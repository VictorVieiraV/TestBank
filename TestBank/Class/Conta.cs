using Dominio;
using System.Drawing;

namespace TestBank.Class
{
    public class Conta
    {
        private List<ContaObj> _listaContas;

        public Conta(List<ContaObj> listaContas)
        {
            _listaContas = listaContas;
        }

        public void AddConta(ContaObj conta)
        {
            _listaContas.Add(conta);
        }
        public string AbrirConta(ContaObj conta)
        {
            int maxCount = _listaContas.Count();
            conta.Id = maxCount + 1;

            if (conta.TipoConta == Enums.TipoConta.Poupanca)
            {
                AddConta(conta);
                return ("Conta corrente criada com sucesso.");
            }
            else if (conta.TipoConta == Enums.TipoConta.Corrente)
            {
                _listaContas.Add(conta);
                return ("Conta poupança criada com sucesso.");
            }
            else
            {
                return ("Tipo de conta inválido.");
            }
        }

        public string FecharConta(int numeroConta)
        {

            ContaObj conta = _listaContas.Where(x => x.Id == numeroConta).FirstOrDefault();

            if (conta != null)
            {
                if (conta.Saldo >= 0)
                {
                    _listaContas.Remove(conta);
                    return "Conta fechada com sucesso.";
                }
                else
                {
                    return "Não é possível fechar a conta. Saldo negativo.";
                }
            }
            else
            {
                return "Conta não encontrada.";
            }
        }

        public List<ContaObj> BuscarContasPorCpf(string cpf)
        {
            var contas = _listaContas.Where(x => x.CpfCliente == cpf).ToList();

            if (contas != null)
            {
                return contas;
            }
            return new List<ContaObj>();
        }

        public ContaObj BuscarContaPorId(int id)
        {
            var conta = _listaContas.Where(x => x.Id == id).FirstOrDefault();

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
            if (conta.Id > 0)
            {
                conta.Saldo += valor;
                return true;
            }
            return false;
        }

        public bool RealizarTransferencia(ContaObj contaOrigem, ContaObj contaDestino, double valor, out double saldoOrigem, out double saldoDestino)
        {
            if (EfetuarDebito(valor, contaOrigem.Id) && EfetuarDeposito(valor, contaDestino.Id))
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
