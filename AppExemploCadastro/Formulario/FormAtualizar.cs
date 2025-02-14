using AppExemploCadastro.Contexto;
using AppExemploCadastro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppExemploCadastro.Formulario
{
    public partial class FormAtualizar : Form
    {
        int contExc = 0;
        List<Pessoa> ListaPessoa = new List<Pessoa>();

        public FormAtualizar()
        {
            InitializeComponent();
            PessoaContext pessoa = new PessoaContext();
            ListaPessoa = pessoa.ListarPessoas();
            comboBox1.DataSource = ListaPessoa.ToList();
            comboBox1.DisplayMember = "Nome";
            comboBox1.SelectedIndex = -1;
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            var linhaSelec = comboBox1.SelectedIndex;
            if (linhaSelec > -1 && contExc > 0)
            {
                var pessoaSelec = ListaPessoa[linhaSelec];
                txtCpf.Text = pessoaSelec.Cpf;
                txtEmail.Text = pessoaSelec.Email;
                txtNome.Text = pessoaSelec.Nome;
                txtRegistroGeral.Text = pessoaSelec.RegistroGeral;

                PessoaContext context = new PessoaContext();
                context.AtualizarPessoa(pessoaSelec);
                MessageBox.Show($"ID:{(pessoaSelec.Id).ToString()} " + "ATUALIZADO COM SUCESSO!", "2ºA INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Clear(); txtEmail.Clear(); txtNome.Clear(); txtRegistroGeral.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var linhaSelec = comboBox1.SelectedIndex;
            if (linhaSelec > -1 && contExc > 0)
            {
                var pessoaSelec = ListaPessoa[linhaSelec];
                txtCpf.Text = pessoaSelec.Cpf;
                txtEmail.Text = pessoaSelec.Email;
                txtNome.Text = pessoaSelec.Nome;
                txtRegistroGeral.Text = pessoaSelec.RegistroGeral;
            }
            contExc++;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            var linhaSelec = comboBox1.SelectedIndex;
            if (linhaSelec > -1 && contExc > 0)
            {
                var pessoaSelec = ListaPessoa[linhaSelec];
                txtCpf.Text = pessoaSelec.Cpf;
                txtEmail.Text = pessoaSelec.Email;
                txtNome.Text = pessoaSelec.Nome;
                txtRegistroGeral.Text = pessoaSelec.RegistroGeral;

                PessoaContext context = new PessoaContext();
                context.DeletarPessoa(pessoaSelec);
                MessageBox.Show($"ID:{(pessoaSelec.Id).ToString()} " + "DELETADO COM SUCESSO!", "2ºA INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpf.Clear(); txtEmail.Clear(); txtNome.Clear(); txtRegistroGeral.Clear();
            }
        }
    }
}
