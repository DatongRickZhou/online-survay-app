<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="week2.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/sheetstyle.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title></title>
    <style type="text/css">
        .navigationBar {
            height: 30px;
        }
        .ResearchButton {
        height:100%;
        margin:0px;
        padding:0px;
        }
        .navLabel {
        width:auto;
        }
    </style>
</head>
<body>
    
    <form id="form2" runat="server">
        <div class="navigationBar d-flex justify-content-between" >
        <label class="navLabel">Welcome to AIT Servay</label>
        <asp:Button Cssclass="btn btn-primary ResearchButton" ID="ResearchButton" runat="server" Text="Research" OnClick="ResearchButton_Click" />
    </div>
        <br />
        <br />
        <br />
        <br />
        <div class="container">
            <div class="row">
                <h1 class="text-center col">Register Page</h1>
            </div>
            <br />
            <br />
            <div class="row justify-content-center">
                <div class="col-4">
                    <Label>FirstName:</Label>
                </div>
                <div class="col-4">
                    <Label>LastName:</Label>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-4 ">
                    <asp:TextBox Cssclass="form-control" ID="FirstNameTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:TextBox Cssclass="form-control" ID="LastNameTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row ">
                <div class="col-4 offset-2">
                    <asp:Label ID="Label1" runat="server" Text="Phone Number:"></asp:Label>
                </div>
            </div>
            <div class="row ">
                <div class="col-4 offset-2">
                    <asp:TextBox Cssclass="form-control" ID="PhoneNumberTextBox" runat="server"></asp:TextBox>
                </div>
                <br />
            </div>
            <div class="row ">
                <div class="col-4 offset-2">
                    <asp:Label ID="Label3" runat="server" Text="Date of Birth:"></asp:Label>
                </div>
            </div>
            <div class="row ">
                <div class="col-4 offset-2">
                    <asp:TextBox Cssclass="form-control" type="date" ID="DOBTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
            <br /> 
            <div class="row">
                <div class="col-4 offset-2">
                    <asp:Button CssClass="form-control btn-primary " ID="StartButton" runat="server" Text="Regist" OnClick="StartButton_Click" />
                </div>
                 <div class="col-4">
                    <asp:Button CssClass="form-control btn-secondary " ID="SkipButton" runat="server" Text="Skip" OnClick="SkipButton_Click" />
                </div>
                
            </div>
        </div>
    </form> 
</body>
</html>
