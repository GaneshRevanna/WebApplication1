<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminusermanagement.aspx.cs" Inherits="WebApplication1.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <%-- Publisher Details --%>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>

                            </div>

                        </div>
                        <%-- image --%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80px" src="images/generaluser.png" />
                                    
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
                        <%-- 1st three text box in signup --%>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Member Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" ReadOnly="False" ></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Go" Class="btn btn-primary" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member Name" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Account Status</label> 
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Account status" TextMode="SingleLine" ReadOnly="True" ></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success mr-1" ID="LinkButton1" runat="server" Text="s" OnClick="LinkButton1_Click"><i class="fa-sharp fa-solid fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning mr-1" ID="LinkButton2" runat="server" Text="w" OnClick="LinkButton2_Click"><i class="fa-regular fa-circle-pause"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger mr-1" ID="LinkButton3" runat="server" Text="d" OnClick="LinkButton3_Click"> <i class="fa-solid fa-circle-xmark"></i></asp:LinkButton>
                                         
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- Second three textbix --%>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Dob</label>
                                <div class="form-group">
                                   
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>contact no</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="contact no" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Email-id</label> 
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID" TextMode="Email" ReadOnly="True" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Third thre text box --%>
                        <div class="row">
                            <div class="col-md-5">
                                <label>State</label>
                                <div class="form-group">
                                   
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="State" ReadOnly="True" ></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-3">
                                <label>Pin code</label> 
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="pin code" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- last text box --%>
                        <div clas="row">
                        <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                   
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Adress" ReadOnly="True" TextMode="MultiLine" Text=""></asp:TextBox>
                                       
                                </div>
                            </div>
                            </div>
                        <%-- Button --%>
                        <div clas="row">
                        <div class="col-12">
                                <div class="form-group">
                                   <asp:Button CssClass="btn btn-danger btn-lg btn-block" ID="Button5" runat="server" Text="Delete user permanently" OnClick="Button5_Click" />
                                </div>
                            </div>
                            </div>

                        
                        <div>
                        </div>

                    </div>

                </div>
                <a href="home.aspx"><< Home page </a>
            </div>
            <%-- Publisher List --%>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>

                            </div>

                        </div>

                        
                        <%-- hr line --%>
                        <div class="row">
                            <div class="col">
                                <hr />
                                
                            </div>
                            <%-- table --%>
                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT [dob], [full_name], [contact_no], [email], [pincode], [member_id], [password], [account_status] FROM [member_master_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" ReadOnly="True" />
                                            <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                                            <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                                            <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                                            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                            <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>


                            <div>
                            </div>

                        </div>

                    </div>
                </div>

            </div>


        </div>
    </div>
</asp:Content>
