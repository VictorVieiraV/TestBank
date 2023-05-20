using Dominio;

namespace TestBank.Class
{
    public class Investimento
    {
        List<InvestimentoObj> _listaInvestimentos;
        Conta _conta;

        public Investimento(List<InvestimentoObj> listaInvestimentos, Conta conta)
        {
            _listaInvestimentos = listaInvestimentos;
            _conta = conta;
        }
        public string RealizarInvestimento(int idConta, double valorInserido)
        {
            ContaObj conta = _conta.BuscarContaPorId(idConta);
            if (conta == null && conta.Id == 0)
            {
                return "Conta não encontrada.";
            }

            if (valorInserido <= 0)
            {
                return "Valor inválido.";
            }
            else
            {
                var maxId = _listaInvestimentos.Count();
                InvestimentoObj investimentoObj = new InvestimentoObj()
                {
                    IdConta = conta.Id,
                    IdInvestimento = maxId + 1,
                    PorcentagemGanhos = 2.00,
                    Valor = valorInserido
                };
                _listaInvestimentos.Add(investimentoObj);
                conta.Saldo -= valorInserido;
                return $"Investimento realizado com sucesso. Novo saldo: {conta.Saldo}";
            }
        }

        public string ResgatarInvestimento(int numeroConta, int idInvestimento)
        {
            List<InvestimentoObj> investimentos = BuscarInvestimentosPorConta(numeroConta);

            if (investimentos != null && investimentos.Count > 0)
            {
                var investimentoSelecionado = investimentos.Where(x => x.IdInvestimento == idInvestimento).FirstOrDefault();
                var contaSelecionado = _conta.BuscarContaPorId(numeroConta);
                contaSelecionado.Saldo += investimentoSelecionado.Valor + (investimentoSelecionado.Valor * investimentoSelecionado.PorcentagemGanhos);
                return "Investimento resgatado com sucesso. Novo saldo bancario: " + contaSelecionado.Saldo;
            }
            else
            {
                return "Investimentos não encontrados.";
            }
        }

        public List<InvestimentoObj> BuscarInvestimentosPorConta(int numeroConta)
        {
            return _listaInvestimentos.Where(x => x.IdConta == numeroConta).ToList();
        }
    }
}
