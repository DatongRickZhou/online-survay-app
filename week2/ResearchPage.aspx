<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchPage.aspx.cs" Inherits="week2.ResearchPage" %>

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
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-4">
                    <h1 class="modal-title">Choose Option:</h1>
                    <br />
                    <div class="row ">
                        <div class="col-6 d-flex justify-content-between">
                            <h2>Gender: </h2>
                        <asp:DropDownList CssClass="form-control" ID="GenderDropdownList" AutoPostBack="true" runat="server">
                    
                        </asp:DropDownList>
                        </div>
                        <div class="col-6 d-flex justify-content-between">
                            <h2>State: </h2>
                        <asp:DropDownList CssClass="form-control" ID="StateDropDownList" AutoPostBack="true" runat="server">
                            
                        </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <h2>Bank use: </h2>
                        <asp:DropDownList CssClass="form-control" ID="BankDropdownList" AutoPostBack="true" runat="server">
                            
                        </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <h2>Bank service use: </h2>
                        <asp:DropDownList CssClass="form-control" ID="ServiceDropdownList" AutoPostBack="true"  runat="server">
                            
                        </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col">
                            <asp:Button Cssclass="form-control btn-outline-success" ID="confirm" runat="server" Text="Confirm" OnClick="confirm_Click" />
                        </div>
                        <div class="col">
                            <asp:Button Cssclass="form-control btn-outline-warning" ID="reset" runat="server" Text="Reset" OnClick="reset_Click" />
                        </div>
                     </div>
                </div>
                <div class="col-8">
                    <h1 class="modal-title">Research table</h1>
                 
                    <asp:GridView ID="researchTable" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
