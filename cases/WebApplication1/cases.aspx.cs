using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebApplication1.ServiceReference1;
using WebApplication1.ServiceReference2;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
//using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Xml;
using System.Reflection;


namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string connectionString = "server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8;Convert Zero Datetime=True";
        //const string url = "192.168.1.201/cases";
        string url = WebApplication1.Class1.sqlstring;
        string eventid = "";
        string milestoneid = "";
        string caseid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                find_cases();

                eventid = Request.QueryString["eventid"];
                milestoneid = Request.QueryString["milestoneid"];
                caseid = Request.QueryString["caseid"];

                if (!string.IsNullOrEmpty(Request.Params["eventid"]))
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;

                    command.CommandText = "SELECT * FROM event where ID=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", eventid);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        event_id.Text = reader["id"].ToString();
                        event_cases.Text = reader["Cases"].ToString();
                        aiton.Text = reader["Aiton"].ToString();
                        perigrafi_event.Text = reader["Perigrafi"].ToString();

                        if (reader["date"] != DBNull.Value)
                        {
                            event_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            event_date.Text = "";
                        }
                        if (reader["Final_date"] != DBNull.Value)
                        {
                            final_date_event.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            final_date_event.Text = "";
                        }
                    }
                    reader.Close();

                    connection.Close();
                }

                if (!string.IsNullOrEmpty(Request.Params["milestoneid"]))
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;

                    command.CommandText = "SELECT * FROM milestone where ID=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", milestoneid);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        milestone_id.Text = reader["id"].ToString();
                        milestone_cases.Text = reader["Cases"].ToString();
                        aiton_milestone.Text = reader["Aiton"].ToString();
                        perigrafi_milestone.Text = reader["Perigrafi"].ToString();
                        ypeythynos.Text = reader["Yp_Ylopohsis"].ToString();

                        if (reader["date"] != DBNull.Value)
                        {
                            milestone_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            milestone_date.Text = "";
                        }
                        if (reader["Final_date"] != DBNull.Value)
                        {
                            final_date_milestone.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            final_date_milestone.Text = "";
                        }
                        if (reader["Close_date"] != DBNull.Value)
                        {
                            close_date_milestone.Text = Convert.ToDateTime(reader["Close_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            close_date_milestone.Text = "";
                        }
                    }
                    reader.Close();

                    connection.Close();
                }

                if (!string.IsNullOrEmpty(Request.Params["caseid"]))
                {

                    for (int i = 0; i < GridView1.Rows.Count - 1; i++)
                    {
                        if (GridView1.Rows[i].Cells[0].Text == caseid)
                        {
                            GridView1.SelectedIndex = i;
                        }
                    }

                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command1 = new MySqlCommand("SELECT * FROM event where Cases='" + caseid + "'", connection);

                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(command1);

                    da.Fill(dataTable);

                    GridView4.DataSource = dataTable;
                    GridView4.DataBind();

                    GridView5.DataSource = dataTable;
                    GridView5.DataBind();

                    Session["gridview5"] = dataTable;

                    MySqlCommand command2 = new MySqlCommand("SELECT * FROM milestone where Cases='" + caseid + "'", connection);

                    DataTable dataTable1 = new DataTable();
                    MySqlDataAdapter da1 = new MySqlDataAdapter(command2);

                    da1.Fill(dataTable1);

                    GridView7.DataSource = dataTable1;
                    GridView7.DataBind();

                    GridView6.DataSource = dataTable1;
                    GridView6.DataBind();

                    Session["gridview6"] = dataTable1;

                    MySqlCommand command3 = new MySqlCommand("SELECT Contact_table.ID, Contact_table.Phone_Index_ID AS Expr1, Contacts.FirstName, Contacts.LastName, Contacts.Company, Contacts.BusinessPhone,   Contacts.BusinessPhone2, Contacts.BusinessFax, Contacts.HomePhone, Contacts.MobilePhone, Contacts.OtherPhone,Contacts.EmailAddress FROM(Contact_table INNER JOIN Contacts ON Contact_table.Phone_Index_ID = Contacts.ID) Where Contact_table.Case_ID='" + caseid + "'", connection);

                    DataTable dataTable3 = new DataTable();
                    MySqlDataAdapter da3 = new MySqlDataAdapter(command3);

                    da3.Fill(dataTable3);

                    GridView2.DataSource = dataTable3;
                    GridView2.DataBind();

                    if (GridView4.Rows.Count == 0)
                    {
                        Panel8.Visible = false;
                    }
                    else
                    {
                        Panel8.Visible = true;
                    }
                    if (GridView7.Rows.Count == 0)
                    {
                        Panel9.Visible = false;
                    }
                    else
                    {
                        Panel9.Visible = true;
                    }
                    if (GridView2.Rows.Count == 0)
                    {
                        Panel2.Visible = false;
                    }
                    else
                    {
                        Panel2.Visible = true;
                    }

                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;
                    command.CommandText = "SELECT * FROM cases where ID=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", caseid);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        case_id.Text = reader["id"].ToString();
                        case_name.Text = reader["Case_Name"].ToString();
                        perigrafi.Text = reader["Perigrafi"].ToString();
                        pigi.Text = reader["Pigi"].ToString();
                        sxolia.Text = reader["Sxolia"].ToString();
                        budget.Text = reader["Budget"].ToString();
                        cost.Text = reader["Cost"].ToString();
                        sale_price.Text = reader["Sale_price"].ToString();
                        arxeio.Text = reader["arxeio"].ToString();
                        project_type.Text = reader["Project_type"].ToString();
                        offer_code.Text = reader["Offer_code"].ToString();
                        project_code.Text = reader["Project_code"].ToString();

                        if (offer_code.Text == "")
                        {
                            code.Text = project_code.Text;
                        }
                        else
                        {
                            code.Text = offer_code.Text;
                        }

                        if (reader["Creation_date"] != DBNull.Value)
                        {
                            creation_date.Text = Convert.ToDateTime(reader["Creation_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            creation_date.Text = "";
                        }
                        if (reader["Offer_date"] != DBNull.Value)
                        {
                            offer_date.Text = Convert.ToDateTime(reader["Offer_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            offer_date.Text = "";
                        }
                        if (reader["Close_date"] != DBNull.Value)
                        {
                            close_date.Text = Convert.ToDateTime(reader["Close_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            close_date.Text = "";
                        }
                        if (reader["Final_date"] != DBNull.Value)
                        {
                            final_date.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            final_date.Text = "";
                        }
                        if (reader["Finish_date"] != DBNull.Value)
                        {
                            finish_date.Text = Convert.ToDateTime(reader["Finish_date"]).ToString("yyyy/MM/dd HH:MM");
                        }
                        else
                        {
                            finish_date.Text = "";
                        }
                        //pelatis.Text = reader["Pelatis"].ToString();
                        status.Text = reader["Status"].ToString();
                        priority.Text = reader["Priority"].ToString();
                        ipeuthinos.Text = reader["Ypefthinos"].ToString();
                    }
                    reader.Close();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            find_cases();
        }

        public void find_cases()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            string query = "SELECT id,Case_Name,Perigrafi,Pigi,Sxolia,Budget,Cost,Sale_price,Creation_date,Final_date,Offer_code,Project_code,Offer_date,Close_date,Project_type,Status,Priority,Ypefthinos,Finish_date,arxeio FROM cases where 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            Session["gridview1"] = dataTable;

            connection.Close();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (e.Row.Cells.Count > 16)
                {
                    LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                    LnkHeaderText.Text = "Κωδικός";
                    LinkButton LnkHeaderText1 = e.Row.Cells[1].Controls[0] as LinkButton;
                    LnkHeaderText1.Text = "Όνομα Υπόθεσης";
                    LinkButton LnkHeaderText2 = e.Row.Cells[2].Controls[0] as LinkButton;
                    LnkHeaderText2.Text = "Περιγραφή";
                    LinkButton LnkHeaderText3 = e.Row.Cells[3].Controls[0] as LinkButton;
                    LnkHeaderText3.Text = "Πηγή";
                    LinkButton LnkHeaderText4 = e.Row.Cells[4].Controls[0] as LinkButton;
                    LnkHeaderText4.Text = "Σχόλια";
                    LinkButton LnkHeaderText5 = e.Row.Cells[5].Controls[0] as LinkButton;
                    LnkHeaderText5.Text = "Προϋπολογισμός";
                    LinkButton LnkHeaderText6 = e.Row.Cells[6].Controls[0] as LinkButton;
                    LnkHeaderText6.Text = "Κόστος";
                    LinkButton LnkHeaderText7 = e.Row.Cells[7].Controls[0] as LinkButton;
                    LnkHeaderText7.Text = "Τιμή Πώλησης";
                    LinkButton LnkHeaderText10 = e.Row.Cells[8].Controls[0] as LinkButton;
                    LnkHeaderText10.Text = "Ημερομηνία Δημιουργίας";
                    LinkButton LnkHeaderText11 = e.Row.Cells[9].Controls[0] as LinkButton;
                    LnkHeaderText11.Text = "Τελική Ημερομηνία";
                    LinkButton LnkHeaderText13 = e.Row.Cells[10].Controls[0] as LinkButton;
                    LnkHeaderText13.Text = "Κωδικός Προσφοράς";
                    LinkButton LnkHeaderText14 = e.Row.Cells[11].Controls[0] as LinkButton;
                    LnkHeaderText14.Text = "Κωδικός Σχεδίου";
                    LinkButton LnkHeaderText15 = e.Row.Cells[12].Controls[0] as LinkButton;
                    LnkHeaderText15.Text = "Ημερομηνία Προσφοράς";
                    LinkButton LnkHeaderText16 = e.Row.Cells[13].Controls[0] as LinkButton;
                    LnkHeaderText16.Text = "Καταληκτική Ημερομηνία";
                    LinkButton LnkHeaderText17 = e.Row.Cells[14].Controls[0] as LinkButton;
                    LnkHeaderText17.Text = "Τύπος Σχεδίου";
                    LinkButton LnkHeaderText18 = e.Row.Cells[15].Controls[0] as LinkButton;
                    LnkHeaderText18.Text = "Κατάσταση";
                    LinkButton LnkHeaderText19 = e.Row.Cells[16].Controls[0] as LinkButton;
                    LnkHeaderText19.Text = "Προτεραιότητα";
                    LinkButton LnkHeaderText20 = e.Row.Cells[17].Controls[0] as LinkButton;
                    LnkHeaderText20.Text = "Υπεύθυνος";
                    LinkButton LnkHeaderText21 = e.Row.Cells[18].Controls[0] as LinkButton;
                    LnkHeaderText21.Text = "Ημερομηνία Τερματισμού";
                    LinkButton LnkHeaderText22 = e.Row.Cells[19].Controls[0] as LinkButton;
                    LnkHeaderText22.Text = "Αρχείο";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells.Count > 8)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
                else if (e.Row.Cells.Count > 6)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
                else
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.Cells.Count > 8)
            {
                int index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.SelectedRow.Cells[1].Text;
                string surname = GridView1.SelectedRow.Cells[2].Text;
                int uid = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;

                command.CommandText = "SELECT * FROM cases where ID=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", uid);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    case_id.Text = reader["id"].ToString();
                    case_name.Text = reader["Case_Name"].ToString();
                    perigrafi.Text = reader["Perigrafi"].ToString();
                    pigi.Text = reader["Pigi"].ToString();
                    sxolia.Text = reader["Sxolia"].ToString();
                    budget.Text = reader["Budget"].ToString();
                    cost.Text = reader["Cost"].ToString();
                    sale_price.Text = reader["Sale_price"].ToString();
                    arxeio.Text = reader["arxeio"].ToString();
                    project_type.Text = reader["Project_type"].ToString();
                    offer_code.Text = reader["Offer_code"].ToString();
                    project_code.Text = reader["Project_code"].ToString();

                    if (offer_code.Text == "")
                    {
                        code.Text = project_code.Text;
                    }
                    else
                    {
                        code.Text = offer_code.Text;
                    }

                    if (reader["Creation_date"] != DBNull.Value)
                    {
                        creation_date.Text = Convert.ToDateTime(reader["Creation_date"]).ToString("yyyy/MM/dd HH:MM");
                    }
                    else
                    {
                        creation_date.Text = "";
                    }
                    if (reader["Offer_date"] != DBNull.Value)
                    {
                        offer_date.Text = Convert.ToDateTime(reader["Offer_date"]).ToString("yyyy/MM/dd HH:MM");
                    }
                    else
                    {
                        offer_date.Text = "";
                    }
                    if (reader["Close_date"] != DBNull.Value)
                    {
                        close_date.Text = Convert.ToDateTime(reader["Close_date"]).ToString("yyyy/MM/dd HH:MM");
                    }
                    else
                    {
                        close_date.Text = "";
                    }
                    if (reader["Final_date"] != DBNull.Value)
                    {
                        final_date.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                    }
                    else
                    {
                        final_date.Text = "";
                    }
                    if (reader["Finish_date"] != DBNull.Value)
                    {
                        finish_date.Text = Convert.ToDateTime(reader["Finish_date"]).ToString("yyyy/MM/dd HH:MM");
                    }
                    else
                    {
                        finish_date.Text = "";
                    }
                    //pelatis.Text = reader["Pelatis"].ToString();
                    status.Text = reader["Status"].ToString();
                    priority.Text = reader["Priority"].ToString();
                    ipeuthinos.Text = reader["Ypefthinos"].ToString();
                }
                reader.Close();

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM event where Cases='" + uid.ToString() + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView4.DataSource = dataTable;
                GridView4.DataBind();

                GridView5.DataSource = dataTable;
                GridView5.DataBind();

                Session["gridview5"] = dataTable;

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM milestone where Cases='" + uid.ToString() + "'", connection);

                DataTable dataTable1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(command2);

                da1.Fill(dataTable1);

                GridView7.DataSource = dataTable1;
                GridView7.DataBind();

                GridView6.DataSource = dataTable1;
                GridView6.DataBind();

                Session["gridview6"] = dataTable1;

                MySqlCommand command3 = new MySqlCommand("SELECT Contact_table.ID, Contact_table.Phone_Index_ID AS Expr1, Contacts.FirstName, Contacts.LastName, Contacts.Company, Contacts.BusinessPhone,   Contacts.BusinessPhone2, Contacts.BusinessFax, Contacts.HomePhone, Contacts.MobilePhone, Contacts.OtherPhone,Contacts.EmailAddress FROM(Contact_table INNER JOIN Contacts ON Contact_table.Phone_Index_ID = Contacts.ID) Where Contact_table.Case_ID='" + uid.ToString() + "'", connection);

                DataTable dataTable3 = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(command3);

                da3.Fill(dataTable3);

                GridView2.DataSource = dataTable3;
                GridView2.DataBind();

                if (GridView4.Rows.Count == 0)
                {
                    Panel8.Visible = false;
                }
                else
                {
                    Panel8.Visible = true;
                }
                if (GridView7.Rows.Count == 0)
                {
                    Panel9.Visible = false;
                }
                else
                {
                    Panel9.Visible = true;
                }
                if (GridView2.Rows.Count == 0)
                {
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }

                //MySqlCommand command4 = new MySqlCommand("SELECT ID,FirstName,LastName,Company FROM contacts", connection);

                //DataTable dataTable4 = new DataTable();
                //MySqlDataAdapter da4 = new MySqlDataAdapter(command4);

                //da4.Fill(dataTable4);

                //GridView3.DataSource = dataTable4;
                //GridView3.DataBind();

                foreach (Control control in Panel3.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }
                }

                foreach (Control control in Panel5.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }
                }

                connection.Close();

                Panel1.Visible = true;

                Session["tab"] = "cases";
                if (Request.QueryString["eventid"] != null || Request.QueryString["milestoneid"] != null || Request.QueryString["caseid"] != null)
                {
                    PropertyInfo Isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

                    Isreadonly.SetValue(Request.QueryString, false, null);

                    Request.QueryString.Clear();
                }

            }
            else if (GridView1.SelectedRow.Cells.Count > 6)
            {
                int index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.SelectedRow.Cells[0].Text;
                string surname = GridView1.SelectedRow.Cells[1].Text;
                string uid = GridView1.SelectedRow.Cells[0].Text;
            }
            else
            {
                int index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.SelectedRow.Cells[0].Text;
                string surname = GridView1.SelectedRow.Cells[1].Text;
                string uid = GridView1.SelectedRow.Cells[0].Text;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            find_events();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }

        public void find_events()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM event where 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            connection.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            find_milestones();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }

        public void find_milestones()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM milestone where 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            connection.Close();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells.Count > 8)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
                else if (e.Row.Cells.Count > 6)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
                else
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells.Count > 8)
                {
                    e.Row.Cells[0].ToolTip = "Κωδικός";
                    e.Row.Cells[1].ToolTip = "Όνομα Υπόθεσης";
                    e.Row.Cells[2].ToolTip = "Περιγραφή";
                    e.Row.Cells[3].ToolTip = "Πηγή";
                    e.Row.Cells[4].ToolTip = "Σχόλια";
                    e.Row.Cells[5].ToolTip = "Προϋπολογισμός";
                    e.Row.Cells[6].ToolTip = "Κόστος";
                    e.Row.Cells[7].ToolTip = "Τιμή Πώλησης";
                    e.Row.Cells[8].ToolTip = "Ημερομηνία Δημιουργίας";
                    e.Row.Cells[9].ToolTip = "Τελική Ημερομηνία";
                    e.Row.Cells[10].ToolTip = "Κωδικός Προσφοράς";
                    e.Row.Cells[11].ToolTip = "Κωδικός Σχεδίου";
                    e.Row.Cells[12].ToolTip = "Ημερομηνία Προσφοράς";
                    e.Row.Cells[13].ToolTip = "Καταληκτική Ημερομηνία";
                    e.Row.Cells[14].ToolTip = "Τύπος Σχεδίου";
                    e.Row.Cells[15].ToolTip = "Κατάσταση";
                    e.Row.Cells[16].ToolTip = "Προτεραιότητα";
                    e.Row.Cells[17].ToolTip = "Υπεύθυνος";
                    e.Row.Cells[18].ToolTip = "Ημερομηνία Τερματισμού";
                    e.Row.Cells[19].ToolTip = "Αρχείο";
                }
                else if (e.Row.Cells.Count > 6)
                {
                    e.Row.Cells[0].ToolTip = "Κωδικός";
                    e.Row.Cells[1].ToolTip = "Ημερομηνία";
                    e.Row.Cells[2].ToolTip = "Υπόθεση";
                    e.Row.Cells[3].ToolTip = "Αιτών";
                    e.Row.Cells[4].ToolTip = "Υπεύθυνος Υλοποίησης";
                    e.Row.Cells[5].ToolTip = "Περιγραφή";
                    e.Row.Cells[6].ToolTip = "Τελική Ημερομηνία";
                    e.Row.Cells[7].ToolTip = "Καταληκτική Ημερομηνία";
                }
                else
                {
                    e.Row.Cells[0].ToolTip = "Κωδικός";
                    e.Row.Cells[1].ToolTip = "Ημερομηνία";
                    e.Row.Cells[2].ToolTip = "Υπόθεση";
                    e.Row.Cells[3].ToolTip = "Αιτών";
                    e.Row.Cells[4].ToolTip = "Περιγραφή";
                    e.Row.Cells[5].ToolTip = "Τελική Ημερομηνία";
                }
            }
        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (case_name.Text != "" && perigrafi.Text != "" && project_type.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;

                command.CommandText = "SELECT * FROM cases where Case_Name=@p21";
                command.Prepare();
                command.Parameters.AddWithValue("@p21", case_name.Text);
                reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();


                    command.CommandText = "INSERT into cases(Case_Name,Perigrafi,Pigi,Sxolia,Budget,Cost,Sale_price,Creation_date,Final_date,Offer_code,Project_code,Offer_date,Close_date,Project_type,Status,Priority,Ypefthinos,Finish_date,arxeio) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20)";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", case_name.Text);
                    command.Parameters.AddWithValue("@p2", perigrafi.Text);
                    command.Parameters.AddWithValue("@p3", pigi.Text);
                    command.Parameters.AddWithValue("@p4", sxolia.Text);
                    command.Parameters.AddWithValue("@p5", budget.Text);
                    command.Parameters.AddWithValue("@p6", cost.Text);
                    command.Parameters.AddWithValue("@p7", sale_price.Text);
                    //command.Parameters.AddWithValue("@p8", pelatis.Text);
                    command.Parameters.AddWithValue("@p9", creation_date.Text);
                    command.Parameters.AddWithValue("@p10", final_date.Text);
                    command.Parameters.AddWithValue("@p11", offer_code.Text);
                    command.Parameters.AddWithValue("@p12", project_code.Text);
                    command.Parameters.AddWithValue("@p13", offer_date.Text);
                    command.Parameters.AddWithValue("@p14", close_date.Text);
                    command.Parameters.AddWithValue("@p15", project_type.Text);
                    command.Parameters.AddWithValue("@p16", status.Text);
                    command.Parameters.AddWithValue("@p17", priority.Text);
                    command.Parameters.AddWithValue("@p18", ipeuthinos.Text);
                    command.Parameters.AddWithValue("@p19", finish_date.Text);
                    command.Parameters.AddWithValue("@p20", arxeio.Text);
                    command.ExecuteNonQuery();

                    if (offer_code.Text != "" || project_code.Text != "")
                    {
                        command.CommandText = "INSERT into codes(Cases,Code) values (@p24,@p25)";
                        command.Prepare();
                        command.Parameters.AddWithValue("@p24", case_name.Text);
                        if (offer_code.Text != "")
                        {
                            command.Parameters.AddWithValue("@p25", offer_code.Text);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@p25", project_code.Text);
                        }
                        command.ExecuteNonQuery();
                    }

                    connection.Close();

                    foreach (Control control in Panel1.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox txt = (TextBox)control;
                            txt.Text = "";
                        }


                    }

                    find_cases();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Εισαγωγή')", true);
                }
                else
                {
                    reader.Close();
                    connection.Close();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Το Όνομα Υπόθεσης υπάρχει ήδη. Δώστε διαφορετικό Όνομα')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }

            Session["tab"] = "cases";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (case_name.Text != "" && perigrafi.Text != "" && project_type.Text != "" && GridView1.SelectedRow != null)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;

                if (case_name.Text != GridView1.SelectedRow.Cells[1].Text)
                {
                    command.CommandText = "SELECT * FROM cases where Case_Name=@p21";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p21", case_name.Text);
                    reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();

                        command.CommandText = "UPDATE cases SET Case_Name=@p1, Perigrafi=@p2, Pigi=@p3, Sxolia=@p4, Budget=@p5, Cost=@p6, Sale_price=@p7, Creation_date=@p9, Final_date=@p10, Offer_code=@p11, Project_code=@p12, Offer_date=@p13, Close_date=@p14, Project_type=@p15, Status=@p16, Priority=@p17, Ypefthinos=@p18, Finish_date=@p19, arxeio=@p20 WHERE ID=@p21";
                        command.Prepare();
                        command.Parameters.AddWithValue("@p1", case_name.Text);
                        command.Parameters.AddWithValue("@p2", perigrafi.Text);
                        command.Parameters.AddWithValue("@p3", pigi.Text);
                        command.Parameters.AddWithValue("@p4", sxolia.Text);
                        command.Parameters.AddWithValue("@p5", budget.Text);
                        command.Parameters.AddWithValue("@p6", cost.Text);
                        command.Parameters.AddWithValue("@p7", sale_price.Text);
                        //command.Parameters.AddWithValue("@p8", pelatis.Text);
                        command.Parameters.AddWithValue("@p9", creation_date.Text);
                        command.Parameters.AddWithValue("@p10", final_date.Text);
                        command.Parameters.AddWithValue("@p11", offer_code.Text);
                        command.Parameters.AddWithValue("@p12", project_code.Text);
                        command.Parameters.AddWithValue("@p13", offer_date.Text);
                        command.Parameters.AddWithValue("@p14", close_date.Text);
                        command.Parameters.AddWithValue("@p15", project_type.Text);
                        command.Parameters.AddWithValue("@p16", status.Text);
                        command.Parameters.AddWithValue("@p17", priority.Text);
                        command.Parameters.AddWithValue("@p18", ipeuthinos.Text);
                        command.Parameters.AddWithValue("@p19", finish_date.Text);
                        command.Parameters.AddWithValue("@p20", arxeio.Text);
                        command.Parameters.AddWithValue("@p21", case_id.Text);
                        command.ExecuteNonQuery();

                        command.CommandText = "SELECT * FROM codes where Cases=@p22";
                        command.Prepare();
                        command.Parameters.AddWithValue("@p22", case_name.Text);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            reader.Close();

                            command.CommandText = "DELETE FROM codes WHERE Cases=@p23";
                            command.Prepare();
                            command.Parameters.AddWithValue("@p23", case_name.Text);
                            command.ExecuteNonQuery();

                            if (offer_code.Text != "" || project_code.Text != "")
                            {
                                command.CommandText = "INSERT into codes(Cases,Code) values (@p24,@p25)";
                                command.Prepare();
                                command.Parameters.AddWithValue("@p24", case_name.Text);
                                if (offer_code.Text != "")
                                {
                                    command.Parameters.AddWithValue("@p25", offer_code.Text);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@p25", project_code.Text);
                                }
                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            reader.Close();
                            if (offer_code.Text != "" || project_code.Text != "")
                            {
                                command.CommandText = "INSERT into codes(Cases,Code) values (@p24,@p25)";
                                command.Prepare();
                                command.Parameters.AddWithValue("@p24", case_name.Text);
                                if (offer_code.Text != "")
                                {
                                    command.Parameters.AddWithValue("@p25", offer_code.Text);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@p25", project_code.Text);
                                }
                                command.ExecuteNonQuery();
                            }
                        }

                        connection.Close();

                        foreach (Control control in Panel1.Controls)
                        {
                            if (control is TextBox)
                            {
                                TextBox txt = (TextBox)control;
                                txt.Text = "";
                            }


                        }

                        find_cases();

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Ενημέρωση')", true);
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Το Όνομα Υπόθεσης υπάρχει ήδη. Δώστε διαφορετικό Όνομα')", true);
                    }
                }
                else
                {
                    command.CommandText = "UPDATE cases SET Case_Name=@p1, Perigrafi=@p2, Pigi=@p3, Sxolia=@p4, Budget=@p5, Cost=@p6, Sale_price=@p7, Creation_date=@p9, Final_date=@p10, Offer_code=@p11, Project_code=@p12, Offer_date=@p13, Close_date=@p14, Project_type=@p15, Status=@p16, Priority=@p17, Ypefthinos=@p18, Finish_date=@p19, arxeio=@p20 WHERE ID=@p21";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", case_name.Text);
                    command.Parameters.AddWithValue("@p2", perigrafi.Text);
                    command.Parameters.AddWithValue("@p3", pigi.Text);
                    command.Parameters.AddWithValue("@p4", sxolia.Text);
                    command.Parameters.AddWithValue("@p5", budget.Text);
                    command.Parameters.AddWithValue("@p6", cost.Text);
                    command.Parameters.AddWithValue("@p7", sale_price.Text);
                    //command.Parameters.AddWithValue("@p8", pelatis.Text);
                    command.Parameters.AddWithValue("@p9", creation_date.Text);
                    command.Parameters.AddWithValue("@p10", final_date.Text);
                    command.Parameters.AddWithValue("@p11", offer_code.Text);
                    command.Parameters.AddWithValue("@p12", project_code.Text);
                    command.Parameters.AddWithValue("@p13", offer_date.Text);
                    command.Parameters.AddWithValue("@p14", close_date.Text);
                    command.Parameters.AddWithValue("@p15", project_type.Text);
                    command.Parameters.AddWithValue("@p16", status.Text);
                    command.Parameters.AddWithValue("@p17", priority.Text);
                    command.Parameters.AddWithValue("@p18", ipeuthinos.Text);
                    command.Parameters.AddWithValue("@p19", finish_date.Text);
                    command.Parameters.AddWithValue("@p20", arxeio.Text);
                    command.Parameters.AddWithValue("@p21", case_id.Text);
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT * FROM codes where Cases=@p22";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p22", case_name.Text);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();

                        command.CommandText = "DELETE FROM codes WHERE Cases=@p23";
                        command.Prepare();
                        command.Parameters.AddWithValue("@p23", case_name.Text);
                        command.ExecuteNonQuery();

                        if (offer_code.Text != "" || project_code.Text != "")
                        {
                            command.CommandText = "INSERT into codes(Cases,Code) values (@p24,@p25)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@p24", case_name.Text);
                            if (offer_code.Text != "")
                            {
                                command.Parameters.AddWithValue("@p25", offer_code.Text);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@p25", project_code.Text);
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        reader.Close();
                        if (offer_code.Text != "" || project_code.Text != "")
                        {
                            command.CommandText = "INSERT into codes(Cases,Code) values (@p24,@p25)";
                            command.Prepare();
                            command.Parameters.AddWithValue("@p24", case_name.Text);
                            if (offer_code.Text != "")
                            {
                                command.Parameters.AddWithValue("@p25", offer_code.Text);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@p25", project_code.Text);
                            }
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();

                    foreach (Control control in Panel1.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox txt = (TextBox)control;
                            txt.Text = "";
                        }


                    }

                    find_cases();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Ενημέρωση')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }
            Session["tab"] = "cases";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ναι")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM cases WHERE ID=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", case_id.Text);
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM contact_table WHERE Case_ID=@p2";
                command.Prepare();
                command.Parameters.AddWithValue("@p2", case_id.Text);
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM codes WHERE Cases=@p3";
                command.Prepare();
                command.Parameters.AddWithValue("@p3", code.Text);
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM event WHERE Cases=@p4";
                command.Prepare();
                command.Parameters.AddWithValue("@p4", case_id.Text);
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM milestone WHERE Cases=@p5";
                command.Prepare();
                command.Parameters.AddWithValue("@p5", case_id.Text);
                command.ExecuteNonQuery();

                connection.Close();

                foreach (Control control in Panel1.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }

                foreach (Control control in Panel3.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }

                foreach (Control control in Panel5.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }

                GridView1.SelectedIndex = -1;
                GridView2.SelectedIndex = -1;
                GridView3.SelectedIndex = -1;
                GridView5.SelectedIndex = -1;
                GridView6.SelectedIndex = -1;
                GridView4.SelectedIndex = -1;
                GridView7.SelectedIndex = -1;

                GridView2.DataSource = null;
                GridView2.DataBind();

                GridView5.DataSource = null;
                GridView5.DataBind();

                GridView6.DataSource = null;
                GridView6.DataBind();

                GridView4.DataSource = null;
                GridView4.DataBind();

                GridView7.DataSource = null;
                GridView7.DataBind();

                find_cases();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Διαγραφή')", true);
            }
            Session["tab"] = "cases";
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            offer_code.Text = getcode("300");
            Session["tab"] = "cases";
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            offer_code.Text = getcode("350");
            Session["tab"] = "cases";
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            project_code.Text = getcode("500");
            Session["tab"] = "cases";
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            project_code.Text = getcode("550");
            Session["tab"] = "cases";
        }

        public string getcode(string code)
        {
            string getnextcode, lastcode = "";
            string shortyear = DateTime.Today.Year.ToString();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand("SELECT ID FROM codes WHERE Code LIKE '" + code + "%' ORDER BY Code DESC LIMIT 0,1", connection);
            MySqlDataReader reader;
            connection.Open();

            string maxid = command.ExecuteScalar().ToString();

            if (maxid == "")
            {
                getnextcode = code + "." + shortyear.Remove(0, 2) + ".1";
            }
            else
            {
                command.CommandText = "SELECT * FROM codes where ID=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", maxid);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lastcode = reader["Code"].ToString();
                }
                reader.Close();

                if (lastcode.Substring(4, 2) != shortyear.Remove(0, 2))
                {
                    getnextcode = code + "." + shortyear.Remove(0, 2) + ".1";

                }
                else
                {
                    int c = Int32.Parse(lastcode.Remove(0, 7)) + 1;
                    getnextcode = code + "." + shortyear.Remove(0, 2) + "." + c;

                }
            }

            connection.Close();

            return getnextcode;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            foreach (Control control in Panel1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (event_date.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT into event(date,Cases,Aiton,Perigrafi,final_date) values (@p1,@p2,@p3,@p4,@p5)";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", event_date.Text);
                command.Parameters.AddWithValue("@p2", GridView1.SelectedRow.Cells[0].Text);
                command.Parameters.AddWithValue("@p3", aiton.Text);
                command.Parameters.AddWithValue("@p4", perigrafi_event.Text);
                command.Parameters.AddWithValue("@p5", final_date_event.Text);
                command.ExecuteNonQuery();

                foreach (Control control in Panel3.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM event where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView4.DataSource = dataTable;
                GridView4.DataBind();

                GridView5.DataSource = dataTable;
                GridView5.DataBind();

                connection.Close();

                if (GridView4.Rows.Count == 0)
                {
                    Panel8.Visible = false;
                }
                else
                {
                    Panel8.Visible = true;
                }
                if (GridView7.Rows.Count == 0)
                {
                    Panel9.Visible = false;
                }
                else
                {
                    Panel9.Visible = true;
                }
                if (GridView2.Rows.Count == 0)
                {
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Εισαγωγή')", true);
                //*ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#clos*/e_date_milestone').datetimepicker();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }
            Session["tab"] = "event";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (event_date.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE event SET date=@p1,Aiton=@p3, Perigrafi=@p4, final_date=@p5 WHERE ID=@p21";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", event_date.Text);
                command.Parameters.AddWithValue("@p3", aiton.Text);
                command.Parameters.AddWithValue("@p4", perigrafi_event.Text);
                command.Parameters.AddWithValue("@p5", final_date_event.Text);
                command.Parameters.AddWithValue("@p21", event_id.Text);
                command.ExecuteNonQuery();

                connection.Close();

                foreach (Control control in Panel3.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM event where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView4.DataSource = dataTable;
                GridView4.DataBind();

                GridView5.DataSource = dataTable;
                GridView5.DataBind();

                connection.Close();

                

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Ενημέρωση')", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }
            Session["tab"] = "event";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //if (GridView5.SelectedRow != null)
            //{
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ναι")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM event WHERE ID=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", event_id.Text);
                command.ExecuteNonQuery();

                connection.Close();

                foreach (Control control in Panel3.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM event where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView4.DataSource = dataTable;
                GridView4.DataBind();

                GridView5.DataSource = dataTable;
                GridView5.DataBind();

                connection.Close();

               

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Διαγραφή')", true);
            }
            Session["tab"] = "event";
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
            //}
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            foreach (Control control in Panel3.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }
            }

            Session["tab"] = "event";
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            if (milestone_date.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT into milestone(date,Cases,Aiton,Yp_Ylopohsis,Perigrafi,Final_date,Close_date) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", milestone_date.Text);
                command.Parameters.AddWithValue("@p2", GridView1.SelectedRow.Cells[0].Text);
                command.Parameters.AddWithValue("@p3", aiton_milestone.Text);
                command.Parameters.AddWithValue("@p4", ypeythynos.Text);
                command.Parameters.AddWithValue("@p5", perigrafi_milestone.Text);
                command.Parameters.AddWithValue("@p6", final_date_milestone.Text);
                command.Parameters.AddWithValue("@p7", close_date_milestone.Text);
                command.ExecuteNonQuery();

                foreach (Control control in Panel5.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }


                }
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM milestone where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView6.DataSource = dataTable;
                GridView6.DataBind();

                GridView7.DataSource = dataTable;
                GridView7.DataBind();

                connection.Close();

                if (GridView4.Rows.Count == 0)
                {
                    Panel8.Visible = false;
                }
                else
                {
                    Panel8.Visible = true;
                }
                if (GridView7.Rows.Count == 0)
                {
                    Panel9.Visible = false;
                }
                else
                {
                    Panel9.Visible = true;
                }
                if (GridView2.Rows.Count == 0)
                {
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }

                

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Εισαγωγή')", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }
            Session["tab"] = "milestone";
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            if (milestone_date.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE milestone SET date=@p1, Aiton=@p3, Yp_Ylopohsis=@p4, Perigrafi=@p5, Final_date=@p6, Close_date=@p7 WHERE ID=@p21";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", milestone_date.Text);
                command.Parameters.AddWithValue("@p3", aiton_milestone.Text);
                command.Parameters.AddWithValue("@p4", ypeythynos.Text);
                command.Parameters.AddWithValue("@p5", perigrafi_milestone.Text);
                command.Parameters.AddWithValue("@p6", final_date_milestone.Text);
                command.Parameters.AddWithValue("@p7", close_date_milestone.Text);
                command.Parameters.AddWithValue("@p21", milestone_id.Text);
                command.ExecuteNonQuery();

                connection.Close();

                foreach (Control control in Panel5.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }
                }

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM milestone where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView6.DataSource = dataTable;
                GridView6.DataBind();

                GridView7.DataSource = dataTable;
                GridView7.DataBind();

                connection.Close();

               

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Ενημέρωση')", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
            }
            Session["tab"] = "milestone";
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            //if (GridView6.SelectedRow != null)
            //{
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ναι")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "DELETE FROM milestone WHERE ID=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", milestone_id.Text);
                command.ExecuteNonQuery();

                connection.Close();

                foreach (Control control in Panel5.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = "";
                    }
                }

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM milestone where Cases='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command1);

                da.Fill(dataTable);

                GridView6.DataSource = dataTable;
                GridView6.DataBind();

                GridView7.DataSource = dataTable;
                GridView7.DataBind();

                connection.Close();

                

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Διαγραφή')", true);
            }
            Session["tab"] = "milestone";
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
            //}
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            foreach (Control control in Panel5.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }
            }

            Session["tab"] = "milestone";
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView5.SelectedRow.RowIndex;
            string name = GridView5.SelectedRow.Cells[1].Text;
            string surname = GridView5.SelectedRow.Cells[2].Text;
            int uid = Convert.ToInt32(GridView5.SelectedRow.Cells[0].Text);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM event where ID=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", uid);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                event_id.Text = reader["id"].ToString();
                aiton.Text = reader["Aiton"].ToString();
                perigrafi_event.Text = reader["Perigrafi"].ToString();

                if (reader["date"] != DBNull.Value)
                {
                    event_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    event_date.Text = "";
                }
                if (reader["Final_date"] != DBNull.Value)
                {
                    final_date_event.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    final_date_event.Text = "";
                }
            }
            reader.Close();

            connection.Close();

            Session["tab"] = "event";
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
        }

        protected void GridView5_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Γεγονότα";
                HeaderCell.ColumnSpan = 7;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView5.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView5, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                e.Row.Cells[0].ToolTip = "Κωδικός";
                e.Row.Cells[1].ToolTip = "Ημερομηνία";
                e.Row.Cells[2].ToolTip = "Υπόθεση";
                e.Row.Cells[3].ToolTip = "Αιτών";
                e.Row.Cells[4].ToolTip = "Περιγραφή";
                e.Row.Cells[5].ToolTip = "Τελική Ημερομηνία";
            }
            
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                LnkHeaderText.Text = "Κωδικός";
                LinkButton LnkHeaderText1 = e.Row.Cells[1].Controls[0] as LinkButton;
                LnkHeaderText1.Text = "Ημερομηνία";
                LinkButton LnkHeaderText2 = e.Row.Cells[2].Controls[0] as LinkButton;
                LnkHeaderText2.Text = "Υπόθεση";
                LinkButton LnkHeaderText3 = e.Row.Cells[3].Controls[0] as LinkButton;
                LnkHeaderText3.Text = "Αιτών";
                LinkButton LnkHeaderText5 = e.Row.Cells[4].Controls[0] as LinkButton;
                LnkHeaderText5.Text = "Περιγραφή";
                LinkButton LnkHeaderText6 = e.Row.Cells[5].Controls[0] as LinkButton;
                LnkHeaderText6.Text = "Τελική Ημερομηνία";
            }
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView6.SelectedRow.RowIndex;
            string name = GridView6.SelectedRow.Cells[1].Text;
            string surname = GridView6.SelectedRow.Cells[2].Text;
            int uid = Convert.ToInt32(GridView6.SelectedRow.Cells[0].Text);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM milestone where ID=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", uid);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                milestone_id.Text = reader["id"].ToString();
                milestone_cases.Text = reader["Cases"].ToString();
                aiton_milestone.Text = reader["Aiton"].ToString();
                perigrafi_milestone.Text = reader["Perigrafi"].ToString();
                ypeythynos.Text = reader["Yp_Ylopohsis"].ToString();

                if (reader["date"] != DBNull.Value)
                {
                    milestone_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    milestone_date.Text = "";
                }
                if (reader["Final_date"] != DBNull.Value)
                {
                    final_date_milestone.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    final_date_milestone.Text = "";
                }
                if (reader["Close_date"] != DBNull.Value)
                {
                    close_date_milestone.Text = Convert.ToDateTime(reader["Close_date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    close_date_milestone.Text = "";
                }
            }
            reader.Close();

            connection.Close();

            Session["tab"] = "milestone";

            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "txtdate", "$('#event_date').datetimepicker();$('#final_date_event').datetimepicker();$('#milestone_date').datetimepicker();$('#final_date_milestone').datetimepicker();$('#close_date_milestone').datetimepicker();", true);
        }

        protected void GridView6_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Ορόσημα";
                HeaderCell.ColumnSpan = 8;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView6.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView6, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                e.Row.Cells[0].ToolTip = "Κωδικός";
                e.Row.Cells[1].ToolTip = "Ημερομηνία";
                e.Row.Cells[2].ToolTip = "Υπόθεση";
                e.Row.Cells[3].ToolTip = "Αιτών";
                e.Row.Cells[4].ToolTip = "Υπεύθυνος Υλοποίησης";
                e.Row.Cells[5].ToolTip = "Περιγραφή";
                e.Row.Cells[6].ToolTip = "Τελική Ημερομηνία";
                e.Row.Cells[7].ToolTip = "Καταληκτική Ημερομηνία";
            }
            
        }

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                LnkHeaderText.Text = "Κωδικός";
                LinkButton LnkHeaderText1 = e.Row.Cells[1].Controls[0] as LinkButton;
                LnkHeaderText1.Text = "Ημερομηνία";
                LinkButton LnkHeaderText2 = e.Row.Cells[2].Controls[0] as LinkButton;
                LnkHeaderText2.Text = "Υπόθεση";
                LinkButton LnkHeaderText3 = e.Row.Cells[3].Controls[0] as LinkButton;
                LnkHeaderText3.Text = "Αιτών";
                LinkButton LnkHeaderText4 = e.Row.Cells[4].Controls[0] as LinkButton;
                LnkHeaderText4.Text = "Υπεύθυνος Υλοποίησης";
                LinkButton LnkHeaderText5 = e.Row.Cells[5].Controls[0] as LinkButton;
                LnkHeaderText5.Text = "Περιγραφή";
                LinkButton LnkHeaderText6 = e.Row.Cells[6].Controls[0] as LinkButton;
                LnkHeaderText6.Text = "Τελική Ημερομηνία";
                LinkButton LnkHeaderText7 = e.Row.Cells[7].Controls[0] as LinkButton;
                LnkHeaderText7.Text = "Καταληκτική Ημερομηνία";
            }
            
        }

        protected void case_click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;

            Session["tab"] = "cases";

            Response.Redirect("http://"+ url +"/cases.aspx?caseid=" + button.ID);
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Πελάτες";
                HeaderCell.ColumnSpan = 6;
                HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView2.Controls[0].Controls.AddAt(0, HeaderGridRow);

                e.Row.Cells[1].ToolTip = "Κωδικός Πελάτη";
                e.Row.Cells[2].ToolTip = "Κωδικός Επαφής";
                e.Row.Cells[3].ToolTip = "Όνομα";
                e.Row.Cells[4].ToolTip = "Επώνυμο";
                e.Row.Cells[5].ToolTip = "Εταιρεία";
                e.Row.Cells[6].ToolTip = "Τηλέφωνο Εργασίας";
                e.Row.Cells[7].ToolTip = "Τηλέφωνο Εργασίας 2";
                e.Row.Cells[8].ToolTip = "Fax Εργασίας";
                e.Row.Cells[9].ToolTip = "Τηλέφωνο Οικίας";
                e.Row.Cells[10].ToolTip = "Κινητό Τηλέφωνο";
                e.Row.Cells[11].ToolTip = "Άλλα Τηλέφωνα";
                e.Row.Cells[12].ToolTip = "Email";
            }
        }

        protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Αναζήτηση Επαφών";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView3.Controls[0].Controls.AddAt(0, HeaderGridRow);

                e.Row.Cells[1].ToolTip = "Κωδικός Επαφής";
                e.Row.Cells[2].ToolTip = "Όνομα";
                e.Row.Cells[3].ToolTip = "Επώνυμο";
                e.Row.Cells[4].ToolTip = "Εταιρεία";
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["gridview1"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = Session["gridview1"];
                GridView1.DataBind();
            }

            foreach (Control control in Panel1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }


            }

            foreach (Control control in Panel3.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }


            }

            foreach (Control control in Panel5.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }


            }

            GridView1.SelectedIndex = -1;
            GridView2.SelectedIndex = -1;
            GridView3.SelectedIndex = -1;
            GridView5.SelectedIndex = -1;
            GridView6.SelectedIndex = -1;
            GridView4.SelectedIndex = -1;
            GridView7.SelectedIndex = -1;

            GridView2.DataSource = null;
            GridView2.DataBind();

            GridView5.DataSource = null;
            GridView5.DataBind();

            GridView6.DataSource = null;
            GridView6.DataBind();

            GridView4.DataSource = null;
            GridView4.DataBind();

            GridView7.DataSource = null;
            GridView7.DataBind();
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void case_name_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Κωδικός Πελάτη";
                e.Row.Cells[2].Text = "Κωδικός Επαφής";
                e.Row.Cells[3].Text = "Όνομα";
                e.Row.Cells[4].Text = "Επώνυμο";
                e.Row.Cells[5].Text = "Εταιρεία";
                e.Row.Cells[6].Text = "Τηλέφωνο Εργασίας";
                e.Row.Cells[7].Text = "Τηλέφωνο Εργασίας 2";
                e.Row.Cells[8].Text = "Fax Εργασίας";
                e.Row.Cells[9].Text = "Τηλέφωνο Οικίας";
                e.Row.Cells[10].Text = "Κινητό Τηλέφωνο";
                e.Row.Cells[11].Text = "Άλλα Τηλέφωνα";
                e.Row.Cells[12].Text = "Email";
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Κωδικός Επαφής";
                e.Row.Cells[2].Text = "Όνομα";
                e.Row.Cells[3].Text = "Επώνυμο";
                e.Row.Cells[4].Text = "Εταιρεία";
            }
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            string word = TextBox5.Text;
            char[] letters = word.ToCharArray();
            char[] letters1 = word.ToCharArray();


            for (int i = 0; i <= letters.Length - 1; i++)
            {
                switch (letters[i])
                {
                    case 'a':
                        letters1[i] = 'α';
                        break;
                    case 'b':
                        letters1[i] = 'β';
                        break;
                    case 'c':
                        letters1[i] = 'ψ';
                        break;
                    case 'd':
                        letters1[i] = 'δ';
                        break;
                    case 'e':
                        letters1[i] = 'ε';
                        break;
                    case 'f':
                        letters1[i] = 'φ';
                        break;
                    case 'g':
                        letters1[i] = 'γ';
                        break;
                    case 'h':
                        letters1[i] = 'η';
                        break;
                    case 'i':
                        letters1[i] = 'ι';
                        break;
                    case 'j':
                        letters1[i] = 'ξ';
                        break;
                    case 'k':
                        letters1[i] = 'κ';
                        break;
                    case 'l':
                        letters1[i] = 'λ';
                        break;
                    case 'm':
                        letters1[i] = 'μ';
                        break;
                    case 'n':
                        letters1[i] = 'ν';
                        break;
                    case 'o':
                        letters1[i] = 'ο';
                        break;
                    case 'p':
                        letters1[i] = 'π';
                        break;
                    case 'q':
                        letters1[i] = 'κ';
                        break;
                    case 'r':
                        letters1[i] = 'ρ';
                        break;
                    case 's':
                        letters1[i] = 'σ';
                        break;
                    case 't':
                        letters1[i] = 'τ';
                        break;
                    case 'u':
                        letters1[i] = 'θ';
                        break;
                    case 'v':
                        letters1[i] = 'β';
                        break;
                    case 'w':
                        letters1[i] = 'ω';
                        break;
                    case 'x':
                        letters1[i] = 'χ';
                        break;
                    case 'y':
                        letters1[i] = 'υ';
                        break;
                    case 'z':
                        letters1[i] = 'ζ';
                        break;
                    case 'A':
                        letters1[i] = 'α';
                        break;
                    case 'B':
                        letters1[i] = 'β';
                        break;
                    case 'C':
                        letters1[i] = 'ψ';
                        break;
                    case 'D':
                        letters1[i] = 'δ';
                        break;
                    case 'E':
                        letters1[i] = 'ε';
                        break;
                    case 'F':
                        letters1[i] = 'φ';
                        break;
                    case 'G':
                        letters1[i] = 'γ';
                        break;
                    case 'H':
                        letters1[i] = 'η';
                        break;
                    case 'I':
                        letters1[i] = 'ι';
                        break;
                    case 'J':
                        letters1[i] = 'ξ';
                        break;
                    case 'K':
                        letters1[i] = 'κ';
                        break;
                    case 'L':
                        letters1[i] = 'λ';
                        break;
                    case 'M':
                        letters1[i] = 'μ';
                        break;
                    case 'N':
                        letters1[i] = 'ν';
                        break;
                    case 'O':
                        letters1[i] = 'ο';
                        break;
                    case 'P':
                        letters1[i] = 'π';
                        break;
                    case 'Q':
                        letters1[i] = 'κ';
                        break;
                    case 'R':
                        letters1[i] = 'ρ';
                        break;
                    case 'S':
                        letters1[i] = 'σ';
                        break;
                    case 'T':
                        letters1[i] = 'τ';
                        break;
                    case 'U':
                        letters1[i] = 'θ';
                        break;
                    case 'V':
                        letters1[i] = 'β';
                        break;
                    case 'W':
                        letters1[i] = 'ω';
                        break;
                    case 'X':
                        letters1[i] = 'χ';
                        break;
                    case 'Y':
                        letters1[i] = 'υ';
                        break;
                    case 'Z':
                        letters1[i] = 'ζ';
                        break;
                    case 'ά':
                        letters1[i] = 'α';
                        break;
                    case 'έ':
                        letters1[i] = 'ε';
                        break;
                    case 'ή':
                        letters1[i] = 'η';
                        break;
                    case 'ύ':
                        letters1[i] = 'υ';
                        break;
                    case 'ί':
                        letters1[i] = 'ι';
                        break;
                    case 'ό':
                        letters1[i] = 'ο';
                        break;
                    case 'ώ':
                        letters1[i] = 'ω';
                        break;
                    case 'Ά':
                        letters1[i] = 'α';
                        break;
                    case 'Έ':
                        letters1[i] = 'ε';
                        break;
                    case 'Ή':
                        letters1[i] = 'η';
                        break;
                    case 'Ύ':
                        letters1[i] = 'υ';
                        break;
                    case 'Ί':
                        letters1[i] = 'ι';
                        break;
                    case 'Ό':
                        letters1[i] = 'ο';
                        break;
                    case 'Ώ':
                        letters1[i] = 'ω';
                        break;
                }
            }
            word = string.Join("", letters1);

            MySqlCommand command4 = new MySqlCommand("SELECT ID,FirstName,LastName,Company FROM contacts where FirstName LIKE '%" + TextBox5.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox5.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox5.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox5.Text + "%' OR EmailAddress LIKE '%" + TextBox5.Text + "%' OR  EmailAddress LIKE '%" + TextBox5.Text + "%' OR BusinessPhone LIKE '%" + TextBox5.Text + "%'", connection);

            DataTable dataTable4 = new DataTable();
            MySqlDataAdapter da4 = new MySqlDataAdapter(command4);

            da4.Fill(dataTable4);

            GridView3.DataSource = dataTable4;
            GridView3.DataBind();

            connection.Close();

            Session["tab"] = "cases";
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (case_id.Text != "")
            {

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;

                command.CommandText = "SELECT * FROM contact_table where Case_ID=@p3 and Phone_Index_ID=@p4";
                command.Prepare();
                command.Parameters.AddWithValue("@p3", case_id.Text);
                command.Parameters.AddWithValue("@p4", Convert.ToInt32(GridView3.SelectedRow.Cells[1].Text));
                reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();

                    command.CommandText = "INSERT into contact_table(Case_ID,Phone_Index_ID) values (@p1,@p2)";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", case_id.Text);
                    command.Parameters.AddWithValue("@p2", Convert.ToInt32(GridView3.SelectedRow.Cells[1].Text));
                    command.ExecuteNonQuery();
                }

                reader.Close();

                MySqlCommand command3 = new MySqlCommand("SELECT Contact_table.ID, Contact_table.Phone_Index_ID AS Expr1, Contacts.FirstName, Contacts.LastName, Contacts.Company, Contacts.BusinessPhone,   Contacts.BusinessPhone2, Contacts.BusinessFax, Contacts.HomePhone, Contacts.MobilePhone, Contacts.OtherPhone,Contacts.EmailAddress FROM(Contact_table INNER JOIN Contacts ON Contact_table.Phone_Index_ID = Contacts.ID) Where Contact_table.Case_ID='" + case_id.Text + "'", connection);

                DataTable dataTable3 = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(command3);

                da3.Fill(dataTable3);

                GridView2.DataSource = dataTable3;
                GridView2.DataBind();

                if (GridView2.Rows.Count == 0)
                {
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                }

                connection.Close();

                Session["tab"] = "cases";
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM contact_table WHERE ID=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text));
            command.ExecuteNonQuery();

            MySqlCommand command3 = new MySqlCommand("SELECT Contact_table.ID, Contact_table.Phone_Index_ID AS Expr1, Contacts.FirstName, Contacts.LastName, Contacts.Company, Contacts.BusinessPhone,   Contacts.BusinessPhone2, Contacts.BusinessFax, Contacts.HomePhone, Contacts.MobilePhone, Contacts.OtherPhone,Contacts.EmailAddress FROM(Contact_table INNER JOIN Contacts ON Contact_table.Phone_Index_ID = Contacts.ID) Where Contact_table.Case_ID='" + GridView1.SelectedRow.Cells[0].Text + "'", connection);

            DataTable dataTable3 = new DataTable();
            MySqlDataAdapter da3 = new MySqlDataAdapter(command3);

            da3.Fill(dataTable3);

            GridView2.DataSource = dataTable3;
            GridView2.DataBind();

            connection.Close();

            if (GridView2.Rows.Count == 0)
            {
                Panel2.Visible = false;
            }
            else
            {
                Panel2.Visible = true;
            }

            Session["tab"] = "cases";
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView4.SelectedRow.RowIndex;
            string name = GridView4.SelectedRow.Cells[1].Text;
            string surname = GridView4.SelectedRow.Cells[2].Text;
            int uid = Convert.ToInt32(GridView4.SelectedRow.Cells[0].Text);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM event where ID=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", uid);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                event_id.Text = reader["id"].ToString();
                event_cases.Text = reader["Cases"].ToString();
                aiton.Text = reader["Aiton"].ToString();
                perigrafi_event.Text = reader["Perigrafi"].ToString();

                if (reader["date"] != DBNull.Value)
                {
                    event_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    event_date.Text = "";
                }
                if (reader["Final_date"] != DBNull.Value)
                {
                    final_date_event.Text = Convert.ToDateTime(reader["Final_date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    final_date_event.Text = "";
                }
            }
            reader.Close();

            connection.Close();

            Session["tab"] = "event";

            Response.Redirect("http://"+ url +"/cases.aspx?eventid=" + uid + "&caseid=" + GridView4.SelectedRow.Cells[2].Text);
        }

        protected void GridView4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Γεγονότα";
                HeaderCell.ColumnSpan = 8;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView4.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView4, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                e.Row.Cells[0].ToolTip = "Κωδικός";
                e.Row.Cells[1].ToolTip = "Ημερομηνία";
                e.Row.Cells[2].ToolTip = "Υπόθεση";
                e.Row.Cells[3].ToolTip = "Αιτών";
                e.Row.Cells[4].ToolTip = "Περιγραφή";
                e.Row.Cells[5].ToolTip = "Τελική Ημερομηνία";
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Κωδικός";
                e.Row.Cells[1].Text = "Ημερομηνία";
                e.Row.Cells[2].Text = "Υπόθεση";
                e.Row.Cells[3].Text = "Αιτών";
                e.Row.Cells[4].Text = "Περιγραφή";
                e.Row.Cells[5].Text = "Τελική Ημερομηνία";
            }
        }

        protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(GridView7.SelectedRow.Cells[0].Text);

            Session["tab"] = "milestone";

            Response.Redirect("http://"+ url +"/cases.aspx?milestoneid=" + uid + "&caseid=" + GridView7.SelectedRow.Cells[2].Text);
        }

        protected void GridView7_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Ορόσημα";
                HeaderCell.ColumnSpan = 9;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView7.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].ToolTip = "Κωδικός";
                e.Row.Cells[1].ToolTip = "Ημερομηνία";
                e.Row.Cells[2].ToolTip = "Υπόθεση";
                e.Row.Cells[3].ToolTip = "Αιτών";
                e.Row.Cells[4].ToolTip = "Υπεύθυνος Υλοποίησης";
                e.Row.Cells[5].ToolTip = "Περιγραφή";
                e.Row.Cells[6].ToolTip = "Τελική Ημερομηνία";
                e.Row.Cells[7].ToolTip = "Καταληκτική Ημερομηνία";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView7, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Κωδικός";
                e.Row.Cells[1].Text = "Ημερομηνία";
                e.Row.Cells[2].Text = "Υπόθεση";
                e.Row.Cells[3].Text = "Αιτών";
                e.Row.Cells[4].Text = "Υπεύθυνος Υλοποίησης";
                e.Row.Cells[5].Text = "Περιγραφή";
                e.Row.Cells[6].Text = "Τελική Ημερομηνία";
                e.Row.Cells[7].Text = "Καταληκτική Ημερομηνία";
            }
        }

        protected void GridView5_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["gridview5"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView5.DataSource = Session["gridview5"];
                GridView5.DataBind();
            }

            GridView5.SelectedIndex = -1;

            Session["tab"] = "event";
        }

        protected void GridView6_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["gridview6"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView6.DataSource = Session["gridview6"];
                GridView6.DataBind();
            }

            GridView6.SelectedIndex = -1;

            Session["tab"] = "milestone";
        }
    }
}