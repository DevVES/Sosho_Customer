<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="verify.aspx.cs" Inherits="verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrapper">
        <div class="container">
            <div id="dialog">
                    <div class="row">
                        <div class="title">
                            <h3>Mobile Number Verification</h3></div>
                          </div>
               <div class="row">
                <div class="inner">
                    <h3>Please enter the 6-digit verification code sent via SMS to </h3>
                   <%-- <span>we have send an otp on your number</span>--%>
                    <div class="mobile-no">
                        <span>+91 <%= ( Request.QueryString["m"]!=null? clsCommon.Base64Decode(Request.QueryString["m"]):"") %></span>
                        <p class="change"><a href="register.aspx">change</a></p>
                    </div>
                     <div style="display:none">
                            <asp:Label ID="lblflag" runat="server"></asp:Label>
                            <asp:Label ID="lblqty" runat="server"></asp:Label>

                        </div>
                    <div id="form">
                        <input id="otp" runat="server" onkeyup="Checkit()" onpaste="Checkit()" maxlength="6"   autocomplete="off" onkeypress="return isNumber(event)" />
                        <%--      <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />
                                  <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />
                                  <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />
                                  <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />
                                  <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />
                                  <input type="text" maxlength="1" size="1" min="0" max="9" pattern="[0-9]{1}" />--%>
                    </div>
                    <asp:Button ID="verifybtn" runat="server" OnClick="verifybtn_Click" CssClass="btn verify-btn btn-embossed" Text="verify" />

                    <div class="resend">
                        Didn't receive the code?<br />
                        <%--   resend otp?--%>
                    </div>
                    <div id="counting"></div>
                    <%--<button type="button" id="mybtn" class="resend-btn" onclick="alert('finally!')">Resend OTP</button>--%>
                  <%--  <asp:button id="resendbtn" runat="server" OnClick="resendbtn_Click" cssclass="btn resend-btn btn-embossed" text="resend otp"  />--%>

                     <asp:Button ID="resendbtn" CssClass="resend-btn" runat="server" Text="Resend OTP" Enabled="false" OnClick="resendbtn_Click" />

                    <div class="resend-sec">
                        Resend OTP after 120 Seconds
                    </div>
                </div>
                   </div>
            </div>
        </div>
    </div>






    <%--    <script>
        var max_chars = 6;
        $('#otp').keydown(function (e) {
            if ($(this).val().length >= max_chars) {
                $(this).val($(this).val().substr(0, max_chars));
            }
        });
    </script>--%>

    <script>
        function Checkit() {
            var count = $("#ContentPlaceHolder1_otp").val().length;
            var chang = ""
            $('#otp').removeAttr('if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g');
            //$("span").text(i += 1);
            if (count == 6) {
                $('#ContentPlaceHolder1_verifybtn').removeAttr('disabled');
                //$('#ContentPlaceHolder1_verifybtn').attr('disabled', false);
                //$('#ContentPlaceHolder1_verifybtn').prop('disabled', false);
            }
           

            
            else {
                
                $('#ContentPlaceHolder1_verifybtn').attr("disabled", true);
                //$('#ContentPlaceHolder1_verifybtn').attr('disabled', true);
                //$('#ContentPlaceHolder1_verifybtn').prop('disabled', true);
            }
        }



       
        function isNumber(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            var keyCode = key;
            key = String.fromCharCode(key);
            if (key.length == 0) return;
            var regex = /^[0-9.\b]+$/;
            if (keyCode == 188 || keyCode == 190) {
                return;
            } else {
                if (!regex.test(key)) {
                    theEvent.returnValue = false;
                    if (theEvent.preventDefault) theEvent.preventDefault();
                }
            }
        }

        //$('#ContentPlaceHolder1_otp').keypress(function () {
        //    //var thetext = $(this).val();
        //    var count = $("#ContentPlaceHolder1_otp").val().length;
        //    count++;
        //    //$("span").text(i += 1);
        //    if (count == 6)
        //    {
        //        $('#ContentPlaceHolder1_verifybtn').removeAttr('disabled');
        //        //$('#ContentPlaceHolder1_verifybtn').attr('disabled', false);
        //        //$('#ContentPlaceHolder1_verifybtn').prop('disabled', false);
        //    }
        //    else {
        //        $('#ContentPlaceHolder1_verifybtn').removeAttr('Enabled');
        //        //$('#ContentPlaceHolder1_verifybtn').attr('disabled', true);
        //        //$('#ContentPlaceHolder1_verifybtn').prop('disabled', true);
        //    }
        //})
    </script>

    <%--  <script>
            var otp = document.getElementById('otp');
            i = 0;
            function click() {
                $("otp").text(i += 1);
            }
        </script>--%>

    <script>
        var sec = 120;
        var mytimer = document.getElementById('counting');
        var mybtn = document.getElementById('resendbtn');
        window.onload = countdown;

        function countdown() {
            if (sec < 10) {
                mytimer.innerHTML = "0" + sec;
            } else {
                mytimer.innerHTML = sec;
            }
            if (sec < 0) {
                $("#ContentPlaceHolder1_mybtn").removeAttr("disabled");
                $("#ContentPlaceHolder1_mybtn").removeClass("resend-btn").addClass("resend-btnEnable");
                $("#ContentPlaceHolder1_counting").fadeTo(2500, 0);
              //  mybtn.innerHTML = "click me!";
                return;
            }
         
          
            if (sec == 0)
            {
                $('#ContentPlaceHolder1_resendbtn').removeAttr('disabled');
                $("#ContentPlaceHolder1_resendbtn").removeClass("resend-btn").addClass("resend-btnEnable");
                mytimer.innerText = "OTP timeout. Please hit resend";
                return;
                
            }
            else
            {
                sec -= 1;

                window.setTimeout(countdown, 1000);

            }
            return;
        }
   
         $(document).ready(function () {

             //const urlParams1 = new URLSearchParams(window.location.search);

             //if (urlParams1 != null && urlParams1 != "")
             //{
             lbllogout.innerHTML = "";
             //}
             $(".mobile-number").hide();
             $('.offer-time').css('display', 'none');
         });
        </script>
     
    <%-- <script>
        $(function () {
            'use strict';

            var body = $('body');

            function gotonextinput(e) {
                var key = e.which,
                  t = $(e.target),
                  sib = t.next('input');

                if (key != 9 && (key < 48 || key > 57)) {
                    e.preventdefault();
                    return false;
                }

                if (key === 9) {
                    return true;
                }

                if (!sib || !sib.length) {
                    sib = body.find('input').eq(0);
                }
                sib.select().focus();
            }

            function onkeydown(e) {
                var key = e.which;

                if (key === 9 || (key >= 48 && key <= 57)) {
                    return true;
                }

                e.preventdefault();
                return false;
            }

            function onfocus(e) {
                $(e.target).select();
            }

            body.on('keyup', 'input', gotonextinput);
            body.on('keydown', 'input', onkeydown);
            body.on('click', 'input', onfocus);

        })
    </script>--%>

</asp:Content>
