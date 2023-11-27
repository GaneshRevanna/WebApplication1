using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //RANDOM PEOPLE
                if (Session["role"].Equals(""))
                {
                    //header links
                    LinkButton4.Visible = true;//view books
                    LinkButton1.Visible = true;//userlogin
                    LinkButton2.Visible = true;//signup

                    LinkButton3.Visible = false;//logout
                    LinkButton5.Visible = false;//hello user
                    //footer links
                    Linkbutton6.Visible = true;
                    Linkbutton7.Visible = false;
                    Linkbutton8.Visible = false; 
                    Linkbutton9.Visible = false;
                    Linkbutton10.Visible = false;
                   Linkbutton11.Visible = false;

                }
                //USER ROLE
                else if (Session["role"].Equals("user"))
                {
                    //headerlinks
                    LinkButton4.Visible = true;//view books
                    LinkButton1.Visible = false;//userlogin
                    LinkButton2.Visible = false;//signup

                    LinkButton3.Visible = true;//logout
                    LinkButton5.Visible = true;//hello user
                    LinkButton5.Text="Hello " +Session["fullname"].ToString();
                   
                    //footer links
                    Linkbutton6.Visible = true;
                    Linkbutton7.Visible = false;
                    Linkbutton8.Visible = false;
                    Linkbutton9.Visible = false;
                    Linkbutton10.Visible = false;
                    Linkbutton11.Visible = false;

                }
                //ADMIN ROLE
                else if (Session["role"].Equals ("admin"))
                {
                    //headerlinks
                    LinkButton4.Visible = true;
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton5.Visible = true;
                    LinkButton5.Text = "Hello Admin " ;
                    //footer links
                    Linkbutton6.Visible = false;
                    Linkbutton7.Visible = true;
                    Linkbutton8.Visible = true;
                    Linkbutton9.Visible = true;
                    Linkbutton10.Visible = true;
                    Linkbutton11.Visible = true;

                }
                //sign up role
                else if (Session["role"].Equals("signup"))
                {
                    //header links
                    LinkButton4.Visible = true;//view books
                    LinkButton1.Visible = true;//userlogin
                    LinkButton2.Visible = false;//signup

                    LinkButton3.Visible = false;//logout
                    LinkButton5.Visible = false;//hello user
                    //footer links
                    Linkbutton6.Visible = true;
                    Linkbutton7.Visible = false;
                    Linkbutton8.Visible = false;
                    Linkbutton9.Visible = false;
                    Linkbutton10.Visible = false;
                    Linkbutton11.Visible = false;

                }
                //login role
                else if (Session["role"].Equals("login page"))
                {
                    //header links
                    LinkButton4.Visible = true;//view books
                    LinkButton1.Visible = true;//userlogin
                    LinkButton2.Visible = true;//signup

                    LinkButton3.Visible = false;//logout
                    LinkButton5.Visible = false;//hello user
                    //footer links
                    Linkbutton6.Visible = true;
                    Linkbutton7.Visible = false;
                    Linkbutton8.Visible = false;
                    Linkbutton9.Visible = false;
                    Linkbutton10.Visible = false;
                    Linkbutton11.Visible = false;

                }
            }

            catch (Exception ex)
            {

            }
            
        }

        protected void Linkbutton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            Session["role"] = "login page";
            LinkButton4.Visible = true;//view books
            LinkButton1.Visible = true;//userlogin
            LinkButton2.Visible = true;//signup

            LinkButton3.Visible = false;//logout
            LinkButton5.Visible = false;//hello user
                                        //footer links
            Linkbutton6.Visible = true;
            Linkbutton7.Visible = false;
            Linkbutton8.Visible = false;
            Linkbutton9.Visible = false;
            Linkbutton10.Visible = false;
            Linkbutton11.Visible = false;
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            LinkButton4.Visible = true;//view books
            LinkButton1.Visible = true;//userlogin
            LinkButton2.Visible = true;//signup

            LinkButton3.Visible = false;//logout
            LinkButton5.Visible = false;//hello user
                                        //footer links
            Linkbutton6.Visible = true;
            Linkbutton7.Visible = false;
            Linkbutton8.Visible = false;
            Linkbutton9.Visible = false;
            Linkbutton10.Visible = false;
            Linkbutton11.Visible = false;
            Response.Redirect("home.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void Linkbutton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthor.aspx");
        }

        protected void Linkbutton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void Linkbutton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminnbookinventory.aspx");
        }

        protected void Linkbutton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void Linkbutton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }
    }
}