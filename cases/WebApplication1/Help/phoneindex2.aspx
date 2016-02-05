<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phoneindex2.aspx.cs" Inherits="WebApplication1.phonecatalog2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Τηλεφωνικός Κατάλογος</title>
    <link rel="shortcut icon" href="http://192.168.1.201:8082/mini.ico"/>
    <link rel="stylesheet" type="text/css" href="style.css"/>
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.3/jquery.min.js"></script>
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

           function processSuccess(data, status, req) {
               if (status == "success")
                   $("#Label3").text(($(req.responseXML).find("findpersonResult").find("name").text()));
           }

           function processError(data, status, req) {
               alert(req.responseText + " " + status);
           }
               
        </script>
    <style type="text/css">
        .button {}
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="image">
            <a href="http://192.168.1.201/phoneindex.aspx">
                <img id="3" class="Image1" src="http://192.168.1.201:8082/technor.png" height="178" width="634" alt="Alternate Text" /></a>
        </div>
        <div class="textbox">

            <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="#D50000" Text="Συμπληρώστε τα απαραίτητα πεδία που είναι χρωματισμένα " Visible="False"></asp:Label>
            <br />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Γενικές Πληροφορίες" Font-Size="XX-Large" CssClass="headlabels" Font-Names="Calibri" ForeColor="#3399FF"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Όνομα" Height="25px" CssClass="labels" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" CssClass="textboxes" ></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Επώνυμο" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" style="margin-right: 17px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Εταιρεία" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" style="margin-right: 10px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Τμήμα" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Επάγγελμα" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" style="margin-right: 30px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Δραστηριότητα" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 52px" CssClass="textboxes">
                <asp:ListItem> ΟΛΑ</asp:ListItem>
                <asp:ListItem>ΕΡΓΟΛΗΠΤΗΣ</asp:ListItem>
                <asp:ListItem>ΜΕΛΕΤΗΤΗΣ</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ</asp:ListItem>
                <asp:ListItem>ΕΙΔΙΚΕΣ ΕΤΑΙΡΕΙΕΣ</asp:ListItem>
                <asp:ListItem>ΠΕΡΙΦΕΡΕΙΑ</asp:ListItem>
                <asp:ListItem>ΔΗΜΟΣ</asp:ListItem>
                <asp:ListItem>ΔΕΥΑ</asp:ListItem>
                <asp:ListItem>ΔΕΚΟ</asp:ListItem>
                <asp:ListItem>ΔΗΜΟΣΙΟ</asp:ListItem>
                <asp:ListItem>ΑΝΤΛΙΑΣ</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ Α</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ Β</asp:ListItem>
                <asp:ListItem>ΠΙΝΑΚΑΣ Α</asp:ListItem>
                <asp:ListItem>ΠΙΝΑΚΑΣ Β</asp:ListItem>
                <asp:ListItem>ΑΛΛΟΙ</asp:ListItem>
            </asp:DropDownList>
            
            <br />
            <asp:Label ID="Label8" runat="server" Text="Περιοχή" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" style="margin-right: 19px; margin-top: 16px;" Height="22px" Width="193px">
                <asp:ListItem>ΟΛΕΣ</asp:ListItem>
                <asp:ListItem>ΑΝ. ΜΑΚΕΔΟΝΙΑ &amp; ΘΡΑΚΗ</asp:ListItem>
                <asp:ListItem>ΚΕΝΤΡΙΚΗ ΜΑΚΕΔΟΝΙΑ</asp:ListItem>
                <asp:ListItem>ΔΥΤΙΚΗ ΜΑΚΕΔΟΝΙΑ</asp:ListItem>
                <asp:ListItem>ΗΠΕΙΡΟΣ</asp:ListItem>
                <asp:ListItem>ΘΕΣΣΑΛΙΑ</asp:ListItem>
                <asp:ListItem>ΙΟΝΙΟΙ ΝΗΣΟΙ</asp:ListItem>
                <asp:ListItem>ΔΥΤΙΚΗ ΕΛΛΑΔΑ</asp:ListItem>
                <asp:ListItem>ΣΤΕΡΕΑ ΕΛΛΑΔΑ</asp:ListItem>
                <asp:ListItem>ΑΤΤΙΚΗ</asp:ListItem>
                <asp:ListItem>ΠΕΛΟΠΟΝΝΗΣΟΣ</asp:ListItem>
                <asp:ListItem>ΒΟΡΕΙΟ ΑΙΓΑΙΟ</asp:ListItem>
                <asp:ListItem>ΝΟΤΙΟ ΑΙΓΑΙΟ</asp:ListItem>
                <asp:ListItem>ΚΡΗΤΗ</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" style="margin-right: 6px; margin-top: 0px; margin-bottom: 1px;" Width="193px">
            </asp:DropDownList>

        </div>
        <div class="textbox">

            <asp:Label ID="Label9" runat="server" Text="Τηλέφωνα , FAX &amp; Email" Font-Size="XX-Large" CssClass="headlabels" Font-Names="Calibri" ForeColor="#3399FF"></asp:Label>

            <br />

            <br />
            <asp:Label ID="Label11" runat="server" Text="Τηλέφωνο Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" style="margin-right: 86px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Τηλέφωνο Εργασίας 2" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" style="margin-right: 98px" CssClass="textboxes" ></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" Text="FAX Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" style="margin-left: 0px; margin-right: 48px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Τηλέφωνο Οικίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server" style="margin-right: 69px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label15" runat="server" Text="Κινητό Τηλέφωνο" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server" style="margin-right: 71px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Άλλο Τηλέφωνο" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server" style="margin-right: 63px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Email" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server" style="margin-left: 27px; margin-right: 18px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label18" runat="server" Text="Διαδικτυακή Σελίδα" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox13" runat="server" style="margin-right: 85px" CssClass="textboxes"></asp:TextBox>

        </div>
        <div class="textbox">

            <asp:Label ID="Label10" runat="server" Text="Διευθύνσεις" Font-Size="XX-Large" CssClass="headlabels" Font-Names="Calibri" ForeColor="#3399FF"></asp:Label>

            <br />
            <br />
            <asp:Label ID="Label19" runat="server" Text="Οδός Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox14" runat="server" style="margin-right: 55px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label20" runat="server" Text="Πόλη Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox15" runat="server" style="margin-right: 54px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label21" runat="server" Text="Ταχυδρομικός Κώδικας Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox16" runat="server" style="margin-right: 173px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label22" runat="server" Text="Χώρα Εργασίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox17" runat="server" style="margin-right: 56px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label23" runat="server" Text="Οδός Οικίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox18" runat="server" style="margin-right: 35px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label24" runat="server" Text="Πόλη Οικίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox19" runat="server" style="margin-right: 35px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label25" runat="server" Text="Ταχυδρομικός Κώδικας Οικίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox20" runat="server" style="margin-right: 154px" CssClass="textboxes"></asp:TextBox>
            <br />
            <asp:Label ID="Label26" runat="server" Text="Χώρα Οικίας" CssClass="labels" Height="25px" Font-Names="Calibri"></asp:Label>
            <asp:TextBox ID="TextBox21" runat="server" style="margin-right: 38px" CssClass="textboxes"></asp:TextBox>

        </div>
        <div class="textbox">

            <asp:Button ID="Button4" runat="server" Text="Αποστολή Επαφής" OnClick="Button4_Click" BackColor="#006600" ForeColor="White" Font-Names="Calibri" Height="24px" Width="128px" CssClass="button" />

            <asp:Button ID="Button1" runat="server" Text="Ενημέρωση" OnClick="Button1_Click" BackColor="#006699" ForeColor="White" Font-Names="Calibri" Height="24px" Width="99px" CssClass="button" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Αποθήκευση" BackColor="#006699" ForeColor="White" Font-Names="Calibri" Height="24px" Width="99px" CssClass="button" />
            <asp:Button ID="Button2" runat="server" Text="Διαγραφή" OnClick="Button2_Click" BackColor="Red" ForeColor="White" Font-Names="Calibri" Height="24px" Width="99px" CssClass="button" />

        </div>
    </div>
    </form>
</body>
</html>
