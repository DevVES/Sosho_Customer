<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyWallet.aspx.cs" Inherits="MyWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wallet">
        <div class="container">
            <div class="row">
                <h3>My Wallet</h3>
            </div>
            <div class="row">
                <div class="main">
                    <div>
                        <p><strong>Available Balance</strong><strong class="pull-right">₹ <span id="walletbal" runat="server">0.00</span></strong></p>
                        <%--<p><strong>Money in your wallet</strong></p>--%>
                        <hr />
                    </div>
                    <%-- <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Used Balance</th>
                                <th>Available Balance</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td id="lblusedbal" runat="server"></td>
                                <td id="lblavlbal" runat="server"></td>
                            </tr>

                        </tbody>
                    </table>--%>
                    <div class="list-group" runat="server" id="wallethistory">
                        <a href="#" class="list-group-item">
                            <h5 class="list-group-item-heading" >Black Friday Sale Booster <span class="pull-right" style="color:green">+₹ 50.00</span></h5>
                            <p class="list-group-item-text">10/09/2020 11:24:13 PM <span class="pull-right">Closing Balance:₹ 150.00 </span></p>
                        </a>
                    </div>
                </div>
            </div>

            <%--    <div>
                <p>Name:<span>Pratixa Patel</span></p>
                <p>Home Town<span>Vadodara</span></p>
            </div>--%>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.offer-time').css('display', 'none');
        });
    </script>
</asp:Content>
