using Dominio;
using TestBank.Class;

class Program
{
    static void Main(string[] args)
    {
        Boleto _boleto = new Boleto(new Cliente(), new Conta(),new List<BoletoObj>());
        Cliente _cliente = new Cliente();
        Conta _conta = new Conta();
        Fatura _fatura = new Fatura();
        Investimento _investimento = new Investimento();
        Relatorio _relatorio = new Relatorio();
        Taxa _taxa = new Taxa();
        Transacao _transacao = new Transacao();

        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\n==== BANCO XYZ ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - BuscarBoletoPorId");
            Console.WriteLine("2 - PagarBoleto");
            Console.WriteLine("3 - GerarBoleto");
            Console.WriteLine("4 - CadastrarCliente");
            Console.WriteLine("5 - AlterarCliente");
            Console.WriteLine("6 - ConsultarCliente");
            Console.WriteLine("7 - BuscarClientePorCpf");
            Console.WriteLine("8 - Abrir Conta");
            Console.WriteLine("9 - Fechar Conta");
            Console.WriteLine("10 - Buscar Contas Por Cpf");
            Console.WriteLine("11 - Buscar Conta Por Id");
            Console.WriteLine("12 - Efetuar Debito");
            Console.WriteLine("13 - Efetuar Deposito");
            Console.WriteLine("14 - Realizar Transferencia");
            Console.WriteLine("15 - Consultar Faturas Em Aberto");
            Console.WriteLine("16 - Pagar Fatura");
            Console.WriteLine("17 - Realizar Investimento");
            Console.WriteLine("18 - Resgatar Investimento");
            Console.WriteLine("19 - Buscar Investimentos Por Conta");
            Console.WriteLine("20 - Obter Saldo");
            Console.WriteLine("21 - Consultar Extrato");
            Console.WriteLine("22 - Gerar Relatorio de Contas");
            Console.WriteLine("23 - Adicionar Taxa");
            Console.WriteLine("24 - Remover Taxa");
            Console.WriteLine("25 - Buscar Taxa Por Id");
            Console.WriteLine("26 - Consultar Todas as Taxas");
            Console.WriteLine("27 - Efetuar Deposito");
            Console.WriteLine("28 - Efetuar Saque");
            Console.WriteLine("29 - Efetuar Transferencia");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção escolhida: ");

            var opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "0":
                    sair = true;
                    Console.WriteLine("Saindo...");
                    break;
                case "1":
                    Console.WriteLine("Digite o Id do boleto:");
                    int idBoleto = int.Parse(Console.ReadLine());
                    _boleto.BuscarBoletoPorId(idBoleto);
                    break;
                case "2":
                    Console.WriteLine("Digite o Id do boleto:");
                    var idBoleto2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor do boleto:");
                    double valorBoleto = double.Parse(Console.ReadLine());
                    _boleto.PagarBoleto(idBoleto2, valorBoleto);
                    break;
                case "3":
                    Console.WriteLine("Digite o cpf:");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Digite o Id do boleto:");
                    int idConta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor do boleto:");
                    double valorBoleto2 = double.Parse(Console.ReadLine());
                    _boleto.GerarBoleto(cpf, idConta, valorBoleto2);
                    break;
                case "4":
                    _cliente.CadastrarCliente();
                    break;
                case "5":
                    Console.WriteLine("Digite o nome:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite o CPF:");
                    string cpf2 = Console.ReadLine();
                    Console.WriteLine("Digite o endereço:");
                    string endereco = Console.ReadLine();
                    Console.WriteLine("Digite o telefone:");
                    string tel = Console.ReadLine();

                    var cliente = new ClienteObj()
                    {
                        Nome = nome,
                        Cpf = cpf2,
                        Endereco = endereco,
                        Telefone = tel
                    };
                    _cliente.AlterarCliente(cliente);
                    break;
                case "6":
                    _cliente.ConsultarCliente();
                    break;
                case "7":
                    Console.WriteLine("Digite o cpf:");
                    string cpf3 = Console.ReadLine();
                    _cliente.BuscarClientePorCpf(cpf3);
                    break;
                case "8":
                    _conta.AbrirConta();
                    break;
                case "9":
                    _conta.FecharConta();
                    break;
                case "10":
                    Console.WriteLine("Digite o cpf:");
                    string cpf4 = Console.ReadLine();
                    _conta.BuscarContasPorCpf(cpf4);
                    break;
                case "11":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta2 = int.Parse(Console.ReadLine());
                    _conta.BuscarContaPorId(idConta2);
                    break;
                case "12":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor que deseja retirar:");
                    double valorBoleto3 = double.Parse(Console.ReadLine());
                    _conta.EfetuarDebito(valorBoleto3, idConta3);
                    break;
                case "13":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor que deseja retirar:");
                    double valorBoleto4 = double.Parse(Console.ReadLine());
                    _conta.EfetuarDeposito(valorBoleto4, idConta4);
                    break;
                case "14":
                    _fatura.ConsultarFaturasEmAberto();
                    break;
                case "15":
                    _fatura.PagarFatura();
                    break;
                case "16":
                    _investimento.RealizarInvestimento();
                    break;
                case "17":
                    _investimento.ResgatarInvestimento();
                    break;
                case "18":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta5 = int.Parse(Console.ReadLine());
                    _investimento.BuscarInvestimentosPorConta(idConta5);
                    break;
                case "19":
                    _relatorio.ObterSaldo();
                    break;
                case "20":
                    _relatorio.ConsultarExtrato();
                    break;
                case "21":
                    _relatorio.GerarRelatorioContas();
                    break;
                case "22":
                    _taxa.AdicionarTaxa();
                    break;
                case "23":
                    _taxa.RemoverTaxa();
                    break;
                case "24":
                    Console.WriteLine("Digite o Id da taxa:");
                    int idTaxa = int.Parse(Console.ReadLine());
                    _taxa.BuscarTaxaPorId(idTaxa);
                    break;
                case "25":
                    _taxa.ConsultarTodasTaxas();
                    break;
                case "26":
                    _transacao.EfetuarDeposito();
                    break;
                case "27":
                    _transacao.EfetuarSaque();
                    break;
                case "28":
                    _transacao.EfetuarTransferencia();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}