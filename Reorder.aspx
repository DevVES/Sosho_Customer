<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reorder.aspx.cs" Inherits="Reorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/bootstrap-3.3.7.min.css" rel="stylesheet" />
    <link href="OwlCarousel/dist/assets/owl.carousel.css" rel="stylesheet" />
    <link href="OwlCarousel/dist/assets/owl.theme.default.min.css" rel="stylesheet" />
    <link href="css/CircularContentCarousel/style.css" rel="stylesheet" />
    <link href="css/CircularContentCarousel/jquery.jscrollpane.css" rel="stylesheet" />
    <link href="css/completeCss.css" rel="stylesheet" />
    <style>
        /* Solid border */
        hr.solid {
            border-top: 3px solid #bbb;
        }

        .BlueText {
            background: #1DA1F2;
            color: #FFFFFF;
            font-size: 15px;
            font-family: 'Amazon Ember'
        }
         input:read-only {
            opacity: 1;
            background-color: #fff;
        }

        .ProductImage {
            /*height: 400px;
            width: 400px;*/
           width: 150px;
            height: 150px;
        }

        .ProudctMRPText {
            font-family: 'Amazon Ember';
            font-size: 15px;
            width: 121px;
            /*padding-left: 27px;*/
            /*padding-left: 10px;*/
        }

        .ProductName {
            color: #1A1A1A;
            font-family: 'Amazon Ember';
            font-size: 22px;
            /*padding-left: 27px;*/
            /*padding-left: 10px;*/
            font-weight: bold;
        }

        .ProductMRPValue {
            font-family: 'Amazon Ember';
            padding-top: 15px;
        }

        .ProductMRPText {
            font-size: 15px;
        }

        .AmazonFont {
            font-family: 'Amazon Ember';
        }

        .SoshoPrice {
            color: #1A1A1A;
            font-size: 15px;
            /*width: 121px;*/
            /*padding-left: 27px;*/
            /*padding-left: 10px;*/
            font-weight: bold;
        }

        .SoshoColon {
            color: #1A1A1A;
            font-weight: bold;
        }

        .SoshoPriceValue {
            color: #B12704;
            font-size: 18px;
            font-weight: bold;
        }

        .ProductDropDown {
            /*padding-top: 15px;*/
            padding-top: 6px;
            color: black;
            font-size: 14px;
            font-family: 'Amazon Ember';
            border-color: #D0D0D0;
            /*padding-left: 27px;*/
            /*padding-left: 10px;*/
        }

        .ProductBtn {
            color: white;
            background-color: #1DA1F2;
            margin: 3px;
            font-size: 10px;
        }

        .tableheader {
            width: 100%;
            /*position: relative;*/
            bottom: -6px;
            right: 166px;
        }

        .DiscountOffer {
            color: white;
            background-color: #B12704;
            border-radius: 50px;
            padding: 10px 5px 5px 5px;
            width: 48px;
            position: absolute;
            text-align: center;
            height:48px;
            font-family:'Amazon Ember Bold';
            font-size:11px;
        }

        .SoldCount {
            font-family: 'Amazon Ember';
            font-size: 15px;
            font-weight: bold;
        }

        .BtnAddText {
            color: white;
            font-size: 16px;
            width: 93px;
        }

        .WeightText {
            width: 120px;
        }

        .boldPackSize {
            background-Color: #F00;
            color: #FFF;
        }

        .ProductCenter {
            padding-top: 5px;
        }

        @media only screen and (max-width: 600px) {
            /* For mobile phones: */
            .ProductImage {
                height: 110px;
                width: 110px;
                object-fit:scale-down;
            }

            .tableheader {
                width: 100%;
                /*right: 7px;*/
            }

            .DiscountOffer {
               font-size:10px;
               width: 45px;
               height: 45px;
            }

            .ProductName {
                font-size: 14px;
                /*padding-left: 10px;*/
            }

            .ProudctMRPText {
                font-size: 14px;
                width: 106px;
            }

            .SoshoPrice {
                font-size: 14px;
            }

            .SoshoPriceValue {
                font-size: 14px;
            }

            .SoldCount {
                font-size: 8px;
            }

            .ProductMRPText {
                font-size: 11px;
            }

            .BlueText {
                font-size: 10px;
            }

            .ProductDropDown {
                font-size: 12px;
            }

            .WeightText {
                width: 72px;
            }

            /*.ProductCenter {
                text-align: -webkit-center;
            }*/
        }
    </style>
    <div class="col-md-12" style="padding-top: 10px;">

        <div class="col-md-3 pull-right">
            <div id="divSortProd">
                <select id="sort" onchange="SortProduct(this)">
                    <option value="0">Sort By : Default</option>
                    <option value="1">Price - Low to High</option>
                    <option value="2">Price - High to Low</option>
                    <option value="3">Discount</option>
                    <option value="4">Sosho Recommended</option>
                </select>
            </div>
        </div>
        <div class="col-md-2 pull-right" id="btnbuyall">
            <input type="button" class="btn BlueText BtnAddText" onclick="AddAll()" value="Add all" />
        </div>
    </div>
    <div class="col-md-12" style="text-align: center;margin-top: 45px;">
        <div id="empty" style="display: none; font-weight: 600; font-size: xx-large;">
            <p>No products found.</p>
        </div>
    </div>
    <div id="divProductNew">
    </div>
    <div id="loader">
      </div>
    
    <div id="modalProductDescription" class="modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="row">
                        <div id="home-product-detail">
                            <div class="product-description">
                                <div class="col-md-3"></div>
                                <div class="col-md-5">
                                    <div id="ProdName" style="color: #FFFFFF; font-family: 'Amazon Ember'; font-weight: bold; text-align: center;"></div>
                                </div>
                                <div class="col-md-4">
                                    <button type="button" class="btn close" aria-label="Close" data-dismiss="modal">
                                        <i class="fa fa-times-circle-o fa-lg" aria-hidden="true"></i>
                                    </button>
                                </div>
                                <div class="description">
                                    <div class="inner">
                                        <h5>Description</h5>
                                        <div id="divPDescription" style="font-family: 'Amazon Ember';"></div>
                                    </div>
                                </div>
                                <div class="feature">
                                    <div class="inner">
                                        <h5>Key features</h5>
                                        <div id="divPKeyFeature" style="font-family: 'Amazon Ember';"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <%--Pincode Modal Popup--%>
    <div id="myPinCodeModal" class="modalcenter fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <fieldset style="border: 1px groove #ddd !important; padding: 0 1.4em 1.4em 1.4em !important; margin: 0 0 1.5em 0 !important; -webkit-box-shadow: 0px 0px 0px 0px #000; box-shadow: 0px 0px 0px 0px #000;">
                                <legend style="font-size: 1.2em !important; font-weight: bold !important; text-align: left !important; width: auto; padding: 0 10px; border-bottom: none;">Pin code</legend>
                                <i class="fa fa-map-marker" style="font-size: 25px; color: rgb(29, 161, 242)"></i>
                                <input type="text" id="txtPinCodeval" placeholder="Pin Code" maxlength="6" style="padding-left: 0; padding-right: 0; border-radius: 0; border: none; border-radius: 0; box-shadow: none; border-bottom: 1px solid #d7dde4; height: 27px; width: 67px; border-color: rgb(29, 161, 242);" />

                                <span id="lblpinmsg" runat="server" style="height: 16px; color: green; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 0"></span>
                                <span id="lblpinnotmsg" runat="server" style="height: 16px; color: red; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 4px"></span>
                            </fieldset>
                        </div>
                        <div style="text-align: center;">
                            <button type="button" class="btn btn-primary" onclick="Newcheckservices()" style="background: rgb(29, 161, 242); border-color: rgb(29, 161, 242);" id="BtnPinCodeApply">Confirm</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>


    <script>

        var products = [];
        var obj;
        var count = 0;
        var AllProducts = [];
        var $contentLoadTriggered = false;

        $(document).ready(function () {
             $("#loader").hide();
            var sValue = '<%=HttpContext.Current.Session["PinCode"]%>';
            $("#reorder").removeAttr("href");
            $("#reorder").attr("href", "Default.aspx");
            $("#reorder").text("Back");
            if ($('#cnfrm').hasClass('hide')) {
                $(".dvBtnReOrder").css('bottom', '0px');
            }
            else {
                $(".dvBtnReOrder").css('bottom', '10px');
            }
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetSessionProductData",
                data: '{ data: "1" }',
                contentType: "application/json",
                dataType: "json",
                success: function (response) {
                    if (response.d.length > 0) {
                        products.push(...response.d);
                    }
                    console.log(response);
                },
                failure: function (response) {

                    alert("Something Wrong....");

                }
            });
            if (sValue != "") {
                $("#txtPinCodeval").val(sValue);
                $("#BtnPinCodeApply").click();

            } else {
                window.location = "Default.aspx";
            }
            $(".dvhidePincode").css('display', 'none');
            //$("#divPin").hide();
        });
        function getproddesc(prodid) {
            $.ajax({

                type: "POST",
                url: "Default.aspx/getproddesc",
                data: '{prodid:"' + prodid + '"}',
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    var getdata = {
                        data: response.d,
                    }
                    $("#ContentPlaceHolder1_lblproductdec")[0].innerHTML = getdata.data.ProductDiscription;
                    $("#ContentPlaceHolder1_lblprodkeyfeature")[0].innerHTML = getdata.data.keyfeatures;
                    $("#ContentPlaceHolder1_lblprodnote")[0].innerHTML = getdata.data.Note;

                },
                failure: function (response) {

                    alert("Something Wrong....");

                }
            });
        }

        function AddClick(rowindex, prodid, grpid, mrp, soshoprice, el, bannerProductType) {
            $('#AddShow' + grpid).show();
            $('#BtnAdd' + grpid).hide();

            var $this = $(el);

            var qty = $('#AddShow' + grpid).find('input').val();
            var grpId = grpid;
            var productvariant = $('#hdnProductVariant' + grpid).val();
            var unitId = $('#ddlUnit' + grpid).val();
            var unitvalue = $('#ddlUnit' + grpid).val();
            var parts = unitvalue.split(' - ');

            obj = {
                Productid: prodid,
                Grpid: grpId,
                Mrp: parseInt(mrp),
                SoshoPrice: parseInt(soshoprice),
                Qty: parseInt(qty),
                Unit: parts[0],
                UnitId: parts[1],
                Productvariant: productvariant,
                BannerProductType: bannerProductType,
                BannerId: "0"

            }
            products.push(obj);
            count = products.length;

            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
                $(".dvBtnReOrder").css('bottom', '10px');
                $('#hdnProductCount').val(count);
                UpdateSessionCart();
            }
        }

        function plusqty(type, prodid, grpid, mrp, soshoprice, el, bannerProductType,maxQty) {
            var grpId = grpid;
            var productvariant = $('#hdnProductVariant' + grpid).val();
            var unitId = $('#ddlUnit' + grpid).val();
            var unitvalue = $('#ddlUnit' + grpid).val();
            var parts = unitvalue.split(' - ');



            var $this = $(el);
            var parent = $this.parent();
            var value = parent.find('input').val();
            value = Number(value);
            var trid = $this.parent().closest('tr').attr('id'); // table row ID
            var rowindexval = trid.replace('AddShow', '');

            if (type == 1) {
                value = value + 1;
                if (value > Number(maxQty)) {
                    alert("Quantity cannot be exceeded more than " + maxQty);
                    return;
                }
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == grpid), 1);
                }

                obj = {
                    Productid: prodid,
                    Grpid: grpId,
                    Mrp: parseInt(mrp),
                    SoshoPrice: parseInt(soshoprice),
                    Qty: value,
                    Unit: parts[0],
                    UnitId: parts[1],
                    Productvariant: productvariant,
                    BannerProductType: bannerProductType,
                    BannerId: "0"

                }
                products.push(obj);
            }
            else if (type == 0) {
                //if (value > 1) {
                //    value = value - 1;
                //}
                value = value - 1;


                if (value == 0) {
                    $('#AddShow' + rowindexval).hide();
                    $('#BtnAdd' + rowindexval).show();

                    var product = products.find(x => x.Productid == prodid);
                    if (product != null && product != undefined) {
                        products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == grpid), 1);
                        count = products.length;
                    }
                } else {
                    var product = products.find(x => x.Productid == prodid);
                    if (product != null && product != undefined) {
                        products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == grpid), 1);
                    }

                    obj = {
                        Productid: prodid,
                        Grpid: grpId,
                        Mrp: parseInt(mrp),
                        SoshoPrice: parseInt(soshoprice),
                        Qty: value,
                        Unit: parts[0],
                        UnitId: parts[1],
                        Productvariant: productvariant,
                        BannerProductType: bannerProductType,
                        BannerId: "0"

                    }
                    products.push(obj);
                }
            }
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    count = products.length;
                }
                if (count == 0) {
                    $('#count')[0].innerHTML = "";
                    $('#cnfrm').addClass('hide');
                    $(".dvBtnReOrder").css('bottom', '0px');
                }
                else {
                    $('#count')[0].innerHTML = count + " Product Added";
                    $('#cnfrm').removeClass('hide');
                    $(".dvBtnReOrder").css('bottom', '10px');
                    $('#hdnProductCount').val(count);
                }
                //UpdateSessionCart();
            }
            else {
                $('#count')[0].innerHTML = "";
                $('#cnfrm').addClass('hide');
                $(".dvBtnReOrder").css('bottom', '0px');
            }
            UpdateSessionCart();
            if (value != 0) {
                var dataval = parent.find('input');
                dataval[0].value = value;
            }

        }

        function ConfirmOrder() {
            console.log(products);
            $("#divMainloader").attr("display", "block");
            $("#cnfrm").attr("disabled", true);
            $.ajax({

                type: "POST",
                url: "Default.aspx/ConfirmOrder",
                data: JSON.stringify({ model: products, "WhatsAppNo": $("#btnsendMessage").text(), "PinCode": $("#spanpincode").html() }),
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    var querystring = window.location.search;
                    $("#divMainloader").attr("display", "none");
                    $("#cnfrm").attr("disabled", false);
                    window.location = "OrderSummery.aspx";
                },
                failure: function (response) {
                    alert("Something Wrong....");
                }
            });
        }

        function UpdateSessionCart() {
            console.log(products);
            $("#divMainloader").attr("display", "block");
            $("#cnfrm").attr("disabled", true);
            $.ajax({

                type: "POST",
                url: "Default.aspx/ConfirmOrder",
                data: JSON.stringify({ model: products, "WhatsAppNo": $("#btnsendMessage").text(), "PinCode": $("#spanpincode").html() }),
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    var querystring = window.location.search;
                    $("#divMainloader").attr("display", "none");
                    $("#cnfrm").attr("disabled", false);
                    //window.location = "OrderSummery.aspx";
                },
                failure: function (response) {
                    alert("Something Wrong....");
                }
            });
        }

        function SortProduct(el) {
            $('#btnbuyall').css('display', 'block');
            var $this = $(el);
            var sortval = $this.val();
            var JurisdictionId = $("#hdnJurisdictionId").val();
            GetProductdata(JurisdictionId, 1, 30, sortval);

        }

        function GetSessionProductData() {
            if (products.length > 0) {
                $.each(products, function (index, value) {

                    $('#AddShow' + value.Grpid).show();
                    $('#BtnAdd' + value.Grpid).hide();
                    $('#AddShow' + value.Grpid).find('input').val(value.Qty);

                });

                $('#count')[0].innerHTML = products.length + " Product Added";
                $('#cnfrm').removeClass('hide');
                $(".dvBtnReOrder").css('bottom', '10px');
                $('#hdnProductCount').val(products.length);
            }

            //$.ajax({
            //    type: "POST",
            //    url: "Default.aspx/GetSessionProductData",
            //    data: '{ data: "1" }',
            //    contentType: "application/json",
            //    dataType: "json",
            //    success: function (response) {
            //        console.log(response);
            //    },
            //    failure: function (response) {

            //        alert("Something Wrong....");

            //    }
            //});

        }

        function Newcheckservices() {
            $("#lblpinmsg").hide();
            $("#lblpinnotmsg").hide();
            var pincode = $("#txtPinCodeval").val();
            $("#BtnPinCodeApply").attr("disabled", true);
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
                    var message = getdata.data.Message;
                    var resultflag = getdata.data.resultflag;
                    var JurisdictionId = getdata.data.JurisdictionID;
                    if (resultflag == "1") {
                        $("#lblpinmsg").show();
                        var labelObj = document.getElementById("<%=lblpinmsg.ClientID %>");
                        labelObj.innerHTML = message;
                        $("#lblpinmsg").val(message);
                        $("#myPinCodeModal").modal('hide');
                        $("#hdnJurisdictionId").val(JurisdictionId);
                        $("#spanpincode").html(pincode);
                        $("#BtnPinCodeApply").attr("disabled", false);
                        GetProductdata(JurisdictionId, 1, 30, 0);

                    }
                    else {
                        $("#lblpinnotmsg").show();
                        var labelObj = document.getElementById("<%=lblpinnotmsg.ClientID %>");
                        labelObj.innerHTML = message;
                        $("#lblpinnotmsg").val(message);
                        $("#BtnPinCodeApply").attr("disabled", false);
                    }
                },
                failure: function (response) {

                    alert("Something Wrong....");

                }
            });


        };
        function CallPinCodePopup() {
            $("#lblpinmsg").hide();
            $("#lblpinnotmsg").hide();
            $('#txtPinCodeval').val('');
            $("#ContentPlaceHolder1_lblpinmsg").text("");
            $("#ContentPlaceHolder1_lblpinnotmsg").text("");
            //$('#myPinCodeModal').modal({ backdrop: 'static', keyboard: false });
            $('#myPinCodeModal').modal({ backdrop: true, keyboard: true });
            $('#txtPinCodeval').focus();
        }

        function GetProductdata(JurisdictionId, Start, End, Filter) {
            $('#empty').css('display', 'none');
            $.ajax({
                type: 'POST',
                url: "Reorder.aspx/GetProductdata",
                data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"' + Start + '",EndNo:"' + End + '",Filter:' + Filter + '}',
                contentType: "application/json",
                dataType: "json",
                success: function (response) {
                    AllProducts = [];
                    var ProductEndNo = parseInt(response.d.productcount == '' ? 0 : response.d.productcount);
                    $('#hdnProductEndNo').val(parseInt($('#hdnProductEndNo').val()) + parseInt(ProductEndNo + 1));
                    $('#hdnproductcallcount').val(response.d.productcount);
                    $("#divProductNew").html(response.d.response);
                    $("#btnsendMessage").text(response.d.whatsapp);
                    AllProducts.push(...response.d.productdata.ProductList);
                    if (AllProducts.length == 0) {
                        $('#btnbuyall').css('display', 'none');
                        $('#empty').css('display', 'inline-block');
                    }
                    GetSessionProductData();
                },
                failure: function (response) {

                    alert("Something Wrong....");

                }
            });
        }
        function image(rowindex, prodid, el) {
            $('#divPDescription').text('');
            $('#divPKeyFeature').text('');
            $('#hdnPName' + rowindex).val();
            $('#ProdName').text($('#hdnPName' + rowindex).val());

            if (AllProducts.length > 0) {
                var FilterProduct = AllProducts.find(x => x.ProductId == prodid);
                if (FilterProduct != null && FilterProduct != undefined) {
                    var sDesc = FilterProduct.ProductDescription;
                    var sKeyfeature = FilterProduct.ProductKeyFeatures;

                    $('#divPDescription').append(sDesc);
                    $('#divPKeyFeature').append(sKeyfeature);
                }
            }


            $('#modalProductDescription').modal('show');

        }


        function AddAll() {
            $('#empty').css('display', 'none');
            $('#btnbuyall').css('display', 'block');
            //products = [];
            if (AllProducts != null && AllProducts != undefined && AllProducts.length > 0) {
                $.each(AllProducts, function (index, value) {
                    var product = products.find(x => x.Productid == value.ProductId);
                    if (product != null && product != undefined) {
                        products.splice(products.findIndex(x => x.Productid == value.ProductId), 1);
                    }
                    var parts = value.Weight.split(' - ');
                    obj = {
                        Productid: value.ProductId,
                        Grpid: value.AttributeId,
                        Mrp: parseInt(value.MRP),
                        SoshoPrice: parseInt(value.SoshoPrice),
                        Qty: value.OrderedQuantity,
                        Unit: parts[0],
                        UnitId: parts[1],
                        Productvariant: '',
                        BannerProductType: '1',
                        BannerId: "0",
                        isOutOfStock: value.isOutOfStock
                    }
                    products.push(obj);
                });
                count = products.length;

                if (products.length > 0) {
                    $('#count')[0].innerHTML = count + " Product Added";
                    $('#cnfrm').removeClass('hide');
                    $(".dvBtnReOrder").css('bottom', '10px');
                    $('#hdnProductCount').val(count);
                    UpdateSessionCart();
                }

                if (AllProducts.length >= 30) {

                    var sortval = $("#sort").val();
                    var JurisdictionId = $("#hdnJurisdictionId").val();
                    var Start = AllProducts.length + 1;
                    var End = AllProducts.length + 30;
                    $.ajax({
                        type: 'POST',
                        url: "Reorder.aspx/GetProductdata",
                        data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"' + Start + '",EndNo:"' + End + '",Filter:' + sortval + '}',
                        contentType: "application/json",
                        dataType: "json",
                        success: function (response) {
                            AllProducts = [];
                            $('#hdnproductcallcount').val(response.d.productcount);
                            $("#divProductNew").html(response.d.response);
                            AllProducts.push(...response.d.productdata.ProductList);
                            GetSessionProductData();
                            if (response.d.productcount == "") {
                                $("#divProductNew").html('');
                                $('#empty').css('display', 'inline-block');
                                $('#btnbuyall').css('display', 'none');
                                //ConfirmOrder();
                            }
                        },
                        failure: function (response) {

                            alert("Something Wrong....");

                        }
                    });
                } else {
                    $("#divProductNew").html('');
                    $('#empty').css('display', 'inline-block');
                    $('#btnbuyall').css('display', 'none');
                    //ConfirmOrder();
                }
            }
        }

        $(document.body).on('touchmove', onScroll); // for mobile
        $(window).on('scroll', onScroll);

        // callback
        function onScroll() {

            //if ($(window).scrollTop() + window.innerHeight >= document.body.scrollHeight) {
            //if ($(window).scrollTop() >= ($(document).height() - $(window).height())) {
            //if($(window).scrollTop() == $(document).height() - $(window).height() && $contentLoadTriggered == false) {
            if ($(document).height() - $('header').height() <= $(window).scrollTop() + $(window).height() && $contentLoadTriggered == false) {
                var JurisdictionId = $("#hdnJurisdictionId").val();
                var Start = AllProducts.length + 1;
                var End = AllProducts.length + 30;
                var sortval = $("#sort").val();
                var ProductCallCount = $('#hdnproductcallcount').val();
                if (AllProducts.length >= 30 && ProductCallCount != "") {
                    $contentLoadTriggered = true;
                     $("#loader").show();
                    $.ajax({
                        type: 'POST',
                        url: "Reorder.aspx/GetProductdata",
                        data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"' + Start + '",EndNo:"' + End + '",Filter:"' + sortval + '"}',
                        contentType: "application/json",
                        dataType: "json",
                        async: true,
                        success: function (response) {
                            if (response.d.productcount != "") {
                                $('#hdnproductcallcount').val(response.d.productcount);
                                var responsenew = '';
                                responsenew = response.d.response;
                                $("#divProductNew").append(responsenew);
                                AllProducts.push(...response.d.productdata.ProductList);
                                GetSessionProductData();
                            }
                            else {
                                $('#hdnProductEndNo').val('0');
                                $('#hdnproductcallcount').val(response.d.productcount);
                            }
                            $contentLoadTriggered = false;
                             $("#loader").hide();
                        },
                        failure: function (response) {

                            alert("Something Wrong....");

                        }

                    });
                }

            }
            var rootElement = document.documentElement;
            var scrollTotal = rootElement.scrollHeight - rootElement.clientHeight;
            if ((rootElement.scrollTop / scrollTotal) > 0) {
                // Show button
                $(".scrollToTopBtn").addClass("showBtn");
            } else {
                // Hide button
                $(".scrollToTopBtn").removeClass("showBtn");
            }
        }
        $(function () {
            let isMobile = window.matchMedia("only screen and (max-width: 760px)").matches;
            if (isMobile) {
                $("#btnbuyall").removeClass('pull-right');
                $("#btnbuyall").css('width', '12px');
            }
        });
    </script>
</asp:Content>

