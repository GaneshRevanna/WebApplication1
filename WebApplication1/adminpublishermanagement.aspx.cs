using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ( checkpublisherExist())
            {
                Response.Write("<script>alert('MEMBER ID ALREADY EXIST')</script>");
            }
            else
            {
                addpublisher();
            }
            clearform();
        }
        void addpublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id,publisher_name) VALUES(@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('ADDED SUCCESSFULLY')</script>");
                GridView1.DataBind();
            }
            catch(Exception ex) {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            
        }
        bool checkpublisherExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim()+"'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);    
                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkpublisherExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('This member ID does not exist')</script>");
            }
            clearform();
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if( con.State == ConnectionState.Closed )
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='"+TextBox1.Text.Trim()+"'",con);
                
                cmd.Parameters.AddWithValue("@publisher_name",TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher updated successfully')</script>");
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
            
           
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('PUBLISHER DELETED SUCCESSFULLY')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkpublisherExist())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Member Id Does not exist')</script>");
            }
            clearform();
        }
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getAuthorbyID();
        }
        void getAuthorbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon); 
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "'",con);
               SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else {
                    Response.Write("<script>alert('INVALID USER')</script>");
                        }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}