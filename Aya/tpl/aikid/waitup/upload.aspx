<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="tpl_aikid_waitup_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="file" runat="server" /><asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
            <asp:Label ID="lb_error" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
