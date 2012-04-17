<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CompanyPhones._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align ="center" style="height: 67px" >
    <br/>
    <asp:Label Text = "Select Company" runat = "server"></asp:Label>
     <br/> <br />
    <asp:DropDownList ID="dropCompany" runat="server" Height="25px" Width="225px" 
            OnSelectedIndexChanged = "Selected_Change" 
            ontextchanged="dropCompany_TextChanged" AutoPostBack = "true">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label2" Text = "Select Company Agent" runat = "server" Visible = "false"></asp:Label>
    <br/> <br />
    <asp:DropDownList ID="dropAgent" runat="server" Height="25px" Width="225px" OnSelectedIndexChanged = "Selected_ChangeInAgent"
    AutoPostBack = "true">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label3" Text = "Change Agent PhoneNumber" runat = "server" Visible = "false"></asp:Label>
    <br />
    
        <asp:Label ID="Label4" runat="server" Text="" Visible = "false"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtPhone" runat="server" Width="177px" Visible = "false"></asp:TextBox>
    <br />
     <asp:Button ID="btnChange" runat="server" Height="24px" Text="Updated"  onclick="btnUpdate_Click"/>
    </div>
       
    </form>

</body>
</html>
