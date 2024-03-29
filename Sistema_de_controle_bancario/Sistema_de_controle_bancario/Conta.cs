using Sistema_de_controle_bancario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Sistema_de_controle_bancario
{
    public class Conta
    {
        public Conta(long numero, Cliente titular, string banco, int bancoAgencia, int bancoCep, int bancoTel)
        {

            Numero = numero;
            Titular = titular;
            Banco = banco;
            Agencia = bancoAgencia;
            Cep = bancoCep;
            Tel = bancoTel;


        }

        public long Numero { get; private set; }
        public decimal Saldo { get; set; }
        public string Banco { get; set; }
        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Cep { get; set; }
        public int Tel { get; set; }





        public void Deposito(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }
        public void Saque(decimal valor)
        {
            if (valor > 0 && Saldo > valor)
            {

                Saldo -= (valor + 0.10m);
            }
        }
        public void Transferencia(Conta contaDestino, decimal valor)
        {
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                contaDestino.Deposito(valor);
            }
        }

    }

}
