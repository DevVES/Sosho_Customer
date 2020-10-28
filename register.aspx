<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="register-mobile">
        <div class="container">
            <div class="row">
                <h3>Sign Up</h3>
            </div>
            <div class="row options-inner">
                <%--<p class="login-title">Please Fill below Details as per Requirements</p>--%>

                <div class="col-md-12 col-sm-12">
                    <div class="left-section">
                        <p>Please enter your 10-digit mobile number for OTP verification</p>
                        <div class="enter-mobileno">
                            <asp:DropDownList ID="DropDownList1" style="border-radius:0" runat="server" CssClass="form-text">
                                <asp:ListItem>+91</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtMobileNumber" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" MaxLength="10" CssClass="form-text"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnVerify" CssClass="verify-btn" runat="server" Text="Verify" OnClick="Button1_Click" />
                        </div>
                        <div style="display:none">
                            <asp:Label ID="lblflag" runat="server"></asp:Label>
                            <asp:Label ID="lblqty" runat="server"></asp:Label>

                        </div>
                        <div class="divider-text">
                            <span class="bg-light hide">OR</span>
                        </div>
                    </div>
                </div>
                <%--       <div class="col-md-2">
                            <p class="divider-text">
                                <span class="bg-light">OR</span>
                            </p>
                        </div>--%>
                <div class="col-md-6 col-sm-12 hide">
                    <div class="login-fb">
                        <div class="inner">
                            <div class="inline">
                                <img src="images/register/facebook-logo%20(1).png" />
                                <p>Login with Facebook</p>
                            </div>
                        </div>
                    </div>
                    <div class="login-twitter">
                        <div class="inner">
                            <div class="inline">
                                <img src="images/register/twitter%20(2).png" />
                                <p>Login with Twitter</p>
                            </div>
                        </div>
                    </div>
                    <div class="login-google">
                        <div class="inner">
                            <div class="inline">
                                <img src="images/register/google-plus.png" />
                                <p>Login with Google plus</p>
                            </div>
                        </div>
                    </div>
                    <div class="login-linkedin">
                        <div class="inner">
                            <div class="inline">
                                <img src="images/register/linkedin-logo.png" />
                                <p>Login with LinkedIn</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
        <script>
            $(document).ready(function () {
                
                //const urlParams1 = new URLSearchParams(window.location.search);
               
                //if (urlParams1 != null && urlParams1 != "")
                //{
                    lbllogout.innerHTML = "";
                //}
                    $(".mobile-number").hide();
                $('.offer-time').css('display', 'none');
                
            });
        </script>

    </div>


</asp:Content>
