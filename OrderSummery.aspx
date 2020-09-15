<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderSummery.aspx.cs" Inherits="OrderSummery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--Darshan--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #order-summery .ordersummery-address {
           
            margin-bottom: 7px!important;
        }
        #shopping-cart .single-product .product-qty .inline .minus {
  
    height: 27px!important;
    width: 29px!important;
   
    font-size: 18px!important;
}

        #shopping-cart .single-product .product-qty .inline .plus {
    width: 29px!important; 
    height: 27px!important;   
    font-size: 18px!important;
}
    </style>
    <div id="order-summery" >
        <div class="container">
            <div class="ordersummery-address">
                <div class="row">
                    <div class="col-md-6">
                        <div class="shipped-address">
                            <p class="title">Shipping Address</p>
                            <div class="customer-address">
                                <span class="phone-no"><span id="lblfname" runat="server">Pratixa Patel</span> </span>
                                <span id="lblmno" runat="server"></span>&nbsp;
                                <a href="checkout.aspx">Change</a>

                                <div class="address-detail">
                                    <span id="add1" runat="server"></span>
                                    <span id="add2" runat="server">Bharuch, Gujarat, 392001</span>
                                    <span id="add3" runat="server">India</span>
                                </div>
                                
                               
                            </div>
                        </div>
                    </div>
                    <div id="divMyText" style="display: none">

                        <asp:Label ID="lblCustid" runat="server"></asp:Label>
                        <asp:Label ID="lbltemp" runat="server"></asp:Label>
                        <asp:Label ID="lbladdrid" runat="server"></asp:Label>
                        <asp:Label ID="lblccode" runat="server"></asp:Label>
                        <asp:Label ID="lblbuyflag" runat="server"></asp:Label>

                    </div>
                    <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
                    <div class="col-md-6 right-section" style="display: none">
                        <div class="shipped-address">
                            <p class="title">Delivery By</p>
                            <p class="delivery-time" id="lbldeliverydate" runat="server">Delivery within Ahmedabad in 2-3 business days</p>
                        </div>
                    </div>
                </div>
            </div>
            <div id="shopping-cart">
                <div class="row">
                    <div class="column-labels hide">
                        <label class="product-image">Image</label>
                        <label class="product-details">Product Name</label>
                        <label class="product-price">Price</label>
                        <label class="product-weight">Weight</label>
                        <label class="product-quantity">Quantity</label>
                        <label class="product-line-price">Total</label>

                    </div>
                    <div class="column-labels">
                        <p class="title">Cart</p>

                    </div>
                    <div id="prodcontent" runat="server">
                    <div class="single-product">
                        <div class="single-product left">
                            <div class="product-image">
                                <img  id="proimg" src="/" runat="server" />
                            </div>
                        </div>
                        <div class="single-product right">

                            <div class="product-name-order" id="lblpname" runat="server">
                                <p>Duna Burfi</p>
                            </div>
                            <div class="price">
                                <div class="gram">
                                    <div>
                                    Weight:<span id="lbldisplayunit" runat="server">250-gram</span><br />
                                        </div>
                                    <br />
                                    <div>
                                    Price/Qty:<p id="lblproprice" runat="server">200 </p>
                                        </div>
                                    <%--/ --%>
                        <%--<span id="lbldisplayunit" runat="server">250-gram</span>--%>
                                </div>
                                
                                <div class="final-amt">
                                    <p runat="server" id="lbltotprices">₹25.98</p>
                                </div>
                            </div>
                            <div class="product-qty">
                                <div class="inline">
                                    <button type="button" class="minus" runat="server" id="btnminuqty" onclick="PriceMinus()" style="color:white;background-color:#1DA1F2">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <div class="qty" style="display: grid;">
                                        <input type="text" id="txtqty" value="1" class="" style="width: 29px; height: 27px;" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" maxlength="2" onchange="Pricecalculation()" runat="server" />
                                        <a onclick="saveitem(0); return false;">Save</a>
                                    </div>
                                    <button type="button" runat="server" class="plus" id="btnplus" onclick="Priceplus()" style="color:white;background-color:#1DA1F2">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="product-line-price">
                                <i class="fa fa-trash" onclick="Remove()"></i>
                            </div>
                        </div>
                    </div>
                        </div>
                </div>
                <div class="total">
                    <div class="row section">
                        <div class="total-amount">
                            <span>Total Price:₹</span><span id="totwtshipping" runat="server"></span>

                        </div>
                        <div class="saving hide" >
                            <p id="P1" runat="server">(-) Offer Discount (₹<asp:Label ID="lblofferprice" runat="server" Text="15"></asp:Label>*<asp:Label ID="lblqty" runat="server" Text="2"></asp:Label>) :₹<span id="lbltotofferprice" runat="server">30</span></p>
                        </div>
                        <div class="darshan hide">
                            <span id="lblshipping" runat="server">(-) Offer Discount (₹</span><asp:Label ID="lblshipping1" runat="server"></asp:Label><span id="lblmul" runat="server"></span><asp:Label ID="lblqty1" runat="server" Text=""></asp:Label><span id="lblbr" runat="server"></span> <span id="lblrs" runat="server"></span><span id="lbltotshipping" runat="server"></span>


                        </div>

                        <%-- <div class="shipping-include">
                               
                            </div>--%>

                        <div class="total-saving hide">
                            <p id="lblgst" runat="server">Total Saving + Shipping Discount: <span>₹258</span></p>
                            <p class="discount-price" id="totwithshipp" runat="server">Shipping Included:<span class="discount-price-span"></span></p>
                        </div>
                        <div class="redeem" id="divRedeem">
                            <p id="lblredeemtext" runat="server">(-) Redeem Amount: ₹<span id="lblredeem" runat="server">0</span></p>

                        </div>
                        <div class="payable-amount">
                            <p id="lblpayableamt" runat="server">Payable Amount: ₹<span id="lbltotpayamt" runat="server">8552</span></p>
                        </div>

                    </div>

                </div>
                <div class="coupon-box hide">
                    <div id="applyRedeem">
                        <div class="sb-inline-block titlebox" style="vertical-align: middle; padding: 10px 10px 10px 0;">
                            <div class="title">
                                <strong class="formlabel">Money in your wallet : ₹<span id="reeamt" runat="server"></span></strong>
                            </div>
                        </div>
                        <div class="coupon-code sb-inline-block">
                            <input name="discountreferralcode" onkeypress="return event.charCode >= 48 &amp;&amp; event.charCode <= 57" placeholder="Enter Amount To Redeem" id="punchamt" runat="server" class="text-box" style="width: initial; font-size: 13px; text-align: center; font-weight: 500;" type="text" />
                            <input type="button" id="btnredem" style="width: initial; padding: 0 10px; font-size: 16px;" name="applyreferralcode" value="Redeem" class="btn btn-buy-big continue-button" onclick='reedemwallet(1)' runat="server" />
                            <input type="button" id="cancel_redeemamount" style="width: initial; padding: 10px; font-size: 15px;" name="cancelreferralcode" value="Cancel" class="btn btn-buy-big continue-button hide" /><span class="please-wait hide" id="reedemplswait">Please Wait</span>

                        </div>
                    </div>
                    <div id="changeredeem">
                        <div id="_redeemerrmsg" class="hint formlabel" style="color: red; text-transform: none; white-space: inherit;"></div>
                        <a id="_redeemerrmsgtandcLink"></a>
                        <div id="_redeemmsg" class="hint formlabel" style="color: green; text-transform: none; white-space: inherit;"></div>
                        <p style="color: #239423; font-size: 13px; font-family: verdana; font-weight: 700;" id="lblshowmsgwallet" runat="server"></p>

                        <input type="button" id="Button1" style="width: initial; padding: 0 10px; font-size: 16px;" name="applyreferralcode" value="Change" class="btn btn-buy-big continue-button" onclick="saveitem(0); return false;" runat="server" />

                    </div>
                </div>
                <div class="">
                </div>
                <div class="totals hide">
                    <div class="totals-item">
                        <label>Subtotal</label>
                        <div class="totals-value" id="cart-subtotal">71.97</div>
                    </div>
                    <div class="totals-item">
                        <label>Tax (5%)</label>
                        <div class="totals-value" id="cart-tax">3.60</div>
                    </div>
                    <div class="totals-item">
                        <label>Shipping</label>
                        <div class="totals-value" id="cart-shipping">15.00</div>
                    </div>
                    <div class="totals-item totals-item-total">
                        <label>Grand Total</label>
                        <div class="totals-value" id="cart-total">90.57</div>
                    </div>
                </div>
                <div style="text-align: center">
                    <button class="checkout" id="btnplaceorder" type="button" onclick="Placeorder()">Place Order</button>
                    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
                </div>
                <div id="divMainloaderplace" style="text-align:center;display:none;">
                                Processing...
                            </div>
            </div>
        </div>
    </div>



    <script>
        var products = [];
        $(document).ready(function () {
           
            $('.offer-time').css('display', 'none');
      
            //$("#btnplaceorder").click();

            var reedamamt = document.getElementById('<%= punchamt.ClientID %>').value;

            if (reedamamt == "" || reedamamt == "0" || reedamamt == "0.00") {
                $("#divRedeem").hide();
                $("#applyRedeem").show();
                $("#changeredeem").hide();
            }
            else {
                $("#divRedeem").show();
                $("#changeredeem").show();
                $("#applyRedeem").hide();

            }
        });

        //Change Button Click show apply and hide change
        function Changediv(){
            $("#applyRedeem").show();
            $("#changeredeem").hide();
        }



        //Flag 1 Redeem Value Directly Calculation
        //Flag 0 Redeem Value after Caluculation
        //SaveButtonClick

        function saveitem(flag){

            if (flag == 0) {
                $("#ContentPlaceHolder1_lblredeem").html("0");
                $("#ContentPlaceHolder1_punchamt").val('');
            }

            var ptotprice = $('#ContentPlaceHolder1_lbltotprices').html();
            var labelObj = document.getElementById("<%=totwtshipping.ClientID %>");
            labelObj.innerHTML = ptotprice;
            var qty5 = document.getElementById('<%= txtqty.ClientID %>').value;
            var qty = Number(qty5);

            var offer = $('#ContentPlaceHolder1_lblofferprice').html();

            var shiping = $('#ContentPlaceHolder1_lblshipping1').html();

            var totship = qty * shiping;
            var totoffer = offer * qty;
            var totship = totship.toFixed(2);
            var totoffer = totoffer.toFixed(2);
            var objqry1 = document.getElementById("<%= lblqty1.ClientID %>");
           objqry1.innerHTML = qty;

           var objqty = document.getElementById("<%= lblqty.ClientID %>");
            objqty.innerHTML = qty;

            var objoffertot = document.getElementById("<%= lbltotofferprice.ClientID %>");

            var reedam = $('#ContentPlaceHolder1_lblredeem').html();
            reedam = Number(reedam);

            objoffertot.innerHTML = totoffer;
            ptotprice = Number(ptotprice);
            totoffer = Number(totoffer);
            totship = Number(totship);


            var fprice = ptotprice - totoffer + totship;

            if (reedam == "") {
                reedam = "0";
            }

            finalprice = fprice - reedam;

            var finalprice = finalprice.toFixed(2);

            $('#ContentPlaceHolder1_lbltemp').html(fprice);


            var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
            objpay.innerHTML = finalprice;

            var objpay = document.getElementById("<%= lbltotshipping.ClientID %>");
            objpay.innerHTML = totship;

            finalprice = 0;

            if (flag == 0) {
                reedemwallet(0);
                $("#ContentPlaceHolder1_lblredeemtext").hide();
                $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                $("#divRedeem").hide();
                $("#applyRedeem").show();
                $("#changeredeem").hide();

            }

        }





        //Price CalculationNormal
        function Pricecalculation() {
            //var pprice = document.getElementById("ContentPlaceHolder1_lbltotprices").valueOf;
            var pprice1 = $('#ContentPlaceHolder1_lblproprice').html();
            var qty5 = document.getElementById('<%= txtqty.ClientID %>').value;
            var qty = Number(qty5);
            var tot1 = pprice1 * qty;

            var tot = tot1.toFixed(2);
            //alert(tot);
            //$('#').text = tot;
            var labelObj = document.getElementById("<%= lbltotprices.ClientID %>");
            labelObj.innerHTML = tot;
        }

        //Price Minus  Calculation
        <%--function PriceMinus() {
            var pprice1 = $('#ContentPlaceHolder1_lblproprice').html();
            var qty5 = document.getElementById('<%= txtqty.ClientID %>').value;
            var qty = Number(qty5);
            if (qty > 1) {
                qty = qty - 1;
                var tot1 = pprice1 * qty;

                var tot = tot1.toFixed(2);
                var labelObj = document.getElementById("<%= lbltotprices.ClientID %>");
                labelObj.innerHTML = tot;

                MyTextBox = document.getElementById("<%= txtqty.ClientID %>");
                MyTextBox.value = qty;

            }

        }--%>

        function PriceMinus(prodid, el) {

             $this = $(el);
            var price = $this.parents('.single-product').find('#lblproprice')[0].innerHTML;
            var proqty = $this.parents('.single-product').find('#txtqty').val();
             var prweight = $this.parents('.single-product').find('#lbldisplayunit')[0].innerHTML;
            var PWeight = prweight.substr(0, prweight.indexOf('-'));

            var qty = Number(proqty);
            if (qty > 1) {
                qty = qty - 1;

                var prtotal = price * qty;
                var total = prtotal.toFixed(2);

                $this.parents('.single-product').find('#lbltotprices')[0].innerHTML = total;

                $this.parents('.single-product').find('#txtqty').val(qty);

                var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
                document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt - Number(price));
                document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;

                if (products.length > 0) {
                    var product = products.find(x => x.Productid == prodid);
                    if (product != null && product != undefined) {
                        products.splice(products.findIndex(x => x.Productid == prodid), 1);

                        obj = {
                            Productid: prodid,
                            Qty: parseInt(qty),
                            Weight: parseInt(PWeight)
                        }
                        products.push(obj);
                    }
                    else {
                        obj = {
                            Productid: prodid,
                            Qty: parseInt(qty),
                            Weight: parseInt(PWeight)
                        }
                        products.push(obj);
                    }
                } else {
                    obj = {
                        Productid: prodid,
                        Qty: parseInt(qty),
                        Weight: parseInt(PWeight)
                    }
                    products.push(obj);
                }
            }
            else {
                Remove(prodid, el);
            }
            console.log(products);
        }

        function Priceplus(prodid, el) {
            $this = $(el);
            var price = $this.parents('.single-product').find('#lblproprice')[0].innerHTML;
            var proqty = $this.parents('.single-product').find('#txtqty').val();
            var prweight = $this.parents('.single-product').find('#lbldisplayunit')[0].innerHTML;
            var PWeight = prweight.substr(0, prweight.indexOf('-'));

            var qty = Number(proqty);
            qty = qty + 1;

            var prtotal = price * qty;
            var total = prtotal.toFixed(2);

            $this.parents('.single-product').find('#lbltotprices')[0].innerHTML = total;

            $this.parents('.single-product').find('#txtqty').val(qty);

            var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
            document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt + Number(price));
            document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;


            if (products.length > 0) {
                 var product = products.find(x => x.Productid == prodid);
                 if (product != null && product != undefined) {
                     products.splice(products.findIndex(x => x.Productid == prodid), 1);

                     obj = {
                         Productid: prodid,
                         Qty: parseInt(qty),
                         Weight:parseInt(PWeight)
                     }
                     products.push(obj);
                 }
                 else {
                     obj = {
                         Productid: prodid,
                         Qty: parseInt(qty),
                         Weight:parseInt(PWeight)
                     }
                     products.push(obj);
                 }
             } else {
                obj = {
                         Productid: prodid,
                         Qty: parseInt(qty),
                         Weight:parseInt(PWeight)
                     }
                     products.push(obj);
            }
            console.log(products);
        }

        function Remove(prodid,el) {
            //alert("ProductId: " + prodid);
            var $this = $(el);
            var r = confirm("Are you sure you want to remove this item?");
            if (r == true) {
                $.ajax({

                    type: "POST",
                    url: "OrderSummery.aspx/Remove",
                    data: '{productid:"' + prodid + '"}',
                    contentType: "application/json;charset=utf-8",
                    datatype: "json",
                    success: function (ResponseData) {
                        //alert(ResponseData.d);
                        if (ResponseData.d == "Success") {
                            var price = $this.parents('.single-product').find('#lbltotprices')[0].innerHTML;
                            var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
                            document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt - Number(price));
                            document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;
                            $this.parents('.single-product')[1].remove();

                        } else if (ResponseData.d == "lastproduct") {
                            //alert("One product is required to complete order. So you can not remove this product.");
                             window.location = "Default.aspx";
                        }
                        else {
                            alert("Somthing Wrong");
                        }

                    },
                    failure: function (ResponseData) {
                        alert("Somthing Wrong");
                    }
                });
            }
        }

        //Price Plus Caluculation
        <%--function Priceplus() {
            //var pprice = document.getElementById("ContentPlaceHolder1_lbltotprices").valueOf;
            var pprice1 = $('#ContentPlaceHolder1_lblproprice').html();

            var qty5 = document.getElementById('<%= txtqty.ClientID %>').value;
            var qty = Number(qty5);
            qty = qty + 1;
            var tot1 = pprice1 * qty;

            var tot = tot1.toFixed(2);
            var labelObj = document.getElementById("<%= lbltotprices.ClientID %>");
            labelObj.innerHTML = tot;

            MyTextBox = document.getElementById("<%= txtqty.ClientID %>");
            MyTextBox.value = qty;


        }--%>




        //Directly Apply Redeem pass amt 1
        //Save Button Click and Call Redeem amt 0 and pass value payamt 0 
        function reedemwallet(amt) {

            if (amt == "1") {
                $("#changeredeem").show();
                $("#applyRedeem").hide();
            }

            $("#ContentPlaceHolder1_lblredeemtext").show();
            $('#ContentPlaceHolder1_lblshowmsgwallet').show();
            var reedamamt = document.getElementById('<%= punchamt.ClientID %>').value;

            //Redeem Amount Section Hide Show amount and Change
            if (reedamamt == "" || reedamamt == "0" || reedamamt == "0.00") {
                $("#divRedeem").hide();
            }
            else {
                $("#divRedeem").show();
            }
            var custid = $('#<%=lblCustid.ClientID%>').html();
            var payamt = $('#<%=lbltemp.ClientID%>').html();

            if (reedamamt == "") {
                reedamamt = "0";
                $("#ContentPlaceHolder1_punchamt").val('0');
            }

            $.ajax({
                type: "POST",
                //url: "http://192.168.1.108/api/RedeemWallet/RedeemWallet?CustomerId=" + custid + "&OrderTotal=" + payamt + "&Redemeamount=" + reedamamt + "",
                url: "OrderSummery.aspx/ReedemWalletDetails",
                data: '{Reeamt:"' + reedamamt + '",CustId:"' + custid + '",PayAmt:"' + payamt + '"}',
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    if (response != "") {
                        //alert(response.d.resultflag + response.resultflag);
                        var bar_data =
                       {
                           data: JSON.parse(response.d),
                       };

                        if (reepasamt != "") {
                            var available = bar_data.data.Message;
                            $('#ContentPlaceHolder1_lblshowmsgwallet').html(available);
                        }

                        //Flag 1 Only Calculation 
                        if (bar_data.data.resultflag != 0) {
                            var wallamt = bar_data.data.WalletAmount;
                            $("#ContentPlaceHolder1_reeamt").html(wallamt);

                            var reepasamt = document.getElementById('<%= punchamt.ClientID %>').value;
                            $("#ContentPlaceHolder1_lblredeem").html(reepasamt);
                            saveitem(1);
                        }

                        //Not Valid Amount  flag 0 No Data found
                        if (bar_data.data.resultflag == 0) {
                            $("#ContentPlaceHolder1_punchamt").val('');
                            $("#divRedeem").hide();

                        }

                        //If Value Null to Hide Lable 
                        var valuenullcheck = document.getElementById('<%= punchamt.ClientID %>').value;
                        if (valuenullcheck == "0") {
                            $("#ContentPlaceHolder1_punchamt").val('');
                            $("#ContentPlaceHolder1_lblredeemtext").hide();

                        }

                    }
                    else {
                        alert("Error");
                    }
                },
                failure: function (response) {
                    alert("err");
                }
            })
        }



        //CustomerId, PaidAmount, AddressId, Quantity, buywith, discountamount, Redeemeamount, couponCode

        function Placeorder() {
            $("#divMainloaderplace").attr("display", "block");
            $("#btnplaceorder").attr("disabled", true);
            var CustId = $("#ContentPlaceHolder1_lblCustid").html();
            var PaidAmt = $("#ContentPlaceHolder1_lbltotpayamt").html();
            var Qty = $("#ContentPlaceHolder1_txtqty").val();
            var disct = $("#ContentPlaceHolder1_lbltotofferprice").html();
            var Redamt = $("#ContentPlaceHolder1_lblredeem").html();
            var addrid = $("#ContentPlaceHolder1_lbladdrid").html();
            var refcode = $("#ContentPlaceHolder1_lblccode").html();
            var buyflag = $("#ContentPlaceHolder1_lblbuyflag").html();
            var shipcharge = $("#ContentPlaceHolder1_lbltotshipping").html();
            var Ccode = 0;
            var totalamount = PaidAmt;


            if (PaidAmt == "0" || PaidAmt =="0.0" || PaidAmt=="0.00") {
                $.ajax({
                    type: "POST",
                    url: "OrderSummery.aspx/PlaceOrderAmtZero",
                    data: '{CustId:"' + CustId + '",PayAmt:"' + PaidAmt + '",addr:"' + addrid + '",qty:"' + Qty + '",buyflag:"' + buyflag + '",disc:"' + disct + '",redm:"' + Redamt + '",ccode:"' + Ccode + '",shipcharg:"' + shipcharge + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {                       
                       // alert(response.d)
                        if (response != "") {

                                var Resp=
                                {
                                data:JSON.parse(response.d),
                                };
                                if (Resp.data.resultflag == 1)
                                {
                                     $("#divMainloaderplace").attr("display", "none");
                                    var Oid = Resp.data.OrderId;
                                    //alert(Oid);
                                    window.location = "final.aspx"; 
                                }
                                else
                                {
                                     $("#divMainloaderplace").attr("display", "none");
                                    $("#btnplaceorder").attr("disabled", false);
                                    alert("No Data Found ..");
                                }
                        }
                        else {
                             $("#divMainloaderplace").attr("display", "none");
                              $("#btnplaceorder").attr("disabled", false);
                            alert("Services Not Responding... ");
                        }
                    },
                    failure: function (response) {
                         $("#divMainloaderplace").attr("display", "none");
                          $("#btnplaceorder").attr("disabled", false);
                        alert("err");
                    }
                })
            }
            else
            {
                $.ajax({
                    type: "POST",
                    //url: "OrderSummery.aspx/CODPlaceOrder",
                    //data: '{CustId:"' + CustId + '",PayAmt:"' + PaidAmt + '",addr:"' + addrid + '",qty:"' + Qty + '",buyflag:"' + buyflag + '",disc:"' + disct + '",redm:"' + Redamt + '",ccode:"' + Ccode + '",shipcharg:"' + shipcharge + '",rcode:"' + refcode + '"}',
                    url: "OrderSummery.aspx/CODPlaceMultipleOrder",
                    data: JSON.stringify({summeryModel:products,totalamount}),
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {
                        window.location = "final.aspx";
                        // alert(response.d)
                        if (response != "") {
                           
                            var Resp=
                            {
                                data:JSON.parse(response.d),
                            };
                            if (Resp.data.resultflag == 1)
                            {
                                var Oid = Resp.data.OrderId;
                                //alert(Oid);
                               
                            }
                            else
                            {
                                alert("No Data Found ..");
                            }
                        }
                        else {
                            alert("Services Not Responding... ");
                        }
                    },
                    failure: function (response) {
                        alert("err");
                    }
                })
            }
            //else {
            //    $.ajax({
            //        type: "POST",
            //        url: "OrderSummery.aspx/PlaceOrderAmtMoreThanZero",
            //        data: '{CustId:"' + CustId + '",PayAmt:"' + PaidAmt + '",addr:"' + addrid + '",qty:"' + Qty + '",buyflag:"' + buyflag + '",disc:"' + disct + '",redm:"' + Redamt + '",ccode:"' + Ccode + '",shipcharg:"' + shipcharge + '"}',
            //        contentType: "application/json",
            //        dataType: "json",

            //        success: function (response) {
            //          //  alert(response.d)
            //            if (response != "") {
                           
            //                var Resp =
            //                {
            //                    data: JSON.parse(response.d),
            //                };
            //                if (Resp.data.resultflag == 1) {
            //                    var tid = Resp.data.txnId;
            //                   // alert(tid);
            //                    window.location = "payment.aspx";
            //                }
            //                else {
            //                    alert("NO Data Found...");
            //                }
            //            }
            //            else {
            //                alert("Services Not Responding... ");
            //            }
            //        },
            //        failure: function (response) {
            //            alert("err");
            //        }
            //    })
            //}




        }

    </script>

</asp:Content>

