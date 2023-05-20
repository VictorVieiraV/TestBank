using Dominio;

namespace TestBank.Class
{
    public class Transacao
    {
        Conta _conta = new Conta();
        public void EfetuarDeposito()
        {
            Console.Write("Digite o Id da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            ContaObj conta = _conta.BuscarContaPorId(idConta);

            if (conta != null)
            {
                Console.Write("Digite o valor a ser depositado: ");
                double valorDepositado = double.Parse(Console.ReadLine());

                if (_conta.EfetuarDeposito(valorDepositado, idConta))
                {
                    Console.WriteLine("Depósito realizado com sucesso. Novo saldo da conta: " + conta.Saldo);
                }
                else
                {
                    Console.WriteLine("Não foi possível realizar o deposito.");
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }

        public void EfetuarSaque()
        {
            Console.Write("Digite o Id da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            ContaObj conta = _conta.BuscarContaPorId(idConta);

            if (conta != null)
            {
                Console.Write("Digite o valor a ser sacado: ");
                double valorSacado = double.Parse(Console.ReadLine());

                if (_conta.EfetuarDeposito(valorSacado, idConta))
                {
                    Console.WriteLine("Saque realizado com sucesso. Novo saldo da conta: " + conta.Saldo);
                }
                else
                {
                    Console.WriteLine("Não foi possível realizar o saque.");
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }

        public void EfetuarTransferencia()
        {
            Console.Write("Digite o Id da conta de origem: ");
            int idContaOrigem = int.Parse(Console.ReadLine());

            ContaObj contaOrigem = _conta.BuscarContaPorId(idContaOrigem);

            if (contaOrigem != null)
            {
                Console.Write("Digite o Id da conta de destino: ");
                int idContaDestino = int.Parse(Console.ReadLine());

                ContaObj contaDestino = _conta.BuscarContaPorId(idContaDestino);

                if (contaDestino != null)
                {
                    Console.Write("Digite o valor a ser transferido: ");
                    double valor = double.Parse(Console.ReadLine());

                    double saldoOrigem;

                    double saldoDestino;
                    if (_conta.RealizarTransferencia(contaOrigem, contaDestino, valor, out saldoOrigem, out saldoDestino))
                    {
                        Console.WriteLine("Transferência realizada com sucesso.");
                        Console.WriteLine("Novo saldo da conta de origem: " + saldoOrigem);
                        Console.WriteLine("Novo saldo da conta de destino: " + saldoDestino);
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente na conta de origem.");
                    }
                }
                else
                {
                    Console.WriteLine("Conta de destino não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Conta de origem não encontrada.");
            }
        }
    }
}
