using Dominio;
using System.Drawing;

namespace TestBank.Class
{
    public class Conta
    {
        Cliente _cliente = new Cliente();
        List<ContaObj> listaContas = new List<ContaObj>();
        public void AddConta(ContaObj conta)
        {
            listaContas.Add(conta);
        }
        public void AbrirConta()
        {
            Console.WriteLine("Digite o CPF do cliente para abrir a conta:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o tipo de conta (1-Conta Corrente / 2-Conta Poupança):");
            int tipoConta = int.Parse(Console.ReadLine());
            int maxCount = listaContas.Count();

            if (tipoConta == 1)
            {
                ContaObj conta = new ContaObj()
                {
                    Id = maxCount + 1,
                    CpfCliente = cpf,
                    Saldo = 0.00,
                    TipoConta = Enums.TipoConta.Poupanca
                };
                AddConta(conta);
                Console.WriteLine($"Conta corrente criada com sucesso.");
            }
            else if (tipoConta == 2)
            {
                ContaObj conta = new ContaObj()
                {
                    Id = maxCount + 1,
                    CpfCliente = cpf,
                    Saldo = 0.00,
                    TipoConta = Enums.TipoConta.Corrente
                };

                listaContas.Add(conta);
                Console.WriteLine($"Conta poupança criada com sucesso.");
            }
            else
            {
                Console.WriteLine("Tipo de conta inválido.");
            }
        }

        public void FecharConta()
        {
            Console.Write("Digite o número da conta que deseja fechar: ");
            int numeroConta = int.Parse(Console.ReadLine());

            ContaObj conta = listaContas.Where(x => x.Id == numeroConta).FirstOrDefault();

            if (conta != null)
            {
                if (conta.Saldo >= 0)
                {
                    listaContas.Remove(conta);
                    Console.WriteLine("Conta fechada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Não é possível fechar a conta. Saldo negativo.");
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }

        public List<ContaObj> BuscarContasPorCpf(string cpf)
        {
            var contas = listaContas.Where(x => x.CpfCliente == cpf).ToList();

            if (contas != null)
            {
                return contas;
            }
            return new List<ContaObj>();
        }

        public ContaObj BuscarContaPorId(int id)
        {
            var conta = listaContas.Where(x => x.Id == id).FirstOrDefault();

            if (conta != null)
            {
                return conta;
            }
            return new ContaObj();
        }

        public bool EfetuarDebito(double valor, int idConta)
        {
            ContaObj conta = BuscarContaPorId(idConta);
            if (conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                return true;
            }
            return false;
        }

        public bool EfetuarDeposito(double valor, int idConta)
        {
            ContaObj conta = BuscarContaPorId(idConta);
            if (conta.Saldo >= valor)
            {
                conta.Saldo += valor;
                return true;
            }
            return false;
        }

        public bool RealizarTransferencia(ContaObj contaOrigem, ContaObj contaDestino, double valor, out double saldoOrigem, out double saldoDestino)
        {
            if (EfetuarDebito(valor, contaDestino.Id) && EfetuarDeposito(valor, contaOrigem.Id))
            {
                saldoOrigem = contaOrigem.Saldo;
                saldoDestino = contaDestino.Saldo;
                return true;
            }
            saldoOrigem = 0;
            saldoDestino = 0;
            return false;
        }
    }
}
