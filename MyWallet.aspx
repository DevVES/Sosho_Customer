<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyWallet.aspx.cs" Inherits="MyWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div id="wallet">
        <div class="container">       
            <div class="row">
            <h3>My Wallet</h3>
        </div>
        <div class="row">
            <div class="main">
                <div>
                    <p><strong>Money in your wallet</strong></p>
                    <hr />
                </div>
        <table class="table table-bordered">
    <thead>
      <tr>
        <th>Used Balance</th>
        <th>Available Balance</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td id="lblusedbal" runat="server"></td>
        <td id="lblavlbal" runat="server"> </td>
      </tr>
     
    </tbody>
  </table>
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
          $('.offer-time').css('display','none');
      });
    </script>
</asp:Content>
