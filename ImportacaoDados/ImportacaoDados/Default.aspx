<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportacaoDados._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <html>
            <head>
                <title>Importação de dados</title>
            </head>
            <body>
                <h3>Arquivo</h3>
                <INPUT id="oFile" type="file" runat="server" NAME="oFile">
                <asp:button id="btnUpload" type="submit" text="Upload" runat="server"></asp:button>

            </body>
        </html>

        <script type="text/javascript">
            function openfileDialog() {
                    document.getElementById("FileLoader").click();
            }

        </script>
    </div>
</asp:Content>
