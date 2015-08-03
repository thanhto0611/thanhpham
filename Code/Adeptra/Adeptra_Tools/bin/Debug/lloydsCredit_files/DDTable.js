/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */
 
DDTable = function(id, sGroup, config)
{
    if (id)
    {
        this.init(id, sGroup, config);
        this.initFrame();
    }
    var i = this.getDragEl();
    var s = i.style;
    s.borderColor = "transparent";
    s.backgroundColor = "#f6f5e5";
    YAHOO.util.Dom.setStyle(i, 'opacity', 0.76);
};

YAHOO.extend(DDTable, YAHOO.util.DDProxy);

DDTable.prototype.b4MouseDown = function(e)
{
    this.setStartPosition();
    var x=YAHOO.util.Event.getPageX(e);
    var y=YAHOO.util.Event.getPageY(e);
    this.autoOffset(x,y);
    //-- fix for horiz page scroll on click when ddtable is partially off page: 
    //this.setDragElPos(x,y);
};

DDTable.prototype.startDrag = function(x, y)
{
    var dragEl = this.getDragEl();
    var clickEl = this.getEl();

    dragEl.style.border = "1px solid #cccccc";
};

DDTable.prototype.onDragEnter = function(e, id)
{
};

DDTable.prototype.onDragOut = function(e, id)
{
    /*
    var el;
    if ("string" == typeof id)
    {
        el = YAHOO.util.DDM.getElement(id);
    }
    else
    {
        el = YAHOO.util.DDM.getBestMatch(id).getEl();
    }
    el.style.backgroundColor = "";
    */
};

DDTable.prototype.onDragDrop = function(e, id)
{
    var srcEl = this.getEl();
    var destEl;
    if ("string" == typeof id)
    {
        destEl = YAHOO.util.DDM.getElement(id);
    }
    else
    {
        destEl = YAHOO.util.DDM.getBestMatch(id).getEl();
    }
    var mid = YAHOO.util.DDM.getPosY(destEl) + ( Math.floor(destEl.offsetHeight / 2));
    var moveBeforeDestEl = (YAHOO.util.Event.getPageY(e) < mid);
    var rows = YAHOO.util.Dom.getElementsByClassName('filterRow', 'tr', 'portfolioFilterTable');
    var srcPos = -1;
    var destPos = -1;
    for (var i = 0; i < rows.length; i++)
    {
        if (srcEl == rows[i])
        {
            srcPos = i;
        }
        else if (destEl == rows[i])
        {
            if (moveBeforeDestEl)
            {
                destPos = i;
            }
            else
            {
                destPos = i+1;
            }
            if (srcPos >= 0)
            {
                // moving from lower position to higher position, so
                // adjust destPos to account to removal of src
                destPos--;
            }
        }
    }
    if (srcPos != destPos)
    {
        setPriorityIntercept(srcPos, destPos, true);
        this.requestSent = true;
    }
};

DDTable.prototype.endDrag = function(e, id)
{
    if (this.requestSent)
    {
        // disable drag-drop of filter rules
        purgeFilterHandles();
    }
};

DDTable.prototype.onDragOver = function(e, id)
{
};
