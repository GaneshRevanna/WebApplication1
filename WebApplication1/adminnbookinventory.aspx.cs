using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        static string globalfilepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublishervalues();
            }
            GridView1.DataBind();   
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
       
        void fillAuthorPublishervalues()
        {
            try
            {
                SqlConnection con=new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;",con);
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                //PUBLISHER DROPDOWN
                 cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();



            }
            catch (Exception ex) 
            {
                Response.Redirect(ex.Message);
            }

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            if(checkbookexist())
            {
                Response.Write("<script>alert('THIS BOOK ALREADY EXISTS')</script>");
            }
            else
            {
                addbook();
            }
        }
        bool checkbookexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' OR book_name='"+TextBox2.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }
        void addbook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i]+ ",";
                }
                genres=genres.Remove(genres.Length-1);

                string filepath = "";
                string filename=Path.GetFileName(FileUpload1.PostedFile.FileName);//TO TAKE A PATH OF THE FILENAME
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));//CODE TO MAPPING A PATH AND STORE IN A FOLDER
                filepath = "~/book_inventory/" + filename;//TO SET A PATH ACCORDING TO LOCAL FOLDER
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,book_description,actual_stock,current_stock,book_img_link) VALUES(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox6.Text.Trim());                   ;
                cmd.Parameters.AddWithValue("@current_stock", global_current_stock) ;

                cmd.Parameters.AddWithValue("@book_img_link", filepath);

               
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('BOOK ADDED SUCCESSFULLY')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')</script>");
            }
        }
        //UPDATE BUTTON
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkbookexist())
            {
                updateauthor();
            }
            else
            {
                Response.Write("<Script>alert('Book Not exist')</script>");
            }
        }
        void updateauthor()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);
                string filepath = "~/book_inventory/books1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filename = globalfilepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET  book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock,book_img_link=@book_img_link WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.Text.Trim());
                cmd.Parameters.AddWithValue("@publish_date", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox6.Text.Trim()); ;
                cmd.Parameters.AddWithValue("@current_stock", global_current_stock);

                cmd.Parameters.AddWithValue("@book_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('BOOK UPDATED SUCCESSFULLY')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        //Delete button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkbookexist())
            {
                deletebook();
            }
            else
            {
                Response.Write("<script>alert('This book does not exist')</script>");
            }
        }
        void deletebook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('BOOK DELETED SUCCESSFULLY')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        //GO BUTTON
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkbookexist())
            {
                getbookbyid();
            }
            else 
            {
                
                Response.Write("<script>alert('THIS BOOK DOES  NOT EXIST ')</script>");
            }
            
        }
        void getbookbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox9.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox3.Text = dt.Rows[0]["edition"].ToString();
                    
                    TextBox6.Text = dt.Rows[0]["actual_stock"].ToString();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString();
                    TextBox10.Text= dt.Rows[0]["book_description"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    ListBox1.ClearSelection();
                    for (int i = 0; i < genre.Length; i++)
                    {

                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {

                                ListBox1.Items[j].Selected = true;

                            }

                        }

                    }
                    TextBox11.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                  
                    

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    //block is to make listbox items true by taking the genre data from the backend
                    
                
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    globalfilepath = dt.Rows[0]["book_img_link"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

                Console.WriteLine($"Exception Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");



            }
        }
    }
 }
   
