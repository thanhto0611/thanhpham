/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */

// global, to be initialized on page load
var apmStrategies = null;
var apmPortfolios = null;
var portfolioFilter = null;
var variableNames = null;
var callWindows = null;
var filterRules = null;
var apmSettingValueConfig = null;
var apmPhoneSettingActionNames = null;
var conditionLogicalOperators = null;
var tenants = null;

var filterDragDrop = [];
var ddTargetDragDrop = [];
var autoCompletes = null;

var functionEditorInstance = null;

var valueToLabelTranslations;

//used to created the variable list DIV in Function editor
var ruleDatums;

//used by autocomplete in Condition fields and FunctionEditor parameter fields
var variableListDS;

var inputVariablesList;

var variableListDOM = null;

var deleteDialog;

var toolTipMaxLength = 42;
var regex = new RegExp(".{1," + toolTipMaxLength + "}", "g");

var activeDDInput;

function deleteDialogShow(index,name)
{
    return function()
    {
        var buttons = deleteDialog.cfg.getProperty("buttons");
        buttons[0].handler = function() { deleteFilterYesIntercept(deleteDialog, index); };
        deleteDialog.cfg.setProperty("buttons",buttons);
        deleteDialog.setBody(YAHOO.Adeptra.I18NUtil.labelFormat("portal2.apm.portfolios.filter.deleteruleconfirm",[name]));
        deleteDialog.render(document.body);
        deleteDialog.show();
    };
}

function getInputTooltip(inputValue)
{
    var tooltip = "";
    if (inputValue.length > toolTipMaxLength)
    {
    	var chunkedValue = inputValue.match(regex);
        for (index = 0; index < chunkedValue.length; index++) {
            chunkedValue[index] = YAHOO.Adeptra.Common.escapeHtml(chunkedValue[index]);
        }
    	tooltip = chunkedValue.join("<br />");
    }
    else
    {
    	tooltip = YAHOO.Adeptra.Common.escapeHtml(inputValue);
    }
    return tooltip;
}

function initVariableListDOM()
{
	 if (variableListDOM == null)
     {
         variableListDOM = YAHOO.util.Dom.get('variableListCol').cloneNode(true);
         variableListDOM.id = null;
         var varSelect = YAHOO.util.Dom.getElementsByClassName('dynamicList','select', variableListDOM);
         YAHOO.util.Event.addListener(varSelect[0], 'change', dynamicList,variableListDOM);
     }

     //initialize variable list DOM and the drag drop source
     variableListDOM.style.display="block";
     var divs = YAHOO.util.Dom.getElementsByClassName('draggableInput','div', variableListDOM);

    for (var c = 0, i = divs.length; c < i; c += 1)
    {
    	var elementToDragAndDrop = divs[c].firstChild;
    	YAHOO.util.Event.purgeElement(elementToDragAndDrop);
    	YAHOO.util.Event.on(elementToDragAndDrop, "mouseenter", initDragDrop);
    }
}

function updateVariableListDOM(targetGroupId,value,label)
{
    // main variable list DOM
    var optionGroups = YAHOO.util.Dom.getElementsByClassName('optionGroup', 'div', variableListDOM);
    // iterate over them
    for (var i=0; i<optionGroups.length; i++)
    {
        var optionGroup = optionGroups[i];
        if (optionGroup.id == targetGroupId)
        {
            var div = document.createElement("div");
            YAHOO.util.Dom.addClass(div,"option draggableInput");
            var span = document.createElement("span");
            YAHOO.util.Dom.addClass(span,"drag-variable");
            div.appendChild(span);
            span.setAttribute("value",value);
            span.setAttribute("data-raw",value);
            span.appendChild(document.createTextNode(label));
            optionGroup.appendChild(div);
            break;
        }
    }
    initVariableListDOM();
}

function dynamicList(e,rootId)
{
    var list = YAHOO.util.Event.getTarget(e);
    var selectedId = list.options[list.selectedIndex].id;  //the ID of the selected item in the list

    // get all the option groups in the lower panel
    var optionGroups = YAHOO.util.Dom.getElementsByClassName('optionGroup', 'div', rootId);

    // iterate over them
    for (var i=0; i<optionGroups.length; i++)
    {
        var optionGroup = optionGroups[i];
        if (optionGroup.id == selectedId || selectedId == 'all')
        {
            optionGroup.className = 'optionGroup';
        }
        else
        {
            optionGroup.className = 'optionGroup noDisplay';
        }
    }
}

function initDragDrop(e)
{
	var elementToDragDrop = YAHOO.util.Event.getTarget(e);
    activeDDInput = new DDInput(elementToDragDrop, "inputs",
    {
        onDragDropHandler : function(dragValue,targetElement,srcElement)
        {
        	YAHOO.util.Event.removeListener(targetElement,"click");
        	targetElement.setAttribute("data-raw", srcElement.getAttribute("data-raw"));                           
        	targetElement.value = dragValue;
        	targetElement.title = getInputTooltip(dragValue);
            purgeParameterFieldClasses(targetElement);
            if(YAHOO.util.Dom.hasClass(srcElement,'drag-variable'))
            {
                YAHOO.util.Dom.addClass(targetElement,'variable');
            }
            else if(YAHOO.util.Dom.hasClass(srcElement,'drag-literal'))
            {
                YAHOO.util.Dom.addClass(targetElement,'literal');
            }
            else if(YAHOO.util.Dom.hasClass(srcElement,'drag-function'))
            {
            	var functionName = YAHOO.Adeptra.Labels.getFunctionName(srcElement.getAttribute("data-raw"));
                functionEditorInstance.showNewFunctionPanel(functionName,targetElement);
            }
        }
    });
}
// ======================================================================
// Filter Rules
// ======================================================================
var FILTER_ACTION_PROTOTYPE;

function initFilterRows()
{
    FILTER_ACTION_PROTOTYPE = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', 'newFilterActions')[0].cloneNode(true);

    initPhoneSettingActionNames();
    var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
    var loadingRow = document.getElementById('loadingFiltersRow');
    if (loadingRow)
    {
        tbody.removeChild(loadingRow);
    }
    for (var i = 0; i < filterRules.length; i++)
    {
        var rule = filterRules[i];
                var newRow = document.createElement("tr");
        tbody.appendChild(newRow);
        createFilterRow(rule, i,newRow);
    }
    // if no rule edit privilege, updown button appears disabled
    if (hasRulePrivilege)
    {
      rePrioritize();
      createFilterListers();
    }
    updateFiltersEnabled();
    setFooter();
    if (filterRules.length == 0 && hasRulePrivilege)
    {
        setTimeout(newFilter(-1), 0);
    }
}

function initPhoneSettingActionNames()
{
    if (apmPhoneSettingActionNames == null)
    {
        apmPhoneSettingActionNames = new Array();
        if(apmSettingValueConfig)
        {
            for (var i = 0; i < apmSettingValueConfig.length; i++)
            {
                if (apmSettingValueConfig[i].type != "PHONE")
                {
                    continue;
                }
                var phoneSettingConfig = apmSettingValueConfig[i];
                var settingConfigs = getPhoneSettingConfigs(phoneSettingConfig);
                if (settingConfigs != null)
                {
                    for (var j = 0; j < settingConfigs.length; j++)
                    {
                        // map SET action by setting name and label
                        apmPhoneSettingActionNames[settingConfigs[j].name] = phoneSettingConfig;
                        apmPhoneSettingActionNames[settingConfigs[j].label] = phoneSettingConfig;
                    }
                }
            }
        }
    }
}

function getPhoneSettingConfigs(phoneSettingConfig)
{
    // return the trio of constituent settingConfigs for the given PHONE type settingConfig
    var settingNameCC = phoneSettingConfig.name + ".cc";
    var settingNameAC = phoneSettingConfig.name + ".ac";
    var settingNameNum = phoneSettingConfig.name + ".num";
    var settingConfigCC = findSettingConfigByName(settingNameCC);
    var settingConfigAC = findSettingConfigByName(settingNameAC);
    var settingConfigNum = findSettingConfigByName(settingNameNum);
    if (settingConfigCC != null && settingConfigAC != null && settingConfigNum != null)
    {
        var configs = new Array();
        configs.push(settingConfigCC, settingConfigAC, settingConfigNum);
        return configs;
    }
    return null;
}

function getActionPhoneSettingConfig(action)
{
    // return the settingConfig for the PHONE type that the given action is a member of
    return apmPhoneSettingActionNames[action.settingName];
}

function getRulePhoneActions(phoneSettingConfig, rule)
{
    // return the trio of rule SET actions for the given PHONE type
    var setCC = null, setAC = null, setNum = null;
    var settingNameCC = phoneSettingConfig.name + ".cc";
    var settingNameAC = phoneSettingConfig.name + ".ac";
    var settingNameNum = phoneSettingConfig.name + ".num";
    for (var i = 0; i < rule.actions.length; i++)
    {
        var action = rule.actions[i];
        if (action.action != 4)
        {
            continue;
        }
        var settingConfig = findSettingConfigByName(action.settingName);
        if (settingConfig.name == settingNameCC)
        {
            setCC = action;
        }
        else if (settingConfig.name == settingNameAC)
        {
            setAC = action;
        }
        else if (settingConfig.name == settingNameNum)
        {
            setNum = action;
        }
    }
    if (setCC != null && setAC != null && setNum != null)
    {
        var actions = new Array();
        actions.push(setCC, setAC, setNum);
        return actions;
    }
    return null;
}

function handleFilterListeners()
{
    purgeFilterListeners();
    createFilterListers();
}

function purgeFilterListeners(excludeHandles)
{
    // prioritize arrows
    purgePrioritizeLinks();
    // drag-drop prioritize
    if (!excludeHandles)
    {
        purgeFilterHandles();
    }
    // enabled checkbox
    purgeDisableFilterLinks();
    // edit/new
    purgeFilterLinks();
    // delete
    purgeDeleteFilterLinks();
}

function createFilterListers()
{
    // prioritize arrows
    createPrioritizeLinks();
    // drag-drop prioritize
    createFilterHandles();
    // enabled checkbox
    createDisableFilterLinks();
    // edit/new
    createFilterLinks();
    // delete
    createDeleteFilterLinks();
}

// ----------------------------------------------------------------------
// Prioritize
// ----------------------------------------------------------------------

function purgePrioritizeLinks()
{
    var elements = YAHOO.util.Dom.getElementsByClassName('downPrioritize', 'a', 'portfolioFilterTable');
    for (var i=0; i<elements.length; i++)
    {
        var link = elements[i];
        YAHOO.util.Event.purgeElement(link);
    }
    elements = YAHOO.util.Dom.getElementsByClassName('upPrioritize', 'a', 'portfolioFilterTable');
    for (var i=0; i<elements.length; i++)
    {
        var link = elements[i];
        YAHOO.util.Event.purgeElement(link);
    }
}

function createPrioritizeLinks()
{
    setTimeout(addListeners('upPrioritize', 'a', 'portfolioFilterTable', 'upPrioritize'), 0);
    setTimeout(addListeners('downPrioritize', 'a', 'portfolioFilterTable', 'downPrioritize'), 0);
}

function upPrioritize(pos)
{
    return function()
    {
        setPriorityIntercept(pos+1, pos, false);
    };
}

function downPrioritize(pos)
{
    return function()
    {
        setPriorityIntercept(pos, pos+1, false);
    };
}

function rePrioritize()
{
    restripe(document.getElementById('portfolioFilterTable'));
    var arrows = YAHOO.util.Dom.getElementsByClassName('priorityArrows', 'td', 'portfolioFilterTable');

    for (var i=0; i<arrows.length; i++)
    {
        var images = arrows[i].getElementsByTagName("img");
        var links = arrows[i].getElementsByTagName("a");

        if (i == 0)
        {
            images[0].src="../common/img/iconPriorityUpDisabled.gif";
            images[1].src="../common/img/iconPriorityDown.gif";
            links[0].className="";
            links[1].className="downPrioritize";
        }
        else if (i == (arrows.length-1))
        {
            images[0].src="../common/img/iconPriorityUp.gif";
            images[1].src="../common/img/iconPriorityDownDisabled.gif";
            links[0].className="upPrioritize";
            links[1].className="";
        }
        else
        {
            images[0].src="../common/img/iconPriorityUp.gif";
            images[1].src="../common/img/iconPriorityDown.gif";
            links[0].className="upPrioritize";
            links[1].className="downPrioritize";
        }
        arrows[i].getElementsByTagName("strong")[0].innerHTML=(i+1);
    }
}

function setPriorityIntercept(srcPos, destPos, inDD)
{
    purgeFilterListeners(inDD);
    disableCheckBoxes(true);
    var postData = 'filter.id=' + portfolioFilter.id;
    var ids = new Array();
    for (var i = 0; i < filterRules.length; i++)
    {
        ids.push(filterRules[i].id);
    }
    ids.splice(srcPos, 1);
    ids.splice(destPos, 0, filterRules[srcPos].id);
    for (var i = 0; i < filterRules.length; i++)
    {
        postData += '&';
        var rule = filterRules[i];
        postData += 'filter.rules[' + i + '].id=';
        postData += ids[i];
    }
    JSONRequest.sendRequest(
        'filter/order.action',
        postData,
        {
            success: function(result)
            {
                var rule = filterRules[srcPos];
                filterRules.splice(srcPos, 1);
                filterRules.splice(destPos, 0, rule);
                createFilterListers();
                disableCheckBoxes(false);
            },
            error: function(result)
            {
                if(!alertJSONErrorsExt(result))
                                {
                                        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"),null);
                                }
                setPrioritySuccess(destPos, srcPos);
                createFilterListers();
                disableCheckBoxes(false);
            },
            failure: function(o)
            {
                if (!alertFailureExt(o, document.location.href))
                {
                    setPrioritySuccess(destPos, srcPos);
                    createFilterListers();
                    disableCheckBoxes(false);
                }
            }
        });
    setPrioritySuccess(srcPos, destPos);
}

function setPrioritySuccess(srcPos, destPos)
{
    var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');

    var srcRow = rows[srcPos];
    if (srcPos > destPos)
    {
        tbody.insertBefore(srcRow, rows[destPos]);
    }
    else
    {
        tbody.insertBefore(srcRow, rows[destPos].nextSibling);
    }
    rePrioritize();
    animRow(srcRow);
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
        attributes = { backgroundColor: {from: '#FDFF1F', to: '#f2f2f2' } };
        anim = new YAHOO.util.ColorAnim(row, attributes, 1);
    }
    anim.animate();
}

// ----------------------------------------------------------------------
// Prioritize Drag/drop
// ----------------------------------------------------------------------

function purgeFilterHandles()
{
    for (var i = 0; i < filterDragDrop.length; i++)
    {
        filterDragDrop[i].unreg();
    }
    filterDragDrop = new Array();
}

function createFilterHandles()
{
    var filterRows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
    if (filterRows.length > 1)
    {
        for (var i=0; i<filterRows.length; i++)
        {
            filterRows[i].id="filter" + (i+1);
            filterRows[i].getElementsByTagName('td')[0].id="filterHandle" + (i+1);
        }
        ddTable();
    }
}

function ddTable()
{
    var filterRows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr');
    YAHOO.util.DDM.mode = YAHOO.util.DDM.INTERSECT;
    for (var i=0; i < filterRows.length; i++)
    {
        filterDragDrop[i] = new DDTable(filterRows[i]);
        filterDragDrop[i].setHandleElId("filterHandle" + (i+1));
    }
}

/*
function disableFilterDD(on)
{
    if (on) {
        for(var i=0; i<filterDragDrop.length; i++) {
            filterDragDrop[i].lock();
        }
    } else {
        for(var i=0; i<filterDragDrop.length; i++) {
            filterDragDrop[i].unlock();
        }
    }
}
*/

// ----------------------------------------------------------------------
// Enable/Disable
// ----------------------------------------------------------------------

function purgeDisableFilterLinks()
{
    var links = YAHOO.util.Dom.getElementsByClassName('disableFilter', 'input', 'portfolioFilterTable');

    for (var i = 0; i < links.length; i++)
    {
        var link = links[i];
        YAHOO.util.Event.purgeElement(link);
   }
}

function createDisableFilterLinks()
{
    setTimeout(addListeners('disableFilter', 'input', 'portfolioFilterTable', 'disableFilter'), 0);
}

function disableFilter(pos)
{
    return function()
    {
        disableFilterIntercept(pos);
    };
}

function disableFilterIntercept(pos)
{
    var rule = filterRules[pos];
    var enabled = rule.enabled;
    JSONRequest.sendRequest(
        'rule/enable.action',
        'rule.id=' + rule.id 
        	+ '&rule.enabled=' + (rule.enabled ? 'false' : 'true')
        	+ '&rule.filter.id=' + portfolioFilter.id,
        {
            success: function(result)
            {
                rule.enabled = !rule.enabled;
                updateFilterEnabled(rule);
            },
            error: function(result)
            {
                if(!alertJSONErrorsExt(result))
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

function updateFilterEnabled(rule)
{

    var checks = YAHOO.util.Dom.getElementsByClassName('disableFilter', 'input', 'portfolioFilterTable');
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');

    var pos = -1;
    for (var i = 0; i < filterRules.length; i++)
    {
        if (filterRules[i].id == rule.id)
        {
            pos = i;
            break;
        }
    }

    var cells = rows[pos].childNodes;
    if (pos >= 0)
    {
        if (checks[pos].checked == "")
        {
            for (var c=0; c<cells.length; c++)
            {
                YAHOO.util.Dom.setStyle(cells[c], 'color', 'gray');
                if (cells[c].childNodes && cells[c].childNodes[0].nodeName=="A")
                {
                    YAHOO.util.Dom.setStyle(cells[c].childNodes[0], 'color', 'gray');
                }
            }
        }
        else
        {
            for (var c=0; c<cells.length; c++)
            {
                YAHOO.util.Dom.setStyle(cells[c], 'color', 'black');
                if (cells[c].childNodes && cells[c].childNodes[0].nodeName=="A")
                {
                    YAHOO.util.Dom.setStyle(cells[c].childNodes[0], 'color', 'black');
                }
            }
        }
    }
}

function updateFiltersEnabled()
{
    var checks = YAHOO.util.Dom.getElementsByClassName('disableFilter', 'input', 'portfolioFilterTable');
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');

    for (var j = 0; j < checks.length; j++)
    {
        var cells = rows[j].childNodes;
        if (checks[j].checked == "")
        {
            for (var c=0; c<cells.length; c++)
            {
                YAHOO.util.Dom.setStyle(cells[c], 'color', 'gray');
                if (cells[c].childNodes && cells[c].childNodes[0].nodeName=="A")
                {
                    YAHOO.util.Dom.setStyle(cells[c].childNodes[0], 'color', 'gray');
                }
            }
        }
        else
        {
            for (var c=0; c<cells.length; c++)
            {
                YAHOO.util.Dom.setStyle(cells[c], 'color', 'black');
                if (cells[c].childNodes && cells[c].childNodes[0].nodeName=="A")
                {
                    YAHOO.util.Dom.setStyle(cells[c].childNodes[0], 'color', 'black');
                }
            }
        }
    }
}

function disableCheckBoxes(status)
{
    purgeDisableFilterLinks();
    var checkboxes = YAHOO.util.Dom.getElementsByClassName('disableFilter', 'input', 'portfolioFilterTable');

    if (status == true)
    {
        for (var i=0; i<checkboxes.length; i++) checkboxes[i].disabled = "disabled";
    }
    else
    {
        for (var i=0; i<checkboxes.length; i++) checkboxes[i].disabled = "";
    }
}

// ----------------------------------------------------------------------
// Delete
// ----------------------------------------------------------------------

function purgeDeleteFilterLinks()
{
    var links = YAHOO.util.Dom.getElementsByClassName('deleteFilterLink', 'a', 'portfolioFilterTable');

    for (var i=0; i<links.length; i++)
    {
        YAHOO.util.Event.purgeElement(links[i]);
    }
}

function createDeleteFilterLinks()
{
    var links = YAHOO.util.Dom.getElementsByClassName('deleteFilterLink', 'a', 'portfolioFilterTable');
    var names = YAHOO.util.Dom.getElementsByClassName('filterName', 'td', 'portfolioFilterTable');

    for (var i=0; i<links.length;i++)
    {
        YAHOO.util.Event.addListener(links[i], "click", deleteDialogShow(i,names[i].innerHTML));
    }
}

function deleteFilterYesIntercept(dialog, i)
{
    var postData = 'filter.id=' + portfolioFilter.id +
        "&filter.rules[0].id="+filterRules[i].id;
    JSONRequest.sendRequest(
        'filter/deleteRule.action',
        postData,
        {
            success: function(result)
            {
                filterRules.splice(i, 1);
                deleteFilterRow(dialog, i);
            },
            error: function(result)
            {
                if(!alertJSONErrorsExt(result))
                                {
                                        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"),null);
                                }
                                dialog.hide();
            },
            failure: function(o)
            {
                if (!alertFailureExt(o, document.location.href))
                {
                    dialog.hide();
                }
            }
        });
}

function deleteFilterRow(dialog, i)
{
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
    var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
    tbody.removeChild(rows[i]);
    dialog.hide();
    rePrioritize();
    handleFilterListeners();

    setFooter();

    if(rows.length == 1)
    {
        setTimeout(newFilter(-1), 0);
    }
}

// ----------------------------------------------------------------------
// Edit/New links
// ----------------------------------------------------------------------

function handleFilterLinks()
{
    purgeFilterLinks();
    purgeDeleteFilterLinks();
    createFilterLinks();
    createDeleteFilterLinks();
}

function purgeFilterLinks()
{
    var editFilterLinks = YAHOO.util.Dom.getElementsByClassName('editFilterLink', 'a', 'portfolioFilterTable');
    var newFilterLinks = YAHOO.util.Dom.getElementsByClassName('newFilterLink', 'a', 'portfolioFilterTable');
    var copyFilterLinks = YAHOO.util.Dom.getElementsByClassName('copyFilterLink', 'a', 'portfolioFilterTable');

    for (var i=0; i<copyFilterLinks.length; i++)
    {
        var link = copyFilterLinks[i];
        YAHOO.util.Event.purgeElement(link);
    }
    for (var i=0; i<newFilterLinks.length; i++)
    {
        var link = newFilterLinks[i];
        YAHOO.util.Event.purgeElement(link);
    }
    for (var i=0; i<editFilterLinks.length; i++)
    {
        var link = editFilterLinks[i];
        YAHOO.util.Event.purgeElement(link);
    }
}

function createFilterLinks()
{
    setTimeout(addListeners('newFilterLink', 'a', 'portfolioFilterTable', 'newFilter'), 0);
    setTimeout(addListeners('editFilterLink', 'a', 'portfolioFilterTable', 'editFilter'), 0);
    setTimeout(addListeners('copyFilterLink', 'a', 'portfolioFilterTable', 'copyFilter'), 0);
}

function initConditionRow(condition, filterConditionRow)
{
    var inputs = filterConditionRow.getElementsByTagName('input');
    var selects = filterConditionRow.getElementsByTagName('select');

    if (condition != undefined)
    {
	    purgeParameterFieldClasses(inputs[1]);
	    purgeParameterFieldClasses(inputs[2]);
	
	    YAHOO.util.Event.addListener(inputs[1],"keyup",changeToLiteralFieldUpdateRaw);
	    YAHOO.util.Event.addListener(inputs[2],"keyup",changeToLiteralFieldUpdateRaw); 
	
	    setConditionOrActionValue(condition.value1, inputs[1]);
	
	    setConditionOrActionValue(condition.value2, inputs[2]);
	
	    selectInOptions(condition.operator, selects.length == 1 ? selects[0].options : selects[1].options);

	    var elementsToShow = YAHOO.util.Dom.getElementsByClassName('hideOnAlwaysRun', 'td', filterConditionRow);
		for (var c = 0, i = elementsToShow.length; c < i; c += 1)
		{
			YAHOO.util.Dom.removeClass(elementsToShow[c], "noDisplay");
		}
		var elementToHide = YAHOO.util.Dom.getElementsByClassName('alwaysRun', 'td',  filterConditionRow)[0];
		YAHOO.util.Dom.addClass(elementToHide, "noDisplay");
    }
    else
    {
    	var elementsToHide = YAHOO.util.Dom.getElementsByClassName('hideOnAlwaysRun', 'td', filterConditionRow);
    	for (var c = 0, i = elementsToHide.length; c < i; c += 1)
    	{
    		YAHOO.util.Dom.addClass(elementsToHide[c], "noDisplay");
    	}
    	var elementToShow = YAHOO.util.Dom.getElementsByClassName('alwaysRun', 'td',  filterConditionRow)[0];
    	YAHOO.util.Dom.removeClass(elementToShow, "noDisplay");
    	var elementToHide = YAHOO.util.Dom.getElementsByClassName('removeCondition', 'a', filterConditionRow)[0];
    	YAHOO.util.Dom.addClass(elementToHide, "noDisplay");
    }
}

function setConditionOrActionValue(inputValue, inputElement)
{
   YAHOO.util.Event.removeListener(inputElement,"click");
   
   inputElement.setAttribute("data-raw", inputValue);

   if(isNamedFunction(inputValue))
   {
       var arr = getNamedFunctionComponents(inputValue);
       inputElement.value = arr[1];
       inputElement.title = getInputTooltip(arr[2]);
       inputElement.hiddenValue = inputValue;
       YAHOO.util.Event.addListener(inputElement, "click",functionEditorInstance.showEditFunctionPanel,functionEditorInstance,true);
       YAHOO.util.Dom.addClass(inputElement,"named-function");
   }
   else if(isFunction(inputValue))
   {
	   inputElement.value = YAHOO.Adeptra.Labels.generate(inputValue);
	   inputElement.title = getInputTooltip(inputElement.value);
       YAHOO.util.Event.addListener(inputElement, "click",functionEditorInstance.showEditFunctionPanel,functionEditorInstance,true);
       YAHOO.util.Dom.addClass(inputElement,"general-function");
   }
   else if(isVariable(inputValue))
   {
       inputElement.value = YAHOO.Adeptra.Labels.generate(inputValue);
	   inputElement.title = getInputTooltip(inputElement.value);
       YAHOO.util.Dom.addClass(inputElement,"variable");
   }
   else
   {
       inputElement.value = YAHOO.Adeptra.Labels.generate(inputValue);
	   inputElement.title = getInputTooltip(inputElement.value);
   }
}

function isNonModifierKey(e) {
	return ((e.keyCode >= 33 && e.keyCode <= 40) || e.keyCode == 13 || e.keyCode == 16
    || (e.keyCode >= 17 && e.keyCode <= 20) || e.keyCode == 45 || e.keyCode == 27 || e.keyCode == 145
    || e.keyCode == 9 || e.keyCode == 144 || (e.keyCode >= 112 && e.keyCode <= 123));
}

function changeToLiteralField(e)
{
  //return on keys which do not modify the content of the text field
  if(isNonModifierKey(e))
  {
    return;
  }
  var target = YAHOO.util.Event.getTarget(e);
  purgeParameterFieldClasses(target);
  YAHOO.util.Dom.addClass(target,"literal");
  if(target.hiddenValue != null)
  {
      target.hiddenValue = "";
  }
  target.setAttribute("data-raw", "");
}

function changeToLiteralFieldUpdateRaw(e)
{
  //return on keys which do not modify the content of the text field
  if(isNonModifierKey(e))
  {   
   return;
  }
  var target = YAHOO.util.Event.getTarget(e);
  purgeParameterFieldClasses(target);
  YAHOO.util.Dom.addClass(target,"literal");
  if(target.hiddenValue != null)
  {
      target.hiddenValue = "";
  }
  
  if (isNamedFunction(target.value)) 
  {
	  target.setAttribute("data-raw", target.value);	  
  } 
  else 
  {
	  target.setAttribute("data-raw", "constant:"+target.value);
  }
}

// simple check for a number
function isNumber(n) 
{
    return !isNaN(parseFloat(n)) && isFinite(n);
}


// Used in functionEditor, leave literal input as literal
function changeToLiteralFieldFE(e)
{
  //return on keys which do not modify the content of the text field
  if(isNonModifierKey(e))
  {
    return;
  }
  var target = YAHOO.util.Event.getTarget(e);
  purgeParameterFieldClasses(target);
  YAHOO.util.Dom.addClass(target,"literal");

  if (isNumber(target.value))
  {
    target.setAttribute("data-raw", target.value);
  }
  else
  {
	var value = "'" + target.value.replace(/\'/g,'') + "'";
    target.setAttribute("data-raw", value);	  
  }
}

function extractConditionRowCondition(filterConditionRow,filterConditionRowNext)
{
	var tds = YAHOO.util.Dom.getElementsByClassName('noDisplay', 'td', filterConditionRow);
	if (tds.length == 3)
	{
		return;
	}
    var inputs = filterConditionRow.getElementsByTagName('input');
   
    var selects = filterConditionRow.getElementsByTagName('select');
    var operatorSelect = selects.length == 1 ? selects[0] : selects[1];

    var condition = {
        operator:operatorSelect.options[operatorSelect.selectedIndex].value,
                logicalOperator:filterConditionRowNext ? filterConditionRowNext.getElementsByTagName('select')[0].value: "A",
        value1:getRawValue(inputs[1]),
        value2:getRawValue(inputs[2])
    };
    return condition;
}

function getRawValue(inputObj)
{
    var raw = inputObj.getAttribute("data-raw");
    return (raw == undefined || raw == null || raw == "" || raw == "null") ? "constant:" : raw;
}

function getNamedFnExprValue(inputObj, raw)
{ 
    if(inputObj.hiddenValue != null)
    {
        var splitHiddenValues = inputObj.hiddenValue.split(":");
        if(inputObj.value.indexOf(splitHiddenValues[1])!= -1)
        {
            return inputObj.hiddenValue;
        }
        else
        {
            return inputObj.value;
        }
    }
    
    if (raw)
    {
    	return getRawValue(inputObj);
    } 
    else 
    {
        return inputObj.value;
    }
}

function purgeParameterFieldClasses(fieldObj)
{
  YAHOO.util.Dom.removeClass(fieldObj, "variable");
  YAHOO.util.Dom.removeClass(fieldObj, "literal");
  YAHOO.util.Dom.removeClass(fieldObj, "general-function");
  YAHOO.util.Dom.removeClass(fieldObj, "named-function");
}

function selectInOptions(value, options)
{
    for (var i = 0; i < options.length; i++)
    {
        if (value == options[i].value)
        {
            options[i].selected = "selected";
        }
        else
        {
            options[i].selected = "";
        }
    }
}

function isSettingText(settingName)
{
    var settingConfig = findSettingConfig(settingName);
    if (settingConfig != null)
    {
        return (settingConfig.type == "TEXT");
    }
    return false;
}

function isSettingSelect(settingName)
{
    var settingConfig = findSettingConfig(settingName);
    if (settingConfig != null)
    {
        return (settingConfig.type == "INT" || settingConfig.type == "CHOICE" || settingConfig.type == "CALLWINDOW");
    }
    return false;
}

function isSettingPhone(settingName)
{
    var settingConfig = findSettingConfig(settingName);
    if (settingConfig != null)
    {
        return (settingConfig.type == "PHONE");
    }
    return false;
}

function findSettingConfig(settingName)
{
    if(apmSettingValueConfig)
    {
      for (var i = 0; i < apmSettingValueConfig.length; i++)
      {
        var settingConfig = apmSettingValueConfig[i];
        if (settingConfig.name == settingName)
        {
            return settingConfig;
        }
      }
    }
    return null;
}

function findSettingConfigByLabel(settingLabel)
{
    if(apmSettingValueConfig)
    {
        for (var i = 0; i < apmSettingValueConfig.length; i++)
        {
            var settingConfig = apmSettingValueConfig[i];
            if (settingConfig.label == settingLabel)
            {
                return settingConfig;
            }
        }
    }
    return {};
}

function findSettingConfigByName(settingName)
{
    for (var i = 0; i < apmSettingValueConfig.length; i++)
    {
        var settingConfig = apmSettingValueConfig[i];
        if (settingConfig.name == settingName)
        {
            return settingConfig;
        }
    }
    return null;
}

function getSelectedSettingConfig(filterActionRow)
{
    var settingSelect = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterActionRow)[0];
    var settingName = null;
    if(settingSelect.selectedIndex != -1)
    {
            settingName = settingSelect[settingSelect.selectedIndex].value;
    }
    return findSettingConfig(settingName);
}

function initSettingValueSelect(filterActionRow)
{
    var settingValueSelect = YAHOO.util.Dom.getElementsByClassName('settingValueList', 'select', filterActionRow)[0];
    for (var i = settingValueSelect.options.length; i >= 0; i--)
    {
        settingValueSelect.options[i] = null;
    }
    var settingConfig = getSelectedSettingConfig(filterActionRow);
    if (settingConfig != null)
    {
        if (settingConfig.type == "INT")
        {
            var j = 0;
            for(var i = settingConfig.minInt; i <= settingConfig.maxInt; i++)
            {
                settingValueSelect.options[j] = new Option(i, i);
                j++;
            }
        }
        else if (settingConfig.type == "CHOICE")
        {
            var optionsArray = settingConfig.options.split(","); //splits comma separated list into components
            var i = 0;
            for (var optionIndex in optionsArray)
            {
                var possibleValue = optionsArray[optionIndex].trim();
                settingValueSelect.options[i] = new Option(possibleValue == "" ? "null" : possibleValue, possibleValue);
                i++;
            }
        }
        else if(settingConfig.type == "CALLWINDOW")
        {
                 for(var i=0;i<callWindows.length;i++)
          {
              //skip system default windows
              if(callWindows[i].id > 0)
               {
                  settingValueSelect.options[i] = new Option(callWindows[i].name,callWindows[i].id);
               }
          }
        }
        else
        {
            return false;
        }
    }
    return false;
}

function initActionRow(rule, action, filterActionRow)
{
    // set selected index
    var actionSelect = YAHOO.util.Dom.getElementsByClassName('actionSelect', 'select', filterActionRow)[0];
    var portfolioSelect = YAHOO.util.Dom.getElementsByClassName('portfolioSelectList', 'select', filterActionRow)[0];
    var strategySelect = YAHOO.util.Dom.getElementsByClassName('strategySelectList', 'select', filterActionRow)[0];
    var settingSelect = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterActionRow)[0];
    var settingInput = YAHOO.util.Dom.getElementsByClassName('settingValueText', 'div', filterActionRow)[0];
    var actionMinsInput = YAHOO.util.Dom.getElementsByClassName('actionMinsInput', 'div', filterActionRow)[0];
    actionMinsInput = actionMinsInput.getElementsByTagName('input')[0];
    var variableSelect = YAHOO.util.Dom.getElementsByClassName('variableSelectList', 'select', filterActionRow)[0];
    var variableInput = YAHOO.util.Dom.getElementsByClassName('variableValueText', 'div', filterActionRow)[0];
    variableInput = variableInput.getElementsByTagName('input')[0];
    var tenantSelect = YAHOO.util.Dom.getElementsByClassName('tenantSelectList', 'select', filterActionRow)[0];

    selectInOptions(action.action, actionSelect.options);
    actionSelectRow(filterActionRow);

    if (!action.data)
    {
        action.data="";
    }

    // now set values
    switch (action.action)
    {
    case 0: // terminate
    case 7: // clear settings
        break;
    case 1: // suspend
    case 6: // goto alert
        actionMinsInput.value = action.data;
        actionMinsInput.title = getInputTooltip(action.data);
        break;
    case 8: // set delay
        actionMinsInput.value = action.data;
        actionMinsInput.title = getInputTooltip(action.data);
        break;
    case 2: // goto portfolio
        if (action.portfolio)
        {
            selectInOptions(action.portfolio.id, portfolioSelect.options);
        }
        else
        {
            selectInOptions(portfolioFilter.id, portfolioSelect.options);
        }
        break;
    case 4: // set
        // action is by value...
        var phoneSettingConfig = getActionPhoneSettingConfig(action);
        var phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
        if (phoneActions != null)
        {
            selectInOptions(phoneSettingConfig.name, settingSelect.options);
            settingSelectRow(filterActionRow, phoneActions);
        }
        else
        {
            var settingConfig = findSettingConfigByName(action.settingName);
            if (settingConfig)
            {
                selectInOptions(settingConfig.name, settingSelect.options);
                settingSelectRow(filterActionRow, action.settingValue);
            }
        }
        break;
    case 3: // goto strategy
        actionMinsInput.value = action.data;
        actionMinsInput.title = getInputTooltip(action.data);
        // intentional fallthrough
    case 5: // set strategy
        selectInOptions(action.strategyUser.id, strategySelect.options);
        break;
    case 9: // set variable
        selectInOptions(action.settingName, variableSelect.options);
        setConditionOrActionValue(action.settingValue, variableInput);
        break;
    case 11: // execute
        setConditionOrActionValue(action.settingValue, variableInput);
        break;
    case 12:
        actionMinsInput.value = action.data;
        actionMinsInput.title = getInputTooltip(action.data);
        break;
    case 13: // goto tenant
        selectInOptions(action.settingValue, tenantSelect.options);
        break;
    }
}

function extractActionRowActions(filterActionRows)
{
    var actions = new Array();

    for(var i=0;i<filterActionRows.length;i++)
    {
        var actionSelect = YAHOO.util.Dom.getElementsByClassName('actionSelect', 'select', filterActionRows[i])[0];
        var portfolioSelect = YAHOO.util.Dom.getElementsByClassName('portfolioSelectList', 'select', filterActionRows[i])[0];
        var strategySelect = YAHOO.util.Dom.getElementsByClassName('strategySelectList', 'select', filterActionRows[i])[0];
        var settingSelect = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterActionRows[i])[0];
        var settingValueSelect = YAHOO.util.Dom.getElementsByClassName('settingValueList', 'select', filterActionRows[i])[0];
        var settingValueInput = YAHOO.util.Dom.getElementsByClassName('settingValueText', 'div', filterActionRows[i])[0];
        var actionMinsInput = YAHOO.util.Dom.getElementsByClassName('actionMinsInput', 'div', filterActionRows[i])[0];
        var settingValuePhone = YAHOO.util.Dom.getElementsByClassName('settingValuePhone', 'div', filterActionRows[i])[0];
        var settingValuePhoneInputs = settingValuePhone.getElementsByTagName('input');
        settingValueInput = settingValueInput.getElementsByTagName('input')[0];
        actionMinsInput = actionMinsInput.getElementsByTagName('input')[0];
        var portfolioOptions = portfolioSelect.getElementsByTagName('option');
        var strategyOptions = strategySelect.getElementsByTagName('option');
        var variableSelect = YAHOO.util.Dom.getElementsByClassName('variableSelectList', 'select', filterActionRows[i])[0];
        var variableInput = YAHOO.util.Dom.getElementsByClassName('variableValueText', 'div', filterActionRows[i])[0].getElementsByTagName('input')[0];
        var tenantSelect = YAHOO.util.Dom.getElementsByClassName('tenantSelectList', 'select', filterActionRows[i])[0];
        var tenantOptions = tenantSelect.getElementsByTagName('option');

        var strategyValue = -1;
        var actionValue = actionSelect.options[actionSelect.selectedIndex].value;
        if ((actionValue == 3 || actionValue == 5) && (strategySelect.selectedIndex != -1))
        {
            strategyValue = strategyOptions[strategySelect.selectedIndex].value;
        }
        var portfolioValue = -1;
        if(actionValue == 2 && portfolioSelect.selectedIndex != -1)
        {
            portfolioValue = portfolioOptions[portfolioSelect.selectedIndex].value;
        }
        var settingName = null;
        var settingValue = null;
        var actionData = "";
        if (actionValue == 6 || actionValue == 8 || actionValue == 3 || actionValue == 12)
        {
            actionData = actionMinsInput.value;
        }
        if (actionValue == 9)
        {
            if(variableSelect.selectedIndex == -1)
            {
                showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.setvariable.variablenamereq"),null);
                return null;
            }
            else
            {
                settingName = variableSelect.options[variableSelect.selectedIndex].value;
                settingValue = getNamedFnExprValue(variableInput, true);
            }
        }
        if (actionValue == 11)
        {
            settingValue = getNamedFnExprValue(variableInput, true);
        }
        if (actionValue == 4 && settingSelect.selectedIndex != -1)
        {
            settingName = settingSelect.options[settingSelect.selectedIndex].value;
            if (isSettingText(settingName))
            {
                settingValue = getNamedFnExprValue(settingValueInput, true);
            }
            else if (isSettingSelect(settingName))
            {
                settingValue = "constant:" + settingValueSelect.options[settingValueSelect.selectedIndex].value;
            }
            else if (isSettingPhone(settingName))
            {
                var phoneSettingConfig = findSettingConfig(settingName);
                var settingConfigs = getPhoneSettingConfigs(phoneSettingConfig);
                for (var j = 0; j < settingConfigs.length; j++)
                {
                    var action = {
                        action:actionValue,
                        portfolio: {
                            id:portfolioValue
                        },
                        strategyUser: {
                            id:strategyValue
                        },
                        settingName:settingConfigs[j].name,
                        settingValue:"constant:" + settingValuePhoneInputs[j].value,
                        data:actionMinsInput.value
                    };
                    actions.push(action);
                }
                // added actions, so continue to next row
                continue;
            }
        }
        if (actionValue == 13)
        {
            // goto tenant
            settingValue = tenantOptions[tenantSelect.selectedIndex].value;
        }
        var action = {
            action:actionValue,
            portfolio: {
                id:portfolioValue
            },
            strategyUser: {
                id:strategyValue
            },
            settingName:settingName,
            settingValue:settingValue,
            data:actionData
        };
        actions.push(action);
    }
    return actions;
}

function copyFilter(pos)
{
	return function()
	{
        purgeFilterListeners();
        disableCheckBoxes(true);

        var rule = filterRules[pos];
        var filterTbody = document.getElementById('portfolioFilterTable').getElementsByTagName('tbody')[0];
        var editFilter = document.getElementById('newFilterRow').cloneNode(true);
        editFilter.className = editFilter.className.replace('noDisplay', '');

        var posCount = pos;
        var filterRows = filterTbody.getElementsByTagName('tr');
        var filterRow;
        for ( var i=0; i<filterRows.length; i++ )
        {

            if ( filterRows[i].parentNode.id == "filterBody" )
            {
                if ( posCount == 0 )
                {
                    filterRow = filterRows[i];
                    break;
                }
                else
                {
                    posCount--;
                }
            }
        }


        var editName = editFilter.getElementsByTagName('h2')[0];
        var name = rule.name;

        var editImg = document.createElement("img");
        editImg.src = "../common/img/iconEdit.gif";
        editImg.alt=YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addrule");
        editImg.title=YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addrule");

        YAHOO.Adeptra.Common.purgeChildren(editName);
        editName.appendChild(editImg);
        editName.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addrule")));

        var editNameInput = editFilter.getElementsByTagName('input')[0];
        editNameInput.value = name;
        editNameInput.title = getInputTooltip(name);

        //Conditions
        var editConditionsTable = editFilter.getElementsByTagName('table')[1];
        var editConditionsTbody = editConditionsTable.getElementsByTagName('tbody')[0];
        var filterConditionRow = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', editConditionsTbody)[0];
        //Add all rows before initializing
        var filterConditionRows = new Array();
        filterConditionRows.push(filterConditionRow);
        if (rule.conditions.length > 1)
        {
            var filterConditionPrototype = filterConditionRow;
            for (var i = 1; i < rule.conditions.length; i++)
            {
                var condition = rule.conditions[i];
                filterConditionRow = filterConditionPrototype.cloneNode(true);
                var header = filterConditionRow.getElementsByTagName('th')[0];
                                header.innerHTML = "";
                header.appendChild(createConditionLogicalOperatorSelect(rule.conditions[i-1].logicalOperator));
                filterConditionRows.push(filterConditionRow);
                editConditionsTbody.appendChild(filterConditionRow);
            }
        }
        // Initialize filter rows after cloning all nodes (IE doesn't behave well otherwise)
        for (var i = 0; i < filterConditionRows.length; i++)
        {
          initConditionRow(rule.conditions[i], filterConditionRows[i]);
        }
        //Actions
        newFilterActionSelects(editFilter);
        var editActionsTable = editFilter.getElementsByTagName('table')[2];
        var editActionsTbody = editActionsTable.getElementsByTagName('tbody')[0];
        var filterActionRow = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', editActionsTbody)[0];
        var filterActionPrototype = filterActionRow.cloneNode(true);
        // keep track of any SET PHONE constituent actions rendered in a "collapsed" SET PHONE presentation
        var phoneActionsRendered = new Array();
        var action = rule.actions[0];
        var phoneSettingConfig = getActionPhoneSettingConfig(action);
        var phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
        initActionRow(rule, action, filterActionRow);
        if (phoneActions != null)
        {
            phoneActionsRendered[phoneActions[0].settingName] = true;
            phoneActionsRendered[phoneActions[1].settingName] = true;
            phoneActionsRendered[phoneActions[2].settingName] = true;
        }
        if (rule.actions.length > 1)
        {
            for (var i = 1; i < rule.actions.length; i++)
            {
                action = rule.actions[i];
                phoneSettingConfig = getActionPhoneSettingConfig(action);
                if (phoneSettingConfig != null && phoneActionsRendered[action.settingName])
                {
                    // skip this action, it is part of a SET PHONE trio which has already been rendered
                    continue;
                }
                filterActionRow = filterActionPrototype.cloneNode(true);
                var header = filterActionRow.getElementsByTagName('th')[0];
                header.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.and");
                initActionRow(rule, action, filterActionRow);
                editActionsTbody.appendChild(filterActionRow);
                phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
                if (phoneActions != null)
                {
                    phoneActionsRendered[phoneActions[0].settingName] = true;
                    phoneActionsRendered[phoneActions[1].settingName] = true;
                    phoneActionsRendered[phoneActions[2].settingName] = true;
                }
            }
        }
        YAHOO.util.Dom.insertAfter(editFilter, filterRow);
        var cloneFilter = filterRow;
        //filterTbody.removeChild(filterRow);
        //handleConditions();
        addConditionListeners(editConditionsTable.rows);
        //handleActions();
        addActionListeners(editActionsTable.rows);
        ddInput();
        initAutoCompletes(editFilter,variableListDS,true);
        createHelpButtonListeners("filterHelp");
        createHelpPanelListeners("filterHelp");

        var buttonLinks = YAHOO.util.Dom.getElementsByClassName('buttonsRow', 'div', editFilter)[0].getElementsByTagName("button");

        YAHOO.util.Event.addListener(buttonLinks[0], "click", newFilterSave(null, editFilter, (pos+1)));
        YAHOO.util.Event.addListener(buttonLinks[1], "click", editFilterCancel(cloneFilter, editFilter, pos));

        var twoColumnColumnTwoWrap = YAHOO.util.Dom.getElementsByClassName('twoColumnColumnTwoWrap', 'div', editFilter)[0];
        twoColumnColumnTwoWrap.appendChild(variableListDOM);

        createFilterRowListeners(editFilter);
        displayButtons();
        fixColumns();
        setFooter();		
	};
}
function editFilter(pos)
{
    return function()
    {
        purgeFilterListeners();
        disableCheckBoxes(true);

        var rule = filterRules[pos];
        var filterTbody = document.getElementById('portfolioFilterTable').getElementsByTagName('tbody')[0];
        var editFilter = document.getElementById('newFilterRow').cloneNode(true);
        editFilter.className = editFilter.className.replace('noDisplay', '');

        var posCount = pos;
        var filterRows = filterTbody.getElementsByTagName('tr');
        var filterRow;
        for ( var i=0; i<filterRows.length; i++ )
        {

            if ( filterRows[i].parentNode.id == "filterBody" )
            {
                if ( posCount == 0 )
                {
                    filterRow = filterRows[i];
                    break;
                }
                else
                {
                    posCount--;
                }
            }
        }


        var editName = editFilter.getElementsByTagName('h2')[0];
        var name = rule.name;

        var editImg = document.createElement("img");
        editImg.src = "../common/img/iconEdit.gif";
        editImg.alt=YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.editrule1");
        editImg.title=YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.editrule1");

        YAHOO.Adeptra.Common.purgeChildren(editName);
        editName.appendChild(editImg);
        editName.appendChild(document.createTextNode(" " + YAHOO.Adeptra.I18NUtil.labelFormat("portal2.apm.portfolios.filter.editrule",[name])));

        //editName.innerHTML = '<img src="../common/img/iconEdit.gif" alt="Edit Rule" title="Edit Rule" /> Edit ' + name;
        var editNameInput = editFilter.getElementsByTagName('input')[0];
        editNameInput.value = name;
        editNameInput.title = getInputTooltip(name);
        
        //Conditions
        var editConditionsTable = editFilter.getElementsByTagName('table')[1];
        var editConditionsTbody = editConditionsTable.getElementsByTagName('tbody')[0];
        var filterConditionRow = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', editConditionsTbody)[0];
        //Add all rows before initializing
        var filterConditionRows = new Array();
        filterConditionRows.push(filterConditionRow);
        if (rule.conditions.length > 1)
        {
            var filterConditionPrototype = filterConditionRow;
            for (var i = 1; i < rule.conditions.length; i++)
            {
                var condition = rule.conditions[i];
                filterConditionRow = filterConditionPrototype.cloneNode(true);
                var header = filterConditionRow.getElementsByTagName('th')[0];
                                header.innerHTML = "";
                header.appendChild(createConditionLogicalOperatorSelect(rule.conditions[i-1].logicalOperator));
                filterConditionRows.push(filterConditionRow);
                editConditionsTbody.appendChild(filterConditionRow);
            }
        }
        // Initialize filter rows after cloning all nodes (IE doesn't behave well otherwise)
        for (var i = 0; i < filterConditionRows.length; i++)
        {
          initConditionRow(rule.conditions[i], filterConditionRows[i]);
        }
        //Actions
        newFilterActionSelects(editFilter);
        var editActionsTable = editFilter.getElementsByTagName('table')[2];
        var editActionsTbody = editActionsTable.getElementsByTagName('tbody')[0];
        var filterActionRow = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', editActionsTbody)[0];
        var filterActionPrototype = filterActionRow.cloneNode(true);
        // keep track of any SET PHONE constituent actions rendered in a "collapsed" SET PHONE presentation
        var phoneActionsRendered = new Array();
        var action = rule.actions[0];
        var phoneSettingConfig = getActionPhoneSettingConfig(action);
        var phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
        initActionRow(rule, action, filterActionRow);
        if (phoneActions != null)
        {
            phoneActionsRendered[phoneActions[0].settingName] = true;
            phoneActionsRendered[phoneActions[1].settingName] = true;
            phoneActionsRendered[phoneActions[2].settingName] = true;
        }
        if (rule.actions.length > 1)
        {
            for (var i = 1; i < rule.actions.length; i++)
            {
                action = rule.actions[i];
                phoneSettingConfig = getActionPhoneSettingConfig(action);
                if (phoneSettingConfig != null && phoneActionsRendered[action.settingName])
                {
                    // skip this action, it is part of a SET PHONE trio which has already been rendered
                    continue;
                }
                filterActionRow = filterActionPrototype.cloneNode(true);
                var header = filterActionRow.getElementsByTagName('th')[0];
                header.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.and");
                initActionRow(rule, action, filterActionRow);
                editActionsTbody.appendChild(filterActionRow);
                phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
                if (phoneActions != null)
                {
                    phoneActionsRendered[phoneActions[0].settingName] = true;
                    phoneActionsRendered[phoneActions[1].settingName] = true;
                    phoneActionsRendered[phoneActions[2].settingName] = true;
                }
            }
        }
        filterTbody.insertBefore(editFilter, filterRow);
        var cloneFilter = filterRow;
        filterTbody.removeChild(filterRow);
        //handleConditions();
        addConditionListeners(editConditionsTable.rows);
        //handleActions();
        addActionListeners(editActionsTable.rows);
        ddInput();
        initAutoCompletes(editFilter,variableListDS,true);
        createHelpButtonListeners("filterHelp");
        createHelpPanelListeners("filterHelp");

        var buttonLinks = YAHOO.util.Dom.getElementsByClassName('buttonsRow', 'div', editFilter)[0].getElementsByTagName("button");

        YAHOO.util.Event.addListener(buttonLinks[0], "click", editFilterSave(cloneFilter,editFilter, pos));
        YAHOO.util.Event.addListener(buttonLinks[1], "click", editFilterCancel(cloneFilter, editFilter, pos));

        var twoColumnColumnTwoWrap = YAHOO.util.Dom.getElementsByClassName('twoColumnColumnTwoWrap', 'div', editFilter)[0];
        twoColumnColumnTwoWrap.appendChild(variableListDOM);

        createFilterRowListeners(editFilter);
        displayButtons();
        fixColumns();
        setFooter();
    };
}

//Calculate whether to display buttons depending on number of rows
function displayButtons()
{
	// Condition buttons
	var root = YAHOO.util.Dom.get('newFilterConditions');
	var rows = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', root);
	
	// Action buttons
	var root = YAHOO.util.Dom.get('newFilterActions');
	var rows = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', root);
	if (rows.length > 1) {  	
		var elements = YAHOO.util.Dom.getElementsByClassName("removeAction","a",root);
		for (var e in elements) {
			YAHOO.util.Dom.removeClass(elements[e], 'noDisplay');
    	}
    }
}

function createConditionLogicalOperatorSelect(selected)
{
        var select = document.createElement("select");

        for(key in conditionLogicalOperators)
        {
          var option = document.createElement("option");
          option.value = key;
             option.appendChild(document.createTextNode(conditionLogicalOperators[key]));
          if(key == selected)
          {
                  option.selected = "selected";
          }
           select.appendChild(option);
        }
        return select;
}

function extractFilterValues(filterRow)
{
    var editNameInput = filterRow.getElementsByTagName('input')[0];

    var conditions = new Array();
    var editConditionsTable = filterRow.getElementsByTagName('table')[1];
    var editConditionsTbody = editConditionsTable.getElementsByTagName('tbody')[0];
    var filterConditionRows = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', editConditionsTbody);

    for (var i = 0; i < filterConditionRows.length; i++)
    {
        var condition = extractConditionRowCondition(filterConditionRows[i],filterConditionRows[i+1]);
        if(condition == null)
        {
            //'always run' condition found
            continue;
        }
        else
        {
            conditions.push(condition);
        }
    }

    var editActionsTable = filterRow.getElementsByTagName('table')[2];
    var editActionsTbody = editActionsTable.getElementsByTagName('tbody')[0];
    var filterActionRows = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', editActionsTbody);

    var actions = extractActionRowActions(filterActionRows);
    if(actions == null)
    {
        //invalid action found
        return;
    }

    var rule = {
        id:-1,
        version:0,
        enabled:true,
        name:editNameInput.value,
        conditions:conditions,
        actions:actions
    };
    return rule;
}

function formatRulePostData(rule, isNew, pos)
{
    // if isNew, pos is where the new rule should be in the list
    var postDataArr = new Array();

    postDataArr.push({key:"filter.id",value:portfolioFilter.id});

    if (!isNew)
    {
        var currentRule = filterRules[pos];
        postDataArr.push({key:"rule.id",value:currentRule.id});
        postDataArr.push({key:"rule.version",value:currentRule.version});
        postDataArr.push({key:"rule.enabled",value:currentRule.enabled});
    }
    else
    {
        postDataArr.push({key:"rule.enabled",value:"true"});
    }

    postDataArr.push({key:"rule.name",value:rule.name});

    for (var i = 0; i < rule.conditions.length; i++)
    {
        var condition = rule.conditions[i];
        var prefix = "rule.conditions[" + i + "].";
        postDataArr.push({key:prefix + "operator",value:condition.operator});
        postDataArr.push({key:prefix + "logicalOperator",value:condition.logicalOperator});
        postDataArr.push({key:prefix + "value1",value:condition.value1});
        postDataArr.push({key:prefix + "value2",value:condition.value2});
    }

    if (rule.actions)
    {
        var actions = rule.actions;
        for(var i=0;i<actions.length;i++)
        {
            var action = actions[i];
            var prefix = "rule.actions[" + i + "].";
            postDataArr.push({key:prefix + "action",value:action.action});
            postDataArr.push({key:prefix + "portfolio.id",value:action.portfolio.id});
            postDataArr.push({key:prefix + "strategyUser.id",value:action.strategyUser.id});
            if (action.settingName != null)
            {
                postDataArr.push({key:prefix + "settingName",value:action.settingName});
            }
            if (action.settingValue != null)
            {
                postDataArr.push({key:prefix + "settingValue",value:action.settingValue});
            }
            if (action.data != null)
            {
                postDataArr.push({key:prefix + "data",value:action.data});
            }
        }
    }

    if (isNew)
    {
        for (var i = 0; i <= filterRules.length; i++)
        {
            var id = -1;
            if (i < pos)
            {
                id = filterRules[i].id;
            }
            else if (i > pos)
            {
                id = filterRules[(i-1)].id;
            }
            postDataArr.push({key:"filter.rules[" + i + "].id",value:id});
        }
    }
    return postDataArr;
}

function showErrorMessage(messageText, el, isFunctionEditor) {
	 var message = YAHOO.util.Dom.get("ruleMessage");
	 if (isFunctionEditor != undefined && isFunctionEditor) message = YAHOO.util.Dom.get("ruleMessageFE");

	 if (YAHOO.util.Dom.hasClass(message,"ruleMessageHidden"))
     {
         YAHOO.util.Dom.removeClass(message,"ruleMessageHidden");
         YAHOO.util.Dom.addClass(message,"ruleMessageVisible");   
     }
     message.innerHTML = messageText;
     if (messageTimerActive)
     {
         clearTimeout(messageTimer);
         messageTimerActive = 0;
     }
     messageTimerActive=1;
     if (isFunctionEditor != undefined && isFunctionEditor) {
    	 messageTimer = setTimeout("hideMessage(true)",5000);
     } else {
    	 messageTimer = setTimeout("hideMessage()",5000); 
     }
     	      
	 if (el != undefined) { 
		 attributes = { backgroundColor: {from: '#FFAFB2', to: '#ffffff' } };
		 anim = new YAHOO.util.ColorAnim(el, attributes, 1);	 
		 anim.animate();    
	 }
}

function validateActions(rule) {
	for (var idx in rule.actions) {
		
		// Execute action - Not blank
		if (rule.actions[idx].action == "11" && (rule.actions[idx].settingValue.trim() == "" || rule.actions[idx].settingValue.trim() == "constant:")) {
			showErrorMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.executeactionrequired"));
			return false;
		}
		
		// Execute action - Functions only
		var FUNCTION_TAG = "function:";
		if (rule.actions[idx].action == "11" && (rule.actions[idx].settingValue.substring(0,FUNCTION_TAG.length) != FUNCTION_TAG)) {
			showErrorMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.executeFunctionsOnly"));
			return false;
		}		
	}
	return true;
}

function editFilterSaveIntercept(cloneFilter,newFilter, pos)
{
    var currentRule = filterRules[pos];
    var rule = extractFilterValues(newFilter);
    if (rule && validateActions(rule)) {
        var postDataArray = formatRulePostData(rule, false, pos);
        // TODO: disable save/cancel buttons
        JSONRequest.sendMapRequest(
            'rule/update.action',
            postDataArray,
            {
                success: function(result)
                {
                    filterRules[pos] = result.rule;
                    editFilterSaveSuccess(newFilter, filterRules[pos], pos);
                },
                error: function(result)
                {
                    showFieldActionErrors(result);
                },
                failure: function(o)
                {
                    alertFailureExt(o, document.location.href);
                    // TODO: renabled save/cancel buttons? or refresh page
                }
            });
    }
}

function editFilterSaveSuccess(newFilter, rule, pos)
{
    var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
    var newRow = document.createElement("tr");
    tbody.insertBefore(newRow, newFilter);
    createFilterRow(rule, pos,newRow);

    tbody.removeChild(newFilter);
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
    rePrioritize();
    animRow(rows[pos]);
    updateFilterEnabled(rule);
    disableCheckBoxes(false);
    createFilterListers();
    destroyAutoCompletes();
    setFooter();
}

function editFilterSave(cloneFilter,newFilter, pos)
{
    return function(e)
    {
        editFilterSaveIntercept(cloneFilter,newFilter, pos);
        YAHOO.util.Event.preventDefault(e);
    };
}

function editFilterCancel(cloneNewFilter, newFilter, pos)
{
    return function()
    {
        var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
        var filterRows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');

        tbody.removeChild(newFilter);
        if (pos >= filterRows.length)
        {
            tbody.appendChild(cloneNewFilter);
        }
        else
        {
            tbody.insertBefore(cloneNewFilter, filterRows[pos]);
        }
        disableCheckBoxes(false);
        createFilterListers();
            destroyAutoCompletes();
        setFooter();
    }
}

/*
experimental - no improvement
function setFilterRowRuleOptions(filterRow)
{
    var filterOptions = document.getElementById('filterOptions');
    var divs = filterOptions.getElementsByTagName("div");
    if (divs.length) {
        var filterOptionsDiv = divs[0];
        var filterOptionsCell = YAHOO.util.Dom.getElementsByClassName('filterOptions', 'td', filterRow)[0];
        filterOptionsCell.appendChild(filterOptionsDiv);
    }
}
*/

function newFilter(pos)
{
    return function()
    {
        var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
        var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
        var row = null;
        if (pos >= 0)
        {
            row = rows[pos];
        }

        var newFilter = document.getElementById('newFilterRow');
        var cloneFilter = newFilter.cloneNode(true);

        //setFilterRowRuleOptions(newFilter);
        newFilter.className = newFilter.className.replace('noDisplay', '');
        if (pos == (rows.length-1))
        {
            tbody.appendChild(newFilter);
        }
        else
        {
            tbody.insertBefore(newFilter, row.nextSibling);
        }

        var conditionsInputs = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', newFilter)[0].getElementsByTagName('input');
        purgeParameterFieldClasses(conditionsInputs[1]);
        purgeParameterFieldClasses(conditionsInputs[2]);
        YAHOO.util.Event.addListener(conditionsInputs[1],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(conditionsInputs[2],"keyup",changeToLiteralFieldUpdateRaw);

        newFilterActionSelects(newFilter);
        //handleConditions();
        var conditionRow = YAHOO.util.Dom.getElementsByClassName('newFilterCondition','tr',newFilter)[0];
        addConditionListeners([conditionRow]);
        //handleActions();
        var actionRow = YAHOO.util.Dom.getElementsByClassName('newFilterAction','tr',newFilter)[0];
        addActionListeners([actionRow]);
        ddInput();
        initAutoCompletes(newFilter,variableListDS,true);
        createHelpButtonListeners("filterHelp");
        createHelpPanelListeners("filterHelp");

        var buttonLinks = YAHOO.util.Dom.getElementsByClassName('buttonsRow', 'div', newFilter)[0].getElementsByTagName("button");
        if (!rows.length)
        {
            buttonLinks[1].style.display="none";
        }
        YAHOO.util.Event.removeListener(buttonLinks[0], "click");
        YAHOO.util.Event.removeListener(buttonLinks[1], "click");
        YAHOO.util.Event.addListener(buttonLinks[0], "click", newFilterSave(cloneFilter, newFilter, (pos+1)));
        if(pos >= 0)
        {
            YAHOO.util.Event.addListener(buttonLinks[1], "click", newFilterCancel(cloneFilter, newFilter));
        }

        var twoColumnColumnTwoWrap = YAHOO.util.Dom.getElementsByClassName('twoColumnColumnTwoWrap', 'div', newFilter)[0];
        twoColumnColumnTwoWrap.appendChild(variableListDOM);

        purgeFilterListeners();
        disableCheckBoxes(true);
        fixColumns();

        newFilter.getElementsByTagName('input')[0].focus();
        actionSelectRow(newFilter);
        createFilterRowListeners(newFilter);
        setFooter();

    };
}

function clearAutoCompletes(filterElement)
{
  var autoCompleteContainers = YAHOO.util.Dom.getElementsByClassName("autoCompleteContainer", 'div', filterElement);
  for(var i=0;i<autoCompleteContainers.length;i++)
  {
    autoCompleteContainers[i].parentNode.removeChild(autoCompleteContainers[i]);
  }
}

function destroyAutoCompletes()
{
  for(var i=0;i<autoCompletes.length;i++)
  {
        autoCompletes[i].destroy();
  }
  autoCompletes = null;
}

var messageTimerActive = 0;
var messageTimer;
function hideMessage(functionEditor)
{
    var message = YAHOO.util.Dom.get("ruleMessage");
    if (functionEditor) message = YAHOO.util.Dom.get("ruleMessageFE");
    YAHOO.util.Dom.removeClass(message,"ruleMessageVisible");
    YAHOO.util.Dom.addClass(message,"ruleMessageHidden");
    messageTimerActive = 0;
}

function initAutoCompletes(filterElement,variableListDataSource,showFunPanel)
{
    var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', filterElement ? filterElement : 'newFilterRow');
    autoCompletes = autoCompletes == null ? [] : autoCompletes;
    for(var i=0;i<inputTargets.length;i++)
    {
        var autoCompleteContainer = document.createElement("div");
        autoCompleteContainer.className = "autoCompleteContainer";
        inputTargets[i].parentNode.parentNode.appendChild(autoCompleteContainer);
        var oAutoComp = new YAHOO.widget.AutoComplete(inputTargets[i],autoCompleteContainer, variableListDataSource);
        oAutoComp.queryDelay = 0;
        oAutoComp.prehighlightClassName = "yui-ac-prehighlight";
        oAutoComp.typeAhead = false;
        oAutoComp.useShadow = false;
        oAutoComp.animVert = false;
        oAutoComp.animHoriz = false;
        oAutoComp.useIFrame = true;
        oAutoComp.itemSelectEvent.subscribe(function(sType,oArgs) {
            var textBox = oArgs[0]._elTextbox;
            var label = oArgs[2][0];
            var raw = oArgs[2][1];
            var functionName = YAHOO.Adeptra.Labels.getFunctionName(raw);            
            
            // Check if execute action setting
            var isActionTextBox = YAHOO.util.Dom.hasClass(textBox,'textBoxSettingValue');
            var isExecute = false
            if (isActionTextBox) {
            	var row = textBox.parentNode.parentNode.parentNode;
    			var selectCell = YAHOO.util.Dom.getElementsByClassName("selectBoxCellAction", "td", row)[0];
    			var actionSelect = YAHOO.util.Dom.getElementsByClassName("actionSelect", "select", selectCell)[0];    		
    			if (actionSelect.options[actionSelect.selectedIndex].value == 11) isExecute = true;
            }            
            var isExecuteActionSetting = isActionTextBox && isExecute;
            var allowSelect = false;
            if (!(isExecuteActionSetting) && textBox.acceptAllFunction == '1' ||  (!isAde && !isApm2))
            {
                /*
                 * This target accepts any function... No need to do any more checks
                 */
                allowSelect = true;
            }
            else
            {
                
                var functionInfo = null;
                allowSelect = true;

                if (ruleDatums.functions[functionName] != undefined) 
    		    {
            		 functionInfo = ruleDatums.functions[functionName]
    		    }
                
                // Execute action only allows functions
                if ((isExecuteActionSetting && functionInfo == null)) 
                {                	
                    textBox.overrideFunctionPanel = true;
                    allowSelect = false;
                    messageText =  YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.executeFunctionsOnly");                                        
                    showErrorMessage(messageText, textBox);
                } 
                else if (!isExecuteActionSetting && (functionInfo != null && (functionInfo.returns == undefined || functionInfo.returns == '')))
                {
                    /*
                     * We are not allowed to use this function as is doesn't appear to return anything
                     */
                    textBox.overrideFunctionPanel = true;
                    allowSelect = false;                                                       
                    var messageText = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.noFunctionReturn");                                        
                    showErrorMessage(messageText, textBox);
                }
            }
            
            if (allowSelect)
            {
                purgeParameterFieldClasses(textBox);             
                YAHOO.util.Dom.addClass(textBox,"variable");
                textBox.setAttribute("data-raw", raw);
                
                if (messageTimerActive)
                {
                    clearTimeout(messageTimer);
                    messageTimerActive=0;
                    hideMessage();
                }
                attributes = { backgroundColor: {from: '#AFFFB2', to: '#ffffff' } };
                anim = new YAHOO.util.ColorAnim(textBox, attributes, 1);
                anim.animate();
            }
            else
            {
                purgeParameterFieldClasses(textBox);
                textBox.value = "";
                textBox.title  = "";
                textBox.setAttribute("data-raw", "");
            }
           
            /*
            var textBox = oArgs[0]._oTextbox;
            var oData = oArgs[2]; // object literal of selected item's result
            dragDropHandler(textBox, oData.id, oData.name, (oData.className == 'drag-variable'), (oData.className == 'drag-literal'))
            function dragDropHandler(targetElement, value, dragValue, isSrcClassVariable, isSrcClassLiteral)
            */
        }
        );
        if(showFunPanel)
        {
            oAutoComp.itemSelectEvent.subscribe(function(sType,oArgs) {

                var label = oArgs[2][0];
                var raw = oArgs[2][1];
                var functionName = YAHOO.Adeptra.Labels.getFunctionName(raw);
                var textBox = oArgs[0]._elTextbox;
            	
                if (!textBox.overrideFunctionPanel || textBox.overrideFunctionPanel == "undefined")
                {
                    functionEditorInstance.showNewFunctionPanel(functionName,textBox);
                }
                else
                {
                	textBox.overrideFunctionPanel = false;
                }
                    
            });
        }
        autoCompletes.push(oAutoComp);
    }
}

function newFilterSave(cloneNewFilter, newFilter, pos)
{
    return function(e)
    {
        newFilterSaveIntercept(cloneNewFilter, newFilter, pos);
        YAHOO.util.Event.preventDefault(e);
    };
}

function newFilterCancel(cloneNewFilter, newFilter)
{
    return function()
    {
        var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
        tbody.removeChild(newFilter);

        tbody = document.getElementById('newFilterTable').getElementsByTagName("tbody")[0];
        tbody.appendChild(cloneNewFilter);
        cloneNewFilter.className = 'editRow noDisplay';
        //rePrioritize();
        disableCheckBoxes(false);
        destroyAutoCompletes();
        createFilterListers();
        setFooter();
    }
}

function newFilterSaveIntercept(cloneNewFilter, newFilter, pos)
{
    var rule = extractFilterValues(newFilter);
    if (rule && validateActions(rule))
    {
        var postDataArray = formatRulePostData(rule, true, pos);
        // TODO: disable save/cancel buttons
        JSONRequest.sendMapRequest(
            'rule/create.action',
            postDataArray,
            {
                success: function(result)
                {
                    filterRules.splice(pos, 0, result.rule);
                    newFilterSaveSuccess(cloneNewFilter, newFilter, result.rule, pos);
                },
                error: function(result)
                {
                   showFieldActionErrors(result);
                },
                failure: function(o)
                {
                    alertFailureExt(o, document.location.href);
                }
            });
    }
}

function newFilterSaveSuccess(cloneNewFilter, newFilter, rule, pos)
{
    var tbody = document.getElementById('portfolioFilterTable').getElementsByTagName("tbody")[0];
    var newRow = document.createElement("tr");
    tbody.insertBefore(newRow, newFilter);
    createFilterRow(rule, pos, newRow);

    tbody.removeChild(newFilter);
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
    rePrioritize();
    animRow(rows[pos]);
    updateFilterEnabled(rule);
    disableCheckBoxes(false);
    createFilterListers();
    destroyAutoCompletes();
    setFooter();

    if (cloneNewFilter)
    {
    	tbody = document.getElementById('newFilterTable').getElementsByTagName("tbody")[0];
    	tbody.appendChild(cloneNewFilter);
    	cloneNewFilter.className = 'editRow noDisplay';
	}
}

function clearDDInput()
{
    for (var i = 0; i < ddTargetDragDrop.length; i++)
    {
        ddTargetDragDrop[i].unreg();
    }
    ddTargetDragDrop = [];
}

function ddInput()
{
    clearDDInput();

    var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', 'newFilterRow');
    for (var y=0; y<inputTargets.length; y++)
    {
        ddTargetDragDrop[y] = new YAHOO.util.DDTarget(inputTargets[y], 'inputs');
    }
}

// Add Multiple Conditions

function newFilterAddCondition(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode.parentNode;
    var pos = tr.rowIndex;
    //purgeConditions();
    var tbody = document.getElementById('newFilterConditions').getElementsByTagName('tbody')[0];
    var filterConditions = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', 'newFilterConditions');

    // Reset the table cell display
	var hiddenElements = YAHOO.util.Dom.getElementsByClassName('noDisplay', 'td', filterConditions[0]);
	var elementsToShow = YAHOO.util.Dom.getElementsByClassName('hideOnAlwaysRun', 'td', filterConditions[0]);
	for (var c = 0, i = elementsToShow.length; c < i; c += 1)
	{
		YAHOO.util.Dom.removeClass(elementsToShow[c], "noDisplay");
	}
	var elementToHide = YAHOO.util.Dom.getElementsByClassName('alwaysRun', 'td', filterConditions[0])[0];
	YAHOO.util.Dom.addClass(elementToHide, "noDisplay");
	if (hiddenElements.length == 3)
	{
		// We don't need to add a new condition row, so exit after displaying the remove icon
		var elements = YAHOO.util.Dom.getElementsByClassName("removeCondition", "a", filterConditions[0]);
		for (var e in elements) {
			YAHOO.util.Dom.removeClass(elements[e], 'noDisplay');
		}
	    var inputs = filterConditions[0].getElementsByTagName('input');
	    YAHOO.util.Event.addListener(inputs[1],"keyup",changeToLiteralFieldUpdateRaw);
	    YAHOO.util.Event.addListener(inputs[2],"keyup",changeToLiteralFieldUpdateRaw);    
		return;
	}
	
    var filterConditionPrototype = filterConditions[0];

    // Need to clear prototype row before cloning (IE doesn't behave well otherwise)
    var prototypeCondition = extractConditionRowCondition(filterConditionPrototype);
    YAHOO.util.Event.purgeElement(filterConditionPrototype, true);

    clearDDInput();
    clearAutoCompletes(filterConditionPrototype);

    var newFilterCondition = filterConditionPrototype.cloneNode(true);

    // Add back listeners to first row
    addConditionListeners([filterConditionPrototype]);
    
    // restore autocomplete for the prototype filter
    initConditionRow(prototypeCondition, filterConditionPrototype);
    initAutoCompletes(filterConditionPrototype,variableListDS,true);

    var header = newFilterCondition.getElementsByTagName('th')[0];
    header.innerHTML = "";
    header.appendChild(createConditionLogicalOperatorSelect());

    var inputs = newFilterCondition.getElementsByTagName('input');
    inputs[1].value = "";
    inputs[1].title = "";
    inputs[2].value = "";
    inputs[2].title = "";
    inputs[1].setAttribute("data-raw", "");
    inputs[2].setAttribute("data-raw", "");
    purgeParameterFieldClasses(inputs[1]);
    purgeParameterFieldClasses(inputs[2]);
    YAHOO.util.Event.addListener(inputs[1],"keyup",changeToLiteralFieldUpdateRaw);
    YAHOO.util.Event.addListener(inputs[2],"keyup",changeToLiteralFieldUpdateRaw);    

    var options = newFilterCondition.getElementsByTagName('option');
    for (var i=0; i<options.length; i++)
    {
        options[i].selected = "";
    }

    if (pos == (filterConditions.length-1))
    {
        tbody.appendChild(newFilterCondition);
    }
    else
    {
        tbody.insertBefore(newFilterCondition, filterConditions[pos].nextSibling);
    }

    var newTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', newFilterCondition);
    newTargets[0].id='';
    newTargets[1].id='';
    var targets = new YAHOO.util.DDTarget(newTargets[0], 'inputs');
    targets = new YAHOO.util.DDTarget(newTargets[1], 'inputs');

    //handleConditions();
    
    // Display 'remove' buttons if required  
    var rows = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', tr.parentNode);
	var elements = YAHOO.util.Dom.getElementsByClassName("removeCondition","a",tr.parentNode);
	for (var e in elements) {
		YAHOO.util.Dom.removeClass(elements[e], 'noDisplay');
	}
    
    addConditionListeners([newFilterCondition]);
    ddInput();
    initAutoCompletes(newFilterCondition,variableListDS,true);
    setFooter();
}

function newFilterRemoveCondition(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode.parentNode;
    var pos = tr.rowIndex;
    
    // Hide 'remove' buttons if required
    var row = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', tr.parentNode);
    if (row.length == 1) {
    	var elements = YAHOO.util.Dom.getElementsByClassName("removeCondition","a",tr.parentNode);
		for (var e in elements) {
			YAHOO.util.Dom.addClass(elements[e], 'noDisplay');
		}
	}
    
    var tbody = document.getElementById('newFilterConditions').getElementsByTagName('tbody')[0];
    var filterConditions = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', 'newFilterConditions');

    if (filterConditions.length == 1)
    {
    	var elementsToHide = YAHOO.util.Dom.getElementsByClassName('hideOnAlwaysRun', 'td', 'newFilterConditions');
    	for (var c = 0, i = elementsToHide.length; c < i; c += 1)
    	{
    		YAHOO.util.Dom.addClass(elementsToHide[c], "noDisplay");
    	}
    	var elementToShow = YAHOO.util.Dom.getElementsByClassName('alwaysRun', 'td', 'newFilterConditions')[0];
    	YAHOO.util.Dom.removeClass(elementToShow, "noDisplay");
    	var input = elementToShow.getElementsByTagName('input')[0];
    	input.value = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.always");
    	input.title = input.value;
    }
    else
    {
        if (pos == 0)
        {
            var header = filterConditions[1].getElementsByTagName('th')[0];
            header.innerHTML = 'Condition';
        }
        YAHOO.util.Event.purgeElement(filterConditions[pos]);
        tbody.removeChild(filterConditions[pos]);
        //handleConditions();
    }
    setFooter();
}

function newFilterConditionNames()
{
    var tbody = document.getElementById('newFilterConditions').getElementsByTagName('tbody')[0];
    var filterConditions = YAHOO.util.Dom.getElementsByClassName('newFilterCondition', 'tr', 'newFilterConditions');

    for (var i = 0; i < filterConditions.length; i++)
    {
        var filterCondition = filterConditions[i];
        var inputs = filterCondition.getElementsByTagName('input');
        var selects = filterCondition.getElementsByTagName('select');
        inputs[1].name  = "conditions[" + i + "].value1";
        inputs[2].name  = "conditions[" + i + "].value2";
        selects[0].name = "conditions[" + i + "].operator";
    }
}

/*function handleConditions()
{
    purgeConditions();
    newFilterConditionNames();
    setTimeout(addListeners('addCondition', 'a', 'newFilterConditions', 'newFilterAddCondition'), 0);
    setTimeout(addListeners('removeCondition', 'a', 'newFilterConditions', 'newFilterRemoveCondition'), 0);
}*/

function addConditionListeners(rows)
{
    newFilterConditionNames();
    for (var i=0;i<rows.length;i++)
    {
        var row = rows[i];
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('addCondition', 'a', row)[0],'click',newFilterAddCondition);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('removeCondition', 'a', row)[0],'click',newFilterRemoveCondition);
    }
}

/*function purgeConditions()
{
    var addConditions = YAHOO.util.Dom.getElementsByClassName('addCondition', 'a', 'newFilterConditions');
    var removeConditions = YAHOO.util.Dom.getElementsByClassName('removeCondition', 'a', 'newFilterConditions');

    for (var i=0; i<addConditions.length; i++)
    {
        var addLink = addConditions[i];
        YAHOO.util.Event.purgeElement(addLink, true);
        var remLink = removeConditions[i];
        YAHOO.util.Event.purgeElement(remLink, true);
    }
}*/

function newFilterAddAction(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode.parentNode;
    var pos = tr.rowIndex;

    //purgeActions();
    var tbody = document.getElementById('newFilterActions').getElementsByTagName('tbody')[0];
    var filterActions = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', 'newFilterActions');

    var newFilterAction = FILTER_ACTION_PROTOTYPE.cloneNode(true);

    var header = newFilterAction.getElementsByTagName('th')[0];
    header.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.and");

    // -1 is when there are no rows left.
    if (pos == (filterActions.length-1) || pos == -1)
    {
        tbody.appendChild(newFilterAction);
    }
    else
    {
        tbody.insertBefore(newFilterAction, filterActions[pos].nextSibling);
    }

    newFilterActionSelects(newFilterAction);
    var newTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', newFilterAction);
    var targets = new YAHOO.util.DDTarget(newTargets[0], 'inputs');
    targets = new YAHOO.util.DDTarget(newTargets[1], 'inputs');

    //show hide appropriate elements based on action
    actionSelectRow(newFilterAction);
    //handleActions();
    addActionListeners([newFilterAction]);
    createFilterRowListeners(newFilterAction);
    initAutoCompletes(newFilterAction,variableListDS,true);
    setFooter();
    
    // Show 'remove' buttons if more than one row
    var rows = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', tr.parentNode);
    if (rows.length > 1) {
    	var elements = YAHOO.util.Dom.getElementsByClassName("removeAction","a",tr.parentNode);
    	for (var e in elements) {
    		YAHOO.util.Dom.removeClass(elements[e], 'noDisplay');
    	}
    }
}

function newFilterRemoveAction(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode.parentNode;
    var pos = tr.rowIndex;
    
    // Hide 'remove' buttons depeding on number of rows  
    var rows = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', tr.parentNode);
    if (rows.length == 2) {
    	var elements = YAHOO.util.Dom.getElementsByClassName("removeAction","a",tr.parentNode);
    	for (var e in elements) {
    		YAHOO.util.Dom.addClass(elements[e], 'noDisplay');
    	}
    }
    
    var tbody = document.getElementById('newFilterActions').getElementsByTagName('tbody')[0];
    var filterActions = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', tbody);

    if (filterActions.length == 1)
    {
        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.actionrequired"),null);
    }
    else
    {
        if (pos == 0)
        {
            var header = filterActions[1].getElementsByTagName('th')[0];
            header.innerHTML = 'Action';
        }
        YAHOO.util.Event.purgeElement(filterActions[pos]);
        tbody.removeChild(filterActions[pos]);
        //handleActions();
        setFooter();
    }
}

// Selecting action

function newFilterActionSelects(filterRow)
{
    var portfolioSelects = YAHOO.util.Dom.getElementsByClassName('portfolioSelectList', 'select', filterRow);
    var strategySelects = YAHOO.util.Dom.getElementsByClassName('strategySelectList', 'select', filterRow);
    var settingSelects = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterRow);
    var variableSelects = YAHOO.util.Dom.getElementsByClassName('variableSelectList', 'select', filterRow);
    for (var i = 0; i < portfolioSelects.length; i++)
    {
        var portfolioSelect = portfolioSelects[i];
        var strategySelect = strategySelects[i];
        var settingSelect = settingSelects[i];
        var variableSelect = variableSelects[i];
        for (var j = portfolioSelect.options.length; j >= 0; j--)
        {
            portfolioSelect.options[j] = null;
        }
        var portfolioSelectIndex=0;
        for (var j = 0; j < apmPortfolios.length; j++)
        {
            if(typeof(currentPortfolio) != 'undefined' && currentPortfolio.id == apmPortfolios[j].id)
            {
                // skip this portfolio in Portfolio detail page
                continue;
            }
            portfolioSelect.options[portfolioSelectIndex++] = new Option(apmPortfolios[j].name, apmPortfolios[j].id);
        }
        for (var j = variableSelect.options.length; j >= 2; j--)
        {
            variableSelect.options[j] = null;
        }
        if(variableNames)
        {
            for (var j = 0; j < variableNames.length; j++)
            {
                var option = document.createElement("option");
                option.value="variable:"+variableNames[j].variableName;
                option.appendChild(document.createTextNode(variableNames[j].label));
                variableSelect.appendChild(option);
            }
        }
        for (var j = settingSelect.options.length; j >= 0; j--)
        {
            settingSelect.options[j] = null;
        }
        for (var j = strategySelect.options.length; j >= 0; j--)
        {
            strategySelect.options[j] = null;
        }
        var k = 0;
        if(apmStrategies)
        {
            for (var j = 0; j < apmStrategies.length; j++)
            {
                if(apmStrategies[j].valid)
                {
                    strategySelect.options[k++] = new Option(apmStrategies[j].name, apmStrategies[j].id);
                }
            }
        }

        if(apmSettingValueConfig)
        {
            for (var j = 0, k = 0; j < apmSettingValueConfig.length; j++)
            {
                var settingConfig = apmSettingValueConfig[j];
                if ("SPECIAL" == settingConfig.type)
                {
                    // skip
                    continue;
                }
                settingSelect.options[k] = new Option(settingConfig.label, settingConfig.name);
                k++;
            }
        }
    }
}

function createFilterRowListeners(filterRow)
{
    var variableSelectAddIcons = YAHOO.util.Dom.getElementsByClassName('variableSelectAddIcon', 'img', filterRow);
    for (var i = 0; i < variableSelectAddIcons.length; i++)
    {
        YAHOO.util.Event.addListener(variableSelectAddIcons[i],"click",onVariableAdd,filterRow,false);
    }
}

function purgeFilterRowListeners(filterRow)
{
   var variableSelectAddIcons = YAHOO.util.Dom.getElementsByClassName('variableSelectAddIcon', 'img', filterRow);
    for (var i = 0; i < variableSelectAddIcons.length; i++)
    {
        YAHOO.util.Event.purgeElement(variableSelectAddIcons[i]);
    }
}

function onVariableAdd(e,filterRow)
{
    var variableSelectSpan = YAHOO.util.Event.getTarget(e).parentNode;
    var currentSelect = variableSelectSpan.getElementsByTagName("select")[0];
    var handleSave = function ()
    {
        var postData = new Array();
        var inputs = this.body.getElementsByTagName("input");
        var label = inputs[0].value;
        var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName("error-message","div",this.body)[0];
        if(label.trim() == "")
        {
            errorMessageDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.variablelabelrequired");
            return;
        }
        errorMessageDiv.innerHTML = "";

        postData.push({key:"variableName.variableName",value:""});
        postData.push({key:"variableName.label",value:label});

        var sanitize = JSONRequest.sendMapRequest('admin/createVariableName.action',postData,
        {
            success: function(result)
            {
                if(result.result=="success")
                {
                    variableNames.push(result.variableName);
                    ruleDatums.fields["variable:"+result.variableName.variableName] = new Object();
                    ruleDatums.fields["variable:"+result.variableName.variableName].label = result.variableName.label;
                    ruleDatums.fields["variable:"+result.variableName.variableName].location = "resources:userVariables." + result.variableName.variableName;
                    
                    ruleDatums.fields["resources:userVariables."+result.variableName.variableName] = new Object();
                    ruleDatums.fields["resources:userVariables."+result.variableName.variableName].label = result.variableName.label;
                    ruleDatums.fields["resources:userVariables."+result.variableName.variableName].location = "resources:userVariables." + result.variableName.variableName;
                    
                    //Add to Auto-Complete for function editor
                    var pair = new Array();             
                    pair.name = result.variableName.label;
                    pair.id = "variable:" + result.variableName.variableName;
                    pair.className = "drag-variable";
                    variableListFunPanelObjectArray.push(pair);
                    
                    //Auto complete on home page
                    variableListDS.liveData.unshift([result.variableName.label, "variable:"+result.variableName.variableName]);
                    
                    inputVariablesList.unshift("variable:"+result.variableName.variableName);
                    
                    //sort variables after adding new variable
                    variableNames.sort(function(a,b) {
                        if(a.label < b.label)
                        {
                            return -1;
                        }
                        else if(a.label > b.label)
                        {
                            return 1;
                        }
                        return 0;
                    });

                    //update all variable Selects in the current filter row
                    var variableSelects = YAHOO.util.Dom.getElementsByClassName('variableSelectList', 'select', filterRow);
                    for(var i=0;i<variableSelects.length;i++)
                    {
                        var variableSelect = variableSelects[i];
                        var prevValue = variableSelect.value;
                        for (var j = variableSelect.options.length; j >= 0; j--)
                        {
                            variableSelect.options[j] = null;
                        }
                        for (var j = 0; j < variableNames.length; j++)
                        {
                            var option = document.createElement("option");
                            option.value = "variable:" + variableNames[j].variableName;
                            option.appendChild(document.createTextNode(variableNames[j].label));
                            variableSelect.appendChild(option);
                            if(option.value == prevValue)
                            {
                                option.selected = "selected";
                            }
                        }
                    }

                    // update variable list panel
                    updateVariableListDOM("UserVariables","variable:" + result.variableName.variableName,result.variableName.label);
                    functionEditorInstance.updateVariableListDOM("UserVariables","variable:" + result.variableName.variableName,result.variableName.label);
                    //set the current select value to the new variable
                    currentSelect.value = "variable:" + result.variableName.variableName;
                    this.hide();
                    this.destroy();
                }
                else
                {
                    var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName("error-message","div",this.body)[0];
                    errorMessageDiv.innerHTML=YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addvariable.panel.genericerror");
                }
            },
            error: function(result)
            {
                var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName("error-message","div",this.body)[0];
                errorMessageDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addvariable.panel.genericerror");
            },
            failure: function(o)
            {
                var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName("error-message","div",this.body)[0];
                errorMessageDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addvariable.panel.genericerror");
            },
            scope:this
        });

    };

    var handleCancel = function ()
    {
        this.hide();
        this.destroy();
    };

    var buttons = new Array({text:"", handler:handleSave}, {text:"", handler:handleCancel, isDefault:true});

    var dialog = new YAHOO.widget.SimpleDialog("addVariablePanelWrap", {width:"350px",underlay:"none",context:[YAHOO.util.Event.getTarget(e),"tl","bl"],modal:true, close:true, draggable:true,buttons:buttons,postmethod:"manual"});
    dialog.setHeader("<img src='../common/img/addIconBlue.gif' style='vertical-align:middle'/>&nbsp;" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addvariable.panel.header"));
    var addVariablePanel = YAHOO.util.Dom.get("addVariablePanel").cloneNode(true);
    YAHOO.util.Dom.removeClass(addVariablePanel,"noDisplay");
    dialog.setBody(addVariablePanel);
    dialog.render(variableSelectSpan);
    dialog.show();
}

function settingSelectRow(filterActionRow, settingValue)
{
    // settingValue is optional
    var settingSelect = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterActionRow)[0];
    var settingValueSelect = YAHOO.util.Dom.getElementsByClassName('settingValueList', 'select', filterActionRow)[0];
    var settingValueText = YAHOO.util.Dom.getElementsByClassName('settingValueText', 'div', filterActionRow)[0];
    var settingValueInput = settingValueText.getElementsByTagName('input')[0];
    var settingValuePhone = YAHOO.util.Dom.getElementsByClassName('settingValuePhone', 'div', filterActionRow)[0];
    var settingValuePhoneInputs = settingValuePhone.getElementsByTagName('input');
    settingValueSelect.style.overflow="hidden";
    var hidden = YAHOO.util.Dom.hasClass(settingSelect, 'noDisplay');
    if (hidden)
    {
        // settingSelect is hidden - hide all set controls
        YAHOO.util.Dom.addClass(settingValueSelect, 'noDisplay');
        YAHOO.util.Dom.addClass(settingValueText, 'noDisplay');
        YAHOO.util.Dom.addClass(settingValuePhone, 'noDisplay');
        return;
    }
    // settingSelect is visible
    if(settingSelect.selectedIndex >=0)
    {
      var settingName = settingSelect.options[settingSelect.selectedIndex].value;
      // hide the set control(s) that aren't needed
      var isSelect = isSettingSelect(settingName);
      var isPhone = isSettingPhone(settingName);
      var isText = isSettingText(settingName);

      if (!isSelect)
      {
          YAHOO.util.Dom.addClass(settingValueSelect, 'noDisplay');
      }
      if (!isText)
      {
          YAHOO.util.Dom.addClass(settingValueText, 'noDisplay');
      }
      if (!isPhone)
      {
          YAHOO.util.Dom.addClass(settingValuePhone, 'noDisplay');
      }
    }
    // fill in the values for the control (if necessary)
    initSettingValueSelect(filterActionRow);
    // set the initial value
    if (settingValue != null)
    {
        if (isSelect)
        {
            selectInOptions(YAHOO.Adeptra.Labels.getLabel(settingValue), settingValueSelect.options);
        }
        else if (isText)
        {
            if(settingValue != null)
            {
                //YAHOO.util.Event.addListener(settingValueInput,"keydown",changeToLiteralField);
                YAHOO.util.Event.addListener(settingValueInput,"keyup",changeToLiteralFieldUpdateRaw);                
                setConditionOrActionValue(settingValue, settingValueInput);
            }
            else
            {
                settingValueInput.value = "";
                settingValueInput.title = settingValueInput.value;
            }
        }
        else if (isPhone)
        {
            // settingValue is array of actions
            settingValuePhoneInputs[0].value = settingValue[0].settingValue == null ? "" : YAHOO.Adeptra.Labels.getLabel(settingValue[0].settingValue);
            settingValuePhoneInputs[0].title = settingValuePhoneInputs[0].value;
            settingValuePhoneInputs[1].value = settingValue[1].settingValue == null ? "" : YAHOO.Adeptra.Labels.getLabel(settingValue[1].settingValue);
            settingValuePhoneInputs[1].title = settingValuePhoneInputs[1].value;
            settingValuePhoneInputs[2].value = settingValue[2].settingValue == null ? "" : YAHOO.Adeptra.Labels.getLabel(settingValue[2].settingValue);
            settingValuePhoneInputs[2].title = settingValuePhoneInputs[2].value;
        }
    }
    else
    {
        var settingConfig = getSelectedSettingConfig(filterActionRow);
        if (settingConfig)
        {
            if (isSelect)
            {
                selectInOptions(settingConfig.appDefault, settingValueSelect.options);
            }
            else if (isText)
            {
                settingValueInput.value = settingConfig.appDefault == null ? "" : settingConfig.appDefault;
                settingValueInput.title = getInputTooltip(settingValueInput.value);
                settingValueInput.setAttribute("data-raw", "constant:"+settingValueInput.value);
            }
            else if (isPhone)
            {
                // set default value for each constituent SET action
                var settingConfigs = getPhoneSettingConfigs(settingConfig);
                settingValuePhoneInputs[0].value = settingConfigs[0].appDefault == null ? "" : settingConfigs[0].appDefault;
                settingValuePhoneInputs[0].title = settingValuePhoneInputs[0].value;
                settingValuePhoneInputs[1].value = settingConfigs[1].appDefault == null ? "" : settingConfigs[1].appDefault;
                settingValuePhoneInputs[1].title = settingValuePhoneInputs[1].value;
                settingValuePhoneInputs[2].value = settingConfigs[2].appDefault == null ? "" : settingConfigs[2].appDefault;
                settingValuePhoneInputs[2].title = settingValuePhoneInputs[2].value;
            }
        }
    }
    // show the control that is needed
    if (isSelect)
    {
        YAHOO.util.Dom.removeClass(settingValueSelect, 'noDisplay');
    }
    if (isText)
    {
        YAHOO.util.Dom.removeClass(settingValueText, 'noDisplay');
    }
    if (isPhone)
    {
        YAHOO.util.Dom.removeClass(settingValuePhone, 'noDisplay');
    }
}

function actionSelectRow(filterActionRow)
{
    var actionSelect = YAHOO.util.Dom.getElementsByClassName('actionSelect', 'select', filterActionRow)[0];
    var suspendMinsLabel = YAHOO.util.Dom.getElementsByClassName('suspendMinsLabel', 'div', filterActionRow)[0];
    var portfolioSelect = YAHOO.util.Dom.getElementsByClassName('portfolioSelectList', 'select', filterActionRow)[0];
    var strategySelect = YAHOO.util.Dom.getElementsByClassName('strategySelectList', 'select', filterActionRow)[0];
    var settingSelect = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', filterActionRow)[0];
    var strategyMinsLabel = YAHOO.util.Dom.getElementsByClassName('strategyMinsLabel', 'div', filterActionRow)[0];
    var actionMinsInput = YAHOO.util.Dom.getElementsByClassName('actionMinsInput', 'div', filterActionRow)[0];
    var variableSelectSpan = YAHOO.util.Dom.getElementsByClassName('variableSelectSpan', 'span', filterActionRow)[0];
    var variableInput = YAHOO.util.Dom.getElementsByClassName('variableValueText', 'div', filterActionRow)[0];
    var tenantSelect = YAHOO.util.Dom.getElementsByClassName('tenantSelectList', 'select', filterActionRow)[0];

    // hide first
    var action = actionSelect.options[actionSelect.selectedIndex].value;
    if (!(action == 1))
    {
        // not suspend
        YAHOO.util.Dom.addClass(suspendMinsLabel, 'noDisplay');
        YAHOO.util.Dom.addClass(actionMinsInput, 'noDisplay');
    }
    if (!(action == 2))
    {
        // not goto portfolio
        YAHOO.util.Dom.addClass(portfolioSelect, 'noDisplay');
    }
    if (!(action == 3))
    {
        // not goto strategy
        YAHOO.util.Dom.addClass(strategySelect, 'noDisplay');
    }
    if (!(action == 3 || action == 6))
    {
        // not goto strategy nor goto alert
        YAHOO.util.Dom.addClass(strategyMinsLabel, 'noDisplay');
        YAHOO.util.Dom.addClass(actionMinsInput, 'noDisplay');
    }
    if (!(action == 5))
    {
        // not set strategy
        YAHOO.util.Dom.addClass(strategySelect, 'noDisplay');
    }
    if (!(action == 4))
    {
        // not set
        YAHOO.util.Dom.addClass(settingSelect, 'noDisplay');
        // this will hide set controls
        settingSelectRow(filterActionRow);
    }
    if (!(action == 11))
    {
        variableInput.firstChild.acceptAllFunction = '0';
    }
    if (!(action == 9))
    {
        // not set variable
        YAHOO.util.Dom.addClass(variableSelectSpan, 'noDisplay');
    }
    if (!(action == 9 || action == 11))
    {
        // not set variable or execute
        YAHOO.util.Dom.addClass(variableInput, 'noDisplay');
    }
    if (!(action == 13))
    {
        // not goto tenant
        YAHOO.util.Dom.addClass(tenantSelect, 'noDisplay');
    }
    // then show
    if (action == 1)
    {
        // suspend
        YAHOO.util.Dom.removeClass(suspendMinsLabel, 'noDisplay');
        YAHOO.util.Dom.removeClass(actionMinsInput, 'noDisplay');
    }
    if (action == 2)
    {
        // goto portfolio
        YAHOO.util.Dom.removeClass(portfolioSelect, 'noDisplay');
    }
    if (action == 3)
    {
        // goto strategy
        YAHOO.util.Dom.removeClass(strategySelect, 'noDisplay');
    }
    if (action == 3 || action == 6)
    {
        // goto strategy or goto alert
        YAHOO.util.Dom.removeClass(strategyMinsLabel, 'noDisplay');
        YAHOO.util.Dom.removeClass(actionMinsInput, 'noDisplay');
    }
    if (action == 5)
    {
        // set strategy
        YAHOO.util.Dom.removeClass(strategySelect, 'noDisplay');
    }
    if (action == 4)
    {
        // set
        YAHOO.util.Dom.removeClass(settingSelect, 'noDisplay');
        settingSelectRow(filterActionRow);
    }
    if (action == 8)
    {
        // set delay
        YAHOO.util.Dom.removeClass(suspendMinsLabel, 'noDisplay');
        YAHOO.util.Dom.removeClass(actionMinsInput, 'noDisplay');
    }
    if (action == 9)
    {
        // set variable
        YAHOO.util.Dom.removeClass(variableSelectSpan, 'noDisplay');
        YAHOO.util.Dom.removeClass(variableInput, 'noDisplay');
    }
    if (action == 11)
    {
        // execute
        YAHOO.util.Dom.removeClass(variableInput, 'noDisplay');
        variableInput.firstChild.acceptAllFunction = '1';
    }
    if (action == 12)
    {
        // execute
        YAHOO.util.Dom.removeClass(actionMinsInput, 'noDisplay');
    }
    if (action == 13)
    {
        // goto tenant
        YAHOO.util.Dom.removeClass(tenantSelect, 'noDisplay');
    }
}

function newFilterActionSelect(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode;
    var pos = tr.rowIndex;
    var tbody = document.getElementById('newFilterActions').getElementsByTagName('tbody')[0];
    var filterActionRow = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', 'newFilterActions')[pos];
    actionSelectRow(filterActionRow);
}

function newFilterSettingSelect(e)
{
    var tr = YAHOO.util.Event.getTarget(e).parentNode.parentNode;
    var pos = tr.rowIndex;
    var tbody = document.getElementById('newFilterActions').getElementsByTagName('tbody')[0];
    var filterActionRow = YAHOO.util.Dom.getElementsByClassName('newFilterAction', 'tr', 'newFilterActions')[pos];
    settingSelectRow(filterActionRow);
}

/*function handleActions()
{
        purgeActions();
    setTimeout(addListeners('addAction', 'a', 'newFilterActions', 'newFilterAddAction'), 0);
    setTimeout(addListeners('removeAction', 'a', 'newFilterActions', 'newFilterRemoveAction'), 0);
    setTimeout(addListeners('actionSelect', 'select', 'newFilterActions', 'newFilterActionSelect'), 0);
    setTimeout(addListeners('settingSelectList', 'select', 'newFilterActions', 'newFilterSettingSelect'), 0);
}*/

function addActionListeners(rows)
{
    for (var i=0;i<rows.length;i++)
    {
        var row = rows[i];
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('addAction', 'a', row)[0],'click',newFilterAddAction);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('removeAction', 'a', row)[0],'click',newFilterRemoveAction);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('actionSelect', 'select', row)[0],'change',newFilterActionSelect);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', row)[0],'change',newFilterSettingSelect);
           
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBoxSettingValue', 'input', row)[0],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBoxSettingValue', 'input', row)[1],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBox', 'input', row)[0],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBox', 'input', row)[1],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBox', 'input', row)[2],"keyup",changeToLiteralFieldUpdateRaw);
        YAHOO.util.Event.addListener(YAHOO.util.Dom.getElementsByClassName('textBox', 'input', row)[3],"keyup",changeToLiteralFieldUpdateRaw);        
                
    }
}

/*function purgeActions()
{
    var addActions = YAHOO.util.Dom.getElementsByClassName('addAction', 'a', 'newFilterActions', 'newFilterAddAction');
    var removeActions = YAHOO.util.Dom.getElementsByClassName('removeAction', 'a', 'newFilterActions');
    var actionSelects = YAHOO.util.Dom.getElementsByClassName('actionSelect', 'select', 'newFilterActions');
    var settingSelects = YAHOO.util.Dom.getElementsByClassName('settingSelectList', 'select', 'newFilterActions');

    for (var i=0; i<addActions.length; i++)
    {
        var addLink = addActions[i];
        YAHOO.util.Event.purgeElement(addLink, true);
        var remLink = removeActions[i];
        YAHOO.util.Event.purgeElement(remLink, true);
        var selLink = actionSelects[i];
        YAHOO.util.Event.purgeElement(selLink, true);
        var setLink = settingSelects[i];
        YAHOO.util.Event.purgeElement(setLink, true);
    }
}*/


function wrapAndInsert(text, element, dual)
{
    var noOfChars = 32;
    // IE tends to be too slow doing this, restrict to non IE browsers
    if(_browser.indexOf("ie") == -1)
    {
          var noOfPixelsPerChar = 8;
          var clientWidth = element.clientWidth;
          noOfChars = Math.round(clientWidth/noOfPixelsPerChar);
    }
    
    // for dual content holding (backend untranslated raw)
    if (dual == true) {
    	// see labels.js
    	YAHOO.Adeptra.Common.breakAndWrap(element,noOfChars,YAHOO.Adeptra.Labels.generate(text));
    	element.setAttribute("data-raw", text);
    } else {
    	YAHOO.Adeptra.Common.breakAndWrap(element,noOfChars,text);
    }
}

function createFilterRow(rule, pos, newRow)
{
    var priorityTd = document.createElement('td');
    newRow.appendChild(priorityTd);
    priorityTd.className = "priorityArrows";
    priorityTd.innerHTML = "<strong>" + (pos+1) + "</strong>";
    priorityTd.innerHTML += ' <a href="#" class="upPrioritize"><img src="../common/img/iconPriorityUpDisabled.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.giveportfoliohigherpriority") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.giveportfoliohigherpriority") + '" /></a>';
    priorityTd.innerHTML += ' <a href="#" class="downPrioritize"><img src="../common/img/iconPriorityDownDisabled.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.giveportfoliolowerpriority") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.giveportfoliolowerpriority") + '" /></a>';

    var enableDisableTd = document.createElement('td');
    newRow.appendChild(enableDisableTd);
    enableDisableTd.className = "enableCell";
    enableDisableTd.innerHTML =
    '<input type="checkbox" ' + (rule.enabled ? 'checked="checked"' : '') +
    (hasRulePrivilege ? '' : ' disabled="disabled"') + ' class="disableFilter" />';

    var ruleNameTd = document.createElement('td');
    newRow.appendChild(ruleNameTd);
    var ruleName = rule.name;
    wrapAndInsert(ruleName,ruleNameTd);
    ruleNameTd.className="filterName";

    var conditionsTd = document.createElement('td');
    conditionsTd.style.padding = "0";
    newRow.appendChild(conditionsTd);

    var actionsTd = document.createElement('td');
    newRow.appendChild(actionsTd);

    var addEditDeleteTd = null;
    if (hasRulePrivilege)
    {
        addEditDeleteTd = document.createElement('td');
        newRow.appendChild(addEditDeleteTd);
    }

    //conditions
    var conditions = rule.conditions;
    var condTable = document.createElement("table");
    condTable.style.width = "100%";
    condTable.style.height = "100%";
    condTable.style.borderStyle = "none";
    condTable.style.borderWidth = "0";
    conditionsTd.appendChild(condTable);
    if (conditions.length)
    {
        var col1 = document.createElement("col");
        col1.width="10%";
        condTable.appendChild(col1);
        var col2 = document.createElement("col");
        col2.width="40%";
        condTable.appendChild(col2);
        var col3 = document.createElement("col");
        col3.width="10%";
        condTable.appendChild(col3);
        var col4 = document.createElement("col");
        col4.width="40%";
        condTable.appendChild(col4);

        var condTbody = document.createElement("tbody");
        condTable.appendChild(condTbody);

        for (var i = 0; i < conditions.length; i++)
        {

            var condition = conditions[i];
            var previousCondition = i > 0 ? conditions[i-1] : {};

            var condTr = document.createElement("tr");
            condTr.style.height = "100%";
            condTbody.appendChild(condTr);

            var condTd1 = document.createElement("td");
            condTd1.style.width = "10%";
            condTd1.style.height = "100%";
            condTd1.style.borderStyle="none";
            condTd1.style.borderWidth = "0";

            if(previousCondition.logicalOperator == "O")
            {
                YAHOO.util.Dom.addClass(condTd1,"orCondition");
            }

            var condTd2 = document.createElement("td");
            condTd2.style.width = "40%";
            condTd2.style.height = "100%";
            condTd2.style.borderStyle="none";
            condTd2.style.borderWidth="0";
            if(condition.logicalOperator == "O" || previousCondition.logicalOperator == "O")
            {
                YAHOO.util.Dom.addClass(condTd2,"orCondition");
            }

            var condTd3 = document.createElement("td");
            condTd3.style.width = "10%";
            condTd3.style.height = "100%";
            condTd3.style.borderStyle = "none";
            condTd3.style.borderWidth = "0";
            if(condition.logicalOperator == "O" || previousCondition.logicalOperator == "O")
            {
                YAHOO.util.Dom.addClass(condTd3,"orCondition");
            }

            var condTd4 = document.createElement("td");
            condTd4.style.width = "40%";
            condTd4.style.height = "100%";
            condTd4.style.borderStyle = "none";
            condTd4.style.borderWidth = "0";
            if(condition.logicalOperator == "O" || previousCondition.logicalOperator == "O")
            {
                YAHOO.util.Dom.addClass(condTd4,"orCondition");
            }

            condTr.appendChild(condTd1);
            condTr.appendChild(condTd2);
            condTr.appendChild(condTd3);
            condTr.appendChild(condTd4);

            if ( i==0 )
            {
                condTd1.innerHTML = '<p><strong>' + YAHOO.Adeptra.I18NUtil.label("portal2.common.if") + '</strong></p>';
            }
            else
            {
                condTd1.innerHTML += '<p><strong>' + (previousCondition.logicalOperator == "O" ? YAHOO.Adeptra.I18NUtil.label("portal2.common.or") : YAHOO.Adeptra.I18NUtil.label("portal2.common.and")) + '</strong></p>';
            }

            if(condition.value1 == null || condition.value1 == "" || condition.value1 == "null" || condition.value1 == "constant:")
            {
                var p = document.createElement("i");
                p.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.null")));
                condTd2.appendChild(p);
            }
            else
            {
                if(isNamedFunction(condition.value1))
                {
                    var arr = getNamedFunctionComponents(condition.value1);
                    wrapAndInsert(arr[1],condTd2, true);
                    condTd2.title = getInputTooltip(arr[2]);
                    YAHOO.util.Dom.addClass(condTd2,"named-function");
                }
                else if(isFunction(condition.value1))
                {
                    wrapAndInsert(condition.value1,condTd2, true);
                    YAHOO.util.Dom.addClass(condTd2,"general-function");
                }
                else if(isVariable(condition.value1))
                {
                    wrapAndInsert(condition.value1,condTd2, true);
                    YAHOO.util.Dom.addClass(condTd2,"variable");
                }
                else
                {
                    wrapAndInsert(condition.value1,condTd2, true);
                }
            }

            condTd3.innerHTML = '<p>' + condition.operator + '</p>';

            if(condition.value2 == null || condition.value2 == "" || condition.value2 == "null" || condition.value2 == "constant:")
            {
                var p = document.createElement("i");
                p.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.null")));
                condTd4.appendChild(p);
            }
            else
            {
                if(isNamedFunction(condition.value2))
                {
                    var arr = getNamedFunctionComponents(condition.value2);
                    wrapAndInsert(arr[1],condTd4, true);
                    condTd4.title = getInputTooltip(arr[2]);
                    YAHOO.util.Dom.addClass(condTd4,"named-function");
                }
                else if(isFunction(condition.value2))
                {
                    wrapAndInsert(condition.value2,condTd4, true);
                    YAHOO.util.Dom.addClass(condTd4,"general-function");
                }
                else if(isVariable(condition.value2))
                {
                    wrapAndInsert(condition.value2,condTd4, true);
                    YAHOO.util.Dom.addClass(condTd4,"variable");
                }
                else
                {
                    wrapAndInsert(condition.value2,condTd4, true);
                }
            }
        }
    }
    else
    {
        var condTbody = document.createElement("tbody");
        condTable.appendChild(condTbody);
        var condTr = document.createElement("tr");
        condTr.style.height = "100%";
        condTbody.appendChild(condTr);

        var condTd1 = document.createElement("td");
        condTd1.style.width = "10%";
        condTd1.style.height = "100%";
        condTd1.style.borderStyle="none";
        condTd1.style.borderWidth = "0";
        condTr.appendChild(condTd1);
        condTd1.innerHTML = '<p><strong>' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.always") + '</strong></p>';
    }

    // Actions

    var actionsTable = document.createElement("table");
    actionsTable.style.width="100%";
    actionsTd.appendChild(actionsTable);

    actionsTable.className = "filterActionsTable";
    var actionsTableTbody = document.createElement("tbody");
    actionsTable.appendChild(actionsTableTbody);

    // "Collapse" the display into SET PHONE type actions if the rule contains all constituent SET actions
    var phoneActionsRendered = new Array();

    var actions = rule.actions;

    if (actions.length)
    {
        for (var i = 0; i < actions.length; i++)
        {
            var action = actions[i];
            var phoneSettingConfig = getActionPhoneSettingConfig(action);
            if (phoneSettingConfig != null && phoneActionsRendered[action.settingName])
            {
                // skip this action, it is part of a SET PHONE trio which has already been rendered
                continue;
            }
            var tr = document.createElement("tr");
            actionsTableTbody.appendChild(tr);

            var td1 = document.createElement('td');
            td1.width="10%";
            tr.appendChild(td1);
            var td2 = document.createElement('td');
            td2.width="30%";
            tr.appendChild(td2);

            var actionClause = "";
            var actionName = "";
            if (conditions.length)
            {
	            if (i == 0)
	            {
	                actionClause = '<p><strong>' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.then") + '</strong> ';
	            }
	            else
	            {
	                actionClause = '<p><strong>' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.and") + '</strong> ';
	            }
            }

            switch (action.action)
            {
            case 0:
                // terminate
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.terminatecase"));
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 1:
                // suspend
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.suspendcase"));
                if (action.data) {
                    actionName += " (" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.duration") + ": " + action.data + ")";
                }
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 2:
                // goto portfolio/rule group
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.gotoportfolio"));
                var portfolioLink;
                if (action.portfolio)
                {
                    portfolioLink = YAHOO.Adeptra.Common.portfolioDetailsLink(findPortfolio(action.portfolio.id));
                }
                else
                {
                    portfolioLink = YAHOO.Adeptra.Common.portfolioDetailsLink(findPortfolio(portfolioFilter.id));
                }

                var td3 = document.createElement('td');
                td3.width="60%";
                td3.setAttribute("colspan","2");
                td3.appendChild(portfolioLink);
                tr.appendChild(td3);
                break;
            case 3:
                // goto strategy
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.gotostrategy"));
                if (action.data) {
                    actionName += " (" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.delay") + ": " + action.data + ")";
                }
                var strategyLink = YAHOO.Adeptra.Common.strategyDetailsLink(findStrategy(action.strategyUser.id));

                var td3 = document.createElement('td');
                td3.width="60%";
                td3.setAttribute("colspan","2");
                td3.appendChild(strategyLink);
                tr.appendChild(td3);
                break;
            case 4:
                // set
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.set"));

                var td3 = document.createElement('td');
                td3.width="30%";
                tr.appendChild(td3);
                var td4 = document.createElement('td');
                td4.width="30%";
                tr.appendChild(td4);

                var phoneActions = phoneSettingConfig != null ? getRulePhoneActions(phoneSettingConfig, rule) : null;
                
                if (phoneActions == null)
                {
                    wrapAndInsert(action.settingName,td3, true);

                    var settingConfig = findSettingConfigByName(action.settingName);
                    if(settingConfig.type == "CALLWINDOW")
                    {
                        for(var ii=0;ii<callWindows.length;ii++)
                        {
                            if(callWindows[ii].id == YAHOO.Adeptra.Labels.getLabel(action.settingValue))
                            {
                                wrapAndInsert(callWindows[ii].name,td4,true);
                                break;
                            }
                        }
                    }
                    else
                    {

                        if (action.settingValue == null || action.settingValue == "" || action.settingValue == "null" || action.settingValue == "constant:")
                        {
                            var p = document.createElement("i");
                            p.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.null")));
                            td4.appendChild(p);
                        }
                        else
                        {
                            actionValue2 = document.createElement("p");
                            if(isNamedFunction(action.settingValue))
                            {
                                var arr = getNamedFunctionComponents(action.settingValue);
                                wrapAndInsert(arr[1],td4,true);
                                td4.title = getInputTooltip(arr[2]);
                                YAHOO.util.Dom.addClass(td4,"named-function");
                            }
                            else if(isFunction(action.settingValue))
                            {
                                wrapAndInsert(action.settingValue,td4,true);
                                YAHOO.util.Dom.addClass(td4,"general-function");
                            }
                            else if(isVariable(action.settingValue))
                            {
                                wrapAndInsert(action.settingValue,td4,true);
                                YAHOO.util.Dom.addClass(td4,"variable");
                            }
                            else
                            {
                                wrapAndInsert(action.settingValue,td4,true);
                            }
                        }
                    }
                    //td4.appendChild(actionValue2);
                }
                else
                {
                    // combine SET PHONE action values
                    var actionValue1 = phoneSettingConfig.label;
                    wrapAndInsert(actionValue1,td3,true);

                    var actionValue2 = YAHOO.Adeptra.Labels.getLabel(phoneActions[0].settingValue) + "-" + YAHOO.Adeptra.Labels.getLabel(phoneActions[1].settingValue) + "-" + YAHOO.Adeptra.Labels.getLabel(phoneActions[2].settingValue);
                    wrapAndInsert(actionValue2,td4,true);

                    // keep track of the SET PHONE actions that have already been rendered so we skip over them
                    phoneActionsRendered[phoneActions[0].settingName] = true;
                    phoneActionsRendered[phoneActions[1].settingName] = true;
                    phoneActionsRendered[phoneActions[2].settingName] = true;
                }
                break;
            case 5:
                // set strategy
                // This is no longer used
                break;
            case 6:
                // goto alert
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.createalert"));
                if (action.data) {
                    actionName += " (" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.delay") + ": " + action.data + ")";
                }
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 7:
                // clear settings
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.clearsettings"));
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 8:
                // set delay
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.setdelay"));
                if (action.data) {
                    actionName += " (" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.delay") + ": " + action.data + ")";
                }
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 9:
                // set variable
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.setvariable"));

                var td3 = document.createElement('td');
                td3.width="30%";
                tr.appendChild(td3);
                var td4 = document.createElement('td');
                td4.width="30%";
                tr.appendChild(td4);

                var actionValue1 = action.settingName;
                for (j = 0; j < variableNames.length; j++) {
                    if (variableNames[j].variableName == action.settingName) {
                        actionValue1 = variableNames[j].label;
                        break;
                    }
                }
                wrapAndInsert(actionValue1,td3,true);

                if (action.settingValue == null || action.settingValue == "" || action.settingValue == "null" || action.settingValue == "constant:")
                {
                    var p = document.createElement("i");
                    p.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.null")));
                    td4.appendChild(p);
                }
                else
                {
                    if(isNamedFunction(action.settingValue))
                    {
                        var arr = getNamedFunctionComponents(action.settingValue);
                        wrapAndInsert(arr[1],td4,true);
                        td4.title = getInputTooltip(arr[2]);
                        YAHOO.util.Dom.addClass(td4,"named-function");
                    }
                    else if(isFunction(action.settingValue))
                    {
                        wrapAndInsert(action.settingValue,td4,true);
                        YAHOO.util.Dom.addClass(td4,"general-function");
                    }
                    else if(isVariable(action.settingValue))
                    {
                        wrapAndInsert(action.settingValue,td4,true);
                        YAHOO.util.Dom.addClass(td4,"variable");
                    }
                    else
                    {
                        wrapAndInsert(action.settingValue,td4,true);
                    }
                }
                break;

            case 10:
                // return
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.return"));
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 11:
                // execute
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.execute"));

                var td3 = document.createElement('td');
                td3.width="60%";
                td3.setAttribute("colspan","2");
                tr.appendChild(td3);

                if(isNamedFunction(action.settingValue))
                {
                    var arr = getNamedFunctionComponents(action.settingValue);
                    wrapAndInsert(arr[1],td3,true);
                    td3.title =  getInputTooltip(arr[2]);
                    YAHOO.util.Dom.addClass(td3,"named-function");
                }
                else if(isFunction(action.settingValue))
                {
                    wrapAndInsert(action.settingValue,td3,true);
                    YAHOO.util.Dom.addClass(td3,"general-function");
                }
                else if(isVariable(action.settingValue))
                {
                    wrapAndInsert(action.settingValue,td3,true);
                    YAHOO.util.Dom.addClass(td3,"variable");
                }
                else
                {
                    wrapAndInsert(action.settingValue,td3,true);
                }

                break;

            case 12:
                // delay
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.delayaction"));
                if (action.data) {
                    actionName += " (" + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.duration") + ": " + action.data + ")";
                }
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 13:
                // goto tenant
                actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.gototenant"));
                if (action.settingValue)
                {
                    actionName += " " + tenants[action.settingValue];
                }
                td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            case 14:
            	//wait for result
            	actionName = YAHOO.Adeptra.Labels.getActionLabel(action.action,YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.action.waitforresult"));
            	td2.width="90%";
                td2.setAttribute("colspan","3");
                break;
            }

            td1.innerHTML = actionClause;
            wrapAndInsert(actionName,td2,true);
        }
    }

    if (addEditDeleteTd)
    {
        addEditDeleteTd.innerHTML = '<table><tr>' + (isApm2 || isAde ? '<td style="padding:0px;border:none;"><a href="#filter'+ (pos + 1) +'" class="copyFilterLink"><img src="../common/img/iconCopy.png" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.copyrule") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.copyrule") + '"/></a>&nbsp;</td>' : '') + '<td style="padding:0px;border:none;"><a href="#filter'+ (pos + 1) +'" class="editFilterLink"><img src="../common/img/iconEdit.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.editrule1") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.editrule1") + '"/></a>&nbsp;</td><td style="padding:0px;border:none;"><a href="#dead" class="deleteFilterLink"><img src="../common/img/iconRemove.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.removerule") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.removerule") + '"/></a>&nbsp;</td><td style="padding:0px;border:none;"><a href="#filter'+ (pos + 1) +'" class="newFilterLink"><img src="../common/img/iconAdd.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addrule") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.addrule") + '"/></a></td></tr></table>';
        addEditDeleteTd.className = 'lastCell3Buttons';
    }

    newRow.className = 'filterRow';
}

function isFunction(input)
{	
    if (input == null || input.indexOf("constant") == 0) 
    {
        return false;
    }
    var functionPattern = new RegExp("[a-zA-Z]+.*\\(.*\\).*");
    var matches = functionPattern.exec(input);
    if (matches != null && matches[0].length == input.length)
    {
        return true;
    }
    return false;
}

function isNamedFunction(value)
{
    return value != null && value.indexOf("named-function:") == 0;
}

function isVariable(value)
{
    if (value == null || value == "")
    {
        return false;
    }
    for(var i=0;i<inputVariablesList.length;i++)
    {
        if(inputVariablesList[i] == value)
        {
            return true;
        }
    }
    return false;
}

function getNamedFunctionComponents(value)
{
    var arr = [];
    var firstIndex = value.indexOf(":");
    var secondIndex = value.indexOf(":",firstIndex+1);

    arr[0] = value.substring(0,firstIndex);
    arr[1] = value.substring(firstIndex+1,secondIndex);
    arr[2] = value.substring(secondIndex+1);
    return arr;
}
