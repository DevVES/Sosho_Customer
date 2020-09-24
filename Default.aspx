<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/bootstrap-3.3.7.min.css" rel="stylesheet" />
    <link href="OwlCarousel/dist/assets/owl.carousel.css" rel="stylesheet" />
    <link href="OwlCarousel/dist/assets/owl.theme.default.min.css" rel="stylesheet" />
    <link href="css/CircularContentCarousel/style.css" rel="stylesheet" />
    <link href="css/CircularContentCarousel/jquery.jscrollpane.css" rel="stylesheet" />

    <style>
        #mo-wa {
            display: none;
        }

        #web {
            display: block;
        }

        /* Solid border */
        hr.solid {
            border-top: 3px solid #bbb;
        }

        .CategoryImagecenter {
            display: block;
            margin-left: auto;
            margin-right: auto;
            /*width: 50%;*/
            width: 104px;
            border-radius: 50%;
        }

        .CategoryText {
            font-family: 'Amazon Ember';
            color: #1A1A1A;
            font-size: 12px;
            font-weight: bold;
        }

        .BlueText {
            background: #1DA1F2;
            color: #FFFFFF;
            font-size: 16px;
            font-family: 'Amazon Ember'
        }

        .ProductImage {
            /*height: 400px;
            width: 400px;*/
            width: 69%;
        }

        .ProudctMRPText {
            font-family: 'Amazon Ember';
            font-size: 15px;
            width: 121px;
            /*padding-left: 27px;*/
            padding-left: 10px;
        }

        .ProductName {
            color: #1A1A1A;
            font-family: 'Amazon Ember';
            font-size: 22px;
            /*padding-left: 27px;*/
            padding-left: 10px;
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
            padding-left: 10px;
            font-weight: bold;
        }

        .SoshoColon {
            color: #1A1A1A;
            font-weight: bold;
        }

        .SoshoPriceValue {
            color: red;
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
            padding-left: 10px;
        }

        .ProductBtn {
            color: white;
            background-color: #1DA1F2;
        }

        .tableheader {
            width: 100%;
            /*position: relative;*/
            bottom: -6px;
            right: 166px;
        }

        .DiscountOffer {
            color: white;
            background-color: red;
            border-radius: 50px;
            padding: 15px;
            width: 77px;
            position: absolute;
            text-align: center;
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

        .BannerAddPostion {
            position: absolute;
            left: 85%;
            transform: translate(1%, -96%);
        }

        @media only screen and (max-width: 600px) {
            /* For mobile phones: */
            .ProductImage {
                height: 150px;
                width: 150px;
            }

            .tableheader {
                width: 100%;
                /*right: 7px;*/
            }

            .DiscountOffer {
                padding: 5px;
                width: 62px;
            }

            .ProductName {
                font-size: 14px;
                padding-left: 10px;
            }

            .ProudctMRPText {
                font-size: 14px;
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
                font-size: 13px;
            }

            .ProductDropDown {
                font-size: 12px;
            }

            .BtnAddText {
                font-size: 12px;
            }

            .WeightText {
                width: 72px;
            }

            .ProductCenter {
                text-align: -webkit-center;
            }

            .BannerAddPostion {
                left: 76%;
            }
        }
        /*@media screen and (max-width: 700px) {
           
            #mo-wa {
                display: block;
            }

            #web {
                display: none;
            }
        }*/
    </style>
    <%--<div class="row">
        <div class="offer-banner" id="divCategory">--%>
    <%-- <a href="#" id="link" runat="server">
                <img class="img" id="lbltopbanner" runat="server" src="" />
            </a>--%>
    <%--</div>
    </div>--%>


    <%-- <div style="float: left; width: 330px; height: 100%; text-align: center; left: 0px;">
        <img src="images/Testing/CategoryImage/chevodo.jpg" style="width: 127px;" />
        <h3>Chevodo</h3>
    </div>--%>
    <%--  <div id="ca-container" style="position: relative; margin: 25px auto 20px auto; width: 990px; height: 450px;">
        <div style="width:25px;height:38px;background: transparent url(../images/arrows.png) no-repeat top left;position:absolute;top:50%;margin-top:-19px;left:-40px;text-indent:-9000px;opacity:0.7;cursor:pointer;z-index:100;">
            <span>Previous</span>
            <span style="width:25px;height:38px;background: transparent url(../images/arrows.png) no-repeat top left;position:absolute;top:50%;margin-top:-19px;left:-40px;text-indent:-9000px;opacity:0.7;cursor:pointer;z-index:100;background-position:top right;left:auto;right:-40px;">Next</span>
        </div>
        <div style="width: 100%; height: 100%; position: relative; overflow: hidden;">
            <div style="float: left; width: 130px; height: 100%; text-align: center; left: 0px;">
                <img src="images/Testing/CategoryImage/274148_11-fortune-sunflower-refined-oil.jpg" style="width: 97px;" />
                <h3>sunflower-refined-oil</h3>
            </div>
            <div style="float: left; width: 130px; height: 100%; text-align: center; left: 0px;">
                <img src="images/Testing/CategoryImage/284420_7-aashirvaad-multigrains-atta.jpg" style="width: 97px;" />
                <h3>Atta & Flour</h3>
            </div>
            <div style="float: left; width: 130px; height: 100%; text-align: center; left: 0px;">
                <img src="images/Testing/CategoryImage/40052455_2-wagh-bakri-dust-tea.jpg" style="width: 97px;" />
                <h3>Tea & Coffee</h3>
            </div>
            <div style="float: left; width: 130px; height: 100%; text-align: center; left: 0px;">
                <img src="images/Testing/CategoryImage/100004121_2-everest-powder-tikhalal-chilli.jpg" style="width: 97px;" />
                <h3>Chilli</h3>
            </div>
            <div style="float: left; width: 130px; height: 100%; text-align: center; left: 0px;">
                <img src="images/Testing/CategoryImage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;" />
                <h3>Ratlami Sev</h3>
            </div>
        </div>

    </div>--%>

    <%--<div id="ca-container" class="ca-new-container">
        <div class="ca-nav">
            <span class="ca-nav-prev" style="background: transparent url(../images/arrows.png) no-repeat top left;">previous</span>
            <span class="ca-nav-next" style="background: transparent url(../images/arrows.png) no-repeat top left; background-position:top right;">next</span>
        </div>
        <div class="ca-wrapper" style="overflow:hidden;">
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/40003735_9-amul-dark-chocolate-55-rich-in-cocoa.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">chocolates & candies</span>  
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/295519_11-glucon-d-instant-energy-health-drink-nimbu-pani-refill.jpg" style="width: 97px;border-radius:50%;" />
                    <span>testing 2</span>
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">health drink, supplement</span>  
                </div>
            </div>

            <div class="ca-item" style="left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/40052455_2-wagh-bakri-dust-tea.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">tea & coffee</span>  
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100004121_2-everest-powder-tikhalal-chilli.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">masalas & spices</span>  
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/274148_11-fortune-sunflower-refined-oil.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">edible oils & ghee</span>  
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/284420_7-aashirvaad-multigrains-atta.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">atta, flours & sooji</span>  
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;border-radius:50%;" />
                    <span style="font-family:'amazon ember';color:#1a1a1a;font-size:14px;">snacks & namkeen</span>  
                </div>
            </div>
            <%--<div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;" />
                    <h5>ratlami sev</h5>
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;" />
                    <h5>ratlami sev</h5>
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;" />
                    <h5>ratlami sev</h5>
                </div>
            </div>
            <div class="ca-item" style=" left: 0px;">
                <div class="ca-item-main">
                    <img src="images/testing/categoryimage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 97px;" />
                    <h5>ratlami sev</h5>
                </div>
            </div>
    --%>
    <%--</div>

    </div>--%>

    <%--    <div id="ca-container-New" class="ca-new-container">
        <div class="ca-nav">
            <%--<span class="ca-nav-prev" style="background: transparent url(../images/arrows.png) no-repeat top left;">Previous</span>--%>
    <%--<span class="ca-nav-prev" style="background: url(../images/arrows.png)">Previous</span>
            <span class="ca-nav-next" style="background: url(../images/arrows.png) no-repeat top left; background-position: top right;">Next</span>
        </div>--%>
    <%--  <div class="ca-wrapper" style="overflow: hidden;">
            <div class="ca-item" style="left: 0px;">
                <div>--%>
    <%--<img src="images/Testing/CategoryImage/40003735_9-amul-dark-chocolate-55-rich-in-cocoa.jpg" style="width: 104px; border-radius: 50%;" class="center"/>--%>
    <%--<img src="images/Testing/CategoryImage/40003735_9-amul-dark-chocolate-55-rich-in-cocoa.jpg"  class="CategoryImagecenter"/>
                    <span class="CategoryText">Chocolates & Candies</span>
                </div>
            </div>
            <div class="ca-item" style="left: 0px;">
                <div>--%>
    <%--<img src="images/Testing/CategoryImage/295519_11-glucon-d-instant-energy-health-drink-nimbu-pani-refill.jpg" style="width: 104px; border-radius: 50%;" class="center"/>--%>
    <%--<img src="images/Testing/CategoryImage/295519_11-glucon-d-instant-energy-health-drink-nimbu-pani-refill.jpg"  class="CategoryImagecenter"/>
                    <span class="CategoryText">Health Drink, Supplement</span>
                </div>
            </div>

            <div class="ca-item" style="left: 0px;">
                <div>--%>
    <%--<img src="images/Testing/CategoryImage/40052455_2-wagh-bakri-dust-tea.jpg" style="width: 104px; border-radius: 50%;" class="center" />--%>
    <%--          <img src="images/Testing/CategoryImage/40052455_2-wagh-bakri-dust-tea.jpg"  class="CategoryImagecenter" />
                    <span style="font-family: 'Amazon Ember'; color: #1A1A1A; font-size: 12px;font-weight:bold;">Tea & Coffee</span>
                </div>
            </div>
            <div class="ca-item" style="left: 0px;">
                <div>
                    <img src="images/Testing/CategoryImage/100004121_2-everest-powder-tikhalal-chilli.jpg" style="width: 104px; border-radius: 50%;" class="center" />
                    <span style="font-family: 'Amazon Ember'; color: #1A1A1A; font-size: 12px;font-weight:bold;">Masalas & Spices</span>
                </div>
            </div>
            <div class="ca-item" style="left: 0px;">
                <div>
                    <img src="images/Testing/CategoryImage/274148_11-fortune-sunflower-refined-oil.jpg" style="width: 104px; border-radius: 50%;" class="center" />
                    <span style="font-family: 'Amazon Ember'; color: #1A1A1A; font-size: 12px;font-weight:bold;">Edible Oils & Ghee</span>
                </div>
            </div>
            <div class="ca-item" style="left: 0px;">
                <div>
                    <img src="images/Testing/CategoryImage/284420_7-aashirvaad-multigrains-atta.jpg" style="width: 104px; border-radius: 50%;" class="center" />
                    <span style="font-family: 'Amazon Ember'; color: #1A1A1A; font-size: 12px;font-weight:bold;">Atta, Flours & Sooji</span>
                </div>
            </div>
            <div class="ca-item" style="left: 0px;">
                <div>
                    <img src="images/Testing/CategoryImage/100022493_1-haldirams-namkeen-ratlami-sev.jpg" style="width: 104px; border-radius: 50%;" class="center" />
                    <span style="font-family: 'Amazon Ember'; color: #1A1A1A; font-size: 12px;font-weight:bold;">Snacks & Namkeen</span>
                </div>
            </div>
        </div>--%>

    <%--</div>--%>



    <div id="divCategory" class="ca-new-container" runat="server">
    </div>

    <div id="divBannerImage">
    </div>

    <%--<div class="row">
        <div class="offer-banner">--%>
    <%--<img src="images/Testing/BannerImage/Deals and Offers_Strip Banner_940 x 120px(1).jpg" class="img" />--%>
    <%--<img src="http://admin.salebhai.in:98/BannerImage//strip-banner.jpg" class="img" />
        </div>
        
        <br />
        <div class="offer-banner">
            <img src="http://admin.salebhai.in:98/BannerImage\\App_750x300.jpg" class="img"/>
        </div>
    </div>--%>
    <%--<div class="row" style ="padding-top:6px;" ">
        <div class="owl-carouselowl-theme" id="imagsliderimg" runat="server">
            <div class="item active">
                
                <table style="width:100%;">
                    <tr>
                        <td colspan="5" style="background: #1DA1F2; color: #FFFFFF; font-size: 16px; font-family: 'Amazon Ember'; padding: 7px; padding-top: 5px; text-align: center;">Speci Corna</td>
                    </tr>
                    <tr>
                        <td>
                            <div style="color: white; background-color: red; border-radius: 50px; padding: 15px; width: 77px; position: absolute; text-align: center;">
                        22.00 % Off
                    </div>
                            <img src="ProductImage/1586243467500_0.jpg" alt="v1" style="width:100%;height:70%;"/>
                        </td>
                        <td>
                             <table>
                        <tr>
                            <td colspan="3" style="background: #1DA1F2; color: #FFFFFF; font-size: 16px; font-family: 'Amazon Ember'; border-radius: 22px; padding: 7px; padding-top: 5px; text-align: center;">SOSHO RECOMMENDED</td>
                        </tr>
                        <tr>
                            <td style="padding-top: 5px;" colspan="3">
                                <span style="color: #1A1A1A; font-family: 'Amazon Ember'; font-size: 22px;padding-left:27px;">Wheat Flour (Chakki Atta)</span>
                            </td>
                            
                        </tr>
                        
                        <tr>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;width:121px;padding-top:15px;padding-left:27px;">M.R.P</td>
                            <td style="font-family: 'Amazon Ember';padding-top:15px;">:</td>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;padding-top:15px;">₹ 0.00</td>
                        </tr>
                        
                        <tr style="padding-top: 15px;">
                            <td style="color: #1A1A1A; font-family:'Amazon Ember'; font-size: 15px;width:121px;padding-left:27px;font-weight:bold">Sosho Price</td>
                            <td style="color: #1A1A1A; font-family: 'Amazon Ember';font-weight:bold">:</td>
                            <td style="color: red; font-family: 'Amazon Ember'; font-size: 18px;font-weight:bold;">₹ 375.00</td>
                        </tr>
                        <tr>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;width:121px;padding-left:27px;">You Save</td>
                            <td style="font-family: 'Amazon Ember';">:</td>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;">₹ 100.00</td>
                        </tr>
                        
                        <tr>
                            <td  style="padding-top:15px; color: black; font-size: 15px; font-family: 'Amazon Ember'; border-color: #D0D0D0;padding-left:27px;">
                                <asp:DropDownList ID="ddlUnit" runat="server">
                                    <asp:ListItem Value="10-KG"></asp:ListItem>
                                    <asp:ListItem Value="50-KG"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>
                           <td style="padding-top:15px;padding-left:0px;" >
                                <img src="images/info - new.png" style="width: 20px; height: 20px" />
                               <span style="font-family:'Amazon Ember'"><b>sold 25 times</b></span>
                            </td>
                            <td style="font-family: Verdana; font-size: 18px;padding-top:15px;"></td>
                        </tr>
                       
                        <tr>
                              <td style="padding-top:15px;padding-left:27px;">
                                <button type="button" class="btn" style="color: white; font-family: 'Amazon Ember'; background-color: #1DA1F2; font-size: 16px;width:93px;">ADD</button>
                     
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="3" style="padding-top:15px;padding-left:27px;">
                                <button class="btn" type="button" id="btnminus" runat="server" style="color:white;font-family:'Amazon Ember';background-color:#1DA1F2;"><i class="fa fa-minus"></i></button>
                                <input id="txtqty" runat="server" value="1" style="font-family:'Amazon Ember';font-weight:bold;width:40px;"/>
                                <button class="btn" type="button" id="btnplus" runat="server" style="color:white;font-family:'Amazon Ember';background-color:#1DA1F2;"><i class="fa fa-plus"></i></button>
                            </td>
                        </tr>
                    </table>
                        </td>
                    </tr>
                </table>
              
                    
            </div>
        </div>
        </div>--%>
    <%--<div id="content" runat="server"></div>--%>



    <%--    <div id="divProduct">
        <table style="width: 100%;">
            <tr>
                <%--<td colspan="5" style="background: #1DA1F2; color: #FFFFFF; font-size: 16px; font-family: 'Amazon Ember'; padding: 7px; padding-top: 5px; text-align: center;">Speci Corna</td>--%>
    <%-- <td colspan="5" class="BlueText" style="padding: 7px; padding-top: 5px; text-align: center;">Speci Corna</td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">--%>
    <%--<div style="color: white; background-color: red; border-radius: 50px; padding: 13px; width: 70px; position: absolute; text-align: center;">
                        22.0 Off
                    </div>--%>
    <%--<div style="color: white; background-color: red; border-radius: 50px; padding: 15px; width: 77px; position: absolute; text-align: center;">
                        22.00 % Off
                    </div>
                    <div>--%>
    <%--<img src="ProductImage/1586243467500_0.jpg" style="height: 400px; width: 400px;" />--%>
    <%--<img src="ProductImage/1586243467500_0.jpg" class="ProductImage" />
                    </div>
                </td>
                <td>
                    <table style="width: 100%; position: relative; bottom: -6px; right: 166px;">
                        <tr>--%>
    <%--<td colspan="3" style="background: #1DA1F2; color: #FFFFFF; font-size: 16px; font-family: 'Amazon Ember'; border-radius: 22px; padding: 7px; padding-top: 5px; text-align: center;">SOSHO RECOMMENDED</td>--%>
    <%--<td colspan="3" class="BlueText" style="border-radius: 22px; padding: 7px; padding-top: 5px; text-align: center;">SOSHO RECOMMENDED</td>
                            
                        </tr>
                        <tr>
                            <td style="padding-top: 5px;" colspan="3">
                                <span style="color: #1A1A1A; font-family: 'Amazon Ember'; font-size: 22px;padding-left:27px;">Wheat Flour (Chakki Atta)</span>
                            </td>--%>
    <%--<td colspan="2"></td>--%>
    <%--</tr>
                        
                        <tr>--%>
    <%--<td style="font-family: 'Amazon Ember'; font-size: 15px;width:121px;padding-top:15px;padding-left:27px;">M.R.P</td>--%>
    <%--<td class="ProudctMRPText" style="padding-top:15px;">M.R.P</td>
                            <td style="font-family: 'Amazon Ember';padding-top:15px;">:</td>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;padding-top:15px;">₹ 0.00</td>
                        </tr>
                        
                        <tr style="padding-top: 15px;">
                            <td style="color: #1A1A1A; font-family:'Amazon Ember'; font-size: 15px;width:121px;padding-left:27px;font-weight:bold">Sosho Price</td>
                            <td style="color: #1A1A1A; font-family: 'Amazon Ember';font-weight:bold">:</td>
                            <td style="color: red; font-family: 'Amazon Ember'; font-size: 18px;font-weight:bold;">₹ 375.00</td>
                        </tr>
                        <tr>--%>
    <%--<td style="font-family: 'Amazon Ember'; font-size: 15px;width:121px;padding-left:27px;">You Save</td>--%>
    <%--<td class="ProudctMRPText">You Save</td>
                            <td style="font-family: 'Amazon Ember';">:</td>
                            <td style="font-family: 'Amazon Ember'; font-size: 15px;">₹ 100.00</td>
                        </tr>
                        
                        <tr>
                            <td  style="padding-top:15px; color: black; font-size: 15px; font-family: 'Amazon Ember'; border-color: #D0D0D0;padding-left:27px;">
                                <asp:DropDownList ID="ddlUnit" runat="server">
                                    <asp:ListItem Value="10-KG"></asp:ListItem>
                                    <asp:ListItem Value="50-KG"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>
                           <td style="padding-top:15px;padding-left:0px;" >
                                <img src="images/info - new.png" style="width: 20px; height: 20px" />
                               <span style="font-family:'Amazon Ember'"><b>sold 25 times</b></span>
                            </td>
                            <td style="font-family: Verdana; font-size: 18px;padding-top:15px;"></td>
                        </tr>
                       
                        <tr>
                              <td style="padding-top:15px;padding-left:27px;">--%>
    <%--<button type="button" class="btn" style="color: white; font-family: 'Amazon Ember'; background-color: #1DA1F2; font-size: 16px;width:93px;">ADD</button>--%>
    <%--<button type="button" class="btn BlueText" style="color: white;  font-size: 16px;width:93px;">ADD</button>
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="3" style="padding-top:15px;padding-left:27px;">
                                <button class="btn" type="button" id="btnminus" runat="server" style="color:white;font-family:'Amazon Ember';background-color:#1DA1F2;"><i class="fa fa-minus"></i></button>
                                <input id="txtqty" runat="server" value="1" style="font-family:'Amazon Ember';font-weight:bold;width:40px;"/>
                                <button class="btn" type="button" id="btnplus" runat="server" style="color:white;font-family:'Amazon Ember';background-color:#1DA1F2;"><i class="fa fa-plus"></i></button>
                            </td>
                        </tr>
                    </table>
                </td>


            </tr>--%>
    <%--  <tr>
                <td colspan="2" style="background:#1DA1F2;color:#FFFFFF;font-size:16px;font-family:'Amazon Ember';border-radius:22px;padding:13px;width:70px;padding-top:5px;">SOSHO RECOMMENDED</td>
                <td colspan="3"></td>
            </tr>--%>
    <%-- <tr>
                <td colspan="5">
                    <span style="color:#1A1A1A;font-family:'Amazon Ember';font-size:16px;">Wheat Flour (Chakki Atta)</span>
                </td>
                
            </tr>--%>


    <%-- <td style="padding-top:5px;">
                    <div style="color:white;background-color:red;border-radius:50px;padding:13px;width:70px;position:absolute;text-align:center;">22.0 Off
                        </div>
                    <div>
                    <img src="ProductImage/1586243467500_0.jpg" style="height:600px;width:600px;"/>
                        </div>
                </td>--%>




    <%--        <td colspan="5"><b>Wheat Flour (Chakki Atta)</b></td>
                            <td colspan="2"><b>Sosho Price:</b></td>
                            <td colspan="3">375.00</td>
                            <td>MRP</td>
                            <td>0.00</td>
                            <td>Save</td>
                            <td>375.00</td>
                            <td style="background:#ff5722;border:1px solid #ff5722;color:#fff;font-size:14px;font-weight:600;text-transform:uppercase;box-shadow:rgba(0,0,0,0.5) 3px 3px 2px 0px;">Sold 25 times</td>
                            <td colspan="2">
                            <td colspan="2">
                                <asp:DropDownList ID="ddlUnit" runat="server">
                                    <asp:ListItem Value="10-KG"></asp:ListItem>
                                    <asp:ListItem Value="50-KG"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">
                                <button type="button" class="btn">ADD</button>
                            </td>--%>
    <%--</table>
    </div>--%>

    <div id="divProductNew">
    </div>

    <div id="divIntermediateBannerImage">
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
                                <i class="fa fa-map-marker" style="font-size: 25px; color: red"></i>
                                <input type="text" id="txtPinCodeval" placeholder="Pin Code" maxlength="6" style="padding-left: 0; padding-right: 0; border-radius: 0; border: none; border-radius: 0; box-shadow: none; border-bottom: 1px solid #d7dde4; height: 27px; width: 67px; border-color: #FF4444;" />

                                <span id="lblpinmsg" runat="server" style="height: 16px; color: green; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 0"></span>
                                <span id="lblpinnotmsg" runat="server" style="height: 16px; color: red; align-content: center; font: bold; /* size: 37px; */font-size: 14px; margin: 4px"></span>
                            </fieldset>
                        </div>
                        <div style="text-align: center;">
                            <button type="button" class="btn btn-primary" onclick="Newcheckservices()" id="BtnPinCodeApply">Confirm</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>


    <%--Product Description Modal Popup--%>
    <%--<div id="modalProductDescription" class="modalcenter fade">--%>
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

    <%--Product Packing Size Modal Popup--%>
    <div id="modalProductPackingSize" class="modalcenter fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="PackingProdName" style="font-family: 'Amazon Ember'; font-weight: bold;"></h4>
                    <button type="button" class="btn close" aria-label="Close" data-dismiss="modal">
                        <i class="fa fa-times-circle-o fa-lg" aria-hidden="true"></i>
                    </button>
                </div>

                <div class="modal-body" style="text-align: left;">
                    <p style="font-family: 'Amazon Ember'; font-weight: bold;">Pack Size</p>
                    <div class="AmazonFont" id="divPackSize">
                        <%-- <div style="border-radius: 22px; border: solid">
                        <table style="width: 100%; color: black;">
                            <tr>
                                <td style="width: 22%; text-align: center">
                                    <span id="spanWeight" style="font-family: 'Amazon Ember'; font-weight: bold; color: #1a1a1a"></span>
                                </td>
                                <td><span id="spanSoshoPrice"></span></td>
                                <td style="color: red; font-weight: bold;"><span id="spanDiscountOffer"></span></td>
                                <td>Best Buy</td>
                                <td>
                                    <i class="fa fa-check fa-2x" aria-hidden="true"></i>
                                </td>
                            </tr>
                            <tr>

                                <td style="width: 22%; text-align: center">Pouch</td>
                                <td>MRP:<del><span id="spanProductMrp"></span></del></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                            </div>
                        <br />
                         <div style="border-radius: 22px; border: solid">
                         <table style="width: 100%; color: black;">
                            <tr>
                                <td style="width: 22%; text-align: center">
                                    <span  style="font-family: 'Amazon Ember'; font-weight: bold; color: #1a1a1a"></span>
                                </td>
                                <td><span ></span></td>
                                <td style="color: red; font-weight: bold;"><span ></span></td>
                                <td>Best Buy</td>
                                <td>
                                    <i class="fa fa-check fa-2x" aria-hidden="true"></i>
                                </td>
                            </tr>
                            <tr>

                                <td style="width: 22%; text-align: center">Pouch</td>
                                <td>MRP:<del><span ></span></del></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                            </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        var products = [];
        var obj;
        var count = 0;
        var AllProducts = [];
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
        function AddClick(rowindex, prodid, grpid, mrp, el) {

            //$('#AddShow' + rowindex).css('display', '');
            //$('#BtnAdd' + rowindex).css('display', 'none');

            //$('#AddShow' + rowindex).show();
            //$('#BtnAdd' + rowindex).hide();

            $('#AddShow' + grpid).show();
            $('#BtnAdd' + grpid).hide();

            //$('#count')[0].innerHTML = "";
            //$('#cnfrm').addClass('hide');

            var $this = $(el);

            //var qty = $this.parents('.row').prev().find('input').val();
            //var qty = $('#AddShow' + rowindex).find('input').val();
            //var grpId = $('#hdnGrpId' + rowindex).val();
            //var productvariant = $('#hdnProductVariant' + rowindex).val();
            //var unitId = $('#ddlUnit' + rowindex).val();
            //var unitvalue = $('#ddlUnit' + rowindex).val();

            var qty = $('#AddShow' + grpid).find('input').val();
            var grpId = grpid;
            var productvariant = $('#hdnProductVariant' + grpid).val();
            var unitId = $('#ddlUnit' + grpid).val();
            var unitvalue = $('#ddlUnit' + grpid).val();
            var parts = unitvalue.split(' - ');

            //$this.css('background-image', 'linear-gradient( #e3e7e6 30%, #e3e7e6)');
            //$this.css('border-top', '1px solid #e3e7e6');
            //$this.css('border-left', '1px solid #e3e7e6');
            //if (products.length > 0) {
            //var product = products.find(x => x.Productid == prodid);
            //if (product != null && product != undefined) {
            //    products.splice(products.findIndex(x => x.Productid == prodid), 1);
            //$this.css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
            //$this.css('border-top', '1px solid #ff9910');
            //$this.css('border-left', '1px solid #ff9910');

            //$this.parent().next().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
            //$this.parent().next().find('input').css('border-top', '1px solid #ff9910');
            //$this.parent().next().find('input').css('border-left', '1px solid #ff9910');

            //$this.parent().next().next().find('input').css('background-image', 'linear-gradient( #ff9933 30%, #ff9900)');
            //$this.parent().next().next().find('input').css('border-top', '1px solid #ff9910');
            //$this.parent().next().next().find('input').css('border-left', '1px solid #ff9910');

            //    count = products.length;
            //}
            //else {
            //    obj = {
            //        Productid: prodid,
            //        Mrp: parseInt(mrp),
            //        Qty: parseInt(qty)

            //    //}
            //    products.push(obj);
            //    count = products.length;
            //}
            //}
            //else {
            obj = {
                Productid: prodid,
                Grpid: grpId,
                Mrp: parseInt(mrp),
                Qty: parseInt(qty),
                Unit: parts[0],
                UnitId: parts[1],
                Productvariant: productvariant

            }
            products.push(obj);
            count = products.length;
            //}
            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
                $('#hdnProductCount').val(count);
            }
        }
        function plusqty(type, prodid, grpid, el) {

            var $this = $(el);
            var parent = $this.parent();
            var value = parent.find('input').val();
            value = Number(value);
            var trid = $this.parent().closest('tr').attr('id'); // table row ID
            var rowindexval = trid.replace('AddShow', '');

            if (type == 1) {
                value = value + 1;
            }
            else if (type == 0) {
                if (value > 1) {
                    value = value - 1;
                }
                if (value == 1) {
                    $('#AddShow' + rowindexval).hide();
                    $('#BtnAdd' + rowindexval).show();
                }
            }
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                    //products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == grpid), 1);
                    count = products.length;
                }
                if (count == 0) {
                    $('#count')[0].innerHTML = "";
                    $('#cnfrm').addClass('hide');
                }
                else {
                    $('#count')[0].innerHTML = count + " Product Added";
                    $('#cnfrm').removeClass('hide');
                    $('#hdnProductCount').val(count);
                }
            }
            else {
                $('#count')[0].innerHTML = "";
                $('#cnfrm').addClass('hide');
            }

            var dataval = parent.find('input');
            dataval[0].value = value;
        }
        function BannerAddClick(rowindex, prodid, mrp, el) {
            //$('#divBannerAddShow' + rowindex).show();
            //$('#divBannerAdd' + rowindex).hide();


            $('#divBannerAddShow' + prodid).show();
            $('#divBannerAdd' + prodid).hide();
            var $this = $(el);

            //var qty = $('#divBannerAddShow' + rowindex).find('input').val();
            var qty = $('#divBannerAddShow' + prodid).find('input').val();


            var grpId = prodid;
            var productvariant = "BannerProduct";
            //var unitId = $('#hdnddlUnit' + rowindex).val();
            //var unitvalue = $('#hdnddlUnit' + rowindex).val();

            var unitId = $('#hdnddlUnit' + prodid).val();
            var unitvalue = $('#hdnddlUnit' + prodid).val();
            var parts = unitvalue.split('-');
            obj = {
                Productid: prodid,
                Grpid: grpId,
                Mrp: parseInt(mrp),
                Qty: parseInt(qty),
                Unit: parts[0],
                UnitId: parts[1],
                Productvariant: productvariant

            }
            products.push(obj);
            count = products.length;
            if (products.length > 0) {
                $('#count')[0].innerHTML = count + " Product Added";
                $('#cnfrm').removeClass('hide');
                $('#hdnProductCount').val(count);
            }
        }

        function Bannerplusqty(type, prodid, grpid, el) {

            var $this = $(el);
            var parent = $this.parent();
            var value = parent.find('input').val();
            value = Number(value);
            //var trid = $this.parent().closest('tr').attr('id'); // table row ID
            //var rowindexval = trid.replace('divBannerAddShow', '');

            if (type == 1) {
                value = value + 1;
            }
            else if (type == 0) {
                if (value > 1) {
                    value = value - 1;

                    if (value == 1) {
                        $('#divBannerAddShow' + prodid).hide();
                        $('#divBannerAdd' + prodid).show();
                    }
                }
            }
            if (products.length > 0) {
                var product = products.find(x => x.Productid == prodid);
                if (product != null && product != undefined) {
                   // products.splice(products.findIndex(x => x.Productid == prodid && x.Grpid == grpid), 1);
                    count = products.length;
                }
                if (count == 0) {
                    $('#count')[0].innerHTML = "";
                    $('#cnfrm').addClass('hide');
                }
                else {
                    $('#count')[0].innerHTML = count + " Product Added";
                    $('#cnfrm').removeClass('hide');
                    $('#hdnProductCount').val(count);
                }
            }
            else {
                $('#count')[0].innerHTML = "";
                $('#cnfrm').addClass('hide');
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
                data: JSON.stringify({ model: products,"WhatsAppNo":$("#btnsendMessage").text(),"PinCode": $("#spanpincode").html() }),
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
        function Categoryimage(categoryId, categoryName, el) {
            var JurisdictionId = $("#hdnJurisdictionId").val();
            window.location = "category.aspx?categoryId=" + categoryId + "&JurisdictionId=" + JurisdictionId + "&CatgoryName=" + categoryName + "";
        }
        function image(rowindex, prodid, el) {
            $('#divPDescription').text('');
            $('#divPKeyFeature').text('');
            $('#hdnPName' + rowindex).val();
            $('#ProdName').text($('#hdnPName' + rowindex).val());

            if (AllProducts.length > 0) {
                var FilterProduct = AllProducts[0].find(x => x.ProductId == prodid);
                if (FilterProduct != null && FilterProduct != undefined) {
                    var sDesc = FilterProduct.ProductDescription;
                    var sKeyfeature = FilterProduct.ProductKeyFeatures;

                    $('#divPDescription').append(sDesc);
                    $('#divPKeyFeature').append(sKeyfeature);
                }
            }

            //$('#divPDescription').append($('#hdnPDescription' + rowindex).val());
            //$('#divPKeyFeature').append($('#hdnPKeyFeature' + rowindex).val());

            $('#modalProductDescription').modal('show');

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



    <%-- <!-- The Modal -->
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
    <%-- </div>
                                </div>
                                <div class="feature">
                                    <div class="inner">
                                        <h5>Key features</h5>
                                        <div id="lblprodkeyfeature" runat="server">
                                        </div>--%>
    <%--<ul id="lblprodkeyfeature" runat="server">
                           
                           
                        </ul>--%>
    <%--</div>
                                </div>
                                <div class="notes">
                                    <div class="inner">
                                        <h5>Terms & conditions</h5>
                                        <div id="lblprodnote" runat="server">
                                        </div>--%>
    <%--                        <ul id="lblprodnote" runat="server">
                           
                        </ul>--%>
    <%--                          </div>
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
    </div>--%>

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
        <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

        <script src="js/jquery-1.12.4.min.js"></script>
        <script src="js/bootstrap.min.js"></script>

        <script>
            $(document).ready(function () {
                //$("#myPinCodeModal").modal('show');
                $('.mobile-number').hide();
                $('.offer-time').hide();
                $('#ContentPlaceHolder1_divCategory').hide();
                $('#lbllogout').hide();
                $('#myPinCodeModal').modal({ backdrop: 'static', keyboard: false })

                //$(document).on('click', '#dvPackSizeModal0', function () {
                //    alert("H111led.");
                //});
                //const urlParams1 = new URLSearchParams(window.location.search);

                //if (urlParams1 != null && urlParams1 != "") {

                //    lbllogout.InnerHtml = "<li><p><span><a href=\"register.aspx\">Login</a></span></p><li>";
                //}


            });
            //$(document).on('click', '#dvPackSizeModal0', function () {
            //    alert("H111led.");
            //});
            // Attach a click event to every span inside the DIV.
            $('#divPackSize').on('click', 'div', function () {
                //$(this).parent().removeClass("boldPackSize");
                var check = $(this);
                //$(this).css({ 'backgroundColor': '#F00', 'color': '#FFF' });    // Change its style.
                $(this).css({ 'backgroundColor': '#1DA1F2' });
                var AttrId = $(this).attr("id");
                var AttrIndex = $(this).attr("id").replace('dvPackSizeModal', '');
                var AttrProductId = $(this).find("#hdnPackSizeProductId" + AttrIndex).text();
                var AttrGrpId = $(this).find("#hdnPackSizeGrpId" + AttrIndex).text();

                //Hide Modeal Popup
                $('#modalProductPackingSize').modal('hide');

                //Hide Product
                $('.trProductId' + AttrProductId).css('display', 'none');

                //Show Grp Product
                $('.trGrp' + AttrGrpId).css('display', '');
            });

            //   $("#divPackSize").click(function(evt){
            //alert($(this).attr("id"));

            //});
            function Newcheckservices() {

                var pincode = $("#txtPinCodeval").val();
                var msg1 = "<%=clsCommon.Pincodemaxlen6erromsg%>";
                var strlen = pincode.length;
                //if (strlen == 6)
                //{

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
                        //alert(resultflag);
                        if (resultflag == "1") {
                            $("#lblpinnotmsg").hide();
                            $("#lblpinmsg").show();
                            var labelObj = document.getElementById("<%=lblpinmsg.ClientID %>");
                            labelObj.innerHTML = message;
                            $("#lblpinmsg").val(message);
                            $("#myPinCodeModal").modal('hide');
                            $("#hdnJurisdictionId").val(JurisdictionId);
                            //$("#spanpincode").html('Deliver to ' + pincode);
                            $("#spanpincode").html(pincode);
                            //Get Product Data Load

                            $("#BtnPinCodeApply").attr("disabled", false);
                            //$.ajax({
                            //    type: 'POST',
                            //    url: "Default.aspx/GetFillData",
                            //    data: '{JurisdictionId:"' + JurisdictionId + '"}',
                            //    contentType: "application/json",
                            //    dataType: "json",
                            //    success: function (response) {
                            //        //var getdata = {
                            //        //    data: JSON.parse(response.d.CategoryList),
                            //        //}
                            //        //var categoryImage = getdata.data.CategoryImage;
                            //        //$("#lbltopbanner").attr(src,categoryImage);

                            //        //for (var i = 0; i < response.d.CategoryList.length; i++) {
                            //        //    if (i == 0) {
                            //        //        var categoryImage = response.d.CategoryList[i].CategoryImage;
                            //        //        var CategoryDescription = response.d.CategoryList[i].CategoryDescription;
                            //        //        $("#ContentPlaceHolder1_lbltopbanner").attr("src", categoryImage);
                            //        //        $("#ContentPlaceHolder1_link").attr("href", CategoryDescription);
                            //        //    }

                            //        //}

                            //        $("#divCategory").append(JSON.stringify(response.d).replace('"', " "));

                            //        //var data = {
                            //        //    "JurisdictionId": JurisdictionId,
                            //        //    "StartNo": '1',
                            //        //    "EndNo": '5'
                            //        //};

                            $('#divBannerImage').html('');
                            $("#divProductNew").html('');
                            $("#divIntermediateBannerImage").html('');
                            $('#OtherBanner').html('');

                            $.ajax({
                                type: 'POST',
                                url: "Default.aspx/GetProductdata",
                                data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"1",EndNo:"5",BannerCount:"1"}',
                                contentType: "application/json",
                                dataType: "json",
                                success: function (response) {
                                    var ProductEndNo = parseInt("5");
                                    $('#hdnProductEndNo').val(parseInt(ProductEndNo + 1));
                                    $('#hdnproductcallcount').val(response.d.productcount);
                                    //var getdata = {
                                    //    data: JSON.parse(response.d.whatsapp),
                                    //}
                                    //$("#btnsendMessage").text(getdata.data);

                                    $('.mobile-number').show();
                                    $('.offer-time').show();
                                    $('#ContentPlaceHolder1_divCategory').show();
                                    $('#lbllogout').show();
                                    $("#btnsendMessage").text(response.d.whatsapp);
                                    //$("#divProductNew").append(JSON.stringify(response.d.response).replace('"', " "));
                                    $("#divProductNew").append(response.d.response);
                                    $("#divBannerImage").append(response.d.bannerresponse);
                                    $("#divIntermediateBannerImage").append(response.d.intermediateresponse);
                                    AllProducts.push(response.d.productdata.ProductList);
                                    $("#hdnBannerCount").val(parseInt("1"));
                                },
                                failure: function (response) {

                                    alert("Something Wrong....");

                                }
                            });

                            //    },
                            //    failure: function (response) {

                            //        alert("Something Wrong....");

                            //    }
                            //});

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

            function myPackSize(rowindex, Discountoffer, prodid, grpid, el) {
                //var ddlValue = $('#ddlUnit' + rowindex).val();
                //$('#divPackSize').text('');
                //$('#PackingProdName').text($('#hdnPName' + rowindex).val());
                //$('#spanWeight').text(ddlValue);

                var ddlValue = $('#ddlUnit' + grpid).val();
                $('#divPackSize').text('');
                $('#PackingProdName').text($('#hdnPName' + grpid).val());
                $('#spanWeight').text(ddlValue);

                if (AllProducts.length > 0) {
                    var FilterProduct = AllProducts[0].find(x => x.ProductId == prodid);
                    if (FilterProduct != null && FilterProduct != undefined) {
                        var divsize = '';
                        for (var i = 0; i < FilterProduct.ProductAttributesList.length; i++) {
                            var smrp = FilterProduct.ProductAttributesList[i].Mrp;
                            var Sosho = FilterProduct.ProductAttributesList[i].soshoPrice;
                            var sDiscount = FilterProduct.ProductAttributesList[i].Discount;
                            var sWeight = FilterProduct.ProductAttributesList[i].weight;
                            var sisSelected = FilterProduct.ProductAttributesList[i].isSelected;
                            var grpid = FilterProduct.ProductAttributesList[i].AttributeId;
                            if (sisSelected == 'true') {
                                divsize += '<div style="border-radius: 22px; border: solid;background-Color:#1DA1F2;" id="dvPackSizeModal' + i + '">';
                            }
                            else {
                                divsize += '<div style="border-radius: 22px; border: solid;" id="dvPackSizeModal' + i + '">';
                            }

                            divsize += '<span id="hdnPackSizeProductId' + i + '" style="display:none;">' + prodid + '</span><span id="hdnPackSizeGrpId' + i + '" style="display:none;">' + grpid + '</span>';
                            divsize += ' <table style="width: 100%; color: black;">';
                            divsize += '<tr>';
                            divsize += '<td style="width: 22%; text-align: center">';
                            divsize += '<span id="spanWeight" class="AmazonFont" style="font-weight: bold; color: #1a1a1a">' + sWeight + '</span>';
                            divsize += '</td>';
                            divsize += '<td><span id="spanSoshoPrice">' + Sosho + '</span></td>';
                            divsize += '<td style="color: red; font-weight: bold;"><span id="spanDiscountOffer">' + sDiscount + '</span></td>';
                            divsize += '<td>Best Buy</td>';
                            divsize += '<td>';
                            if (sisSelected == 'true') {
                                divsize += '<i class="fa fa-check fa-2x" aria-hidden="true"></i>';
                            }
                            divsize += '</td>';
                            divsize += '</tr>';
                            divsize += '<tr>';

                            divsize += '<td style="width: 22%; text-align: center">Pouch</td>';
                            divsize += '<td>MRP:<del><span id="spanProductMrp">' + smrp + '</span></del><input type="hidden" id="hdnPackSizeProductId' + i + '" value="' + prodid + '"><input type="hidden" id="hdnPackSizeGrpId' + i + '" value="' + grpid + '"></td>';
                            divsize += '<td></td>';
                            divsize += '<td></td>';
                            divsize += '<td></td>';
                            divsize += '</tr>';
                            divsize += '</table>';
                            divsize += '</div>';
                            divsize += '<br />';

                        }
                        $('#divPackSize').append(divsize);
                    }
                }
                //var id2 = $("table").find('#tbl' + rowindex);
                //var ProductMrp = $("table").find('#tbl' + rowindex).find('.ProductMRPValue').text().replace(':', '');
                //var SoshoPriceValue = $("table").find('#tbl' + rowindex).find('.SoshoPriceValue').text().replace(':', '');

                //$('#spanSoshoPrice').text(SoshoPriceValue);
                //$('#spanProductMrp').text(ProductMrp);
                //$('#spanDiscountOffer').text(Discountoffer);
                $('#modalProductPackingSize').modal('show');
            }
            function CallPinCodePopup() {
                $('#txtPinCodeval').val('');
                $("#ContentPlaceHolder1_lblpinmsg").text("");
                $('#myPinCodeModal').modal({ backdrop: 'static', keyboard: false })
            }
            //$(window).scroll(function () {
            //    if ($(window).scrollTop() + $(window).height() == $(document).height()) {
            //        //alert("END!");
            //        var JurisdictionId = $("#hdnJurisdictionId").val();
            //        //var ProductStartNo = parseInt($('#hdnProductEndNo').val()) + 1;
            //        var ProductStartNo = parseInt($('#hdnProductEndNo').val());
            //        var ProductEndNo = parseInt(ProductStartNo + 4);
            //        var bannercount = $("#hdnBannerCount").val();

            //        if (ProductStartNo > 0) {
            //            $.ajax({
            //                type: 'POST',
            //                url: "Default.aspx/GetProductdata",
            //                data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"' + ProductStartNo + '",EndNo:"' + ProductEndNo + '",BannerCount:"' + bannercount + '"}',
            //                contentType: "application/json",
            //                dataType: "json",
            //                success: function (response) {
            //                    if (response.d.productcount != "") {
            //                        $('#hdnProductEndNo').val(parseInt(ProductEndNo + 1));
            //                        //var getdata = {
            //                        //    data: JSON.parse(response.d.whatsapp),
            //                        //}
            //                        //$("#btnsendMessage").text(getdata.data);
            //                        $("#btnsendMessage").text(response.d.whatsapp);
            //                        //$("#divProductNew").append(JSON.stringify(response.d.response).replace('"', " "));
            //                        //$("#divProductNew").append(response.d.response);
            //                        var responsenew = response.d.response;
            //                        responsenew += response.d.intermediateresponse;
            //                        //$("#divIntermediateBannerImage").after(response.d.response);
            //                        $("#divIntermediateBannerImage").after(responsenew);
            //                        //$("#divBannerImage").append(response.d.bannerresponse);
            //                        //$("#divIntermediateBannerImage").append(response.d.intermediateresponse);
            //                        //$("#divProductNew").after(response.d.intermediateresponse);
            //                        AllProducts.push(response.d.productdata.ProductList);
            //                    }
            //                    else {
            //                        $('#hdnProductEndNo').val('0');
            //                    }
            //                },
            //                failure: function (response) {

            //                    alert("Something Wrong....");

            //                }

            //            });
            //        }
            //    }
            //});

            $(document.body).on('touchmove', onScroll); // for mobile
            $(window).on('scroll', onScroll);

            // callback
            function onScroll() {
                if ($(window).scrollTop() + window.innerHeight >= document.body.scrollHeight) {
                    var ProductCallCount = $('#hdnproductcallcount').val();
                    var JurisdictionId = $("#hdnJurisdictionId").val();
                    //var ProductStartNo = parseInt($('#hdnProductEndNo').val()) + 1;
                    var ProductStartNo = parseInt($('#hdnProductEndNo').val());
                    var ProductEndNo = parseInt(ProductStartNo + 4);
                    var bannercount = $("#hdnBannerCount").val();

                    if (ProductStartNo > 0) {
                        if (ProductCallCount != "") {
                            $.ajax({
                                type: 'POST',
                                url: "Default.aspx/GetProductdata",
                                data: '{JurisdictionId:"' + JurisdictionId + '",StartNo:"' + ProductStartNo + '",EndNo:"' + ProductEndNo + '",BannerCount:"' + bannercount + '"}',
                                contentType: "application/json",
                                dataType: "json",
                                success: function (response) {
                                    if (response.d.productcount != "") {
                                        $('#hdnProductEndNo').val(parseInt(ProductEndNo + 1));
                                        $('#hdnproductcallcount').val(response.d.productcount);
                                        //var getdata = {
                                        //    data: JSON.parse(response.d.whatsapp),
                                        //}
                                        //$("#btnsendMessage").text(getdata.data);
                                        $("#btnsendMessage").text(response.d.whatsapp);
                                        //$("#divProductNew").append(JSON.stringify(response.d.response).replace('"', " "));
                                        //$("#divProductNew").append(response.d.response);
                                        var responsenew = '';
                                       
                                        responsenew = response.d.response;
                                        responsenew += response.d.intermediateresponse;
                                        //$("#divIntermediateBannerImage").after(response.d.response);
                                        $("#divIntermediateBannerImage").after(responsenew);
                                        //$("#divProductNew").append(responsenew);
                                        //$("#divBannerImage").append(response.d.bannerresponse);
                                        //$("#divIntermediateBannerImage").append(response.d.intermediateresponse);
                                        //$("#divProductNew").after(response.d.intermediateresponse);
                                        AllProducts.push(response.d.productdata.ProductList);
                                    }
                                    else {
                                        $('#hdnProductEndNo').val('0');
                                        $('#hdnproductcallcount').val(productcount);
                                    }
                                },
                                failure: function (response) {

                                    alert("Something Wrong....");

                                }

                            });
                        }
                    }
                }
            }
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
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>--%>

    <script src="js/CircularContentCarousel/jquery.easing.1.3.js"></script>
    <!-- the jScrollPane script -->
    <%--<script src="js/CircularContentCarousel/jquery.mousewheel.js"></script>--%>
    <script src="js/CircularContentCarousel/jquery.contentcarousel.js"></script>
    <script type="text/javascript">
        //$('#ca-container').contentcarousel();
        $('#ContentPlaceHolder1_divCategory').contentcarousel();
    </script>
</asp:Content>
