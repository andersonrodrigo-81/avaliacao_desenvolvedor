<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportacaoDados._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
        .div-cad {
            width: 98%;
            margin: 0 auto;
            text-align: left;
        }

        .div-tab-cad {
            display: table;
            width: 100%;
            table-layout: fixed;
        }

        .div-tab-cad-row {
            display: table-row;
            height: 20px;
        }

        .div-tab-cad-cell {
            display: table-cell;
            vertical-align: middle;
            padding-bottom: 2px;
        }

        .div-tab-cad-rodape {
            display: table;
            width: 100%;
            margin-top: 15px;
        }

        .spaceBottom5px {
            margin-bottom: 5px;
        }

        .spaceBottom10px {
            margin-bottom: 10px;
        }

        .spaceTop5px {
            margin-top: 5px;
        }

        .spaceTop10px {
            margin-top: 10px;
        }

        .divBorder {
            padding: 5px;
            -moz-border-radius: 6px 6px 6px 6px;
            border-radius: 6px 6px 6px 6px; /* standards-compliant: (IE) */
            border: 1px solid silver;
            /*border-color: rgba(51, 88, 123, 0.8);*/
            background-color: white;
        }
    </style>
    <div>
        <html>
            <head>
                <title>Importação de dados</title>
            </head>
            <body>
                <div class="div-tab divBorder spaceBottom10px" id="divB" runat="server">
                    <div class="div-cad-tab spaceBottom10px">
                        <div class="div-tab-cad-row">
                            <div class="div-tab-cad-cell" style="width: 100px; padding-left: 10px">
                                <span runat="server" id="Span1">Arquivo</span>
                            </div>
                            <div class="div-tab-cad-cell" style="width: 500px; padding-left: 10px">
                                <INPUT id="oFile" type="file" runat="server" NAME="oFile">
                            </div>
                            <div class="div-tab-cad-cell">
                                <asp:button id="btnUpload" type="submit" text="Carregar" runat="server"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
            </body>
        </html>

    </div>
</asp:Content>
