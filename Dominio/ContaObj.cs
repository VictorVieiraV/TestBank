using static Dominio.Enums;

namespace Dominio
{
    public class ContaObj
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public string CpfCliente { get; set; }
        public TipoConta TipoConta { get; set; }
    }
}
