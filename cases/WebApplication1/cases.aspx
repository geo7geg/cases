<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cases.aspx.cs" Inherits="WebApplication3.WebForm1" EnableEventValidation = "false"  UICulture="el-GR" Culture="el-GR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Υποθέσεις</title>
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

           function function2()
           {
               var controltext = document.getElementById('<%=TextBox5.ClientID%>').value;
               alert(document.getElementById('<%=TextBox5.ClientID%>').value);
               var soapmessage = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><findperson xmlns="http://tempuri.org/"><text>' + controltext + '</text></findperson></soap:Body></soap:Envelope>';
                   
               var webServiceURL = "http://localhost:12051/WebService2.asmx?op=findperson";
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
                   //$("#Label3").text(($(req.responseXML).find("findpersonResult").find("name").text()));
                   document.getElementById('<%=case_name.ClientID%>').value = data.FirstName.text();
                   for (var i = 0; i < data.d.length; i++) {
                       $("#GridView2").append("<tr><td>" + $(req.responseXML).find("findpersonResult").find("Contacts").text() +
                                                   "</td><td>" + data.d[i].LastName + "</td></tr>");
                   }
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

           function Confirm1() {
               var confirm_value1 = document.createElement("INPUT1");
               confirm_value1.type = "hidden";
               confirm_value1.name = "confirm_value1";
               if (confirm("Επιτυχής Εκτέλεση")) {
                   confirm_value1.value = "ΟΚ";
               }
               document.forms[0].appendChild(confirm_value1);
           }

           function processError(data, status, req) {
               alert(req.responseText + " " + status);
           }

           $(document).ready(function () {
               $(".txtdate").datetimepicker();
               var tab1 = '<%=Session["tab"]%>';
               $('#myTab a[href="#' + tab1 + '"]').tab('show');
           });

           <%--$(window).load(function () {
               var tab1 = '<%=Session["tab"]%>';
               $('#myTab a[href="#' + tab1 + '"]').tab('show');
           });--%>
           
           //$('.nav li:eq(2)').tab('show');
           //$('#myTab a[href="#event"]').tab('show');
           //$("#cases").removeClass("active");
           //$("#event").addClass("active");

           //function load() {
           //    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
           //}
           //function jsFunctions() {
           //    $(document).ready(function () {
           //        $(".txtdate").datetimepicker();
           //    });
           //}
           //function pageLoad() {

           //    $(function () {
           //        $(".txtdate").click(function () {
           //            alert("Alert: Hello from jQuery!");
                       
           //        });
           //        $(".txtdate").datetimepicker();
           //    });
               
           //}

           //function InitialiseSettings(){
           //    $(".txtdate").datetimepicker();

           //}

           //Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(InitialiseSettings);

           //$(document).ready(function () {
           //    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(InitialiseSettings‌​) 
           //    function InitialiseSettings() { 
           //        $(".txtdate").datetimepicker();
           //    }
           //})
           //$(document).ready(function () {
           //    $(".txtdate").datetimepicker();
           //});

           //function BindEvents() {
           //    $(document).ready(function () {
           //        $(".txtdate").datetimepicker();
           //    });
           //}
           
           //Sys.Application.add_load(BindEvents);

           //$(function () {
           //    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
           //});

           //function EndRequestHandler(sender, args) {
           //    ClientScript.RegisterStartupScript(this.Page, this.GetType(), "txtdate", "$(document).ready(function () {$('.txtdate').datetimepicker();});", true);
           //}
           //var prm = Sys.WebForms.PageRequestManager.getInstance();
           //ClientScript.RegisterStartupScript(this.Page, this.GetType(), "txtdate", "$(document).ready(function () {$('.txtdate').datetimepicker();});", true);
           //prm.add_endRequest(function () {
           //    BindEvents();
           //});
           //ClientScript.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$(document).ready(function () {$('.txtdate').datetimepicker();});", true);
        </script>
    </head>
<body>
    <form id="form1" runat="server" visible="True" lang="el">
    <div>
        <div class="image">
            <a href="http://server/cases/home.aspx">
                <img id="3" class="Image1" src="http://192.168.1.201:8082/technor.png" alt="Alternate Text" /></a>
        </div>
        <div class="textbox1">
            <ul class="nav nav-pills nav-justified">
                <li><a href="http://server/cases/home.aspx">Αρχική</a></li>
                <li class="active"><a href="http://server/cases/cases.aspx">Υποθέσεις</a></li>
                <li><a href="http://server/cases/events.aspx">Γεγονότα</a></li>
                <li><a href="http://server/cases/milestones.aspx">Ορόσημα</a></li>
            </ul>
            
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Milestones" BackColor="#D96C00" ForeColor="White" style="margin-right: 0px; text-align: center; margin-left: 45px;" Font-Names="Calibri"  CssClass="button rounded" Height="24px" Width="99px" Visible="False"/>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cases" BackColor="#006699" ForeColor="White" style="margin-right: 14px; text-align: center; margin-left: 15px; margin-top: 14px;" Font-Names="Calibri"  CssClass="button rounded" Height="24px" Width="99px" Visible="False"/>
            <asp:Button ID="Button5" runat="server" BackColor="#339966" ForeColor="White" OnClick="Button5_Click" Text="Events" Width="99px" style="margin-right: 5px" CssClass="button rounded" Font-Names="Calibri" Height="24px" Visible="False" />
            <asp:TextBox ID="TextBox4" runat="server" style="margin: 0px; text-align: left; " Font-Size="Large" Height="23px" Width="324px" Visible="False" ></asp:TextBox>
        </div>
        <div>
            <asp:Panel runat="server" Height="250px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server" Height="173px" Width="416px" CellPadding="0" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView1_RowCreated" HorizontalAlign="Center" AllowSorting="True" OnSorting="GridView1_Sorting">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle Font-Names="Calibri" BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1F75AE" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
        <div style="margin-top: 17px; " class="textbox">
            <ul id="myTab" class="nav nav-pills">
                <li class=""><a data-toggle="tab" href="#cases">Υπόθεση</a></li>
                <li class=""><a data-toggle="tab" href="#event">Γεγονός</a></li>
                <li class=""><a data-toggle="tab" href="#milestone">Ορόσημο</a></li>
            </ul>
        </div>
        <div class="tab-content">
        <div id="cases" class="tab-pane fade in active textbox">

            <asp:Panel ID="Panel1" runat="server" Width="857px" CssClass="inlineBlock" Height="599px">
                <div class="inlineBlock">
                    <asp:Label ID="Label1" runat="server" Height="35px" Style="margin-right: 7px; margin-left: 42px; margin-top: 0px; margin-bottom: 0px;" Text="Όνομα*" Width="51px"></asp:Label>
                    <asp:TextBox ID="case_name" runat="server" Style="margin-left: 21px; margin-right: 0px; margin-top: 34px; margin-bottom: 10px" Width="319px" OnTextChanged="case_name_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Height="32px" Style="margin-right: 0px; margin-left: 26px; margin-top: 0px; margin-bottom: 0px;" Text="Περιγραφή*" Width="82px"></asp:Label>
                    <asp:TextBox ID="perigrafi" runat="server" Height="22px" Style="margin-left: 14px; margin-right: 0px" TextMode="MultiLine" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Height="35px" Style="margin-right: 11px; margin-top: 0px; margin-bottom: 0px; margin-left: 48px;" Text="Πηγή" Width="49px"></asp:Label>
                    <asp:TextBox ID="pigi" runat="server" Style="margin-right: 0px; margin-top: 9px; margin-bottom: 10px; margin-left: 13px;" Width="314px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label9" runat="server" Height="34px" Style="margin-right: 14px; margin-top: 0px; margin-bottom: 0px; margin-left: 42px;" Text="Σχόλια" Width="51px"></asp:Label>
                    <asp:TextBox ID="sxolia" runat="server" Height="22px" Style="margin-left: 15px; margin-top: 0px" TextMode="MultiLine" Width="318px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Height="35px" Style="margin: 0px 5px;" Text="Προϋπολογισμός" Width="110px"></asp:Label>
                    <asp:TextBox ID="budget" runat="server" Style="margin-right: 18px; margin-top: 6px; margin-bottom: 10px" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Height="35px" Style="margin-right: 5px; margin-top: 0px; margin-bottom: 0px; margin-left: 37px;" Text="Κόστος" Width="58px"></asp:Label>
                    <asp:TextBox ID="cost" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 20px;" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label7" runat="server" Height="35px" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 0px; margin-left: 12px;" Text="Τιμή Πώλησης" Width="97px"></asp:Label>
                    <asp:TextBox ID="sale_price" runat="server" Style="margin-right: 7px; margin-top: 0px; margin-bottom: 10px; margin-left: 12px;" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Height="35px" Style="margin-right: 11px; margin-top: 0px; margin-bottom: 0px; margin-left: 40px;" Text="Αρχείο" Width="52px"></asp:Label>
                    <asp:TextBox ID="arxeio" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 18px;" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label18" runat="server" Height="35px" Style="margin-right: 13px; margin-top: 0px; margin-bottom: 0px; margin-left: 30px;" Text="Κατάσταση" Width="78px"></asp:Label>
                    <asp:TextBox ID="status" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 11px; margin-left: 0px;" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label19" runat="server" Height="35px" Style="margin: 0px 11px;" Text="Προτεραιότητα" Width="98px"></asp:Label>
                    <asp:TextBox ID="priority" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Width="319px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label20" runat="server" Height="35px" Style="margin: 0px 18px 0px 26px;" Text="Υπεύθυνος" Width="75px"></asp:Label>
                    <asp:TextBox ID="ipeuthinos" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Width="319px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="case_id" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="code" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
                </div>
                <div class="inlineBlock">
                    <asp:Label ID="Label2" runat="server" Height="47px" Style="margin-right: 19px; margin-top: 0px; margin-bottom: 0px; margin-left: 30px;" Text="Ημερομηνία Δημιουργίας" Width="82px"></asp:Label>
                    <asp:TextBox ID="creation_date" runat="server" Style="margin-right: 0px; margin-top: 35px; margin-bottom: 14px; margin-left: 0px;" Width="162px" CssClass="txtdate" OnTextChanged="TextBox1_TextChanged1"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Height="46px" Style="margin-right: 14px; margin-top: 0px; margin-bottom: 0px; margin-left: 32px;" Text="Ημερομηνία Προσφοράς" Width="85px"></asp:Label>
                    <asp:TextBox ID="offer_date" runat="server" Style="margin-right: 0px; margin-top: 12px; margin-bottom: 10px; margin-left: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label14" runat="server" Height="46px" Style="margin-right: 15px; margin-top: 0px; margin-bottom: 0px; margin-left: 30px;" Text="Καταληκτική Ημερομηνία" Width="86px"></asp:Label>
                    <asp:TextBox ID="close_date" runat="server" Style="margin-right: 0px; margin-top: 14px; margin-bottom: 10px; margin-left: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label15" runat="server" Height="48px" Style="margin-right: 19px; margin-top: 0px; margin-bottom: 0px; margin-left: 33px;" Text="Τελική Ημερομηνία" Width="80px"></asp:Label>
                    <asp:TextBox ID="final_date" runat="server" Style="margin-right: 0px; margin-top: 15px; margin-bottom: 10px; margin-left: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label16" runat="server" Height="45px" Style="margin-right: 14px; margin-top: 0px; margin-bottom: 0px; margin-left: 31px;" Text="Ημερομηνία Τερματισμού" Width="88px"></asp:Label>
                    <asp:TextBox ID="finish_date" runat="server" Style="margin-right: 0px; margin-top: 12px; margin-bottom: 10px; margin-left: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Height="35px" Style="margin-right: 4px; margin-top: 0px; margin-bottom: 0px; margin-left: 24px;" Text="Τύπος Σχεδίου*" Width="104px"></asp:Label>
                    <asp:TextBox ID="project_type" runat="server" Style="margin-right: 0px; margin-top: 8px; margin-bottom: 10px; margin-left: 0px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Height="46px" Style="margin-right: 19px; margin-top: 0px; margin-bottom: 0px; margin-left: 32px;" Text="Κωδικός Προσφοράς" Width="80px"></asp:Label>
                    <asp:TextBox ID="offer_code" runat="server" Style="margin-right: 5px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Width="77px"></asp:TextBox>
                    <asp:Button ID="Button11" runat="server" BackColor="#1F75AE" ForeColor="White" Height="22px" OnClick="Button11_Click" style="margin-left: 4px; margin-right: 3px; margin-bottom: 10px" Text="300" Width="38px" TabIndex="1" />
                    <asp:Button ID="Button12" runat="server" BackColor="#1F75AE" ForeColor="White" Height="22px" OnClick="Button12_Click" style="margin-left: 0px; margin-bottom: 10px" Text="350" Width="38px" TabIndex="1" />
                    <br />
                    <asp:Label ID="Label12" runat="server" Height="43px" Style="margin-right: 11px; margin-top: 0px; margin-bottom: 0px; margin-left: 33px;" Text="Κωδικός Σχεδίου" Width="52px"></asp:Label>
                    <asp:TextBox ID="project_code" runat="server" Style="margin-right: 0px; margin-top: 9px; margin-bottom: 10px; margin-left: 35px;" Width="77px"></asp:TextBox>
                    <asp:Button ID="Button13" runat="server" BackColor="#1F75AE" ForeColor="White" Height="22px" OnClick="Button13_Click" style="margin-left: 9px; margin-right: 3px; margin-bottom: 10px" Text="500" Width="38px" TabIndex="1" />
                    <asp:Button ID="Button14" runat="server" BackColor="#1F75AE" ForeColor="White" Height="22px" OnClick="Button14_Click" style="margin-left: 0px; margin-right: 0px; margin-bottom: 10px" Text="550" Width="38px" TabIndex="1" />
                    <br />
                    <br />
                    <asp:Button ID="Button8" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button8_Click" style="margin-right: 14px; text-align: center; margin-left: 30px;" Text="Εισαγωγή" Width="90px" TabIndex="1" />
                    <asp:Button ID="Button9" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button9_Click" style="margin-right: 5px" Text="Ενημέρωση" Width="90px" TabIndex="1" />
                    <asp:Button ID="Button10" runat="server" BackColor="Red" OnClientClick="Confirm()" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button10_Click" style="margin-right: 6px; text-align: center; margin-left: 8px;" Text="Διαγραφή" Width="89px" TabIndex="1" />
                    <br />
                    <br />
                    <asp:Button ID="Button15" runat="server" BackColor="#999999" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button15_Click" style="margin-right: 6px; text-align: center; margin-left: 137px;" Text="Καθαρισμός" Width="90px" TabIndex="1" />
                    <br />
                </div>
                
            </asp:Panel>
            <div class="inlineBlock">
                <asp:Panel ID="Panel8" runat="server" Height="280px" Width="608px" ScrollBars="Auto" Visible="False">
                
                <br />
                <asp:GridView ID="GridView4" runat="server" CellPadding="4" Font-Names="Calibri" ForeColor="#333333" GridLines="Vertical" Height="241px" OnRowCreated="GridView4_RowCreated" OnRowDataBound="GridView4_RowDataBound" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" style="margin-top: 17px" Width="585px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" Font-Names="Calibri" />
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
                <br />
                <asp:Panel ID="Panel9" runat="server" Height="280px" Width="608px" ScrollBars="Auto" Visible="False">
                
                <br />
                <asp:GridView ID="GridView7" runat="server" CellPadding="4" Font-Names="Calibri" ForeColor="#333333" GridLines="Vertical" Height="241px" OnRowCreated="GridView7_RowCreated" OnRowDataBound="GridView7_RowDataBound" OnSelectedIndexChanged="GridView7_SelectedIndexChanged" style="margin-top: 17px" Width="585px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" Font-Names="Calibri" />
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
                <br />
            <asp:Panel ID="Panel2" runat="server" Height="264px" Width="608px" ScrollBars="Auto" Wrap="False" Visible="False">
                <asp:GridView ID="GridView2" runat="server" Height="241px" Width="585px" CellPadding="4" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView2_RowCreated" style="margin-top: 24px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" SelectText="Διαγραφή" ShowSelectButton="True" >
                        <ControlStyle BackColor="#C60000" ForeColor="White" />
                        </asp:CommandField>
                    </Columns>
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
                <br />
                <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 129px" Width="186px"></asp:TextBox>
                <asp:Button ID="Button20" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="23px" OnClick="Button20_Click" style="margin-right: 14px; text-align: center; margin-left: 15px;" Text="Αναζήτηση Επαφών" Width="145px" />
                <br />
                <br />
            <asp:Panel ID="Panel7" runat="server" Height="280px" Width="608px" ScrollBars="Auto">
                
                <br />
                <asp:GridView ID="GridView3" runat="server" CellPadding="4" Font-Names="Calibri" ForeColor="#333333" GridLines="Vertical" Height="241px" OnRowCreated="GridView3_RowCreated" OnRowDataBound="GridView3_RowDataBound" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" style="margin-top: 17px" Width="585px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Προσθήκη" >
                        <ControlStyle BackColor="#1F75AE" ForeColor="White" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" Font-Names="Calibri" />
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
        </div>
         
          
        <div id="event" class="tab-pane fade textbox" style="margin-top: 17px; ">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True" ScriptMode="Inherit">
                
            </asp:ScriptManager>
            
          
            <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
              <ContentTemplate>--%>
                
            <asp:Panel ID="Panel3" runat="server" Width="745px" CssClass="inlineBlock textbox" Height="599px">
                <div style="height: 362px">
                    <%--<script type="text/javascript">
                        //function pageLoad() {

                           
                        //        $(".txtdate").datetimepicker();
                            
                        //}
                    </script> --%>                   
                    <asp:Label ID="Label21" runat="server" Height="25px" Style="margin-right: 5px; margin-left: 0px; margin-top: 0px; margin-bottom: 0px;" Text="Ημερομηνία Γεγονότος*" Width="163px"></asp:Label>
                    <asp:TextBox ID="event_date" runat="server" Style="margin-left: 10px; margin-right: 62px; margin-top: 28px; margin-bottom: 0px" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label23" runat="server" Height="26px" Style="margin-right: 8px; margin-top: 0px; margin-bottom: 0px; margin-left: 51px;" Text="Αιτών" Width="49px"></asp:Label>
                    <asp:TextBox ID="aiton" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 0px; margin-left: 4px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label24" runat="server" Height="29px" Style="margin-right: 7px; margin-top: 0px; margin-bottom: 0px; margin-left: 29px;" Text="Περιγραφή" Width="71px"></asp:Label>
                    <asp:TextBox ID="perigrafi_event" runat="server" Style="margin-right: 1px; margin-top: 19px; margin-left: 5px;" Width="162px" Height="22px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label25" runat="server" Height="26px" Style="margin: 0px 0px 0px 5px;" Text="Τελική Ημερομηνία" Width="132px"></asp:Label>
                    <asp:TextBox ID="final_date_event" runat="server" Style="margin-left: 12px; margin-top: 0px; margin-right: 38px; margin-bottom: 0px;" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <br />
                    
                    <asp:Button ID="Button1" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button1_Click" style="margin-right: 14px; text-align: center; margin-left: 30px;" Text="Εισαγωγή" Width="90px" />
                    <asp:Button ID="Button2" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button2_Click" style="margin-right: 5px" Text="Ενημέρωση" Width="90px" />
                    <asp:Button ID="Button3" runat="server" BackColor="Red" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClientClick="Confirm()" OnClick="Button3_Click" style="margin-right: 6px; text-align: center; margin-left: 8px;" Text="Διαγραφή" Width="90px" />
                    <br />
                    <br />
                    <asp:Button ID="Button6" runat="server" BackColor="#999999" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="27px" OnClick="Button6_Click" style="margin-right: 6px; text-align: center; margin-left: 30px;" Text="Καθαρισμός" Width="90px" />
                    <br />
                    <br />
                    <asp:TextBox ID="event_id" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="event_cases" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
                    </div>
                
            </asp:Panel>
            
            <asp:Panel ID="Panel4" runat="server" CssClass="inlineBlock" Height="286px" Width="646px" ScrollBars="Auto">
                <asp:GridView ID="GridView5" runat="server" Height="241px" Width="585px" CellPadding="4" OnRowDataBound="GridView5_RowDataBound" OnSelectedIndexChanged="GridView5_SelectedIndexChanged" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView5_RowCreated" style="margin-top: 27px" AllowSorting="True" OnSorting="GridView5_Sorting">
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
                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
            <%--<script type="text/javascript">
                var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
                pageRequestManager.add_endRequest(InitialiseSettings);
            </script>--%>
        </div>
        
        <div id="milestone" class="tab-pane fade textbox" style="margin-top: 17px; ">
            
          
            <%--<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                        <ContentTemplate>--%>
            <asp:Panel ID="Panel5" runat="server" Width="745px" CssClass="inlineBlock textbox" Height="599px">
                <div style="height: 447px" >
                    <asp:Label ID="Label26" runat="server" Height="25px" Style="margin-right: 5px; margin-left: 0px; margin-top: 0px; margin-bottom: 0px;" Text="Ημερομηνία Ορόσημου*" Width="163px"></asp:Label>
                    <asp:TextBox ID="milestone_date" runat="server" Style="margin-left: 10px; margin-right: 62px; margin-top: 28px; margin-bottom: 0px" Width="162px" CssClass="txtdate"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label28" runat="server" Height="26px" Style="margin-right: 8px; margin-top: 0px; margin-bottom: 0px; margin-left: 51px;" Text="Αιτών" Width="50px"></asp:Label>
                    <asp:TextBox ID="aiton_milestone" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 0px; margin-left: 4px;" Width="162px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label29" runat="server" Height="24px" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 0px; margin-left: 6px;" Text="Υπεύθυνος Υλοποίησης" Width="155px"></asp:Label>
                    <asp:TextBox ID="ypeythynos" runat="server" Style="margin-right: 64px; margin-top: 0px; margin-bottom: 0px; margin-left: 16px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label30" runat="server" Height="29px" Style="margin-right: 15px; margin-top: 0px; margin-bottom: 0px; margin-left: 23px;" Text="Περιγραφή" Width="71px"></asp:Label>
                    <asp:TextBox ID="perigrafi_milestone" runat="server" Height="22px" Style="margin-left: 8px; margin-top: 19px; margin-right: 1px;" TextMode="MultiLine" Width="162px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label31" runat="server" Height="26px" Style="margin: 0px;" Text="Τελική Ημερομηνία" Width="141px"></asp:Label>
                    <asp:TextBox ID="final_date_milestone" runat="server" CssClass="txtdate" Style="margin-right: 38px; margin-top: 0px; margin-bottom: 0px; margin-left: 12px;" Width="162px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label32" runat="server" Height="24px" Style="margin-right: 9px; margin-top: 0px; margin-bottom: 0px; margin-left: 7px;" Text="Καταληκτική Ημερομηνία" Width="186px"></asp:Label>
                    <asp:TextBox ID="close_date_milestone" runat="server" CssClass="txtdate" Style="margin-right: 87px; margin-top: 16px; margin-bottom: 0px; margin-left: 0px;" Width="162px"></asp:TextBox>
                     <br />
                    <br />
                    <asp:Button ID="Button16" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button16_Click" style="margin-right: 14px; text-align: center; margin-left: 30px;" Text="Εισαγωγή" Width="90px" />
                    <asp:Button ID="Button17" runat="server" BackColor="#1F75AE" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button17_Click" style="margin-right: 5px" Text="Ενημέρωση" Width="90px" />
                    <asp:Button ID="Button18" runat="server" BackColor="Red" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClientClick="Confirm()" OnClick="Button18_Click" style="margin-right: 6px; text-align: center; margin-left: 8px;" Text="Διαγραφή" Width="90px" />
                    <br />
                    <br />
                    <asp:Button ID="Button19" runat="server" BackColor="#999999" CssClass="button rounded" Font-Names="Calibri" ForeColor="White" Height="28px" OnClick="Button19_Click" style="margin-right: 6px; text-align: center; margin-left: 30px;" Text="Καθαρισμός" Width="90px" />
                    <br />
                    <br />
                    <asp:TextBox ID="milestone_id" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="milestone_cases" runat="server" Style="margin-right: 0px; margin-top: 0px; margin-bottom: 10px; margin-left: 0px;" Visible="False" Width="162px"></asp:TextBox>
            </div>
                
            </asp:Panel>
            <asp:Panel ID="Panel6" runat="server" CssClass="inlineBlock" Height="287px" Width="650px" ScrollBars="Auto">
                <asp:GridView ID="GridView6" runat="server" Height="241px" Width="585px" CellPadding="4" OnRowDataBound="GridView6_RowDataBound" OnSelectedIndexChanged="GridView6_SelectedIndexChanged" ForeColor="#333333" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView6_RowCreated" style="margin-top: 27px" AllowSorting="True" OnSorting="GridView6_Sorting">
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
                            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </div>
            </div>
    </div>
    </form>
    </body>
</html>
