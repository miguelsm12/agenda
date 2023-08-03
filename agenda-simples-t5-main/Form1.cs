using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agenda_simples_t5
{
    public partial class Form1 : Form
    {
        // Cria um vetor para guardar os contatos.
        private Contato[] listaDeContatos = new Contato[1];
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddContato_Click(object sender, EventArgs e)
        {
            // Cria um objeto objetoContato,com os dados do formulário.
            Contato objetoContato = new Contato(txtNome.Text, 
                txtSobrenome.Text, txtTelefone.Text, txtEmail.Text);
            Escrever(objetoContato);
            Ordenar();
            Ler();
            AtualizarLista();
            LimparFormulario();
        }

        // Escreve o contato no arquivo de texto.
        private void Escrever(Contato contato)
        {
            StreamWriter escrevedorDeArquivos = new StreamWriter("Contatos.txt");
            escrevedorDeArquivos.WriteLine(listaDeContatos.Length + 1);
            escrevedorDeArquivos.WriteLine(contato.PrimeiroNome);
            escrevedorDeArquivos.WriteLine(contato.Sobrenome);
            escrevedorDeArquivos.WriteLine(contato.Telefone);
            escrevedorDeArquivos.WriteLine(contato.Email);

            // Copia os contatos que já estão no arquivo, e re-escreve
            // eles depois, atualizados.
            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                escrevedorDeArquivos.WriteLine(listaDeContatos[i].PrimeiroNome);
                escrevedorDeArquivos.WriteLine(listaDeContatos[i].Sobrenome);
                escrevedorDeArquivos.WriteLine(listaDeContatos[i].Telefone);
                escrevedorDeArquivos.WriteLine(listaDeContatos[i].Email);
            }
            escrevedorDeArquivos.Close();
        }

        // Método para ler os dados do arquivo de texto.
        private void Ler()
        {
            StreamReader leitorDeArquivos = new StreamReader("Contatos.txt");
            listaDeContatos = new Contato[Convert.ToInt32(leitorDeArquivos.ReadLine())];
            // Copia os dados do arquivo de texto para o vetor listaDeContatos
            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                listaDeContatos[i] = new Contato();
                listaDeContatos[i].PrimeiroNome = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Sobrenome = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Telefone = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Email = leitorDeArquivos.ReadLine();
            }

            leitorDeArquivos.Close();
        }

        private void AtualizarLista()
        {
            // Apaga os dados da lista que está sendo exibida.
            lstContatos.Items.Clear();
            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                lstContatos.Items.Add(listaDeContatos[i].ToString());
            }
        }

        private void LimparFormulario()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            AtualizarLista();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Ordenar();
            AtualizarLista();
        }
        private void Ordenar()
        {
            Contato temporario;
            bool trocar;
            do
            {
                trocar = false;
                for (int i = 0; i < listaDeContatos.Length - 1; i++)
                {
                    if (listaDeContatos[i].PrimeiroNome.
                        CompareTo(listaDeContatos[i + 1].PrimeiroNome) > 0)
                    {
                        temporario = listaDeContatos[i];
                        listaDeContatos[i] = listaDeContatos[i + 1];
                        listaDeContatos[i + 1] = temporario;
                        trocar = true;
                    }
                }
            } while (trocar == true);
        }
    }
}
