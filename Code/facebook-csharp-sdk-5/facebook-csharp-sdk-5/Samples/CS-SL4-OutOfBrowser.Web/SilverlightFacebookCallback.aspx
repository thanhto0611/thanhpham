﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SilverlightFacebookCallback.aspx.cs"
    Inherits="CS_SL4_OutOfBrowser.Web.SilverlightFacebookCallback" %>

<%@ Import Namespace="Facebook" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        window.external.notify('<%= JsonSerializer.Current.SerializeObject(new { access_token = AccessToken, error_description = ErrorDescription }) %>');
    </script>
    </form>
</body>
</html>
