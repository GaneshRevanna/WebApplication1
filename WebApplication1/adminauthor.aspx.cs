using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

    
        protected void Button2_Click(object sender, EventArgs e)
        {
            getbyAuthorId();
        }
        //user defined function
        bool checkAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
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
        //adding new author
        void addnewauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) VALUES(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
            
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert(' author added successfully ');</script>");

                GridView1.DataBind();
                //below script is used to redirect delay after script message
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "delayedRedirectScript",
                //"alert('User Sign Up succcessfully done go to user login to login'); setTimeout(function() { window.location='" + ResolveUrl("userlogin.aspx") + "'; }, 500);", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                Response.Write("<script>alert('Author with this author ID already exists.you cannot add another author with the same author id')</script>");
            }
            else
            {
                addnewauthor();
            }
            clearform();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                updateAuthor();
               
            }
            else
            {
                Response.Write("<script>alert('Author with this author ID does not exists.')</script>");
            }
            clearform();
        }
        //update author
         void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE  author_master_tbl SET author_name=@author_name WHERE author_id='"+TextBox1.Text.Trim()+"'", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert(' author updated successfully ');</script>");
                GridView1.DataBind();   


                //below script is used to redirect delay after script message
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "delayedRedirectScript",
                //"alert('User Sign Up succcessfully done go to user login to login'); setTimeout(function() { window.location='" + ResolveUrl("userlogin.aspx") + "'; }, 500);", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author with this author ID does not exists.')</script>");
            }
            clearform();
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE author_master_tbl  WHERE author_id='" + TextBox1.Text.Trim() + "'", con);

                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert(' author deleted  successfully ');</script>");
                GridView1.DataBind();

                //below script is used to redirect delay after script message
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "delayedRedirectScript",
                //"alert('User Sign Up succcessfully done go to user login to login'); setTimeout(function() { window.location='" + ResolveUrl("userlogin.aspx") + "'; }, 500);", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        void getbyAuthorId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else {
                    Response.Write("<script>alert('Invlid userid')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                
            }
        }
    }

}