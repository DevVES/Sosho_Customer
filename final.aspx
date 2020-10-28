<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="final.aspx.cs" Inherits="final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #webscreen{
            display:block;
        }
          #webscreen:active{
            text-decoration:none;
        }
        #webscreen:hover{
            text-decoration:none;
            background:#fff;
            color:black;
        }
        #mobscreen{
            display:none;
        }
         #mobscreen:active{
             text-decoration:none;
         }
        #mobscreen:hover{
            text-decoration:none;
             background:#fff;
            color:black;
        }
        #mo-wa {
            display: none;
        }

        #web {
            display: block;
        }
        .wa-btn{
                width: 100%;
    background: #ffc107;
    border: 1px solid #ffc107;
    padding: 2px;
    color: #090909;
    text-transform: uppercase;
    font-weight:500;
      text-align:center;
      border-radius:2px;
        }
        .wa-btn i{
                margin-left: 6px;
    background: #1bd741;
    color: #fff;
    padding: 4px 7px 4px 6px;
    border-radius: 4px;
    font-size:18px;
  
        }
         table{
                margin-left:112px;
            }

        @media only screen and (max-device-width: 480px) {
            table{
                /*margin-left:55px;*/
                margin-left:0px;
            }
        }

        @media screen and (max-width: 767px) {
              #webscreen{
            display:none;
        }
        #mobscreen{
            display:block;
        }
            #mo-wa {
                display: block;
                margin-left: 18px;
            }

            #web {
                display: none;
            }
        }
    </style>
    <%--<div id="order-place">
        <div class="container">
            <div class="inner">
               
                <div class="order-method">
                    <i class="fa fa-check"></i>
                    <p class="message" style="margin:0">Order confirmed!</p>
                   
                    
                    <p class="number">Order Number: <span id="lblorderid" runat="server"></span></p>
                    
                    <p class="number">Product Name: <span runat="server" id="Span1"></span></p>
                    <p class="number">Units: <span id="Span2" runat="server"></span></p>
                  
                    <p class="method">Payment Method: <span id="paymentype" runat="server"></span></p>
                      <hr />
               <p class="addr" style="font-weight:600;font-size:14px;"><span id="lbladdridd" runat="server"></span></p>
                       <p class="addr" style="font-weight:600;font-size:14px;"><span id="lblmsg" runat="server"></span></p>
                    <a id="hdnWARedirectLink" href="" runat="server" target=""  />
                </div>
              
              

            
                  <div class="order-delivery-date">
                    <p id="lbldeliveryline" runat="server" style="color:#4caf50">Delivery in 1-2 working days</p>
                    <div style="display: none;">
                        <p class="code">
                            Offer Code:
                        <br />
                            <span></span>
                        </p>
                    </div>
                  </div>
                 <div id="lblwhatsapp" runat="server">
                
                 </div>
                <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
            </div>
        </div>
    </div>--%>



    <div id="orderdone" runat="server">
        <div id="order-place">
            <div class="container">
                <div class="inner">
                    <%--<div class="order-method">
                    <i class="fa fa-check"></i>
                    <p class="message" style="margin:0">Order confirmed!</p>
                   
                    <div style="display:flex"><p class="number" style="width:50%;text-align: right;">Order Number: </p><span style="width:50%;text-align: left;margin-left: 7px;margin-top:3px" id="lblorderid" runat="server">705786</span></div>

                     <div style="display:flex"><p class="number" style="width:50%;text-align: right;">Product Name: </p><span style="width:50%;text-align: left;margin-left: 7px;margin-top:3px" id="Span3" runat="server">Bikaji Rasgulla</span></div>
                     <div style="display:flex"><p class="number" style="width:50%;text-align: right;">Units: </p><span style="width:50%;text-align: left;margin-left: 7px;margin-top:3px" id="Span4" runat="server">50 - grm</span></div>
                     <div style="display:flex"><p class="number" style="width:50%;text-align: right;">Payment Method: </p><span style="width:50%;text-align: left;margin-left: 7px;margin-top:3px" id="Span5" runat="server">COD</span></div>
                    <p class="number">Product Name: <span runat="server" id="Span1">Bikaji Rasgulla</span></p>
                    <p class="number">Units: <span id="Span2" runat="server">50 gm</span></p>
                    <hr />
                    <p class="method">Payment Method: <span id="paymentype" runat="server">ICICI Bank, Credit Card</span></p>
                     <p class="addr"><span id="lbladdridd" runat="server">257, shaktinath G.H.B Bharuch-392001</span></p>
                </div>--%>
                    <div class="order-method">
                        <i class="fa fa-check"></i>
                        <p class="message" style="margin: 0">Order confirmed!</p>


                        <p class="number">Order Number: <span id="lblorderid" runat="server"></span></p>
                       <asp:Label ID="lblWhatsAppNo" runat="server" CssClass="hide"></asp:Label>
                        <%--<p class="number">Product Name: <span runat="server" id="Span1"></span></p>
                        <p class="number">Units: <span id="Span2" runat="server"></span></p>--%>
                        <div id="details" runat="server">
                        <table style="margin-left: 112px;">
                            <thead>
                                <th class="number" style="padding: 6px;text-align:center;width:100%;">Product Name </th>
                                <th class="number" style="padding: 6px;">Unit </th>
                            </thead>
                            <tbody>
                            <tr>
                                <td class="number">Gulab Groundnut oil</td>
                                <td class="number">4</td>
                            </tr>
                            <tr>
                                <td class="number">Everyuth FaceWash Combo</td>
                                <td class="number">2</td>
                            </tr>
                            <tr>
                                <td class="number">Nycil Summer Powder</td>
                                <td class="number">1</td>
                            </tr>
                                </tbody>
                        </table>
                      </div>

                        <p class="method">Payment Method: <span style="color:#1da1f2" id="paymentype" runat="server"></span></p>
                        <hr />
                        <p class="addr" style="font-weight: 600; font-size: 14px;"><span id="lbladdridd" runat="server"></span></p>
                        <%--<p class="addr" style="font-weight: 600; font-size: 14px;"><span id="lblmsg" runat="server"></span></p>--%>
                    </div>



                    <%-- <div id="lblwhatsapp" runat="server">
                    <div class="order-offer-code">
                        <p class="">
                            Share Offer Code with : 
                            

                            <a target="_blank" href="https://web.whatsapp.com/send?text=Hey use ny code and get discount on product name http://www.salebhai.in/?offercode-4148" data-action="share/whatsapp/share">
                                <img id="web" src="images/whatsapp.png" style="width:10%" /></a>

                            

                            <a target="_blank" href="whatsapp://send?text=Hey use ny code and get discount on product name http://www.salebhai.in/?offercode-4148">
                                <img id="mo-wa" src="images/whatsapp.png" style="width:10%" /></a>
                        </p>

                    </div>
                </div>--%>
                    <div class="order-delivery-date">
                        <p id="lbldeliveryline" runat="server" style="color: #4caf50"><b>Delivery in 1-2 working days </b></p>
                        <p class="addr" style="font-weight: 600; font-size: 14px;"><span id="lblmsg" runat="server">Share this offer with your friends now</span></p>
                        <div style="display: none;">
                            <p class="code">
                                Offer Code:
                    <br />
                                <span></span>
                            </p>
                        </div>
                    </div>

                   <div id="lblwhatsapp" runat="server">
                          <a href="#" id="vg" class="wa-btn">Share on whatsapp <i class="fa fa-whatsapp"></i></a>
                    </div>
                    <br />
                    <div id="walletandpromo" runat="server">
                      <%--  <table style="margin-left: 47px; width:90%" >
                            <tbody>
                            <tr>
                                <td style="font-size:16px">Wallet Redeem Amount:</td>
                                <td style="font-size:16px">50.00</td>
                            </tr>
                            <tr>
                                <td style="font-size:16px">Promo Code</td>
                                <td style="font-size:16px">FLAT 50</td>
                            </tr>
                            <tr>
                                <td style="font-size:16px">PromoCode Discount:</td>
                                <td style="font-size:16px">100.00</td>
                            </tr>
                                </tbody>
                        </table>--%>
                      </div>
                    <br />
                    <div style="text-align: center;">
                        <a id="home" class="btn btn-primary" href="/Default.aspx" style="margin-left: 18px;background: rgb(29, 161, 242); border-color: rgb(29, 161, 242);">Home</a>
                         <a id="orderdetails" class="btn btn-primary" href="javascript:void(0)" style="margin-left: 18px;background: rgb(29, 161, 242); border-color: rgb(29, 161, 242);">Order Details</a>

                    </div>

                    <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
                </div>

            </div>
        </div>
    </div>
    <div id="ordernotdon" visible="false" runat="server">
        <div id="order-place">
            <div class="container">
                <div class="inner">

                    <div class="order-method">
                        <i class="fa fa-times danger"></i>
                        <p class="message" style="margin: 0">Order Failed</p>
                        <p class="message" style="margin: 0">Something went wrong please try after sometime</p>
                        <p class="message" style="margin: 0">Thank You!</p>
                        <%--  <p class="number">Order Number: <span id="Span3" runat="server"></span></p>

                        <p class="number">Product Name: <span runat="server" id="Span4"></span></p>
                        <p class="number">Units: <span id="Span5" runat="server"></span></p>

                        <p class="method">Payment Method: <span id="Span6" runat="server"></span></p>
                        <hr />
                        <p class="addr" style="font-weight: 600; font-size: 14px;"><span id="Span7" runat="server"></span></p>
                        <p class="addr" style="font-weight: 600; font-size: 14px;"><span id="Span8" runat="server"></span></p>--%>
                    </div>




                    <%-- <div class="order-delivery-date">
                        <p id="P1" runat="server" style="color: #4caf50">Delivery in 1-2 working days</p>
                        <div style="display: none;">
                            <p class="code">
                                Offer Code:
                    <br />
                                <span></span>
                            </p>
                        </div>
                    </div>

                    <div id="Div2" runat="server">
                       
                    </div>

                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
                </div>

            </div>
        </div>
    </div>
        <div id="MyPopup" class="modal fade" role="dialog" style="display: block;position: relative;">
                            <div class="modal-dialog modal-mg">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header" style="background-color:whitesmoke">
                                        <button type="button" class="close" data-dismiss="modal">
                                            &times;</button>
                                        <h4 class="modal-title">Final Step</h4>
                                    </div>
                                    <div class="modal-body">
                                        <!-- Advance Filter-->
                                        <div class="row">
                                            <div class="col-md-12" style="text-align:center">
                                               <%--  <p><b>Your Order will Delivered on 3rd September to 7th September</b></p>--%>
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                                               
                                               <div id="whatsapp2" runat="server">
                                            
                                              </div>
                                                  
                                                   
                                            </div>
                                            </div>
                                     
                                        <!-- Advance Filter-->
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" style="background-color:red!important" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
    <script>
            var fbButton = document.getElementById('fb-share-button');
            var url = window.location.host;

            fbButton.addEventListener('click', function () {
                window.open('https://www.facebook.com/sharer/sharer.php?u=' + url,
                    'facebook-share-dialog',
                    'width=800,height=600'
                );
                return false;
            });
        </script>

     <script>
         $(document).ready(function () {

             
             $('.offer-time').css('display', 'none');
             $("#btnsendMessage").text($('#ContentPlaceHolder1_lblWhatsAppNo').text());
             window.setTimeout(function () {

                 if ($('#webscreen').css('display') == "block") {
                     $('#webscreen').get(0).click()

                 }
                 else if ($('#mobscreen').css('display') == "block") {
                     //$('#mobscreen').get(0).click()
                    ;
                     //location.href = "'" + $("#ContentPlaceHolder1_hdnWARedirectLink").val() + "'";
                     $("#ContentPlaceHolder1_hdnWARedirectLink").get(0).click();
                 }


                 //$('#whts').get(0).click();

             }, 10000);

         });

         $("#orderdetails").click(function () {
             window.location.href = 'order_details.aspx?Orderid=' + '<%=Session["PlaceOrderId"].ToString()%>';
         });
</script>



    <script type="text/javascript">



        function ShowPopup(title) {
            $("#MyPopup .modal-title").html(title);

            $("#MyPopup").modal("show");
        }
</script>
 
    <script>
        function decorateWhatsAppLink() {
            //set up the url
            var url = 'whatsapp://send?text=';

            //define the message text
            var text = 'Check out this awesome product I found on SaleBhai.in! http://salebhai.in';

            //encode the text
            var encodedText = encodeURIComponent(text);

            //find the link
            var $whatsApp = $('.whatsappf a');

            //set the href attribute on the link
            $whatsApp.attr('href', url + encodedText);
        }

        //call the decorator function
        decorateWhatsAppLink()
    </script>




    <%-- <script>
        $(document).ready(function () {
                window.setTimeout(function () {

                    if ($('#webscreen').css('display') == "block")
                    {
                        $('#webscreen').get(0).click();
                       // alert("D clicked");
                    }
                    else // if ($('#mobscreen').css('display') == "block")
                    {
                       // window.open('', '_blank');
                        $('#mobscreen').get(0).click();
                    }
                    //$('#whts').get(0).click();
                }, 5000);
        });
</script>--%>



   <%-- <script type="text/javascript">



        function ShowPopup(title) {
            $("#MyPopup .modal-title").html(title);
            
            $("#MyPopup").modal("show");
        }
</script>
 
    <script>
        function decorateWhatsAppLink() {
            //set up the url
            var url = 'whatsapp://send?text=';

            //define the message text
            var text = 'Check out this awesome product I found on SaleBhai.in! http://salebhai.in';

            //encode the text
            var encodedText = encodeURIComponent(text);

            //find the link
            var $whatsApp = $('.whatsappf a');

            //set the href attribute on the link
            $whatsApp.attr('href', url + encodedText);
        }

        //call the decorator function
        decorateWhatsAppLink()
    </script>--%>
</asp:Content>

