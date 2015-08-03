/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */

YAHOO.namespace("APM");

if (!YAHOO.APM.InstanceSelector) {

YAHOO.APM.InstanceSelector = function() {

    var Event = YAHOO.util.Event;
    var Dom = YAHOO.util.Dom;

    return {
        currentInstance : null,
        instanceNames : null,
 	    selectorPanel : null,
        type: null,

        init : function(currentInstance, instanceNames, type)
        {
            this.currentInstance = currentInstance;
            this.instanceNames = instanceNames;
            this.type = type;
        },

        showPanel : function()
        {
            if (!this.selectorPanel)
            {
                this.selectorPanel = new YAHOO.widget.Panel(
                    "instanceSelector",
                    { width:"520px",  fixedcenter:true, visible:true, modal : true,underlay:"none",draggable:false } );
                this.selectorPanel.setHeader(YAHOO.Adeptra.I18NUtil.label("portal2.apm.focusmenu"));
                var divContainer = document.createElement("div");
                divContainer.id = "instanceSelectorContainer";

                var divInstancesSel = document.createElement("div");
                divInstancesSel.id = "instancesSel";
                Dom.addClass(divInstancesSel,"multiselectlist");
                for(var i = 0; i < this.instanceNames.length; i++)
                {
                    var div = document.createElement("div");
                    if (this.instanceNames[i] == this.currentInstance)
                    {
                        YAHOO.util.Dom.addClass(div, 'aui-msl-selected');
                    }
                    else
                    {
                        YAHOO.util.Dom.addClass(div, 'aui-msl-normal');
                    }
                    div.value = this.instanceNames[i];
                    div.appendChild(document.createTextNode(this.instanceNames[i]));
                    divInstancesSel.appendChild(div);
                }
                this.selectorPanel.setBody(divContainer);
                divContainer.appendChild(divInstancesSel);

                var div = YAHOO.util.Dom.get("instanceSelectorWrap");
                this.selectorPanel.render(div);
                this.selectorPanel.show();
                this.createSelectorPanelListeners();
            }
            else
            {
                this.selectorPanel.show();
            }
        },

        createSelectorPanelListeners : function()
        {
            Event.addListener("instancesSel","click", this.onSelect,this,true);
            Dom.get("instancesSel").onselectstart=new Function ("return false");
        },

        onSelect : function(e,thisObj)
        {
            var elTarget = Event.getTarget(e);
            if (elTarget.value)
            {
                if(this.currentInstance == elTarget.value)
                {
                    // just hide
                    this.selectorPanel.hide();
                    return;
                }
                else
                {
                    updateInstanceFocus(elTarget.value,this.type);
                    this.selectorPanel.hide();
                }
            }
        },

        onInstanceFocusMenu : function()
        {
            YAHOO.APM.InstanceSelector.showPanel();
        }
    };
}();
}
