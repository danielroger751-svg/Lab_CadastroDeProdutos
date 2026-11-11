using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_CadastroDeProdutos
{
    public partial class Form1 : Form
    {

        private void calcularMargem()
        {
            decimal margem = NumericPrecoDeVenda.Value - NumericPrecoDeCusto.Value;
            txtMargem.Text = margem.ToString("C2");
        }



        private void LimparFormulario()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtMargem.Clear();

            ComboBoxCategoria.SelectedIndex = -1;
            ComboBoxFornecedor.SelectedIndex = -1;

            NumericPrecoDeCusto.Value = 0;
            NumericPrecoDeVenda.Value = 0;
            NumericStokInicial.Value = 0;
            NumericStokMinimo.Value = 0;

            CheckBoxProdutoAtivo.Checked = false;
            DateTimeDataDeCadastro.Value = DateTime.Now;

            txtCodigo.Focus();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonNovo_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja Iniciar Um Novo Cadastro? ","NOVO CADASTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //MessageBox.Show("Novo botão clicado!");
            if (resposta == DialogResult.Yes)
            {
                LimparFormulario();
            }
        }

        private void ButtonLimpar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja Limpar o Formulário? ", "LIMPAR FORMULÁRIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                LimparFormulario();
            }
        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja Excluir o Cadastro? ", "EXCLUIR CADASTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                LimparFormulario();
                MessageBox.Show("Cadastro Excluído com Sucesso!", "EXCLUIR CADASTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, informe o código do produto.");
                txtCodigo.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, informe o nome do produto.");
                txtNome.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(ComboBoxCategoria.Text))
            {
                MessageBox.Show("Por favor, informe a categoria do produto.");
                ComboBoxCategoria.Focus();
                return; 
            }
            if (string.IsNullOrWhiteSpace(ComboBoxFornecedor.Text))
            {
                MessageBox.Show("Por favor, informe o fornecedor do produto.");
                ComboBoxFornecedor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Por favor, informe a descrição do produto.");
                txtDescricao.Focus();
                return;
            }

            if (NumericPrecoDeVenda.Value < NumericPrecoDeCusto.Value || NumericPrecoDeVenda.Value == 0)
            {
                MessageBox.Show("O preço de venda não pode ser menor que o preço de custo, ou Igual á 0.");
                NumericPrecoDeVenda.Focus();
                return;
            }
            if (NumericStokInicial.Value < 1)
            {
                MessageBox.Show("O estoque inicial não pode ser Menor que 1.");
                NumericStokInicial.Focus();
                return; 
            }

            if (NumericStokMinimo.Value < 1)
            {
                MessageBox.Show("O estoque mínimo não pode ser Menor que 1.");
                NumericStokMinimo.Focus();
                return;
            }

            if (DateTimeDataDeCadastro.Value.Date > DateTime.Today)
            {
                MessageBox.Show("A data de cadastro não pode ser maior que a data atual.");
                DateTimeDataDeCadastro.Focus();
                return; 
            }

            if (NumericPrecoDeCusto.Value == 0)
            {
                MessageBox.Show("O preço de custo não pode ser igual a 0.");
                NumericPrecoDeCusto.Focus();
                return;
            }

            if (ComboBoxCategoria.Text == "Roupa" && !ComboBoxFornecedor.Text.Contains("Nike"))
            {
                MessageBox.Show("A categoria Roupa só é permitida para o fornecedor Nike.");
                ComboBoxCategoria.Focus();
                return;
            }
            

            string codigo = txtCodigo.Text;
            string nome = txtNome.Text;
            string categoria = ComboBoxCategoria.Text;
            string fornecedor = ComboBoxFornecedor.Text;
            string descricao = txtDescricao.Text;

            decimal precoDeCusto = NumericPrecoDeCusto.Value;
            decimal precoDeVenda = NumericPrecoDeVenda.Value;
            decimal margem = (precoDeVenda - precoDeCusto);

            int estoqueInicial = (int)NumericStokInicial.Value;
            int estoqueMinimo = (int)NumericStokMinimo.Value;
            DateTime dataDeCadastro = DateTimeDataDeCadastro.Value;

            MessageBox.Show($"Produto cadastrado com sucesso!\n\nCódigo: {codigo}\nNome: " +
            $"{nome}\nCategoria: " +
            $"{categoria}\nFornecedor: {fornecedor}\nDescrição: " +
            $"{descricao}\nPreço de Custo: {precoDeCusto:C}\nPreço de Venda: " +
            $"{precoDeVenda:C}\nEstoque Inicial: {estoqueInicial}\nEstoque Mínimo: " +
            $"{estoqueMinimo}\nData de Cadastro: {dataDeCadastro.ToShortDateString()}", 
            "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void NumericPrecoDeCusto_ValueChanged(object sender, EventArgs e)
        {

            calcularMargem();
        }

        private void NumericPrecoDeVenda_ValueChanged(object sender, EventArgs e)
        {
            calcularMargem();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
