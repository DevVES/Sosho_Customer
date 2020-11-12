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
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>--%>
    <%--<link href="css/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />--%>
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
        ul.ui-autocomplete {
            z-index: 1100;
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
                                 <%--   <div class="col-md-6 form-group">
                                        <strong class="required">Country:</strong>
                                        <asp:DropDownList ID="Country" runat="server" class="section2" AutoPostBack="false" onChange="return GetState(this)">
                                        </asp:DropDownList>

                                    </div>--%>
                                      <div class="col-md-6 form-group">
                                        <strong class="required">Mobile Number:</strong>
                                        <input type="text" name="phone_number" class="form-control" value="" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" maxlength="10" runat="server" id="mobileno" placeholder="Mobil No" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-mobile"></small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong >Email:</strong>
                                        <input type="text" name="email" class="form-control" value=""  runat="server" id="Text1" placeholder="Email" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Pin Code:</strong>
                                        <input type="text" name="address" class="form-control" value="" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" onchange="checkservices(0)" maxlength="6" id="Text2" runat="server" readonly="true" placeholder="Ahmedabad Only"  />
                                        <%-- <p style="color:cadetblue;padding:0px 12px 0">Service Available</p>--%>
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-pin"></small>
                                        <small style="display:none;" id="alert-pin-service">Service not available.</small>
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
                                  <%--  <div class="col-md-6 form-group">
                                        <strong class="required">Location:</strong>
                                        <input type="text" name="location" class="form-control" value=""  runat="server" id="txtLocation" placeholder="Location" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-location"></small>
                                    </div>--%>
                                       <div class="col-md-6 form-group">
                                        <strong class="required">Area:</strong>
                                        <input type="text" name="area" class="form-control" value=""  id="txtArea"  placeholder="Area"  />
                                        <input type="hidden" name="areaid" class="form-control" value="-1"  id="AreaId"   />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-Area"></small>
                                    </div>
                                      <div class="col-md-6 form-group">
                                        <strong class="required">Building/Society:</strong>
                                        <input type="text" name="building" class="form-control" value=""   id="txtBuilding" placeholder="Building/Society" />
                                          <input type="hidden" name="buildingid" class="form-control" value="-1"  id="BuildingId" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-building"></small>
                                    </div>
                                      


                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Building/Society#:</strong>
                                        <input type="text" name="buildingno" class="form-control" value=""  id="txtBuildingNo" placeholder="Building/Society#" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-buildingno"></small>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <strong class="required">Landmark:</strong>
                                        <input type="text" name="landmark" class="form-control" value=""  runat="server" id="txtLandmark" placeholder="Landmark" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                        <small id="alert-landmark"></small>
                                    </div>
                                   
                                    <%--<div class="col-md-12"><strong class="required">Address:</strong></div>
                                    <div class="col-md-12 form-group ">
                                        <textarea style="width: 100%;" id="txtaddr" class="form-control" runat="server" placeholder="Address"></textarea>
                                        <small id="alert-addr"></small>
                                        <%--<input type="text" name="address" class="form-control" value="" id="txtaddr" runat="server" />--%>
                                    <%--</div>--%>
                                </div>
                                 <div class="form-group">
                                    <div class="col-md-6 form-group">
                                        <strong>Other Details:</strong>
                                        <input type="text" name="other" class="form-control" value=""  id="txtOther" placeholder="Other Details" />
                                        <i class="fa fa-check complete" aria-hidden="true"></i>
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
                                        <button onclick="pincodetest(0)" id="DeliverHere" runat="server" class="deliver-btn">Confirm And Deliver Here</button>
                                    </div>
                                </div>
                                <asp:Literal ID="ltrerr123" runat="server"></asp:Literal>
                                <div id="divMyText" style="display: none">

                                    <asp:Label ID="lblCustid1" runat="server"></asp:Label>
                                    <asp:Label ID="lbladdressid" runat="server"></asp:Label>
                                    <asp:Label ID="lblWhatsAppNo" runat="server"></asp:Label>
                                    <asp:Label ID="lblPinCode" runat="server"></asp:Label>
                                     <asp:Label ID="lblCountryId" runat="server"></asp:Label>
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

                                <label><strong class="required">Mobile No.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppmobil" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-editmbno"></small>
                            </div>
                                <div class="col-md-4 col-xs-12">
                                                        
                                                            <label> <strong >Email.</strong></label>
                                                             <asp:TextBox CssClass="form-control" ID="ppemail" runat="server"></asp:TextBox>
                                                        <i class="fa fa-check complete" aria-hidden="true"></i>
                                                    </div>
                            <div class="col-md-4 col-xs-12 hide">

                                <label><strong class="required">Country Name.</strong></label>

                                <asp:DropDownList ID="ppcounty" runat="server" AutoPostBack="false" onChange="return GetState(this)"></asp:DropDownList>

                            </div>

                             <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Pincode.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="pppincode" runat="server"  MaxLength="6"></asp:TextBox>
                             
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small style="display:none;" id="alert-editpin">Service not available.</small>
                                <small style="display:none;" id="alert-editpin1">Service not available.</small>
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

                                <label><strong class="required">Area.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="pparea" runat="server"></asp:TextBox>
                               <input type="hidden" value="-1" id="ppareaid" />
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-pparea"></small>
                            </div>

                            <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Building/Society.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppbuilding" runat="server"></asp:TextBox>
                                <input type="hidden" value="-1" id="ppbuildingid" />
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-ppbuilding"></small>
                            </div>

                             <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Building/Society#</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppbuildingno" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-ppbuildingno"></small>
                            </div>

                             <div class="col-md-4 col-xs-12">

                                <label><strong class="required">Landmark.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="pplandmark" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-pplandmark"></small>
                            </div>

                             <div class="col-md-4 col-xs-12">

                                <label><strong>Other Details.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppother" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-ppother"></small>
                            </div>
                          
                           <%-- <div class="col-md-12 col-xs-12">

                                <label><strong class="required">Address.</strong></label>
                                <asp:TextBox CssClass="form-control" ID="ppaddr" runat="server"></asp:TextBox>
                                <i class="fa fa-check complete" aria-hidden="true"></i>
                                <small id="alert-editaddr"></small>
                            </div>--%>

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
            $('#ContentPlaceHolder1_Text2').val($('#ContentPlaceHolder1_lblPinCode').html());
            $("#btnsendMessage").text($('#ContentPlaceHolder1_lblWhatsAppNo').text());
            SearchArea();
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
        function  SearchArea() {  
            $("#txtArea").autocomplete({  
                source: function(request, response) {  
                    $.ajax({  
                        type: "POST",  
                        contentType: "application/json",
                        url: "checkout.aspx/GetArea",  
                        data: '{zipcode:"' + document.getElementById('ContentPlaceHolder1_Text2').value + '",term:"'+$('#txtArea').val()+'"}',  
                        dataType: "json",  
                        success: function(data) {  
                            response($.map(data.d, function (item) {
                                return { label: item.AreaName, value: item.AreaName, AreaId: item.AreaId };
                            }));
                        },  
                        error: function(result) {  
                            alert("No Match");  
                        }  
                    });  
                },
                select: function (event, ui) {
                    $("#AreaId").val(ui.item.AreaId);
                    SearchBuilding();
                },
                messages: {
                    noResults: ""
                }
            });  
        }  

         function  SearchBuilding() {  
            $("#txtBuilding").autocomplete({  
                source: function(request, response) {  
                    $.ajax({  
                        type: "POST",  
                        contentType: "application/json",  
                        url: "checkout.aspx/GetBuilding",  
                        data: '{areaId:"' + $("#AreaId").val() + '",term:"'+$('#txtBuilding').val()+'"}',  
                        dataType: "json",  
                        success: function(data) {  
                            response($.map(data.d, function (item) {
                                return { label: item.BuildingName, value: item.BuildingName, BuildingId: item.BuildingId };
                            }));
                        },  
                        error: function(result) {  
                            alert("No Match");  
                        }  
                    });  
                },
                select: function (event, ui) {
                    $("#BuildingId").val(ui.item.BuildingId);
                },
                messages: {
                    noResults: ""
                }
            });  
        } 

        function  SearchAreaInPopup() {  
            $("#ContentPlaceHolder1_pparea").autocomplete({  
                source: function(request, response) {  
                    $.ajax({  
                        type: "POST",  
                        contentType: "application/json",
                        url: "checkout.aspx/GetArea",  
                        data: '{zipcode:"' + document.getElementById('ContentPlaceHolder1_pppincode').value + '",term:"'+$('#ContentPlaceHolder1_pparea').val()+'"}',  
                        dataType: "json",  
                        success: function(data) {  
                            response($.map(data.d, function (item) {
                                return { label: item.AreaName, value: item.AreaName, AreaId: item.AreaId };
                            }));
                        },  
                        error: function(result) {  
                            alert("No Match");  
                        }  
                    });  
                },
                select: function (event, ui) {
                    $("#ppareaid").val(ui.item.AreaId);
                    SearchBuildingInPopup();
                },
                messages: {
                    noResults: ""
                }
            });  
        }

        function  SearchBuildingInPopup() {  
            $("#ContentPlaceHolder1_ppbuilding").autocomplete({  
                source: function(request, response) {  
                    $.ajax({  
                        type: "POST",  
                        contentType: "application/json",  
                        url: "checkout.aspx/GetBuilding",  
                        data: '{areaId:"' + $("#ppareaid").val() + '",term:"'+$('#ContentPlaceHolder1_ppbuilding').val()+'"}',  
                        dataType: "json",  
                        success: function(data) {  
                            response($.map(data.d, function (item) {
                                return { label: item.BuildingName, value: item.BuildingName, BuildingId: item.BuildingId };
                            }));
                        },  
                        error: function(result) {  
                            alert("No Match");  
                        }  
                    });  
                },
                select: function (event, ui) {
                    $("#ppbuildingid").val(ui.item.BuildingId);
                },
                messages: {
                    noResults: ""
                }
            });  
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
                //SearchArea();
                //SearchBuilding();
                enableButton();
            }
        }
        $('#txtArea').blur(function () {
            let val = $('#txtArea').val();
            if (val == "" || val == undefined || val == null) {
                $('#AreaId').val('-1');
            }
            if (val.length < 5) {
                document.getElementById('alert-Area').innerHTML = 'Area field is empty or less than 5 characters!';
                checkmark[4].classList.remove('active');
                disableButton();
            }
            else {
                document.getElementById('alert-Area').innerHTML = '';
                checkmark[4].classList.add('active');
                enableButton();
            }
        });

         $('#txtBuilding').blur(function () {
             let val = $('#txtBuilding').val();
             if (val == "" || val == undefined || val == null) {
                $('#BuildingId').val('-1');
            }
            if (val.length < 5) {
                document.getElementById('alert-building').innerHTML = 'Building field is empty or less than 5 characters!';
                checkmark[5].classList.remove('active');
                disableButton();
            }
            else {
                document.getElementById('alert-building').innerHTML = '';
                checkmark[5].classList.add('active');
                enableButton();
            }
         });
         document.getElementById('ContentPlaceHolder1_txtLandmark').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_txtLandmark').value;
            if (status.length < 3) {
                document.getElementById('alert-landmark').innerHTML = 'Landmark field is empty or less than 3 characters!';
                checkmark[6].classList.remove('active');
                disableButton();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-name').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButton();
                //}
            else {
                document.getElementById('alert-landmark').innerHTML = '';
                checkmark[6].classList.add('active');
                enableButton();
            }
        };

        document.getElementById('txtBuildingNo').onblur = function () {
            let status = document.getElementById('txtBuildingNo').value;
            if (status.length < 1) {
                document.getElementById('alert-buildingno').innerHTML = 'BuildingNo field is empty!';
                checkmark[7].classList.remove('active');
                disableButton();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-name').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButton();
                //}
            else {
                document.getElementById('alert-buildingno').innerHTML = '';
                checkmark[7].classList.add('active');
                enableButton();
            }
        };
        //document.getElementById('ContentPlaceHolder1_txtaddr').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_txtaddr').value;
        //    if (status.length < 15) {
        //        document.getElementById('alert-addr').innerHTML = "Please enter proper address";
        //        checkmark[4].classList.remove('active');
        //        disableButton();
        //    } else {
        //        document.getElementById('alert-addr').innerHTML = '';
        //        checkmark[4].classList.add('active');
        //        enableButton();
        //    }
        //}
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
                $("#alert-editpin").show();
                document.getElementById('alert-editpin').innerHTML = "Please put 6 digit of pincode";
                checkmark[3].classList.remove('active');
                disableButtonedit();
            } else {
                checkservices(1);
                document.getElementById('alert-editpin').innerHTML = '';
                checkmark[3].classList.add('active');
               
            }
        }
        //document.getElementById('ContentPlaceHolder1_ppaddr').onblur = function () {
        //    let status = document.getElementById('ContentPlaceHolder1_ppaddr').value;
        //    if (status.length < 5) {
        //        document.getElementById('alert-editaddr').innerHTML = "Please enter proper address";
        //        checkmark[4].classList.remove('active');
        //        disableButtonedit();
        //    } else {
        //        document.getElementById('alert-editaddr').innerHTML = '';
        //        checkmark[4].classList.add('active');
        //        enableButtonedit();
        //    }
        //}
        $('#ContentPlaceHolder1_pparea').blur(function () {
            let val = $('#ContentPlaceHolder1_pparea').val();
            if (val == "" || val == undefined || val == null) {
                $('#ppareaid').val('-1');
            }
            if (val.length < 5) {
                document.getElementById('alert-pparea').innerHTML = 'Area field is empty or less than 5 characters!';
                checkmark[4].classList.remove('active');
                disableButtonedit();
            }
            else {
                document.getElementById('alert-pparea').innerHTML = '';
                checkmark[4].classList.add('active');
                enableButtonedit();
            }
        });

         $('#ContentPlaceHolder1_ppbuilding').blur(function () {
             let val = $('#ContentPlaceHolder1_ppbuilding').val();
             if (val == "" || val == undefined || val == null) {
                $('#ppbuildingid').val('-1');
            }
            if (val.length < 5) {
                document.getElementById('alert-ppbuilding').innerHTML = 'Building field is empty or less than 5 characters!';
                checkmark[5].classList.remove('active');
                disableButtonedit();
            }
            else {
                document.getElementById('alert-ppbuilding').innerHTML = '';
                checkmark[5].classList.add('active');
                enableButtonedit();
            }
         });

         
        document.getElementById('ContentPlaceHolder1_pplandmark').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_pplandmark').value;
            if (status.length < 3) {
                document.getElementById('alert-pplandmark').innerHTML = 'Landmark field is empty or less than 3 characters!';
                checkmark[6].classList.remove('active');
                disableButtonedit();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-name').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButton();
                //}
            else {
                document.getElementById('alert-pplandmark').innerHTML = '';
                checkmark[6].classList.add('active');
                enableButtonedit();
            }
        };

        document.getElementById('ContentPlaceHolder1_ppbuildingno').onblur = function () {
            let status = document.getElementById('ContentPlaceHolder1_ppbuildingno').value;
            if (status.length == 0) {
                document.getElementById('alert-ppbuildingno').innerHTML = 'BuildingNo field is empty!';
                checkmark[7].classList.remove('active');
                disableButtonedit();
            }
                //else if (!alphanumeric(status)) {
                //    document.getElementById('alert-name').innerHTML = 'Invalid characters!';
                //    checkmark[0].classList.remove('active');
                //    disableButton();
                //}
            else {
                document.getElementById('alert-ppbuildingno').innerHTML = '';
                checkmark[7].classList.add('active');
                enableButtonedit();
            }
        };
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
            var Deliverypincode = pincode;
            var Pincodecheck = $('#ContentPlaceHolder1_lblPinCode').html();
            if (Deliverypincode != Pincodecheck) {
                alert('Please select the address which has same pin code as selected on home page or add a new address.');
                return;
            }
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
            enableButtonedit();
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
                        return;

                    }
                    else {
                        //$("#alert-editpin").show();
                        $("#alert-editpin1").show();
                        //$("#alert-pin-service").show();
                        //$("#ContentPlaceHolder1_Text2").val('');
                        $("#ContentPlaceHolder1_pppincode").val('');
                        disableButtonedit();
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
            SearchAreaInPopup();
            SearchBuildingInPopup();
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
             document.getElementById('alert-ppbuilding').innerHTML = '';
             document.getElementById('alert-pparea').innerHTML = '';
             document.getElementById('alert-editpin').innerHTML = '';
             document.getElementById('alert-editmbno').innerHTML = '';
             document.getElementById('alert-editname').innerHTML = '';
             document.getElementById('alert-pplandmark').innerHTML = '';
             document.getElementById('alert-ppbuildingno').innerHTML = '';
             $("#alert-editpin1").hide();
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
                     $("#ContentPlaceHolder1_pparea").val(ResponseData.d.OrderCustomerList[0].AreaName);
                     $("#ContentPlaceHolder1_ppbuilding").val(ResponseData.d.OrderCustomerList[0].BuildingName);
                     $("#ContentPlaceHolder1_ppbuildingno").val(ResponseData.d.OrderCustomerList[0].BuildingNo);
                     $("#ContentPlaceHolder1_pplandmark").val(ResponseData.d.OrderCustomerList[0].Landmark);
                     $("#ContentPlaceHolder1_ppother").val(ResponseData.d.OrderCustomerList[0].OtherDetails);
                     $("#ppareaid").val(ResponseData.d.OrderCustomerList[0].AreaId);
                     $("#ppbuildingid").val(ResponseData.d.OrderCustomerList[0].BuildingId);
                     //$("#ContentPlaceHolder1_lbladdressid").val(ResponseData.d.OrderCustomerList[0].Caddrid);
                     ShowPopup();
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
             //swal({
             //    title: "Sucessully!",
             //    text: "Sucessfully Deleted Address!",
             //    icon: "success",
             //    button: "Ok",
             //});
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
             var countryid = $('#ContentPlaceHolder1_lblCountryId').html();
             var sid = $('#ContentPlaceHolder1_state').children("option:selected").val();
             var cid = $('#ContentPlaceHolder1_city').children("option:selected").val();
             var tag = $('#ContentPlaceHolder1_Tag').children("option:selected").val();
             //var addr = $('#ContentPlaceHolder1_txtaddr').val();
             var ph = $('#ContentPlaceHolder1_mobileno').val();
             //var lname = $('#ContentPlaceHolder1_txtlname').val();
             var fname = $('#ContentPlaceHolder1_txtfname').val();
             var custid = $('#ContentPlaceHolder1_lblCustid1').html();
             var email = $('#ContentPlaceHolder1_Text1').val();
             var areaid = $("#AreaId").val();
             var area = $("#txtArea").val();
             var buildingid = $("#BuildingId").val();
             var building = $("#txtBuilding").val();
             var landmark = $("#ContentPlaceHolder1_txtLandmark").val();
             var buildingNo = $("#txtBuildingNo").val();
              var other =  $("#txtOther").val();

             

             var tagid = Number(tag);
             var statid = Number(sid);
             var ciiid = Number(cid);
             var couid = Number(countryid);
             areaid = Number(areaid);
             buildingid = Number(buildingid);
             
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
             
            
             

             //if (addr == "") {
                
             //    return;
             //}

             if (fname == "") {
                
                 return;
             }


             if (ph == "") {
               
                 return;
             }

              if (area == "") {
               
                 return;
             }

             if (building == "") {
               
                 return;
             }
             if (landmark == "") {
               
                 return;
             }
              if (buildingNo == "") {
               
                 return;
             }

           

             $.ajax({
                 type: "POST",
                 //url: "checkout.aspx/GetURL",
                 url: "checkout.aspx/SaveAddress",
                 //data: '{custid: "' + custid + '",fname1:"' + fname + '",lname:"' + lname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid + '",addr1:"' + addr + '",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '"}',
                  data: '{custid: "' + custid + '",fname1:"' + fname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid +'",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '",areaid:"' + areaid + '",area:"' + area + '",buildingid:"' + buildingid + '",building:"' + building + '",buildingNo:"' + buildingNo + '",landmark:"' + landmark + '",other:"' + other + '"}',

                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     //alert(response.d.LastId);
                     //var bar_data =
                     //  {
                     //      data: JSON.parse(response.d),
                     //  };

                     //var data123 = bar_data.data.LastId;
                     //var orderid = getUrlVars()["orderid"];
                     //if (orderid != undefined && orderid != "" && orderid != "undefined") {
                     //    window.location.href = "OrderSummery.aspx?orderid=" + orderid;
                     //} else {
                     //    window.location.href = "OrderSummery.aspx"
                     //}
                     //window.location = "OrderSummery.aspx";
                     window.location = "final.aspx";

                 },
                 failure: function (response) {
                     alert(response.d);
                 }
             });
             return false;
         }

         //Save Edited Addresss
         function Saveanddeliver() {
             //checkservices(1);
             //checkservices(0);
            // var countryid = $('#ContentPlaceHolder1_ppcounty').children("option:selected").val();
             var countryid = $('#ContentPlaceHolder1_lblCountryId').html();
             var sid = $('#ContentPlaceHolder1_ppstate').children("option:selected").val();
             var cid = $('#ContentPlaceHolder1_ppcity').children("option:selected").val();
             var tag = $('#ContentPlaceHolder1_ppddltag').children("option:selected").val();
             var areaid = $("#ppareaid").val();
             var area = $("#ContentPlaceHolder1_pparea").val();
             var buildingid = $("#ppbuildingid").val();
             var building = $("#ContentPlaceHolder1_ppbuilding").val();
             var landmark = $("#ContentPlaceHolder1_pplandmark").val();
             var buildingNo = $("#ContentPlaceHolder1_ppbuildingno").val();
             var other = $("#ContentPlaceHolder1_ppother").val();

             var tagid = Number(tag);
             var statid = Number(sid);
             var ciiid = Number(cid);
             var couid = Number(countryid);
             areaid = Number(areaid);
             buildingid = Number(buildingid);

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




             //var addr = $('#ContentPlaceHolder1_ppaddr').val();
             var ph = $('#ContentPlaceHolder1_ppmobil').val();
             //var lname = $('#ContentPlaceHolder1_pplastname').val();
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
             if (area == "") {

                 return;
             }

             if (building == "") {
               
                 return;
             }
             if (landmark == "") {
               
                 return;
             }
             if (buildingNo == "") {

                 return;
             }

             

             $.ajax({
                 type: "POST",
                 url: "checkout.aspx/UpdateAddress",
                 //url: "checkout.aspx/saveandeditaddress",
                 //data: '{custid: "' + custid + '",fname1:"' + fname + '",lname:"' + lname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid + '",addr1:"' + addr + '",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '",Addressid:"' + addessid + '"}',
                 data: '{custid: "' + custid + '",addrid:"' + addessid + '",fname1:"' + fname + '",tagid1:"' + tag + '",Countryid1:"' + countryid + '",sid:"' + sid + '",cid:"' + cid +'",pinid1:"' + pincode + '",mobile1:"' + ph + '",Email:"' + email + '",areaid:"' + areaid + '",area:"' + area + '",buildingid:"' + buildingid + '",building:"' + building + '",buildingNo:"' + buildingNo + '",landmark:"' + landmark + '",other:"' + other + '"}',

                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (Repose) {

                     //alert(Repose.d);

                     if (Repose.d.Response = "1") {


                         //var orderid = getUrlVars()["orderid"];
                         //if (orderid != undefined && orderid != "" && orderid != "undefined") {
                         //    window.location.href = "OrderSummery.aspx?orderid=" + orderid;
                         //} else {
                         //    window.location.href = "OrderSummery.aspx"
                         //}



                         //window.location = "OrderSummery.aspx";
                         window.location = "final.aspx";
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

         function Deliverydone(addrid, pincode) {
             //disableButton();
             //document.getElementById('ContentPlaceHolder1_btnsave').disabled = true;
             $(".deliver-btn").prop('disabled', true);
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
                             //var orderid = getUrlVars()["orderid"];
                             //if (orderid != undefined && orderid != "" && orderid != "undefined") {
                             //    window.location.href = "OrderSummery.aspx?orderid=" + orderid;
                             //} else {
                             //    window.location.href = "OrderSummery.aspx"
                             //}

                             //window.location = "OrderSummery.aspx";
                             window.location = "final.aspx";
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
                 alert('Please select the address which has same pin code as selected on home page or add a new address.');
                 return false;
             }
        }
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }




    </script>


</asp:Content>

