<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishPage.aspx.cs" Inherits="week2.FinishPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/sheetstyle.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title></title>
    <style type="text/css">
        .navigationBar {
            height: 22px;
        }
    </style>
</head>
<body>
    <div class="navigationBar" >
        <label class="navLabel">Welcome to AIT Servay</label>
    </div>
    <form id="form1"  runat="server">
        <div class="container">
            <div class="row">
                <div class="col offset-3">
                    <h1 >Thank you for take the Survay! <br />Have a nice day!</h1>
                    <br />
                    <br />
                    <button type="button" class="btn btn-info btn-block">Finishe</button>
                </div>
            </div>
            
        </div>
    </form>
    
</body>
</html>
