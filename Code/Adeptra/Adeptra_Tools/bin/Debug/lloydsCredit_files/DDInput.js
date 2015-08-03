/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */
 
DDInput = function(id, sGroup, config) {
	this.onDragDropHandler = null;
    if (id) {
        this.init(id, sGroup, config);
        this.initFrame();
    }
	var i = this.getDragEl();
    var s = i.style;
    s.borderColor = "transparent";
    s.backgroundColor = "#f6f5e5";
	YAHOO.util.Dom.setStyle(i, 'opacity', 0.76);
    if(config && config.onDragDropHandler)
    {    	
    	this.onDragDropHandler = config.onDragDropHandler;
    }
};

YAHOO.extend(DDInput, YAHOO.util.DDProxy);

DDInput.prototype.startDrag = function(x, y) {
    var dragEl = this.getDragEl();
    var clickEl = this.getEl();
	
	dragEl.innerHTML = clickEl.innerHTML;
    dragEl.className = clickEl.className;
	dragEl.style.width = '15em';
	dragEl.style.padding = '2px';

    dragEl.style.border = "1px solid #cccccc";
};

DDInput.prototype.onDragEnter = function(e, id) {
	
};

DDInput.prototype.onDragOut = function(e, id) {
	var el;
	
	if ("string" == typeof id) {
        el = YAHOO.util.DDM.getElement(id);
    } else { 
        el = YAHOO.util.DDM.getBestMatch(id).getEl(); 
    }
	
    el.style.backgroundColor = "";
};

DDInput.prototype.getParameterForField = function(targetElement) {
	// Get parameter
	var inputParams = YAHOO.util.Dom.getElementsByClassName("draggableInputTarget", "input", YAHOO.util.Dom.get("editFunctionTable"));		
	var targetIdx = 0;
	for (var idx in inputParams) {
		if (inputParams[idx] == targetElement) {
			targetIdx = idx;
		}
	}
	
	var params = functionEditorInstance.functionInfo.params;
	var param;
			
	// Dynamic parameter length, target is a user added field, so use last param
	if (targetIdx > params.length-1) {
		param = params[params.length-1];
	} else {			
		param = params[targetIdx];
	}
	return param;
}

// Parameter 'fieldkey' is optional. If used then srcElement should be null.
DDInput.prototype.functionEditorAcceptsArgument = function(targetElement, srcElement, fieldKey) {
	
	var param = this.getParameterForField(targetElement);
			
	// Check for location type
	if (param != undefined && (param.type == "location" || param.type == "string-literal-translated")) {

		// Lookup whether src field has 'location' attribute in ruleDatums
	    var key = srcElement != null? srcElement.getAttribute('data-raw') : fieldKey;
		if(key != undefined && ruleDatums.fields[key] != undefined 
				&& ruleDatums.fields[key].location != undefined)
		{
			return true; 
		} else {
			return false;
		}
	}
	
    return true;
}

DDInput.prototype.accepts = function(dragValue,targetElement,srcElement)
{	

	// Function Editor is open
	if (functionEditorInstance.open) {
		return this.functionEditorAcceptsArgument(targetElement, srcElement);			    	
	}
	
    /*
     * If this is an APM1 instance... skip this validation
     */
    if (!isAde && !isApm2) {
    	return true;
    }
        
    var isActionExecuteSetting = this.isActionExecuteSetting(targetElement);
    
    if(YAHOO.util.Dom.hasClass(srcElement,'drag-function'))
    {
    	
        /*
         * This is a function type.
         */
        
        if (targetElement.acceptAllFunction == '1')
        {
            return true;
        }
        
        var functionInfo = null;
        for(key in ruleDatums.functions)
        {
            if(ruleDatums.functions[key].label == dragValue)
            {
                functionInfo = ruleDatums.functions[key];
                break;
            }
         }
        if (!isActionExecuteSetting && (functionInfo == null || functionInfo.returns == undefined || functionInfo.returns == ''))
        {
            /*
             * We are not allowed to use this function as is doesn't appear to return anything
             */
            return false;
        }
    } else {
    	if (isActionExecuteSetting)
    	{
    		return false;
    	}
    }
    return true;
};

DDInput.prototype.isActionExecuteSetting = function(targetElement)
{
	// Action field
	if(YAHOO.util.Dom.hasClass(targetElement,'textBoxSettingValue')) 
	{
		// DOM traversal to check if Action is set to 'execute' (value 11)		
		var row = targetElement.parentNode.parentNode.parentNode;
		var selectCell = YAHOO.util.Dom.getElementsByClassName("selectBoxCellAction", "td", row)[0];
		var actionSelect = YAHOO.util.Dom.getElementsByClassName("actionSelect", "select", selectCell)[0];
		if (actionSelect.options[actionSelect.selectedIndex].value == 11) 
		{
			return true;
		}
	}
	return false;
};

DDInput.prototype.functionEditorRejectsArgument = function(textBox) {        
    var messageText = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.locationTypeOnly");       
    showErrorMessage(messageText, textBox, true);
    textBox.value = "";
}

DDInput.prototype.onDragDrop = function(e, id) {
    var el;
    
    if ("string" == typeof id) {
        el = YAHOO.util.DDM.getElement(id);
    } else { 
        el = YAHOO.util.DDM.getBestMatch(id).getEl();
    }
    
    if(!YAHOO.util.Dom.hasClass(el,"draggableInputTarget"))
    { 
	  return;
    }
		
	var srcElement = this.getEl();
    var targetElement = el;
    var dragValue = srcElement.innerHTML;
    var accept;
	if (!this.accepts(dragValue,targetElement,srcElement))
	{
		 if (functionEditorInstance.open) {
			 this.functionEditorRejectsArgument(el);
		 } else {			
			accept = false;					    
	        messageText = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.noFunctionReturn");
	        if (this.isActionExecuteSetting(targetElement)) {
	        	messageText = YAHOO.Adeptra.I18NUtil.label("portal2.apm.portfolios.filter.executeFunctionsOnly");
	        }
	        showErrorMessage(messageText,el);
		 }
	}
	else
	{
	    if (messageTimerActive)
        {
            clearTimeout(messageTimer);
            messageTimerActive=0;
            hideMessage(true);
        }
	    accept = true;
    	attributes = { backgroundColor: {from: '#AFFFB2', to: '#ffffff' } };
    	anim = new YAHOO.util.ColorAnim(el, attributes, 1);
    	anim.animate();
	}
	
    if(this.onDragDropHandler)
    {
		if (accept)
		{
		    this.onDragDropHandler.call(this,dragValue,targetElement,srcElement);
		}
    }
	else
	{
		el.value = dragValue;
    }  
};

DDInput.prototype.endDrag = function(e, id) {
};

DDInput.prototype.onDragOver = function(e, id) {
var el;
    
    if ("string" == typeof id) {
        el = YAHOO.util.DDM.getElement(id);
    } else { 
        el = YAHOO.util.DDM.getBestMatch(id).getEl(); 
    }
    
    if(!YAHOO.util.Dom.hasClass(el,"draggableInputTarget"))
    { 
      return;
    }
    
    var srcElement = this.getEl();
    var targetElement = el;
    var dragValue = srcElement.innerHTML;
    var accept;
    if (!this.accepts(dragValue,targetElement,srcElement))
    {
        el.style.backgroundColor = "#FFAFB2";
    }
    else
    {
        el.style.backgroundColor = "#AFFFB2";
    }
};
