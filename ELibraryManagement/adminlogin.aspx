<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ELibraryManagement.adminlogin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div class="container">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="150px" src="img/adminuser.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                         <div class="col">
                             <center>
                             <h3>Admin Login</h3>
                             </center>
                         </div>
                    </div>

                    <div class="row">
                         <div class="col">
                           <hr />
                         </div>
                    </div>

                      <div class="row">
                         <div class="col">
                               
                                   <label><b>Admin Id</b></label>
                                   <div class="form-group">
                                   <asp:TextBox class="form-control" runat="server" Id="TextBox1"
                                       placeholder="Admin Id" ></asp:TextBox>
                                   </div>
                                  <label><b>Password</b></label>
                                  <div class="form-group">
                                   <asp:TextBox class="form-control" runat="server" Id="TextBox2"
                                       placeholder="Password" TextMode="Password" ></asp:TextBox>
                                   </div>
                          
                             <div class="form-group">
                                 <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                 </div>

                         </div>
                           
                    </div>


                </div>
                
            </div>
             <a href="homepage.aspx"><< Back to Home</a>
            <br />
             <br />           
        </div>
    </div>
</asp:Content>
