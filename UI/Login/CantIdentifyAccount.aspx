<%@ Page Language="C#" MasterPageFile="~/UI/Login/MasterPage.master" AutoEventWireup="true" CodeFile="CantIdentifyAccount.aspx.cs" Inherits="CantIdentifyAccount" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
            width: 329px;
        }
         .style1
        {
           
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
            text-align:left;
        }
        .water
    {
         font-family: Tahoma, Arial, sans-serif;
         color:gray;
    }
      .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #3B5998;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left:10px;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #3B5998;
            cursor: pointer;
            color: #3B5998;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #3B5998;
            cursor: pointer;
        }
        .style6
        {
        }
        .style8
        {
        }
        #Select2
        {
            width: 71px;
        }
        .style9
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 10pt;
            vertical-align: top;
            width: 13px;
        }
    </style>
  
    <script language="javascript" type="text/javascript">
// <![CDATA[

       

// ]]>
    </script>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  
    
        <h4>
            <asp:Label ID="Label7" runat="server" Text="Can't identify your account" 
                ForeColor="#A10D0D"></asp:Label>
          </h4>
        <table class="style3">
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label1" runat="server" 
                Text="Enter alternative email where we can post your info
                " 
                CssClass="style1" style="font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
                <td class="style8">
            <asp:TextBox ID="txtActiveEmail" runat="server" height="22px" width="228px" 
                        MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtActiveEmail" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label2" runat="server" CssClass="style1" 
                style="font-family: Arial, Helvetica, sans-serif; text-align: right" 
                Text="Email address used to access your Pyramid Plus account" width="336px" Height="18px"></asp:Label>
                </td>
                <td class="style8">
            <asp:TextBox ID="txtAccountEmail" runat="server" height="22px" width="228px" 
                        MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtAccountEmail" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label3" runat="server" CssClass="style1" 
                style="font-family: Arial, Helvetica, sans-serif; text-align: right" 
                Text="Name on your Pyramid Plus account" width="336px"></asp:Label>
                </td>
                <td class="style8">
            <asp:TextBox ID="txtAccountUserName" runat="server" height="22px" width="228px" 
                        MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtAccountUserName" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label4" runat="server" CssClass="style1" 
                style="font-family: Arial, Helvetica, sans-serif; text-align: right" 
                Text="Date of birth" width="336px"></asp:Label>
                </td>
                <td class="style8" colspan="2">
                    <table class="style3">
                        <tr>
                            <td class="style6">
                                <select id="Select1" name="D1" onclick="return Select1_onclick()" onclick="return Select1_onclick()">
                                    <option value="-1">Day:</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option>
                                </select><select id="Select3" name="D3" onclick="return Select3_onclick()">
                                    <option value="-1">Month:</option><option value="1">January</option><option value="2">February</option><option value="3">March</option><option value="4">April</option><option value="5">May</option><option value="6">June</option><option value="7">July</option><option value="8">August</option><option value="9">September</option><option value="10">October</option><option value="11">November</option><option value="12">December</option>
                                </select><select id="Select2" name="D2" onclick="return Select2_onclick()">
                                    <option value="-1">Year:</option><option value="2012">2012</option><option value="2011">2011</option><option value="2010">2010</option><option value="2009">2009</option><option value="2008">2008</option><option value="2007">2007</option><option value="2006">2006</option><option value="2005">2005</option><option value="2004">2004</option><option value="2003">2003</option><option value="2002">2002</option><option value="2001">2001</option><option value="2000">2000</option><option value="1999">1999</option><option value="1998">1998</option><option value="1997">1997</option><option value="1996">1996</option><option value="1995">1995</option><option value="1994">1994</option><option value="1993">1993</option><option value="1992">1992</option><option value="1991">1991</option><option value="1990">1990</option><option value="1989">1989</option><option value="1988">1988</option><option value="1987">1987</option><option value="1986">1986</option><option value="1985">1985</option><option value="1984">1984</option><option value="1983">1983</option><option value="1982">1982</option><option value="1981">1981</option><option value="1980">1980</option><option value="1979">1979</option><option value="1978">1978</option><option value="1977">1977</option><option value="1976">1976</option><option value="1975">1975</option><option value="1974">1974</option><option value="1973">1973</option><option value="1972">1972</option><option value="1971">1971</option><option value="1970">1970</option><option value="1969">1969</option><option value="1968">1968</option><option value="1967">1967</option><option value="1966">1966</option><option value="1965">1965</option><option value="1964">1964</option><option value="1963">1963</option><option value="1962">1962</option><option value="1961">1961</option><option value="1960">1960</option><option value="1959">1959</option><option value="1958">1958</option><option value="1957">1957</option><option value="1956">1956</option><option value="1955">1955</option><option value="1954">1954</option><option value="1953">1953</option><option value="1952">1952</option><option value="1951">1951</option><option value="1950">1950</option><option value="1949">1949</option><option value="1948">1948</option><option value="1947">1947</option><option value="1946">1946</option><option value="1945">1945</option><option value="1944">1944</option><option value="1943">1943</option><option value="1942">1942</option><option value="1941">1941</option><option value="1940">1940</option><option value="1939">1939</option><option value="1938">1938</option><option value="1937">1937</option><option value="1936">1936</option><option value="1935">1935</option><option value="1934">1934</option><option value="1933">1933</option><option value="1932">1932</option><option value="1931">1931</option><option value="1930">1930</option><option value="1929">1929</option><option value="1928">1928</option><option value="1927">1927</option><option value="1926">1926</option><option value="1925">1925</option><option value="1924">1924</option><option value="1923">1923</option><option value="1922">1922</option><option value="1921">1921</option><option value="1920">1920</option><option value="1919">1919</option><option value="1918">1918</option><option value="1917">1917</option><option value="1916">1916</option><option value="1915">1915</option><option value="1914">1914</option><option value="1913">1913</option><option value="1912">1912</option><option value="1911">1911</option><option value="1910">1910</option><option value="1909">1909</option><option value="1908">1908</option><option value="1907">1907</option><option value="1906">1906</option><option value="1905">1905</option>
                                </select></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label5" runat="server" CssClass="style1" 
                style="font-family: Arial, Helvetica, sans-serif; text-align: right" 
                Text="Mobile Number" width="336px"></asp:Label>
                </td>
                <td class="style8">
            <asp:TextBox ID="txtMobileNumber" runat="server" height="22px" width="228px" 
                        MaxLength="11"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtMobileNumber" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
            <asp:Label ID="Label6" runat="server" CssClass="style1" 
                style="font-family: Arial, Helvetica, sans-serif; text-align: right" 
                Text="Any other email addresses you might have added to your Facebook account" 
                width="336px"></asp:Label>
                </td>
                <td class="style8">
            <asp:TextBox ID="txtAccountLinkedEmailAddress" runat="server" height="22px" width="228px" 
                        ontextchanged="TextBox7_TextChanged" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtAccountLinkedEmailAddress" ErrorMessage="* Required" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style5" align="right" valign="bottom">
                    &nbsp;</td>
                <td class="style8">
            <asp:Button cssClass="button" ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                Text="Submit"  />
                    <asp:Button ID="Button1"  
                class="button" runat="server"
                Text="Cancel" onclick="Button1_Click1" CausesValidation="False" />
           
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    
        <asp:Panel ID="Panel2" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
        </asp:Panel>
    
  </asp:Content>
