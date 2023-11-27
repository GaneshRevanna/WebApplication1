<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication1.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
       <div class="row">
           <div class="col">
               <div class="card">
                    <div class="card-body">
                        <%-- title --%>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString5 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString5.ProviderName %>" SelectCommand="SELECT [book_id], [genre], [author_name], [publisher_name], [publish_date], [language], [edition], [book_cost], [book_description], [actual_stock], [current_stock], [book_img_link], [book_name] FROM [book_master_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                           
                                            <asp:TemplateField>

                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-lg-10">
                                                                <div class="row">
                                                                    <div class="col-12">

                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True"></asp:Label>

                                                                    </div>

                                                                </div>
                                                                  <div class="row">
                                                                      <div class="col-12">
                                                                      Author-<asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True"></asp:Label>
                                                                          &nbsp;|Genre-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                          &nbsp;| Language-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                          &nbsp;</div>
                                                                </div>
                                                                  <div class="row">
                                                                    <div class="col-12">

                                                                        Publisher-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                        &nbsp;|Publish Date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                        |Edition-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                    </div>

                                                                </div>
                                                                  <div class="row">
                                                                    <div class="col-12">

                                                                        Cost-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                        |Actual stock-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                        |Available stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                    </div>

                                                                </div>
                                                                  <div class="row">
                                                                    <div class="col-12">

                                                                        [DESCRIPTION]-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>' Font-Italic="True"></asp:Label>

                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Image CssClass="img-fluid " ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                           
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
</a
</asp:Content>
