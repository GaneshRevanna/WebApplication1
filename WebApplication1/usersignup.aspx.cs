using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckMemberExist())
            {
                Response.Write("<script> alert('This member Id already exists so try some other id');</script>");
            }
            else
            {
                signupnewuser();
                
            }
           

        }
        //new userdefined function
        bool CheckMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" +TextBox8.Text.Trim()+ "'; ", con);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;   
                }

            }
            catch(Exception ex) 
            {
                Response.Write("<script>('" + ex.Message+ "');</script>");
                return false;
            }
          
        }
        void signupnewuser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('successfully signed up go to user login to login');</script>");
                

                //below script is used to redirect delay after script message
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "delayedRedirectScript",
                //"alert('User Sign Up succcessfully done go to user login to login'); setTimeout(function() { window.location='" + ResolveUrl("userlogin.aspx") + "'; }, 500);", true);
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
    }
}