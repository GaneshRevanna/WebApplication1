<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                            <center>
                                <img width="100px" src="images/sign-up.png" />
                             </center>

                            </div>
                            
                        </div>
                         <div class="row">
                            <div class="col">
                            <center>
                            <h4>Member signup</h4>
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
                        <%-- 1st two text box in signup --%>
                        <div class="row">
                            <div class="col-md-6">
                           <label>Full name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full name"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                             <div class="col-md-6">
                           <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of birth" TextMode="Date"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                            
                        </div>
                        <%-- 2nd two text box in signup --%>
                        <div class="row">
                            <div class="col-md-6">
                           <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="contact no" TextMode="Phone"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                             <div class="col-md-6">
                           <label>  Mail Id</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Mail id" TextMode="Email"></asp:TextBox>
                                </div>
                            
                                 
                               
                            </div>
                            
                        </div>
                        <%-- 3rd three text box in signup --%>
                         <div class="row">
                            <div class="col-md-4">
                           <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control">
                                        <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                                    </asp:DropDownList>
                                </div>
                            

                               
                            </div>
                             <div class="col-md-4">
                           <label>city</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                                </div>
                            

                               
                            </div>
                             <div class="col-md-4">
                           <label>PIN Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="PIN CODE" TextMode="Number"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                            
                        </div>
                        <%-- 4th row address --%>
                        <div class="row">
                            <div class="col">
                           <label>Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                            
                            
                        </div>
                        <%-- pii badge --%>
                        <div class="row">
                            <div class="col">
                           
                               <center>
                                    <span class="badge badge-danger">Login Credentials</span>
                               </center>
                            

                               
                            </div>


                         
                    </div>
                        <%-- Login credentials --%>
                        <div class="row">
                            <div class="col-md-6">
                           <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                             <div class="col-md-6">
                           <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            

                               
                            </div>
                            
                        </div>
                        <%-- Button --%>

                        <div class="row">
                            <div class="col-8 mx-auto">
                           
                               <center>
                                   <div class="form-group">
                                   <asp:Button ID="Button1" runat="server" Text="Signup" class="btn btn-success btn-block" OnClick="Button1_Click"  />
                                            
                                   </div>
                               </center>
                            

                               
                            </div>
                </div>
                <div>
                    
             </div>
                        
             </div>
                    
                    </div>
                <a href="home.aspx"> << Home page </a>
                </div>
            
        </div>
         
    </div>
</asp:Content>
