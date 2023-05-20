using Dominio;

namespace TestBank.Class
{
    public class Transacao
    {
        Conta _conta;

        public Transacao(Conta conta)
        {
            _conta = conta;
        }
        public string EfetuarDeposito(int idConta, double valorDepositado)
        {
            ContaObj conta = _conta.BuscarContaPorId(idConta);

            if (conta != null && conta.Id > 0)
            {
                if (_conta.EfetuarDeposito(valorDepositado, idConta))
                {
                    return $"Depósito realizado com sucesso. Novo saldo da conta: {conta.Saldo}";
                }
                else
                {
                    return "Não foi possível realizar o deposito.";
                }
            }
            else
            {
                return "Conta não encontrada.";
            }
        }

        public string EfetuarSaque(int idConta, double valorSacado)
        {
            ContaObj conta = _conta.BuscarContaPorId(idConta);

            if (conta != null && conta.Id > 0)
            {
                if (_conta.EfetuarDebito(valorSacado, idConta))
                {
                    return $"Saque realizado com sucesso. Novo saldo da conta: {conta.Saldo}";
                }
                else
                {
                    return "Não foi possível realizar o saque.";
                }
            }
            else
            {
                return "Conta não encontrada.";
            }
        }

        public List<string> EfetuarTransferencia(int idContaOrigem, int idContaDestino, double valor)
        {
            ContaObj contaOrigem = _conta.BuscarContaPorId(idContaOrigem);
            List<string> retorno = new List<string>();

            if (contaOrigem != null && contaOrigem.Id > 0)
            {
                ContaObj contaDestino = _conta.BuscarContaPorId(idContaDestino);

                if (contaDestino != null && contaDestino.Id > 0)
                {
                    double saldoOrigem;
                    double saldoDestino;
                    if (_conta.RealizarTransferencia(contaOrigem, contaDestino, valor, out saldoOrigem, out saldoDestino))
                    {
                        retorno.Add("Transferência realizada com sucesso.");
                        retorno.Add("Novo saldo da conta de origem: " + saldoOrigem);
                        retorno.Add("Novo saldo da conta de destino: " + saldoDestino);
                    }
                    else
                    {
                        retorno.Add("Saldo insuficiente na conta de origem.");
                    }
                }
                else
                {
                    retorno.Add("Conta de destino não encontrada.");
                }
            }
            else
            {
                retorno.Add("Conta de origem não encontrada.");
            }
            return retorno;
        }
    }
}
