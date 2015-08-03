/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */

var deletePortfolioDialog;
var sTotal = 0;

// ----------------------------------------------------------------------
// Portfolios
// ----------------------------------------------------------------------

function initPortfolios(portfolioStatusCounts)
{
	deletePortfolioDialog = new YAHOO.widget.SimpleDialog("deletePortfolioDialog", {
            width:"34em",
            fixedcenter:true,
            visible:false,
            modal:true,
            close:false,
            draggable:false,
            underlay:"none",
            buttons: [
            { text:YAHOO.Adeptra.I18NUtil.label("portal2.common.yes"), handler:null },
            { text:YAHOO.Adeptra.I18NUtil.label("portal2.common.no"), handler:function() {this.hide();}, isDefault:true } ]
        });

	if(ade)
	{
		deletePortfolioDialog.setHeader(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.deleterulegroupconfirmheader"));	
	}		
	else
	{
		deletePortfolioDialog.setHeader(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.deleteportfolioconfirmheader"));
	}

    for (var i = 0; i < apmPortfolios.length; i++)
    {
        var portfolio = apmPortfolios[i];
        var counts = null;
        if (portfolioStatusCounts.breakdown)
        {
            counts = portfolioStatusCounts.breakdown[portfolio.id];
            if (counts)
            {
                sTotal += counts.runningCount;
                sTotal += counts.pendingCount;
            }
        }
    }
    
    for (var i = 0; i < apmPortfolios.length; i++)
    {
        var portfolio = apmPortfolios[i];
        var counts = null;
        if (portfolioStatusCounts.breakdown)
        {
            counts = portfolioStatusCounts.breakdown[portfolio.id];
        }
        newPortfolioRow(portfolio, counts, true);
    }
    
    if(apmPortfolios.length > 0)
    {
      createNewPortfolioLinks();
      createEditDeletePortfolioLinks();
      restripe(document.getElementById('portfolioTable'));
    }
    else
    {
      newPortfolioRemoveForm();
      newPortfolio()
    }
}

function newPortfolioSaveIntercept(e, pos)
{
    YAHOO.util.Event.preventDefault(e);
	if(YAHOO.util.Dom.get("newPortfolioName").value == null || 
	        YAHOO.util.Dom.get("newPortfolioName").value.trim() == "")
	{
		if(ade)
        {
            showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.invalidrulegroupname"));
        }
        else
        {
            showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.namerequired"));
        }
		return false;
	}
	var postData = new Array();
	postData.push({"key":"portfolio.name","value":YAHOO.util.Dom.get("newPortfolioName").value});
	var action = "create";
	if (pos != null)
	{
		var portfolio = apmPortfolios[pos];
		if (portfolio)
		{
			postData.push({"key":"portfolio.id","value":portfolio.id});
			action = "copy";
		}
	}
    JSONRequest.sendMapRequest(
	    'portfolio/' + action + '.action',
        postData,
        {
            success: function(result)
            {
                apmPortfolios.unshift(result.portfolio);
                newPortfolioSave(result.portfolio);
            },
            error: function(result)
            {
                if(result.duplicate)
                {
                   if(ade)
                   {
                       showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.rulegroupnamealreadyexists"));
                   }
                   else
                   {
                       showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.namealreadyexists"));
                   }
                }
                else if(!alertJSONErrorsExt(result))
				{	
			        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"),null);
				}
            },
            failure: function(o)
            {
                alertFailureExt(o, document.location.href);
            }
        });
}

function deletePortfolioYesIntercept(i)
{
	purgeNewPortfolioLinks();
	purgeEditDeletePortfolioLinks();
    JSONRequest.sendRequest(
        'portfolio/delete.action',
        'portfolio.id=' + apmPortfolios[i].id,
        {
            success: function(result)
            {
                apmPortfolios.splice(i, 1);
                deletePortfolioRow(i);
            },
            error: function(result)
            {
           		deletePortfolioDialog.hide();
           		if(ade)
           		{
           			showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.unabletodeleterulegroup"));
           		}
           		else
           		{
           			showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.unabletodeleteportfolio"));
           		}
            },
            failure: function(o)
            {
            	deletePortfolioDialog.hide();
                if (!alertFailureExt(o, document.location.href))
                {
                	if(ade)
                	{
                 	   showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.unabletodeleterulegroup"));
                	}
                	else
                	{
                 	   showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.unabletodeleteportfolio"));
                	}
                }
            }
        });
}

function updatePortfolioCaseCounts(portfolioCaseStatusCounts)
{
  var tableRows = document.getElementById('portfolioTable').rows;
  var td;
  var totalAll = portfolioCaseStatusCounts.runningCount + portfolioCaseStatusCounts.pendingCount + portfolioCaseStatusCounts.suspendedCount;
  for(var i=1;i<tableRows.length;i++)
  {
	  var row = tableRows[i];
	  
	  if(!YAHOO.util.Dom.hasClass(row,"portfolioRow"))
	  {
	    continue;
	  } 
	  
	  var portfolioId = row.id;	  
	  var active = 0;
      var pending = 0;
      var total = 0;
    
	  if (portfolioCaseStatusCounts.breakdown)
	  {
	     var counts = portfolioCaseStatusCounts.breakdown[portfolioId];
	     if(counts)
	     {	     
	     	active = counts.runningCount;
	     	pending = counts.pendingCount;
	     	total = active + pending;
	     }
	  }
	  
	  td = row.cells[1];
	  
	  var a;
      var href = "Analysis.action?instanceName=" + _instanceName + "&portfolioSearch=true&casePortfolioId=" + portfolioId + "&caseState=";
	  if ( active>0 && (!caseCountsLinkLimit || active<=caseCountsLinkLimit) )
	  {
	        a = document.createElement("a");
	        a.setAttribute("href", href + "active");
	        a.innerHTML = active;
	        td.innerHTML = "";
	        td.appendChild(a);
	  }
      else
      {
        td.innerHTML = active;
      }   
      
      td = row.cells[2];

	  if (pending>0 && (!caseCountsLinkLimit || pending<=caseCountsLinkLimit) )
	  {    
		  a = document.createElement("a");
		  a.setAttribute("href", href + "pending");
		  a.innerHTML = pending;
		  td.innerHTML = "";
		  td.appendChild(a);
	  }
	  else
	  {
		  td.innerHTML = pending;
	  }    

     td = row.cells[3];
     if (total>0 && (!caseCountsLinkLimit || total<=caseCountsLinkLimit) )
     {    
        a = document.createElement("a");
        a.setAttribute("href", href + "total");
        a.innerHTML = total; 
        td.innerHTML = "";
        td.appendChild(a);
     }
     else
     {
        td.innerHTML = total;
     }          
     td.appendChild(document.createTextNode(" ( "+ calculatePercentage(total, totalAll) + "% )"));     
  }  
}

function newPortfolio()
{
    purgeEditDeletePortfolioLinks();
    purgeNewPortfolioLinks();

    var newPortfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];

    var title = document.createElement("h1");
    var img = document.createElement("img");
    img.src = "../common/img/iconPortfolio.gif";
    var textNode;
    
    if(ade)
    {
    	img.alt = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newrulegroup");
        img.title = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newrulegroup");
        textNode = document.createTextNode(" " + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newrulegroup"));
    }
    else
    {
       	img.alt = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newportfolio");
        img.title = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newportfolio");
        textNode = document.createTextNode(" " + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.newportfolio"));
    }
    title.appendChild(img);
    title.appendChild(textNode);
    var td = document.createElement("td");
    if(ade)
	{
    	td.colSpan = 6;
	}
    else
	{
    	td.colSpan = 7;
	}
    td.appendChild(title);

    if(ade)
    {
    	textNode = document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.rulegroupname"));
    }
    else
    {
    	textNode = document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.portfolioname"));	
    }
    
    var form = document.createElement("form");
    form.className = "form-inline";
    td.appendChild(form);
    
    var label = document.createElement("label");
    YAHOO.util.Dom.setAttribute(label, "for", "newPortfolioName");
    label.appendChild(textNode);
    form.appendChild(label);

    inputField = document.createElement("input");
    inputField.type = "text";
    inputField.name = "portfolio.name";
    inputField.className="textBox newNameSimple";
    inputField.id="newPortfolioName";

    form.appendChild(inputField);

    var newButton = document.createElement("button");
    newButton.id = "newPortFolioSave";
    newButton.className = "newSaveSimple btn btn-fico btn-primary";
    newButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.save")));

    YAHOO.util.Event.addListener("newPortFolioSave", "click", newPortfolioSaveIntercept, null, true);

    form.appendChild(newButton);

    var tableRows = newPortfolioTbody.getElementsByTagName("tr");

    if(tableRows.length)
    {
        newButton = document.createElement("button");
        newButton.id = "newPortFolioCancel";
        newButton.className = "newCancelSimple btn btn-link";
        newButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.cancel")));

        YAHOO.util.Event.addListener("newPortFolioCancel", "click", newPortfolioCancel);
    }

    form.appendChild(newButton);

    var tr = document.createElement("tr");
    tr.appendChild(td);
    tr.className='newRowSimple';
    tr.id = "newPortfolioRow";

    newPortfolioTbody.insertBefore(tr, newPortfolioTbody.firstChild);

    setFooter();
}

function newPortfolioSave(portfolio)
{
    createNewPortfolioLinks();
    createEditDeletePortfolioLinks();

    var tr = newPortfolioRow(portfolio, null, false);
    var newPortfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
    restripe(document.getElementById('portfolioTable'));
    var attributes = { backgroundColor: { from: '#FDFF1F', to: '#ffffff' } };
    var anim = new YAHOO.util.ColorAnim(tr, attributes, 0.5);
    anim.animate();

    // If the portfolio was copied, remove the edit row
    var editRow = document.getElementById("editPortfolioRow");
    if (editRow)
    {
    	newPortfolioTbody.removeChild(editRow);
    }
    
    setFooter();
}

function newPortfolioCancel(e)
{
	YAHOO.util.Event.preventDefault(e);
    newPortfolioRemoveForm();
    createEditDeletePortfolioLinks();
    var portfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
    var tableRows = portfolioTbody.getElementsByTagName("tr");

    if (tableRows.length)
    {
        createNewPortfolioLinks();
    }
    else
    {
        newPortfolio();
    }
}

function newPortfolioRemoveForm()
{
    var tr = document.getElementById("newPortfolioRow");
    if (tr)
    {
        var portfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
        portfolioTbody.removeChild(tr);
    }
}

function newPortfolioRow(portfolio, counts, append)
{
    var text = portfolio.name;
    var tr = document.createElement("tr");
    tr.className = "portfolioRow";
    tr.id = portfolio.id;

    var portfolioLink = "PortfolioDetails.action?instanceName="+_instanceName+"&portfolio.id="+portfolio.id;

    var td = document.createElement("td");
    td.innerHTML =
            portfolioDetailsLink(portfolio, 'iconPortfolio.gif') + " " +
            portfolioDetailsLink(portfolio);
    tr.appendChild(td);

    var active = "0";
    var pending = "0";
    var suspended = "0";
    var total = "0";
    var strategies = "N/A";
    if (counts)
    {
        active = counts.runningCount;
        pending = counts.pendingCount;
        total = active + pending;
    }

    if(portfolio.orderedStrategies && portfolio.orderedStrategies.length)
    {
        strategies = null;
        var strats = portfolio.orderedStrategies;
        for (var i = 0; i < strats.length; i++)
        {
            var strategy = strats[i];
            if (strategies)
            {
                strategies += " , ";
            }
            else
            {
                strategies = "";
            }
            strategies += strategyDetailsLink(strategy);
        }
    } 

    var a;
    var href = "Analysis.action?instanceName="+_instanceName+"&portfolioSearch=true&casePortfolioId=" + portfolio.id + "&caseState=";

    td = document.createElement("td");
    if ( active>0 && (!caseCountsLinkLimit || active<=caseCountsLinkLimit) )
    {
        a = document.createElement("a");
        a.setAttribute("href", href + "active");
        a.innerHTML = active;
        td.appendChild(a);
    }
    else
    {
        td.innerHTML = active;
    }   
    tr.appendChild(td);

    td = document.createElement("td");
    if (pending>0 && (!caseCountsLinkLimit || pending<=caseCountsLinkLimit) )
    {    
        a = document.createElement("a");
        a.setAttribute("href", href + "pending");
        a.innerHTML = pending;
        td.appendChild(a);
    }
    else
    {
        td.innerHTML = pending;
    }
    tr.appendChild(td);

    td = document.createElement("td");
    if (total>0 && (!caseCountsLinkLimit || total<=caseCountsLinkLimit) )
    {    
        a = document.createElement("a");
        a.setAttribute("href", href + "total");
        a.innerHTML = total; 
        td.appendChild(a);
    }
    else
    {
        td.innerHTML = total;
    }
    td.appendChild(document.createTextNode(" ( "+ calculatePercentage(total, sTotal) + "% )"));
    tr.appendChild(td);

    if(!ade)
    {
        td = document.createElement("td");
        td.innerHTML = strategies;
        tr.appendChild(td);
    }

    if (hasPortfolioPrivilege)
    {
		td = document.createElement("td");
		if(ade)
		{
			td.innerHTML = 
				// TODO: Edit Rule Group Name
				(isApm2 || isAde ? ' <a href="#dead" class="copyPortfolioLink"><img src="../common/img/iconCopy.png" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.copyrulegroup") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.copyrulegroup") + '" /></a>' : '') +
				' <a href="#dead" class="editPortfolioLink"><img src="../common/img/iconEdit.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.editrulegroup") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.editrulegroup") + '" /></a>' +
				' <a href="#dead" class="deletePortfolioLink"><img src="../common/img/iconRemove.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.removerulegroup") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.removerulegroup") + '" /></a>';
		}
		else
		{
			td.innerHTML = 
				// TODO: Edit portfolio name
				//' ' + portfolioDetailsLink(portfolio, 'iconEdit.gif', 'Edit Portfolio') +
				(isApm2 || isAde ? ' <a href="#dead" class="copyPortfolioLink"><img src="../common/img/iconCopy.png" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.copyportfolio") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.copyportfolio") + '" /></a>' : '') +
				' <a href="#dead" class="editPortfolioLink"><img src="../common/img/iconEdit.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.editportfolio") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.editportfolio") + '" /></a>' +
				' <a href="#dead" class="deletePortfolioLink"><img src="../common/img/iconRemove.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.removeportfolio") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.removeportfolio") + '" /></a>';
				// TODO: Portfolio-specific Analysis +
				//' <a href="/apm/Analysis.action?portfolio.id=' + portfolio.id + '"><img src="../common/img/iconBarGraph.gif" alt="Graph" /></a>';
		}
		td.className = 'lastCell3Buttons';
		tr.appendChild(td);
    }

    var portfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];

    newPortfolioRemoveForm();
    if (append)
    {
        portfolioTbody.appendChild(tr);
    }
    else
    {
        portfolioTbody.insertBefore(tr, portfolioTbody.firstChild);
    }
    return tr;
}

function deletePortfolioDialogShow(index)
{
	return function()
	{
		var buttons = deletePortfolioDialog.cfg.getProperty("buttons");
		buttons[0].handler = function() { deletePortfolioYesIntercept(index); };
		deletePortfolioDialog.cfg.setProperty("buttons",buttons);
		if(ade)
		{
			deletePortfolioDialog.setBody(YAHOO.Adeptra.I18NUtil.labelFormat("portal2.apm.portfolios.deleterulegroupconfirm",[apmPortfolios[index].name]));	
		}
		else
		{
			deletePortfolioDialog.setBody(YAHOO.Adeptra.I18NUtil.labelFormat("portal2.apm.portfolios.deleteportfolioconfirm",[apmPortfolios[index].name]));
		}
		deletePortfolioDialog.render(document.body);
                deletePortfolioDialog.show();
	};
}

function deletePortfolioRow(i)
{
    var rows = YAHOO.util.Dom.getElementsByClassName('portfolioRow', 'tr', 'portfolioTable');
    var tbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
    tbody.removeChild(rows[i]);
    deletePortfolioDialog.hide();
    restripe(document.getElementById('portfolioTable'));
	createNewPortfolioLinks();
    createEditDeletePortfolioLinks();
    setFooter();
    if (rows.length == 1)
    {
        newPortfolio();
    }
}

function copyPortfolio(pos)
{
    return function()
    {
		purgeNewPortfolioLinks();
		purgeEditDeletePortfolioLinks();

        var portfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
        var tableRows = portfolioTbody.getElementsByTagName("tr");
        var portfolioRow = tableRows[pos];

        var editRow = createEditPortfolioRow(pos, true);

        YAHOO.util.Dom.insertAfter(editRow, portfolioRow);
		createCopyPortfolioButtonListeners(pos, portfolioRow);
        setFooter();
    }
}

function editPortfolio(pos)
{
    return function()
    {
		purgeNewPortfolioLinks();
		purgeEditDeletePortfolioLinks();

        var portfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
        var tableRows = portfolioTbody.getElementsByTagName("tr");
        var portfolioRow = tableRows[pos];

        var editRow = createEditPortfolioRow(pos, false);

        portfolioTbody.insertBefore(editRow, portfolioRow);
        portfolioTbody.removeChild(portfolioRow);
		createEditPortfolioButtonListeners(pos, portfolioRow);
        setFooter();
    }
}

function editPortfolioSaveIntercept(pos, portfolioRow)
{
    return function(e)
    {
        if(YAHOO.util.Dom.get("editPortfolioName").value == null || 
                YAHOO.util.Dom.get("editPortfolioName").value.trim() == "")
        {
            if(ade)
            {
                showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.invalidrulegroupname"));
            }
            else
            {
                showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.namerequired"));
            }
            return;
        }
        
		var postData = new Array();
		postData.push({"key":"portfolio.name","value":YAHOO.util.Dom.get("editPortfolioName").value});
		postData.push({"key":"portfolio.id","value":YAHOO.util.Dom.get("editPortfolioId").value});
		postData.push({"key":"portfolio.version","value":YAHOO.util.Dom.get("editPortfolioVersion").value});

        JSONRequest.sendMapRequest(
           	'portfolio/rename.action',
            postData,
            {
                success: function(result)
                {
                    editPortfolioSave(pos, portfolioRow, result.portfolio);
                },
                error: function(result)
                {
                    showFieldActionErrors(result);
                },
                failure: function(o)
                {
                    if (!alertFailure(o))
                    {
                        editPortfolioCancel(pos, portfolioRow);
                    }
                }
            });
        YAHOO.util.Event.preventDefault(e);
    }
}

function editPortfolioCancelIntercept(pos, portfolioRow)
{
    return function(e)
    {
        purgeEditPortfolioButtonListeners();
        editPortfolioCancel(pos, portfolioRow);
        YAHOO.util.Event.preventDefault(e);
    }
}

function editPortfolioSave(pos, portfolioRow, portfolio)
{
	purgeEditPortfolioButtonListeners();
	createNewPortfolioLinks();
	createEditDeletePortfolioLinks();

    var portfoliosTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
    var editRow = document.getElementById("editPortfolioRow");

    // update name in apmStrategies
    apmPortfolios[pos] = portfolio;
    // reinsert old row and remove edit row
    portfoliosTbody.insertBefore(portfolioRow, editRow);
    portfoliosTbody.removeChild(editRow);
    // update name in row
    portfolioRow.getElementsByTagName("a")[1].innerHTML = "";
    portfolioRow.getElementsByTagName("a")[1].appendChild(document.createTextNode(portfolio.name));
    // animate
    animRow(portfolioRow);

    setFooter();
}

function editPortfolioCancel(pos, portfolioRow)
{
	createNewPortfolioLinks();
	createEditDeletePortfolioLinks();

    var portfoliosTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];
    var editRow = document.getElementById("editPortfolioRow");

    portfoliosTbody.insertBefore(portfolioRow, editRow);
    portfoliosTbody.removeChild(editRow);

    setFooter();
}

function createEditPortfolioRow(pos, isCopy)
{
    var portfolio = null;
    if (pos >= 0)
    {
        portfolio = apmPortfolios[pos];
    }
    var newPortfolioTbody = document.getElementById('portfolioTable').getElementsByTagName("tbody")[0];

    var title = document.createElement("h1");
    var img = document.createElement("img");
    var textNode;
    img.src = "../common/img/iconPortfolio.gif";
    img.alt = "Portfolio";
    var action = "edit";
    if (isCopy)
    {
    	action = "new";
    }
    if(ade)
    {
    	textNode = document.createTextNode(" " + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios." + action + "rulegroup"));	
    }
    else
    {
    	textNode = document.createTextNode(" " + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios." + action + "portfolio"));
    }
    
    title.appendChild(img);
    title.appendChild(textNode);
    var td = document.createElement("td");
    if(ade)
	{
    	td.colSpan = 6;
	}
    else
	{
    	td.colSpan = 7;
	}

    td.appendChild(title);
    if(ade)
    {
    	textNode = document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.rulegroupname"));
    }
    else
    {
    	textNode = document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.portfolioname"));
    }

    var form = document.createElement("form");
    form.className = "form-inline";
    td.appendChild(form);

    var label = document.createElement("label");
    YAHOO.util.Dom.setAttribute(label, "for", "editPortfolioName");
    label.appendChild(textNode);
    form.appendChild(label);

    inputField = document.createElement("input");
    inputField.type = "text";
    inputField.className="textBox newNameSimple";
    inputField.id="editPortfolioName";
    if (isCopy)
    {
    	inputField.id = "newPortfolioName";
    }
    inputField.value = portfolio.name;

    form.appendChild(inputField);

	inputField = document.createElement("input");
	inputField.type = "hidden";
	inputField.id = "editPortfolioId";
	inputField.value = portfolio.id;
	form.appendChild(inputField);
	inputField = document.createElement("input");
	inputField.type = "hidden";
	inputField.id = "editPortfolioVersion";
	inputField.value = portfolio.version;
	form.appendChild(inputField);

    var newButton = document.createElement("button");
    newButton.id = "editPortfolioSave";
    newButton.className = "newSaveSimple btn btn-fico btn-primary";
    newButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.save")));
    form.appendChild(newButton);

    newButton = document.createElement("button");
	newButton.id = "editPortfolioCancel";
    newButton.className = "newCancelSimple btn btn-link";
    newButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.cancel")));
    form.appendChild(newButton);

    var tr = document.createElement("tr");
    tr.appendChild(td);
    tr.className='newRowSimple';
    tr.id = "editPortfolioRow";

    return tr;
}

function createCopyPortfolioButtonListeners(pos, portfolioRow)
{
    YAHOO.util.Event.addListener("editPortfolioSave", "click", newPortfolioSaveIntercept, pos, true);
    YAHOO.util.Event.addListener("editPortfolioCancel", "click", editPortfolioCancelIntercept(pos, portfolioRow));
}

function createEditPortfolioButtonListeners(pos, portfolioRow)
{
    YAHOO.util.Event.addListener("editPortfolioSave", "click", editPortfolioSaveIntercept(pos, portfolioRow));
    YAHOO.util.Event.addListener("editPortfolioCancel", "click", editPortfolioCancelIntercept(pos, portfolioRow));
}

function purgeEditPortfolioButtonListeners()
{
    YAHOO.util.Event.purgeElement(YAHOO.util.Dom.get("editPortfolioSave"));
    YAHOO.util.Event.purgeElement(YAHOO.util.Dom.get("editPortfolioCancel"));
}

function createNewPortfolioLinks()
{
	if (hasPortfolioPrivilege)
    {
		var div = document.getElementById('portfolioHeaderLinks');
		div.style.opacity = "1";
		div.style.filter = "alpha(opacity=100)";
		YAHOO.util.Event.addListener("newPortfolioImage", "click", newPortfolio);
		YAHOO.util.Event.addListener("newPortfolio", "click", newPortfolio);
    }
}

function purgeNewPortfolioLinks()
{
	if (hasPortfolioPrivilege)
    {
		var div = document.getElementById('portfolioHeaderLinks');
		div.style.opacity = "1";
		div.style.filter = "alpha(opacity=100)";
		YAHOO.util.Event.purgeElement(YAHOO.util.Dom.get("newPortfolioImage"));
		YAHOO.util.Event.purgeElement(YAHOO.util.Dom.get("newPortfolio"));
    }
}

function createEditDeletePortfolioLinks()
{    
	setTimeout(addListeners('deletePortfolioLink', 'a', 'portfolioTable', 'deletePortfolioDialogShow'), 0);
	setTimeout(addListeners('editPortfolioLink', 'a', 'portfolioTable', 'editPortfolio'), 0);
	setTimeout(addListeners('copyPortfolioLink', 'a', 'portfolioTable', 'copyPortfolio'), 0);
}

function purgeEditDeletePortfolioLinks()
{
  var links = YAHOO.util.Dom.getElementsByClassName('deletePortfolioLink', 'a', 'portfolioTable');
  for (var i=0; i<links.length; i++)
  {
    YAHOO.util.Event.purgeElement(links[i]);
  }
  links = YAHOO.util.Dom.getElementsByClassName('editPortfolioLink', 'a', 'portfolioTable');
  for (var i=0; i<links.length; i++)
  {
    YAHOO.util.Event.purgeElement(links[i]);
  }
  links = YAHOO.util.Dom.getElementsByClassName('copyPortfolioLink', 'a', 'portfolioTable');
  for (var i=0; i<links.length; i++)
  {
    YAHOO.util.Event.purgeElement(links[i]);
  }
}

function animRow(row)
{
    var attributes;
    var anim;
    if (row.className.indexOf("oddRow") >= 0)
    {
        attributes = { backgroundColor: {from: '#FDFF1F', to: '#ffffff' } };
        anim = new YAHOO.util.ColorAnim(row, attributes, 1);
    }
    else
    {
        attributes = { backgroundColor: {from: '#FDFF1F', to: '#f3f3f3' } };
        anim = new YAHOO.util.ColorAnim(row, attributes, 1);
    }
    anim.animate();
}
