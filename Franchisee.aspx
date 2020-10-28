<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Franchisee.aspx.cs" Inherits="Franchisee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8.18.0/dist/sweetalert2.all.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/promise-polyfill"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <div id="personal-info">
        <div class="container">
            <div class="row">
                <h3>Become a Franchisee</h3>
            </div>
            <div class="row" style="text-align:-webkit-center;">
                <div class="main">
                    <div class="tbl-width">
                        <table class="edit-table">
                            <tr>
                                <td class="text">Name<span class="text-danger">*</span></td>
                                <td>
                                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span id="spnname" class="text-danger hide">This field is required.</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="text">Email<span class="text-danger">*</span></td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span id="spnemail" class="text-danger hide">This field is required.</span>
                                </td>
                            </tr>

                            <tr>
                                <td class="text">Mobile<span class="text-danger">*</span></td>
                                <td>
                                    <asp:TextBox ID="txtmob" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span id="spnmob" class="text-danger hide">This field is required.</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="text">Pincode<span class="text-danger">*</span></td>
                                <td>
                                    <asp:TextBox ID="txtpin" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span id="spnpin" class="text-danger hide">This field is required.</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="text">Address<span class="text-danger">*</span></td>
                                <td>
                                    <asp:TextBox ID="txtaddress" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span id="spnaddr" class="text-danger hide">This field is required.</span>
                                </td>
                            </tr>
                        </table>
                        <div class="save-text">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" id="Button1" class="save-btn" runat="server" value="Submit" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
         $(document).ready(function () {
          $('.offer-time').css('display','none');
      });
        $("#ContentPlaceHolder1_Button1").click(function () {
            var name = $("#ContentPlaceHolder1_txtname").val();
            var email = $("#ContentPlaceHolder1_txtemail").val();
            var mobile = $("#ContentPlaceHolder1_txtmob").val();
            var pin = $("#ContentPlaceHolder1_txtpin").val();
            var addr = $("#ContentPlaceHolder1_txtaddress").val();

            $("#spnname").addClass('hide');
            $("#spnemail").addClass('hide');
            $("#spnmob").addClass('hide');
            $("#spnpin").addClass('hide');
            $("#spnaddr").addClass('hide');

            var flag = true;

            if (name == "") {
                $("#spnname").removeClass('hide');
                flag = false;
            }
            if (email == "") {
                $("#spnemail").removeClass('hide');
                flag = false;
            }
            if (mobile == "") {
                $("#spnmob").removeClass('hide');
                flag = false;
            }
            if (pin == "") {
                $("#spnpin").removeClass('hide');
                flag = false;
            }
            if (addr == "") {
                $("#spnaddr").removeClass('hide');
                flag = false;
            }


            var obj = {
                Name: name,
                Email: email,
                Mobile: mobile,
                PinCode: pin,
                Address: addr
            }
            if (flag) {


                $.ajax({
                    type: "POST",
                    url: "Franchisee.aspx/Save",
                    data: JSON.stringify({ model: obj }),
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {
                        if (response.d.response == "1") {
                            swal({
                                title: "Successful!",
                                text: response.d.message,
                                icon: "success",
                                button: "Ok",
                            }).then((value) => {
                                window.location = "Default.aspx";
                            });
                        } else {
                            swal({
                                title: "Error!",
                                text: response.d.message,
                                icon: "error",
                                button: "Ok",
                            });
                        }
                    },
                    failure: function (response) {
                        alert("err");
                    }
                });
            } else {
                $("#ContentPlaceHolder1_txtname").focus();
            }

        });
    </script>
</asp:Content>

