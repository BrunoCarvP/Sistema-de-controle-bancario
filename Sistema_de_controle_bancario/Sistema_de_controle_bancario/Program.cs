using Sistema_de_controle_bancario;

Cliente cliente1 = new Cliente("Menino Ney", 1996, "80545901563");
Conta conta1 = new Conta(123456, cliente1, "Banco do Brasil", 013, 27135000, 33412525);
conta1.Saldo = 2341.42m;


Cliente cliente2 = new Cliente("Robson", 2000, "12345678912");
Conta conta2 = new Conta(654321, cliente2, "Nubank", 280, 23077000, 33410041);

conta2.Saldo = 2000.00m;

/*conta2.Saldo = conta1.Saldo * 0.7m;*/
List<Conta> contas = new List<Conta> { conta1, conta2 };


while (true)
{
    Console.Write("Digite numero da conta que deseja entrar ou digite 00 para sair: ");
    int contaDigitada = int.Parse(Console.ReadLine());
    if (contaDigitada == 00)
    {
        break;
    }
    Conta contaSelecionada = contas.Find(c => c.Numero == contaDigitada);


    if (contaSelecionada != null)
    {
        Console.WriteLine();
        Console.WriteLine($"Número da conta: {contaSelecionada.Numero}, Agencia: {contaSelecionada.Agencia}, Cep: {contaSelecionada.Cep}, Telefone: {contaSelecionada.Tel}, Banco: {contaSelecionada.Banco} \nTitular da conta: {contaSelecionada.Titular.Nome} \nCPF do Tilutar: {contaSelecionada.Titular.Cpf} \nAno de nascimento do titular: {contaSelecionada.Titular.AnoNascimento} \nSaldo da conta: {contaSelecionada.Saldo:c2}");
        Console.WriteLine();

        while (true)
        {


            Console.Write("Digite (1) para efetuar saque: \nDigite (2) para efetuar deposito: \nDigite (3) para fazer transferencia: \nDigite (4) para ver todos os dados: \nDigite (0) para sair:");
            Console.WriteLine();
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                Console.Write("Qual o valor que você deseja retirar?: ");
                decimal valorSaque = decimal.Parse(Console.ReadLine());
                contaSelecionada.Saque(valorSaque);
                Console.WriteLine();
                Console.WriteLine($"Saldo da conta após saque: {contaSelecionada.Saldo:c2}");

            }
            else if (num == 2)
            {
                Console.Write("Qual o valor que deseja depositar?: ");
                decimal valorDeposito = decimal.Parse(Console.ReadLine());
                contaSelecionada.Deposito(valorDeposito);
                Console.WriteLine($"Saldo da conta após depósito: {contaSelecionada.Saldo:c2}");


            }
            else if (num == 3)
            {
                Console.Write("Digite o número da conta de destino: ");
                int numeroContaDestino = int.Parse(Console.ReadLine());
                Conta contaDestino = contas.Find(c => c.Numero == numeroContaDestino);

                if (contaDestino == null)
                {
                    Console.WriteLine("Conta de destino não encontrada.");
                }
                else
                {
                    Console.Write("Qual o valor que você deseja transferir?: ");
                    decimal valorTransferencia = decimal.Parse(Console.ReadLine());
                    contaSelecionada.Transferencia(contaDestino, valorTransferencia);
                    Console.WriteLine();
                    Console.WriteLine($"Saldo da conta após transferência: {contaSelecionada.Saldo:c2}");
                    Console.WriteLine($"Saldo da conta de destino após transferência: {contaDestino.Saldo:c2}");
                    Console.WriteLine();
                }
            }
            else if (num == 4)
            {
                Console.WriteLine("Aqui estão todos os dados: ");
                Console.WriteLine();
                Console.WriteLine($"Número da conta: {contaSelecionada.Numero} \nBanco: {contaSelecionada.Banco} \nTitular da conta: {contaSelecionada.Titular.Nome} \nCPF do Tilutar: {contaSelecionada.Titular.Cpf} \nAno de nascimento do titular: {contaSelecionada.Titular.AnoNascimento} \nSaldo da conta: {contaSelecionada.Saldo:c2}");
                Console.WriteLine();
            }

            else if (num == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Digite um número válido.");
            }
        }
    }
    else
    {
        Console.WriteLine("Numero da conta invalido digite novamente:");

    }
}