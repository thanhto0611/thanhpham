// Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.

var autoCompletes = null;

function clearAutoCompletes(filterElement)
{
    var autoCompleteContainers = YAHOO.util.Dom.getElementsByClassName("autoCompleteContainer", 'div', filterElement);
    for ( var i = 0; i < autoCompleteContainers.length; i++)
    {
        autoCompleteContainers[i].parentNode.removeChild(autoCompleteContainers[i]);
    }
}

function dragDropHandler(targetElement, value, dragValue, isSrcClassVariable, isSrcClassLiteral)
{
	// Decide whether to use location attribute
	var param = DDInput.prototype.getParameterForField(targetElement);
	var isLocation = false;
	if (param != undefined && (param.type == "location" || param.type == "string-literal-translated")) {
		if(ruleDatums.fields[value] != undefined && ruleDatums.fields[value].location != undefined)
		{
			value =  ruleDatums.fields[value].location;
			isLocation = true;
	    } 
	}
	
    if (targetElement.dataType == 'string-literal-translated')
    {
        var correctedValue = value;
        var index;
        if ((index = correctedValue.indexOf(":")) != -1)
        {
            correctedValue = correctedValue.substring(0, index) + "." + correctedValue.substring(index + 1);
        }

        targetElement.value = dragValue;
        
        // Only single quote if not a location value
        if (!isLocation) correctedValue = "'"+correctedValue.replace(/\'/g,'')+"'";
        
        targetElement.setAttribute("data-raw", correctedValue);
        purgeParameterFieldClasses(targetElement);
        YAHOO.util.Dom.addClass(targetElement, 'literal');
    } 
    else if (targetElement.dataType == 'expression')
    {
        var correctedValue = value;
        if ((index = correctedValue.indexOf(":")) != -1)
        {
            correctedValue = correctedValue.substring(0, index) + "." + correctedValue.substring(index + 1);
        }

        var cursorPosition = getCaret(targetElement);
        targetElement.value = targetElement.value.substring(0, cursorPosition) + correctedValue + targetElement.value.substring(cursorPosition);
        targetElement.setAttribute("data-raw", targetElement.value);
        // sets the caret at the end of the inserted values
        setCaret(targetElement, cursorPosition + correctedValue.length);

        purgeParameterFieldClasses(targetElement);
        YAHOO.util.Dom.addClass(targetElement, 'literal');
    } 
    else if (targetElement.dataType == 'variable-expression')
    {
        var translatedValue = value;
        // variable or location
        if (translatedValue.indexOf("variable:") == 0)
        {
            var index = "variable:".length;
            targetElement.value = translatedValue.substring(0, index - 1) + "." + translatedValue.substring(index);
            targetElement.setAttribute("data-raw", targetElement.value);
        } 
        else if (translatedValue.indexOf("location:") == 0)
        {
            var index = "location:".length;
            targetElement.value = targetElement.value + "." + translatedValue.substring(index);
            targetElement.setAttribute("data-raw", targetElement.value);
        }
        purgeParameterFieldClasses(targetElement);
        YAHOO.util.Dom.addClass(targetElement, 'variable');
    } 
    else
    {
        targetElement.value = dragValue;
        
        // Correct data-raw value
        var correctedValue = value;
        if (correctedValue.indexOf(":") != -1)
        {
            correctedValue = correctedValue.replace(":",".");
        }        
        targetElement.setAttribute("data-raw", correctedValue);
        
        purgeParameterFieldClasses(targetElement);
        if (isSrcClassVariable)
        {
            YAHOO.util.Dom.addClass(targetElement, 'variable');
        } 
        else if (isSrcClassLiteral)
        {
            YAHOO.util.Dom.addClass(targetElement, 'literal');
        }
    }
}

function destroyAutoCompletes()
{
    for ( var i = 0; i < autoCompletes.length; i++)
    {
        autoCompletes[i].destroy();
    }
    autoCompletes = null;
}

function initAutoComplete(inputTarget, variableListDataSource, showFunPanel) {
	 var autoCompleteContainer = document.createElement("div");
     autoCompleteContainer.className = "autoCompleteContainer";     
     inputTarget.parentNode.parentNode.appendChild(autoCompleteContainer);
     var oAutoComp = new YAHOO.widget.AutoComplete(inputTarget, autoCompleteContainer, variableListDataSource);
     oAutoComp.queryDelay = 0;
     oAutoComp.prehighlightClassName = "yui-ac-prehighlight";
     oAutoComp.typeAhead = false;
     oAutoComp.useShadow = false;
     oAutoComp.animVert = false;
     oAutoComp.animHoriz = false;
     oAutoComp.useIFrame = true;
     oAutoComp.resultTypeList = false;

     /*
      * Override the rendering
      */
     oAutoComp.formatResult = function(oResultData, sQuery, sResultMatch)
     {
         return oResultData.name;
     };
     oAutoComp.itemSelectEvent.subscribe(function(sType, oArgs)
         {
             var textBox = oArgs[0]._elTextbox;
             var oData = oArgs[2]; // object literal of selected item's result
             var accepts = DDInput.prototype.functionEditorAcceptsArgument(textBox, null, oData.id);             
             if (accepts) {
            	 dragDropHandler(textBox, oData.id, oData.name, (oData.className == 'drag-variable'), (oData.className == 'drag-literal'));       
             } else {
            	 DDInput.prototype.functionEditorRejectsArgument(textBox);       	
             }
         }
     );
     if (showFunPanel)
     {
         oAutoComp.itemSelectEvent.subscribe(function(sType, oArgs)
         {
             functionEditorInstance.showNewFunctionPanel(oArgs[2], oArgs[0]._elTextbox);
         });
     }
     autoCompletes.push(oAutoComp);
}

function initConditionAutoComplete(filterElement, variableListDataSource, showFunPanel)
{
    var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', filterElement);
    autoCompletes = autoCompletes == null ? [] : autoCompletes;
    for ( var i = 0; i < inputTargets.length; i++)
    {
    	initAutoComplete(inputTargets[i], variableListDataSource, showFunPanel);
    }
}

/**
 * Given a string containing the comma-delimited parameters of a functional call,
 * the method returns the value of each parameter.
 * 
 * If a function call is foobar(a,b,c), then the argument parameter is expected
 * to be "a,b,c" when calling this method.
 * 
 * Example of function call, argument parameter expected, and result returned
 * 
 * +------------------------------------------------------------------------+
 * | foobar(a,4,c)            | "a,4,c"            | ["a", "4", "c"]        |
 * |                          |                    |                        |
 * | foobar('a', length(str)) | "'a', length(str)" | ["'a'", "length(str)"] |
 * |                          |                    |                        |
 * | foobar('a', substr(n,m)) | "'a', substr(n,m)" | ["'a'", "substr(n,m)"] |
 * |                          |                    |                        |
 * | foobar('hi,bye', idx)    | "'hi,bye', idx"    | ["'hi,bye'", "idx"]    |
 * +------------------------------------------------------------------------+
 *  
 * @param argument the string containing the delimited parameters
 * @param functionInfo object containing metadata about the function call
 * @returns an array with each parameter value
 */
function splitParameters(argument,functionInfo)
{
	var demarcations = []; // indices that mark parameter boundaries
	var inSingleQuote = false; // flag indicating if in a quoted string
	var inParens = 0; // keeps track if parentheses are balanced
	var inBracket = 0; // keeps track if parentheses are balanced
	
	var i = 0;
	while (i < argument.length)
	{
		var c = argument.charAt(i);
		
		if (c == "'") // indicates start or end of a quoted string, so flip flag
		{
			inSingleQuote = !inSingleQuote;
		}
		else if (inSingleQuote)
		{
			// in a quoted string, move on
		}
		else if (c == '(')
		{
			inParens++;
		}
		else if (c == ')')
		{
			inParens--;
		}
		else if (c == '[')
		{
			inBracket++;
		}
		else if (c == ']')
		{
			inBracket--;
		}
		else if (c == ',')
		{
			if (inParens == 0 && inBracket == 0)
			{
				// it's a parameter separator, so mark it
				demarcations.push(i);
			}
		}
		
		i++;
	}
	
	var params = []; // the parameter values returned by this method
	// return the params using demarcations
	var functionParams = functionInfo.params;
	if (functionParams && functionParams.length > 0)
	{
		// true if the last parameter in the function call is an expression
		var isLastParamExpression = functionParams[functionParams.length - 1].type == "expression";
		var lastIdx = 0, idx = 0; // indices bounding the parameter to extract
		// maximum number of parameters to parse: if the last param is not an expression
		// then parse all demarcations, otherwise parse only the number of params
		// declared by the function (# demarcations = # params - 1)
		var maxDemarcs = isLastParamExpression ? functionParams.length - 1: demarcations.length;
		for (var j=0; j<maxDemarcs ; j++)
		{
			idx = demarcations[j];
			params.push(argument.substr(lastIdx, (idx - lastIdx)));
			
			lastIdx = idx + 1;
		}
		params.push(argument.substr(lastIdx));
	}
	
	return params;
}

YAHOO.Adeptra.FunctionEditor = function(variableListFunctionPanelDS) {
    this.variableListFunctionPanelDS = null;
    this.functionInfo = null;
    this.functionPanel = null;
    this.functionTextTarget = null;
		

    // variable list panel for functions
    this.functionPanelVariableListDOM = null;
    this.functionPanelTargetDragDrop = [];
    
    // variable list panel for named functions
    this.namedFunctionPanelVariableListDOM = null;
    this.namedFunctionPanelInputDragDrop = [];

    this.activeDDInput;
    
    this.init(variableListFunctionPanelDS);    
    this.open = false;
}

YAHOO.Adeptra.FunctionEditor.prototype = {

	init : function(variableListFunctionPanelDS) {
	   this.variableListFunctionPanelDS = variableListFunctionPanelDS;
	   this.variableListFunctionPanelDS.responseSchema = {
		fields: [ "id", "name", "className" ]
		};
       this.initVariableListDOM();
       this.functionPanel = new YAHOO.widget.Panel("functionPanel", { width:"800px", visible:true, modal : true,underlay:"none",draggable:true,fixedcenter: true} );
       this.functionPanel.controlledClosing = false;
       var this_ = this;
       this.functionPanel.hideEvent.subscribe(function() {
           if (!this.controlledClosing)
           {
                this_.resetVariableListDOM();
                if(YAHOO.util.Dom.hasClass(this_.functionTextTarget,"variableField"))
                {
                   purgeParameterFieldClasses(this_.functionTextTarget);
                }
                if(!YAHOO.util.Dom.hasClass(this_.functionTextTarget,"general-function"))
                {
                    this_.functionTextTarget.value = "";
                    this_.functionTextTarget.setAttribute("data-raw", "");
                }
                
                
                this_.open = false;
                this_.purgeFunctionPanel();
           }
           this.controlledClosing = false;
       });
    },

    resetVariableListDOM : function() {
		var varSelect = YAHOO.util.Dom.getElementsByClassName('functionPanelDynamicList','select', this.functionPanelVariableListDOM)[0];
		varSelect.selectedIndex = 0;
        this.dynamicList(varSelect,this.functionPanelVariableListDOM);
        varSelect = YAHOO.util.Dom.getElementsByClassName('namedFunctionPanelDynamicList','select', this.namedFunctionPanelVariableListDOM)[0];
		varSelect.selectedIndex = 0;
        this.dynamicList(varSelect,this.namedFunctionPanelVariableListDOM);
	},

	showNewFunctionPanel : function (functionDesc,functionTextObj)
	{	

		this.functionInfo = null;
		this.functionTextTarget = functionTextObj;

        var customFunctionLabel = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.variablegroup.generalfunctions.namedfunction");

        if(functionDesc == customFunctionLabel)
        {
            YAHOO.util.Event.removeListener(functionTextObj, "click",
                    this.showEditFunctionPanel);
            this.showNameFunctionPanel(false);
        }
        else
        {
        	if (ruleDatums.functions[functionDesc] != undefined) 
		    {
        		 this.functionInfo = ruleDatums.functions[functionDesc];
		    }	

			YAHOO.util.Event.removeListener(functionTextObj, "click",this.showEditFunctionPanel);
			if(this.functionInfo != null)
			{
				this.showFunctionPanel(false);
			}
		}
	},

    showEditFunctionPanel : function(e)
    {
        this.functionTextTarget =  YAHOO.util.Event.getTarget(e);
    
        var functionText = this.functionTextTarget.value;
        var startParamIndex = functionText.indexOf('(');
        var functionName = functionText.substr(0, startParamIndex);
    
        // Use raw values
        var field = this.functionTextTarget.getAttribute("data-raw");
        var functionTag = "function:";
        functionName = field.substring(functionTag.length, field.indexOf("("));

        this.functionInfo = null;
        for (key in ruleDatums.functions)
        {
            if (ruleDatums.functions[key].name == functionName)
            {
                this.functionInfo = ruleDatums.functions[key];
                break;
            }
        }
        
        if (this.functionInfo == null)
        {
            return; // function no longer exists (deprecated/removed)
        }
        if (this.functionTextTarget.hiddenValue != null)
        {
            this.showNameFunctionPanel(true);
        }
        else
        {
            this.showFunctionPanel(true);
        }
    },

    restrictExpressionText: function(e)
    {
        // 37 = LEFT, 38 = UP, 39 = RIGHT, 40 = DOWN, 46 = DELETE, 8 = BACKSPC
        if(e.keyCode == 37 || e.keyCode == 38 || e.keyCode == 39 || e.keyCode == 40 || e.keyCode == 8 || e.keyCode == 46)
        {
            return;
        }

        //13 = Enter ( disallow new line feed)
        if(e.keyCode == 13)
        {
            YAHOO.util.Event.preventDefault(e);
            return;
        }

        var textArea = YAHOO.util.Event.getTarget(e);

        if(textArea.value.length >= 1000)
        {
            if(e.type == 'change')
            {
              textArea.value = textArea.value.substring(0,999);              
            }
            YAHOO.util.Event.preventDefault(e);
        }       
    },

    updateExpressionRaw: function(e)
    {
    	var textArea = YAHOO.util.Event.getTarget(e);
        textArea.setAttribute("data-raw", textArea.value);
    },
    
    getParameterValues : function(functionText)
    {
        var startParanIndex = functionText.indexOf('(');
        var endParanIndex = functionText.length-1;
        // contains the text between '(' and ')'
        var parametersClause = functionText.substring(startParanIndex+1,endParanIndex)

        var params = splitParameters(parametersClause,this.functionInfo);
		
        // check params for "null" and replace with null
        for (var i=0; i<params.length; i++)
        {
            if (params[i] == "null")
            {
                params[i] = null;
            }
        }		

        return params;
    },	
    
    showNameFunctionPanel : function(edit)
    {
            this.functionPanel.setHeader(YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.editfunction"));
            
            var divContainer = document.createElement("div");
            divContainer.id = "editFunctionContainer";
            divContainer.className="twoColumnContainer clearfix";
            var leftDiv = document.createElement("div");
            var rightDiv = document.createElement("div");
            divContainer.appendChild(leftDiv);
            divContainer.appendChild(rightDiv);
            
            leftDiv.appendChild(this.getMandatoryMessage(YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.namedfunctionmandatorymsg")));

            var errorMessageDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(errorMessageDiv,"errorMessage");
            YAHOO.util.Dom.addClass(errorMessageDiv,"noDisplay");
            leftDiv.appendChild(errorMessageDiv);

            var functionTable = document.createElement("table");
            functionTable.id = "editFunctionTable";
            leftDiv.appendChild(functionTable);
            leftDiv.id="leftDiv";
            rightDiv.appendChild(this.namedFunctionPanelVariableListDOM);
            rightDiv.id="rightDiv";
            
            var tBody = document.createElement("tbody");
            functionTable.appendChild(tBody);

            var tr = document.createElement("tr");
            tBody.appendChild(tr);
            var td1 = document.createElement("td");
            td1.style.width="5%";
            tr.appendChild(td1);
            var td2 = document.createElement("td");
            td2.style.width="15%";
            tr.appendChild(td2);
            var td3 = document.createElement("td");
            td3.style.width="60%";
            tr.appendChild(td3);
            var td4 = document.createElement("td");
            td4.style.width="10%";
            tr.appendChild(td4);
            var td5 = document.createElement("td");
            td5.style.width="10%";
            tr.appendChild(td5);

            td1.innerHTML = "*"            
            td2.innerHTML = "<strong> "+YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.functionname")+"</strong>";
            
            var functionNameFld = document.createElement("input");
            functionNameFld.type = "text";
            functionNameFld.value = "";
            functionNameFld.size = "43";
            functionNameFld.maxLength = "40";
            YAHOO.util.Dom.addClass(functionNameFld,"inputTarget");

            var parameterInputDiv = document.createElement("div");
            var autoCompleteWrapDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(autoCompleteWrapDiv,"autoCompleteWrap");
            parameterInputDiv.appendChild(autoCompleteWrapDiv);
            autoCompleteWrapDiv.appendChild(functionNameFld);
            td3.appendChild(parameterInputDiv);

            var tr = document.createElement("tr");
            tBody.appendChild(tr);            
            var td1 = document.createElement("td");
            tr.appendChild(td1);
            var td2 = document.createElement("td");
            tr.appendChild(td2);
            var td3 = document.createElement("td");
            tr.appendChild(td3);
            
            td1.innerHTML = "*"
            td2.innerHTML = "<strong> "+YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.expression")+"</strong>";

            var expressionFld = document.createElement("textArea");
            YAHOO.util.Dom.addClass(expressionFld,"inputTarget");
            YAHOO.util.Dom.addClass(expressionFld,"draggableInputTarget");
            expressionFld.rows= "8";
            expressionFld.cols= "40";
            YAHOO.util.Event.addListener(expressionFld, "keydown", this.restrictExpressionText);            
            YAHOO.util.Event.addListener(expressionFld, "change", this.restrictExpressionText);
            YAHOO.util.Event.addListener(expressionFld, "keyup", this.updateExpressionRaw);
            var parameterInputDiv = document.createElement("div");
            var autoCompleteWrapDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(autoCompleteWrapDiv,"autoCompleteWrap");
            parameterInputDiv.appendChild(autoCompleteWrapDiv);
            autoCompleteWrapDiv.appendChild(expressionFld);
            td3.appendChild(parameterInputDiv); 
            
            var emptyDiv = document.createElement("div");
            rightDiv.appendChild(emptyDiv);

            var buttonsDiv = this.buildButtons();
            rightDiv.appendChild(buttonsDiv);

            this.functionPanel.setBody(divContainer);

            var div = YAHOO.util.Dom.get("functionPanelWrap");
            if(div.firstChild)
            {
                div.removeChild(div.firstChild);
            }
            this.functionPanel.render(div);
            if(edit)
            {
                var inputTargets = [];
                inputTargets[0] = YAHOO.util.Dom.getElementsByClassName('inputTarget','input','functionPanelWrap')[0];
                inputTargets[1] = YAHOO.util.Dom.getElementsByClassName('inputTarget','textarea','functionPanelWrap')[0];

                inputTargets[0].value = this.functionTextTarget.value;
                var hiddenValue = this.functionTextTarget.hiddenValue;
                hiddenValue = hiddenValue.replace("named-function:","");
                hiddenValue = hiddenValue.replace(inputTargets[0].value+":","");
                inputTargets[1].value = hiddenValue;
            }
            this.functionPanel.show();
            this.functionPanel.cfg.setProperty("fixedcenter",false);
            this.namedFunctionPanelDDInputDragDrop("functionPanelWrap");
            this.createFunctionPanelListeners(true);
            this.open = true;
    },
    
	showFunctionPanel : function(edit)
	{  
        this.functionPanel.setHeader(YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.editfunction"));     
        
        var divContainer = document.createElement("div");
        divContainer.id = "editFunctionContainer"; 
        divContainer.className="twoColumnContainer clearfix";
        var leftDiv = document.createElement("div");
        var rightDiv = document.createElement("div");
        divContainer.appendChild(leftDiv);
        divContainer.appendChild(rightDiv);
        
        var functionTable = document.createElement("table");
        functionTable.id = "editFunctionTable";

        var colGroup = document.createElement("colgroup");
        colGroup.width="5%";
        functionTable.appendChild(colGroup);
        colGroup = document.createElement("colgroup");
        colGroup.width="20%";
        functionTable.appendChild(colGroup);
        colGroup = document.createElement("colgroup");
        colGroup.width="65%";
        functionTable.appendChild(colGroup);
        colGroup = document.createElement("colgroup");
        colGroup.width="5%";
        functionTable.appendChild(colGroup);
        colGroup = document.createElement("colgroup");
        colGroup.width="5%";
        functionTable.appendChild(colGroup);
        
        var mandatoryMessage = document.createElement("div");
        YAHOO.util.Dom.addClass(mandatoryMessage,"mandatoryMessage");
        mandatoryMessage.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.mandatorymsg");
        leftDiv.appendChild(mandatoryMessage);
                
        leftDiv.appendChild(functionTable);
        leftDiv.id="leftDiv";
        rightDiv.appendChild(this.functionPanelVariableListDOM);
        rightDiv.id="rightDiv";
        
        var tBody = document.createElement("tbody");
        functionTable.appendChild(tBody);

        var tr = document.createElement("tr");
        tBody.appendChild(tr);
        var td1 = document.createElement("td");
        tr.appendChild(td1);
        td1.innerHTML = "<strong>" + this.functionInfo.label + "</strong>";
        
        tr = document.createElement("tr");
        tBody.appendChild(tr);
        td1 = document.createElement("td");
        tr.appendChild(td1);
        td1.innerHTML = "<strong>" + "(" + "</strong>";

        for(var i=0;i<this.functionInfo.params.length;i++)
        {
            var functionParam = this.functionInfo.params[i];
            tBody.appendChild(this.createParamRow(functionTable,functionParam));
        }
               
        if(edit)
        {
            var lastParam = this.functionInfo.params[this.functionInfo.params.length-1];
            var parameterValues = this.getParameterValues(this.functionTextTarget.value);
            var rawParameterValues = this.getParameterValues(this.functionTextTarget.getAttribute("data-raw"));         
            
            if(parameterValues.length > 0)
            {
                var extraParams = parameterValues.length - this.functionInfo.params.length;
                var functionParam;
                if(this.functionInfo.params.length > 0 && this.functionInfo.params[this.functionInfo.params.length - 1].name == "..")
                {
                    functionParam = this.functionInfo.params[this.functionInfo.params.length - 1];
                }
                else
                {
                    // backwards compatibility with old function usages when function definition has reduced number of params
                    functionParam = {desc:"",name:"",optional:true,numeric:false,type:"string"};
                }

                for(var i=0;i<extraParams;i++)
                {
                    tBody.appendChild(this.createParamRow(functionTable,functionParam));
                }
                this.setParameterValues(functionTable,parameterValues, rawParameterValues);
            }
        }

        var tr = document.createElement("tr");
        var td1 = document.createElement("td");
        tr.appendChild(td1);

        td1.innerHTML = "<strong>" + ")" + "</strong>";
        
        tBody.appendChild(tr);
                
        var functionDescDiv = document.createElement("div");
        YAHOO.util.Dom.addClass(functionDescDiv,"functionDesc");
        functionDescDiv.innerHTML = this.functionInfo.description? this.functionInfo.description : this.functionInfo.desc;
        leftDiv.appendChild(functionDescDiv);

        if(this.functionInfo.returns)
        {
             //-- Return
            var returnDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(returnDiv,"functionDesc");
            returnDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.returns") + ": " + 
                this.functionInfo.returns; 
            leftDiv.appendChild(returnDiv);
        }
        
        //-- Example Text
        var exampleTextDiv = document.createElement("div");
        YAHOO.util.Dom.addClass(exampleTextDiv,"functionDesc");
        exampleTextDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.example") + ": " + 
            this.functionInfo.exampleText  + "<br/><br/>" + 
            this.functionInfo.exampleRule; 
        leftDiv.appendChild(exampleTextDiv);
        
        //-- Example Rule
/*        var exampleRuleDiv = document.createElement("div");
        YAHOO.util.Dom.addClass(exampleRuleDiv,"functionDesc");
        exampleRuleDiv.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.examplerule") + ":<br/>" + this.functionInfo.exampleRule;
        leftDiv.appendChild(exampleRuleDiv);    */
            
        var messageDiv = document.createElement("div");
        messageDiv.id = "ruleMessageFE";        
        YAHOO.util.Dom.addClass(messageDiv,"ruleMessageHidden")
        messageDiv.innerHTML = "";
        leftDiv.appendChild(messageDiv);
        
        var buttonsDiv = this.buildButtons();
        rightDiv.appendChild(buttonsDiv);
        
        this.functionPanel.setBody(divContainer);     
        
        var div = YAHOO.util.Dom.get("functionPanelWrap");
        if(div.firstChild)
        {
            div.removeChild(div.firstChild);
        }            
        this.functionPanel.render(div);

        // set the colspans now, to render correctly in IE
        functionTable.rows[0].cells[0].colSpan="5";
        functionTable.rows[1].cells[0].colSpan="5";
        functionTable.rows[functionTable.rows.length-1].cells[0].colSpan="5";

        this.functionPanel.show();
        this.open = true;

        //remove fixedcenter prop, to allow scrolling for panels larger than the window size
        this.functionPanel.cfg.setProperty("fixedcenter",false);
        initConditionAutoComplete(functionTable,this.variableListFunctionPanelDS,false);
        this.functionPanelDDInputDragDrop("functionPanelWrap");
        this.createFunctionPanelListeners();
        
        //-- set focus on first input field
        if(functionTable.rows.length > 3)
        {
            var param0 = functionTable.rows[2].getElementsByTagName("input")[0];
            param0.focus();
        } else {
        	var dynamicList = document.getElementById("functionPanelDynamicList");
        	if (dynamicList != undefined) dynamicList.focus();
        }

        // set param labels for params with no names
        this.setParameterLabels();
    },
	
    buildButtons : function()
    {    
            var buttonsDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(buttonsDiv,"floatRight");
            
            var saveButton = document.createElement("button");
            YAHOO.util.Dom.addClass(saveButton,"functionSave btn btn-fico btn-primary");
            saveButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.save")));

            var cancelButton = document.createElement("button");
            YAHOO.util.Dom.addClass(cancelButton,"functionCancel btn btn-link");
            cancelButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.cancel")));

            var deleteButton = document.createElement("button");
            YAHOO.util.Dom.addClass(deleteButton,"functionDelete btn btn-red");
            deleteButton.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.delete")));
            
            buttonsDiv.appendChild(saveButton);
            buttonsDiv.appendChild(document.createTextNode(" "));
            buttonsDiv.appendChild(cancelButton);
            buttonsDiv.appendChild(document.createTextNode("  "));
            buttonsDiv.appendChild(deleteButton);
                
            return buttonsDiv;
    },

    getMandatoryMessage : function(messageLabel)
    {
      var mandatoryMessage = document.createElement("div");
      YAHOO.util.Dom.addClass(mandatoryMessage,"mandatoryMessage");
      mandatoryMessage.innerHTML = messageLabel;
      return mandatoryMessage;
    },

    setParameterLabels : function()
    {
        var functionTable = YAHOO.util.Dom.get("editFunctionTable");
        var paramsRows = functionTable.rows;
        var labelIndex = 1;
        for(var i = 2;i<paramsRows.length-1;i++)
        {
            var paramRow = paramsRows[i];
            if(YAHOO.util.Dom.hasClass(paramRow,"noLabel"))
            {
                var labelCell = paramRow.cells[1]; 
                labelCell.innerHTML = "";
                // Non-Breaking-Space = \u00a0
                labelCell.appendChild(document.createTextNode((YAHOO.util.Dom.hasClass(paramRow,"isOptional") ? "\u00a0\u00a0" : "*") + YAHOO.Adeptra.I18NUtil.label("portal2.common.param") + " " + labelIndex));
            }
            labelIndex++;
        }
    },

	setParameterValues : function(functionTable,parameterValues,rawParameterValues)
	{
		for(var i = 0; i<parameterValues.length; i++)
		{
			 var paramInput = null;
             if(functionTable.rows[i+2].getElementsByTagName("textarea").length > 0)
             {
                paramInput = functionTable.rows[i+2].getElementsByTagName("textarea")[0];
             }
             else
             {
                paramInput = functionTable.rows[i+2].getElementsByTagName("input")[0];
             }

			 var paramValue = parameterValues[i] ? parameterValues[i].trim() : "";
			 var rawParamValue =  rawParameterValues[i] ? rawParameterValues[i].trim() : "";
			 
			 if(paramValue == null)
			 {
			 	//leave blank
			 }
			 else if(paramValue.indexOf("'") == -1 && isNaN(paramValue) && paramInput.tagName == "INPUT")
			 {				  
				YAHOO.util.Dom.addClass(paramInput,"variable");
			 }
			 else
			 {
				if(paramValue.indexOf("'") == 0 && paramInput.tagName == "INPUT")
				{
					paramValue = paramValue.substring(1,paramValue.length-1);
				}
				YAHOO.util.Dom.addClass(paramInput,"literal");				  
			 }
 		     paramInput.value = paramInput.tagName == "INPUT" ? paramValue : rawParamValue;
 		     paramInput.setAttribute("data-raw", rawParamValue);
		}
	},

	createParamRow : function(functionTable,functionParam)
	{
		var tr = document.createElement("tr");
        
        if(functionParam.optional)
        {
            YAHOO.util.Dom.addClass(tr,"isOptional");
        }
        if(functionParam.name == ".." || functionParam.name == "")
        {
            YAHOO.util.Dom.addClass(tr,"noLabel");
        }

		var td1 = document.createElement("td");
		tr.appendChild(td1);
		var td2 = document.createElement("td");
		tr.appendChild(td2);
		var td3 = document.createElement("td");
		tr.appendChild(td3);			
		var td4 = document.createElement("td");
		tr.appendChild(td4);
        var td5 = document.createElement("td");
		tr.appendChild(td5);

		td2.innerHTML = (functionParam.optional ? "&nbsp;&nbsp;" : "*") + (functionParam.name == ".." ? "" : functionParam.name);        

        var parameterInputDiv = document.createElement("div");
        
        if(functionParam.type == 'expression')
        {            
            var expressionFld = document.createElement("textArea");
            expressionFld.dataType=functionParam.type;
            YAHOO.util.Dom.addClass(expressionFld,"inputTarget");
            YAHOO.util.Dom.addClass(expressionFld,"draggableInputTarget");
            expressionFld.rows= "8";
            expressionFld.cols= "40";
            YAHOO.util.Event.addListener(expressionFld, "keydown", this.restrictExpressionText);            
            YAHOO.util.Event.addListener(expressionFld, "change", this.restrictExpressionText);
            YAHOO.util.Event.addListener(expressionFld, "keyup", this.updateExpressionRaw);
            parameterInputDiv.appendChild(expressionFld);
        }
        else
        {
            var autoCompleteWrapDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(autoCompleteWrapDiv,"autoCompleteWrap");
            var autoCompleteText = document.createElement("input");
            autoCompleteText.type="text";
            autoCompleteText.value="";
            autoCompleteText.dataType=functionParam.type;

            YAHOO.util.Dom.addClass(autoCompleteText,"draggableInputTarget");
            YAHOO.util.Event.addListener(autoCompleteText,"keyup",changeToLiteralFieldFE);            
            YAHOO.util.Event.addListener(autoCompleteText,"beforepaste",changeToLiteralField);
            autoCompleteWrapDiv.appendChild(autoCompleteText); 
            parameterInputDiv.appendChild(autoCompleteWrapDiv);           
        }

		td3.appendChild(parameterInputDiv); 

		if(functionParam.desc)
		{
			var helpLink = document.createElement("div");
            YAHOO.util.Dom.addClass(helpLink,"functionParamHelpLink");
			helpLink.innerHTML = '<img src="../common/img/iconHelp.gif"/>';
			helpLink.title = functionParam.desc;
			td4.appendChild(helpLink);
			//setTooltip(td4, functionParam.desc);
		}

		//variable arguments, create add/delete parameter buttons
		if(functionParam.name == "..")
		{
			var addButton = document.createElement("img");
			addButton.src="../common/img/iconAdd.gif";
			td5.appendChild(addButton);

			td5.appendChild(document.createTextNode(" "));

			var deleteButton = document.createElement("img");
			deleteButton.src="../common/img/iconRemove.gif";
			td5.appendChild(deleteButton);

			YAHOO.util.Event.addListener(addButton, "click", function(e) { 
																	var paramRow = this.createParamRow(functionTable,functionParam);
																	var tbody = functionTable.getElementsByTagName("tbody")[0];
																	tbody.insertBefore(paramRow,tr.nextSibling);
                                                                    this.setParameterLabels();
																	this.functionPanelDDInputDragDrop("functionPanelWrap");
																	this.initAutoCompleteForParamRow(paramRow);
															 } ,this,true);

			YAHOO.util.Event.addListener(deleteButton, "click", function(e) { 																
																if(functionTable.rows.length > 4)
																{
 																 var tbody = functionTable.getElementsByTagName("tbody")[0];
																 tbody.removeChild(tr);
                                                                 this.setParameterLabels();
																 this.functionPanelDDInputDragDrop("functionPanelWrap");
																 this.removeAutoCompleteForParamRow(tr);
																}
															 } ,this,true);

		}

		return tr;
	},

	initAutoCompleteForParamRow: function(paramRow)
	{
		var inputTarget = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', paramRow)[0];
    	initAutoComplete(inputTarget, this.variableListFunctionPanelDS, false);
	},
	
	removeAutoCompleteForParamRow: function(paramRow)
	{
	    var inputTarget = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', paramRow)[0];
		var removeIndex = null;
		for (var idx in autoCompletes)
		{
			if (typeof(autoCompletes[idx]) == "object" && autoCompletes[idx]._elTextbox == inputTarget) {
				removeIndex = idx;					
			}			
		}
		if (removeIndex != null)  autoCompletes.splice(removeIndex,1);		
	},
	
	createFunctionPanelListeners : function(namedFunction)
	{
		var saveButton = YAHOO.util.Dom.getElementsByClassName('functionSave', 'button', 'functionPanelWrap')[0];
		var cancelButton = YAHOO.util.Dom.getElementsByClassName('functionCancel', 'button', 'functionPanelWrap')[0];
		var deleteButton = YAHOO.util.Dom.getElementsByClassName('functionDelete', 'button', 'functionPanelWrap')[0];

        if(namedFunction)
        {
            YAHOO.util.Event.addListener(saveButton, "click", this.namedFunctionSave,this,true);
            YAHOO.util.Event.addListener(cancelButton, "click", this.namedFunctionCancel,this,true);
        }
        else
        {
        YAHOO.util.Event.addListener(saveButton, "click", this.functionSave,this,true);
        YAHOO.util.Event.addListener(cancelButton, "click", this.functionCancel,this,true);
        }
        YAHOO.util.Event.addListener(deleteButton, "click", this.functionDelete,this,true);
	},

    namedFunctionSave: function(e)
    {
           var inputTargets = [];
        inputTargets[0] = YAHOO.util.Dom.getElementsByClassName('inputTarget','input','functionPanelWrap')[0];
        inputTargets[1] = YAHOO.util.Dom.getElementsByClassName('inputTarget','textarea','functionPanelWrap')[0];
           var inputFieldsTable = YAHOO.util.Dom.get("editFunctionTable");

        var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName("errorMessage","div","functionPanelWrap")[0];
        errorMessageDiv.innerHTML='';
        if(!YAHOO.util.Dom.hasClass(errorMessageDiv,"noDisplay"))
        {
           YAHOO.util.Dom.addClass(errorMessageDiv,"noDisplay");
        }
           
           var bBlank = false;
        var errMsg = "";
        var errorsExist = false;
        
        for(var i=0;i<inputTargets.length;i++)
        {
             var labelCell = inputFieldsTable.rows[i].cells[0];
            labelCell.style.color = "";
              if(i==0)
               {
                if(inputTargets[i].value.indexOf(":") != -1)
                {
                    errMsg = "Name field contains invalid character ':'.";
                    errorsExist = true;
                    break;
                }
               }
            if (inputTargets[i].value == "")
            {
                bBlank = true;
                labelCell.style.color="red";     
                errMsg = YAHOO.Adeptra.I18NUtil.label(
                       "portal2.functioneditor.error.fieldsempty");
                errorsExist = true;
                break;               
            }           
        }

        if(errorsExist || bBlank)
        {
            errorMessageDiv.appendChild(document.createTextNode(errMsg));
            YAHOO.util.Dom.removeClass(errorMessageDiv,"noDisplay");
            return;
        }

        //sanitize new lines feeds
        inputTargets[1].value = inputTargets[1].value.replace(/[\r\n]/g,'');
        
        this.functionTextTarget.value = inputTargets[0].value;
        var combined = "named-function:"+inputTargets[0].value+":"+inputTargets[1].value;
        this.functionTextTarget.hiddenValue = combined;
        this.functionTextTarget.title = inputTargets[1].value;
        YAHOO.util.Event.removeListener(this.functionTextTarget, "click",
               this.showEditFunctionPanel);
        YAHOO.util.Event.addListener(this.functionTextTarget, "click",
               this.showEditFunctionPanel,this,true);
        purgeParameterFieldClasses(this.functionTextTarget);
        YAHOO.util.Dom.addClass(this.functionTextTarget,"named-function");
        this.functionPanel.controlledClosing = true;
        this.functionPanel.hide();
        this.open = false;
        this.purgeFunctionPanel();
        this.functionTextTarget.setAttribute("data-raw", combined);
   },

   functionSave : function (e)
   {
        this.resetVariableListDOM();
        
        var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', 'editFunctionContainer'); // input text fields
        inputTargets = inputTargets.concat(YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'textarea', 'editFunctionContainer')); // input text area fields

        var inputFieldsTable = YAHOO.util.Dom.get("editFunctionTable");
        
        var rawText = this.functionInfo.name + "(";
        var errorsExist = false;
        var errMsg = "";
        
        var errorMessageDiv = YAHOO.util.Dom.getElementsByClassName('errorMessageDiv', 'div', 'editFunctionContainer')[0];
        if(errorMessageDiv)
        {
           errorMessageDiv.parentNode.removeChild(errorMessageDiv);
        }
        
        var bBlank = false;
        var functionInfo = this.functionInfo;

        for(var i=0;i<inputTargets.length;i++)
        {
            var labelCell = inputFieldsTable.rows[i+2].cells[1];           
            var functionParamInfo = functionInfo.params[i] ? functionInfo.params[i] : null;            
            if(functionParamInfo == null)
            {
                if(functionInfo.params.length > 0 && functionInfo.params[functionInfo.params.length - 1].name == "..")
                {
                  functionParamInfo = functionInfo.params[functionInfo.params.length - 1];
                }
                else
                {
                  functionParamInfo = {desc:"",name:"",optional:true,numeric:false,type:"string"};
                }
            }

            if (bBlank && inputTargets[i].value != "")
            {
              errorsExist = true;
              errMsg = "Error in optional fields.";
              labelCell.style.color="red"; 	        
            }
            if (inputTargets[i].value == "")
            {
                bBlank = true;
            }

            //-- blank
            if(!functionParamInfo.optional && bBlank)
            {
              errorsExist = true;
              errMsg = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.error.fieldsempty");
              labelCell.style.color="red";    
            }
            //-- numeric
            else if(functionParamInfo.numeric && YAHOO.util.Dom.hasClass(inputTargets[i],"literal") && isNaN(inputTargets[i].value))
            {
              errorsExist = true;
              errMsg = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.error.numericfield");
              labelCell.style.color="red";
            }
            //-- disallow illegal characters for non-expression types: '
            //-- the regex allows: quoted and unquoted strings that do not contain single quotes
            else if(functionParamInfo.type != 'expression' && !/^'[^']+'$|^[^']*$/.test(inputTargets[i].value))
            {
                errorsExist = true;
                errMsg = YAHOO.Adeptra.I18NUtil.label("portal2.functioneditor.error.illegalchars");
                labelCell.style.color="red";            	
            }
            else
            {
              labelCell.style.color="black";   
            }
            bBlank = false;
        }
        
        if(errorsExist)
        {
            var errorMessageDiv = document.createElement("div");
            YAHOO.util.Dom.addClass(errorMessageDiv,"errorMessageDiv");
            errorMessageDiv.style.color="red";
            errorMessageDiv.appendChild(document.createTextNode(errMsg));
            YAHOO.util.Dom.get("leftDiv").appendChild(errorMessageDiv);
            return;
        }	
        
        var bSkip = false;
        var tranFlag = false;
        var params = [];        
        for(var i=0;i<inputTargets.length;i++)
        {
            var functionParamInfo = functionInfo.params[i] ? functionInfo.params[i] : functionInfo.params[0];
                        
            // Use raw value, fallback to main value
            var value = "";
        	if (inputTargets[i].getAttribute("data-raw") != undefined) {
            	value = inputTargets[i].getAttribute("data-raw");
                if(value == "''") {
                    value = "";
                }
            } else {
            	value = inputTargets[i].value;
            }
        	
        	///
            // Process Parameters
        	//
        	// Location (or string-literal-translated)
        	// TODO: Remove string-literal-translated
        	if (value != "" && (functionParamInfo.type == "string-literal-translated" || functionParamInfo.type == "location"))
        	{
        		params.push(value);
        	}
        	// Literal strings
        	else if(!functionParamInfo.numeric && YAHOO.util.Dom.hasClass(inputTargets[i],"literal") && 
                value != "" && value != "transactions" && 
                functionParamInfo.type != "expression" && 
                functionParamInfo.type != "variable-expression")
            {            	                
            	// Quote value if it is not a nested function call           
                if (!value.match(/^[a-zA-Z][a-zA-Z0-9_]*\(.*\).*$/))
                {	                   
                    value = "'" + value.replace(/\'/g,'') + "'";                  
                }
                params.push(value);
            }
            // Empty 
            else if(value == "")
            {
            	params.push("null");
            }
            // Other
            else
            {     
            	// Quote a numeric value in a string parameter
                if (isNumber(value) && (functionParamInfo.type == "string")) 
                {
            		value = "'" + value + "'";
            	}
                params.push(value);
            }
        }
        //
        // Remove trailing null parameters
        //
        for (var idx = params.length-1; idx >= 0; idx--) {
        	if (typeof(params[idx]) == "string") 
        	{
	            if (params[idx] == "null") 
	            {
	                params.pop();
	            } 
	            else 
	            {
	                break;
	            }
        	}
        }
        
        //
        // Raw
        //
        for (var idx in params) {
        	if (typeof(params[idx]) == "string") {	        	 
	            rawText += params[idx];
	        	if (idx < params.length-1) rawText += ",";
        	}
        }
        rawText = "function:"+rawText+")";
        
        //
        // Generate Labels
        //
        var labelText = this.functionInfo.name + "(";
        params = YAHOO.Adeptra.Labels.generateOutParameters(params);
        for (var idx in params) {
        	if (typeof(params[idx]) == "string") {	        	 
        		labelText += params[idx];        		
	        	if (idx < params.length-1) labelText += ",";
        	}
        }        
        labelText += ")";
        
        this.functionTextTarget.setAttribute("data-raw", rawText);       
        this.functionTextTarget.value = labelText;
        YAHOO.util.Event.removeListener(this.functionTextTarget, "click",this.showEditFunctionPanel);
        YAHOO.util.Event.addListener(this.functionTextTarget, "click",this.showEditFunctionPanel,this,true);
        purgeParameterFieldClasses(this.functionTextTarget);
        YAHOO.util.Dom.addClass(this.functionTextTarget,"general-function");
        this.functionPanel.controlledClosing = true;
        this.functionPanel.hide();
        this.open = false;
        this.purgeFunctionPanel();
	},

	functionDelete : function(e)
	{
		this.resetVariableListDOM();
		this.functionTextTarget.value = "";	 
		this.functionTextTarget.setAttribute("data-raw", "");
		YAHOO.util.Event.removeListener(this.functionTextTarget,"click");
		purgeParameterFieldClasses(this.functionTextTarget);
		this.functionPanel.controlledClosing = true;
		this.functionPanel.hide();
		this.open = false;
		this.purgeFunctionPanel();		
	},

	functionCancel : function (e)
	{
		this.resetVariableListDOM();
		if(YAHOO.util.Dom.hasClass(this.functionTextTarget,"variableField"))
		{
		   purgeParameterFieldClasses(this.functionTextTarget);
		}
        if(!YAHOO.util.Dom.hasClass(this.functionTextTarget,"general-function"))
        {
            this.functionTextTarget.value = "";
            this.functionTextTarget.setAttribute("data-raw", "");
        }
        this.functionPanel.controlledClosing = true;
		this.functionPanel.hide();
		this.open = false;
		this.purgeFunctionPanel();
	},

    namedFunctionCancel : function (e)
    {
        var inputTargets = YAHOO.util.Dom.getElementsByClassName(
                'draggableInputTarget', 'input', 'editFunctionContainer');
        if(!YAHOO.util.Dom.hasClass(this.functionTextTarget,"named-function"))
        {
            this.functionTextTarget.value = "";
        }
        this.functionPanel.controlledClosing = true;
        this.functionPanel.hide();
        this.open = false;
        this.purgeFunctionPanel();
    },

	purgeFunctionPanel : function ()
	{
		var div = YAHOO.util.Dom.get("functionPanelWrap");
		if(div.firstChild)
		{
			div.removeChild(div.firstChild);
		}
	},

    namedFunctionPanelDDInputDragDrop : function (rootId)
    {       
        for (var i = 0; i < this.namedFunctionPanelInputDragDrop.length; i++)
		{
			this.namedFunctionPanelInputDragDrop[i].unreg();
		}
		this.namedFunctionPanelInputDragDrop = new Array();    
        var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'textarea', rootId);
        for (var y=0; y<inputTargets.length; y++)
        {
            this.namedFunctionPanelInputDragDrop[y] = new YAHOO.util.DDTarget(inputTargets[y], 'namedfuninputs');
        }   
    },    

	functionPanelDDInputDragDrop : function (rootId)
	{
		for (var i = 0; i < this.functionPanelTargetDragDrop.length; i++)
		{
			this.functionPanelTargetDragDrop[i].unreg();
		}
		this.functionPanelTargetDragDrop = new Array();    
			
		var inputTargets = YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'input', rootId);
        inputTargets = inputTargets.concat(YAHOO.util.Dom.getElementsByClassName('draggableInputTarget', 'textarea', rootId));
		for (var y=0; y<inputTargets.length; y++)
		{
			this.functionPanelTargetDragDrop[y] = new YAHOO.util.DDTarget(inputTargets[y], 'funinputs');
		}   
	},

	initFunctionPanelDragDrop: function(e)
	{
		var elementToDragDrop = YAHOO.util.Event.getTarget(e);
	    this.activeDDInput = new DDInput(elementToDragDrop, "funinputs",
	    {
	        onDragDropHandler : function(dragValue,targetElement,srcElement)
	        {
                dragDropHandler(targetElement, srcElement.getAttribute("value"), dragValue,
                	YAHOO.util.Dom.hasClass(srcElement,'drag-variable'), YAHOO.util.Dom.hasClass(srcElement,'drag-literal'));
	        }
	    });
	},

	initNamedFunctionPanelDragDrop: function(e)
	{
		var elementToDragDrop = YAHOO.util.Event.getTarget(e);
	    this.activeDDInput = new DDInput(elementToDragDrop, "namedfuninputs",
	    {
	        onDragDropHandler : function(dragValue,targetElement,srcElement)
	        {
                var correctedValue = srcElement.getAttribute("value");
                if((index = correctedValue.indexOf(":")) != -1)
                {
                    correctedValue = correctedValue.substring(0,index) + "." + correctedValue.substring(index+1);
                }

                var cursorPosition = getCaret(targetElement);
                targetElement.value = targetElement.value.substring(0,cursorPosition) + correctedValue + targetElement.value.substring(cursorPosition);
                //sets the caret at the end of the inserted values
                setCaret(targetElement,cursorPosition+correctedValue.length);

                purgeParameterFieldClasses(targetElement);
                if(YAHOO.util.Dom.hasClass(srcElement,'drag-variable'))
                {
                   YAHOO.util.Dom.addClass(targetElement,'variable');
                }
                else if(YAHOO.util.Dom.hasClass(srcElement,'drag-literal'))
                {
                  YAHOO.util.Dom.addClass(targetElement,'literal');    
                }
            }
	    });
	},

    initVariableListDOM: function()
    {
  	   //initialize variable list with drag/drop	
       if(this.functionPanelVariableListDOM == null)
       {
	      this.functionPanelVariableListDOM = YAHOO.util.Dom.get('variableListFunctionCol').cloneNode(true);
          this.functionPanelVariableListDOM.id = null;
          var varSelect = YAHOO.util.Dom.getElementsByClassName('functionPanelDynamicList','select', this.functionPanelVariableListDOM);
	      YAHOO.util.Event.addListener(varSelect[0], 'change', this.dynamicList,this.functionPanelVariableListDOM);
       }

	   this.functionPanelVariableListDOM.style.display="block";
	   var divs = YAHOO.util.Dom.getElementsByClassName('draggableInput','div', this.functionPanelVariableListDOM);  
	          
	   for (var c = 0, i = divs.length; c < i; c += 1)
	   {
		   var elementToDragAndDrop = divs[c].firstChild;
		   YAHOO.util.Event.purgeElement(elementToDragAndDrop);
		   YAHOO.util.Event.on(elementToDragAndDrop, "mouseenter", this.initFunctionPanelDragDrop);
	   }

       if(this.namedFunctionPanelVariableListDOM == null)
       {
	      this.namedFunctionPanelVariableListDOM = YAHOO.util.Dom.get('variableListNamedFunctionCol').cloneNode(true);
          this.namedFunctionPanelVariableListDOM.id = null;
          var varSelect = YAHOO.util.Dom.getElementsByClassName('namedFunctionPanelDynamicList','select', this.namedFunctionPanelVariableListDOM);
	      YAHOO.util.Event.addListener(varSelect[0], 'change', this.dynamicList,this.namedFunctionPanelVariableListDOM);
       }

       this.namedFunctionPanelVariableListDOM.style.display="block";
       divs = YAHOO.util.Dom.getElementsByClassName('draggableInput','div', this.namedFunctionPanelVariableListDOM);  
       for (var c = 0, i = divs.length; c < i; c += 1)
       {
		   var elementToDragAndDrop = divs[c].firstChild;
		   YAHOO.util.Event.purgeElement(elementToDragAndDrop);
		   YAHOO.util.Event.on(elementToDragAndDrop, "mouseenter", this.initNamedFunctionPanelDragDrop);
       }
    },

    updateVariableListDOM : function(targetGroupId,value,label)
    {
        var optionGroupsArray = new Array();

        // function panel variable list DOM    
        optionGroupsArray.push(YAHOO.util.Dom.getElementsByClassName('optionGroup', 'div', this.functionPanelVariableListDOM));	
        // named function panel variable list DOM
        optionGroupsArray.push( YAHOO.util.Dom.getElementsByClassName('optionGroup', 'div', this.namedFunctionPanelVariableListDOM));	


        for(var j=0;j<optionGroupsArray.length;j++)
        {
            var optionGroups = optionGroupsArray[j];
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
        }
        this.initVariableListDOM();
    },

    dynamicList: function (e,rootId)
    {
        var target = YAHOO.util.Event.getTarget(e);
        var list = target == null ? e : target;
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
}