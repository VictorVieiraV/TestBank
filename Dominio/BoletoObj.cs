using static Dominio.Enums;

namespace Dominio
{
    public class BoletoObj
    {
        public int IdBoleto { get; set; }
        public string CpfCliente { get; set; }
        public int IdConta { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusBoleto StatusBoleto { get; set; }
    }
}
