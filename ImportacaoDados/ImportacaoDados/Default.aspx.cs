using ImportacaoDados.Services;
using ImportacaoDados.ViewModel;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImportacaoDados
{
    public partial class _Default : Page
    {
        private int _SomaQuantidade;
        private Decimal _SomaTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataInicio.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                DataFim.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                BindGrid();
            }
        }

        private void BindGrid()
        {
            EntradasModel model = new EntradasModel();

            DateTime.TryParse(DataInicio.Text, out DateTime pDtI);
            DateTime.TryParse(DataFim.Text, out DateTime pDtF);
            model.DataInicio = pDtI;
            model.DataFim = pDtF;

            using (EntradasService svc = new EntradasService())
            {
                var result = svc.ObterDados(model);

                if (result.Count > 0)
                {
                    
                    _SomaTotal = result.Sum(s => s.Valor);
                    _SomaQuantidade = result.Sum(s => s.Quantidade);

                    gvDados.PageSize = result.Count;
                    gvDados.DataSource = result;
                    gvDados.DataBind();
                }
            }
            
            
        }

        protected int GetSomaQuantidade()
        {
            return _SomaQuantidade;
        }

        protected Decimal GetValorTotal()
        {
            return _SomaTotal;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory;
            string nomeArquivo = Upload.PostedFile.FileName;

            if (!string.IsNullOrEmpty(nomeArquivo))
            {
                string caminhoCompleto = caminhoArquivo + nomeArquivo;

                Upload.SaveAs(caminhoCompleto);


                string[] linhas = File.ReadAllLines(caminhoCompleto);

                List<ImportacaoViewModel> listaImportadaVm = new List<ImportacaoViewModel>();

                for (int i = 1; i < linhas.Count(); i++)
                {
                    string[] conteudo = linhas[i].Split('\t');

                    ImportacaoViewModel linha = new ImportacaoViewModel();

                    linha.NomeComprador = conteudo[0].ToString();
                    linha.NomeItem = conteudo[1].ToString();

                    Decimal.TryParse(conteudo[2].ToString(), out decimal pValor);
                    linha.Valor = pValor;

                    int.TryParse(conteudo[3].ToString(), out int pQtd);
                    linha.Quantidade = pQtd;

                    linha.NomeEndereco = conteudo[4].ToString();
                    linha.NomeFornecedor = conteudo[5].ToString();

                    listaImportadaVm.Add(linha);

                }

                Upload.Dispose();
                Upload.PostedFile.InputStream.Dispose();

                using (EntradasService svc = new EntradasService())
                {
                    var result = svc.GravarDados(listaImportadaVm);
                }
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Alerta", "alert(' Importação realizada.')", true);
                
                BindGrid();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Alerta", "alert(' Nenhum Arquivo Selecionado')", true);
            }
        }

        protected void lnkFiltrar_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}