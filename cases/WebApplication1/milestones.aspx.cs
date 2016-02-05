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

namespace WebApplication1
{
    public partial class milestones : System.Web.UI.Page
    {
        const string connectionString = "server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8;Convert Zero Datetime=True";
        //const string url = "192.168.1.201/cases";
        string url = WebApplication1.Class1.sqlstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                find_milestones();
            }
            else
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;

                    command.CommandText = "SELECT * FROM cases where id=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", GridView1.Rows[i].Cells[2].Text);
                    reader = command.ExecuteReader();
                    string name_case = "";
                    if (reader.Read())
                    {
                        name_case = reader["Case_Name"].ToString();
                    }

                    reader.Close();
                    connection.Close();

                    LinkButton lb = new LinkButton();
                    lb.ToolTip = GridView1.Rows[i].Cells[2].Text;
                    lb.Text = name_case;
                    lb.Click += new EventHandler(case_click);

                    GridView1.Rows[i].Cells[2].Controls.Add(lb);
                }
            }
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

            Session["gridview1"] = dataTable;

            connection.Close();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;

                command.CommandText = "SELECT * FROM cases where id=@p1";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", e.Row.Cells[2].Text);
                reader = command.ExecuteReader();
                string name_case = "";
                if (reader.Read())
                {
                    name_case = reader["Case_Name"].ToString();
                }

                reader.Close();
                connection.Close();

                LinkButton lb = new LinkButton();
                lb.ToolTip = e.Row.Cells[2].Text;
                lb.Text = name_case;
                lb.Click += new EventHandler(case_click);

                e.Row.Cells[2].Controls.Add(lb);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
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

        protected void case_click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;

            Session["tab"] = "cases";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM cases where Case_Name=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", button.Text);
            reader = command.ExecuteReader();
            string case_id = "";
            if (reader.Read())
            {
                case_id = reader["id"].ToString();
            }

            reader.Close();
            connection.Close();

            Response.Redirect("http://" + url + "/cases.aspx?caseid=" + case_id);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int index = GridView1.SelectedRow.RowIndex;
            string name = GridView1.SelectedRow.Cells[1].Text;
            string surname = GridView1.SelectedRow.Cells[2].Text;
            int uid = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);

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
                cases.Text = reader["Cases"].ToString();
                aiton.Text = reader["Aiton"].ToString();
                perigrafi.Text = reader["Perigrafi"].ToString();
                ypeythynos.Text = reader["Yp_Ylopohsis"].ToString();

                if (reader["date"] != DBNull.Value)
                {
                    milestone_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd HH:MM");
                }
                else
                {
                    milestone_date.Text = "";
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
            }
            reader.Close();

            connection.Close(); 
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ναι")
            {
                if (GridView1.SelectedRow != null)
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM milestone WHERE ID=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text));
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

                    find_milestones();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Διαγραφή')", true);
                }
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (milestone_date.Text != "" && cases.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE milestone SET date=@p1, Cases=@p2, Aiton=@p3, Yp_Ylopohsis=@p4, Perigrafi=@p5, Final_date=@p6, Close_date=@p7 WHERE ID=@p21";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", milestone_date.Text);
                command.Parameters.AddWithValue("@p2", cases.Text);
                command.Parameters.AddWithValue("@p3", aiton.Text);
                command.Parameters.AddWithValue("@p4", ypeythynos.Text);
                command.Parameters.AddWithValue("@p5", perigrafi.Text);
                command.Parameters.AddWithValue("@p6", final_date.Text);
                command.Parameters.AddWithValue("@p7", close_date.Text);
                command.Parameters.AddWithValue("@p21", Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text));
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

                find_milestones();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Επιτυχής Ενημέρωση')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Σημπληρώστε τα απαραίτητα πεδία με τον αστερίσκο')", true);
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

            GridView1.SelectedIndex = -1;

            foreach (Control control in Panel1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = "";
                }
            }
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
    }
}