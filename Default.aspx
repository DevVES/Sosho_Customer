<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <link href="css/bootstrap-3.3.7.min.css" rel="stylesheet" />

    <link href="OwlCarousel/dist/assets/owl.carousel.css" rel="stylesheet" />
    <link href="OwlCarousel/dist/assets/owl.theme.default.min.css" rel="stylesheet" />



    <style>
        #mo-wa {
            display: none;
        }

        #web {
            display: block;
        }

        @media screen and (max-width: 767px) {
            #mo-wa {
                display: block;
            }

            #web {
                display: none;
            }
        }
    </style>
    <div class="row">
        <div class="offer-banner" id="divCategory">
            <%-- <a href="#" id="link" runat="server">
                <img class="img" id="lbltopbanner" runat="server" src="" />
            </a>--%>
        </div>
    </div>

    <div id="content" runat="server"></div>


    <%--Pincode Modal Popup--%>
    <div id="myPinCodeModal" class="modalcenter fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <fieldset style="border: 1px groove #ddd !important; padding: 0 1.4em 1.4em 1.4em !important; margin: 0 0 1.5em 0 !important; -webkit-box-shadow: 0px 0px 0px 0px #000; box-shadow: 0px 0px 0px 0px #000;">
                                <legend style="font-size: 1.2em !important; font-weight: bold !important; text-align: left !important; width: auto; padding: 0 10px; border-bottom: none;">Pin code</legend>
                                <i class="fa fa-map-marker" style="font-size: 25px; color: red"></i>
                                <input type="text" id="txtPinCodeval" placeholder="Pin Code" maxlength="6" style="padding-left: 0; padding-right: 0; border-radius: 0; border: none; border-radius: 0; box-shadow: none; border-bottom: 1px solid #d7dde4; height: 27px; width: 67px; border-color: #FF4444;" />

                                <span id="lblpinmsg" runat="server" style="height: 16px; color: green; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 0"></span>
                                <span id="lblpinnotmsg" runat="server" style="height: 16px; color: red; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 4px"></span>
                            </fieldset>
                        </div>
                        <div style="text-align: center;">
                            <button type="button" class="btn btn-primary" onclick="Newcheckservices()">Apply</button>
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
        function plusqty(type, el) {

            var $this = $(el);
            var parent = $this.parent();
            var value = parent.find('input').val();
            value = Number(value);

            if (type == 1) {
                value = value + 1;
            }
            else if (type == 0) {
                if (value > 1) {
                    value = value - 1;
                }
            }

            var dataval = parent.find('input');
            dataval[0].value = value;
        }

        function BuyFivewithFriend_Click(prodid, mrp, PWeight, el) {
            $('#count')[0].innerHTML = "";
            $('#cnfrm').addClass('hide');

            var flag = "6";
            var $this = $(el);

            var qty = $this.parents('.row').prev().find('input').val();

            $this.css('background-image', 'linear-gradient( #e3e7e6 30%, #e3e7e6)');
            $this.css('border-top', '1px solid #e3e7e6');
            $this.css('border-left', '1px solid #e3e7e6');
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    products.splice(products.findIndex(x => x.Productid == prodid), 1);
                    $this.css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.css('border-top', '1px solid #ff9910');
                    $this.css('border-left', '1px solid #ff9910');

                    $this.parent().next().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().next().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().next().find('input').css('border-left', '1px solid #ff9910');

                    $this.parent().next().next().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().next().next().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().next().next().find('input').css('border-left', '1px solid #ff9910');

                    count = products.length;
                }
                else {
                    obj = {
                        Productid: prodid,
                        Mrp: parseInt(mrp),
                        Flag: flag,
                        Qty: parseInt(qty),
                        Weight: parseInt(PWeight)
                    }
                    products.push(obj);
                    count = products.length;
                }
            } else {
                obj = {
                    Productid: prodid,
                    Mrp: parseInt(mrp),
                    Flag: flag,
                    Qty: parseInt(qty),
                    Weight: parseInt(PWeight)
                }
                products.push(obj);
                count = products.length;
            }


            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
            }
        }
        function BuyOneWithFriend_Click(prodid, mrp, PWeight, el) {
            $('#count')[0].innerHTML = "";
            $('#cnfrm').addClass('hide');

            var flag = "2";
            var $this = $(el);

            var qty = $this.parents('.row').prev().find('input').val();

            $this.css('background-image', 'linear-gradient( #e3e7e6 30%, #e3e7e6)');
            $this.css('border-top', '1px solid #e3e7e6');
            $this.css('border-left', '1px solid #e3e7e6');
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    products.splice(products.findIndex(x => x.Productid == prodid), 1);
                    $this.css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.css('border-top', '1px solid #ff9910');
                    $this.css('border-left', '1px solid #ff9910');

                    $this.parent().prev().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().prev().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().prev().find('input').css('border-left', '1px solid #ff9910');

                    $this.parent().next().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().next().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().next().find('input').css('border-left', '1px solid #ff9910');
                    count = products.length;
                }
                else {
                    obj = {
                        Productid: prodid,
                        Mrp: parseInt(mrp),
                        Flag: flag,
                        Qty: parseInt(qty),
                        Weight: parseInt(PWeight)
                    }
                    products.push(obj);
                    count = products.length;
                }
            } else {
                obj = {
                    Productid: prodid,
                    Mrp: parseInt(mrp),
                    Flag: flag,
                    Qty: parseInt(qty),
                    Weight: parseInt(PWeight)
                }
                products.push(obj);
                count = products.length;
            }


            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
            }
        }
        function BuyOne_Click(prodid, mrp, PWeight, el) {
            $('#count')[0].innerHTML = "";
            $('#cnfrm').addClass('hide');

            var flag = "1";
            var $this = $(el);

            var qty = $this.parents('.row').prev().find('input').val();

            $this.css('background-image', 'linear-gradient( #e3e7e6 30%, #e3e7e6)');
            $this.css('border-top', '1px solid #e3e7e6');
            $this.css('border-left', '1px solid #e3e7e6');
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    products.splice(products.findIndex(x => x.Productid == prodid), 1);
                    $this.css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.css('border-top', '1px solid #ff9910');
                    $this.css('border-left', '1px solid #ff9910');

                    $this.parent().prev().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().prev().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().prev().find('input').css('border-left', '1px solid #ff9910');

                    $this.parent().prev().prev().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
                    $this.parent().prev().prev().find('input').css('border-top', '1px solid #ff9910');
                    $this.parent().prev().prev().find('input').css('border-left', '1px solid #ff9910');

                    count = products.length;

                }
                else {
                    obj = {
                        Productid: prodid,
                        Mrp: parseInt(mrp),
                        Flag: flag,
                        Qty: parseInt(qty),
                        Weight: parseInt(PWeight)
                    }
                    products.push(obj);
                    count = products.length;
                }
            } else {
                obj = {
                    Productid: prodid,
                    Mrp: parseInt(mrp),
                    Flag: flag,
                    Qty: parseInt(qty),
                    Weight: parseInt(PWeight)
                }
                products.push(obj);
                count = products.length;
            }

            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
            }
        }

        function ConfirmOrder() {
            console.log(products);
            //var productstring = JSON.stringify(products);
            $("#divMainloader").attr("display", "block");
            $("#cnfrm").attr("disabled", true);
            $.ajax({

                type: "POST",
                url: "Default.aspx/ConfirmOrder",
                // data: '{model:"' + productstring + '"}',
                data: JSON.stringify({ model: products }),
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    var querystring = window.location.search;
                    $("#divMainloader").attr("display", "none");
                    $("#cnfrm").attr("disabled", false);
                    if (querystring != "") {
                        window.location = "checkout.aspx/" + querystring;
                    } else {
                        window.location = "checkout.aspx";
                    }

                },
                failure: function (response) {

                    alert("Something Wrong....");

                }
            });
        }
                   <%-- function checkservices() {

                        var pincode = $("#txtpincode").val();
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
                                var message = getdata.data.Message;
                                var resultflag = getdata.data.resultflag;
                                //alert(resultflag);
                                if (resultflag == "1") {
                                    $("#ContentPlaceHolder1_lblpinnotmsg").hide();
                                    $("#ContentPlaceHolder1_lblpinmsg").show();
                                    var labelObj = document.getElementById("<%=lblpinmsg.ClientID %>");
                                    labelObj.innerHTML = message;
                                    $("#ContentPlaceHolder1_lblpinmsg").val(message);
                                }
                                else {
                                    $("#ContentPlaceHolder1_lblpinmsg").hide();
                                    $("#ContentPlaceHolder1_lblpinnotmsg").show();
                                    var labelObj = document.getElementById("<%=lblpinnotmsg.ClientID %>");
                                    labelObj.innerHTML = message;
                                    $("#ContentPlaceHolder1_lblpinnotmsg").val(message);
                                }
                            },
                            failure: function (response) {

                                alert("Something Wrong....");

                            }
                        });
                        //}

                    }--%>
</script>


    <div class="row">
        <div id="video" runat="server" class="video-sec">
            <%--<iframe width="100%" height="280px" id="VideoId" runat="server" src="https://www.youtube.com/embed/4XDq4kyCmdA" frameborder="0" allowfullscreen="" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" class=""></iframe>--%>
        </div>
    </div>
    <%--<div class="row hide">
        <div id="home-product-detail1">
            <div class="product-description">
                <div class="description">
                    <div class="inner">
                        <h5>Description</h5>
                        <ul>
                            <li id="lblproductdec" runat="server">Sukhadia Garbaddas Bapuji Honey Bites are made up of generous amounts of dry fruits held together with golden, sweet honey. 
                            They are a healthy, sugarless sweet that is often enjoyed during festivals such as Diwali, or simply as a scrumptious dessert after meals. 
                            These delectably sweet, dry fruit rich treats will make for an ideal gift for your loved ones.
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="feature">
                    <div class="inner">
                        <h5>Key features</h5>
                        <ul>
                            <li id="lblprodkeyfeature" runat="server">Sukhadia Garbaddas Bapuji Honey Bites are made up of generous amounts of dry fruits held together with golden, sweet honey. 
                            They are a healthy, sugarless sweet that is often enjoyed during festivals such as Diwali, or simply as a scrumptious dessert after meals. 
                            These delectably sweet, dry fruit rich treats will make for an ideal gift for your loved ones.

                            </li>
                            <li>Sukhadia Garbaddas Bapuji Honey Bites are made up of generous amounts of dry fruits</li>
                        </ul>
                    </div>
                </div>
                <div class="notes">
                    <div class="inner">
                        <h5>Please Note</h5>
                        <ul id="lblprodnote" runat="server">
                            <li>They are a healthy, sugarless sweet that is often enjoyed during festivals such as Diwali, or simply as a scrumptious dessert after meals</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>



    <!-- The Modal -->
    <div class="modal" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="row">
                        <div id="home-product-detail">
                            <div class="product-description">
                                <div class="description">
                                    <div class="inner">
                                        <h5>Description</h5>
                                        <div id="lblproductdec" runat="server"></div>
                                        <%-- <ul  id="lblproductdec" runat="server">
                          
                        </ul>--%>
                                    </div>
                                </div>
                                <div class="feature">
                                    <div class="inner">
                                        <h5>Key features</h5>
                                        <div id="lblprodkeyfeature" runat="server">
                                        </div>
                                        <%--<ul id="lblprodkeyfeature" runat="server">
                           
                           
                        </ul>--%>
                                    </div>
                                </div>
                                <div class="notes">
                                    <div class="inner">
                                        <h5>Terms & conditions</h5>
                                        <div id="lblprodnote" runat="server">
                                        </div>
                                        <%--                        <ul id="lblprodnote" runat="server">
                           
                        </ul>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>

    <div class="container hide">
        <div class="product-title">
            <div class="product-name">
                <p id="lblproductHeader" runat="server">Duna Burfi</p>
            </div>
        </div>
    </div>
    <div class="container hide">
        <div id="main-div">
            <div class="col-md-6 left-section">
                <div class="product-detail">
                    <%--  <div class="name">
                            <p id="lblproductHeader" runat="server">Duna Burfi</p>
                        </div>--%>
                    <div class="product-price">
                        <p><span class="span-mrp">MRP</span><sub class="discount">₹ 0</sub><span class="main-price" id="lblpricemain" runat="server">₹ 0</span></p>
                    </div>

                    <div class="product-image-multiple">
                        <div id="productCarousel" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->
                            <ol class="carousel-indicators" id="divimgid" runat="server">
                                <li data-target="#productCarousel" data-slide-to="0" class="active"></li>
                                <li data-target="#productCarousel" data-slide-to="1"></li>
                                <li data-target="#productCarousel" data-slide-to="2"></li>
                            </ol>

                            <!-- Wrapper for slides -->
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="right-section">
                    <div class="social-links">
                        <img class="space" src="images/facebook.png" />
                        <img class="space" src="images/whatsapp.png" />
                        <img class="space" src="images/instagram.png" />
                        <%--    <i class="fa fa-facebook fb"></i>
                                        <i class="fa fa-whatsapp wa"></i>
                                        <i class="fa fa-instagram ins"></i>--%>
                    </div>
                    <div class="buy-options-outer">
                        <div class="buy-options">
                            <%--   <asp:Button ID="BuyOne" class="button" runat="server" Text="Buy 1 for Rs.678" />
                            <asp:Button ID="BuyOneWithFriend" class="button" runat="server" Text="Buy 1 for Rs.678" />
                            <asp:Button ID="BuyFivewithFriend" class="button" runat="server" Text="Buy 1 for Rs.678" />--%>
                        </div>
                    </div>
                    <p class="or">OR</p>
                    <div class="buy-options-outer">
                        <p>Use Friend's Offer Code</p>
                        <div class="offer-code">
                            <%--  <hr />--%>
                            <input runat="server" type="text" name="offercode" placeholder="ENTER OFFER CODE" />
                        </div>
                        <div class="buy-now-button">
                            <asp:Button class="buy-now" ID="Button1" runat="server" Text="Buy Now" />
                            <%-- <a href="" >Buy Now</a>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script>
            //var fbButton = document.getElementById('fb-share-button');
            //var url = window.location.href;

            //fbButton.addEventListener('click', function () {
            //    window.open('https://www.facebook.com/sharer/sharer.php?u=' + url,
            //        'facebook-share-dialog',
            //        'width=800,height=600'
            //    );
            //    return false;
            //});
        </script>

        <script>
            //function decorateWhatsAppLink() {
            //    //set up the url
            //    var url = 'whatsapp://send?text=';

            //    //define the message text
            //    var text = 'Check out this awesome product I found on SaleBhai.in!';

            //    //encode the text
            //    var encodedText = encodeURIComponent(text);

            //    //find the link
            //    var $whatsApp = $('.whatsapp a');

            //    //set the href attribute on the link
            //    $whatsApp.attr('href', url + encodedText);
            //}

            ////call the decorator function
            //decorateWhatsAppLink()
        </script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <script>
            $(document).ready(function () {
                //$("#myPinCodeModal").modal('show');
                $('#myPinCodeModal').modal({ backdrop: 'static', keyboard: false })
                //const urlParams1 = new URLSearchParams(window.location.search);

                //if (urlParams1 != null && urlParams1 != "") {

                //    lbllogout.InnerHtml = "<li><p><span><a href=\"register.aspx\">Login</a></span></p><li>";
                //}


            });

            function Newcheckservices() {

                var pincode = $("#txtPinCodeval").val();
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
                        var message = getdata.data.Message;
                        var resultflag = getdata.data.resultflag;
                        var JurisdictionId = getdata.data.JurisdictionID;
                        //alert(resultflag);
                        if (resultflag == "1") {
                            $("#lblpinnotmsg").hide();
                            $("#lblpinmsg").show();
                            var labelObj = document.getElementById("<%=lblpinmsg.ClientID %>");
                            labelObj.innerHTML = message;
                            $("#lblpinmsg").val(message);
                            $("#myPinCodeModal").modal('hide');
                            $("#hdnJurisdictionId").val(JurisdictionId);
                            $("#spanpincode").html('Deliver to ' + pincode);

                            //Get Product Data Load

                            $.ajax({
                                type: 'POST',
                                url: "Default.aspx/GetFillData",
                                data: '{JurisdictionId:"' + JurisdictionId + '"}',
                                contentType: "application/json",
                                dataType: "json",
                                success: function (response) {
                                    //var getdata = {
                                    //    data: JSON.parse(response.d.CategoryList),
                                    //}
                                    //var categoryImage = getdata.data.CategoryImage;
                                    //$("#lbltopbanner").attr(src,categoryImage);

                                    //for (var i = 0; i < response.d.CategoryList.length; i++) {
                                    //    if (i == 0) {
                                    //        var categoryImage = response.d.CategoryList[i].CategoryImage;
                                    //        var CategoryDescription = response.d.CategoryList[i].CategoryDescription;
                                    //        $("#ContentPlaceHolder1_lbltopbanner").attr("src", categoryImage);
                                    //        $("#ContentPlaceHolder1_link").attr("href", CategoryDescription);
                                    //    }

                                    //}

                                    $("#divCategory").append(JSON.stringify(response.d).replace('"', " "));

                                    //var data = {
                                    //    "JurisdictionId": JurisdictionId,
                                    //    "StartNo": '1',
                                    //    "EndNo": '5'
                                    //};
                                    
                                    $.ajax({
                                        type: 'POST',
                                        url: "Default.aspx/GetNewdata",
                                        //data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"1",EndNo:"5"}',
                                        //data: data,
                                         data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"1",EndNo:"5"}',
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

                                },
                                failure: function (response) {

                                    alert("Something Wrong....");

                                }
                            });

                        }
                        else {
                            $("#lblpinmsg").hide();
                            $("#lblpinnotmsg").show();
                            var labelObj = document.getElementById("<%=lblpinnotmsg.ClientID %>");
                            labelObj.innerHTML = message;
                            $("#lblpinnotmsg").val(message);
                        }
                    },
                    failure: function (response) {

                        alert("Something Wrong....");

                    }
                });



                //}

            };
        </script>
    </div>
    <%--<script src="OwlCarousel/docs/assets/vendors/jquery.min.js"></script>--%>
    <%--<script src="OwlCarousel/dist/owl.carousel.js"></script>--%>
    <script>
        //$('.owl-carousel').owlCarousel({
        //    loop: true,
        //    margin: 10,
        //    nav: true,
        //    autoplay: true,
        //    autoplayTimeout: 4000,
        //    autoplayHoverPause: true,
        //    responsive: {
        //        0: {
        //            items: 1
        //        },
        //        600: {
        //            items: 1
        //        },
        //        1000: {
        //            items: 1
        //        }
        //    }
        //})
    </script>
    <div class="container hide">
        <hr />
        <div class="offer-time">
            <div class="inner">
                <img src="images/discount.png" />
                <p>Offer Expiring : <span>HH:MM:SS</span></p>
            </div>
        </div>
        <hr />
    </div>

</asp:Content>
