﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM admin_login_tbl WHERE username='" + TextBox1.Text.Trim() + "' AND  password='" + TextBox2.Text.Trim() + "'  ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Admin Login Successfull')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["role"] = "admin";
                        Session["fullname"]=dr.GetValue(2).ToString();
                    }
                    Response.Redirect("home.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('"+ex.Message+"')</script>");
            }
        }
    }
}