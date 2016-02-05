<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="WebApplication1.events"  EnableEventValidation = "false"  UICulture="el-GR" Culture="el-GR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Γεγονότα</title>
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

           function Confirm() {
               var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Είστε σίγουρος;")) {
                   confirm_value.value = "Ναι";
               } else {
                   confirm_value.value = "Όχι";
               }
               document.forms[0].appendChild(confirm_value);
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
        <%--<li><a class="dropdown-toggle" data-toggle="dropdown" href="#">Υποθέσεις<span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="http://localhost:12051/cases.aspx?act=new">Νέο Έργο</a></li>
                        <li><a href="http://localhost:12051/cases.aspx?act=edit">Επεξεργασία Έργων</a></li>
                    </ul>
        </li>--%>
        <div class="textbox1">
            <ul class="nav nav-pills nav-justified">
                <li><a href="http://server/cases/home.aspx">Αρχική</a></li>
                <li><a href="http://server/cases/cases.aspx">Υποθέσεις</a></li>
                <li  class="active"><a href="http://server/cases/events.aspx">Γεγονότα</a></li>
                <li><a href="http://server/cases/milestones.aspx">Ορόσημα</a></li>
            </ul>
        </div>
        <div>
            <asp:Panel runat="server" Height="250px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server" Height="173px" Width="416px" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" OnSorting="GridView1_Sorting">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle Font-Names="Calibri" BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1F75AE" Font-Bold="True" ForeColor="White" />
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
        <div class="textbox">

            <asp:Panel ID="Panel1" runat="server" CssClass="textbox" Height="296px">
                <div class="textbox">
                    <asp:Label ID="event" runat="server" Height="25px" Style="margin-right: 5px; margin-left: 4px; margin-top: 0px; margin-bottom: 0px;" Text="Ημερομηνία Γεγονότος*" Width="163px"></asp:Label>
                    <asp:TextBox ID="event_date" runat="server" Style="margin-left: 3px; margin-right: 62px; margin-top: 28px; margin-bottom: 0px" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Height="36px" Style="margin-right: 11px; margin-left: 27px; margin-top: 0px; margin-bottom: 0px;" Text="Υπόθεση*" Width="74px"></asp:Label>
                    <asp:TextBox ID="cases" runat="server" Style="margin-right: 0px; margin-top: 9px; margin-bottom: 10px; margin-left: 0px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Height="26px" Style="margin-right: 8px; margin-top: 0px; margin-bottom: 0px; margin-left: 51px;" Text="Αιτών" Width="49px"></asp:Label>
                    <asp:TextBox ID="aiton" runat="server" Style="margin-right: 0px; margin-top: 6px; margin-bottom: 0px; margin-left: 4px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Height="29px" Style="margin-right: 7px; margin-top: 0px; margin-bottom: 0px; margin-left: 29px;" Text="Περιγραφή" Width="71px"></asp:Label>
                    <asp:TextBox ID="perigrafi" runat="server" Style="margin-right: 1px; margin-top: 19px; margin-left: 5px;" Width="162px" Height="22px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Height="26px" Style="margin: 0px 0px 0px 5px;" Text="Τελική Ημερομηνία" Width="132px"></asp:Label>
                    <asp:TextBox ID="final_date" runat="server" Style="margin-left: 12px; margin-top: 0px; margin-right: 38px; margin-bottom: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button9" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="30px" OnClick="Button9_Click" style="margin-right: 5px" Text="Ενημέρωση" Width="100px" />
                    <asp:Button ID="Button10" runat="server" BackColor="Red" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="30px" OnClientClick="Confirm()" OnClick="Button10_Click" style="margin-right: 6px; text-align: center; margin-left: 8px;" Text="Διαγραφή" Width="100px" />
                    <br />
                    <br />
                </div> 
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
