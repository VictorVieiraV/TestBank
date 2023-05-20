using Dominio;

namespace TestBank.Class
{
    public class Investimento
    {
        List<InvestimentoObj> listaInvestimentos = new List<InvestimentoObj>();
        Conta _conta = new Conta();

        public void RealizarInvestimento()
        {
            Console.WriteLine("Digite o Id da conta:");
            int idConta = int.Parse(Console.ReadLine());

            ContaObj conta = _conta.BuscarContaPorId(idConta);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            Console.WriteLine("Digite o valor a ser investido:");
            double valorInserido = double.Parse(Console.ReadLine());

            if (valorInserido <= 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }
            else
            {
                var maxId = listaInvestimentos.Count();
                InvestimentoObj investimentoObj = new InvestimentoObj()
                {
                    IdConta = conta.Id,
                    IdInvestimento = maxId + 1,
                    PorcentagemGanhos = 2.00,
                    Valor = valorInserido
                };
                listaInvestimentos.Add(investimentoObj);
                conta.Saldo -= valorInserido;
                Console.WriteLine($"Investimento realizado com sucesso. Novo saldo: {conta.Saldo}");
            }
        }

        public void ResgatarInvestimento()
        {
            Console.WriteLine("Digite o número da conta:");
            int numeroConta = int.Parse(Console.ReadLine());

            List<InvestimentoObj> investimentos = BuscarInvestimentosPorConta(numeroConta);

            if (investimentos != null)
            {
                foreach (var investimento in investimentos)
                {
                    Console.WriteLine("Investimento: " + investimento.IdInvestimento);
                    Console.WriteLine("Valor: " + investimento.Valor);
                    Console.WriteLine("Porcentagem de ganho: " + investimento.PorcentagemGanhos);
                }

                Console.WriteLine("Informe o Id do investimento que deseja resgatar: ");
                int idSelecionado = int.Parse(Console.ReadLine());
                var investimentoSelecionado = investimentos.Where(x => x.IdInvestimento == idSelecionado).FirstOrDefault();
                var contaSelecionado = _conta.BuscarContaPorId(numeroConta);
                contaSelecionado.Saldo += investimentoSelecionado.Valor * investimentoSelecionado.PorcentagemGanhos;
                Console.WriteLine("Investimento resgatado com sucesso. Novo saldo bancario: " + contaSelecionado.Saldo);
            }
            else
            {
                Console.WriteLine("Investimentos não encontrada.");
                return;
            }
        }

        public List<InvestimentoObj> BuscarInvestimentosPorConta(int numeroConta)
        {
            return listaInvestimentos.Where(x => x.IdConta == numeroConta).ToList();
        }
    }
}
