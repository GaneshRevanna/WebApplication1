using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM member_master_tbl WHERE member_id='"+ TextBox1.Text.Trim() + "' AND  password='" + TextBox2.Text.Trim()+"' AND account_status<>'deactive'  ",con);
                SqlDataReader dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read()) 
                    {

                        Response.Write("<script>alert('Login Successfull')</script>");
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["fullname"]=dr.GetValue(0).ToString();
                        Session["role"]="user";
                        Session["status"]= dr.GetValue(10).ToString();
                        
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

                Response.Write("<script> alert('+')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["role"] = "signup";
            Response.Redirect("usersignup.aspx");

        }
    }
}