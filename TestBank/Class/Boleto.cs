using Dominio;

namespace TestBank.Class
{
    public class Boleto
    {
        private Cliente _cliente;
        private Conta _conta;
        private List<BoletoObj> _listaBoletos;

        public Boleto(Cliente cliente, Conta conta, List<BoletoObj> listaBoletos)
        {
            _cliente = cliente;
            _conta = conta;
            _listaBoletos = listaBoletos;
        }

        public BoletoObj BuscarBoletoPorId(int id)
        {
            var boletoObj = _listaBoletos.Where(x => x.IdBoleto == id).FirstOrDefault();

            if (boletoObj != null)
            {
                return boletoObj;
            }
            return new BoletoObj();
        }

        public string PagarBoleto(int idBoleto, double valor)
        {
            var boleto = BuscarBoletoPorId(idBoleto);
            ContaObj conta = _conta.BuscarContaPorId(boleto.IdConta);
            ClienteObj cliente = _cliente.BuscarClientePorCpf(boleto.CpfCliente);

            if (boleto.IdBoleto != 0) 
            {
                if (conta.Saldo >= valor)
                {
                    _conta.EfetuarDebito(valor, conta.Id);
                    Console.WriteLine("Boleto pago com sucesso para o cliente " + cliente.Nome + ".");
                    return "Boleto pago com sucesso para o cliente " + cliente.Nome + ".";

                }
                else
                {
                    Console.WriteLine("Não há saldo suficiente na conta para realizar o pagamento.");
                    return "Não há saldo suficiente na conta para realizar o pagamento.";
                }
            }
            else
            {
                Console.WriteLine("Boleto não encontrado.");
                return "Boleto não encontrado.";
            }
        }

        public string GerarBoleto(string cpf, int idConta, double valor)
        {
            ClienteObj clienteObj = _cliente.BuscarClientePorCpf(cpf);

            if (clienteObj.Nome != null)
            {
                ContaObj conta = _conta.BuscarContaPorId(idConta);

                if (conta.Id != 0)
                {
                    BoletoObj boletoObj = new BoletoObj()
                    {
                        CpfCliente = clienteObj.Cpf,
                        DataVencimento = DateTime.Now,
                        IdConta = conta.Id,
                        Valor = valor
                    };
                    _listaBoletos.Add(boletoObj);

                    Console.WriteLine("Boleto gerado com sucesso para o cliente " + clienteObj.Nome + ".");
                    return "Boleto gerado com sucesso para o cliente " + clienteObj.Nome + ".";
                }
                else
                {
                    Console.WriteLine("Conta não encontrada para o cpf " + cpf + ".");
                    return "Conta não encontrada para o cpf " + cpf + ".";
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return "Cliente não encontrado.";
            }
        }
    }
}