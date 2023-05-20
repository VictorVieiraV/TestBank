using Dominio;

namespace TestBank.Class
{
    public class Fatura
    {
        Conta _conta = new Conta();
        List<FaturaObj> listaFaturas = new List<FaturaObj>();

        public void ConsultarFaturasEmAberto()
        {
            Console.WriteLine("Digite o número da conta:");
            int numeroConta = int.Parse(Console.ReadLine());

            ContaObj conta = _conta.BuscarContaPorId(numeroConta);

            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            var faturas = listaFaturas.Where(x => x.IdConta == numeroConta).ToList();
            foreach (var fatura in faturas)
            {
                Console.WriteLine("Fatura da conta: " + numeroConta);
                Console.WriteLine("Data Vencimento: " + fatura.DataVencimento);
                Console.WriteLine("Valor: R$" + fatura.Valor);
            }
        }

        public void PagarFatura()
        {
            Console.WriteLine("Digite o Id da conta:");
            int idConta = int.Parse(Console.ReadLine());

            var faturas = listaFaturas.Where(x => x.IdConta == idConta).ToList();
            foreach (var fatura in faturas)
            {
                Console.WriteLine("Id da conta: " + fatura.IdConta);
                Console.WriteLine("Data Vencimento: " + fatura.DataVencimento);
                Console.WriteLine("Valor: R$" + fatura.Valor);
                Console.WriteLine();
            }

            Console.WriteLine("Digite o Id da fatura que deseja pagar:");
            int idFatura = int.Parse(Console.ReadLine());

            var faturaAtual = listaFaturas.Where(x => x.IdFatura == idFatura).FirstOrDefault();

            if (faturaAtual != null)
            {
                ContaObj conta = _conta.BuscarContaPorId(idConta);
                if (conta != null)
                {
                    if (conta.Saldo > faturaAtual.Valor)
                    {
                        conta.Saldo -= faturaAtual.Valor;
                        faturaAtual.StatusFatura = Enums.StatusFatura.Paga;
                        Console.WriteLine("Fatura paga com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Conta não possui saldo suficiente para pagar fatura.");
                    }
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Fatura não encontrado.");
            }
        }
    }
}
