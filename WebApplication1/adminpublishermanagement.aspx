<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="WebApplication1.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <%-- Publisher Details --%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>

                            </div>

                        </div>
                        <%-- image --%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                    <img width="80px" src="images/publisher.png" />
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
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Go" Class="btn btn-secondary  " OnClick="Button2_Click" />
                                    </div>
                                </div>








                            </div>
                            <div class="col-md-8">
                                <label>Publisher name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name" TextMode="SingleLine"></asp:TextBox>
                                </div>



                            </div>

                        </div>

                        <%-- Button --%>

                        <div class="row">
                            <%-- First button  --%>
                            <div class="col-4">
                                <div class="form-group">
                                    <center>
                                        <asp:Button ID="Button1" runat="server" Text="Add" Class="btn btn-success btn-lg btn-block  " OnClick="Button1_Click" />
                                    </center>
                                </div>



                            </div>
                            <%-- second button --%>
                            <div class="col-4">
                                <div class="form-group">
                                    <center>
                                        <asp:Button ID="Button3" runat="server" Text="Update" Class="btn btn-warning btn-lg btn-block" OnClick="Button3_Click" />
                                    </center>
                                </div>



                            </div>
                            <%-- third button --%>
                            <div class="col-4">
                                <div class="form-group">
                                    <center>
                                        <asp:Button ID="Button4" runat="server" Text="Delete" Class="btn btn-danger btn-lg btn-block" OnClick="Button4_Click" />
                                    
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
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher List</h4>
                                </center>

                            </div>

                        </div>

                        
                        <%-- hr line --%>
                        <div class="row">
                            <div class="col">
                                <hr />
                                
                            </div>
                            </div>
                            <%-- table --%>
                            <div class="row">
                                <div class="col">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                            <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
