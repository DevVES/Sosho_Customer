<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Payment.aspx.cs" Inherits="Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="payment-gateway">
        <div class="container content-box">
            <div class="row">
                <div class="title">
                <h3>Payment Options</h3>
                    </div>
            </div>
        <div class="row inner">
                     <div class="padding">
                    <div class="col-md-3 payment_method padding0 zindex padding left-section">
                        <ul class="nav nav-tabs tabs-left inline-grid">
                            <li class="active"><a href="#wallet" data-toggle="tab">Wallets</a></li>
                            <li><a href="#netbanking" data-toggle="tab">Cards / Net Banking</a></li>
                            
                            <li><a href="#cod" data-toggle="tab">Cash on delivery</a></li>
                        </ul>
                    </div>
                    <div class="col-md-9 padding">
                        <div class="opc_pay_amount_strip">
                            Payable Amount: <strong style="color: #bf3a06;">Rs. <asp:Literal ID="trnamount" runat="server"></asp:Literal> /-</strong>
                        </div>

                        <div class="tab-content right-section">
                            <div id="wallet" class="tab-pane active">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="text-center wallets">
                                        <asp:ImageButton ID="MobikwikButton" runat="server" ImageUrl="https://www.salebhai.com/Themes/salebhai/images/wallet/Net-Banking-payment-Logo_3.png" OnClick="MobikwikButton_Click" />
                                    <p>Pay by Mobikwik</p>
                                           <%-- <span>More than a Wallet</span>--%>
                                        </div>
                                        </div>
                                    <div class="col-md-6">
                                        <div class="text-center wallets">
                                        <asp:ImageButton ID="PaytmButton" runat="server" ImageUrl="https://www.salebhai.com/Themes/salebhai/images/wallet/Net-Banking-payment-Logo_2.png" OnClick="PaytmButton_Click" />
                                     <p>Pay by Paytm</p>
                                        </div>
                                        </div>
                                    </div>
                                       <div class="col-md-12">
                                   <div class="col-md-6">
                                               <div class="text-center wallets">
                                        <asp:ImageButton ID="FreechargeButton" runat="server" ImageUrl="https://www.salebhai.com/Themes/salebhai/images/wallet/Net-Banking-payment-Logo_4.png" OnClick="FreechargeButton_Click" />
                                          <p>Pay by Freecharge</p>
                                               </div>
                                       </div>
                                     <div class="col-md-6">
                                         <div class="text-center wallets">
                                         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://www.salebhai.com/Themes/salebhai/images/wallet/Net-Banking-payment-Logo_6.png" OnClick="AmazonPayButton_Click"/>
                                          <p>Pay by Amazon Pay</p>
                                         </div>
                                         </div>
                                    </div>
                                </div>
                            <div id="netbanking" class="tab-pane text-center">
                               
                                <div class="text-center margin20 margin6">  <asp:Button class="btn btn-primary net-banking" id="billdeskbtn" runat="server" Text="PROCEED TO PAYMENT" OnClick="billdeskbtn_Click" /></div>
                           
                            </div>
                            
                              <div id="cod" class="tab-pane">
                             
                          <div class="text-center margin20 margin6">  <asp:Button class="btn btn-primary net-banking" id="Button2" runat="server" Text="PROCEED TO PAYMENT" OnClick="billdeskbtn_Click" /></div>
                            </div>
                            </div>
                        </div>
                    </div>
           
            </div>

        </div>

</div>
</asp:Content>