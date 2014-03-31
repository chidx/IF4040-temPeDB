<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="tempeDB.home" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width:750px; text-align:center">
                    <h1>tempeDB</h1>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:150px">

                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="Medium" Text="Query" Font-Bold="True">
                    </dx:ASPxLabel>

                </td>
                <td style="width:600px; vertical-align:top">

                    <dx:ASPxMemo ID="queryTextBox" runat="server" Height="100px" Width="600px">
                    </dx:ASPxMemo>

                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td style="text-align:right">

                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit" OnClick="ASPxButton1_Click">
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

                    <dx:ASPxPanel ID="panel1" runat="server" Height="300px" Width="755px">
                        <Paddings PaddingLeft="260px" />
                        <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True"></dx:PanelContent>
</PanelCollection>
                    </dx:ASPxPanel>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </body>
</html>
