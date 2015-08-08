<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="cascadingdropdownexp.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlcontinents" runat="server" 
            onselectedindexchanged="ddlcontinents_SelectedIndexChanged" Width="200px" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlcountries" runat="server" DataTextField="countryName" 
            DataValueField = "countryId" Width="200px" 
            onselectedindexchanged="ddlcountries_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlcities" runat="server" DataTextField="cityName" DataValueField = "cityId" Width="200px">
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
