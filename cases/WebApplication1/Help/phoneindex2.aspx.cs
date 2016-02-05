using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class phonecatalog2 : System.Web.UI.Page
    {
        const string connectionString = "server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8";
        //string firstname = "";
        //string surname = "";
        string uid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //ImageButton1.ImageUrl = "http://192.168.1.208:8082/technor.png";
            //firstname = Request.QueryString["FirstName"];
            //surname = Request.QueryString["LastName"];
            uid = Request.QueryString["Uid"];

            if (!Page.IsPostBack)
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = connectionString;

                if (!string.IsNullOrEmpty(Request.Params["Uid"]))
                {
                    MySqlCommand command = new MySqlCommand("SELECT Company,FirstName,LastName,Department,JobTitle,BusinessStreet,BusinessCity,BusinessPostalCode,BusinessCountry,HomeStreet,HomeCity,HomePostalCode,HomeCountry,BusinessFax,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,EmailAddress,WebPage,ACTIVITY,TERRITORY FROM contacts where Uid='" + uid + "'", connection);
                    MySqlDataReader reader;
                    connection.Open();
                    command.Prepare();
                    reader = command.ExecuteReader();

                    reader.Read();

                    string territory = reader["TERRITORY"].ToString();
                    string[] words = territory.Split(',');

                    switch(words[0])
                    {
                        case "ΟΛΕΣ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΟΛΕΣ");
                                break;
                            }
                        case "":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΟΛΕΣ");
                                break;
                            }
                        case "ΑΝ. ΜΑΚΕΔΟΝΙΑ & ΘΡΑΚΗ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΕΒΡΟΣ");
                                DropDownList3.Items.Add("ΡΟΔΟΠΗ");
                                DropDownList3.Items.Add("ΞΑΝΘΗ");
                                DropDownList3.Items.Add("ΔΡΑΜΑ");
                                DropDownList3.Items.Add("ΚΑΒΑΛΑ");
                                DropDownList3.Items.Add("ΘΑΣΟΣ");

                                break;
                            }
                        case "ΚΕΝΤΡΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΘΕΣΣΑΛΟΝΙΚΗ");
                                DropDownList3.Items.Add("ΣΕΡΡΕΣ");
                                DropDownList3.Items.Add("ΧΑΛΚΙΔΙΚΗ");
                                DropDownList3.Items.Add("ΚΙΛΚΙΣ");
                                DropDownList3.Items.Add("ΠΕΛΛΑ");
                                DropDownList3.Items.Add("ΗΜΑΘΙΑ");
                                DropDownList3.Items.Add("ΠΙΕΡΙΑ");
                                break;
                            }
                        case "ΔΥΤΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΚΟΖΑΝΗ");
                                DropDownList3.Items.Add("ΦΛΩΡΙΝΑ");
                                DropDownList3.Items.Add("ΚΑΣΤΟΡΙΑ");
                                DropDownList3.Items.Add("ΓΡΕΒΕΝΑ");
                                break;
                            }
                        case "ΗΠΕΙΡΟΣ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΙΩΑΝΝΙΝΑ");
                                DropDownList3.Items.Add("ΑΡΤΑ");
                                DropDownList3.Items.Add("ΘΕΣΠΡΩΤΙΑ");
                                DropDownList3.Items.Add("ΠΡΕΒΕΖΑ");
                                break;
                            }
                        case "ΘΕΣΣΑΛΙΑ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΚΑΡΔΙΤΣΑ");
                                DropDownList3.Items.Add("ΛΑΡΙΣΑ");
                                DropDownList3.Items.Add("ΜΑΓΝΗΣΙΑ");
                                DropDownList3.Items.Add("ΤΡΙΚΑΛΑ");
                                DropDownList3.Items.Add("ΣΠΟΡΑΔΕΣ");
                                break;
                            }
                        case "ΙΟΝΙΟΙ ΝΗΣΟΙ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΖΑΚΥΝΘΟΣ");
                                DropDownList3.Items.Add("ΚΕΡΚΥΡΑ");
                                DropDownList3.Items.Add("ΚΕΦΑΛΛΟΝΙΑ");
                                DropDownList3.Items.Add("ΛΕΥΚΑΔΑ");
                                break;
                            }
                        case "ΔΥΤΙΚΗ ΕΛΛΑΔΑ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑ");
                                DropDownList3.Items.Add("ΑΧΑΪΑ");
                                DropDownList3.Items.Add("ΗΛΕΙΑ");
                                break;
                            }
                        case "ΣΤΕΡΕΑ ΕΛΛΑΔΑ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΦΘΙΟΤΙΔΑ");
                                DropDownList3.Items.Add("ΕΥΡΥΤΑΝΙΑ");
                                DropDownList3.Items.Add("ΒΟΙΩΤΙΑ");
                                DropDownList3.Items.Add("ΕΥΒΟΙΑ");
                                DropDownList3.Items.Add("ΦΩΚΙΔΑ");
                                break;
                            }
                        case "ΑΤΤΙΚΗ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΚΕΝΤΡΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                                DropDownList3.Items.Add("ΝΟΤΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                                DropDownList3.Items.Add("ΒΟΡΕΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                                DropDownList3.Items.Add("ΔΥΤΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                                DropDownList3.Items.Add("ΠΕΙΡΑΙΑΣ");
                                DropDownList3.Items.Add("ΝΗΣΟΙ");
                                DropDownList3.Items.Add("ΔΥΤΙΚΗ ΑΤΤΙΚΗ");
                                DropDownList3.Items.Add("ΑΝΑΤΟΛΙΚΗ ΑΤΤΙΚΗ");
                                break;
                            }
                        case "ΠΕΛΟΠΟΝΝΗΣΟΣ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΑΡΓΟΛΙΔΑ");
                                DropDownList3.Items.Add("ΑΡΚΑΔΙΑ");
                                DropDownList3.Items.Add("ΚΟΡΙΝΘΙΑ");
                                DropDownList3.Items.Add("ΛΑΚΩΝΙΑ");
                                DropDownList3.Items.Add("ΜΕΣΣΗΝΙΑ");
                                break;
                            }
                        case "ΒΟΡΕΙΟ ΑΙΓΑΙΟ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΛΕΣΒΟ");
                                DropDownList3.Items.Add("ΣΑΜΟ");
                                DropDownList3.Items.Add("ΧΙΟ");
                                DropDownList3.Items.Add("ΛΗΜΝΟΣ");
                                DropDownList3.Items.Add("ΙΚΑΡΙΑ");
                                break;
                            }
                        case "ΝΟΤΙΟ ΑΙΓΑΙΟ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΑΝΔΡΟΣ");
                                DropDownList3.Items.Add("ΘΗΡΑ");
                                DropDownList3.Items.Add("ΚΑΛΥΜΝΟΣ");
                                DropDownList3.Items.Add("ΚΑΡΠΑΘΟΣ");
                                DropDownList3.Items.Add("ΚΕΑ-ΚΥΘΝΟΣ");
                                DropDownList3.Items.Add("ΚΩΣ");
                                DropDownList3.Items.Add("ΜΗΛΟΣ");
                                DropDownList3.Items.Add("ΜΥΚΟΝΟΣ");
                                DropDownList3.Items.Add("ΝΑΞΟΣ");
                                DropDownList3.Items.Add("ΠΑΡΟΣ");
                                DropDownList3.Items.Add("ΡΟΔΟΣ");
                                DropDownList3.Items.Add("ΣΥΡΟΣ");
                                DropDownList3.Items.Add("ΤΗΝΟΣ");
                                break;
                            }
                        case "ΚΡΗΤΗ":
                            {
                                DropDownList3.Items.Clear();
                                DropDownList3.Items.Add("ΗΡΑΚΛΕΙΟ");
                                DropDownList3.Items.Add("ΛΑΣΙΘΙ");
                                DropDownList3.Items.Add("ΧΑΝΙΑ");
                                DropDownList3.Items.Add("ΡΕΘΥΜΝΟ");
                                break;
                            }
                            
                    }

                    TextBox1.Text = reader["FirstName"].ToString();
                    TextBox2.Text = reader["LastName"].ToString();
                    TextBox3.Text = reader["Company"].ToString();
                    TextBox4.Text = reader["Department"].ToString();
                    TextBox5.Text = reader["JobTitle"].ToString();
                    DropDownList1.Text = reader["ACTIVITY"].ToString();
                    DropDownList2.Text = words[0];
                    DropDownList3.Text = words[1];

                    TextBox6.Text = reader["BusinessPhone"].ToString();
                    TextBox7.Text = reader["BusinessPhone2"].ToString();
                    TextBox8.Text = reader["BusinessFax"].ToString();
                    TextBox9.Text = reader["HomePhone"].ToString();
                    TextBox10.Text = reader["MobilePhone"].ToString();
                    TextBox11.Text = reader["OtherPhone"].ToString();
                    TextBox12.Text = reader["EmailAddress"].ToString();
                    TextBox13.Text = reader["WebPage"].ToString();

                    TextBox14.Text = reader["BusinessStreet"].ToString();
                    TextBox15.Text = reader["BusinessCity"].ToString();
                    TextBox16.Text = reader["BusinessPostalCode"].ToString();
                    TextBox17.Text = reader["BusinessCountry"].ToString();
                    TextBox18.Text = reader["HomeStreet"].ToString();
                    TextBox19.Text = reader["HomeCity"].ToString();
                    TextBox20.Text = reader["HomePostalCode"].ToString();
                    TextBox21.Text = reader["HomeCountry"].ToString();

                    reader.Close();

                    Button3.Visible = false;
                }
                else
                {
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Add("ΟΛΕΣ");
                    
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button4.Visible = false;
                }

                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && DropDownList1.Text != "" && DropDownList2.Text != "" && DropDownList3.Text != "" && TextBox6.Text != "" && TextBox10.Text != "" && TextBox12.Text != "" && TextBox14.Text != "" && TextBox15.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                //string firstname = Request.QueryString["FirstName"];
                //string surname = Request.QueryString["LastName"];

                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE contacts SET Company=@p1, FirstName=@p2, LastName=@p3, Department=@p4, JobTitle=@p5, BusinessStreet=@p6, BusinessCity=@p7, BusinessPostalCode=@p8, BusinessCountry=@p9, HomeStreet=@p10, HomeCity=@p11, HomePostalCode=@p12, HomeCountry=@p13, BusinessFax=@p14, BusinessPhone=@p15, BusinessPhone2=@p16, HomePhone=@p17, MobilePhone=@p18, OtherPhone=@p19, EmailAddress=@p20, WebPage=@p21, ACTIVITY=@p22, TERRITORY=@p23 WHERE Uid=@p24";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", TextBox3.Text);
                command.Parameters.AddWithValue("@p2", TextBox1.Text);
                command.Parameters.AddWithValue("@p3", TextBox2.Text);
                command.Parameters.AddWithValue("@p4", TextBox4.Text);
                command.Parameters.AddWithValue("@p5", TextBox5.Text);
                command.Parameters.AddWithValue("@p6", TextBox14.Text);
                command.Parameters.AddWithValue("@p7", TextBox15.Text);
                command.Parameters.AddWithValue("@p8", TextBox16.Text);
                command.Parameters.AddWithValue("@p9", TextBox17.Text);
                command.Parameters.AddWithValue("@p10", TextBox18.Text);
                command.Parameters.AddWithValue("@p11", TextBox19.Text);
                command.Parameters.AddWithValue("@p12", TextBox20.Text);
                command.Parameters.AddWithValue("@p13", TextBox21.Text);
                command.Parameters.AddWithValue("@p14", TextBox8.Text);
                command.Parameters.AddWithValue("@p15", TextBox6.Text);
                command.Parameters.AddWithValue("@p16", TextBox7.Text);
                command.Parameters.AddWithValue("@p17", TextBox9.Text);
                command.Parameters.AddWithValue("@p18", TextBox10.Text);
                command.Parameters.AddWithValue("@p19", TextBox11.Text);
                command.Parameters.AddWithValue("@p20", TextBox12.Text);
                command.Parameters.AddWithValue("@p21", TextBox13.Text);
                command.Parameters.AddWithValue("@p22", DropDownList1.Text);
                command.Parameters.AddWithValue("@p23", DropDownList2.Text + "," + DropDownList3.Text);
                command.Parameters.AddWithValue("@p24", uid);
                command.ExecuteNonQuery();

                connection.Close();
                //MessageBox.Show("Η επαφή ενημερώθηκε");
                Response.Redirect("http://192.168.1.201/phoneindex.aspx");
            }
            else
            {
                TextBox1.BackColor = Color.LightBlue;
                TextBox2.BackColor = Color.LightBlue;
                TextBox3.BackColor = Color.LightBlue;
                TextBox6.BackColor = Color.LightBlue;
                TextBox10.BackColor = Color.LightBlue;
                TextBox12.BackColor = Color.LightBlue;
                TextBox14.BackColor = Color.LightBlue;
                TextBox15.BackColor = Color.LightBlue;
                DropDownList1.BackColor = Color.LightBlue;
                DropDownList2.BackColor = Color.LightBlue;
                DropDownList3.BackColor = Color.LightBlue;
                //MessageBox.Show("Συμπληρώστε τα απαραίτητα πεδία με το μπλε χρώμα");
                Label27.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //string firstname = Request.QueryString["FirstName"];
            //string surname = Request.QueryString["LastName"];

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM contacts WHERE Uid=@p1";
            command.Prepare();
            command.Parameters.AddWithValue("@p1", uid);
            command.ExecuteNonQuery();

            connection.Close();
            //MessageBox.Show("Η επαφή διαγράφηκε");
            Response.Redirect("http://192.168.1.201/phoneindex.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && DropDownList1.Text != "" && DropDownList2.Text != "" && DropDownList3.Text != "" && TextBox6.Text != "" && TextBox10.Text != "" && TextBox12.Text != "" && TextBox14.Text != "" && TextBox15.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                //string firstname = Request.QueryString["FirstName"];
                //string surname = Request.QueryString["LastName"];

                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT into contacts (Company,FirstName,LastName,Department,JobTitle,BusinessStreet,BusinessCity,BusinessPostalCode,BusinessCountry,HomeStreet,HomeCity,HomePostalCode,HomeCountry,BusinessFax,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,EmailAddress,WebPage,ACTIVITY,TERRITORY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23)";
                command.Prepare();
                command.Parameters.AddWithValue("@p1", TextBox3.Text);
                command.Parameters.AddWithValue("@p2", TextBox1.Text);
                command.Parameters.AddWithValue("@p3", TextBox2.Text);
                command.Parameters.AddWithValue("@p4", TextBox4.Text);
                command.Parameters.AddWithValue("@p5", TextBox5.Text);
                command.Parameters.AddWithValue("@p6", TextBox14.Text);
                command.Parameters.AddWithValue("@p7", TextBox15.Text);
                command.Parameters.AddWithValue("@p8", TextBox16.Text);
                command.Parameters.AddWithValue("@p9", TextBox17.Text);
                command.Parameters.AddWithValue("@p10", TextBox18.Text);
                command.Parameters.AddWithValue("@p11", TextBox19.Text);
                command.Parameters.AddWithValue("@p12", TextBox20.Text);
                command.Parameters.AddWithValue("@p13", TextBox21.Text);
                command.Parameters.AddWithValue("@p14", TextBox8.Text);
                command.Parameters.AddWithValue("@p15", TextBox6.Text);
                command.Parameters.AddWithValue("@p16", TextBox7.Text);
                command.Parameters.AddWithValue("@p17", TextBox9.Text);
                command.Parameters.AddWithValue("@p18", TextBox10.Text);
                command.Parameters.AddWithValue("@p19", TextBox11.Text);
                command.Parameters.AddWithValue("@p20", TextBox12.Text);
                command.Parameters.AddWithValue("@p21", TextBox13.Text);
                command.Parameters.AddWithValue("@p22", DropDownList1.Text);
                command.Parameters.AddWithValue("@p23", DropDownList2.Text + "," + DropDownList3.Text);
                command.ExecuteNonQuery();

                connection.Close();
                //MessageBox.Show("Η επαφή αποθηκεύτηκε");
                Response.Redirect("http://192.168.1.201/phoneindex.aspx");
            }
            else
            {
                TextBox1.BackColor = Color.LightBlue;
                TextBox2.BackColor = Color.LightBlue;
                TextBox3.BackColor = Color.LightBlue;
                TextBox6.BackColor = Color.LightBlue;
                TextBox10.BackColor = Color.LightBlue;
                TextBox12.BackColor = Color.LightBlue;
                TextBox14.BackColor = Color.LightBlue;
                TextBox15.BackColor = Color.LightBlue;
                DropDownList1.BackColor = Color.LightBlue;
                DropDownList2.BackColor = Color.LightBlue;
                DropDownList3.BackColor = Color.LightBlue;
                //MessageBox.Show("Συμπληρώστε τα απαραίτητα πεδία με το μπλε χρώμα");
                Label27.Visible = true;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList2.SelectedItem.Text)
            {
                case "ΟΛΕΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        break;
                    }
                case "ΑΝ. ΜΑΚΕΔΟΝΙΑ & ΘΡΑΚΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΕΒΡΟΣ");
                        DropDownList3.Items.Add("ΡΟΔΟΠΗ");
                        DropDownList3.Items.Add("ΞΑΝΘΗ");
                        DropDownList3.Items.Add("ΔΡΑΜΑ");
                        DropDownList3.Items.Add("ΚΑΒΑΛΑ");
                        DropDownList3.Items.Add("ΘΑΣΟΣ");

                        break;
                    }
                case "ΚΕΝΤΡΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΘΕΣΣΑΛΟΝΙΚΗ");
                        DropDownList3.Items.Add("ΣΕΡΡΕΣ");
                        DropDownList3.Items.Add("ΧΑΛΚΙΔΙΚΗ");
                        DropDownList3.Items.Add("ΚΙΛΚΙΣ");
                        DropDownList3.Items.Add("ΠΕΛΛΑ");
                        DropDownList3.Items.Add("ΗΜΑΘΙΑ");
                        DropDownList3.Items.Add("ΠΙΕΡΙΑ");
                        break;
                    }
                case "ΔΥΤΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΟΖΑΝΗ");
                        DropDownList3.Items.Add("ΦΛΩΡΙΝΑ");
                        DropDownList3.Items.Add("ΚΑΣΤΟΡΙΑ");
                        DropDownList3.Items.Add("ΓΡΕΒΕΝΑ");
                        break;
                    }
                case "ΗΠΕΙΡΟΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΙΩΑΝΝΙΝΑ");
                        DropDownList3.Items.Add("ΑΡΤΑ");
                        DropDownList3.Items.Add("ΘΕΣΠΡΩΤΙΑ");
                        DropDownList3.Items.Add("ΠΡΕΒΕΖΑ");
                        break;
                    }
                case "ΘΕΣΣΑΛΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΑΡΔΙΤΣΑ");
                        DropDownList3.Items.Add("ΛΑΡΙΣΑ");
                        DropDownList3.Items.Add("ΜΑΓΝΗΣΙΑ");
                        DropDownList3.Items.Add("ΤΡΙΚΑΛΑ");
                        DropDownList3.Items.Add("ΣΠΟΡΑΔΕΣ");
                        break;
                    }
                case "ΙΟΝΙΟΙ ΝΗΣΟΙ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΖΑΚΥΝΘΟΣ");
                        DropDownList3.Items.Add("ΚΕΡΚΥΡΑ");
                        DropDownList3.Items.Add("ΚΕΦΑΛΛΟΝΙΑ");
                        DropDownList3.Items.Add("ΛΕΥΚΑΔΑ");
                        break;
                    }
                case "ΔΥΤΙΚΗ ΕΛΛΑΔΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑ");
                        DropDownList3.Items.Add("ΑΧΑΪΑ");
                        DropDownList3.Items.Add("ΗΛΕΙΑ");
                        break;
                    }
                case "ΣΤΕΡΕΑ ΕΛΛΑΔΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΦΘΙΟΤΙΔΑ");
                        DropDownList3.Items.Add("ΕΥΡΥΤΑΝΙΑ");
                        DropDownList3.Items.Add("ΒΟΙΩΤΙΑ");
                        DropDownList3.Items.Add("ΕΥΒΟΙΑ");
                        DropDownList3.Items.Add("ΦΩΚΙΔΑ");
                        break;
                    }
                case "ΑΤΤΙΚΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΕΝΤΡΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΝΟΤΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΒΟΡΕΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΔΥΤΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΠΕΙΡΑΙΑΣ");
                        DropDownList3.Items.Add("ΝΗΣΟΙ");
                        DropDownList3.Items.Add("ΔΥΤΙΚΗ ΑΤΤΙΚΗ");
                        DropDownList3.Items.Add("ΑΝΑΤΟΛΙΚΗ ΑΤΤΙΚΗ");
                        break;
                    }
                case "ΠΕΛΟΠΟΝΝΗΣΟΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΡΓΟΛΙΔΑ");
                        DropDownList3.Items.Add("ΑΡΚΑΔΙΑ");
                        DropDownList3.Items.Add("ΚΟΡΙΝΘΙΑ");
                        DropDownList3.Items.Add("ΛΑΚΩΝΙΑ");
                        DropDownList3.Items.Add("ΜΕΣΣΗΝΙΑ");
                        break;
                    }
                case "ΒΟΡΕΙΟ ΑΙΓΑΙΟ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΛΕΣΒΟ");
                        DropDownList3.Items.Add("ΣΑΜΟ");
                        DropDownList3.Items.Add("ΧΙΟ");
                        DropDownList3.Items.Add("ΛΗΜΝΟΣ");
                        DropDownList3.Items.Add("ΙΚΑΡΙΑ");
                        break;
                    }
                case "ΝΟΤΙΟ ΑΙΓΑΙΟ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΝΔΡΟΣ");
                        DropDownList3.Items.Add("ΘΗΡΑ");
                        DropDownList3.Items.Add("ΚΑΛΥΜΝΟΣ");
                        DropDownList3.Items.Add("ΚΑΡΠΑΘΟΣ");
                        DropDownList3.Items.Add("ΚΕΑ-ΚΥΘΝΟΣ");
                        DropDownList3.Items.Add("ΚΩΣ");
                        DropDownList3.Items.Add("ΜΗΛΟΣ");
                        DropDownList3.Items.Add("ΜΥΚΟΝΟΣ");
                        DropDownList3.Items.Add("ΝΑΞΟΣ");
                        DropDownList3.Items.Add("ΠΑΡΟΣ");
                        DropDownList3.Items.Add("ΡΟΔΟΣ");
                        DropDownList3.Items.Add("ΣΥΡΟΣ");
                        DropDownList3.Items.Add("ΤΗΝΟΣ");
                        break;
                    }
                case "ΚΡΗΤΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΗΡΑΚΛΕΙΟ");
                        DropDownList3.Items.Add("ΛΑΣΙΘΙ");
                        DropDownList3.Items.Add("ΧΑΝΙΑ");
                        DropDownList3.Items.Add("ΡΕΘΥΜΝΟ");
                        break;
                    }

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:?body="+ TextBox1.Text +"%0A"+ TextBox2.Text +"%0A"+ TextBox3.Text +"%0A"+ TextBox4.Text +"%0A"+ TextBox5.Text +"%0A"+ Label11.Text +"%20:%20"+ TextBox6.Text +"%0A"+ Label12.Text +"%20:%20"+ TextBox7.Text +"%0A"+ Label13.Text +"%20:%20"+ TextBox8.Text +"%0A"+ Label14.Text +"%20:%20"+ TextBox9.Text +"%0A"+ Label15.Text +"%20:%20"+ TextBox10.Text +"%0A"+ Label16.Text +"%20:%20"+ TextBox11.Text +"%0A"+ Label17.Text +"%20:%20"+ TextBox12.Text +"%0A"+ Label19.Text +"%20:%20"+ TextBox14.Text +"%0A"+ Label20.Text +"%20:%20"+ TextBox15.Text +"%0A"+ Label22.Text +"%20:%20"+ TextBox17.Text +"'", true);
        }
    }
}