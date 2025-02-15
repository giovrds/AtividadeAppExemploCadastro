using AppExemploCadastro.Contexto;
using AppExemploCadastro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppExemploCadastro.Formulario
{
    public partial class FormDeletarPessoa : Form
    {
        int contExc = 0;
        List<Pessoa> ListaPessoas = new List<Pessoa>();
        public FormDeletarPessoa()
        {
            InitializeComponent();
            PessoaContext context = new PessoaContext();//prepararou a conexão
            ListaPessoas = context.ListarPessoas(); //conectou e buscou no banco
            comboBox1.DataSource = ListaPessoas.ToList();
            comboBox1.DisplayMember = "Nome";
            comboBox1.SelectedIndex = -1;
        }


        private void btExcluir_Click(object sender, EventArgs e)
        {
            var linhaSelec = comboBox1.SelectedIndex;
            if (linhaSelec > -1 && contExc > 0)
            {
                var pessoaSelec = ListaPessoas[linhaSelec];
                txtCpf.Text = pessoaSelec.Cpf;
                txtEmail.Text = pessoaSelec.Email;
                txtNome.Text = pessoaSelec.Nome;
                txtRegistroGeral.Text = pessoaSelec.RegistroGeral;

                PessoaContext context = new PessoaContext();
                context.DeletarPessoa(pessoaSelec);
                MessageBox.Show($"ID: {(pessoaSelec.Id).ToString()} " + "DELETADO COM SUCESSO!", "2ºA INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Clear(); txtEmail.Clear(); txtNome.Clear(); txtRegistroGeral.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var linhaSelec = comboBox1.SelectedIndex;
            if (linhaSelec > -1 && contExc > 0)
            {
                var pessoaSelec = ListaPessoas[linhaSelec];
                txtNome.Text = pessoaSelec.Nome;
                txtCpf.Text = pessoaSelec.Cpf;
                txtRegistroGeral.Text = pessoaSelec.RegistroGeral;
                txtEmail.Text = pessoaSelec.Email;
            }
            contExc++;
        }
    }
}
