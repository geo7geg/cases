 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.home" EnableEventValidation = "false"  UICulture="el-GR" Culture="el-GR"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Αρχική</title>
    <link rel="shortcut icon" href="http://192.168.1.201:8082/mini.ico"/>
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.3/jquery.min.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Scripts/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/jquery.datetimepicker.css" />
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery.datetimepicker.js"></script>
    <link rel="stylesheet" href="Scripts/bootstrap.min.css"/>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>--%>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    
       <script type="text/javascript">
           var z = 1;

           function function1() {
               var grow = setInterval(function () {
                   document.getElementById("grow").style.fontSize = z + "px";
                   z += 10;
                   if (document.getElementById("grow").style.fontSize >= "50px") {
                       clearInterval(grow);
                   }
               }, 1000);
           }

           function function2(obj)
           {
               var controlID = obj.id;
               var soapmessage = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><findperson xmlns="http://tempuri.org/"><id>'+ controlID +'</id></findperson></soap:Body></soap:Envelope>';
                   
               var webServiceURL = "http://192.168.1.201:8082/WebService2.asmx?op=findperson";
                $.ajax({
                    url: webServiceURL,
                    type: "POST",
                    dataType: "xml",
                    data: soapmessage,
                    contentType: "text/xml; charset=\"utf-8\"",
                    processData: false,
                    success: processSuccess,
                    error: processError
                });
           }

           function onMouseOver(rowIndex)
           {
               var gv = document.getElementById("GridView1");
               var rowElement = gv.rows[rowIndex];
               rowElement.display(rowElement.cells[0].text);
           }


           function processSuccess(data, status, req) {
               if (status == "success")
                   $("#Label3").text(($(req.responseXML).find("findpersonResult").find("name").text()));
           }

           function processError(data, status, req) {
               alert(req.responseText + " " + status);
           }
            
           $(document).ready(function () {
               $(".txtdate").datetimepicker();
           });
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="image">
            <a href="http://server/cases/home.aspx">
                <img id="3" class="Image1" src="http://192.168.1.201:8082/technor.png" alt="Alternate Text" /></a>
        </div>
        <div class="textbox1">
            <ul class="nav nav-pills nav-justified">
                <li class="active"><a href="http://server/cases/home.aspx">Αρχική</a></li>
                <li><a href="http://server/cases/cases.aspx">Υποθέσεις</a></li>
                <li><a href="http://server/cases/events.aspx">Γεγονότα</a></li>
                <li><a href="http://server/cases/milestones.aspx">Ορόσημα</a></li>
            </ul>
        </div>
        <br />
        <br />
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server" Height="173px" CssClass="gridview" Width="416px" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellSpacing="4" AllowSorting="True" OnSorting="GridView1_Sorting">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle Font-Names="Calibri" BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1F75AE" Font-Bold="True" ForeColor="White" Wrap="True"  CssClass="gridview" HorizontalAlign="Center"/>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#2A8F4D" Font-Bold="True" ForeColor="#EDF9F1" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <br />
        <div>
            <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Auto">
                <asp:GridView ID="GridView2" runat="server" Height="173px" Width="416px" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView2_RowCreated" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CellSpacing="4" AllowSorting="True" OnSorting="GridView2_Sorting" CssClass="gridview">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle Font-Names="Calibri" BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1F75AE" Font-Bold="True" ForeColor="White" Wrap="True"  CssClass="gridview" HorizontalAlign="Center"/>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#2A8F4D" Font-Bold="True" ForeColor="#EDF9F1" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
    </form>
    <%--<div class="wallpaper">

    </div>--%>
</body>
</html>
