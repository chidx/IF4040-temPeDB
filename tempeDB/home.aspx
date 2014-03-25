<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="tempeDB.home" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center><h1>TempE_db</h1></center>
        <br />
        <br />
        <table>
            <tr>
                <td style="width:150px">

                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="Medium" Text="Query" Font-Bold="True">
                    </dx:ASPxLabel>

                </td>
                <td style="width:600px">

                    <dx:ASPxTextBox ID="queryTextBox" runat="server" Width="600px" AutoResizeWithContainer="True" Height="200px">
                    </dx:ASPxTextBox>

                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td style="text-align:right">

                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit">
                    </dx:ASPxButton>

                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>

                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="text-align:center; width:750px">
                    <h3>Result</h3>
                </td>
            </tr>
            <tr>
                <td style="width:750px">

                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
