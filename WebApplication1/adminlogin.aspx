<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication1.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                            <center>
                            <img width="150px" src="images/adminuser.png" />
                             </center>

                            </div>
                            
                        </div>
                         <div class="row">
                            <div class="col">
                            <center>
                            <h4>Admin Login</h4>
                             </center>

                            </div>
                            
                        </div>
                        <%-- TEXTBOX AND BUTTON --%>
                        <div class="row">
                            <div class="col">
                            <center>
                            <hr />
                             </center>

                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col">
                           <label>Admin Id</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin Id"></asp:TextBox>
                                </div>
                            
                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"  placeholder="Password"></asp:TextBox>
                            </div>
                               <div class="form-group">
                                <asp:Button ID="Button1" runat="server" Text="Login"  Class="btn btn-success btn-block" OnClick="Button1_Click1"/>
                                </div>
                                
                            </div>
                            
                        </div>
                        <a href="home.aspx"> << Home page </a> 
                    </div>

                </div>
                

            </div>

        </div>
    </div>
</asp:Content>
