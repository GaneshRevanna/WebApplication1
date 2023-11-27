<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminnbookinventory.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   <script>
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

       });
       function readURL(input) {
            if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgview').attr('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0]);

       
    }
       }
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
                                    <h4>Book Details</h4>
                                </center>

                            </div>

                        </div>
                        <%-- image --%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" width="150" src="images/books.png" />
                                </center>

                            </div>

                        </div>
                        <%-- horizonta line --%>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <%-- FILE CHOOSEN BUTTON --%>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload1"  runat="server" />
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
                                <label>Book Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" ReadOnly="False"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Go" Class="btn btn-primary" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Book name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name" TextMode="SingleLine" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <%-- Second three textboxes --%>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="A1" Value="a1" />
                                        <asp:ListItem Text="a2" Value="a2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5" Visible="True">
                                        <asp:ListItem Text="action" Value="action" />
                                        <asp:ListItem Text="adventure" Value="adventure" />
                                        <asp:ListItem Text="comicBook" Value="comicBook" />
                                        <asp:ListItem Text="SelfHelp" Value="SelfHelp" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <%-- Third thre text box --%>
                        <div class="row">
                               <div class="col-md-4">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="A1" Value="a1" />
                                        <asp:ListItem Text="a2" Value="a2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-4">
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="pin code" TextMode="Date" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Fourth three textboxes --%>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Edition" ReadOnly="False"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Cost(per unit)" TextMode="Number" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Pages" TextMode="Number" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- 5th 3 text boxes --%>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Actual Stock" ReadOnly="False" TextMode="Number"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="current stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Issued books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- last text box --%>
                        <div clas="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Book Description" ReadOnly="False" TextMode="MultiLine" Text=""></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <%-- Button --%>
                        <div class="row">
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block  " ID="Button5" runat="server" Text="Add" OnClick="Button5_Click1" />
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-warning btn-block  " ID="Button1" runat="server" Text="update" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-danger btn-block " ID="Button3" runat="server" Text="delete" OnClick="Button3_Click" />
                                </div>
                            </div>
                        </div>


                        <div>
                        </div>

                    </div>

                </div>
                <a href="home.aspx"><< Home page </a>
            </div>
            <%-- Book Inventory  List --%>
            <div class="col-md-6">
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
                                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
</asp:Content>
