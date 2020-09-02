<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PersonalInfo.aspx.cs" Inherits="PersonalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="personal-info">
        <div class="container">       
            <div class="row">
            <h3>Personal Information</h3>
        </div>
        <div class="row">
            <div class="main">
                <div id ="editsection" runat="server">
                      <div class="edit" id="edit">
                <asp:Button ID="Button2" CssClass="edit-btn" runat="server" Text="Edit" OnClick="Button2_Click" />
                </div>
            <table id="existing-table">
                <tr><td colspan="4" class="font"><i class="fa fa-user right icon"></i>Name </td><td><span id="name" runat="server"></span></td></tr>
                <tr><td colspan="4" class="font"><i class="fa fa-home right icon"></i>Current City </td><td><span id="city" runat="server"></span></td></tr>
                <tr><td colspan="4" class="font"><i class="fa fa-map-marker right icon"></i>State </td><td><span id="state" runat="server"></span></td></tr>
                <tr><td colspan="4" class="font"><i class="fa fa-envelope right icon"></i>Email </td><td><span id="email11" runat="server"></span></td></tr>
                <tr><td colspan="4" class="font"><i class="fa fa-phone right icon"></i>MobileNo </td><td><span id="mobile" runat="server"></span></td></tr>
            </table>


                </div>
              
               <div class="tbl-width" id="edittable" runat="server">
                 <table class="edit-table">
                    <tr>
                        <td class="text">First Name</td>
                        <td>
                            <asp:TextBox ID="txtfname" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="text">Last Name</td>
                        <td>
                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td class="text">State</td>
                        <td>
                         <asp:DropDownList ID="ddlstate" runat="server" class="section2" AutoPostBack="false" onChange="return GetState(this)">
                                    </asp:DropDownList>
                            </td>
                    </tr>
                     <tr>
                        <td class="text">Current City</td>
                        <td>
                             <asp:DropDownList ID="ddlcity" runat="server" class="section2" AutoPostBack="false" onChange="return GetCity(this)">
                                    </asp:DropDownList></td>
                    </tr>
                      <tr>
                        <td class="text">Email</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td class="text">MobileNo</td>
                        <td>
                            <asp:TextBox ID="txtmob" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                   </table>
                   <div class="save-text">
                        <asp:Button ID="Button3" CssClass="Back-btn" runat="server" Text="Back"  OnClick="Back_Click" />
                
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:Button ID="Button1" CssClass="save-btn" runat="server" Text="Save"  OnClick="Save_Click" />
                    </div>
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
          $('.offer-time').css('display','none');
      });
      function GetState(e) {
          var id = e.options[e.selectedIndex].value;
          document.getElementById("ContentPlaceHolder1_ddlstate").innerHTML = "";

          $.ajax({
              type: "POST",
              url: "PersonalInfo.aspx/GetMainCourse",
              data: '{id: "' + id + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  var products = response.d.split("###");
                  var dropdown = document.getElementById("ContentPlaceHolder1_ddlstate");
                
                  for (var i = 0; i < products.length; i++) {
                      var listoption = products[i].split(',');
                      dropdown[dropdown.length] = new Option(listoption[1], listoption[0]);
                      
                  }
                  //Default Selected
                  //$("#ContentPlaceHolder1_ppstate").val("1".statename).select;
                  //$("#ContentPlaceHolder1_ppstate").select("1".statename.selectedIndex);
              },
              failure: function (response) {
                  alert(response.d);
              }
          });
          return false;
      }

      //Get City Select On State
      function GetCity(e) {
          var id = e.options[e.selectedIndex].value;

          document.getElementById("ContentPlaceHolder1_ddlcity").innerHTML = "";
         

          $.ajax({
              type: "POST",
              url: "PersonalInfo.aspx/GetCityList",
              data: '{id: "' + id + '"}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  var products = response.d.split("###");
                  var dropdown = document.getElementById("ContentPlaceHolder1_ddlcity");
                 
                  for (var i = 0; i < products.length; i++) {
                      var listoption = products[i].split(',');
                      dropdown[dropdown.length] = new Option(listoption[1], listoption[0]);
                     
                  }
              },
              failure: function (response) {
                  alert(response.d);
              }
          });
          return false;
      }
  </script>
</asp:Content>

