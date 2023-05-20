using Dominio;
using TestBank.Class;

class Program
{
    static void Main(string[] args)
    {
        Boleto _boleto = new Boleto(new Cliente(new List<ClienteObj>()), new Conta(new List<ContaObj>()), new List<BoletoObj>());
        Cliente _cliente = new Cliente(new List<ClienteObj>());
        Conta _conta = new Conta(new List<ContaObj>());
        Fatura _fatura = new Fatura(new List<FaturaObj>(), new Conta(new List<ContaObj>()));
        Investimento _investimento = new Investimento(new List<InvestimentoObj>(), new Conta(new List<ContaObj>()));
        Relatorio _relatorio = new Relatorio(new Conta(new List<ContaObj>()), new List<TransacaoObj>());
        Taxa _taxa = new Taxa(new List<TaxaObj>());
        Transacao _transacao = new Transacao(new Conta(new List<ContaObj>()));

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
                case "7":
                    Console.WriteLine("Digite o cpf:");
                    string cpf3 = Console.ReadLine();
                    _cliente.BuscarClientePorCpf(cpf3);
                    break;
                case "8":
                    Console.WriteLine("Digite o CPF do cliente para abrir a conta:");
                    string cpf5 = Console.ReadLine();

                    Console.WriteLine("Digite o tipo de conta (1-Conta Corrente / 2-Conta Poupança):");
                    int tipoConta = int.Parse(Console.ReadLine());

                    var conta = new ContaObj()
                    {
                        CpfCliente = cpf5,
                        Saldo = 0.00,
                        TipoConta = (Enums.TipoConta)tipoConta
                    };
                    _conta.AbrirConta(conta);
                    break;
                case "9":
                    Console.Write("Digite o número da conta que deseja fechar: ");
                    int numeroConta = int.Parse(Console.ReadLine());
                    _conta.FecharConta(numeroConta);
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
                    Console.WriteLine("Digite o número da conta:");
                    int numeroConta2 = int.Parse(Console.ReadLine());
                    _fatura.ConsultarFaturasEmAberto(numeroConta2);
                    break;
                case "15":
                    Console.WriteLine("Digite o Id da fatura que deseja pagar:");
                    int idFatura = int.Parse(Console.ReadLine());
                    _fatura.PagarFatura(idFatura);
                    break;
                case "16":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta6 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o valor a ser investido:");
                    double valorInserido = double.Parse(Console.ReadLine());
                    _investimento.RealizarInvestimento(idConta6, valorInserido);
                    break;
                case "17":
                    Console.WriteLine("Digite o número da conta:");
                    int numeroConta3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o Id do investimento que deseja resgatar: ");
                    int idInvestimento = int.Parse(Console.ReadLine());
                    _investimento.ResgatarInvestimento(numeroConta3, idInvestimento);
                    break;
                case "18":
                    Console.WriteLine("Digite o Id da conta:");
                    int idConta5 = int.Parse(Console.ReadLine());
                    _investimento.BuscarInvestimentosPorConta(idConta5);
                    break;
                case "19":
                    Console.Write("Digite o número da conta: ");
                    int numeroConta4 = int.Parse(Console.ReadLine());
                    _relatorio.ObterSaldo(numeroConta4);
                    break;
                case "20":
                    Console.WriteLine("Informe o número da conta:");
                    int numeroConta5 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o Id da transacao:");
                    int idTransacao = int.Parse(Console.ReadLine());
                    _relatorio.ConsultarExtrato(numeroConta5, idTransacao);
                    break;
                case "21":
                    _relatorio.GerarRelatorioTransacoes();
                    break;
                case "22":
                    Console.Write("Informe a descrição da taxa: ");
                    string descricao = Console.ReadLine();
                    Console.Write("Informe o valor da taxa: ");
                    double valorTaxa = double.Parse(Console.ReadLine());
                    _taxa.AdicionarTaxa(descricao, valorTaxa);
                    break;
                case "23":
                    Console.Write("Informe o Id da taxa que deseja remover: ");
                    int idTaxa = int.Parse(Console.ReadLine());

                    _taxa.RemoverTaxa(idTaxa);
                    break;
                case "24":
                    Console.WriteLine("Digite o Id da taxa:");
                    int idTaxa2 = int.Parse(Console.ReadLine());
                    _taxa.BuscarTaxaPorId(idTaxa2);
                    break;
                case "25":
                    _taxa.ConsultarTodasTaxas();
                    break;
                case "26":
                    Console.Write("Digite o Id da conta: ");
                    int idConta7 = int.Parse(Console.ReadLine());
                    Console.Write("Digite o valor a ser depositado: ");
                    double valorDepositado = double.Parse(Console.ReadLine());

                    _transacao.EfetuarDeposito(idConta7, valorDepositado);
                    break;
                case "27":
                    Console.Write("Digite o Id da conta: ");
                    int idConta8 = int.Parse(Console.ReadLine());
                    Console.Write("Digite o valor a ser sacado: ");
                    double valorSacado = double.Parse(Console.ReadLine());

                    _transacao.EfetuarSaque(idConta8, valorSacado);
                    break;
                case "28":
                    Console.Write("Digite o Id da conta de origem: ");
                    int idContaOrigem = int.Parse(Console.ReadLine());
                    Console.Write("Digite o Id da conta de destino: ");
                    int idContaDestino = int.Parse(Console.ReadLine());
                    Console.Write("Digite o valor a ser transferido: ");
                    double valor = double.Parse(Console.ReadLine());

                    _transacao.EfetuarTransferencia(idContaOrigem, idContaDestino, valor);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}