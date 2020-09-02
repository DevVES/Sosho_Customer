<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="my-order">
  <div class="container">
            <div class="row">
               <%-- <p>My Account > <a href="">My Orders</a></p>--%>
                <h2>Order Summary</h2>
                <p class="months">Last 6 Months Orders</p>
            </div>
           

         <div id="orderlistDetails" runat="server">

        <div class="row">
                <div class="order-list">
                    <ul>
                        <li>
                            <div class="inner">
                                <div class="orderid left">
                                    <p><strong>374521</strong></p>
                                </div>
                                <div class="left olist-date">
                                    <p>Saturday, December 25,2012</p>
                                </div>
                                <div class="amount right">
                                    <p>Order Total:<span>450</span></p>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td>
                                    <div class="left olist-img">
                                        <a href="">
                                            <img src="images/Prayankee give me_02-19-19/0000473_bhagat-halwai-doda-burfi.jpeg" /></a>
                                    </div>
                                    <div class="left olist-name">
                                        <p>Sukhadia Garbaddas Bapuji Dryfruit Bites</p>
                                        
                                    </div>
                                    <div class="right">
                                        <div class="details">
                                            <a href="order_details.aspx">
                                                <p>View Details</p>
                                            </a>
                                            <p class="share">Share on</p>
                                           <div class="social-links-myorder">
                                               <%-- <span class="whatsapp"><a class="fa fa-whatsapp" href="" target="_blank" style="cursor:pointer;font-size: 14px;background: #25D366;color: #fff;padding: 4px;border-radius: 4px;"></a></span>
                                                <span id="fb-share-button"><i class="fa fa-facebook" style="cursor:pointer;font-size: 14px;background: #3b5998;padding: 4px;margin-right: 0px;color: #fff;border-radius: 4px;"></i></span>
                                                <span id="ins"><i class="fa fa-instagram" style="cursor:pointer;font-size: 14px;background: #c13584;padding: 4px;border-radius: 4px;color: #fff;"></i></span>--%>
                                                <%--<img class="space" src="images/whatsapp.png" />
                                                <img class="space" src="images/instagram.png" />--%>
                                          </div>
                                        </div>
                                    </div>
                                </td>
                             </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        <div class="row">
                <div class="order-list">
                    <ul>
                        <li>
                            <div class="inner">
                                <div class="orderid left">
                                    <p><strong>374521</strong></p>
                                </div>
                                <div class="left olist-date">
                                    <p>Saturday, December 25,2012</p>
                                </div>
                                <div class="amount right">
                                    <p>Order Total:<span>450</span></p>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td>
                                    <div class="left olist-img">
                                        <a href="">
                                            <img src="images/Prayankee give me_02-19-19/0000473_bhagat-halwai-doda-burfi.jpeg" /></a>
                                    </div>
                                    <div class="left olist-name">
                                        <p>Sukhadia Garbaddas Bapuji Dryfruit Bites</p>
                                       
                                    </div>
                                    <div class="right">
                                        <div class="details">
                                            <a href="order_details.aspx">
                                                <p>View Details</p>
                                            </a>
                                            <%--<asp:Button ID="Button2" CssClass="olist-share-btn" runat="server" Text="SHARE" />--%>
                                            <div>
                                                 <p class="olist-expired">Expired on HH:MM:SS</p>
                                            </div>
                                        </div>
                                    </div>
                                </td>

                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        <div class="row">
                <div class="order-list">
                    <ul>
                        <li>
                            <div class="inner">
                                <div class="orderid left">
                                    <p><strong>374521</strong></p>
                                </div>
                                <div class="left olist-date">
                                    <p>Saturday, December 25,2012</p>
                                </div>
                                <div class="amount right">
                                    <p>Order Total:<span>450</span></p>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td>
                                    <div class="left olist-img">
                                        <a href="">
                                            <img src="images/Prayankee give me_02-19-19/0000473_bhagat-halwai-doda-burfi.jpeg" /></a>
                                    </div>
                                    <div class="left olist-name">
                                        <p>Sukhadia Garbaddas Bapuji Dryfruit Bites</p>
                                       
                                    </div>
                                    <div class="right">
                                        <div class="details">
                                            <a href="order_details.aspx">
                                                <p>View Details</p>
                                            </a>
                                            <%--<asp:Button ID="Button2" CssClass="olist-share-btn" runat="server" Text="SHARE" />--%>
                                            <div>
                                                 <p class="olist-expired">Expired on HH:MM:SS</p>
                                            </div>
                                        </div>
                                    </div>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        <div class="row">
                <div class="order-list">
                    <ul>
                        <li>
                            <div class="inner">
                                <div class="orderid left">
                                    <p><strong>374521</strong></p>
                                </div>
                                <div class="left olist-date">
                                    <p>Saturday, December 25,2012</p>
                                </div>
                                <div class="amount right">
                                    <p>Order Total:<span>450</span></p>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td>
                                    <div class="left olist-img">
                                        <a href="">
                                            <img src="images/Prayankee give me_02-19-19/0000473_bhagat-halwai-doda-burfi.jpeg" /></a>
                                    </div>
                                    <div class="left olist-name">
                                        <p>Sukhadia Garbaddas Bapuji Dryfruit Bites</p>
                                        
                                    </div>
                                    <div class="right">
                                        <div class="details">
                                            <a href="order_details.aspx">
                                                <p>View Details</p>
                                            </a>
                                            <p class="share">Share on</p>
                                           <div>
                                             <a href=""><img src="images/facebook.png" /></a>
                                                <a href=""><img src="images/instagram.png" /></a>
                                                <a href=""><img src="images/whatsapp.png" /></a>
                                               </div>
                                        </div>
                                    </div>
                                </td>

                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>

         </div>

        </div>
 </div>
     <script>
            var fbButton = document.getElementById('fb-share-button');
            var url = window.location.href;

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
              });
              function decorateWhatsAppLink() {
                  //set up the url
                  var url = 'whatsapp://send?text=';

                  //define the message text
                  var text = 'Check out this awesome product I found on SaleBhai.in! http://salebhai.in';

                  //encode the text
                  var encodedText = encodeURIComponent(text);

                  //find the link
                  var $whatsApp = $('.whatsapp a');

                  //set the href attribute on the link
                  $whatsApp.attr('href', url + encodedText);
              }

              //call the decorator function
              decorateWhatsAppLink()
    </script>
</asp:Content>

