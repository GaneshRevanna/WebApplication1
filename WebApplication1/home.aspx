<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- 1st section --%>
<section>
    <img src="images/home-bg.jpg" class="img-fluid" />
</section>

    <%-- 2nd Section --%>
<section>
    <%-- 3 IMAGES CONTAINER --%>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                <h2>Our Features</h2>
                <p><b>3 Primary Features:</b></p>
                </center>

            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <center>
                <img width="150px" src="images/digital-inventory.png" />
                <h4>Digital Book Inventory </h4>
                <p class="text-justify">This is a digital book inventory system it will accupy the the advantages of inventoring the books digitally and verifying the things will never get occupied vy something</p>
                </center>
            </div>
            <div class="col-md-4">
                <center>
                 <img width="150px" class="img-fluid" src="images/defaulters-list.png" />
                <h4>Defaulters List </h4>
                <p class="text-justify">Defaulters list who alla are still didnt returned the books they are not allowed to take books and they were in defaulters list they not allowed to taking the books</p>
                </center>
            </div>
            <div class="col-md-4">

                <center>
                 <img width="150px" class="img-fluid" src="images/search-online.png" />
                <h4>Search Books</h4>
                <p class="text-justify">Searching the books any one can search the needed books and they can take the books and within the due date they need to return up all the books else they will allowed for the defaulters list </p>
                </center>
            </div>

        </div>


    </div>

</section>

    <%-- 3rd Section --%>
<section>
    <img src="images/in-homepage-banner.jpg" class="img-fluid" />

</section>

    <%-- 4th section --%>
    <section>
    <%-- 3 IMAGES CONTAINER --%>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                <h2>Our Process</h2>
                <p><b>3 Primary Process</b></p>
                </center>

            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <center>
                <img class="img-fluid" src="images/sign-up.png" width="150px" />
                <h4>Signup </h4>
                <p class="text-justify">This is a digital book inventory system it will accupy the the advantages of inventoring the books digitally and verifying the things will never get occupied vy something</p>
                </center>
            </div>
            <div class="col-md-4">
                <center>
                 <img class="img-fluid" src="images/library.png" width="150px" />
                <h4>Visit us</h4>
                <p class="text-justify">Defaulters list who alla are still didnt returned the books they are not allowed to take books and they were in defaulters list they not allowed to taking the books</p>
                </center>
            </div>
            <div class="col-md-4">

                <center>
                 <img width="150px" class="img-fluid" src="images/search-online.png" />
                <h4>Search Books</h4>
                <p class="text-justify">Searching the books any one can search the needed books and they can take the books and within the due date they need to return up all the books else they will allowed for the defaulters list </p>
                </center>
            </div>

        </div>


    </div>

</section>
</asp:Content>
