using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace WebApplication1
{
    public partial class home : System.Web.UI.Page
    {
        const string connectionString = "server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8;Convert Zero Datetime=True";
        //const string url = "192.168.1.201/cases";
        string url = Class1.sqlstring;

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

                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;

                    command.CommandText = "SELECT * FROM cases where id=@p1";
                    command.Prepare();
                    command.Parameters.AddWithValue("@p1", GridView2.Rows[i].Cells[2].Text);
                    reader = command.ExecuteReader();
                    string name_case = "";
                    if (reader.Read())
                    {
                        name_case = reader["Case_Name"].ToString();
                    }

                    reader.Close();
                    connection.Close();

                    LinkButton lb = new LinkButton();
                    lb.ToolTip = GridView2.Rows[i].Cells[2].Text;
                    lb.Text = name_case;
                    lb.Click += new EventHandler(case_click);

                    GridView2.Rows[i].Cells[2].Controls.Add(lb);
                }
            }
        }

        public void find_milestones()
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM event";

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM milestone", connection);

            DataTable dataTable1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(command2);

            da1.Fill(dataTable1);

            DataTable dtAll = dataTable.Copy();
            dtAll.Merge(dataTable1);

            MySqlCommand command3 = new MySqlCommand("SELECT * FROM milestone WHERE Final_date <='" + DateTime.Today.AddDays(7).ToString("yyyy/MM/dd HH:MM") + "' AND Close_date ='0000-00-00 00:00:00' ORDER BY Final_date DESC", connection);

            DataTable dataTable2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter(command3);

            da2.Fill(dataTable2);

            DataView dv = dtAll.DefaultView;
            dv.Sort = "date desc";
            DataTable dtAll1 = dv.ToTable();

            GridView1.DataSource = dtAll1;
            GridView1.DataBind();

            GridView2.DataSource = dataTable2;
            GridView2.DataBind();

            Session["gridview1"] = dtAll;
            Session["gridview2"] = dataTable2;

            connection.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);
            
            if (GridView1.SelectedRow.Cells[6].Text == "-")
            {
                Session["tab"] = "event";

                Response.Redirect("http://"+ url +"/cases.aspx?eventid=" + uid + "&caseid=" + GridView1.SelectedRow.Cells[2].Text);
            }
            else
            {
                Session["tab"] = "milestone";
                
                Response.Redirect("http://"+ url +"/cases.aspx?milestoneid=" + uid + "&caseid=" + GridView1.SelectedRow.Cells[2].Text);
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
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Γεγονότα - Ορόσημα";
                HeaderCell.ColumnSpan = 9;
                HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                e.Row.Cells[0].ToolTip = "Κωδικός";
                e.Row.Cells[1].ToolTip = "Ημερομηνία";
                e.Row.Cells[2].ToolTip = "Υπόθεση";
                e.Row.Cells[3].ToolTip = "Αιτών";
                e.Row.Cells[4].ToolTip = "Περιγραφή";
                //e.Row.Cells[6].ToolTip = "Ημερομηνία Ορόσημου";
                e.Row.Cells[6].ToolTip = "Υπεύθυνος Υλοποίησης";
                e.Row.Cells[7].ToolTip = "Τελική Ημερομηνία";
                e.Row.Cells[8].ToolTip = "Καταληκτική Ημερομηνία";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                LnkHeaderText.Text = "Κωδικός";
                LinkButton LnkHeaderText1 = e.Row.Cells[1].Controls[0] as LinkButton;
                LnkHeaderText1.Text = "Ημερομηνία Γεγονότος";
                LinkButton LnkHeaderText2 = e.Row.Cells[2].Controls[0] as LinkButton;
                LnkHeaderText2.Text = "Υπόθεση";
                LinkButton LnkHeaderText3 = e.Row.Cells[3].Controls[0] as LinkButton;
                LnkHeaderText3.Text = "Αιτών";
                LinkButton LnkHeaderText4 = e.Row.Cells[4].Controls[0] as LinkButton;
                LnkHeaderText4.Text = "Περιγραφή";
                //LinkButton LnkHeaderText8 = e.Row.Cells[6].Controls[0] as LinkButton;
                //LnkHeaderText8.Text = "Ημερομηνία Ορόσημου";
                LinkButton LnkHeaderText5 = e.Row.Cells[6].Controls[0] as LinkButton;
                LnkHeaderText5.Text = "Υπεύθυνος Υλοποίησης";
                LinkButton LnkHeaderText6 = e.Row.Cells[7].Controls[0] as LinkButton;
                LnkHeaderText6.Text = "Τελική Ημερομηνία";
                LinkButton LnkHeaderText7 = e.Row.Cells[8].Controls[0] as LinkButton;
                LnkHeaderText7.Text = "Καταληκτική Ημερομηνία";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "-";
                    }
                }

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

            Response.Redirect("http://"+ url +"/cases.aspx?caseid=" + case_id);
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text);

            Session["tab"] = "milestone";

            Response.Redirect("http://"+ url +"/cases.aspx?milestoneid=" + uid + "&caseid=" + GridView2.SelectedRow.Cells[2].Text);
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["gridview2"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView2.DataSource = Session["gridview2"];
                GridView2.DataBind();
            }

            GridView2.SelectedIndex = -1;
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Ορόσημα";
                HeaderCell.ColumnSpan = 8;
                HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.BackColor = Color.DarkGreen;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView2.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
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
    }
}