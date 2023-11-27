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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            getMemberbyid();
        }
        void getMemberbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT*FROM member_master_tbl WHERE member_id='"+TextBox1.Text.Trim()+"'",con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();//fullname
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox5.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(3).ToString();
                        TextBox7.Text = dr.GetValue(4).ToString();
                        TextBox8.Text = dr.GetValue(5).ToString();
                        TextBox9.Text = dr.GetValue(6).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                        TextBox3.Text = dr.GetValue(10).ToString();

                    }
                }
                else
                {
                    Response.Write("<script>alert('THIS ID DOES NORT EXIST')</script>");
                    TextBox2.Text = ""; //fullname
                    TextBox4.Text = "";
                    TextBox5.Text ="";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text ="";
                    TextBox10.Text ="" ;
                    TextBox3.Text = "";

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");

            }

        }





        void updatestatusbyid(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='"+status+"' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('STATUS UPDATED SUCCESSFULLY')</script>");
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }


        //active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updatestatusbyid("active");
        }
        //pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updatestatusbyid("pending");
        }
        //delete
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updatestatusbyid("deactive");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            deleteUserbyid();

    }
        void deleteUserbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete member_master_tbl  WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('MEMBER DELETED SUCCESSFULLY')</script>");
               
                clearform();
                GridView1.DataBind();





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
        void clearform()
        {
            TextBox2.Text = ""; //fullname
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox3.Text = "";
        }
    }
}