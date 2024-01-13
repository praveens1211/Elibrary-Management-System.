<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ELibraryManagement.adminlogin" %>
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
                                <img width="150px" src="img/generaluser.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                         <div class="col">
                             <center>
                             <h3>User Login</h3>
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
                               
                                   <label><b>User Id</b></label>
                                   <div class="form-group">
                                   <asp:TextBox class="form-control" runat="server" Id="TextBox1"
                                       placeholder="UserId" ></asp:TextBox>
                                   </div>
                                  <label><b>Password</b></label>
                                  <div class="form-group">
                                   <asp:TextBox class="form-control" runat="server" Id="TextBox2"
                                       placeholder="Password" TextMode="Password" ></asp:TextBox>
                                   </div>
                          
                             <div class="form-group">
                                 <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                 </div>
                              <div class="form-group">
                             <a href="usersignup.aspx"><input class="btn btn-info btn-block btn-lg" id="Button1" type="button" value="Sign Up" />
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
