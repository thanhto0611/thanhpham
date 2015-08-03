/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */

YAHOO.namespace("Adeptra");

var dialogName = "dialog" + (new Date()).getTime();
var loadingdialog =  
     new YAHOO.widget.Panel("wait",     
         { width:"225px",    
           fixedcenter:true,    
           close:false,    
           draggable:false,    
           modal:true,   
           visible:false  
         }    
     );   

var _browser = detectBrowser();
var mask = null;
var JSONRequestActionSantizerMap  = new Array();

JSONRequestActionSantizerMap["rule/create.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["rule/update.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["analysis/search.action"] = "%utf8input%";
JSONRequestActionSantizerMap["admin/modifySettingName.action"] = "{utf8input-xml}";
JSONRequestActionSantizerMap["admin/createSettingName.action"] = "{utf8input-xml}";
JSONRequestActionSantizerMap["search/getAttributes.action"] = "%utf8input%";
JSONRequestActionSantizerMap["search/getAlertList.action"] = "%utf8input%{EQU}{INCLUDE-%,}"; //
JSONRequestActionSantizerMap["search/getRepeatAlertList.action"] = "%utf8input%";
JSONRequestActionSantizerMap["search/addFilterForPause.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["search/addFilterForStop.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["search/addActionForPause.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["search/addActionForStop.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["search/addActionForResume.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["search/getAllApplicationFilters.action"] = "%utf8input%";
JSONRequestActionSantizerMap["applications/saveOverlayCallWindows.action"] = "%utf8input%{AND}";
JSONRequestActionSantizerMap["applications/saveCallWindows.action"] = "%utf8input%{AND}";
JSONRequestActionSantizerMap["applications/saveStrategy.action"] = ["%utf8input%{AND}{EQU}{TILDE}", "%utf8input%{DS-EXTENDED}"];
JSONRequestActionSantizerMap["strategy/update.action"] = ["%utf8input%{AND}{EQU}", "%utf8input%{DS-EXTENDED}"];
JSONRequestActionSantizerMap["applications/saveDatasource.action"] = ["%utf8input%{AND}{INCLUDE-$}{TILDE}","%utf8input%{DS-EXTENDED}"];
JSONRequestActionSantizerMap["applications/getDatasource.action"] = ["%utf8input%{AND}{INCLUDE-$}{TILDE}","%utf8input%{DS-EXTENDED}"];
JSONRequestActionSantizerMap["reports/generateReport.action"] = "%utf8input%{EQU}{PERCENT}";
JSONRequestActionSantizerMap["reports/addScheduledReport.action"] = "%utf8input%{EQU}{PERCENT}";
JSONRequestActionSantizerMap["applications/demoalert/saveAlertSettings.action"] = "{utf8input-xml}{PLUS}{TILDE}";
JSONRequestActionSantizerMap["scheduledreports/editScheduledReport.action"] = "%utf8input%{EQU}";
JSONRequestActionSantizerMap["strategyset/rename.action"] = "{utf8input}{PUNC-LIMITED}{EQU}";
JSONRequestActionSantizerMap["filters/removefilter.action"] = "%utf8input%{EQU}{INCLUDE-%,}";
JSONRequestActionSantizerMap["fraudstop/save.action"] = ["%utf8input%{AND}"];
JSONRequestActionSantizerMap["agent/ExecuteTests.action"] = "%utf8input%{EQU}{PERCENT}";
JSONRequestActionSantizerMap["optinmanager/create.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["webcollect/create.action"] = "{utf8input}{PUNC-LIMITED}{EQU}";
JSONRequestActionSantizerMap["optinmanager/update.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["users/create.action"] = "%utf8input%{EQU}{INCLUDE-%,'}";
JSONRequestActionSantizerMap["users/createMultiple.action"] = "%utf8input%{EQU}{INCLUDE-%,'}";
JSONRequestActionSantizerMap["users/update.action"] = "%utf8input%{EQU}{INCLUDE-%,'}";
JSONRequestActionSantizerMap["users/resetPassword.action"] = "{username}";
JSONRequestActionSantizerMap["users/getUserDetails.action"] = "{username}";
JSONRequestActionSantizerMap["users/lockAccount.action"] = "{username}";
JSONRequestActionSantizerMap["users/unlockAccount.action"] = "{username}";
JSONRequestActionSantizerMap["users/searchUsers.action"] = "{username}";
JSONRequestActionSantizerMap["users/getUserDetails.action"] = "{username}";
JSONRequestActionSantizerMap["webcollect/createCard.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["webcollect/createBank.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["webcollect/agreeWithNewCard.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["webcollect/agreeWithNewBank.action"] = "{utf8input-js-cond-epxr{include%}}";
JSONRequestActionSantizerMap["resultMap/resetTemplate.action"] = "{username}";
JSONRequestActionSantizerMap["resultMap/saveEditedEntry.action"] = "%utf8input%{EQU}{INCLUDE-%,'}";
JSONRequestActionSantizerMap["resultMap/saveNewElements.action"] = "%utf8input%{EQU}{INCLUDE-%,'}";
JSONRequestActionSantizerMap["resultMap/setRank.action"] = "{numeric}";
JSONRequestActionSantizerMap["resultMap/updateCurrentTemplate.action"] = "{numeric}";

YAHOO.Adeptra.Sanitizer = function() {
    this.namedPatterns = null;
    this.namedPatternBlacklists = null;
    this.defaultPattern = "^[a-zA-Z0-9 :_@/\\-\\s\\,\\.\\[\\]\\(\\)\\*\\|\\u0080-\\uffff]*$";
    this.defaultPatternBlacklist = "!\"#$%&'+;<=>?\^`{}~";
};

YAHOO.Adeptra.Sanitizer.prototype = {

    init : function(namedPatterns, namedPatternBlacklists) {
        this.namedPatterns = namedPatterns;
        this.namedPatternBlacklists = namedPatternBlacklists;
    },

    sanitize : function(postData,pattern,showErrorMessage) {
        if(postData==null)
        {
            return true;
        }
    	
    	var regex = null;
            var blacklist = null;
    	var validChars = true;
            if (this.namedPatterns != null)
            {
                regex = this.namedPatterns[pattern];
                blacklist = this.namedPatternBlacklists[pattern];
                if (regex == null)
                {
                    regex = this.defaultPattern;
                    blacklist = this.defaultPatternBlacklist;
                }
            }
    	var regexpression = new RegExp(regex);
    	
    	if(typeof(postData) == "string")
    	{
    		var paramMap = postData.split("&");
    		for(var i=0;i<paramMap.length;i++)
    		{
    			var arr = paramMap[i].split("=");
    			if(arr[0] == "password" || arr[0] == "newPassword" || arr[0] == "confirmNewPassword")
    			{
    					//no need for sanitization
    					continue;
    			}
    
    			if(arr[1] != null)
    			{
    					var matches = arr[1].match(regexpression);
    					//string.match returns an array of matches or null. first match should be the same as the input string
    					if(matches == null || !(matches[0].length == arr[1].length))
    					{
    							validChars = false;
    							break;
    					}
    			}
            }
        }
        else
        {
            for(var i=0;i<postData.length;i++)
            {
    			if(postData[i].key == "password" || postData[i].key == "newPassword" || postData[i].key == "confirmNewPassword")
    			{
    					//no need for sanitization
    					continue;
    			}
    			if(postData[i].value != null)
    			{				
    					//convert value to string by appending ''
    					var matches = (postData[i].value+'').match(regexpression);
    					//string.match returns an array of matches or null. first match should be the same as the input string
    					if(matches == null || !(matches[0].length == (postData[i].value + '').length))
    					{
    							validChars = false;
    							break;
    					}
    			}
            }
        }
    
    	
    	if(!validChars && showErrorMessage) 
    	{
    	    var message = YAHOO.Adeptra.I18NUtil.label("portal2.common.error.unsupportedchars") + "<br><br>";
                message += this.insertSpace(blacklist);
    	    showMessage(message,null,{width:"60em"});
    	}
    	
    	return validChars;
        },
    	
        insertSpace : function(str) {
    	var returnStr = "";
            var i=0;
    	for(i=0; i<str.length;i++)
    	{
                returnStr += str.charAt(i) + " ";
    	}
    	return returnStr;
        }
};

var SanitizerInstance = new YAHOO.Adeptra.Sanitizer();

YAHOO.Adeptra.Common = {
   purgeChildren : function(elm)
   {
	   while(elm.hasChildNodes()){
		   elm.removeChild(elm.lastChild);
	   }
   },
   escapeHtml : function (dirtyString) {
       return dirtyString.toString()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
   },
   createNullElement : function() 
   {
	   var nullElm = document.createElement("i");
	   nullElm.appendChild(document.createTextNode("null"));
	   return nullElm;
   },

   strategyDetailsLink : function(strategy, img, altText)
   {
		var action = null;
		// TODO: check type flag to determine if it is a strategyset
		if (strategy.createdBy)
		{
			action = 'StrategyDetails.action';
		}
		else
		{
			action = 'StrategySetDetails.action';
		}

		
		return this.apmModelLink(action+"?instanceName=" + this.escapeHtml(_instanceName) + "&strategy.id=", strategy, img, altText);
	},

	portfolioDetailsLink : function(portfolio, img, altText)
	{
		return this.apmModelLink("PortfolioDetails.action?instanceName=" + this.escapeHtml(_instanceName) + "&portfolio.id=", portfolio, img, altText);
	},

	callWindowDetailsLink : function(callWindow, img, altText)
    {
        return this.apmModelLink("CallWindowDetails.action?instanceName=" + this.escapeHtml(_instanceName) + "&callWindow.id=", callWindow, img, altText);   
    },

	apmModelLink : function(href, obj, img, altText)
	{
	    var anchor = document.createElement("a");
		if (obj && typeof(obj.id) == 'number')
		{
			anchor.href = href + this.escapeHtml(obj.id);

			if (img)
			{
				var imgElm = document.createElement("img");
                imgElm.src = "../common/img/" + img;
				
				if (altText)
				{
					imgElm.alt = this.escapeHtml(altText);
					imgElm.title = this.escapeHtml(altText);
				}
				anchor.appendChild(imgElm);
			}
			else
			{
				anchor.appendChild(document.createTextNode(obj.name));
			}
			return anchor;
		}
		return null;
	},

    insertValueWithNewLineToElement : function(element,index,str)
	{
		if ( index == 0 )
		{
			element.appendChild(document.createTextNode(str));
			return;
		}

		if ( str.length <= index )
		{
			element.appendChild(document.createTextNode(str));
			return;
		}

		var strset = str.split(""); 
		for ( var i=0; i < strset.length; i++ )
		{
			element.appendChild(document.createTextNode(strset[i]));
			if ( (i+1) % index == 0 )
			{
				element.appendChild(document.createElement("br"));
			}
		}
	}, 
	
    breakAndWrap : function(element,len,str)
    {         
        if ( !str || str.length==0 )
        {
            element.appendChild(document.createTextNode(""));
            return;
        }   
        if ( !len || len==0 || str.length<=len )
        {
            element.appendChild(document.createTextNode(str));
            return;
        }
        
        var strset = str.split("\n");
        for (var i=0; i<strset.length; i++)
        {
            var strwords = strset[i].split(" ");
            var strtmp = "";
            for (var j=0; j<strwords.length; j++)
            {
                // insert missing space
                strwords[j] = strwords[j] + " ";
                //-- next word too long
                if (strwords[j].length > len)
                {
                    var nextPc = strwords[j].slice(0,(len - strtmp.length));
                    strtmp += nextPc;

                    if(strtmp.length > 0)
                    {
                        element.appendChild(document.createTextNode(strtmp));                    
                        strtmp = "";
                        element.appendChild(document.createElement("br"));
                    }
                    
                    var lenNextPc = nextPc.length;
                    var remainingPc = strwords[j].slice(lenNextPc);                
                    var newAry = this.splitEveryNth(len, remainingPc);
                    for (var k=0; k<newAry.length; k++)
                    {
                        if (newAry[k].length < len)
                        {
                            strtmp = newAry[k];                            
                        }
                        else
                        {
                            element.appendChild(document.createTextNode(newAry[k]));                    
                            element.appendChild(document.createElement("br"));
                        }
                    }
                }
                //-- concat too long
                else if (strtmp.length + strwords[j].length >= len)
                {
                    if(strtmp.length > 0)
                    {
                        element.appendChild(document.createTextNode(strtmp)); 
                        strtmp = "";
                        element.appendChild(document.createElement("br"));
                    }
                    strtmp = strwords[j]
                }
                //-- concat next word 
                else if (strtmp.length + strwords[j].length <= len)
                {
                    strtmp += strwords[j];
                }
            }
            if(strtmp.length > 0)
            {
                element.appendChild(document.createTextNode(strtmp));
                strtmp="";
                element.appendChild(document.createElement("br"));
            }
        }
    },

    splitEveryNth : function(len,str)
    {
        var retArray = [];
        var newstr = str;
        while (newstr.length > 0)
        {
            var nextSlice = newstr.slice(0,len);
            retArray.push(nextSlice);
            newstr = newstr.slice(len);
        }                
        return retArray;    
    },
	
	contains : function(array,value)
	{
		for(var i=0;i<array.length;i++)
		{
			if(array[i] == value)
			{
				return true;
			}
		}
		return false;
    }	
};

YAHOO.Adeptra.ProgressIndicator = function() {
	this.id = "progressIndicatorMask";
	this.mask = null;
	this.noOfRequests = 0;
	this.progressGifDiv = null;
	this.iframe = null;
};

YAHOO.Adeptra.ProgressIndicator.prototype = {

	init : function() {
		if (!this.iframe) {
			this.iframe = document.createElement("iframe");
			this.iframe.src = "javascript:false;";

			document.body.appendChild(this.iframe);

			YAHOO.util.Dom.setStyle(this.iframe, "position", "absolute");
			YAHOO.util.Dom.setStyle(this.iframe, "border", "none");
			YAHOO.util.Dom.setStyle(this.iframe, "margin", "0");
			YAHOO.util.Dom.setStyle(this.iframe, "padding", "0");
			YAHOO.util.Dom.setStyle(this.iframe, "opacity", "0");
			YAHOO.util.Dom.setStyle(this.iframe, "top", "0");
			YAHOO.util.Dom.setStyle(this.iframe, "left", "0");
			YAHOO.util.Dom.setStyle(this.iframe, "display", "none");
		}

	    if (!this.mask) 
		{
			this.mask = document.createElement("div");
			this.mask.id = this.id + "_mask";
			this.mask.className = "progressIndicatorMask";
			this.mask.innerHTML = "&#160;";

			var maskClick = function(e, obj) 
			{
				YAHOO.util.Event.stopEvent(e);
			};

			var firstChild = document.body.firstChild;
			if (firstChild)	
			{
				document.body.insertBefore(this.mask,document.body.firstChild);
			} 
			else 
			{
				document.body.appendChild(this.mask);
			}
		}

        if (!this.progressGifDiv)
        {
    		this.progressGifDiv = document.createElement("div");
    		var gif = document.createElement("img");
            gif.src = "../common/img/ajax-loader.gif";
    		this.progressGifDiv.appendChild(gif);
    		this.progressGifDiv.className = "progressIndicator";
    
    		this.mask.appendChild(this.progressGifDiv);
    		YAHOO.util.Event.addListener(window,"resize",this.resizeReposition,this,true);
    		YAHOO.util.Event.addListener(window,"scroll",this.resizeReposition,this,true);
        }
	},

	leftBottomAlign : function() {
		var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft;
		var scrollY = document.documentElement.scrollTop || document.body.scrollTop;

		var viewPortWidth = YAHOO.util.Dom.getClientWidth();
		var viewPortHeight = YAHOO.util.Dom.getClientHeight();

		var elementWidth = this.progressGifDiv.style.width;
		var elementHeight = this.progressGifDiv.style.height;

		var x = (viewPortWidth  - elementWidth) + scrollX;
		var y = (viewPortHeight - elementHeight) + scrollY;

		//this.progressGifDiv.style.left = x-elementWidth + "px";
		this.progressGifDiv.style.left = "10px";

        //this.progressGifDiv.style.top = y-elementHeight + "px";
		this.progressGifDiv.style.top = (y - 70) + "px";
	},

	resizeReposition : function() {
         this.sizeMask();
		 this.sizeIFrame();
		 this.leftBottomAlign();
	},

	showMask : function() {
		if (this.mask) {
			this.sizeMask();
			this.mask.style.display = "block";
		}
	},

	showIFrame : function() {
		if (this.iframe) {			
			this.sizeIFrame();
			this.iframe.style.display = "block";
		}
	},

	hideMask : function() {
		if (this.mask) {
			this.mask.style.display = "none";
		}
	},

	hideIFrame : function() {
		if (this.iframe) {
			this.iframe.style.display = "none";
		}
	},

    sizeMask : function() {
		if (this.mask) {
			YAHOO.util.Dom.setStyle(this.mask, "width", YAHOO.util.Dom.getDocumentWidth()+"px");
			YAHOO.util.Dom.setStyle(this.mask, "height",  YAHOO.util.Dom.getDocumentHeight()+"px");
		}
    },

    sizeIFrame : function() {
		if (this.iframe) {
			YAHOO.util.Dom.setStyle(this.iframe, "width", YAHOO.util.Dom.getDocumentWidth()+"px");
			YAHOO.util.Dom.setStyle(this.iframe, "height",  YAHOO.util.Dom.getDocumentHeight()+"px");
		}
    },

    sizeProgress : function() {
		this.sizeIFrame();
		this.sizeMask();
	},

    showProgress : function() {
		if(this.noOfRequests == 0) {
		  this.leftBottomAlign();
		  this.showMask();
          this.showIFrame(); 
	    }
		this.noOfRequests++;
	},     

	hideProgress : function() {
	    if(this.noOfRequests > 0) 
	    {
	        this.noOfRequests--;
	    }
		if(this.noOfRequests < 1) {
		  this.hideMask();
		  this.hideIFrame();
		}
	}	
};

var piInstance = new YAHOO.Adeptra.ProgressIndicator();

YAHOO.Adeptra.I18NUtil = {

	i18NProperties : null,
	userLocale : null,
	imgSuffix : null,
	dateFormatSymbols : null,
	userTimeZone : null,
	userDateFormat : null,
	userTimeFormat : null,
	userDateTimeFormat : null,

	init : function(userLocale,userTimeZone,userDateTimeFormat,imageSuff,dateFormatSymbols) {
	  this.i18NProperties = new Array();
	  this.userLocale = userLocale;
	  this.userTimeZone = userTimeZone;		  
	  if(userDateTimeFormat)
	  {
	    var dateTimeFormat = userDateTimeFormat.split("|");
	    this.userDateFormat = dateTimeFormat[0];
	    this.userTimeFormat = dateTimeFormat[1];
	    this.userDateTimeFormat = this.userDateFormat + " " + this.userTimeFormat;
	  }
	  
	  
	  this.imgSuffix = imageSuff;
	  this.dateFormatSymbols = dateFormatSymbols;
	    
	},

	setProperty : function(key,value) {
		this.i18NProperties[key] = value;
	},

	label : function(key) {
		return (this.i18NProperties && this.i18NProperties[key]) 
		? this.i18NProperties[key] : "<UNDEFINED>";
	},

	labelFormat : function(key,args) {
		var message = this.i18NProperties ? this.i18NProperties[key] : null;
		if(message)
		{
			for(var i=0;i<args.length;i++)
			{
				message = message.replace(new RegExp("\\{" + i + "\\}","gi"),args[i]);
			}
			return message;
		}
		return "<UNDEFINED>";
	},
	
	getDateFormatSymbols : function() {
	   return this.dateFormatSymbols;
	},

	imageSuffix : function() {
		return this.imgSuffix;
	},
	
	getUserTimeZone : function() {
	    return this.userTimeZone;
	},
	
	getUserDateFormat : function() {
            //temp fix. always use dd-NNN-yyyy until all user locales are configured in LDAP
            return "dd-NNN-yyyy";
	    //return this.userDateFormat;
	},
	
	getUserTimeFormat : function() {
	    return this.userTimeFormat;
	},
	
	getUserDateTimeFormat : function() {
	    //temp fix. always use dd-NNN-yyyy until all user locales are configured in LDAP
            return "dd-NNN-yyyy HH:mm:ss";
	    //return this.userDateTimeFormat;
	}
}

YAHOO.Adeptra.DateUtils = {
   timezoneDateTimeFormatMap : null,
   currentDate : new Date(),
   DEFAULT_DATE_FORMAT : "dd-NNN-yyyy",
   DEFAULT_TIME_FORMAT : "HH:mm:ss",

   init : function(timezoneDateTimeFormatMap,dateFormatSymbols,currentDateComponents) {
       if(currentDateComponents != null)
       {
        this.currentDate = new Date(currentDateComponents.YEAR,currentDateComponents.MONTH,        
         currentDateComponents.DAY_OF_MONTH,currentDateComponents.HOUR_OF_DAY,currentDateComponents.MINUTE,
         currentDateComponents.SECOND,currentDateComponents.MILLISECOND);
       }
       this.timezoneDateTimeFormatMap = timezoneDateTimeFormatMap;
       //init date symbols for date validation script (date.js)
	   if(typeof date_dateSymbolsInit == "function")
	   {
		 date_dateSymbolsInit(dateFormatSymbols);
	   }
   },
   
   getDateFormat : function(timeZone) {
       var dateTimeFormat = this.timezoneDateTimeFormatMap[timeZone];
       if(dateTimeFormat)
       {
         return dateTimeFormat.split("|")[0];
       }
       return this.DEFAULT_DATE_FORMAT;
   },
   
   getTimeFormat : function(timeZone) {
       var dateTimeFormat = this.timezoneDateTimeFormatMap[timeZone];
       if(dateTimeFormat)
       {
         return dateTimeFormat.split("|")[1];
       }
       return this.DEFAULT_TIME_FORMAT;
   },
   
   getDateTimeFormat : function(timeZone) {
       var dateTimeFormat = this.timezoneDateTimeFormatMap[timeZone];
       if(dateTimeFormat)
       {
		 var arr = dateTimeFormat.split("|");
         return arr[0] + " " + arr[1];
       }
       return this.DEFAULT_DATE_FORMAT + " " + this.DEFAULT_TIME_FORMAT;
   },
   
   formatDate : function(date,format,formatAsLocal) {
      //delegate to date.js
      return date_formatDate(date,format,formatAsLocal);
   },
   
   getDateFromFormat : function(val,format) {
      //delegate to date.js
      return date_getDateFromFormat(val,format);
   },
   
   isDate : function(val,format) {
      //delegate to date.js
      return date_isDate(val,format);
   },
   
   getCalendar : function(id,containerId,config,calendarDateTime) {
        var dateFormatSymbols = YAHOO.Adeptra.I18NUtil.getDateFormatSymbols();
   		var cal = calendarDateTime ?  new YAHOO.Adeptra.CalendarDateTime(id, containerId , config) : new YAHOO.widget.Calendar(id, containerId , config);
   		cal.cfg.setProperty("MONTHS_SHORT",   dateFormatSymbols.shortMonths); 
		cal.cfg.setProperty("MONTHS_LONG",    dateFormatSymbols.months); 
		cal.cfg.setProperty("WEEKDAYS_SHORT", dateFormatSymbols.shortWeekdays); 
		cal.cfg.setProperty("WEEKDAYS_LONG",  dateFormatSymbols.weekdays); 
		cal.select(this.getCurrentDate());
   		return cal;
   },
   
   getCurrentDate : function() {
        return new Date(this.currentDate.getTime());
   }
}

YAHOO.Adeptra.SortUtils = {
    sort : function(array,config) 
	{
	   var len = array.length;
	   var compare = null;
	   
	   if(config.compare)
	   {
	     compare = config.compare;
	   }
	   else
	   {
	     compare = this.compare;
	   }
	   
       for(var i=0;i<len-1;i++)
	   {
          for(var j=0;j<len-(i+1);j++)
		  {
		    if(compare.call(this,array[j],array[j+1]) > 0)
			{
			  var temp = array[j];
              array[j] = array[j+1];
              array[j+1] = temp;
			}
		  }
	   }
	   
	   if(config.sortOrder && config.sortOrder == "desc")
	   {
	     array.reverse();
	   }
    },

	compare : function(a,b) 
	{ 
	    if(a==null || a=="") return 1;
		if(b==null || b=="") return -1;
		
		if(typeof(a) == "string") a = a.toLowerCase();
		if(typeof(b) == "string") b = b.toLowerCase();
		
		if(a < b) return -1;
		if (a > b) return 1;
		
		return 0;		
    }
};


var JSONRequest = {

    evalResponse:function(o)
    {
        var result = null;
        try
        {
          result = jQuery.parseJSON(o.responseText);
        }
        catch(e)
        {
          //ignore
          //invalid result...return null result
        }
        return result;
    },

    hasActionErrors:function(json)
    {
        if (json.actionErrors) {
            for (var msg in json.actionErrors) {
                return true;
            }
        }
        return false;
    },

    hasFieldErrors:function(json)
    {
        if (json.fieldErrors) {
            for (var msg in json.fieldErrors) {
                return true;
            }
        }
        return false;
    },

    handleUpload:function(o)
    {
    	loadingdialog.hide();
    	var callback = o.argument;
        if (callback.scope)
            {
                callback.upload.call(callback.scope, o);
            }
            else
            {
                callback.upload(o);
            }
		piInstance.hideProgress();
    },

    handleSuccess:function(o)
    {
    	loadingdialog.hide();
        var result = this.evalResponse(o);
        if (result == null) {
            this.handleFailure(o);
            return;
        }
        var callback = o.argument;
        if (result.result != "success" ||
            this.hasActionErrors(result) ||
            this.hasFieldErrors(result))
        {
            if (callback.scope)
            {
                callback.error.call(callback.scope, result);
            }
            else
            {
                callback.error(result);
            }
        } else {
            if (callback.scope)
            {
                callback.success.call(callback.scope, result);
            }
            else
            {
                callback.success(result);
            }
        } 
		piInstance.hideProgress();
    },

    handleFailure:function(o)
    {
    	loadingdialog.hide();
		
    	if(o.status != 0) 
    	{
            if(o.status == 401)
            {
                showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.unauthorizedactionerror"));
            }
            else
            {
                var callback = o.argument;
                if (callback.scope)
                {
                    callback.failure.call(callback.scope, o);
                }
                else
                {
                    callback.failure(o);
                }
            }
	    }    
		piInstance.hideProgress();
    },
    
    getFormParameters : function(formId,isUpload) {
        var formData = new Array();
       	if(typeof formId == 'string')
       	{
		// Determine if the argument is a form id or a form name.
		// Note form name usage is deprecated by supported
		// here for legacy reasons.
		    oForm = (document.getElementById(formId) || document.forms[formId]);
		}
		else if(typeof formId == 'object')
		{
			// Treat argument as an HTML form object.
			oForm = formId;
		}
		else 
		{
			return;
		}

		var oElement, oName, oValue, oDisabled;
		var hasSubmit = false;

		// Iterate over the form elements collection to construct the
		// label-value pairs.
		for (var i=0; i<oForm.elements.length; i++){
			oElement = oForm.elements[i];
			oDisabled = oForm.elements[i].disabled;
			oName = oForm.elements[i].name;
			oValue = oForm.elements[i].value;

			// Do not submit fields that are disabled or
			// do not have a name attribute value.
			if(!oDisabled && oName)
			{
				switch (oElement.type)
				{
					case 'select-one':
					case 'select-multiple':
						for(var j=0; j<oElement.options.length; j++){
							if(oElement.options[j].selected){
								if(window.ActiveXObject){
									formData.push({key:oName,value:oElement.options[j].attributes['value'].specified?oElement.options[j].value:oElement.options[j].text});
								}
								else{
									formData.push({key:oName,value:oElement.options[j].hasAttribute('value')?oElement.options[j].value:oElement.options[j].text});
								}

							}
						}
						break;
					case 'radio':
					case 'checkbox':
						if(oElement.checked){
							formData.push({key:oName,value:oValue});
						}
						break;
					case 'file':
						// stub case as XMLHttpRequest will only send the file path as a string.
					case undefined:
						// stub case for fieldset element which returns undefined.
					case 'reset':
						// stub case for input type reset button.
					case 'button':
						// stub case for input type button elements.
						break;
					case 'submit':
						if(hasSubmit == false){
							formData.push({key:oName,value:oValue});
							hasSubmit = true;
						}
						break;
					default:
						formData.push({key:oName,value:oValue});
						break;
				}
			}
		}
		return formData;
    },

    postForm:function(uri, form, callback,sanitizerPatternIndex)
    {
        var postData = this.getFormParameters(form);
		var sanitizerPattern = sanitizerPatternIndex?JSONRequestActionSantizerMap[uri][sanitizerPatternIndex]:JSONRequestActionSantizerMap[uri];

        if(!SanitizerInstance.sanitize(postData,sanitizerPattern,true))
		{
		  return false;
		}

		YAHOO.util.Connect.setForm(form);
        YAHOO.util.Connect.setDefaultPostHeader(true);
        JSONRequest.sendRequest(
            uri,
            null,
            callback);
        return true;
    },
	
    sendMapRequest:function(uri, mapData, callback, skipSanitization,showProgressIndicator,sanitizerPatternIndex, ignoreStatusPanel) 
    {
        var data = "";

        if (!skipSanitization)
        {
            var sanitizerPattern = typeof(sanitizerPatternIndex) === 'undefined' ? JSONRequestActionSantizerMap[uri]
                    : JSONRequestActionSantizerMap[uri][sanitizerPatternIndex];
            if (!SanitizerInstance.sanitize(mapData, sanitizerPattern, true))
            {
                return false;
            }
        }

        for ( var i in mapData)
        {
            if (data.length)
            {
                data += "&";
            }
            var key = mapData[i].key;
            var value = mapData[i].value;
            if (key)
            {
                data += encodeURIComponent(key) + "="
                        + (value != null ? encodeURIComponent(value) : "");
            }
        }
        JSONRequest.sendRequestEncoded(uri, data, callback,
                showProgressIndicator, ignoreStatusPanel);
        return true;
    },
    
    sendRequest:function(uri, data, callback,showProgressIndicator,sanitizerPatternIndex)
    {
		var sanitizerPattern = sanitizerPatternIndex?JSONRequestActionSantizerMap[uri][sanitizerPatternIndex]:JSONRequestActionSantizerMap[uri];
        if(!SanitizerInstance.sanitize(data,sanitizerPattern,true))
		{
		  return false;
		}
		
        if (data)
        {
            data = encodeURI(data);
        }
        JSONRequest.sendRequestEncoded(uri, data, callback,showProgressIndicator);
        return true;
    },

    sendRequestEncoded:function(uri, data, callback,showProgressIndicator, ignoreStatusPanel)
    {
    	var actionArray = uri.split("/");
    	var actionName = actionArray[actionArray.length-1].split(".")[0];
    	if ( actionName == "create" &&
    	        (ignoreStatusPanel == null || ignoreStatusPanel == false))
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.creating"));
    	}
    	else if ( actionName == "delete" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.deleting"));
    	}
    	else if ( actionName == "deleteRule" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.deleting"));
    	}
    	else if ( actionName == "update" && 
    	        (ignoreStatusPanel == null || ignoreStatusPanel == false))
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.updating"));
    	}   
    	else if ( actionName == "rename" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.renaming"));
    	}    	 	
		else if ( actionName == "newfilter" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.creating"));
    	}
		else if ( actionName == "removefilter" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.deleting"));
    	}
		else if ( actionName == "saveStrategy" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}    	
		else if ( actionName == "saveDatasource" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}   
		else if ( actionName == "saveCallWindows" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}   
		else if ( actionName == "saveOverlayCallWindows" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}       	    	    	    	
		else if ( actionName == "addSelectedFiles" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.adding"));
    	}    
		else if ( actionName == "addAllFiles" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.adding"));
    	}    
		else if ( actionName == "deleteFile" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.deleting"));
    	}        	    	
		else if ( actionName == "submitpassword" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}   
		else if ( actionName == "submitsettings" )
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));
    	}
    	else if(actionName == "saveAlertSettings")
    	{
    		showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving"));	
    	}
    	else if(actionName == "update" || actionName == "create" || actionName == "createMultiple")
        {
            showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.saving")); 
        }
        else if(actionName == "unlockAccount")
        {
            showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.uap.account.unlocking")); 
        }
        else if(actionName == "lockAccount")
        {
            showUpdatingMessage(YAHOO.Adeptra.I18NUtil.label("portal2.uap.account.locking")); 
        }
		else if(typeof showProgressIndicator == 'undefined' || showProgressIndicator == true)
		{
		    piInstance.init();
		    piInstance.showProgress();
		}

        var randomRequestEl = document.getElementById('randomRequestStr');
        if (randomRequestEl)
        {
            var randomRequestStr = randomRequestEl.value
            if (randomRequestStr && randomRequestStr.length > 0)
            {
                if (data)
                {
                    data += '&';
                }
                else
                {
                    data = '';
                }
                data += 'randomRequestCheckStr=' + randomRequestStr;
            }
            //alert(data);
        }

        //add ajax=true marker for every request
		var extraParams = "ajax=true";
		if(uri.indexOf("instanceName=") == -1 && typeof(_instanceName) != 'undefined')
		{
			//append instance name for ade and apm requests	(i.e: if _instanceName global variable exists)
			extraParams += "&instanceName=" + _instanceName;
		}
       
        YAHOO.util.Connect.asyncRequest(
            "POST",
            uri + (uri.indexOf("?") != -1 ? "&" : "?") + extraParams,
            {
                success:JSONRequest.handleSuccess,
                failure:JSONRequest.handleFailure,
                upload:JSONRequest.handleUpload,
                scope:JSONRequest,
                argument:callback
            },
            data);
    }
};

/**
 * A YAHOO panel which is resizable.
**/
YAHOO.Adeptra.ResizePanel = function(el, userConfig) { 
			if (arguments.length > 0) { 
				YAHOO.Adeptra.ResizePanel.superclass.constructor.call(this, el, userConfig); 
			} 
};

YAHOO.extend(YAHOO.Adeptra.ResizePanel, YAHOO.widget.Panel); 

YAHOO.Adeptra.ResizePanel.CSS_PANEL_RESIZE = "resizepanel";
YAHOO.Adeptra.ResizePanel.CSS_RESIZE_HANDLE = "resizehandle";

YAHOO.Adeptra.ResizePanel.prototype.init = function(el, userConfig) {

	YAHOO.Adeptra.ResizePanel.superclass.init.call(this, el);
	this.beforeInitEvent.fire(YAHOO.Adeptra.ResizePanel);

	YAHOO.util.Dom.addClass(this.innerElement, YAHOO.Adeptra.ResizePanel.CSS_PANEL_RESIZE);

	this.resizeHandle = document.createElement("div");
	this.resizeHandle.id = this.id + "_r";
	this.resizeHandle.className = YAHOO.Adeptra.ResizePanel.CSS_RESIZE_HANDLE;

	this.beforeRenderEvent.subscribe(function() {
			if (! this.footer) {
				this.setFooter("");
			}
		},
		this, true
	);

	this.renderEvent.subscribe(function() {
		var me = this;

		me.innerElement.appendChild(me.resizeHandle);

		this.ddResize = new YAHOO.util.DragDrop(this.resizeHandle.id, this.id);
		this.ddResize.setHandleElId(this.resizeHandle.id);

		var headerHeight = me.header.offsetHeight;

		this.ddResize.onMouseDown = function(e) {

			this.startWidth = me.innerElement.offsetWidth;
			this.startHeight = me.innerElement.offsetHeight;

			me.cfg.setProperty("width", this.startWidth + "px");
			me.cfg.setProperty("height", this.startHeight + "px");

			this.startPos = [YAHOO.util.Event.getPageX(e),
							 YAHOO.util.Event.getPageY(e)];

			me.innerElement.style.overflow = "hidden";
			me.body.style.overflow = "auto";
		}

		this.ddResize.onDrag = function(e) {
			var newPos = [YAHOO.util.Event.getPageX(e),
						  YAHOO.util.Event.getPageY(e)];

			var offsetX = newPos[0] - this.startPos[0];
			var offsetY = newPos[1] - this.startPos[1];

			var newWidth = Math.max(this.startWidth + offsetX, 10);
			var newHeight = Math.max(this.startHeight + offsetY, 10);

			me.cfg.setProperty("width", newWidth + "px");
			me.cfg.setProperty("height", newHeight + "px");

			var bodyHeight = (newHeight - 5 - me.footer.offsetHeight - me.header.offsetHeight - 3);
			if (bodyHeight < 0) {
				bodyHeight = 0;
			}

			me.body.style.height =  bodyHeight + "px";

			var innerHeight = me.innerElement.offsetHeight;
			var innerWidth = me.innerElement.offsetWidth;

			if (innerHeight < headerHeight) {
				me.innerElement.style.height = headerHeight + "px";
			}

			if (innerWidth < 20) {
				me.innerElement.style.width = "20px";
			}
		}

	}, this, true);

	if (userConfig) {
		this.cfg.applyConfig(userConfig, true);
	}

	this.initEvent.fire(YAHOO.Adeptra.ResizePanel);
};

function alertJSONErrors(result)
{
    if (result.actionErrors)
    {
        for (key in result.actionErrors)
        {
            alert(result.actionErrors[key]);
            return true;
        }
    }
    if (result.fieldErrors)
    {
        for (key in result.fieldErrors)
        {
            alert(result.fieldErrors[key]);
            return true;
        }
    }
    if (result.result == "input")
    {
        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.missingparameter"),null);        
        return true;
    }
    return false;
}

function alertFailure(o)
{
    if (o.status == 403)
    {
        // session timeout, reload the page to redirect to login
        document.location.reload();
        return true;
    }
    else if (o.status >= 400)
    {
        // server error.
        alert(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.server"));
        document.location.reload();
        return true;
    }
    else if (o.status == 0)
    {
        // communication error.
        alert("A communication error occurred. Please retry.");
    }
    return false;
}

/* Tacks the Footer to the bottom of the window */

function getWindowHeight() {
        var windowHeight = 0;
        if (typeof(window.innerHeight) == 'number') {
                windowHeight = window.innerHeight;
        }
        else {
                if (document.documentElement && document.documentElement.clientHeight) {
                        windowHeight = document.documentElement.clientHeight;
                }
                else {
                        if (document.body && document.body.clientHeight) {
                                windowHeight = document.body.clientHeight;
                        }
                }
        }
        return windowHeight;
}
function setFooter() {
        if (document.getElementById && document.getElementById('content')) {
                var windowHeight = getWindowHeight();
                if (windowHeight > 0) {
                        var contentHeight = document.getElementById('content').offsetHeight;
                        var footerElement = document.getElementById('footer');
                        var footerHeight  = footerElement.offsetHeight;
                        if (windowHeight - (contentHeight + footerHeight) >= 0) {
                                footerElement.style.position = 'relative';
                                footerElement.style.top = (windowHeight - (contentHeight + footerHeight)-1) + 'px';
                        }
                        else {
                                footerElement.style.position = 'static';
                        }
                }
        }
}

// This recolors table rows with the original alternating row colors.
function recolorTable() {        
        var body = document.getElementById('portfolioFilterTable').firstChild;
        // the i modifier for regexes is far case insensitivity.
        while(!body.nodeName.match(/^tbody$/i)) body = body.nextSibling;
        var rows = body.childNodes;
        var count = false;
        for( var i = 0; i < rows.length; i++ ) {
                if(rows[i].nodeName.match(/^tr$/i)) {
                        count = !count;
                        if(count) rows[i].className = "oddRow";
                        //if(rows[i].className = "editRow") 
                        //rows[i].className  = "editRow" 
                       // alert(rows[i].className);
                        else rows[i].className = "evenRow";
                }
        }
}

function restripe(table) {
	var tbodies = table.getElementsByTagName('tbody');
	var containsFilterBody = false;
	for ( var i=0; i< tbodies.length; i++ )
	{
		if ( tbodies[i].id == "filterBody" )
		{
			containsFilterBody = true;
			break;
		}
	}	
	if ( containsFilterBody )
	{
        var tmptoStripe = table.getElementsByTagName('tr');
        var tbody = table.getElementsByTagName('tbody')[0];
        var stripeLen = tmptoStripe.length;
        var toStripe = new Array();
        for ( var i=0; i<stripeLen; i++ )
        {
        	if ( tmptoStripe[i].parentNode.id == "filterBody" )
        	{
				toStripe.push(tmptoStripe[i]);
        	}
        }
        for (var i = 0; i<toStripe.length; i++) {
                var row = toStripe[i];
				if(YAHOO.util.Dom.hasClass(row,"invalidRow"))
			    {
					continue;
			    }

                row.style.backgroundColor="";
                
                if (i % 2 == 0) {
                        if (row.className.indexOf("oddRow") >= 0) {
                        row.className = row.className.replace("oddRow", "evenRow");
                        } else if (row.className.indexOf("evenRow") < 0) {
                                row.className += " evenRow";
                        }
                }
                else {
                        if (row.className.indexOf("evenRow") >= 0) {
                        row.className = row.className.replace("evenRow", "oddRow");
                        } else if (row.className.indexOf("oddRow") < 0) {
                                row.className += " oddRow";
                        }
                }
                
                if (row.className.indexOf("hot") >= 0) row.className = row.className.replace("hot", "");
        }
	}
	else
	{
        var toStripe = table.getElementsByTagName('tr');
        for (var i = 0; i<toStripe.length; i++) {
                var row = toStripe[i];
				if(YAHOO.util.Dom.hasClass(row,"invalidRow"))
			    {
					continue;
			    }
                row.style.backgroundColor="";
                if (i % 2 == 0) {
                        if (row.className.indexOf("oddRow") >= 0) {
                        row.className = row.className.replace("oddRow", "evenRow");
                        } else if (row.className.indexOf("evenRow") < 0) {
                                row.className += " evenRow";
                        }
                }
                else {
                        if (row.className.indexOf("evenRow") >= 0) {
                        row.className = row.className.replace("evenRow", "oddRow");
                        } else if (row.className.indexOf("oddRow") < 0) {
                                row.className += " oddRow";
                        }
                }
                
                if (row.className.indexOf("hot") >= 0) row.className = row.className.replace("hot", "");
        }
	}

}

/* Makes table borders even vertically. */
function fixColumns() {
        if(!document.getElementById("col1")) return false;
        var h1 = document.getElementById("col1").offsetHeight;
        var h2 = document.getElementById("col2").offsetHeight;
        if(document.getElementById("col3")) {
                var h3 = document.getElementById("col3").offsetHeight;
        }
        else {
                return false;
        }
        var max = h1;
        if(h2 > max) max = h2;
        if(h3 > max) max = h3;
        document.getElementById("col1").style.height = max + "px";
        document.getElementById("col2").style.height = max + "px";
        if(document.getElementById("col3")) {
                document.getElementById("col3").style.height = max + "px";
        }
}

function addListeners(classType, elementType, containerType, callback_function, obj, override)
{
    return function()
    {
        var els = YAHOO.util.Dom.getElementsByClassName(classType, elementType, containerType);
        for (var i=0; i<els.length; i++)
        {
            var el = els[i];
            var str = callback_function + '(' + i + ')';
            YAHOO.util.Event.addListener(el, 'click', eval(str), obj, override);
        }
    };
}

function purgeListeners(classType, elementType, containerType) {
        return function() {
                var els = YAHOO.util.Dom.getElementsByClassName(classType, elementType, containerType);
                for (var i=0; i<els.length; i++) {
                        var el = els[i];
                        YAHOO.util.Event.purgeElement(el, true);
                }
        };
}

/* Help Panel */

function createHelpPanelHeader(id, topic)
{
    var div = document.createElement('div');
    div.className = "puffyBoxHeader";
    div.id = id + "PanelHeader";
    div.innerHTML = '<h2><img src="../common/img/iconHelp.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.common.help") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.common.help") + '" /> ' + topic.innerHTML + '</h2>';
    return div;
}

function createHelpTopicHeader(id, title, topic, idx)
{
    var div = document.createElement('div');
    div.className = "puffyBoxHeader noDisplay";
    div.id = id + "TopicHeader" + idx;
    div.innerHTML =
        '<h2>' +
        '<img src="../common/img/iconHelp.gif" alt="' + YAHOO.Adeptra.I18NUtil.label("portal2.common.help") + '" title="' + YAHOO.Adeptra.I18NUtil.label("portal2.common.help") + '" /> ' +
        '<a href="#" class="puffyBoxHeaderLink">' + title.innerHTML + '</a> ' +
        '&gt; ' + topic.innerHTML +
        '</h2>';
    return div;
}

function createHelpTopicItem(id, topic, idx)
{
    var li = document.createElement('li');
    li.innerHTML = '<a href="#">' + topic.innerHTML + '</a>';
    return li;
}

function createHelpTopicContent(id, content, idx)
{
    var div = document.createElement('div');
    div.className = "puffyBoxBodyContent noDisplay";
    div.id = id + "TopicContent" + idx;
    div.innerHTML = content.innerHTML;
    return div;
}

if (!YAHOO.Adeptra.Help)
{
YAHOO.Adeptra.Help = function() {

    var Event = YAHOO.util.Event;
    var Dom = YAHOO.util.Dom;

    return {
        helpEvent: null,
        init: function()
        {
            if (this.helpEvent == null)
            {
              this.helpEvent = new YAHOO.util.CustomEvent("helpEvent", this);
            }
        },
        addListener: function(fn, obj, override)
        {
            this.init();
            this.helpEvent.subscribe(fn, obj, override);
        },
        removeListener: function(fn, obj)
        {
            this.helpEvent.unsubscribe(fn, obj);
        },
        fire: function(id)
        {
            this.helpEvent.fire(id);
        }
    }
} ();
}

/**
 * Initializes the help panel content.
 * id - the id specified to the HelpPanel velocity macro
 * helpContentId - the id of the div containing the help (title, topics, and content)
 */
function initHelpPanel(id, helpContentId)
{
    if (!helpContentId) {
        helpContentId = id;
    }
    var helpContent = document.getElementById(helpContentId);
    var helpPanel = document.getElementById(id + "Panel");
    if (helpContent && helpPanel)
    {
        var title = helpContent.getElementsByTagName("h2")[0];
        var topics = helpContent.getElementsByTagName("dt");
        var contents = helpContent.getElementsByTagName("dd");

        var bodyDiv = document.getElementById(id + "PanelBody");
        helpPanel.insertBefore(createHelpPanelHeader(id, title), bodyDiv);
        var topicList = document.createElement('ul');
        for (var i = 0; i < topics.length; i++)
        {
            var topic = topics[i];
            var content = contents[i];
            helpPanel.insertBefore(createHelpTopicHeader(id, title, topic, i), bodyDiv);
            topicList.appendChild(createHelpTopicItem(id, topic, i));
            bodyDiv.appendChild(createHelpTopicContent(id, content, i));
        }
        document.getElementById(id + "Topics").appendChild(topicList);
        createHelpPanelListeners(id);
        YAHOO.util.Dom.removeClass(id + 'Div', 'noDisplay');
    }
}

function purgeHelpPanelListeners(id)
{
    var helpPanel = document.getElementById(id + "Panel");
    if (helpPanel)
    {
        YAHOO.util.Event.purgeElement(helpPanel, true);
    }
}

function createHelpPanelListeners(id)
{
    purgeHelpPanelListeners(id);
    var helpPanel = document.getElementById(id + "Panel");
    if (helpPanel) {
        var topicListDiv = document.getElementById(id + "Topics");
        var topicListLinks = topicListDiv.getElementsByTagName("a");
        for (var i = 0; i < topicListLinks.length; i++)
        {
            var link = topicListLinks[i];
            YAHOO.util.Event.addListener(link, "click", createHelpTopicLink(id, i));
        }
        var topicHeaderLinks = YAHOO.util.Dom.getElementsByClassName("puffyBoxHeaderLink", "a", id + "Panel");
        for (var i = 0; i < topicHeaderLinks.length; i++)
        {
            var link = topicHeaderLinks[i];
            YAHOO.util.Event.addListener(link, "click", createHelpTopicHeaderLink(id, i));
        }
    }
}

function createHelpTopicLink(id, i)
{
    return function(e) {
        YAHOO.util.Dom.addClass(id + "PanelHeader", 'noDisplay');
        YAHOO.util.Dom.addClass(id + "Topics", 'noDisplay');
        YAHOO.util.Dom.removeClass(id + "TopicHeader" + i, 'noDisplay');
        YAHOO.util.Dom.removeClass(id + "TopicContent" + i, 'noDisplay');
        YAHOO.util.Event.preventDefault(e);
        YAHOO.Adeptra.Help.fire(id);
    }
}

function createHelpTopicHeaderLink(id, i)
{
    return function(e) {
        YAHOO.util.Dom.removeClass(id + "PanelHeader", 'noDisplay');
        YAHOO.util.Dom.removeClass(id + "Topics", 'noDisplay');
        YAHOO.util.Dom.addClass(id + "TopicHeader" + i, 'noDisplay');
        YAHOO.util.Dom.addClass(id + "TopicContent" + i, 'noDisplay');
        YAHOO.util.Event.preventDefault(e);
        YAHOO.Adeptra.Help.fire(id);
    }
}

/**
 * Adds the listeners for handling clicking on the help button
 * id - the id specified to the HelpPanel velocity macro
 * linkId - the id specified to the HelpPanelLink or HelpPanelHeaderLink velocity macro
 */
function createHelpButtonListeners(id, linkId)
{
    if (!linkId)
    {
        linkId = id;
    }
    purgeHelpButtonListeners(linkId);
    if (document.getElementById(id + 'Panel') != null &&
        document.getElementById(linkId + 'Link') != null)
    {
        YAHOO.util.Event.addListener(linkId + 'Link', "click", createHelpButtonToggle(id, linkId));
        YAHOO.util.Event.addListener(linkId + 'ImgLink', "click", createHelpButtonToggle(id, linkId));
    }
}

function purgeHelpButtonListeners(id)
{
    var link = document.getElementById(id + "Link");
    var imgLink = document.getElementById(id + "ImgLink");
    if (link)
    {
        YAHOO.util.Event.purgeElement(link, true);
    }
    if (imgLink)
    {
        YAHOO.util.Event.purgeElement(imgLink, true);
    }
}

function createHelpButtonToggle(id, linkId)
{
    return function(e) {
        var helpPanel = document.getElementById(id + 'Panel');
        var link = document.getElementById(id + 'Link');
        
        if (helpPanel.style.display == "" || helpPanel.style.display == "none")
        {
            helpPanel.style.display = "block";
            link.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.common.closehelp");
        }
        else
        {
            helpPanel.style.display = "none";
            link.innerHTML = YAHOO.Adeptra.I18NUtil.label("portal2.common.help");
        }
        YAHOO.util.Event.preventDefault(e);
        YAHOO.Adeptra.Help.fire(id);
    }
}

function adeptraInit()
{
    setFooter();
    fixColumns();
    YAHOO.util.Event.addListener(window, "resize", setFooter);
    YAHOO.util.Event.addListener(window, "scroll", setFooter);

    YAHOO.Adeptra.Help.init();
    YAHOO.Adeptra.Help.addListener(setFooter);
    if (document.getElementById('instanceFocusSelect'))
    {
        YAHOO.util.Event.addListener('instanceFocusSelect', 'change', updateInstanceFocus);
    }
    if (document.getElementById('instanceFocusMenu'))
    {
        if (!document.getElementById('instances'))
        {
            YAHOO.util.Event.addListener('instanceFocusCurrent', 'click', YAHOO.APM.InstanceSelector.onInstanceFocusMenu);
        }
    }
    piInstance.init();
}

YAHOO.util.Event.addListener(window, "load", adeptraInit);

function getActiveInstanceTabUrl()
{
    if (document.getElementById('subtabGroup'))
    {
        var allTabs = YAHOO.util.Dom.getElementsBy(function(el){ return true; }, 'li', 'subtabGroup');
        var active = YAHOO.util.Dom.getElementsByClassName('active', 'li', 'subtabGroup');
        if (!active || !active.length)
        {
            active = document.getElementById('subtabGroup').getElementsByTagName('li');
        }
        var href = active[0].getElementsByTagName('a')[0].href;
        
        //Refresh Control/Auto Strategies tabs are optional
        if(href.indexOf('RefreshControl.action') >= 0 || href.indexOf('StrategySetHome.action') >= 0 || href.indexOf('FraudStop.action') >= 0 || href.indexOf('CaseDisposition.action') >= 0 || href.indexOf('WebCollect.action') >= 0)
        {
            //default to home tab
           href = allTabs[0].getElementsByTagName('a')[0].href;
        }
        return href;
    }
}

function updateInstanceFocus(instanceName,instanceType)
{
    JSONRequest.sendRequest(
        'page/checkInstanceExists.action?instanceName='+instanceName,
        '',
        {
            success: function(result)
            {
               var url = getActiveInstanceTabUrl();
               url += "&breadcrumb=true";//to reset action tracker and prevent redirection
               var re = new RegExp("instanceName=.*[&]|instanceName=.*", "g");
               document.location.href = url.replace(re,"instanceName=" + instanceName +(url.indexOf("&")==-1?"":"&"));
            },
            error: function(result)
            {
                showMessage(YAHOO.Adeptra.I18NUtil.labelFormat("portal2." + (instanceType == "apm" ? "apm" : "ade") + ".instancenotavailable",[instanceName]),null);
            },
            failure: function(o)
            {
                showMessage(YAHOO.Adeptra.I18NUtil.labelFormat("portal2." + (instanceType == "apm" ? "apm" : "ade") + ".instancenotavailable",[instanceName]),null);
            }
        });
}

function updateBreadCrumbStats(counts)
{
    if (counts) {
        active = counts.runningCount;
        pending = counts.pendingCount;
        total = active + pending;
        document.getElementById('bcTotalCount').innerHTML = total;
        document.getElementById('bcActiveCount').innerHTML = active;
        document.getElementById('bcPendingCount').innerHTML = pending;
    }
}

function apmModelLink(linkPrefix, obj, img, altText)
{
	if (obj && typeof(obj.id) == 'number')
    {
        var link = linkPrefix + obj.id + '">';
        if (img)
        {
            link += '<img src="../common/img/' + img + '" ';
            if (altText)
            {
                link += 'alt="' + altText + '" title="' + altText + '" ' ;
            }
            link += '/>';
        }
        else
        {
            link += obj.name;
        }
        return link + '</a>';
    }
    return '';
}

function strategyDetailsLink(strategy, img, altText)
{
    var action = null;
    // TODO: check type flag to determine if it is a strategyset
    if (strategy.createdBy)
    {
        action = 'StrategyDetails.action';
    }
    else
    {
        action = 'StrategySetDetails.action';
    }
    return apmModelLink('<a href="' + action + '?instanceName=' + _instanceName + '&strategy.id=', strategy, img, altText);
}

function portfolioDetailsLink(portfolio, img, altText)
{
    return apmModelLink('<a href="PortfolioDetails.action?instanceName=' + _instanceName + '&portfolio.id=', portfolio, img, altText);
}

function callWindowDetailsLink(callWindow, img, altText)
{
    return apmModelLink('<a href="CallWindowDetails.action?instanceName=' + _instanceName + '&callWindow.id=', callWindow, img, altText);
}

function findStrategy(id)
{
    if (apmStrategies) {
        for (var i = 0; i < apmStrategies.length; i++) {
            var strategy = apmStrategies[i];
            if (strategy.id == id) {
                return strategy;
            }
        }
    }
    return null;
}

function findPortfolio(id)
{
    if (apmPortfolios) {
        for (var i = 0; i < apmPortfolios.length; i++) {
            var portfolio = apmPortfolios[i];
            if (portfolio.id == id) {
                return portfolio;
            }
        }
    }
    return null;
}

function format2Digit(number)
{
    if ( number < 10 )
    {
        return "0" + number;
    }
    return number;
}

function showUpdatingMessage(msg)
{
	loadingdialog.setHeader(YAHOO.Adeptra.I18NUtil.labelFormat("portal2.common.pleasewaitmsg",[msg]));
	loadingdialog.setBody('<img src="../common/img/data_loading.gif" />');   
	loadingdialog.render(document.body);  
    loadingdialog.show();
}

function showConfirmationDialog(message,config)
{
	var buttons = new Array(
		{id:"okButton", text:YAHOO.Adeptra.I18NUtil.label("portal2.common.ok"), handler: function(){config.okFunction.call(); this.hide();}},
		{id:"cancelButton", text:YAHOO.Adeptra.I18NUtil.label("portal2.common.cancel"), handler : function(){this.hide();}}
	);
    
	var dialogName = "dialog" + (new Date()).getTime();
    var dialog = new YAHOO.widget.SimpleDialog(dialogName, {
            width:"34em", fixedcenter:true, visible:false, modal:true, 
            close:false, draggable:true, buttons:buttons
        });
    dialog.setBody(message);
    dialog.render(document.body);   
    
    dialog.show();
        
}

function showMessage(bodyStr, url , config)
{
    var okHandler = null;

	if(config && config.okHandler)
	{
	  okHandler = config.okHandler;
	}
	else
	{
	  okHandler = function() {
        if (url)
        {
            if(document.location.href == url)
            {
                document.location.reload();
            }
            else
            {
                document.location.href = url;
            }
        }
        this.hide();
        this.destroy();
      };
	}

    var buttons = new Array({id:"messageButton", text:YAHOO.Adeptra.I18NUtil.label("portal2.common.ok"), handler: okHandler});
    var dialogName = "dialog" + (new Date()).getTime();
    var dialog = new YAHOO.widget.SimpleDialog(dialogName, {
            width:config && config.width ? config.width : "34em",
            fixedcenter:config && config.fixedcenter ? config.fixedcenter : true,
            visible:false, 
            modal:true, 
            close:false, 
            draggable:true, 
            buttons:buttons
        });
    dialog.setBody(bodyStr);
    dialog.render(document.body);
    dialog.body.className = "greenHd";
    dialog.header.className = "greenBody";
    dialog.footer.className = "greenFoot";
        
    //-- if not in 'fixedcenter' mode, center the dialog 
    if (dialog.cfg.getProperty("fixedcenter")!=true)
    {
        dialog.center();
        dialog.cfg.setProperty("y",100);
        dialog.cfg.setProperty("draggable",false);
    }
    dialog.show();
}


function alertJSONErrorsExt(result)
{
    if (result.actionErrors || result.fieldErrors || 
    	result.result == "input")
    {
        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"),null);
        return true;
    }
    return false;
}

function showFieldActionErrors(result)
{
	var errorMessage = formatFieldActionErrors(result);
	
	if(errorMessage == "")
	{
	  errorMessage = YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured");
	}	
	
	showMessage(errorMessage,null);	
}

function formatFieldActionErrors(result)
{
    var errorMessage = "";
    if(result.actionErrors)
	{
		for(var i=0;i<result.actionErrors.length;i++)
		{
		  errorMessage += result.actionErrors[i] + "<br>";
		}
	}
	
	if(result.fieldErrors)
	{
		for(key in result.fieldErrors)
		{
		  errorMessage += result.fieldErrors[key] + "<br>";
		}
	}	
	return errorMessage;
}

function alertFailureExt(o, errUrl)
{
    if (o.status == 403)
    {
        // session timeout, reload the page to redirect to login
        document.location.reload();
        return true;
    }
    else if (o.status >= 400)
    {
        // server error.
        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"),errUrl);        
        return true;
    }
    else if (o.status == 0)
    {
        // communication error.
        showMessage(YAHOO.Adeptra.I18NUtil.label("portal2.common.error.hasoccured"));
    }
    return false;
}

function insertNewline (index,str)
{
    if ( index == 0 )
    {
        return str;
    }
    if ( !str )
    {
        return str;
    }
    if ( str.length <= index )
    {
    	return str;
    }

    var strset = str.split(""); 
    var resultstr = "";
    for ( var i=0; i < strset.length; i++ )
    {
        resultstr += strset[i];
        if ( (i+1) % index == 0 )
        {
            resultstr += "<br>";
        }
    }
    return resultstr;
}

function insertNewlineAfterChars(noOfChars,str)
{
    if ( noOfChars == 0 )
    {
        return str;
    }

    if ( str.length <= noOfChars)
    {
    	return str;
    }
     
    var resultstr = "";
	var startIndex = 0;
	var strlen = str.length;
    while (true)
    {
      if(startIndex+noOfChars > strlen)
	  {
	    resultstr += str.substring(startIndex);
		break;
	  }
      resultstr += str.substring(startIndex,startIndex+noOfChars) + "<br>";
	  startIndex += noOfChars;
    }
    return resultstr;
}

function insertNewlineAtSpace(noOfInitialSpaces,str)
{
    var strset = str.split(" ");
    
    if ( noOfInitialSpaces == 0 )
    {
        return str;
    }

    if ( strset.length <= noOfInitialSpaces)
    {
    	return str;
    }

     
    var resultstr = "";
    for ( var i=0; i < strset.length; i++ )
    {
        resultstr += strset[i] + " ";
        if ( (i+1) % noOfInitialSpaces == 0 )
        {
            resultstr += "<br>";
        }
    }
    return resultstr;
}

function calculatePercentage(num1, num2)
{
    if(num1 == 0 || num2 == 0)
    {
        return 0;
    }
    else
    {
        var result = num1/num2*100;
        var num3 = Math.pow(10, 2);
        result = Math.round(result * num3) / num3;
        return result;
    }
}


if (!String.prototype.trim){
	String.prototype.trim = function() {
    return this.replace(/^\s+|\s+$/g,"");
  }
}

var ttDelay=null;
function setTooltip(ttContext, ttText)
{
    if (gTooltipDelay && ttDelay==null)
    {
        ttDelay = gTooltipDelay;        
    }
    if (ttContext && ttText && ttText.length>0 && ttDelay && ttDelay>-1)
    {
        var ttip = new YAHOO.widget.Tooltip("myTooltip", 
                                           { context:ttContext, 
                                             text:ttText, 
                                             hidedelay:150  
                                           } );
        ttip.cfg.setProperty("showDelay", ttDelay, false);
        return ttip;
    }
}

if(!YAHOO.Adeptra.MultiSelectList)
{

	YAHOO.Adeptra.MultiSelectList = function(id,config,owner) 
	{
		this.init(id,config,owner);
	};
	
	YAHOO.Adeptra.MultiSelectList.prototype = 
	{
		id : null,
		config : null,
		selectedValues : null,
		selectedItems : null,
		data : null,
		owner : null,
	
		init : function(id,config,oOwner) {
			this.id=id;
			this.config = config;
			this.oOwner = oOwner;
			this.selectedValues = new Array();
			this.selectedItems = new Array();

			if(config)
			{
				if(config.header)
				{
					//add headers
					var listDiv = YAHOO.util.Dom.get(id);
					var header = document.createElement("div");
					header.appendChild(document.createTextNode(config.header));
					YAHOO.util.Dom.addClass(header,"multiselect-header");
					if(YAHOO.util.Dom.hasClass(listDiv,"multiselect-right"))
					{
					  header.style.left = "210px";	
					}
					listDiv.parentNode.appendChild(header);
				}
			}

			if (this.oOwner)
			{
			    YAHOO.util.Event.addListener(this.id,"dblclick",this.moveLeftRight,this,true);
			}
            YAHOO.util.Event.addListener(this.id,"click", this.onSelect,this,true);
			YAHOO.util.Event.addListener(window, "load", this.onLoad,this,true);
		},
	
		onLoad : function() {
		    //disable text selection
			YAHOO.util.Dom.get(this.id).onselectstart=new Function ("return false");
		},		
	
		onSelect : function(e,thisObj)
		{
			var elTarget = YAHOO.util.Event.getTarget(e);
			var contains = false;
			for(var i=0;i<this.selectedValues.length;i++)
			{
				if(this.selectedValues[i] == elTarget.value)
				{
					contains = true;
					this.selectedValues.splice(i,1);
					this.selectedItems.splice(i,1);
					break;
				}
			}

			if(!contains)
			{
				this.selectedValues.push(elTarget.value);
				
				function fItem() {
					if (!elTarget.firstChild)
					{
						return;
					}
                    this.displayValue = elTarget.firstChild.nodeValue; // the Text node
                    this.value = elTarget.value;
                    this.id = elTarget.id;
                };                
                var oItem = new fItem();
				this.selectedItems.push(oItem);
			}

			if(thisObj.selectedItems.length > 0)
			{
				if (thisObj.selectedItems[0].id == "rightincludeall" ||
					thisObj.selectedItems[0].id == "leftincludeall")
				{
					direction = (thisObj.selectedItems[0].id == "rightincludeall") ? "left" : "right";
					this.oOwner.moveItems(direction);
					return;
				}
			}
	
			this.paint(elTarget);
		},
		
		//-- common handler for moving items left-right
		moveLeftRight : function(e, thisObj)
		{		    
		    // unselect all
		    this.selectedValues=[];
		    this.selectedItems=[];
            
            this.onSelect(e, thisObj);
            var direction = "right";
            if (thisObj.selectedItems[0].id == "right" ||
                thisObj.selectedItems[0].id == "rightincludeall")
            {
                direction = "left";
            }
            this.oOwner.moveItems(direction);
		},
	
		paint : function(target)
		{	
			var divs = target.parentNode.getElementsByTagName("div");
			for(var i=0;i<divs.length;i++)
			{
				 if(this.isSelected(divs[i].value))
				 {
				   YAHOO.util.Dom.removeClass(divs[i], 'aui-msl-normal');	
				   YAHOO.util.Dom.addClass(divs[i], 'aui-msl-selected');
				 }
				 else
				 {
				   YAHOO.util.Dom.removeClass(divs[i], 'aui-msl-selected');
				   YAHOO.util.Dom.addClass(divs[i], 'aui-msl-normal');
				 }
			}
		},
	
		isSelected : function(value) 
		{
			for(var i=0;i<this.selectedValues.length;i++)
			{
				if(this.selectedValues[i] == value)
				{
					return true;
				}
			}
		},
	
		toPostData : function(retArray)
		{
			var postData = null;
			if(retArray)
			{
				postData = new Array();
				for(var i=0;i<this.selectedValues.length;i++)
				{
					postData.push(
                           {
                            key: this.config.postParameter + "[" + i + "]",
                            value: this.selectedValues[i]
                           }
                    );
				} 
			}
			else
			{
				postData = "";
				for(var i=0;i<this.selectedValues.length;i++)
				{
					postData += "&" + this.config.postParameter + "[" + i + "]=" + this.selectedValues[i]; 
				}
			}		                
	        return postData;
		},
		
		clear : function()
		{
			this.selectedValues = new Array();
			this.selectedItems = new Array();
			var divRoot = document.getElementById(this.id);
			var divs = divRoot.getElementsByTagName("div");
			var divsLength = divs.length;
			for(var i=divsLength-1;i>=0;i--)
			{
			   divRoot.removeChild(divs[i]);
			}
		},
		
		create : function()
		{
            this.selectedValues=[];
            this.selectedItems=[];
            
			var divRoot = document.getElementById(this.id);
			var childNodes = divRoot.getElementsByTagName("div");
			for(var i=0;i<childNodes.length;i++)
			{
				divRoot.removeChild(childNodes[i]);
			}
			
			for(var i=0;i<this.data.length;i++)
			{
				var div = document.createElement("div");
				YAHOO.util.Dom.addClass(div, 'aui-msl-normal');
				div.value = this.data[i].value;
				div.appendChild(document.createTextNode(this.data[i].displayValue));
				div.id = this.data[i].id;
				divRoot.appendChild(div);
				setTooltip(div,div.innerHTML);
			}
		},
		
        update_removedItems : function()
        {
            this.selectedValues=[];
            this.selectedItems=[];
            
            var divRoot = document.getElementById(this.id);
            var childNodes = divRoot.getElementsByTagName("div");
            
            for(var i=childNodes.length-1; i>-1; i--)
            {
                var match=false;
                for (var j=0; j<this.data.length; j++)
                {
                    if (childNodes[i].value == this.data[j].value)
                    {
                        match=true;
                    }
                }
                
                if (!match)
                {
                    divRoot.removeChild(childNodes[i]);
                }
            }
        }		
	}

}

function openWindow(url,name,config)
{	
  //Sets the height of the window in pixels. The minimum value is 150, and specifies the minimum height of the browser content area.
  var height = 150;
  //Sets the width of the window in pixels. The minimum value is 250, and specifies the minimum width of the browsers content area.
  var width = 250;
  //Specifies the left position, in pixels. This value is relative to the upper-left corner of the screen. The value must be greater than or equal to 0.
  var left = 0;
  //Specifies the top position, in pixels. This value is relative to the upper-left corner of the screen. The value must be greater than or equal to 0.
  var top = 0;   
  //Specifies whether to display the browser in full-screen mode. The default is no. Use full-screen mode carefully. Because this mode hides the browser's title bar and menus, you should always provide a button or other visual clue to help the user close the window. ALT+F4 closes the new window.
  var fullscreen = "no"; 
  //Specifies whether to display the navigation bar. The default is yes.	
  var locationbar = "yes";
  //Specifies whether to display the menu bar. The default is yes.
  var menubar = "yes";
  //Specifies whether to display horizontal and vertical scroll bars. The default is yes.
  var scrollbars = "yes";
  //Specifies whether to add a Status Bar at the bottom of the window. The default is yes. 
  var status = "yes";
  //Specifies whether to display a Title Bar for the window. The default is yes.
  var titlebar = "yes";
  //Specifies whether to display the browser command bar, making buttons such as Favorites Center, Add to Favorites, and Tools available. The default is yes.
  var toolbar = "yes";
  //Specifies whether to display resize handles at the corners of the window. The default is yes.
  var resizable = "yes";

  if(config)
  {
	  height = config.height ? config.height : height;
	  width = config.width ? config.width : width;
	  left = config.left ? config.left : left;
	  top = config.top ? config.top : top;
	  locationbar = config.locationbar ? config.locationbar : locationbar;
	  menubar = config.menubar ? config.menubar : menubar;
	  scrollbars = config.scrollbars ? config.scrollbars : scrollbars;
	  status = config.status ? config.status : status;
	  titlebar = config.titlebar ? config.titlebar : titlebar;
	  toolbar = config.toolbar ? config.toolbar : toolbar;
	  resizable = config.resizable ? config.resizable : resizable;
  }  
  return window.open(url, name.replace(/-/g,""), "height="+height+",width="+width+",left="+left+",top="+top+",location="+locationbar+",menubar="+menubar+",scrollbars="+scrollbars+",status="+status+",titlebar="+titlebar+",resizable="+resizable);	
}

function cloneObject(obj)
{
	var c = obj instanceof Array ? [] : {};

	for (var i in obj) {
	 var prop = obj[i];

	 if (typeof prop == 'object') {
		if (prop instanceof Array) {
			c[i] = [];

			for (var j = 0; j < prop.length; j++) {
				if (typeof prop[j] != 'object') {
					c[i].push(prop[j]);
				} else {
					c[i].push(cloneObject(prop[j]));
				}
			}
		} else {
			c[i] = cloneObject(prop);
		}
	 } else {
		c[i] = prop;
	 }
	}

	return c;
}

/**
* Returns the position of the caret in the given element
* Important : this method does not work correctly with new line feeds (\r\n)!!
**/
function getCaret(el) 
{
  if (el.selectionStart) { 
    return el.selectionStart; 
  } else if (document.selection) { 
    el.focus(); 

    var r = document.selection.createRange(); 
    if (r == null) { 
      return 0; 
    } 

    var re = el.createTextRange(), 
    rc = re.duplicate(); 
    re.moveToBookmark(r.getBookmark()); 
    rc.setEndPoint('EndToStart', re); 

    var add_newlines = 0;
    for (var i=0; i<rc.text.length; i++) {
      if (rc.text.substr(i, 2) == '\r\n') {
        add_newlines += 2;
        i++;
      }
    }

    return rc.text.length + add_newlines; 
  }  
  return 0; 
}
/**
 Sets the caret at the given position for the given element
**/
function setCaret(elem, caretPos) 
{
    if(elem != null) {
        if(elem.createTextRange) {
            var range = elem.createTextRange();
            range.move('character', caretPos);
            range.select();
        }
        else {
            if(elem.selectionStart) {
                elem.focus();
                elem.setSelectionRange(caretPos, caretPos);
            }
            else
                elem.focus();
        }
    }
}

function detectBrowser() 
{
    var ua = navigator.userAgent.toLowerCase();
    if (ua.indexOf('opera')!=-1) 
    { // Opera (check first in case of spoof)
      return 'opera';
    } 
    else if (ua.indexOf('msie 7')!=-1) 
    { // IE7
     return 'ie7';
    } 
    else if (ua.indexOf('msie') !=-1) 
    { // IE
     return 'ie';
    } 
    else if (ua.indexOf('safari')!=-1) 
    { // Safari (check before Gecko because it includes "like Gecko")
     return 'safari';
    } 
    else if (ua.indexOf('gecko') != -1) 
    { // Gecko
     return 'gecko';
    } 
    else 
    {
     return false;
    }
}