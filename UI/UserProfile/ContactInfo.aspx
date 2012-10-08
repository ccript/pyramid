<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserProfile/MasterPage.master" AutoEventWireup="true" CodeFile="ContactInfo.aspx.cs" Inherits="ContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  .style5
        {
            color: #666666;
            font-weight: bold;
            font-family: Verdana;
            font-size: 9pt;
            vertical-align: top;
        }
        
           .style2
        {
          
        
           text-align:left;
        }
         </style>

         <link rel="stylesheet" href="../../Resources/Script/jqtransformplugin/fieldsJQuery.css" type="text/css" media="all" />
	<link rel="stylesheet" href="../../Resources/Script/demo.css" type="text/css" media="all" />
	
	<script type="text/javascript" src="../../Resources/Script/requiered/jquery.js" ></script>
	<script type="text/javascript" src="../../Resources/Script/jqtransformplugin/jquery.jqtransform.js" ></script>
	<script language="javascript">
	    $(function () {
	        $('form').jqTransform({ imgPath: 'jqtransformplugin/img/' });
	    });
	</script>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" >

     <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

     <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Primary Email:</td>
            <td>
                <asp:TextBox ID="txtPrimaryEmail" runat="server" MaxLength="45"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtPrimaryEmail" 
                    ErrorMessage="Email must be correct format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Others&nbsp;
                Emails:</td>
            <td class="style2">
                <asp:TextBox ID="txtEmail" class="txtboxes" runat="server" MaxLength="45" ></asp:TextBox>
                <br />
                <asp:LinkButton ID="lbtnAddEmail" runat="server" style="font-size: xx-small" 
                    onclick="lbtnAddEmail_Click">Add Email</asp:LinkButton>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" 
                    ErrorMessage="Email must be correct format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:GridView ID="GridViewEmail" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" 
                   GridLines="None" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGEmail" runat="server" 
                                    Text='<%# Bind("Name") %>'></asp:TextBox>
                                <br />
                                <br />
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtGEmail" Display="Dynamic" 
                    ErrorMessage="Email must be correct format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True">
                        <ItemStyle Font-Size="8pt" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" 
                                    ImageUrl="~/Resources/images/Icon/DeleteSmall.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
           <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>


        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Phone Numbers:
            </td>
            <td class="style2">
                <asp:DropDownList ID="lstCountryCode" runat="server">
                   <asp:ListItem Value="+93">Afghanistan+(93)</asp:ListItem>
<asp:ListItem Value="+355">Albania+(355)</asp:ListItem>
<asp:ListItem Value="+213">Algeria+(213)</asp:ListItem>
<asp:ListItem Value="+1 684">American Samoa+(1684)</asp:ListItem>
<asp:ListItem Value="+376">Andorra+(376)</asp:ListItem>
<asp:ListItem Value="+244">Angola+(244)</asp:ListItem>
<asp:ListItem Value="+1 264">Anguilla+(1 264)</asp:ListItem>
<asp:ListItem Value="+672">Antarctica+(672)</asp:ListItem>
<asp:ListItem Value="+1 268">Antigua and Barbuda+(1268)</asp:ListItem>
<asp:ListItem Value="+54">Argentina+(54)</asp:ListItem>
<asp:ListItem Value="+374">Armenia+(374)</asp:ListItem>
<asp:ListItem Value="+297">Aruba+(297)</asp:ListItem>
<asp:ListItem Value="+61">Australia+(61)</asp:ListItem>
<asp:ListItem Value="+43">Austria+(43)</asp:ListItem>
<asp:ListItem Value="+994">Azerbaijan+(994)</asp:ListItem>
<asp:ListItem Value="+1 242">Bahamas+(1242)</asp:ListItem>
<asp:ListItem Value="+973">Bahrain+(973)</asp:ListItem>
<asp:ListItem Value="+880">Bangladesh+(880)</asp:ListItem>
<asp:ListItem Value="+1 246">Barbados+(1246)</asp:ListItem>
<asp:ListItem Value="+375">Belarus+(375)</asp:ListItem>
<asp:ListItem Value="+32">Belgium+(32)</asp:ListItem>
<asp:ListItem Value="+501">Belize+(501)</asp:ListItem>
<asp:ListItem Value="+229">Benin+(229)</asp:ListItem>
<asp:ListItem Value="+1 441">Bermuda+(1441)</asp:ListItem>
<asp:ListItem Value="+975">Bhutan+(975)</asp:ListItem>
<asp:ListItem Value="+591">Bolivia+(591)</asp:ListItem>
<asp:ListItem Value="+387">Bosnia and Herzegovina+(387)</asp:ListItem>
<asp:ListItem Value="+267">Botswana+(267)</asp:ListItem>
<asp:ListItem Value="+55">Brazil+(55)</asp:ListItem>
<asp:ListItem Value="+">British Indian Ocean Territory+()</asp:ListItem>
<asp:ListItem Value="+1 284">British Virgin Islands+(1 284)</asp:ListItem>
<asp:ListItem Value="+673">Brunei+(673)</asp:ListItem>
<asp:ListItem Value="+359">Bulgaria+(359)</asp:ListItem>
<asp:ListItem Value="+226">Burkina Faso+(226)</asp:ListItem>
<asp:ListItem Value="+95">Burma (Myanmar)+(95)</asp:ListItem>
<asp:ListItem Value="+257">Burundi+(257)</asp:ListItem>
<asp:ListItem Value="+855">Cambodia+(855)</asp:ListItem>
<asp:ListItem Value="+237">Cameroon+(237)</asp:ListItem>
<asp:ListItem Value="+1">Canada+(1)</asp:ListItem>
<asp:ListItem Value="+238">Cape Verde+(238)</asp:ListItem>
<asp:ListItem Value="+1 345">Cayman Islands+(1 345)</asp:ListItem>
<asp:ListItem Value="+236">Central African Republic+(236)</asp:ListItem>
<asp:ListItem Value="+235">Chad+(235)</asp:ListItem>
<asp:ListItem Value="+56">Chile+(56)</asp:ListItem>
<asp:ListItem Value="+86">China+(86)</asp:ListItem>
<asp:ListItem Value="+61">Christmas Island+(61)</asp:ListItem>
<asp:ListItem Value="+61">Cocos (Keeling) Islands+(61)</asp:ListItem>
<asp:ListItem Value="+57">Colombia+(57)</asp:ListItem>
<asp:ListItem Value="+269">Comoros+(269)</asp:ListItem>
<asp:ListItem Value="+682">Cook Islands+(682)</asp:ListItem>
<asp:ListItem Value="+506">Costa Rica+(506)</asp:ListItem>
<asp:ListItem Value="+385">Croatia+(385)</asp:ListItem>
<asp:ListItem Value="+53">Cuba+(53)</asp:ListItem>
<asp:ListItem Value="+357">Cyprus+(357)</asp:ListItem>
<asp:ListItem Value="+420">Czech Republic+(420)</asp:ListItem>
<asp:ListItem Value="+243">Democratic Republic of the Congo+(243)</asp:ListItem>
<asp:ListItem Value="+45">Denmark+(45)</asp:ListItem>
<asp:ListItem Value="+253">Djibouti+(253)</asp:ListItem>
<asp:ListItem Value="+1 767">Dominica+(1 767)</asp:ListItem>
<asp:ListItem Value="+1 809">Dominican Republic+(1 809)</asp:ListItem>
<asp:ListItem Value="+593">Ecuador+(593)</asp:ListItem>
<asp:ListItem Value="+20">Egypt+(20)</asp:ListItem>
<asp:ListItem Value="+503">El Salvador+(503)</asp:ListItem>
<asp:ListItem Value="+240">Equatorial Guinea+(240)</asp:ListItem>
<asp:ListItem Value="+291">Eritrea+(291)</asp:ListItem>
<asp:ListItem Value="+372">Estonia+(372)</asp:ListItem>
<asp:ListItem Value="+251">Ethiopia+(251)</asp:ListItem>
<asp:ListItem Value="+500">Falkland Islands+(500)</asp:ListItem>
<asp:ListItem Value="+298">Faroe Islands+(298)</asp:ListItem>
<asp:ListItem Value="+679">Fiji+(679)</asp:ListItem>
<asp:ListItem Value="+358">Finland+(358)</asp:ListItem>
<asp:ListItem Value="+33">France+(33)</asp:ListItem>
<asp:ListItem Value="+689">French Polynesia+(689)</asp:ListItem>
<asp:ListItem Value="+241">Gabon+(241)</asp:ListItem>
<asp:ListItem Value="+220">Gambia+(220)</asp:ListItem>
<asp:ListItem Value="+970">Gaza Strip+(970)</asp:ListItem>
<asp:ListItem Value="+995">Georgia+(995)</asp:ListItem>
<asp:ListItem Value="+49">Germany+(49)</asp:ListItem>
<asp:ListItem Value="+233">Ghana+(233)</asp:ListItem>
<asp:ListItem Value="+350">Gibraltar+(350)</asp:ListItem>
<asp:ListItem Value="+30">Greece+(30)</asp:ListItem>
<asp:ListItem Value="+299">Greenland+(299)</asp:ListItem>
<asp:ListItem Value="+1 473">Grenada+(1 473)</asp:ListItem>
<asp:ListItem Value="+1 671">Guam+(1 671)</asp:ListItem>
<asp:ListItem Value="+502">Guatemala+(502)</asp:ListItem>
<asp:ListItem Value="+224">Guinea+(224)</asp:ListItem>
<asp:ListItem Value="+245">Guinea-Bissau+(245)</asp:ListItem>
<asp:ListItem Value="+592">Guyana+(592)</asp:ListItem>
<asp:ListItem Value="+509">Haiti+(509)</asp:ListItem>
<asp:ListItem Value="+39">Holy See (Vatican City)+(39)</asp:ListItem>
<asp:ListItem Value="+504">Honduras+(504)</asp:ListItem>
<asp:ListItem Value="+852">Hong Kong+(852)</asp:ListItem>
<asp:ListItem Value="+36">Hungary+(36)</asp:ListItem>
<asp:ListItem Value="+354">Iceland+(354)</asp:ListItem>
<asp:ListItem Value="+91">India+(91)</asp:ListItem>
<asp:ListItem Value="+62">Indonesia+(62)</asp:ListItem>
<asp:ListItem Value="+98">Iran+(98)</asp:ListItem>
<asp:ListItem Value="+964">Iraq+(964)</asp:ListItem>
<asp:ListItem Value="+353">Ireland+(353)</asp:ListItem>
<asp:ListItem Value="+44">Isle of Man+(44)</asp:ListItem>
<asp:ListItem Value="+972">Israel+(972)</asp:ListItem>
<asp:ListItem Value="+39">Italy+(39)</asp:ListItem>
<asp:ListItem Value="+225">Ivory Coast+(225)</asp:ListItem>
<asp:ListItem Value="+1 876">Jamaica+(1 876)</asp:ListItem>
<asp:ListItem Value="+81">Japan+(81)</asp:ListItem>
<asp:ListItem Value="+">Jersey+()</asp:ListItem>
<asp:ListItem Value="+962">Jordan+(962)</asp:ListItem>
<asp:ListItem Value="+7">Kazakhstan+(7)</asp:ListItem>
<asp:ListItem Value="+254">Kenya+(254)</asp:ListItem>
<asp:ListItem Value="+686">Kiribati+(686)</asp:ListItem>
<asp:ListItem Value="+381">Kosovo+(381)</asp:ListItem>
<asp:ListItem Value="+965">Kuwait+(965)</asp:ListItem>
<asp:ListItem Value="+996">Kyrgyzstan+(996)</asp:ListItem>
<asp:ListItem Value="+856">Laos+(856)</asp:ListItem>
<asp:ListItem Value="+371">Latvia+(371)</asp:ListItem>
<asp:ListItem Value="+961">Lebanon+(961)</asp:ListItem>
<asp:ListItem Value="+266">Lesotho+(266)</asp:ListItem>
<asp:ListItem Value="+231">Liberia+(231)</asp:ListItem>
<asp:ListItem Value="+218">Libya+(218)</asp:ListItem>
<asp:ListItem Value="+423">Liechtenstein+(423)</asp:ListItem>
<asp:ListItem Value="+370">Lithuania+(370)</asp:ListItem>
<asp:ListItem Value="+352">Luxembourg+(352)</asp:ListItem>
<asp:ListItem Value="+853">Macau+(853)</asp:ListItem>
<asp:ListItem Value="+389">Macedonia+(389)</asp:ListItem>
<asp:ListItem Value="+261">Madagascar+(261)</asp:ListItem>
<asp:ListItem Value="+265">Malawi+(265)</asp:ListItem>
<asp:ListItem Value="+60">Malaysia+(60)</asp:ListItem>
<asp:ListItem Value="+960">Maldives+(960)</asp:ListItem>
<asp:ListItem Value="+223">Mali+(223)</asp:ListItem>
<asp:ListItem Value="+356">Malta+(356)</asp:ListItem>
<asp:ListItem Value="+692">Marshall Islands+(692)</asp:ListItem>
<asp:ListItem Value="+222">Mauritania+(222)</asp:ListItem>
<asp:ListItem Value="+230">Mauritius+(230)</asp:ListItem>
<asp:ListItem Value="+262">Mayotte+(262)</asp:ListItem>
<asp:ListItem Value="+52">Mexico+(52)</asp:ListItem>
<asp:ListItem Value="+691">Micronesia+(691)</asp:ListItem>
<asp:ListItem Value="+373">Moldova+(373)</asp:ListItem>
<asp:ListItem Value="+377">Monaco+(377)</asp:ListItem>
<asp:ListItem Value="+976">Mongolia+(976)</asp:ListItem>
<asp:ListItem Value="+382">Montenegro+(382)</asp:ListItem>
<asp:ListItem Value="+1 664">Montserrat+(1 664)</asp:ListItem>
<asp:ListItem Value="+212">Morocco+(212)</asp:ListItem>
<asp:ListItem Value="+258">Mozambique+(258)</asp:ListItem>
<asp:ListItem Value="+264">Namibia+(264)</asp:ListItem>
<asp:ListItem Value="+674">Nauru+(674)</asp:ListItem>
<asp:ListItem Value="+977">Nepal+(977)</asp:ListItem>
<asp:ListItem Value="+31">Netherlands+(31)</asp:ListItem>
<asp:ListItem Value="+599">Netherlands Antilles+(599)</asp:ListItem>
<asp:ListItem Value="+687">New Caledonia+(687)</asp:ListItem>
<asp:ListItem Value="+64">New Zealand+(64)</asp:ListItem>
<asp:ListItem Value="+505">Nicaragua+(505)</asp:ListItem>
<asp:ListItem Value="+227">Niger+(227)</asp:ListItem>
<asp:ListItem Value="+234">Nigeria+(234)</asp:ListItem>
<asp:ListItem Value="+683">Niue+(683)</asp:ListItem>
<asp:ListItem Value="+672">Norfolk Island+(672)</asp:ListItem>
<asp:ListItem Value="+850">North Korea+(850)</asp:ListItem>
<asp:ListItem Value="+1 670">Northern Mariana Islands+(1 670)</asp:ListItem>
<asp:ListItem Value="+47">Norway+(47)</asp:ListItem>
<asp:ListItem Value="+968">Oman+(968)</asp:ListItem>
<asp:ListItem Value="+92">Pakistan+(92)</asp:ListItem>
<asp:ListItem Value="+680">Palau+(680)</asp:ListItem>
<asp:ListItem Value="+507">Panama+(507)</asp:ListItem>
<asp:ListItem Value="+675">Papua New Guinea+(675)</asp:ListItem>
<asp:ListItem Value="+595">Paraguay+(595)</asp:ListItem>
<asp:ListItem Value="+51">Peru+(51)</asp:ListItem>
<asp:ListItem Value="+63">Philippines+(63)</asp:ListItem>
<asp:ListItem Value="+870">Pitcairn Islands+(870)</asp:ListItem>
<asp:ListItem Value="+48">Poland+(48)</asp:ListItem>
<asp:ListItem Value="+351">Portugal+(351)</asp:ListItem>
<asp:ListItem Value="+1">Puerto Rico+(1)</asp:ListItem>
<asp:ListItem Value="+974">Qatar+(974)</asp:ListItem>
<asp:ListItem Value="+242">Republic of the Congo+(242)</asp:ListItem>
<asp:ListItem Value="+40">Romania+(40)</asp:ListItem>
<asp:ListItem Value="+7">Russia+(7)</asp:ListItem>
<asp:ListItem Value="+250">Rwanda+(250)</asp:ListItem>
<asp:ListItem Value="+590">Saint Barthelemy+(590)</asp:ListItem>
<asp:ListItem Value="+290">Saint Helena+(290)</asp:ListItem>
<asp:ListItem Value="+1 869">Saint Kitts and Nevis+(1 869)</asp:ListItem>
<asp:ListItem Value="+1 758">Saint Lucia+(1 758)</asp:ListItem>
<asp:ListItem Value="+1 599">Saint Martin+(1 599)</asp:ListItem>
<asp:ListItem Value="+508">Saint Pierre and Miquelon+(508)</asp:ListItem>
<asp:ListItem Value="+1 784">Saint Vincent and the Grenadines+(1 784)</asp:ListItem>
<asp:ListItem Value="+685">Samoa+(685)</asp:ListItem>
<asp:ListItem Value="+378">San Marino+(378)</asp:ListItem>
<asp:ListItem Value="+239">Sao Tome and Principe+(239)</asp:ListItem>
<asp:ListItem Value="+966">Saudi Arabia+(966)</asp:ListItem>
<asp:ListItem Value="+221">Senegal+(221)</asp:ListItem>
<asp:ListItem Value="+381">Serbia+(381)</asp:ListItem>
<asp:ListItem Value="+248">Seychelles+(248)</asp:ListItem>
<asp:ListItem Value="+232">Sierra Leone+(232)</asp:ListItem>
<asp:ListItem Value="+65">Singapore+(65)</asp:ListItem>
<asp:ListItem Value="+421">Slovakia+(421)</asp:ListItem>
<asp:ListItem Value="+386">Slovenia+(386)</asp:ListItem>
<asp:ListItem Value="+677">Solomon Islands+(677)</asp:ListItem>
<asp:ListItem Value="+252">Somalia+(252)</asp:ListItem>
<asp:ListItem Value="+27">South Africa+(27)</asp:ListItem>
<asp:ListItem Value="+82">South Korea+(82)</asp:ListItem>
<asp:ListItem Value="+34">Spain+(34)</asp:ListItem>
<asp:ListItem Value="+94">Sri Lanka+(94)</asp:ListItem>
<asp:ListItem Value="+249">Sudan+(249)</asp:ListItem>
<asp:ListItem Value="+597">Suriname+(597)</asp:ListItem>
<asp:ListItem Value="+">Svalbard+()</asp:ListItem>
<asp:ListItem Value="+268">Swaziland+(268)</asp:ListItem>
<asp:ListItem Value="+46">Sweden+(46)</asp:ListItem>
<asp:ListItem Value="+41">Switzerland+(41)</asp:ListItem>
<asp:ListItem Value="+963">Syria+(963)</asp:ListItem>
<asp:ListItem Value="+886">Taiwan+(886)</asp:ListItem>
<asp:ListItem Value="+992">Tajikistan+(992)</asp:ListItem>
<asp:ListItem Value="+255">Tanzania+(255)</asp:ListItem>
<asp:ListItem Value="+66">Thailand+(66)</asp:ListItem>
<asp:ListItem Value="+670">Timor-Leste+(670)</asp:ListItem>
<asp:ListItem Value="+228">Togo+(228)</asp:ListItem>
<asp:ListItem Value="+690">Tokelau+(690)</asp:ListItem>
<asp:ListItem Value="+676">Tonga+(676)</asp:ListItem>
<asp:ListItem Value="+1 868">Trinidad and Tobago+(1 868)</asp:ListItem>
<asp:ListItem Value="+216">Tunisia+(216)</asp:ListItem>
<asp:ListItem Value="+90">Turkey+(90)</asp:ListItem>
<asp:ListItem Value="+993">Turkmenistan+(993)</asp:ListItem>
<asp:ListItem Value="+1 649">Turks and Caicos Islands+(1 649)</asp:ListItem>
<asp:ListItem Value="+688">Tuvalu+(688)</asp:ListItem>
<asp:ListItem Value="+256">Uganda+(256)</asp:ListItem>
<asp:ListItem Value="+380">Ukraine+(380)</asp:ListItem>
<asp:ListItem Value="+971">United Arab Emirates+(971)</asp:ListItem>
<asp:ListItem Value="+44">United Kingdom+(44)</asp:ListItem>
<asp:ListItem Value="+1">United States+(1)</asp:ListItem>
<asp:ListItem Value="+598">Uruguay+(598)</asp:ListItem>
<asp:ListItem Value="+1 340">US Virgin Islands+(1 340)</asp:ListItem>
<asp:ListItem Value="+998">Uzbekistan+(998)</asp:ListItem>
<asp:ListItem Value="+678">Vanuatu+(678)</asp:ListItem>
<asp:ListItem Value="+58">Venezuela+(58)</asp:ListItem>
<asp:ListItem Value="+84">Vietnam+(84)</asp:ListItem>
<asp:ListItem Value="+681">Wallis and Futuna+(681)</asp:ListItem>
<asp:ListItem Value="+970">West Bank+(970)</asp:ListItem>
<asp:ListItem Value="+">Western Sahara+()</asp:ListItem>
<asp:ListItem Value="+967">Yemen+(967)</asp:ListItem>
<asp:ListItem Value="+260">Zambia+(260)</asp:ListItem>
<asp:ListItem Value="+263">Zimbabwe+(263)</asp:ListItem>

                </asp:DropDownList>
                <asp:TextBox ID="txtPhoneNumber" class="txtboxes" runat="server" 
                    MaxLength="30" ></asp:TextBox>
                <br />
                <asp:LinkButton ID="lbtnAddPhoneNumber" runat="server" 
                    style="font-size: xx-small" onclick="lbtnAddPhoneNumber_Click">Add Phone Number</asp:LinkButton>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtPhoneNumber" ErrorMessage="Only Number Entered" 
            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>   <br />
                       <br />
                <asp:GridView ID="GridViewPhone" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" OnRowUpdating="GridViewPhone_OnRowUpdating"  
                     GridLines="None" ShowHeader="False" 
                    HorizontalAlign="Left">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:DropDownList ID="lstCountryCode" runat="server">
                                   <asp:ListItem Value="+93">Afghanistan+(93)</asp:ListItem>
<asp:ListItem Value="+355">Albania+(355)</asp:ListItem>
<asp:ListItem Value="+213">Algeria+(213)</asp:ListItem>
<asp:ListItem Value="+1 684">American Samoa+(1684)</asp:ListItem>
<asp:ListItem Value="+376">Andorra+(376)</asp:ListItem>
<asp:ListItem Value="+244">Angola+(244)</asp:ListItem>
<asp:ListItem Value="+1 264">Anguilla+(1 264)</asp:ListItem>
<asp:ListItem Value="+672">Antarctica+(672)</asp:ListItem>
<asp:ListItem Value="+1 268">Antigua and Barbuda+(1268)</asp:ListItem>
<asp:ListItem Value="+54">Argentina+(54)</asp:ListItem>
<asp:ListItem Value="+374">Armenia+(374)</asp:ListItem>
<asp:ListItem Value="+297">Aruba+(297)</asp:ListItem>
<asp:ListItem Value="+61">Australia+(61)</asp:ListItem>
<asp:ListItem Value="+43">Austria+(43)</asp:ListItem>
<asp:ListItem Value="+994">Azerbaijan+(994)</asp:ListItem>
<asp:ListItem Value="+1 242">Bahamas+(1242)</asp:ListItem>
<asp:ListItem Value="+973">Bahrain+(973)</asp:ListItem>
<asp:ListItem Value="+880">Bangladesh+(880)</asp:ListItem>
<asp:ListItem Value="+1 246">Barbados+(1246)</asp:ListItem>
<asp:ListItem Value="+375">Belarus+(375)</asp:ListItem>
<asp:ListItem Value="+32">Belgium+(32)</asp:ListItem>
<asp:ListItem Value="+501">Belize+(501)</asp:ListItem>
<asp:ListItem Value="+229">Benin+(229)</asp:ListItem>
<asp:ListItem Value="+1 441">Bermuda+(1441)</asp:ListItem>
<asp:ListItem Value="+975">Bhutan+(975)</asp:ListItem>
<asp:ListItem Value="+591">Bolivia+(591)</asp:ListItem>
<asp:ListItem Value="+387">Bosnia and Herzegovina+(387)</asp:ListItem>
<asp:ListItem Value="+267">Botswana+(267)</asp:ListItem>
<asp:ListItem Value="+55">Brazil+(55)</asp:ListItem>
<asp:ListItem Value="+">British Indian Ocean Territory+()</asp:ListItem>
<asp:ListItem Value="+1 284">British Virgin Islands+(1 284)</asp:ListItem>
<asp:ListItem Value="+673">Brunei+(673)</asp:ListItem>
<asp:ListItem Value="+359">Bulgaria+(359)</asp:ListItem>
<asp:ListItem Value="+226">Burkina Faso+(226)</asp:ListItem>
<asp:ListItem Value="+95">Burma (Myanmar)+(95)</asp:ListItem>
<asp:ListItem Value="+257">Burundi+(257)</asp:ListItem>
<asp:ListItem Value="+855">Cambodia+(855)</asp:ListItem>
<asp:ListItem Value="+237">Cameroon+(237)</asp:ListItem>
<asp:ListItem Value="+1">Canada+(1)</asp:ListItem>
<asp:ListItem Value="+238">Cape Verde+(238)</asp:ListItem>
<asp:ListItem Value="+1 345">Cayman Islands+(1 345)</asp:ListItem>
<asp:ListItem Value="+236">Central African Republic+(236)</asp:ListItem>
<asp:ListItem Value="+235">Chad+(235)</asp:ListItem>
<asp:ListItem Value="+56">Chile+(56)</asp:ListItem>
<asp:ListItem Value="+86">China+(86)</asp:ListItem>
<asp:ListItem Value="+61">Christmas Island+(61)</asp:ListItem>
<asp:ListItem Value="+61">Cocos (Keeling) Islands+(61)</asp:ListItem>
<asp:ListItem Value="+57">Colombia+(57)</asp:ListItem>
<asp:ListItem Value="+269">Comoros+(269)</asp:ListItem>
<asp:ListItem Value="+682">Cook Islands+(682)</asp:ListItem>
<asp:ListItem Value="+506">Costa Rica+(506)</asp:ListItem>
<asp:ListItem Value="+385">Croatia+(385)</asp:ListItem>
<asp:ListItem Value="+53">Cuba+(53)</asp:ListItem>
<asp:ListItem Value="+357">Cyprus+(357)</asp:ListItem>
<asp:ListItem Value="+420">Czech Republic+(420)</asp:ListItem>
<asp:ListItem Value="+243">Democratic Republic of the Congo+(243)</asp:ListItem>
<asp:ListItem Value="+45">Denmark+(45)</asp:ListItem>
<asp:ListItem Value="+253">Djibouti+(253)</asp:ListItem>
<asp:ListItem Value="+1 767">Dominica+(1 767)</asp:ListItem>
<asp:ListItem Value="+1 809">Dominican Republic+(1 809)</asp:ListItem>
<asp:ListItem Value="+593">Ecuador+(593)</asp:ListItem>
<asp:ListItem Value="+20">Egypt+(20)</asp:ListItem>
<asp:ListItem Value="+503">El Salvador+(503)</asp:ListItem>
<asp:ListItem Value="+240">Equatorial Guinea+(240)</asp:ListItem>
<asp:ListItem Value="+291">Eritrea+(291)</asp:ListItem>
<asp:ListItem Value="+372">Estonia+(372)</asp:ListItem>
<asp:ListItem Value="+251">Ethiopia+(251)</asp:ListItem>
<asp:ListItem Value="+500">Falkland Islands+(500)</asp:ListItem>
<asp:ListItem Value="+298">Faroe Islands+(298)</asp:ListItem>
<asp:ListItem Value="+679">Fiji+(679)</asp:ListItem>
<asp:ListItem Value="+358">Finland+(358)</asp:ListItem>
<asp:ListItem Value="+33">France+(33)</asp:ListItem>
<asp:ListItem Value="+689">French Polynesia+(689)</asp:ListItem>
<asp:ListItem Value="+241">Gabon+(241)</asp:ListItem>
<asp:ListItem Value="+220">Gambia+(220)</asp:ListItem>
<asp:ListItem Value="+970">Gaza Strip+(970)</asp:ListItem>
<asp:ListItem Value="+995">Georgia+(995)</asp:ListItem>
<asp:ListItem Value="+49">Germany+(49)</asp:ListItem>
<asp:ListItem Value="+233">Ghana+(233)</asp:ListItem>
<asp:ListItem Value="+350">Gibraltar+(350)</asp:ListItem>
<asp:ListItem Value="+30">Greece+(30)</asp:ListItem>
<asp:ListItem Value="+299">Greenland+(299)</asp:ListItem>
<asp:ListItem Value="+1 473">Grenada+(1 473)</asp:ListItem>
<asp:ListItem Value="+1 671">Guam+(1 671)</asp:ListItem>
<asp:ListItem Value="+502">Guatemala+(502)</asp:ListItem>
<asp:ListItem Value="+224">Guinea+(224)</asp:ListItem>
<asp:ListItem Value="+245">Guinea-Bissau+(245)</asp:ListItem>
<asp:ListItem Value="+592">Guyana+(592)</asp:ListItem>
<asp:ListItem Value="+509">Haiti+(509)</asp:ListItem>
<asp:ListItem Value="+39">Holy See (Vatican City)+(39)</asp:ListItem>
<asp:ListItem Value="+504">Honduras+(504)</asp:ListItem>
<asp:ListItem Value="+852">Hong Kong+(852)</asp:ListItem>
<asp:ListItem Value="+36">Hungary+(36)</asp:ListItem>
<asp:ListItem Value="+354">Iceland+(354)</asp:ListItem>
<asp:ListItem Value="+91">India+(91)</asp:ListItem>
<asp:ListItem Value="+62">Indonesia+(62)</asp:ListItem>
<asp:ListItem Value="+98">Iran+(98)</asp:ListItem>
<asp:ListItem Value="+964">Iraq+(964)</asp:ListItem>
<asp:ListItem Value="+353">Ireland+(353)</asp:ListItem>
<asp:ListItem Value="+44">Isle of Man+(44)</asp:ListItem>
<asp:ListItem Value="+972">Israel+(972)</asp:ListItem>
<asp:ListItem Value="+39">Italy+(39)</asp:ListItem>
<asp:ListItem Value="+225">Ivory Coast+(225)</asp:ListItem>
<asp:ListItem Value="+1 876">Jamaica+(1 876)</asp:ListItem>
<asp:ListItem Value="+81">Japan+(81)</asp:ListItem>
<asp:ListItem Value="+">Jersey+()</asp:ListItem>
<asp:ListItem Value="+962">Jordan+(962)</asp:ListItem>
<asp:ListItem Value="+7">Kazakhstan+(7)</asp:ListItem>
<asp:ListItem Value="+254">Kenya+(254)</asp:ListItem>
<asp:ListItem Value="+686">Kiribati+(686)</asp:ListItem>
<asp:ListItem Value="+381">Kosovo+(381)</asp:ListItem>
<asp:ListItem Value="+965">Kuwait+(965)</asp:ListItem>
<asp:ListItem Value="+996">Kyrgyzstan+(996)</asp:ListItem>
<asp:ListItem Value="+856">Laos+(856)</asp:ListItem>
<asp:ListItem Value="+371">Latvia+(371)</asp:ListItem>
<asp:ListItem Value="+961">Lebanon+(961)</asp:ListItem>
<asp:ListItem Value="+266">Lesotho+(266)</asp:ListItem>
<asp:ListItem Value="+231">Liberia+(231)</asp:ListItem>
<asp:ListItem Value="+218">Libya+(218)</asp:ListItem>
<asp:ListItem Value="+423">Liechtenstein+(423)</asp:ListItem>
<asp:ListItem Value="+370">Lithuania+(370)</asp:ListItem>
<asp:ListItem Value="+352">Luxembourg+(352)</asp:ListItem>
<asp:ListItem Value="+853">Macau+(853)</asp:ListItem>
<asp:ListItem Value="+389">Macedonia+(389)</asp:ListItem>
<asp:ListItem Value="+261">Madagascar+(261)</asp:ListItem>
<asp:ListItem Value="+265">Malawi+(265)</asp:ListItem>
<asp:ListItem Value="+60">Malaysia+(60)</asp:ListItem>
<asp:ListItem Value="+960">Maldives+(960)</asp:ListItem>
<asp:ListItem Value="+223">Mali+(223)</asp:ListItem>
<asp:ListItem Value="+356">Malta+(356)</asp:ListItem>
<asp:ListItem Value="+692">Marshall Islands+(692)</asp:ListItem>
<asp:ListItem Value="+222">Mauritania+(222)</asp:ListItem>
<asp:ListItem Value="+230">Mauritius+(230)</asp:ListItem>
<asp:ListItem Value="+262">Mayotte+(262)</asp:ListItem>
<asp:ListItem Value="+52">Mexico+(52)</asp:ListItem>
<asp:ListItem Value="+691">Micronesia+(691)</asp:ListItem>
<asp:ListItem Value="+373">Moldova+(373)</asp:ListItem>
<asp:ListItem Value="+377">Monaco+(377)</asp:ListItem>
<asp:ListItem Value="+976">Mongolia+(976)</asp:ListItem>
<asp:ListItem Value="+382">Montenegro+(382)</asp:ListItem>
<asp:ListItem Value="+1 664">Montserrat+(1 664)</asp:ListItem>
<asp:ListItem Value="+212">Morocco+(212)</asp:ListItem>
<asp:ListItem Value="+258">Mozambique+(258)</asp:ListItem>
<asp:ListItem Value="+264">Namibia+(264)</asp:ListItem>
<asp:ListItem Value="+674">Nauru+(674)</asp:ListItem>
<asp:ListItem Value="+977">Nepal+(977)</asp:ListItem>
<asp:ListItem Value="+31">Netherlands+(31)</asp:ListItem>
<asp:ListItem Value="+599">Netherlands Antilles+(599)</asp:ListItem>
<asp:ListItem Value="+687">New Caledonia+(687)</asp:ListItem>
<asp:ListItem Value="+64">New Zealand+(64)</asp:ListItem>
<asp:ListItem Value="+505">Nicaragua+(505)</asp:ListItem>
<asp:ListItem Value="+227">Niger+(227)</asp:ListItem>
<asp:ListItem Value="+234">Nigeria+(234)</asp:ListItem>
<asp:ListItem Value="+683">Niue+(683)</asp:ListItem>
<asp:ListItem Value="+672">Norfolk Island+(672)</asp:ListItem>
<asp:ListItem Value="+850">North Korea+(850)</asp:ListItem>
<asp:ListItem Value="+1 670">Northern Mariana Islands+(1 670)</asp:ListItem>
<asp:ListItem Value="+47">Norway+(47)</asp:ListItem>
<asp:ListItem Value="+968">Oman+(968)</asp:ListItem>
<asp:ListItem Value="+92">Pakistan+(92)</asp:ListItem>
<asp:ListItem Value="+680">Palau+(680)</asp:ListItem>
<asp:ListItem Value="+507">Panama+(507)</asp:ListItem>
<asp:ListItem Value="+675">Papua New Guinea+(675)</asp:ListItem>
<asp:ListItem Value="+595">Paraguay+(595)</asp:ListItem>
<asp:ListItem Value="+51">Peru+(51)</asp:ListItem>
<asp:ListItem Value="+63">Philippines+(63)</asp:ListItem>
<asp:ListItem Value="+870">Pitcairn Islands+(870)</asp:ListItem>
<asp:ListItem Value="+48">Poland+(48)</asp:ListItem>
<asp:ListItem Value="+351">Portugal+(351)</asp:ListItem>
<asp:ListItem Value="+1">Puerto Rico+(1)</asp:ListItem>
<asp:ListItem Value="+974">Qatar+(974)</asp:ListItem>
<asp:ListItem Value="+242">Republic of the Congo+(242)</asp:ListItem>
<asp:ListItem Value="+40">Romania+(40)</asp:ListItem>
<asp:ListItem Value="+7">Russia+(7)</asp:ListItem>
<asp:ListItem Value="+250">Rwanda+(250)</asp:ListItem>
<asp:ListItem Value="+590">Saint Barthelemy+(590)</asp:ListItem>
<asp:ListItem Value="+290">Saint Helena+(290)</asp:ListItem>
<asp:ListItem Value="+1 869">Saint Kitts and Nevis+(1 869)</asp:ListItem>
<asp:ListItem Value="+1 758">Saint Lucia+(1 758)</asp:ListItem>
<asp:ListItem Value="+1 599">Saint Martin+(1 599)</asp:ListItem>
<asp:ListItem Value="+508">Saint Pierre and Miquelon+(508)</asp:ListItem>
<asp:ListItem Value="+1 784">Saint Vincent and the Grenadines+(1 784)</asp:ListItem>
<asp:ListItem Value="+685">Samoa+(685)</asp:ListItem>
<asp:ListItem Value="+378">San Marino+(378)</asp:ListItem>
<asp:ListItem Value="+239">Sao Tome and Principe+(239)</asp:ListItem>
<asp:ListItem Value="+966">Saudi Arabia+(966)</asp:ListItem>
<asp:ListItem Value="+221">Senegal+(221)</asp:ListItem>
<asp:ListItem Value="+381">Serbia+(381)</asp:ListItem>
<asp:ListItem Value="+248">Seychelles+(248)</asp:ListItem>
<asp:ListItem Value="+232">Sierra Leone+(232)</asp:ListItem>
<asp:ListItem Value="+65">Singapore+(65)</asp:ListItem>
<asp:ListItem Value="+421">Slovakia+(421)</asp:ListItem>
<asp:ListItem Value="+386">Slovenia+(386)</asp:ListItem>
<asp:ListItem Value="+677">Solomon Islands+(677)</asp:ListItem>
<asp:ListItem Value="+252">Somalia+(252)</asp:ListItem>
<asp:ListItem Value="+27">South Africa+(27)</asp:ListItem>
<asp:ListItem Value="+82">South Korea+(82)</asp:ListItem>
<asp:ListItem Value="+34">Spain+(34)</asp:ListItem>
<asp:ListItem Value="+94">Sri Lanka+(94)</asp:ListItem>
<asp:ListItem Value="+249">Sudan+(249)</asp:ListItem>
<asp:ListItem Value="+597">Suriname+(597)</asp:ListItem>
<asp:ListItem Value="+">Svalbard+()</asp:ListItem>
<asp:ListItem Value="+268">Swaziland+(268)</asp:ListItem>
<asp:ListItem Value="+46">Sweden+(46)</asp:ListItem>
<asp:ListItem Value="+41">Switzerland+(41)</asp:ListItem>
<asp:ListItem Value="+963">Syria+(963)</asp:ListItem>
<asp:ListItem Value="+886">Taiwan+(886)</asp:ListItem>
<asp:ListItem Value="+992">Tajikistan+(992)</asp:ListItem>
<asp:ListItem Value="+255">Tanzania+(255)</asp:ListItem>
<asp:ListItem Value="+66">Thailand+(66)</asp:ListItem>
<asp:ListItem Value="+670">Timor-Leste+(670)</asp:ListItem>
<asp:ListItem Value="+228">Togo+(228)</asp:ListItem>
<asp:ListItem Value="+690">Tokelau+(690)</asp:ListItem>
<asp:ListItem Value="+676">Tonga+(676)</asp:ListItem>
<asp:ListItem Value="+1 868">Trinidad and Tobago+(1 868)</asp:ListItem>
<asp:ListItem Value="+216">Tunisia+(216)</asp:ListItem>
<asp:ListItem Value="+90">Turkey+(90)</asp:ListItem>
<asp:ListItem Value="+993">Turkmenistan+(993)</asp:ListItem>
<asp:ListItem Value="+1 649">Turks and Caicos Islands+(1 649)</asp:ListItem>
<asp:ListItem Value="+688">Tuvalu+(688)</asp:ListItem>
<asp:ListItem Value="+256">Uganda+(256)</asp:ListItem>
<asp:ListItem Value="+380">Ukraine+(380)</asp:ListItem>
<asp:ListItem Value="+971">United Arab Emirates+(971)</asp:ListItem>
<asp:ListItem Value="+44">United Kingdom+(44)</asp:ListItem>
<asp:ListItem Value="+1">United States+(1)</asp:ListItem>
<asp:ListItem Value="+598">Uruguay+(598)</asp:ListItem>
<asp:ListItem Value="+1 340">US Virgin Islands+(1 340)</asp:ListItem>
<asp:ListItem Value="+998">Uzbekistan+(998)</asp:ListItem>
<asp:ListItem Value="+678">Vanuatu+(678)</asp:ListItem>
<asp:ListItem Value="+58">Venezuela+(58)</asp:ListItem>
<asp:ListItem Value="+84">Vietnam+(84)</asp:ListItem>
<asp:ListItem Value="+681">Wallis and Futuna+(681)</asp:ListItem>
<asp:ListItem Value="+970">West Bank+(970)</asp:ListItem>
<asp:ListItem Value="+">Western Sahara+()</asp:ListItem>
<asp:ListItem Value="+967">Yemen+(967)</asp:ListItem>
<asp:ListItem Value="+260">Zambia+(260)</asp:ListItem>
<asp:ListItem Value="+263">Zimbabwe+(263)</asp:ListItem>

                                </asp:DropDownList>
                                <asp:TextBox ID="txtGPhoneNumber" class="txtboxes" runat="server" 
                                    Text='<%# EvalPhoneNumber("Name") %>'></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtGPhoneNumber" ErrorMessage="Only Number Entered" 
                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" 
                                    ImageUrl="~/Resources/images/Icon/DeleteSmall.png" />
                            </ItemTemplate>
                            <ItemStyle Font-Size="8pt" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>

      <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
           <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>


        <tr>
            <td >
                </td>
            <td class="style5">
                Mobile Alert:</td>
            <td>
                <asp:CheckBox ID="cbxMobileAlert" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Address:</td>
            <td class="style2"> 
                <asp:TextBox  class="txtboxes" ID="txtAddress" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Town/Ciy:</td>
            <td class="style2">
                <asp:TextBox  class="txtboxes" ID="txtTownCity" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Zip Code:</td>
            <td class="style2">
                <asp:TextBox  ID="txtZipCode" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Neighbourhood:</td>
            <td class="style2">
                  <asp:TextBox  ID="txtNeighbourhood" runat="server" Width="300px" 
                    MaxLength="45"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>
           <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        


        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                Websites:</td>
            <td class="style2">
                <asp:TextBox class="txtboxes" ID="txtWebsites" runat="server" MaxLength="45" ></asp:TextBox>
                <asp:LinkButton ID="lbtnAddWebsites" runat="server" style="font-size: xx-small" 
                    onclick="lbtnAddWebsites_Click">Add Websites</asp:LinkButton>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtWebsites" Display="Dynamic" 
                    ErrorMessage="URL must be correct format" 
                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                <br />
                <asp:GridView ID="GridViewWebsites" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" DataKeyNames="_Id" 
                   GridLines="None" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGridURL" runat="server" 
                                    Text='<%# Bind("Name") %>'></asp:TextBox>
                                <br />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtGridURL" Display="None" 
                                    ErrorMessage="Website url must be correct format" 
                                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                &nbsp;
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True">
                        <ItemStyle Font-Size="8pt" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" 
                                    ImageUrl="~/Resources/images/Icon/DeleteSmall.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
           <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <hr /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save Changes" 
                    onclick="btnSave_Click" />
            </td>
            <td>
                <asp:Image ID="imgSave" runat="server" ImageUrl="~/Resources/images/Icon/check.png" 
                    Visible="False" />
                <asp:Label ID="lblSave" runat="server" Text="Save changes is successful" 
                    ForeColor="#006600" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

