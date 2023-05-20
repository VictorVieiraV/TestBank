using Dominio;

namespace TestBank.Class
{
    public class Relatorio
    {
        Conta _conta;
        List<TransacaoObj> _listaTransacoes;
        List<ContaObj> _listaContas;

        public Relatorio(Conta conta, List<TransacaoObj> listaTransacoes)
        {
            _listaTransacoes = listaTransacoes;
            _conta = conta;
        }

        public string ObterSaldo(int numeroConta)
        {
            ContaObj contaSelecionada = _conta.BuscarContaPorId(numeroConta);

            if (contaSelecionada.Id == 0)
            {
                return "Conta não encontrada.";
            }

            return $"Saldo atual da conta {contaSelecionada.Id}: R$ {contaSelecionada.Saldo}";
        }

        public string ConsultarExtrato(int numeroConta, int idTransacao)
        {
            ContaObj contaSelecionada = _conta.BuscarContaPorId(numeroConta);

            if (contaSelecionada != null && contaSelecionada.Id > 0)
            {
                if (_listaTransacoes.Where(x => x.IdConta == contaSelecionada.Id).ToList().Count > 0)
                {
                    foreach (var transacao in _listaTransacoes)
                    {
                        if (transacao.IdTransacao == idTransacao)
                        {
                            return $"IdConta: {transacao.IdConta}, Valor: {transacao.Valor}";
                        }
                    }
                }
                else
                {
                    return $"Conta não possui transações.";
                }
            }
            return "Conta não encontrada.";
        }

        public string GerarRelatorioTransacoes()
        {
            foreach (var transacao in _listaTransacoes)
            {
                return $"Conta: {transacao.IdConta}    /    Saldo {transacao.Valor}";
            }
            return "Não foi possível gerar o relatorio.";
        }
    }
}
