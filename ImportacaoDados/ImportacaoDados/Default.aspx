<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImportacaoDados._Default" %>

<%@ Import Namespace="Importador.Models" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Importação de dados</title>

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.15/jquery.mask.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    </head>
    <body>
        <div class="divPopUpRound" style="width: 1200px;">
            <div class="divPopUpRoundTitle">
                <asp:Label ID="Label5" runat="server" Text="IMPORTAÇÃO DE DADOS"></asp:Label>

                <div style="float: right;" class="fecharIFrame">
                </div>
            </div>
        </div>
        <div class="div-tab divBorder spaceBottom10px" id="divB" runat="server" style="width: 1200px;">
            <div class="div-cad-tab spaceBottom10px">
                <div class="div-tab-cad-row">
                    <div class="div-tab-cad-cell" style="width: 100px; padding-left: 10px">
                        <span runat="server" id="Span1">Arquivo</span>
                    </div>
                    <div class="div-tab-cad-cell" style="width: 500px; padding-left: 10px">
                        <asp:FileUpload ID="Upload" runat="server" />
                        <%--<INPUT id="oFile" type="file" runat="server" NAME="oFile">--%>
                    </div>
                    <div class="div-tab-cad-cell">
                        <asp:Button ID="btnUpload" type="submit" Text="Importar" runat="server" OnClick="btnUpload_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <div class="div-tab">
            <div class="divPopUpRound" style="width: 1200px;">
                <div class="divPopUpRoundTitle">
                    <asp:Label ID="lblTitulo" runat="server" Text="LISTA DE IMPORTAÇÕES PERÍODO"></asp:Label>
                </div>
                <div class="divPopUpRoundContent" style="width: 1200px;">

                    <asp:Panel ID="pnFiltro" runat="server" CssClass="content" >
                        <div class="div-tab">
                            <div class="div-tab-cad">
                                <div class="div-tab">
                                    <div class="div-tab-cad-row" style="flex-wrap: wrap; max-height: 40px; height: auto;">
                                        <div class="div-tab-cad-cell ellipsis" style="width: 150px;">
                                            <asp:Label runat="server" Text="Período: " Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="div-tab-cad-cell" style="width: 100px;">
                                            <asp:TextBox ID="DataInicio" runat="server" MaxLength="10" Width="90px" CssClass="form-control" Style='display: inline;'
                                                onkeypress="$(this).mask('00/00/0000')" ></asp:TextBox>
                                        </div>

                                        <div class="div-tab-cad-cell ellipsis" style="width: 20px; padding-left: 10px;">
                                            <asp:Label runat="server" Text="a" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div class="div-tab-cad-cell" style="width: 100px;">
                                            <asp:TextBox ID="DataFim" runat="server" MaxLength="10" Width="90px" CssClass="form-control" Style='display: inline;'
                                                onkeypress="$(this).mask('00/00/0000')"></asp:TextBox>
                                        </div>


                                        <div class="div-tab-cad-cell" style="width: 100px; margin-left: 15px;">
                                            <asp:LinkButton ID="lnkFiltrar" runat="server" Style="float: right;" Text="Filtrar" CssClass="but but-primary but-rc" OnClick="lnkFiltrar_Click"></asp:LinkButton>
                                        </div>

                                        <div class="div-tab-cad-cell">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="divPanelRound" style="width: 1150px;">
                        <div class="divPanelRoundContent">
                            <asp:GridView ID="gvDados" runat="server" AllowPaging="True" CellPadding="0"
                                BorderStyle="None" BorderWidth="0px" AutoGenerateColumns="False" Width="100%"
                                GridLines="None" AllowSorting="True" ShowFooter="true"
                                CssClass="tabela_dados_grh tblEllipsis" DisableEllipsis="true" DescHeaderGV="" ShowCustomHeader="False"
                                DisableDefaultStyle="true" ShowCustomPaging="True" EnableRowSelect="false" EnableSearchEx="false">
                                <HeaderStyle BorderStyle="None" CssClass="bg_sub_titulo_transparente" Font-Size="8px"></HeaderStyle>
                                <RowStyle Height="20px"></RowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div class="div-tab-cad">
                                                <div class="div-tab-cad-row">
                                                    <div class="div-tab-cad-cell" style="width: 100px; text-align: center; border: solid;">
                                                        <asp:Label ID="lblDataImport" Font-Bold="true" runat="server" Text="Data Importação"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 200px; text-align: left; border: solid;">
                                                        <asp:Label ID="lblNomeComprador" Font-Bold="true" runat="server" Text="Nome Comprador"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 200px; text-align: left; border: solid;">
                                                        <asp:Label ID="lblDescricaoItem" Font-Bold="true" runat="server" Text="Descrição Item"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 100px; text-align: center; border: solid;">
                                                        <asp:Label ID="lblQuantidade" Font-Bold="true" runat="server" Text="Quantidade"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 100px; text-align: right; border: solid; padding-right: 5px;">
                                                        <asp:Label ID="lblValor" Font-Bold="true" runat="server" Text="Valor"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 200px; text-align: left; border: solid; padding-left: 10px;">
                                                        <asp:Label ID="lblEndereco" Font-Bold="true" runat="server" Text="Endereco"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell" style="width: 200px; text-align: left; border: solid;">
                                                        <asp:Label ID="lblFornecedor" Font-Bold="true" runat="server" Text="Fornecedor"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell">
                                                    </div>
                                                </div>
                                            </div>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="div-tab-cad">
                                                <div class="div-tab-cad-row">

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 100px; text-align: center;">
                                                        <asp:Label ID="lblData" runat="server" Text='<%# (Container.DataItem as EntradasModel).DataImportacao.ToString("dd/MM/yyyy") %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lblComprador" runat="server" Text='<%# (Container.DataItem as EntradasModel).NomeComprador %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lblItem" runat="server" Text='<%# (Container.DataItem as EntradasModel).DescricaoItem %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 100px; text-align: center;">
                                                        <asp:Label ID="lblQtda" runat="server" Text='<%# (Container.DataItem as EntradasModel).Quantidade %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 100px; text-align: right; padding-right: 5px;">
                                                        <asp:Label ID="lblVal" runat="server" Text='<%# string.Format("{0:C2}",(Container.DataItem as EntradasModel).Valor) %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left; padding-left: 10px;">
                                                        <asp:Label ID="lblEnder" runat="server" Text='<%# (Container.DataItem as EntradasModel).Endereco %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lblFornce" runat="server" Text='<%# (Container.DataItem as EntradasModel).NomeFornecedor %>'></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis">
                                                    </div>

                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <hr />
                                            <div class="div-tab-cad">
                                                <div class="div-tab-cad-row bor">
                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left; padding-left: 3px;">
                                                        <asp:Label ID="Label1" runat="server" Text='Quantidade Total' Font-Bold="true"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 50px; text-align: center;">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# GetSomaQuantidade() %>' Font-Bold="true"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 200px; text-align: left; padding-left: 3px;">
                                                        <asp:Label ID="Label3" runat="server" Text='Valor Total' Font-Bold="true"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis" style="width: 100px; text-align: center;">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# string.Format("{0:C2}", GetValorTotal()) %>' Font-Bold="true"></asp:Label>
                                                    </div>

                                                    <div class="div-tab-cad-cell ellipsis">
                                                    </div>

                                                </div>
                                            </div>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </body>
    </html>
    <script language="JavaScript" type="text/javascript">
        function mascaraData(campoData) {
            var data = campoData.value;
            if (data.length == 2) {
                data = data + '/';
                document.forms[0].data.value = data;
                return true;
            }
            if (data.length == 5) {
                data = data + '/';
                document.forms[0].data.value = data;
                return true;
            }
        }
    </script>

</asp:Content>
