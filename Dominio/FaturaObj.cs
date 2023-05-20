using static Dominio.Enums;

namespace Dominio
{
    public class FaturaObj
    {
        public int IdFatura { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int IdConta { get; set; }
        public StatusFatura StatusFatura { get; set; }
    }
}
