<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="WebApplication1.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
     $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

     });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <%-- Book issuing Details --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>

                            </div>

                        </div>
                        <%-- image --%>
                        <div class="row">
                            <div class="col">
                                <center>


                                    <img width="80px" src="images/books.png" />
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
                                <label>Member Id</label>
                                <div class="form-group">
                                   <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button ID="Button5" runat="server" Text="Go" Class="btn btn-secondary  " OnClick="Button5_Click" />
                                    </div>
                                </div>








                            </div>
                            <div class="col-md-6">
                                <label>Book Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name" TextMode="SingleLine"></asp:TextBox>
                                        
                                    </div>
                                </div>



                            </div>

                        </div>
                        <%-- Second two text boxes --%>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                               </div>
                          </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>

                                        

                                    </div>
                                </div>



                            </div>

                        </div>
                        <%-- Third two text boxes --%>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Member Name" ReadOnly="False" TextMode="Date"></asp:TextBox>


                                </div>








                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Book Name" TextMode="Date" ReadOnly="False"></asp:TextBox>



                                </div>
                            </div>



                        </div>

                    </div>
                    <%-- Button --%>

                    <div class="row">
                        <%-- First button  --%>
                        <div class="col-6">
                            <div class="form-group">
                                <center>
                                    <asp:Button ID="Button1" runat="server" Text="Issue" Class="btn btn-primary btn-lg btn-block  " OnClick="Button1_Click" />
                                </center>
                            </div>



                        </div>
                        <%-- second button --%>
                        <div class="col-6">
                            <div class="form-group">

                                <asp:Button ID="Button3" runat="server" Text="Return" Class="btn btn-success btn-lg btn-block" OnClick="Button3_Click" />

                            </div>



                        </div>


                    </div>
                    <div>
                    </div>

                </div>
                <a href="home.aspx"><< Home page </a>
                </div>
                
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                </center>

                            </div>

                        </div>

                        
                        <%-- hr line --%>
                        <div class="row">
                            <div class="col">
                                <hr />
                                <%-- table --%>
                            </div>
                            </div>
                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString6 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString6.ProviderName %>" SelectCommand="SELECT [member_id], [member_name], [book_id], [book_name], [issue_date], [due_date] FROM [book_issue_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="member_id" HeaderText="member_id" ReadOnly="True" SortExpression="member_id" />
                                            <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                            <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                            <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                            <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                            <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
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
    

</asp:Content>
