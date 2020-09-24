<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/css/select2.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/css/select2.min.css"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/js/i18n/af.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8.18.0/dist/sweetalert2.all.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/promise-polyfill"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <style>
        #checkout {
            padding-top: 0px !important;
        }

        .offer-time {
            padding: 7px !important;
        }

        .required:after {
            content: "*";
            color: red;
            font-weight: bold;
        }

        small {
            color: red;
        }

        .complete {
            visibility: hidden;
            position: absolute;
            right: 0;
            top: 20px;
            color: #BEEE62;
        }
    </style>
    <div id="checkout">
        <div class="wrapper">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row cart-body padding">
                <div id="addresslist" runat="server">
                    <%--<div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 mob-padding">
                    <!--SHIPPING METHOD-->
                    <div class="panel-info">
                        <div class="row">
                        <div class="panel-heading">
                            <h3>Existing Address</h3></div>
                          </div>--%>

                    <%--      <div class="panel-body">
                           <div class="col-md-12 edit-address padding" style="display:flex">
                               <div class="col-md-8 col-sm-8 left padding" style="width:80%">

                                    <span class="name" id="txtname" runat="server"><strong>Pratixa </strong></span>
                                   <span class="name" id="txtsurname" runat="server"><strong>Patel </strong></span>

                                   <div class="tag">
                          
                                  <p id="lbltagid" runat="server">Family</p> 

                                   </div>
                                 <span style="color: #2c2c2c;font-size:15px;font-weight: 700;padding: 0 0 0 12px;margin:0;" id="lblmobilno" runat="server">7069926537</span>

                               </div>
                                       <div class="col-md-4 col-sm-4 right padding" style="width:20%">
                                    
                                    <a class="edit" id="btnedit" runat="server" data-toggle="modal" data-target="#MyPopup"><i class="fa fa-edit" runat="server"></i></a>
                                   <button class="delete" id="btndelete" runat="server"><i class="fa fa-trash"></i></button>
                                   </div>
                                </div>
                      
                            <hr />
                            <div class="address">
                          
                            </div>
                           
                          
                            <hr />
                        <div  style="text-align:center"> <button id="btnsave" runat="server" class="deliver-btn"  onclick="Deliverydone(1)">Deliver Here</button>
                            
                        </div>
                        </div>--%>


                    <%--  </div>
                        </div>--%>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 padding">
                    <!--SHIPPING METHOD-->
                    <div class="panel-info">
                        <div class="row">
                            <div class="panel-heading">
                                <h3>Shipping Address</h3>
                            </div>
                        </div>
                        <div class="row panel">
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-md-12 form-group">
                                        <strong class="required">Full Name:</strong>
                                        <input type="text" name="first_name" class="form-control" id="txtfname" runat="server" required="" placeholder="First Name" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-name"></small>
                                    </div>
                                    <div class="col-md-6 form-group hide">
                                        <strong class="required">Last Name:</strong>
                                        <input type="text" name="last_name" class="form-control" id="txtlname" required="" runat="server" placeholder="Last Name" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-username"></small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Tag:</strong>
                                        <asp:DropDownList ID="Tag" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Country:</strong>
                                        <asp:DropDownList ID="Country" runat="server" class="section2" AutoPostBack="false" onChange="return GetState(this)">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong class="required">State:</strong>
                                        <asp:DropDownList ID="state" runat="server" class="select2" AutoPostBack="false" onChange="return GetCity(this)">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <strong class="required">City:</strong>
                                        <asp:DropDownList ID="city" runat="server" class="select section2" AutoPostBack="false">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Mobile Number:</strong>
                                        <input type="text" name="phone_number" class="form-control" value="" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" maxlength="10" runat="server" id="mobileno" placeholder="Mobil No" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-mobile"></small>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <strong class="required">Pin Code:</strong>
                                        <input type="text" name="address" class="form-control" value="" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" onchange="checkservices(0)" maxlength="6" id="Text2" runat="server" placeholder="Ahmedabad Only"  />
                                        <%-- <p style="color:cadetblue;padding:0px 12px 0">Service Available</p>--%>
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-pin"></small>
                                        <small style="display:none;" id="alert-pin-service">Service not available.</small>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Location:</strong>
                                        <input type="text" name="location" class="form-control" value=""  runat="server" id="txtLocation" placeholder="Location" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-location"></small>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <strong class="required">Area:</strong>
                                        <input type="text" name="area" class="form-control" value=""  id="txtArea" runat="server" placeholder="Area"  />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-Area"></small>
                                    </div>


                                </div>
                                <div class="form-group">
                                    <div class="col-md-12"><strong class="required">Address:</strong></div>
                                    <div class="col-md-12 form-group ">
                                        <textarea style="width: 100%;" id="txtaddr" class="form-control" runat="server" placeholder="Address"></textarea>
                                        <small id="alert-addr"></small>
                                        <%--<input type="text" name="address" class="form-control" value="" id="txtaddr" runat="server" />--%>
                                    </div>
                                </div>
                                <%-- <div class="form-group">
                                <div class="col-md-12"><strong class="required">Email:</strong></div>
                                <div class="col-md-12 form-group">
                                    <input type="text"  name="" class="form-control" placeholder="EmailId" value=""  runat="server" id="Text1"/>
                                    <i class="fa fa-check complete" aria-hidden="true"></i>
                                    <small id="alert-email"></small>
                                     </div>
                                   
                               </div>--%>
                                <div class="form-group" style="text-align: center">
                                    <div class="col-md-12">
                                        <%--<button onclick="storedata()" id="DeliverHere" runat="server" class="deliver-btn">Deliver Here</button>--%>
                                        <button onclick="pincodetest(0)" id="DeliverHere" runat="server" class="deliver-btn">Deliver Here</button>
                                    </div>
                                </div>
                                <asp:Literal ID="ltrerr123" runat="server"></asp:Literal>
                                <div id="divMyText" style="display: none">

                                    <asp:Label ID="lblCustid1" runat="server"></asp:Label>
                                    <asp:Label ID="lbladdressid" runat="server"></asp:Label>
                                    <asp:Label ID="lblWhatsAppNo" runat="server"></asp:Label>
                                    <asp:Label ID="lblPinCode" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: whitesmoke">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title">Edit Deliver Address</h4>
                </div>
                <div class="modal-body">
                    <!-- Advance Filter-->
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-md-12">

                            <div class="col-md-12 col-xs-12">
                                <label><strong class="required">Full Name</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppfname" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-editname"></small>
                            </div>
                            <%-- <div class="col-md-4 col-xs-12">
                                                        
                                                            <label>Last Name.</label>
                                                             <asp:TextBox CssClass="form-control" ID="pplastname" runat="server" PlaceHolder="LastName"></asp:TextBox>
                                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                                            <small id="alert-editlname"></small>
                                                    </div>--%>

                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Tag Name.</strong></label>
                                <asp:DropDownList ID="ppddltag" runat="server"></asp:DropDownList>

                            </div>
                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Country Name.</strong></label>

                                <asp:DropDownList ID="ppcounty" runat="server" AutoPostBack="false" onChange="return GetState(this)"></asp:DropDownList>

                            </div>

                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">State Name.</strong></label>

                                <asp:DropDownList ID="ppstate" runat="server" AutoPostBack="false" onChange="return GetCity(this)">
                                </asp:DropDownList>

                            </div>

                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">City Name.</strong></label>
                                <asp:DropDownList ID="ppcity" runat="server"></asp:DropDownList>

                            </div>

                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Mobile No.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppmobil" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-editmbno"></small>
                            </div>
                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Pincode.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="pppincode" runat="server" onchange="checkservices(1)" MaxLength="6"></asp:TextBox>
                             
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small style="display:none;" id="alert-editpin">Service not available.</small>
                                <small style="display:none;" id="alert-editpin1">Service not available.</small>
                            </div>
                            <%--  <div class="col-md-4 col-xs-12">
                                                        
                                                            <label>Email.</label>
                                                             <asp:TextBox CssClass="form-control" ID="ppemail" runat="server"></asp:TextBox>
                                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                                            <small id="alert-editmail"></small>
                                                    </div>--%>
                            <div class="col-md-12 col-xs-12">

                                <label><strong class="required">Address.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppaddr" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-editaddr"></small>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px; padding-bottom: 10px;">
                        <div class="col-md-4"></div>
                        <div class="col-md-4 col-sm-12">
                            <style>
                                .btn {
                                    background-color: #5bc0de !important;
                                    border-color: #46b8da !important;
                                }
                            </style>
                            <button id="Button1" runat="server" class="btn btn-block btn-info" onclick="pincodetest(1)">SAVE AND DELIVER HERE</button>
                        </div>
                        <div class="col-md-4"></div>

                    </div>
                    <!-- Advance Filter-->
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" style="background-color: red!important" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.offer-time').css('display', 'none');
            
            $("#btnsendMessage").text($('#ContentPlaceHolder1_lblWhatsAppNo').text());
      });
        let checkmark = document.getElementsByClassName('complete');
        function alphanumeric(data) {
            let letters = /^[0-9a-zA-Z]+$/;
            if (letters.test(data)) {
                return true;
            }
            return false;
        }

        function validateEmail(data) {
            let testData = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (testData.test(data)) {
                return true;
            }
            return (false)
        }

        function disableButton() {
            document.getElementById('ContentPlaceHolder1_DeliverHere').disabled = true;
        }

        function enableButton() {
            document.getElementById('ContentPlaceHolder1_DeliverHere').disabled = false;
        }

        document.getElementById('ContentPlaceHolder1_txtfname').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_txtfname').value;
            if (status.length < 5) {
                document.getElementById('alert-name').innerHTML = 'Name field is empty or less than 10 characters!';
                checkmark[0].classList.remove('active');
                disableButton();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-name').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButton();
                //}
            else {
                document.getElementById('alert-name').innerHTML = '';
                checkmark[0].classList.add('active');
                enableButton();
            }
        };

        //document.getElementById('ContentPlaceHolder1_txtlname').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_txtlname').value;
        //    if (status.length < 5) {
        //        document.getElementById('alert-username').innerHTML = 'Username field is empty or less than 5 characters';
        //        checkmark[1].classList.remove('active');
        //        disableButton();
        //    } else if (!alphanumeric(status)) {
        //        document.getElementById('alert-username').innerHTML = 'Invalid characters!';
        //        checkmark[1].classList.remove('active');
        //        disableButton();
        //    } else {
        //        document.getElementById('alert-username').innerHTML = '';
        //        checkmark[1].classList.add('active');
        //        enableButton();
        //    }
        //};

        document.getElementById('ContentPlaceHolder1_mobileno').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_mobileno').value;
            if (status.length < 10) {
                document.getElementById('alert-mobile').innerHTML = "Please put 10 digit mobile number";
                checkmark[2].classList.remove('active');
                disableButton();
            } else {
                document.getElementById('alert-mobile').innerHTML = '';
                checkmark[2].classList.add('active');
                enableButton();
            }
        }
        document.getElementById('ContentPlaceHolder1_Text2').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_Text2').value;
            if (status.length < 6) {
                document.getElementById('alert-pin').innerHTML = "Please put 6 digit of pincode";
                checkmark[3].classList.remove('active');
                disableButton();
            } else {
                document.getElementById('alert-pin').innerHTML = '';
                checkmark[3].classList.add('active');
                enableButton();
            }
        }
        document.getElementById('ContentPlaceHolder1_txtaddr').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_txtaddr').value;
            if (status.length < 15) {
                document.getElementById('alert-addr').innerHTML = "Please enter proper address";
                checkmark[4].classList.remove('active');
                disableButton();
            } else {
                document.getElementById('alert-addr').innerHTML = '';
                checkmark[4].classList.add('active');
                enableButton();
            }
        }
        //document.getElementById('ContentPlaceHolder1_Text1').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_Text1').value;
        //    if (status.length < 0) {
        //        document.getElementById('alert-email').innerHTML = 'Email field is empty';
        //        checkmark[5].classList.remove('active');
        //        disableButton();
        //    } else if (!validateEmail(status)) {
        //        document.getElementById('alert-email').innerHTML = 'Invalid email address!';
        //        checkmark[5].classList.remove('active');
        //        disableButton();
        //    } else {
        //        document.getElementById('alert-email').innerHTML = '';
        //        checkmark[5].classList.add('active');
        //        enableButton();
        //    }
        //};
    </script>
    <script>
        /*for edit form*/

        function alphanumeric(data) {
            let letters = /^[0-9a-zA-Z]+$/;
            if (letters.test(data)) {
                return true;
            }
            return false;
        }

        function validateEmail(data) {
            let testData = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (testData.test(data)) {
                return true;
            }
            return (false)
        }

        function disableButtonedit() {
            document.getElementById('ContentPlaceHolder1_Button1').disabled = true;
        }

        function enableButtonedit() {
            document.getElementById('ContentPlaceHolder1_Button1').disabled = false;
        }
        document.getElementById('ContentPlaceHolder1_ppfname').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_ppfname').value;
            if (status.length < 3) {
                document.getElementById('alert-editname').innerHTML = 'Name field is empty or less than 3 characters!';
                checkmark[0].classList.remove('active');
                disableButtonedit();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-editname').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButtonedit();
                //}
            else {
                document.getElementById('alert-editname').innerHTML = '';
                checkmark[0].classList.add('active');
                enableButtonedit();
            }
        };

        //document.getElementById('ContentPlaceHolder1_pplastname').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_pplastname').value;
        //    if (status.length < 3) {
        //        document.getElementById('alert-editlname').innerHTML = 'Username field is empty or less than 5 characters';
        //        checkmark[1].classList.remove('active');
        //        disableButtonedit();
        //    } else if (!alphanumeric(status)) {
        //        document.getElementById('alert-editlname').innerHTML = 'Invalid characters!';
        //        checkmark[1].classList.remove('active');
        //        disableButtonedit();
        //    } else {
        //        document.getElementById('alert-editlname').innerHTML = '';
        //        checkmark[1].classList.add('active');
        //        enableButtonedit();
        //    }
        //};

        document.getElementById('ContentPlaceHolder1_ppmobil').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_ppmobil').value;
            if (status.length < 10) {
                document.getElementById('alert-editmbno').innerHTML = "Please put 10 digit mobile number";
                checkmark[2].classList.remove('active');
                disableButtonedit();
            } else {
                document.getElementById('alert-editmbno').innerHTML = '';
                checkmark[2].classList.add('active');
                enableButtonedit();
            }
        }
        document.getElementById('ContentPlaceHolder1_pppincode').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_pppincode').value;
            if (status.length < 6) {
                document.getElementById('alert-editpin').innerHTML = "Please put 6 digit of pincode";
                checkmark[3].classList.remove('active');
                disableButtonedit();
            } else {
                document.getElementById('alert-editpin').innerHTML = '';
                checkmark[3].classList.add('active');
                enableButtonedit();
            }
        }
        document.getElementById('ContentPlaceHolder1_ppaddr').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_ppaddr').value;
            if (status.length < 5) {
                document.getElementById('alert-editaddr').innerHTML = "Please enter proper address";
                checkmark[4].classList.remove('active');
                disableButtonedit();
            } else {
                document.getElementById('alert-editaddr').innerHTML = '';
                checkmark[4].classList.add('active');
                enableButtonedit();
            }
        }
        //document.getElementById('ContentPlaceHolder1_ppemail').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_ppemail').value;
        //    if (status.length < 0) {
        //        document.getElementById('alert-editmail').innerHTML = 'Email field is empty';
        //        checkmark[5].classList.remove('active');
        //        disableButtonedit();
        //    } else if (!validateEmail(status)) {
        //        document.getElementById('alert-editmail').innerHTML = 'Invalid email address!';
        //        checkmark[5].classList.remove('active');
        //        disableButtonedit();
        //    } else {
        //        document.getElementById('alert-editmail').innerHTML = '';
        //        checkmark[5].classList.add('active');
        //        enableButtonedit();
        //    }
        //};


    </script>
    <script type="text/javascript">
        //function checkfnamne() {
        //    var fname = $("#ContentPlaceHolder1_txtfname").val();
        //    if (fname.length < 3) {
        //        alert("Enter Proper Name.");
        //        $("#ContentPlaceHolder1_txtfname").focus();
        //        return;
        //    }
        //}
        //function checklnamne() {
        //    var lname = $("#ContentPlaceHolder1_txtlname").val();
        //       if (lname.length < 3) {
        //        alert("Enter Proper Name.");
        //        $("#ContentPlaceHolder1_txtlname").focus();
        //        return;
        //    }
        //}
        //function checkaddr() {
        //    var addr = $("#ContentPlaceHolder1_txtaddr").val();
        //    if (addr.length < 20) {
        //        alert("Enter Proper Address");
        //        $("#ContentPlaceHolder1_txtaddr").focus();
        //        return;
        //    }
        //}
        //function countryselect() {
        //    var con = $("ContentPlaceHolder1_Country").val();
        //    if (con.value == "Default") {
        //        alert('Select your country from the list');
        //        $("ContentPlaceHolder1_Country").focus();
        //        return false;
        //    }
        //    else {
        //        return true;
        //    }
        //}

        function pincodetest(val)
        {
            
            var pincode = "";
            if (val == 0) {
                pincode = $("#ContentPlaceHolder1_Text2").val();
            }
            if (val == 1) {
                pincode = $("#ContentPlaceHolder1_pppincode").val();
            }

            var msg1 = "<%=clsCommon.Pincodemaxlen6erromsg%>";
            var strlen = pincode.length;
            
            $.ajax({

                type: "POST",
                url: "Default.aspx/PincodeCheck",
                data: '{Pincode:"' + pincode + '"}',
                contentType: "application/json",
                dataType: "json",

                success: function (response) {

                    var getdata = {
                        data: JSON.parse(response.d),
                    }

                    var result = getdata.data.resultflag;


                    var message = getdata.data.Message;


                    if (result == "1") {

                        if (val == 0) {
                            storedata();
                        }
                        if (val == 1) {
                            Saveanddeliver();
                        }

                    }
                    else {
                        return;
                    }
                },
                failure: function (response) {

                    alert("Something Wrong....");
                    return;
                }
            });
        }

        function checkservices(val) {

            var flag = Number(val);
            var pincode = "";
            if (val == 0) {
                pincode = $("#ContentPlaceHolder1_Text2").val();
            }
            if (val == 1) {
                pincode = $("#ContentPlaceHolder1_pppincode").val();
            }

            var msg1 = "<%=clsCommon.Pincodemaxlen6erromsg%>";
             var strlen = pincode.length;
             //if (strlen == 6)
             //{
             $.ajax({

                 type: "POST",
                 url: "Default.aspx/PincodeCheck",
                 data: '{Pincode:"' + pincode + '"}',
                 contentType: "application/json",
                 dataType: "json",

                 success: function (response) {

                     var getdata = {
                         data: JSON.parse(response.d),
                     }

                     var result = getdata.data.resultflag;


                     var message = getdata.data.Message;
                     

                     if (result == "1") {
                      
                         $("#alert-pin-service").hide();
                         $("#alert-editpin").hide();
                         $("#alert-editpin1").hide();
                         return ;
                         
                     }
                     else {
                         $("#alert-editpin").show();
                         $("#alert-editpin1").show();
                         $("#alert-pin-service").show();
                         $("#ContentPlaceHolder1_Text2").val('');
                         $("#ContentPlaceHolder1_pppincode").val('');
                         return;
                     }
                 },
                 failure: function (response) {

                     alert("Something Wrong....");
                     return;
                 }
             });
             //}

         }

         //Show popup
         function ShowPopup() {
             $("#MyPopup").modal("show");
         }

         //get State Select On Country
         function GetState(e) {
             var id = e.options[e.selectedIndex].value;

             document.getElementById("ContentPlaceHolder1_state").innerHTML = "";
             document.getElementById("ContentPlaceHolder1_ppstate").innerHTML = "";

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/GetMainCourse",
                 data: '{id: "' + id + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     var products = response.d.split("###");
                     var dropdown = document.getElementById("ContentPlaceHolder1_state");
                     var pdropdown = document.getElementById("ContentPlaceHolder1_ppstate");
                     for (var i = 0; i < products.length; i++) {
                         var listoption = products[i].split(',');
                         dropdown[dropdown.length] = new Option(listoption[1], listoption[0]);
                         pdropdown[dropdown.length] = new Option(listoption[1], listoption[0]);
                     }
                     //Default Selected
                     //$("#ContentPlaceHolder1_ppstate").val("1".statename).select;
                     //$("#ContentPlaceHolder1_ppstate").select("1".statename.selectedIndex);
                 },
                 failure: function (response) {
                     alert(response.d);
                 }
             });
             return false;
         }

         //Get City Select On State
         function GetCity(e) {
             var id = e.options[e.selectedIndex].value;

             document.getElementById("ContentPlaceHolder1_city").innerHTML = "";
             document.getElementById("ContentPlaceHolder1_ppcity").innerHTML = "";

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/GetCityList",
                 data: '{id: "' + id + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     var products = response.d.split("###");
                     var dropdown = document.getElementById("ContentPlaceHolder1_city");
                     var dropdownpop = document.getElementById("ContentPlaceHolder1_ppcity");
                     for (var i = 0; i < products.length; i++) {
                         var listoption = products[i].split(',');
                         dropdown[dropdown.length] = new Option(listoption[1], listoption[0]);
                         dropdownpop[dropdown.length] = new Option(listoption[1], listoption[0]);
                     }
                 },
                 failure: function (response) {
                     alert(response.d);
                 }
             });
             return false;
         }

         //Edit Address Details
         function Editaddr(Addid) {

             $("#ContentPlaceHolder1_lbladdressid").html(Addid);

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/EditAddress",
                 data: '{id: "' + Addid + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (ResponseData) {
                     // alert(ResponseData.d.OrderCustomerList[0].Cfname);
                     $("#ContentPlaceHolder1_ppfname").val(ResponseData.d.OrderCustomerList[0].Cfname);
                     $("#ContentPlaceHolder1_pplastname").val(ResponseData.d.OrderCustomerList[0].Clname);
                     $("#ContentPlaceHolder1_ppmobil").val(ResponseData.d.OrderCustomerList[0].cph);
                     $("#ContentPlaceHolder1_pppincode").val(ResponseData.d.OrderCustomerList[0].pincode);
                     $("#ContentPlaceHolder1_ppemail").val(ResponseData.d.OrderCustomerList[0].Email);
                     $("#ContentPlaceHolder1_ppaddr").val(ResponseData.d.OrderCustomerList[0].addr);

                     $("#ContentPlaceHolder1_ppddltag").val(ResponseData.d.OrderCustomerList[0].tag).select;
                     $("#ContentPlaceHolder1_ppddltag").select(ResponseData.d.OrderCustomerList[0].tag.selectedIndex);

                     $("#ContentPlaceHolder1_ppcounty").val(1).select;
                     $("#ContentPlaceHolder1_ppcounty").select("1".selectedIndex);

                     $("#ContentPlaceHolder1_ppstate").val(ResponseData.d.OrderCustomerList[0].statename).select;
                     $("#ContentPlaceHolder1_ppstate").select(ResponseData.d.OrderCustomerList[0].statename.selectedIndex);

                     $("#ContentPlaceHolder1_ppcity").val(ResponseData.d.OrderCustomerList[0].Cityname).select;
                     $("#ContentPlaceHolder1_ppcity").select(ResponseData.d.OrderCustomerList[0].Cityname.selectedIndex);

                     $("#ContentPlaceHolder1_lbladdressid").val(ResponseData.d.OrderCustomerList[0].Caddrid);

                 },
                 failure: function (response) {
                     alert(response.d);
                 }
             });
             return false;
         }

         //Deleted Address
         function DeleteAddr(Addid) {

             //alert(Addid);
             swal({
                 title: "Sucessully!",
                 text: "Sucessfully Deleted Address!",
                 icon: "success",
                 button: "Ok",
             });
             var c = confirm("Do You to Want To Delete Address?")

             if (c == true) {
                 $.ajax({
                     type: "POST",
                     url: "checkout.aspx/DeleteAddress",
                     data: '{id: "' + Addid + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         //alert(response.d);

                         location.reload();
                     },
                     failure: function (response) {
                         alert(response.d);
                     }
                 });
             }

             return false;
         }
         //New Address Save
         function storedata() {

             var pincode = $('#ContentPlaceHolder1_Text2').val();
             if (pincode == "") {
                 $("#alert-pin-service").show();
                 return;
             }
             var countryid = $('#ContentPlaceHolder1_Country').children("option:selected").val();
             var sid = $('#ContentPlaceHolder1_state').children("option:selected").val();
             var cid = $('#ContentPlaceHolder1_city').children("option:selected").val();
             var tag = $('#ContentPlaceHolder1_Tag').children("option:selected").val();
             var addr = $('#ContentPlaceHolder1_txtaddr').val();
             var ph = $('#ContentPlaceHolder1_mobileno').val();
             var lname = $('#ContentPlaceHolder1_txtlname').val();
             var fname = $('#ContentPlaceHolder1_txtfname').val();
             var custid = $('#ContentPlaceHolder1_lblCustid1').html();
             var email = $('#ContentPlaceHolder1_Text1').val();
             

             var tagid = Number(tag);
             var statid = Number(sid);
             var ciiid = Number(cid);
             var couid = Number(countryid);
             
             if (tagid == "0") {
                
                 return;
             }
             if (couid == "0") {
                
                 return;
             }
             if (statid == "0") {
                
                 return;
             }
             if (ciiid == "0") {
                 
                 return;
             }
             
            
             

             if (addr == "") {
                
                 return;
             }

             if (fname == "") {
                
                 return;
             }


             if (ph == "") {
               
                 return;
             }

           

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/GetURL",
                 data: '{custid: "' + custid + '",fname1:"' + fname + '",lname:"' + lname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid + '",addr1:"' + addr + '",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '"}',

                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     //alert(response.d.LastId);
                     //var bar_data =
                     //  {
                     //      data: JSON.parse(response.d),
                     //  };

                     //var data123 = bar_data.data.LastId;

                     window.location = "OrderSummery.aspx";

                 },
                 failure: function (response) {
                     alert(response.d);
                 }
             });
             return false;
         }

         //Save Edited Addresss
         function Saveanddeliver() {
             checkservices(1);
             checkservices(0);
             var countryid = $('#ContentPlaceHolder1_ppcounty').children("option:selected").val();
             var sid = $('#ContentPlaceHolder1_ppstate').children("option:selected").val();
             var cid = $('#ContentPlaceHolder1_ppcity').children("option:selected").val();
             var tag = $('#ContentPlaceHolder1_ppddltag').children("option:selected").val();

             var tagid = Number(tag);
             var statid = Number(sid);
             var ciiid = Number(cid);
             var couid = Number(countryid);

             if (tagid == "0") {
                
                 return;
             }
             if (couid == "0") {
                
                 return;
             }
             if (statid == "0") {
                 
                 return;
             }
             if (ciiid == "0") {
                
                 return;
             }




             var addr = $('#ContentPlaceHolder1_ppaddr').val();
             var ph = $('#ContentPlaceHolder1_ppmobil').val();
             var lname = $('#ContentPlaceHolder1_pplastname').val();
             var fname = $('#ContentPlaceHolder1_ppfname').val();
             var custid = $('#ContentPlaceHolder1_lblCustid1').html();

             var email = $('#ContentPlaceHolder1_ppemail').val();
             var pincode = $('#ContentPlaceHolder1_pppincode').val();
             var addessid = $('#ContentPlaceHolder1_lbladdressid').html();

             if (fname == "") {

                 return;
             }
             if (ph == "") {

                 return;
             }
             if (pincode == "") {

                 return;
             }

             

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/saveandeditaddress",
                 data: '{custid: "' + custid + '",fname1:"' + fname + '",lname:"' + lname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid + '",addr1:"' + addr + '",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '",Addressid:"' + addessid + '"}',

                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (Repose) {

                     //alert(Repose.d);

                     if (Repose.d.Response = "1") {
                         window.location = "OrderSummery.aspx";
                     }
                     else {
                         alert("Data Not Found");
                     }
                 },
                 failure: function (response) {
                     alert("Something Wrong...");
                 }
             });
             return false;
         }

         function Deliverydone(addrid,pincode) {
             //alert(addrid);
             var addresssid = addrid;
             var addr = Number(addresssid);
             var Deliverypincode = pincode;
             var Pincodecheck = $('#ContentPlaceHolder1_lblPinCode').html();
             if (Deliverypincode == Pincodecheck) {
                 $.ajax({

                     type: "POST",
                     url: "checkout.aspx/passaddressid",
                     data: '{AddressIdd:"' + addr + '"}',
                     contentType: "application/json;charset=utf-8",
                     datatype: "json",
                     success: function (ResponseData) {
                         //alert(ResponseData.d);
                         if (ResponseData.d == "1") {
                             window.location = "OrderSummery.aspx";
                         }
                         else {
                             alert("Data Not Found");
                         }

                     },
                     failure: function (ResponseData) {
                         alert("Somthing Wrong");
                     }
                 });
                 return false;
             }
             else {
                 alert('Pincode is differet as you have selected.Please select same pincode which you have selected at home page else add new address');
                 return false;
             }
         }



    </script>


</asp:Content>

