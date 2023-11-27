using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        bool chechbookexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox2.Text.Trim() + "' ;", con);
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

        bool checkmemberexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
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
        //issue
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(chechbookexist() && checkmemberexist())
            {
                if (checkbookissued()) {
                    Response.Write("<script>alert('This book already issued for this member id')</script>");
                }
                else{
                    
                    bookissue();
                }
            }
            else
            {
                Response.Write("<script>alert('BOOK OR MEMBER DOES NOT EXIST')</script>");
            }
            GridView1.DataBind();
        }
        void bookissue()
        {
            try{
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date)VALUES(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                int result=cmd.ExecuteNonQuery();
                if(result>0)
                {

                    Response.Write("<script>alert('BOOK ISSUED SUCCESSFULLY')</script>");
                    
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock-1 WHERE book_id='" + TextBox2.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                con.Close();
                
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
            
        }
      
        //go button
        protected void Button5_Click(object sender, EventArgs e)
        {
            getnamesbyid();
        }
        void getnamesbyid()
        {
            try
            {
                //for getting member name
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM member_master_tbl WHERE member_id='"+TextBox1.Text.Trim()+"'  ",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt= new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >=1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('This member does not exist')</script>");

                }
                //for getting book name

                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand("SELECT*FROM book_master_tbl WHERE book_id='" + TextBox2.Text.Trim() + "'  ",con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('This book does not exist')</script>");

                }
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
        //return book
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con= new SqlConnection(strcon);
            if(con.State == ConnectionState.Closed)
            {
                con.Open(); 
            }
            
            if (chechbookexist() && checkmemberexist())
            {
                if (checkbookissued()) {
                    bookreturn();
                }
                else
                {
                    Response.Write("<script>alert('This member doesnt took this book or Already issued')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('BOOK OR MEMBER DOES NOT EXIST')</script>");
            }
            GridView1.DataBind();
        }
       void bookreturn()
        {
            try{
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE book_issue_tbl WHERE member_id='" + TextBox1.Text.Trim() + "' AND book_id='"+TextBox2.Text.Trim()+"'", con);               
                int result =cmd.ExecuteNonQuery();
                
                if (result >0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock+1 WHERE book_id='" + TextBox2.Text.Trim() + "'",con);
                    Response.Write("<script>alert('BOOK RETURNED SUCCESSFULLY')</script>");
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                    con.Close ();
                }
                
                con.Close();
                
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
        bool checkbookissued()
        {
            SqlConnection con=new SqlConnection(strcon);
            if(con.State == ConnectionState.Closed ) { 
            con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT*FROM book_issue_tbl WHERE member_id='"+TextBox1.Text.Trim()+"' AND book_id='"+TextBox2.Text.Trim()+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            if(dt.Rows.Count >=1) { return true; }
            else { return false; }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor=System.Drawing.Color.Red;
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}