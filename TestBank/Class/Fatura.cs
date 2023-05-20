using Dominio;

namespace TestBank.Class
{
    public class Fatura
    {
        Conta _conta;
        private List<FaturaObj> _listaFaturas;
        private List<ContaObj> _listaContas;

        public Fatura(List<FaturaObj> listaFaturas, Conta conta)
        {
            _listaFaturas = listaFaturas;
            _conta = conta;
        }

        public List<FaturaObj> ConsultarFaturasEmAberto(int idConta)
        {
            return _listaFaturas.Where(x => x.IdConta == idConta &&
                                            x.StatusFatura == Enums.StatusFatura.Aberta)
                                            .ToList();
        }

        public string PagarFatura(int idFatura)
        {
            var faturaAtual = _listaFaturas.Where(x => x.IdFatura == idFatura &&
                                                       x.StatusFatura == Enums.StatusFatura.Aberta)
                                                       .FirstOrDefault();

            if (faturaAtual != null && faturaAtual.IdFatura > 0)
            {
                ContaObj conta = _conta.BuscarContaPorId(faturaAtual.IdConta);

                if (conta.Id > 0)
                {
                    if (conta.Saldo > faturaAtual.Valor)
                    {
                        conta.Saldo -= faturaAtual.Valor;
                        faturaAtual.StatusFatura = Enums.StatusFatura.Paga;
                        return "Fatura paga com sucesso.";
                    }
                    else
                    {
                        return "Conta não possui saldo suficiente para pagar fatura.";
                    }
                }
                else
                {
                    return "Conta não encontrada.";
                }
            }
            else
            {
                return "Fatura não encontrada.";
            }
        }
    }
}
