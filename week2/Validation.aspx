<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="week2.Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server" Height="21px" Width="158px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            Display="Dynamic" ErrorMessage="Name is needed, idiot!" 
            ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="DoB:"></asp:Label>
        <asp:TextBox ID="DoBTextBox" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DoBTextBox" 
            Display="Dynamic" ErrorMessage="Must be within valid range" MaximumValue="01/01/2069" 
            MinimumValue="01/01/1903" Type="Date"></asp:RangeValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Age:"></asp:Label>
        <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="AgeTextBox" 
            Display="Dynamic" ErrorMessage="You must be 18+ to enter!" Operator="GreaterThanEqual" 
            Type="Integer" ValueToCompare="18"></asp:CompareValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            Display="Dynamic" ErrorMessage="That is not an email!" ControlToValidate="EmailTextBox" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <br />
    
    </div>
    </form>
</body>
</html>
