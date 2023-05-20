using Dominio;

namespace TestBank.Class
{
    public class Relatorio
    {
        Conta _conta = new Conta();
        List<TransacaoObj> listaTransacoes = new List<TransacaoObj>();
        List<ContaObj> listaContas = new List<ContaObj>();
        public void ObterSaldo()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            ContaObj contaSelecionada = _conta.BuscarContaPorId(numeroConta);

            if (contaSelecionada == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            Console.WriteLine("Saldo atual da conta {0}: R$ {1}", contaSelecionada.Id, contaSelecionada.Saldo);
        }

        public void ConsultarExtrato()
        {
            Console.WriteLine("Informe o número da conta:");
            int numeroConta = int.Parse(Console.ReadLine());
            ContaObj contaSelecionada = _conta.BuscarContaPorId(numeroConta);

            if (contaSelecionada == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            Console.WriteLine($"Extrato da conta {contaSelecionada.Id}:");
            foreach (var transacao in listaTransacoes)
            {
                Console.WriteLine($"Data: {transacao.Data}, Valor: {transacao.Valor}");
            }
        }

        public void GerarRelatorioContas()
        {
            Console.WriteLine("Relatório geral:");
            foreach (var conta in listaContas)
            {
                Console.WriteLine($"Conta: {conta.Id}    /    Saldo {conta.Saldo}");
            }
        }
    }
}
