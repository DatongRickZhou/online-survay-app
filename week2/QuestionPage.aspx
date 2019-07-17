<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionPage.aspx.cs" Inherits="week2.QuestionPage" %>

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
    </style>
</head>
<body>
    <div class="navigationBar" >
        <label class="navLabel">Welcome to AIT Servay</label>
    </div>
        <br />
        <br />
        <br />
        <br />
    <div class="container">
        <div class="row">
    <form id="form1" class="form-control col-4 offset-4" runat="server">
    <div class="centerMiddleContainer"style="margin-top: 0px; text-align: justify; font-weight: 700;">
        <asp:Label CssClass="centerMiddle" ID="CurrentQuestionLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:PlaceHolder ID="questionPlaceHolder" runat="server"></asp:PlaceHolder>
        <br />
        <br />
        <br />
    </div>
        <div class="row">
        <asp:Button Cssclass="form-control col-4 offset-4"  ID="NextButton" runat="server" OnClick="NextButton_Click" Text="Next" />
        <br />
        </div>
    </div>
    </form>
        </div>
</body>
</html>
