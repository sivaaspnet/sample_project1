<%@ Page Language="VB" AutoEventWireup="false" CodeFile="3.0.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:PasswordStrength ID="PasswordStrength1" runat="server" 
            TargetControlID="TextBox1"
    DisplayPosition="RightSide"
    StrengthIndicatorType="Text"
    PreferredPasswordLength="10"
    PrefixText="Strength:"
    TextCssClass="TextIndicator_TextBox1"
    MinimumNumericCharacters="0"
    MinimumSymbolCharacters="0"
    RequiresUpperAndLowerCaseCharacters="false"
    TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
    CalculationWeightings="50;15;15;20">
        </cc1:PasswordStrength> 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
    </div>
    </form>
</body>
</html>
