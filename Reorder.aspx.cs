using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static object GetProductdata(string JurisdictionId, string StartNo, string EndNo, int Filter = 1)
    {
        try
        {
            dbConnection dbc = new dbConnection();
            string html = string.Empty, sProductCount = string.Empty, sWhatsAppNo = string.Empty;
            string CustomerId = clsCommon.getCurrentCustomer().id;
            string apistring = clsCommon.strApiUrl + "/api/Product/GetPreviousProductDetails?CustomerID=" + CustomerId + "&JurisdictionID=" + JurisdictionId + "&StartNo=" + StartNo + "&EndNo=" + EndNo + "&Filter=" + Filter;
            string data = clsCommon.GET(apistring);

            if (!String.IsNullOrEmpty(data))
            {
                clsModals.getPreviousProduct objproduct = JsonConvert.DeserializeObject<clsModals.getPreviousProduct>(data);
                if (objproduct.response.Equals("1"))
                {

                    string sDiscount = "", sProductVariant = "", sMrp = "", sSoshoPrice = "", sWeight = "", sIsProductDescription = "", sAImageName = "";
                    decimal dMrp = 0, dSoshoPrice = 0, dSavePrice = 0;
                    string sProductId = "", sGrpId = "", sCategoryId = "", sIsQtyFreeze = "", sMinQty = string.Empty, sIsOutofStock = "", sPackingType = string.Empty;
                    string sisSelected = "", sProductName = "", sProductDesc = "", sProductKeyFeatures = "",sOrderedQty = string.Empty;
                    int iIndex = 0;
                    sWhatsAppNo = objproduct.WhatsAppNo;

                    sProductCount = objproduct.ProductList.Count().ToString();
                    html = "<table style='width:100%;'>";
                    if (objproduct.ProductList != null && objproduct.ProductList.Count > 0)
                    {
                        for (int j = 0; j < objproduct.ProductList.Count; j++)
                        {
                            sProductId = objproduct.ProductList[j].ProductId;
                            sCategoryId = objproduct.ProductList[j].CategoryId;
                            sIsProductDescription = objproduct.ProductList[j].ProductDescription;
                            sProductName = objproduct.ProductList[j].ProductName;
                            sProductDesc = objproduct.ProductList[j].ProductDescription;
                            sProductKeyFeatures = objproduct.ProductList[j].ProductKeyFeatures;
                            sGrpId = objproduct.ProductList[j].AttributeId;
                            sDiscount = objproduct.ProductList[j].Discount;
                            sMrp = objproduct.ProductList[j].MRP.ToString();
                            sSoshoPrice = objproduct.ProductList[j].SoshoPrice.ToString();
                            sWeight = objproduct.ProductList[j].Weight;
                            sAImageName = objproduct.ProductList[j].AImageName;
                            sisSelected = objproduct.ProductList[j].isSelected.ToString();
                            sIsQtyFreeze = objproduct.ProductList[j].isQtyFreeze.ToString();
                            sIsOutofStock = objproduct.ProductList[j].isOutOfStock.ToString();
                            sMinQty = objproduct.ProductList[j].MinQty.ToString();
                            sPackingType = objproduct.ProductList[j].PackingType;
                            sOrderedQty = objproduct.ProductList[j].OrderedQuantity.ToString();



                            if (!string.IsNullOrEmpty(sMrp))
                                dMrp = Convert.ToDecimal(sMrp);
                            if (!string.IsNullOrEmpty(sSoshoPrice))
                                dSoshoPrice = Convert.ToDecimal(sSoshoPrice);

                            dSavePrice = (dMrp - dSoshoPrice);
                            if (!string.IsNullOrEmpty(objproduct.ProductList[j].SpecialMessage))
                            {
                                if (sisSelected == "false")
                                    html += "<tr  id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                else
                                    html += "<tr  id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                                html += "<td colspan='5' class='BlueText' style='padding:7px;padding-top:5px;text-align:center; '>" + objproduct.ProductList[j].SpecialMessage + " </td>";
                                html += "</tr>";
                            }
                            if (sisSelected == "false")
                                html += "<tr id='tr" + iIndex + "' style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                            else
                                html += "<tr id='tr" + iIndex + "' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";


                            if (!string.IsNullOrEmpty(sDiscount))
                            {

                                html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";
                                if (sDiscount.ToString() != "0% Off" && sDiscount.ToString() != "₹ 0 Off")
                                {
                                    html += "<div   class='DiscountOffer'>";
                                    html += sDiscount;
                                    html += "</div>";
                                }
                            }
                            else
                                html += "<td style='padding-top:5px;width:50%;text-align:center;' id='td" + iIndex + "' >";

                            html += "<div><img src=\'" + sAImageName + "'\" alt=\"Image not found\" onerror=\"this.onerror=null; this.src='../images/no_image_available.png';\" class='ProductImage'/></div>";
                            html += "</td>";
                            html += "<td style='width:50%;'>";
                            html += "<table class='tableheader' id='tbl" + iIndex + "'>";
                            if (objproduct.ProductList[j].IsSoshoRecommended.ToString() == "true")
                            {
                                html += "<tr>";
                                html += "<td colspan='3' class='BlueText' style='border-radius:22px;padding:7px;padding-top:5px;text-align:center;'>" + objproduct.ProductList[j].SoshoRecommended + "</td>";
                                html += "</tr>";
                            }

                            html += "<tr class='AmazonFont'>";


                            html += "<td class='ProductCenter' colspan='3'>";

                            html += "<span class='ProductName'>" + (string.IsNullOrEmpty(sPackingType) ? sProductName : string.Concat(sProductName, ',', ' ', sPackingType)) + "</span>";
                            html += "</td>";
                            html += "</tr>";
                            html += "<tr>";
                            html += "<td class='ProudctMRPText' style='padding-top:15px;'>M.R.P</td>";
                            html += "<td class='ProductMRPValue'>:</td>";
                            html += "<td class='ProductMRPValue ProductMRPText'><del>₹ " + sMrp + "</del></td>";
                            html += "</tr>";
                            html += "<tr class='AmazonFont' style='padding-top:15px;'>";
                            html += "<td class='SoshoPrice'>Sosho Price</td>";
                            html += "<td class='SoshoColon'>:</td>";
                            html += "<td class='SoshoPriceValue'>₹ " + sSoshoPrice + "</td>";
                            html += "</tr>";
                            html += "<tr class='AmazonFont'>";
                            html += "<td class='ProudctMRPText'>You Save</td>";
                            html += "<td>:</td>";
                            html += "<td class='ProductMRPText'>₹ " + dSavePrice + "</td>";
                            html += "</tr>";
                            html += "<tr>";
                            html += "<td class='ProductDropDown' colspan='2'>";

                            html += "<option id='ddlUnit" + sGrpId + "' style='font-weight: 700;' Value='" + sWeight + "'>" + sWeight + "</option>";
                            html += "</td>";
                            html += "<td>";
                            if (!string.IsNullOrEmpty(sIsProductDescription))
                            {
                                html += "<img src='images/info - new.png' style='width:20px;height:20px;cursor:pointer;' onclick='image(" + iIndex + "," + sProductId + ",this)' />";
                            }
                            html += "</td>";
                            html += "</tr>";


                            html += "<tr id='BtnAdd" + sGrpId + "'>";
                            html += "<td style='padding-top:6px;' colspan='3'>";
                            if (Convert.ToBoolean(sIsOutofStock))
                            {
                                html += "<label style=\"border: 2px solid red; text-align: center; color: red; font-size: large; font-weight: 600; border-radius:8px; padding: 4px;\">Out of stock</label>";
                            }
                            else
                            {
                                html += "<button type='button' class='btn BlueText BtnAddText' onclick='AddClick(" + iIndex + "," + sProductId + "," + sGrpId + "," + sMrp + "," + sSoshoPrice + ",this,1)'>ADD</button>";
                            }

                            html += "<input type='hidden' id='hdnProductId" + sGrpId + "' value='" + sProductId + "'>";
                            html += "<input type='hidden' id='hdnGrpId" + sGrpId + "' value='" + sGrpId + "'>";
                            html += "<input type='hidden' id='hdnCategoryId" + sGrpId + "' value='" + sCategoryId + "'>";
                            html += "<input type='hidden' id='hdnPName" + sGrpId + "' value='" + sProductName + "'>";
                            html += "<input type='hidden' id='hdnPKeyFeature" + sGrpId + "' value='" + sProductKeyFeatures + "'>";
                            html += "<input type='hidden' id='hdnProductVariant" + sGrpId + "' value='" + sProductVariant + "'>";
                            html += "&nbsp;<span class='SoldCount'> " + objproduct.ProductList[j].SoldCount + "</span>";
                            html += "</td>";
                            html += "</tr>";
                            html += "<tr id='AddShow" + sGrpId + "' style='display:none;'>";
                            html += "<td colspan='3' style='padding-top:15px;padding-left:10px;' class='AmazonFont'>";
                            if (!string.IsNullOrEmpty(sIsQtyFreeze) && Convert.ToBoolean(sIsQtyFreeze))
                            {
                                html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sGrpId + "," + sMrp + "," + sSoshoPrice + ",this,1)'><i class='fa fa-minus'></i></button>";
                                html += "<input id='txtqty' runat='server' value='" + sMinQty + "' style='font-weight:bold;width:40px;text-align: center;'  onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
                                html += "<button class='btn ProductBtn' type='button' id='btnplus' style='background: #a5a5a5;' runat='server' onclick='plusqty(1," + sProductId + "," + sGrpId + "," + sMrp + "," + sSoshoPrice + ",this,1) disabled'><i class='fa fa-plus'></i></button>";
                            }
                            else
                            {
                                html += "<button class='btn ProductBtn' type='button' id='btnminus' runat='server' onclick='plusqty(0," + sProductId + "," + sGrpId + "," + sMrp + "," + sSoshoPrice + ",this,1)'><i class='fa fa-minus'></i></button>";
                                html += "<input id='txtqty' runat='server' value='"+ sOrderedQty + "' style='font-weight:bold;width:40px;text-align: center;' onkeyup=\"if (/\\D/g.test(this.value)) this.value = this.value.replace(/\\D/g, '')\"/>";
                                html += "<button class='btn ProductBtn' type='button' id='btnplus' runat='server' onclick='plusqty(1," + sProductId + "," + sGrpId + "," + sMrp + "," + sSoshoPrice + ",this,1)'><i class='fa fa-plus'></i></button>";
                            }

                            html += "</td>";
                            html += "</tr>";
                            html += "</table>";
                            html += "</td>";
                            html += "</tr>";


                            if (sisSelected == "false")
                                html += "<tr style='display:none;' class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                            else
                                html += "<tr class='trGrp" + sGrpId + " trProductId" + sProductId + "'>";
                            html += "<td colspan='5'> <hr class='solid'>";
                            html += "</td>";
                            html += "</tr>";
                            iIndex++;
                        }

                    }

                    html += "</table>";

                }



            }

            return new { productcount = sProductCount, response = html, whatsapp = sWhatsAppNo, productdata = JsonConvert.DeserializeObject<clsModals.getPreviousProduct>(data) };
        }
        catch (Exception ee)
        {
            return "";
        }
    }
}