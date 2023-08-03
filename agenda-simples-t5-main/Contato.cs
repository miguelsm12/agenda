using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace agenda_simples_t5
{
    internal class Contato
    {
        // Variáveis locais da classe Contato.
        // Acessíveis apenas pela classe Contato.
        private string primeiroNome;
        private string sobrenome;
        private string telefone;
        private string email;

        // PROPRIEDADES da classe Contato.
        // Acessíveis por qualquer parte desse programa.
        public string PrimeiroNome
        {
            get { return primeiroNome; }
            set { primeiroNome = value; }
        }
        public string Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set 
            { 
                if (value.Length == 11)
                {
                    telefone = value;
                }
                else
                {
                    telefone = "00000000000";
                }
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        // Construtor da classe.
        public Contato()
        {
            PrimeiroNome = "João";
            Sobrenome = "Da Silva";
            Telefone = "11988888776";
            Email = "exemplo@exemplo.com";
        }
        // Sobrecarga de método.
        public Contato(string primeiroNome, string sobrenome, string telefone, string email)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            Email = email;
        }

        // Sobreescrita do método ToString().
        public override string ToString()
        {
            // Melhor utilizar String.Empty invés de "".
            string saida = String.Empty;
            saida += String.Format("{0} {1}", PrimeiroNome, Sobrenome);
            saida += " ";
            saida += String.Format("{0}-{1}-{2}", 
                Telefone.Substring(0,2),
                Telefone.Substring(2,5),
                Telefone.Substring(7,4)
                );
            saida += " "; // Apenas um espaço entre o telefone e e-mail.
            saida += String.Format("{0}", Email);

            return saida;
        }
    }
}
