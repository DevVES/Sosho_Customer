<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderSummery.aspx.cs" Inherits="OrderSummery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--Darshan--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #order-summery .ordersummery-address {
            margin-bottom: 7px !important;
        }

        #shopping-cart .single-product .product-qty .inline .minus {
            height: 27px !important;
            width: 29px !important;
            font-size: 18px !important;
        }

        #shopping-cart .single-product .product-qty .inline .plus {
            width: 29px !important;
            height: 27px !important;
            font-size: 18px !important;
        }
        .sidebar-overlay {
            position: absolute;
            display: none;
            left: 200vw;
            right: 0;
            top: 0;
            bottom: 0;
            z-index: 5;
            opacity: 0;
            transition: opacity 0.3s ease;
            z-index: 15;
        }
    </style>
    <div id="order-summery">
        <div class="container">
            <%--<div class="ordersummery-address">--%>
                <div>
                <div class="row">
                    <%--<div class="col-md-6">
                        <div class="shipped-address">
                            <p class="title">Shipping Address</p>
                            <div class="customer-address">
                                <span class="phone-no"><span id="lblfname" runat="server"></span> </span>
                                <span id="lblmno" runat="server"></span>&nbsp;
                                <a href="javascript:void(0)" id="Addrbtn"><span runat="server" id="spnAddrbtn">Change</span></a>

                                <div class="address-detail">
                                    <span id="add1" runat="server"></span>
                                    <span id="add2" runat="server"></span>
                                    <span id="add3" runat="server"></span>
                                </div>


                            </div>
                        </div>
                    </div>--%>
                    <div id="divMyText" style="display: none">

                        <asp:Label ID="lblCustid" runat="server"></asp:Label>
                        <asp:Label ID="lbltemp" runat="server"></asp:Label>
                        <asp:Label ID="lbladdrid" runat="server"></asp:Label>
                        <asp:Label ID="lblccode" runat="server"></asp:Label>
                        <asp:Label ID="lblbuyflag" runat="server"></asp:Label>
                        <asp:Label ID="lblWhatsAppNo" runat="server"></asp:Label>
                        <input type="hidden" id="promocode" />
                        <input type="hidden" id="productstatus" runat="server" value="false" />
                        <input type="hidden" id="minOrderAmount" runat="server" value="0" />
                        <input type="hidden" id="reedemableAmount" runat="server" value="0" />
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
                                    <img id="proimg" src="/" runat="server" />
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
                                        <button type="button" class="minus" runat="server" id="btnminuqty" onclick="PriceMinus()" style="color: white; background-color: #1DA1F2">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <div class="qty" style="display: grid;">
                                            <input type="text" id="txtqty" value="1" class="" style="width: 29px; height: 27px;" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" maxlength="2" onchange="Pricecalculation()" runat="server" />
                                            <a onclick="saveitem(0); return false;">Save</a>
                                        </div>
                                        <button type="button" runat="server" class="plus" id="btnplus" onclick="Priceplus()" style="color: white; background-color: #1DA1F2">
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
                            <span>Total MRP: ₹</span><span id="totmrp" runat="server"></span>
                        </div>
                        <div class="total-amount">
                            <span>Total Sosho Price: ₹</span><span id="totwtshipping" runat="server"></span>
                        </div>
                        <div class="saving hide">
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
                         <div class="redeem" id="divTotalDiscount">
                            <p id="P4" runat="server">Total Discount: ₹ <span id="spntotDiscount" runat="server">0</span></p>

                        </div>
                        <div class="redeem" id="divRedeem">
                            <p id="lblredeemtext" runat="server">(-) Wallet Redeemed Amount: ₹<span id="lblredeem" runat="server">0</span></p>

                        </div>
                        <div class="redeem hide" id="divPromo">
                            <p id="P2" runat="server">PromoCode Cashback: ₹<span id="spnpromo">0</span></p>
                        </div>
                          <div class="redeem hide" id="divDiscount">
                            <p id="P3" runat="server">(-) PromoCode Discount: ₹ <span id="spndiscount">0</span></p>
                        </div>
                         <div class="total-amount">
                            <p id="P5" runat="server">Total Saving: ₹<span id="spnsaving" runat="server">0</span></p>
                        </div>
                        <div class="payable-amount">
                            <p id="lblpayableamt" runat="server">Payable Amount: ₹<span id="lbltotpayamt" runat="server">8552</span></p>
                        </div>

                    </div>

                </div>

                  <div class="cart-footer">
                    <div class="cart-collaterals">
                        <div class="deals">
                            <div id="coupon-box" class="coupon-box">
                                <div class="sb-inline-block titlebox" style="vertical-align: middle;" id="coupon-box-2017-1">
                                    <div class="title">
                                        <a href="javascript:void(0);" id="havepromo" onclick="OpenModal()"><strong class="formlabel">Have a promocode?</strong></a>
                                         <a href="javascript:void(0);" id="cancelpromo" onclick="CancelPromo()"><strong class="formlabel">Remove Promocode</strong></a>
                                    </div>
                                </div>
                                <div class="coupon-code sb-inline-block hide" id="coupon-box-2017-2">
                                    <%--<input name="discountcouponcode" id="_discountcouponcode" placeholder="Enter your coupon here" class="text-box" style="width: 185px;" type="text"/>--%>
                                    <%--<input type="button" id="_btndiscount" style="font-size: 13px; background: rgb(29, 161, 242);border-color: rgb(29, 161, 242);" name="applydiscountcouponcode" value="Apply" class="btn btn-primary" onclick="Applypromocode()"/>--%>
                                </div>
                                <%--<div id="_redeemerrmsg1" class="hint formlabel" style="color: red; text-transform: none; white-space: inherit;">
                                </div>--%>
                                <%--<div id="_redeemmsg1" class="hint formlabel" style="color: green; text-transform: none; white-space: inherit;">
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="coupon-box">
                    <div id="applyRedeem">
                        <div class="sb-inline-block titlebox" style="vertical-align: middle; padding: 10px 10px 10px 0;">
                            <div class="title">
                                <strong class="formlabel">Money in your wallet : ₹<span id="reeamt" runat="server"></span></strong>
                                
                            </div>
                        </div>
                        <div class="coupon-code sb-inline-block" id="rdmamnt">
                            <input name="discountreferralcode" onkeypress="return event.charCode >= 48 &amp;&amp; event.charCode <= 57" placeholder="Enter Amount To Redeem" id="punchamt" runat="server" class="text-box" style="width: initial; font-size: 13px; text-align: center; font-weight: 500;" type="text" />
                            <input type="button" id="btnredem" style="width: initial; padding: 0 10px; font-size: 16px;background: rgb(29, 161, 242);border-color: rgb(29, 161, 242);" name="applyreferralcode" value="Redeem" class="btn btn-primary" onclick='reedemwallet(1)' />
                            <input type="button" id="cancel_redeemamount" style="width: initial;font-size: 15px;background: rgb(29, 161, 242);border-color: rgb(29, 161, 242);" name="cancelreferralcode" value="Cancel" onclick="saveitem(0)" class="btn btn-primary" /><span class="please-wait hide" id="reedemplswait">Please Wait</span>

                        </div>
                    </div>
                    <div id="changeredeem">
                        <div id="_redeemerrmsg" class="hint formlabel" style="color: red; text-transform: none; white-space: inherit;"></div>
                        <a id="_redeemerrmsgtandcLink"></a>
                        <div id="_redeemmsg" class="hint formlabel" style="color: green; text-transform: none; white-space: inherit;"></div>
                        <p style="color: #239423; font-size: 13px; font-family: verdana; font-weight: 700;" id="lblshowmsgwallet" runat="server"></p>

                        <input type="button" id="Button1" style="width: initial; padding: 0 10px; font-size: 16px;background: rgb(29, 161, 242);border-color: rgb(29, 161, 242);" name="applyreferralcode" value="Change" class="btn btn-primary" onclick="saveitem(0); return false;" runat="server" />

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
                    <%--<button class="checkout" id="btnplaceorder" type="button" onclick="Placeorder()">Place Order</button>--%>
                    <button class="checkout" id="btnplaceorder" type="button" onclick="Placeorder()">Confirm</button>
                    <asp:Literal ID="ltrmsg" runat="server"></asp:Literal>
                </div>
                <div id="divMainloaderplace" style="text-align: center; display: none;">
                    Processing...
                </div>
            </div>
        </div>
    </div>

        <div id="myPromoCodeModal" class="modal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
            <button type="button" class="close" onclick="CloseModal()" aria-hidden="true">&times;</button>
            <h4 class="modal-title" style="color: #1da1f2;font-weight: 600;">Enter Promocode</h4>
        </div>
                <div class="modal-body">
           <div class="row">
                        <div class="col-md-12" style="padding:0px;">
                            <div class="form-horizontal">
                                <div class="row">
                                    <div class="col-md-12" style="padding:0px;">
                                        <div class="col-md-6" style="float:left;padding:0px;">
                                            <input name="discountcouponcode" id="_discountcouponcode" placeholder="Have a promocode? Enter here" class="text-box form-control" style="width: 233px;" type="text"/>
                                             <div id="_redeemerrmsg1" class="hint formlabel" style="color: red; text-transform: none; white-space: inherit;">
                                </div>
                                        </div>
                                        
                                    <div class="col-md-6" style="padding:0px;">
                                        <input type="button" id="_btndiscount" style="font-size: 13px; background: rgb(29, 161, 242);border-color: rgb(29, 161, 242);" name="applydiscountcouponcode" value="Apply" class="btn btn-primary" onclick="Applypromocode(0)"/>
                                    </div>
                                    </div>
                                </div>
                                <br />
                                <div id="_redeemmsg1" class="hint formlabel" style="color: green; text-transform: none; white-space: inherit;">
                                </div>
                                <br />
                                <div id="promolist" runat="server">

                               
<%--                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <label class="control-label"><strong>FLAT50</strong></label>
                                            <label class="control-label" style="text-align:left;font-weight:200;">Users get flat 5% cashback on purchasing products from Paytm Mall. Use code RECH2MALL On Recharges Or Bill Payments to avail this offer.</label>
                                        </div>
                                        
                                    <div class="col-md-6" style="text-align:end;">
                                        <input type="button" style="font-size: 13px; background: #fff;border-color:  rgb(29, 161, 242);font-size:13px;color: rgb(29, 161, 242);" name="applydiscountcouponcode" value="Apply" class="btn btn-primary" onclick="Applypromocode(0)" />
                                    </div>
                                    </div>
                                </div>
                                <hr />--%>
                                     </div>
                            </div>
                             
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>



    <script>
        var products = [];
        $(document).ready(function () {
            $("#cancel_redeemamount").hide();
            $('.offer-time').css('display', 'none');
            $("#btnsendMessage").text($('#ContentPlaceHolder1_lblWhatsAppNo').text());
            //$("#btnplaceorder").click();
            var walletavlamnt = document.getElementById('<%= reeamt.ClientID %>').innerHTML;
            var reedamamt = document.getElementById('<%= punchamt.ClientID %>').value;
            if (walletavlamnt == "0" || walletavlamnt == "") {
                $("#rdmamnt").hide();
            }
            $("#divRedeem").hide();
            $("#ContentPlaceHolder1_Button1").hide();
            $("#cancelpromo").hide();
            $("#ContentPlaceHolder1_spnsaving").html($("#ContentPlaceHolder1_spntotDiscount").html());
            //$('#myPromoCodeModal').modal({ backdrop: true});
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

        });
        function OpenModal() {
            $('#_redeemmsg1').text('');
            $('#myPromoCodeModal').show();
        }
        function CloseModal() {
            $('#myPromoCodeModal').hide();
        }


        //Flag 1 Redeem Value Directly Calculation
        //Flag 0 Redeem Value after Caluculation
        //SaveButtonClick

        function saveitem(flag) {
            if (flag == 0) {
                $("#ContentPlaceHolder1_punchamt").removeAttr('disabled');
                 var ptotprice = $('#ContentPlaceHolder1_lbltotpayamt').html();

                var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                if (reedam == "") {
                    reedam = "0";
                }
                reedam = Number(reedam);

                ptotprice = Number(ptotprice);



            


                var finalprice = ptotprice + reedam;
                finalprice = finalprice.toFixed(2);



                var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
                objpay.innerHTML = finalprice;

                finalprice = 0;


                $("#ContentPlaceHolder1_lblredeem").html("0");
                $("#ContentPlaceHolder1_punchamt").val('');

                  //reedemwallet(0);
                $("#ContentPlaceHolder1_lblredeemtext").hide();
                $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                $("#divRedeem").hide();
                $("#btnredem").show();
                $("#cancel_redeemamount").hide();

                var discount = $("#spndiscount").html();
                if (discount == "") {
                    discount = "0";
                }
                discount = Number(discount);

                document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spnsaving.ClientID %>").innerHTML) - reedam;
                var walletmoney = Number($("#ContentPlaceHolder1_reeamt").html());

                $("#ContentPlaceHolder1_reeamt").html(walletmoney + reedam);

                if ($('#ContentPlaceHolder1_reedemableAmount').val() == "0") {
                    var orderAmnt = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;
                    GetReedemableAmount(orderAmnt);
                } else {
                    $('#ContentPlaceHolder1_punchamt').val($('#ContentPlaceHolder1_reedemableAmount').val());
                    $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                }
               
                return;
            }

            var ptotprice = $('#ContentPlaceHolder1_totwtshipping').html();
         

            var reedam = $('#ContentPlaceHolder1_lblredeem').html();
            reedam = Number(reedam);

            ptotprice = Number(ptotprice);

            var discount = $("#spndiscount").html();
             if (discount == "") {
                discount = "0";
            }
            discount = Number(discount);

            if (reedam == "") {
                reedam = "0";
            }
           


            var finalprice = ptotprice - (reedam + discount);
               finalprice= finalprice.toFixed(2);



            var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
            objpay.innerHTML = finalprice;

            document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;

            finalprice = 0;

            var walletmoney = Number($("#ContentPlaceHolder1_reeamt").html());

            $("#ContentPlaceHolder1_reeamt").html(walletmoney - reedam);
            $("#ContentPlaceHolder1_punchamt").val('0');
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

        function PriceMinus(prodid,Grpid,soshoprice,mrp,bannerid,producttype,el) {

            $this = $(el);
            var elprice = $this.parents('.single-product').find('#lblproprice');
            var price = elprice[0].firstElementChild.innerText.substring(elprice[0].firstElementChild.innerText.indexOf(":") + 2);
            //var price = $this.parents('.single-product').find('#lblproprice')[0].innerHTML;
            var proqty = $this.parents('.single-product').find('#txtqty').val();
            var prweight = $this.parents('.single-product').find('#lbldisplayunit')[0].innerHTML;
            //var PWeight = prweight.substr(0, prweight.indexOf('-'));
            var unitvalue = prweight.substring(prweight.indexOf(':') + 1);
            var parts = unitvalue.split('-');
            var PWeight = prweight.substring(prweight.indexOf(':') + 1, prweight.indexOf('-'));
            
            var pmrp = $this.parents('.single-product').find('#lblmrp')[0].innerHTML;

            var qty = Number(proqty);
            if (qty > 1) {
                qty = qty - 1;

                var prtotal = price * qty;
                var total = prtotal.toFixed(2);

                $this.parents('.single-product').find('#lbltotprices')[0].innerHTML = total;

                $this.parents('.single-product').find('#txtqty').val(qty);

                var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                

                if (reedam == "") {
                    reedam = "0";
                }
                reedam = Number(reedam);
                var discount = $("#spndiscount").html();
                 if (discount == "") {
                    discount = "0";
                }
                discount = Number(discount);

               
                var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
                document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt - Number(price));
                document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML) - (reedam + discount);


                var prtotalmrp = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML);
                document.getElementById("<%=totmrp.ClientID %>").innerHTML = (prtotalmrp - Number(pmrp));

                document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML) - Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);

                document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;

                if (products.length > 0) {
                    var product = products.find(x => x.Productid == prodid);
                    if (product != null && product != undefined) {
                        products.splice(products.findIndex(x => x.Productid == prodid), 1);
                        obj = {
                            Productid: prodid,
                            Grpid: Grpid,
                            Mrp: parseInt(mrp),
                            SoshoPrice: parseInt(soshoprice),
                            Qty: parseInt(qty),
                            Unit: parts[0],
                            UnitId: parts[1],
                            Productvariant: "",
                            BannerProductType: producttype,
                            BannerId: bannerid,
                            Weight: parseInt(PWeight)
                        }
                        //obj = {
                        //    Productid: prodid,
                        //    Qty: parseInt(qty),
                        //    Weight: parseInt(PWeight)
                        //}
                        products.push(obj);
                    }
                    else {
                        obj = {
                            Productid: prodid,
                            Grpid: Grpid,
                            Mrp: parseInt(mrp),
                            SoshoPrice: parseInt(soshoprice),
                            Qty: parseInt(qty),
                            Unit: parts[0],
                            UnitId: parts[1],
                            Productvariant: "",
                            BannerProductType: producttype,
                            BannerId: bannerid,
                            Weight: parseInt(PWeight)
                        }
                        //obj = {
                        //    Productid: prodid,
                        //    Qty: parseInt(qty),
                        //    Weight: parseInt(PWeight)
                        //}
                        products.push(obj);
                    }
                } else {
                    obj = {
                        Productid: prodid,
                        Grpid: Grpid,
                        Mrp: parseInt(mrp),
                        SoshoPrice: parseInt(soshoprice),
                        Qty: parseInt(qty),
                        Unit: parts[0],
                        UnitId: parts[1],
                        Productvariant: "",
                        BannerProductType: producttype,
                        BannerId: bannerid,
                        Weight: parseInt(PWeight)
                    }
                    //obj = {
                    //    Productid: prodid,
                    //    Qty: parseInt(qty),
                    //    Weight: parseInt(PWeight)
                    //}
                    products.push(obj);
                }
                UpdateSessionCart();
                var minOrderAmnt = $("#ContentPlaceHolder1_minOrderAmount").val();
                minOrderAmnt = Number(minOrderAmnt);

                if (minOrderAmnt > Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML)) {
                    saveitem(0);
                    $('#ContentPlaceHolder1_lblshowmsgwallet').show();
                    $('#ContentPlaceHolder1_punchamt').val("0");
                    $('#ContentPlaceHolder1_lblshowmsgwallet').html("Wallet money can be redeemed only if minimum order amount is more than ₹ " + minOrderAmnt);
                }
                else {

                    if ($('#ContentPlaceHolder1_reedemableAmount').val() == "0") {
                        var orderAmnt = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;
                        GetReedemableAmount(orderAmnt);
                    } else {
                        $('#ContentPlaceHolder1_punchamt').val( $('#ContentPlaceHolder1_reedemableAmount').val());
                        $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                    }
                    
                }
            }
            else {
                Remove(prodid,Grpid, el);
            }


            console.log(products);
        }

        function Priceplus(prodid,Grpid,soshoprice,mrp,bannerid,producttype, el) {
            $this = $(el);
            var elprice = $this.parents('.single-product').find('#lblproprice');
            var price = elprice[0].firstElementChild.innerText.substring(elprice[0].firstElementChild.innerText.indexOf(":") + 2);
            var proqty = $this.parents('.single-product').find('#txtqty').val();
            var prweight = $this.parents('.single-product').find('#lbldisplayunit')[0].innerHTML;

             var unitvalue = prweight.substring(prweight.indexOf(':') + 1);
            var parts = unitvalue.split('-');

            //var PWeight = prweight.substr(0, prweight.indexOf('-'));
            var PWeight = prweight.substring(prweight.indexOf(':') + 1, prweight.indexOf('-'));

            var pmrp = $this.parents('.single-product').find('#lblmrp')[0].innerHTML;

            var qty = Number(proqty);
            qty = qty + 1;

            var prtotal = price * qty;
            var total = prtotal.toFixed(2);

            $this.parents('.single-product').find('#lbltotprices')[0].innerHTML = total;

            $this.parents('.single-product').find('#txtqty').val(qty);

            var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                

            if (reedam == "") {
                reedam = "0";
            }
            reedam = Number(reedam);

            var discount = $("#spndiscount").html();
              if (discount == "") {
                discount = "0";
            }
            discount = Number(discount);

          

            var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
            document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt + Number(price));
            document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML) - (reedam + discount);

            var prtotalmrp = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML);
            document.getElementById("<%=totmrp.ClientID %>").innerHTML = (prtotalmrp + Number(pmrp));

            document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML) - Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);

            document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    products.splice(products.findIndex(x => x.Productid == prodid), 1);

                    obj = {
                        Productid: prodid,
                        Grpid: Grpid,
                        Mrp: parseInt(mrp),
                        SoshoPrice: parseInt(soshoprice),
                        Qty: parseInt(qty),
                        Unit: parts[0],
                        UnitId: parts[1],
                        Productvariant: "",
                        BannerProductType: producttype,
                        BannerId: bannerid,
                        Weight: parseInt(PWeight)
                    }
                    //obj = {
                    //    Productid: prodid,
                    //    Qty: parseInt(qty),
                    //    Weight: parseInt(PWeight)
                    //}
                    products.push(obj);
                }
                else {
                    obj = {
                        Productid: prodid,
                        Grpid: Grpid,
                        Mrp: parseInt(mrp),
                        SoshoPrice: parseInt(soshoprice),
                        Qty: parseInt(qty),
                        Unit: parts[0],
                        UnitId: parts[1],
                        Productvariant: "",
                        BannerProductType: producttype,
                        BannerId: bannerid,
                        Weight: parseInt(PWeight)
                    }
                    //obj = {
                    //    Productid: prodid,
                    //    Qty: parseInt(qty),
                    //    Weight: parseInt(PWeight)
                    //}
                    products.push(obj);
                }
            } else {
                obj = {
                    Productid: prodid,
                    Grpid: Grpid,
                    Mrp: parseInt(mrp),
                    SoshoPrice: parseInt(soshoprice),
                    Qty: parseInt(qty),
                    Unit: parts[0],
                    UnitId: parts[1],
                    Productvariant: "",
                    BannerProductType: producttype,
                    BannerId: bannerid,
                    Weight: parseInt(PWeight)
                }
                //obj = {
                //    Productid: prodid,
                //    Qty: parseInt(qty),
                //    Weight: parseInt(PWeight)
                //}
                products.push(obj);
            }
             UpdateSessionCart();
            var minOrderAmnt = $("#ContentPlaceHolder1_minOrderAmount").val();
            minOrderAmnt = Number(minOrderAmnt);

            if (minOrderAmnt > Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML)) {
                saveitem(0);
                $('#ContentPlaceHolder1_lblshowmsgwallet').show();
                $('#ContentPlaceHolder1_punchamt').val("0");
                $('#ContentPlaceHolder1_lblshowmsgwallet').html("Wallet money can be redeemed only if minimum order amount is more than ₹ " + minOrderAmnt);
            } else {
                if ($('#ContentPlaceHolder1_reedemableAmount').val() == "0") {
                    var orderAmnt = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;
                    GetReedemableAmount(orderAmnt);
                } else {
                    $('#ContentPlaceHolder1_punchamt').val($('#ContentPlaceHolder1_reedemableAmount').val());
                    $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                }
            }

            console.log(products);
        }

        function Remove(prodid,Grpid, el) {
            //alert("ProductId: " + prodid);
            var $this = $(el);
            var r = confirm("Are you sure you want to remove this item?");
            var productstatus = $("#ContentPlaceHolder1_productstatus").val();
            if (r == true) {
                $.ajax({

                    type: "POST",
                    url: "OrderSummery.aspx/Remove",
                    data: '{productid:"' + prodid +'",attributeid:"' + Grpid+ '"}',
                    contentType: "application/json;charset=utf-8",
                    datatype: "json",
                    success: function (ResponseData) {
                        
                        ResponseData.d = ResponseData.d.split(",");
                        //alert(ResponseData.d);
                        if (ResponseData.d[0] == "Success") {
                             var product = products.find(x => x.Productid == prodid);
                            if (product != null && product != undefined) {
                                products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == Grpid), 1);
                            }
                            $("#ContentPlaceHolder1_productstatus").val(ResponseData.d[1]);
                            var price = $this.parents('.single-product').find('#lbltotprices')[0].innerHTML;
                            var prtotalamunt = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);
                            document.getElementById("<%=totwtshipping.ClientID %>").innerHTML = (prtotalamunt - Number(price));

                            var proqty = $this.parents('.single-product').find('#txtqty').val();
                            proqty = Number(proqty);

                            var pmrp = $this.parents('.single-product').find('#lblmrp')[0].innerHTML;

                            var total = Number(pmrp) * proqty;

                            var prtotalmrp = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML);
                            document.getElementById("<%=totmrp.ClientID %>").innerHTML = (prtotalmrp - total);

                            document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML = Number(document.getElementById("<%=totmrp.ClientID %>").innerHTML) - Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML);

                            var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                

                            if (reedam == "") {
                                reedam = "0";
                            }
                            reedam = Number(reedam);

                            var discount = $("#spndiscount").html();
                             if (discount == "") {
                                discount = "0";
                            }
                            discount = Number(discount);

                           

                            document.getElementById("<%=lbltotpayamt.ClientID %>").innerHTML = Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML) - (reedam + discount);

                            document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;

                            $this.parents('.single-product')[1].remove();

                            var minOrderAmnt = $("#ContentPlaceHolder1_minOrderAmount").val();
                            minOrderAmnt = Number(minOrderAmnt);

                            if (minOrderAmnt > Number(document.getElementById("<%=totwtshipping.ClientID %>").innerHTML)) {
                                saveitem(0);
                                $('#ContentPlaceHolder1_lblshowmsgwallet').show();
                                $('#ContentPlaceHolder1_punchamt').val("0");
                                $('#ContentPlaceHolder1_lblshowmsgwallet').html("Wallet money can be redeemed only if minimum order amount is more than ₹ " + minOrderAmnt);
                            } else {
                                if ($('#ContentPlaceHolder1_reedemableAmount').val() == "0") {
                                    var orderAmnt = document.getElementById("<%=totwtshipping.ClientID %>").innerHTML;
                                    GetReedemableAmount(orderAmnt);
                                } else {
                                    $('#ContentPlaceHolder1_punchamt').val($('#ContentPlaceHolder1_reedemableAmount').val());
                                    $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                                }
                            }

                        } else if (ResponseData.d[0] == "lastproduct") {
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
            $("#ContentPlaceHolder1_lblredeemtext").show();
            $('#ContentPlaceHolder1_lblshowmsgwallet').show();
            var reedamamt = document.getElementById('<%= punchamt.ClientID %>').value;
            $("#ContentPlaceHolder1_punchamt").removeAttr('disabled');
            //Redeem Amount Section Hide Show amount and Change
            if (reedamamt == "" || reedamamt == "0" || reedamamt == "0.00") {
                $("#divRedeem").hide();
                $('#ContentPlaceHolder1_lblshowmsgwallet').html("Please enter amount to redeem.");
                $('#ContentPlaceHolder1_lblshowmsgwallet').css('color', 'red');
                return;
            }
            else {
               $("#divRedeem").show();
                $('#ContentPlaceHolder1_lblshowmsgwallet').css('color',' #239423');
            }
            var custid = $('#<%=lblCustid.ClientID%>').html();
            //var payamt = $('#<%=lbltemp.ClientID%>').html();
            var payamt = $("#ContentPlaceHolder1_totwtshipping").html();

           

            $.ajax({
                type: "POST",
                //url: "http://192.168.1.108/api/RedeemWallet/RedeemWallet?CustomerId=" + custid + "&OrderTotal=" + payamt + "&Redemeamount=" + reedamamt + "",
                url: "OrderSummery.aspx/ReedemWalletDetails",
                data: '{Reeamt:"' + reedamamt + '",CustId:"' + custid + '",PayAmt:"' + payamt + '"}',
                contentType: "application/json",
                dataType: "json",

                success: function (response) {
                    if (response.d != "") {
                        //alert(response.d.resultflag + response.resultflag);
                        var bar_data =
                        {
                            data: JSON.parse(response.d),
                        };
                        console.log(bar_data);

                        //Flag 1 Only Calculation 
                        if (bar_data.data.response != 0) {
                            //var wallamt = bar_data.data.balance;
                            //$("#ContentPlaceHolder1_reeamt").html(wallamt);

                            var reepasamt = document.getElementById('<%= punchamt.ClientID %>').value;
                            $("#ContentPlaceHolder1_lblredeem").html(reepasamt);
                            $("#btnredem").hide();
                            $("#cancel_redeemamount").show();
                            $('#ContentPlaceHolder1_lblshowmsgwallet').html(bar_data.data.ValidationMessage);
                            $("#ContentPlaceHolder1_punchamt").attr('disabled',true);
                            saveitem(1);
                        }

                        //Not Valid Amount  flag 0 No Data found
                        if (bar_data.data.response == 0) {
                            $("#ContentPlaceHolder1_punchamt").val('');
                            $("#divRedeem").hide();
                            $('#ContentPlaceHolder1_lblshowmsgwallet').html(bar_data.data.ValidationMessage);

                        }

                        //If Value Null to Hide Lable 
                       <%-- var valuenullcheck = document.getElementById('<%= punchamt.ClientID %>').value;
                        if (valuenullcheck == "0") {
                            $("#ContentPlaceHolder1_punchamt").val('');
                            $("#ContentPlaceHolder1_lblredeemtext").hide();

                        }--%>

                    }
                    else {
                        alert("Error");
                    }
                },
                failure: function (response) {
                    alert("err");
                }
            });
        }



        //CustomerId, PaidAmount, AddressId, Quantity, buywith, discountamount, Redeemeamount, couponCode

        function Placeorder() {
            $('#spinner').show();
            $("#divMainloaderplace").attr("display", "block");
            $("#btnplaceorder").attr("disabled", true);
            var CustId = $("#ContentPlaceHolder1_lblCustid").html();
            var PaidAmt = $("#ContentPlaceHolder1_lbltotpayamt").html();
            var Qty = $("#ContentPlaceHolder1_txtqty").val();
            //var disct = $("#ContentPlaceHolder1_lbltotofferprice").html();
            var redeemamount = $("#ContentPlaceHolder1_lblredeem").html();
            var addrid = $("#ContentPlaceHolder1_lbladdrid").html();
            var refcode = $("#ContentPlaceHolder1_lblccode").html();
            var buyflag = $("#ContentPlaceHolder1_lblbuyflag").html();
            var shipcharge = $("#ContentPlaceHolder1_lbltotshipping").html();
            var Ccode = 0;
            //var totalamount = PaidAmt;totwtshipping
            var totalamount = $("#ContentPlaceHolder1_totwtshipping").html();
            var PromoAmount = $("#spnpromo").html();
            var Discount = $("#spndiscount").html();
            var PromoCode = $("#promocode").val();
            var addrBtntxt = $("#ContentPlaceHolder1_spnAddrbtn").html();
            var reorderid = getUrlVars()["orderid"];
            if (reorderid == undefined || reorderid == "undefined") {
                reorderid = "0";
            }
            var pstatus = $("#ContentPlaceHolder1_productstatus").val();

            if (pstatus == "true" || pstatus == true) {
                alert("Please remove the items from the list which are marked as not serviceable, out of stock or offer expired.");
                $('#spinner').hide();
                $("#btnplaceorder").attr("disabled", false);
                return;
            }
            if (addrBtntxt == "Select Address") {
                alert("Please select address.");
                $('#spinner').hide();
                $("#btnplaceorder").attr("disabled", false);
                return;
            }

            if (PaidAmt == "0" || PaidAmt == "0.0" || PaidAmt == "0.00") {
                $.ajax({
                    type: "POST",
                    url: "OrderSummery.aspx/PlaceOrderAmtZero",
                    data: '{CustId:"' + CustId + '",PayAmt:"' + PaidAmt + '",addr:"' + addrid + '",qty:"' + Qty + '",buyflag:"' + buyflag + '",disc:"' + disct + '",redm:"' + redeemamount + '",ccode:"' + Ccode + '",shipcharg:"' + shipcharge + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {
                        // alert(response.d)
                        if (response != "") {

                            var Resp =
                            {
                                data: JSON.parse(response.d),
                            };
                            if (Resp.data.resultflag == 1) {
                                $("#divMainloaderplace").attr("display", "none");
                                var Oid = Resp.data.OrderId;
                                //alert(Oid);
                                window.location = "final.aspx";
                            }
                            else {
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
            else {
                $.ajax({
                    type: "POST",
                    //url: "OrderSummery.aspx/CODPlaceOrder",
                    //data: '{CustId:"' + CustId + '",PayAmt:"' + PaidAmt + '",addr:"' + addrid + '",qty:"' + Qty + '",buyflag:"' + buyflag + '",disc:"' + disct + '",redm:"' + Redamt + '",ccode:"' + Ccode + '",shipcharg:"' + shipcharge + '",rcode:"' + refcode + '"}',
                    url: "OrderSummery.aspx/CODPlaceMultipleOrder",
                    data: JSON.stringify({ summeryModel: products, totalamount, redeemamount, PromoAmount, Discount, PaidAmt, PromoCode, reorderid }),
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {
                        //window.location = "final.aspx";
                        $('#spinner').hide();
                        window.location = "checkout.aspx";
                        // alert(response.d)
                        if (response != "") {

                            var Resp =
                            {
                                data: JSON.parse(response.d),
                            };
                            if (Resp.data.resultflag == 1) {
                                var Oid = Resp.data.OrderId;
                                //alert(Oid);

                            }
                            else {
                                alert("No Data Found ..");
                            }
                        }
                        else {
                            alert("Services Not Responding... ");
                        }
                    },
                    failure: function (response) {
                        $('#spinner').hide();
                        $("#btnplaceorder").attr("disabled", false);
                        alert("err");
                    }
                });
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

        function Applypromocode(promocode) {
            $("#divPromo").addClass('hide');
            if (promocode == 0) {
                var Promocode = $("#_discountcouponcode").val();
                if (Promocode == "" || Promocode == null) {
                    $("#_redeemerrmsg1").text("Please enter your coupon.");
                    $("#_redeemerrmsg1").removeClass("hide");
                    setTimeout(function () {
                        $("#_redeemerrmsg1").text("");
                        $("#_redeemerrmsg1").addClass("hide");
                    }, 5000)
                    return false;
                } else {
                    promocode = Promocode;
                }
            }

            var custid = $('#<%=lblCustid.ClientID%>').html();
            var payamt = $("#ContentPlaceHolder1_totwtshipping").html();
            $("#promocode").val(promocode);
                $.ajax({
                    type: "POST",
                    url: "OrderSummery.aspx/RedeemePromoCodeFromOrder",
                    data: '{promocode:"' + promocode + '",CustId:"' + custid + '",PayAmt:"' + payamt + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (response) {
                        $("#divPromo").addClass('hide');
                        $("#spnpromo").html('');
                        $("#divDiscount").addClass('hide');
                        $("#spndiscount").html('');
                        if (response.d != "") {
                            var bar_data =
                            {
                                data: JSON.parse(response.d),
                            };
                            console.log(bar_data);

                            //Flag 1 Only Calculation 
                            if (bar_data.data.response == 1) {
                                $("#cancelpromo").show();
                                $("#havepromo").hide();
                                if (bar_data.data.OfferName != "Discount") {
                                    $("#divPromo").removeClass('hide');
                                    $("#spnpromo").html(bar_data.data.PromoCodeCalcAmount);
                                    $('#myPromoCodeModal').hide();


                                    var ptotprice = $('#ContentPlaceHolder1_totwtshipping').html();
         

                                    var discount = $("#spndiscount").html();
                                    if (discount == "") {
                                        discount = "0";
                                    }
                                    discount = Number(discount);

                                    var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                                    if (reedam == "") {
                                        reedam = "0";
                                    }
                                    reedam = Number(reedam);

                                    ptotprice = Number(ptotprice);
                                 
                                    
                                    var finalprice = ptotprice - (discount + reedam);
                                    finalprice = finalprice.toFixed(2);
                                    var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
                                    objpay.innerHTML = finalprice;

                                    document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;

                                } else {
                                     $("#divDiscount").removeClass('hide');
                                    $("#spndiscount").html(bar_data.data.PromoCodeCalcAmount);
                                    $('#myPromoCodeModal').hide();
                                    var ptotprice = $('#ContentPlaceHolder1_totwtshipping').html();
         

                                    var discount = $("#spndiscount").html();
                                     if (discount == "") {
                                        discount = "0";
                                    }
                                    discount = Number(discount);

                                    var reedam = $('#ContentPlaceHolder1_lblredeem').html();
                                    if (reedam == "") {
                                        reedam = "0";
                                    }
                                    reedam = Number(reedam);

                                    ptotprice = Number(ptotprice);
                                   
                                    
                                    var finalprice = ptotprice - (discount + reedam);
                                    finalprice = finalprice.toFixed(2);
                                    var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
                                    objpay.innerHTML = finalprice;

                                    document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spntotDiscount.ClientID %>").innerHTML) + reedam + discount;
                                }
                                

                            }

                            //Not Valid Amount  flag 0 No Data found
                            if (bar_data.data.response == 0) {
                                $('#_redeemmsg1').text(bar_data.data.ValidationMessage);

                            }
                        }
                        else {
                            alert("Error");
                        }
                    },
                    failure: function (response) {
                        alert("err");
                    }
                });
            


           
        }

        function CancelPromo() {
            

            var ptotprice = $('#ContentPlaceHolder1_lbltotpayamt').html();
         

            var discount = $("#spndiscount").html();
            if (discount == "") {
                discount = "0";
            }
            discount = Number(discount);

            ptotprice = Number(ptotprice);
                                                                     
            var finalprice = ptotprice + discount;
            finalprice = finalprice.toFixed(2);
            var objpay = document.getElementById("<%= lbltotpayamt.ClientID %>");
            objpay.innerHTML = finalprice;

            document.getElementById("<%=spnsaving.ClientID %>").innerHTML = Number(document.getElementById("<%=spnsaving.ClientID %>").innerHTML) - discount;
            $("#cancelpromo").hide();
            $("#havepromo").show();
            $("#divDiscount").addClass('hide');
            $("#spndiscount").html('');
            $("#divPromo").addClass('hide');
            $("#spnpromo").html('');
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

        $("#Addrbtn").click(function () {
            var orderid = getUrlVars()["orderid"];
            if (orderid != undefined && orderid != "" && orderid != "undefined") {
                window.location = "checkout.aspx?orderid=" + orderid;
            } else {
                window.location = "checkout.aspx"
            }
        });

        function GetReedemableAmount(orderamount) {
            $.ajax({
                type: "POST",
                url: "OrderSummery.aspx/GetReedemableAmount",
                data: '{OrderAmount:"' + orderamount + '"}',
                contentType: "application/json;charset=utf-8",
                datatype: "json",
                success: function (ResponseData) {
                    if (ResponseData != null && ResponseData != undefined && ResponseData != "" && ResponseData.d != null && ResponseData.d != undefined && ResponseData.d != "" && ResponseData.d.response == "1") {
                        $('#ContentPlaceHolder1_reedemableAmount').val(ResponseData.d.RedeemableAmount);
                        $('#ContentPlaceHolder1_punchamt').val(ResponseData.d.RedeemableAmount);
                        $('#ContentPlaceHolder1_lblshowmsgwallet').hide();
                    }
                },
                failure: function (ResponseData) {
                    alert("Somthing Wrong");
                }
            });
        }

        function UpdateSessionCart() {
            console.log(products);
            $("#divMainloader").attr("display", "block");
            $("#cnfrm").attr("disabled", true);
            var sValue = '<%=HttpContext.Current.Session["PinCode"]%>';
            $.ajax({

                type: "POST",
                url: "Default.aspx/ConfirmOrder",
                data: JSON.stringify({ model: products, "WhatsAppNo": $("#btnsendMessage").text(), "PinCode": sValue }),
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
        
    </script>

</asp:Content>

