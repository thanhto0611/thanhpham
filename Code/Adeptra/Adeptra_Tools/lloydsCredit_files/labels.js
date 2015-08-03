/**
 *
 * Copyright (1997-2015), Fair Isaac Corporation. All Rights Reserved.
 */

YAHOO.namespace("Adeptra");
YAHOO.Adeptra.Labels = {
		
	generateOutParameters: function(params) {
		var outParams = [];
		for (var p in params)
		{		
			var param = params[p];
			
			// Field is in ruleDatums
			if (ruleDatums.fields[param] != undefined)
			{
				outParams.push(ruleDatums.fields[param].label);
			} 				
			else if (param != "")
			{
				// In function versions use 'prefix.' 
				// Try changing '.' to ':' for lookup
				var converted = param.replace(".",":");
				if (ruleDatums.fields[converted] != undefined)
				{
					outParams.push(ruleDatums.fields[converted].label);						
				} 
				else 
				{
					outParams.push(param);
				}
			}
		}
		return outParams;
	},
		
	getParameterLabels: function(parameterText) {
		var outParams = [];

		if (parameterText != null) {
			var text =  parameterText.toString();
			var start = text.indexOf("(")+1;
			var end = text.lastIndexOf(")");
			var middle = text.substring(start,end);
			var params = YAHOO.Adeptra.Labels.extractFunctionParameters(middle);
			
			outParams = YAHOO.Adeptra.Labels.generateOutParameters(params);
		}
		
		// Output 
		var outString = "";
		for (var p in outParams)
		{
			outString += outParams[p];					
						
			// Add comma
			if (p >= 0 && p < outParams.length-1 && outParams.length > 1) 
			{
				outString += ",";
			}
		}
		return "("+outString+")";
	},

	/* This method takes a comma-delimited string and parses it to its 
	 * individual components. Special handling is made for commas that reside 
	 * inside a quoted string, as those commas are not delimiters.
	 * 
	 * Eg: "a,'b',cd,'e,f',gh,i"
	 * output: ["a", "'b'", "cd", "'e,f'", "gh", "i"]
	 * 
	 * params: a comma-delimited string
	 * returns: an array containing the comma-delimited components of the string
	 */
	extractFunctionParameters: function(paramString)
	{
		var commaTokens = [];
		var inSingleQuote;
		
		var i = 0;
		while (i < paramString.length) {
			var c = paramString.charAt(i);
			switch (c) {
			case '\'':
				inSingleQuote = !inSingleQuote;
				break;
			case ',':
				if (!inSingleQuote)
				{
					commaTokens.push(i);
				}
				break;
			case '\\':
				// skip the next character because it's an escape sequence
				i++;
				break;
			}
			i++;
		}
		
		var paramTokens = [];
		var lastComma = -1;
		for (var n = 0; n < commaTokens.length; n++)
		{
			paramTokens.push(paramString.substring(lastComma + 1, commaTokens[n]));
			lastComma = commaTokens[n];
		}
		// push the last token after the final comma
		paramTokens.push(paramString.substring(lastComma + 1));
		
		return paramTokens;
	},
	
    getActionLabel: function(action, defaultLabel) {

            if (supportedActions)
            {
                for (var i = 0; i < supportedActions.length; i++)
                {
                    if (supportedActions[i].action == action)
                    {
                        return supportedActions[i].label;
                    }
                }
            }
            return defaultLabel;
        },

    getLabel: function(field) {
	
        var functionTag = "function:";
        var constantTag = "constant:";

        // constant
        if (field == null || field == "" || field == "null")
        {
            return "";
        }
        else if (field.substring(0, constantTag.length) == constantTag) 
        {
            return field.substring(constantTag.length, field.length);
        }
        // function
        else if (field.substring(0, functionTag.length) == functionTag) 
        {
            functionName = field.substring(functionTag.length, field.indexOf("("));
            var params = field.substring(field.indexOf("("), field.lastIndexOf(")")+1);
            
            return functionName+YAHOO.Adeptra.Labels.getParameterLabels(params);
        } 
        // other
        else
        {
            if (ruleDatums.fields[field] != undefined) 
            {
                return ruleDatums.fields[field].label;
            } else {
                return field;
            }
        }
    },
    
	getFunctionName: function(raw) {
		var functionName = "";
		var functionTag = "function:";
        if (raw.substring(0,9) == functionTag) {
        	functionName = raw.substring(functionTag.length);
        }
        return functionName;
	},
			
	generate: function(field) {
		label = YAHOO.Adeptra.Labels.getLabel(field);
		return label;
	},
    
    // Used by Changes tab (RuleChangeHistory.js) to get labels for mixed text input
    // This method is specific to Changes tab, 
    extractAndGenerate : function(element,text)
    {
        var output = "";

        if (text)
        {
            var tokens = text.split(" ");
            for ( var t in tokens)
            {
                var token = tokens[t];

                // Account for expressions
                if (token.indexOf("=") != -1)
                {
                    var expressions = token.split("=");
                    for ( var x in expressions)
                    {
                        var expression = expressions[x];

                        // Account for set var case
                        if (expression.substring(expression.length - 1) == "]")
                        {
                            // trunc the "]" and process
                            expression = expression.substring(0, expression.length - 1);
                        }

                        if (expression == "constant:")
                        {
                            element.appendChild(document.createTextNode(output));
                            YAHOO.Adeptra.Labels.appendEmpty(element);
                            output = "";
                        }
                        else
                        {
                            output += YAHOO.Adeptra.Labels.getLabel(expression);
                        }
                        
                        if (expressions[x].charAt(expressions[x].length-1) == "]")
                        {
                            element.appendChild(document.createTextNode(output + " ]"));
                            element.appendChild(document.createElement("br"));
                            output = "";
                        }

                        // left expression, add back equals
                        if (x == 0)
                        {
                            output += "=";
                        }

                        // add space after
                        if (x == expressions.length - 1)
                        {
                            output += " ";
                        }
                    }
                }
                else
                {
                    if (token.substring(token.length - 1) == "]")
                    {
                        token = token.substring(0, token.length - 1);
                    }
                    
                    if (token == "constant:")
                    {
                        element.appendChild(document.createTextNode(output));
                        YAHOO.Adeptra.Labels.appendEmpty(element);
                        output = "";
                    }
                    else if (token == "Conditions:" && tokens.length == 2)
                    {
                    	output += YAHOO.Adeptra.Labels.getLabel(token) + " " + YAHOO.Adeptra.I18NUtil.label("portal2.apm.refreshcontrol.always");
                    }
                    else
                    {
                        output += YAHOO.Adeptra.Labels.getLabel(token) + " ";
                    }
                    
                    if (tokens[t].charAt(tokens[t].length-1) == "]")
                    {
                        element.appendChild(document.createTextNode(output + "]"));
                        element.appendChild(document.createElement("br"));
                        output = "";
                    }
                }
            }
        }

        if (output.length > 0)
        {
            element.appendChild(document.createTextNode(output));
        }
    },
    
    appendEmpty : function(element)
    {
        var iEmpty = document.createElement("i");
        iEmpty.appendChild(document.createTextNode(YAHOO.Adeptra.I18NUtil.label("portal2.common.null")));
        
        element.appendChild(iEmpty);
    }
}
