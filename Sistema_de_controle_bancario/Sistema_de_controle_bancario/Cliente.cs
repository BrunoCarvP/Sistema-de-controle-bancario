using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_controle_bancario
{
    public class Cliente
    {
        public Cliente(string nome, int anoNascimento, string cpf)
        {
            Nome = nome;
            AnoNascimento = anoNascimento;
            int idade = CalcularIdade(anoNascimento);
            if (idade < 18)
            {
                Console.WriteLine($"Voce não tem idade para criar uma conta '{nome}' voce é menor de 18 anos. ");
            }

            Cpf = cpf;
            if (cpf.Length != 11)
            {
                Console.WriteLine($"CPF do Cliente '{nome}' está inválido '{cpf}'.");
                return;
            }
        }

        public string Nome { get; set; }
        public int AnoNascimento { get; set; }
        public string Cpf { get; set; }



        public int CalcularIdade(int anoNascimento)
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - AnoNascimento;
        }
    }
}