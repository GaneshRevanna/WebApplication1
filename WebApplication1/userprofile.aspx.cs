﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again')</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getmemberdetails();
                        getuserbookdata();
                    }
                    
                }

            }
            catch { }

        }
        //updatemember details
        void updatemember()
        {
            String password = "";
            if (TextBox10.Text=="")
            {
                password=TextBox9.Text.Trim();

            }
            else
            {
                password=TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE  member_master_tbl  SET full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password  WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);
                cmd.Parameters.AddWithValue("@full_name",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password",password);
                int result=cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('DETAILS UPDATED SUCCESSFULLY')</script>");
                }
                else
                {
                    Response.Write("<script>alert('INVALID DETAILS')</script>");
                }
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "')</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again')</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                 updatemember();
                

            }


        }
        //grid view
        void getuserbookdata()
        {
            try{
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM  book_issue_tbl WHERE member_id='"+Session["username"].ToString() + "'",con);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();   
            }
            catch(Exception e) {
                Response.Write("<script>alert('"+e.Message+"')</script>");
            }
        }
        //to fill all details in textboxes
        void getmemberdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM  member_master_tbl  WHERE member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();


                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    Label1.Text = "active";
                }

                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending" || dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                    Label1.Text = "pending";
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                    Label1.Text = "deactive";
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                    Label1.Text = "no_status";
                }
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "')</script>");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}