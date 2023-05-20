using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace TestBank.Class
{
    public class Taxa
    {
        List<TaxaObj> _listaTaxas;
        public Taxa(List<TaxaObj> listaTaxas)
        {
            _listaTaxas = listaTaxas;
        }
        public string AdicionarTaxa(string descricao, double valor)
        {
            int maxTaxas = _listaTaxas.Count();
            TaxaObj taxaObj = new TaxaObj()
            {
                Descricao = descricao,
                IdTaxa = maxTaxas + 1,
                Valor = valor
            };

            _listaTaxas.Add(taxaObj);
            return "Taxa adicionada com sucesso!";
        }

        public string RemoverTaxa(int idTaxa)
        {
            TaxaObj taxaSelecionada = BuscarTaxaPorId(idTaxa);

            if (taxaSelecionada != null && taxaSelecionada.IdTaxa > 0)
            {
                _listaTaxas.Remove(taxaSelecionada);
                return "Taxa removida com sucesso!";
            }
            return "Taxa não encontrada.";
        }

        public TaxaObj BuscarTaxaPorId(int IdTaxa)
        {
            return _listaTaxas.Where(x => x.IdTaxa == IdTaxa).FirstOrDefault();
        }

        public List<string> ConsultarTodasTaxas()
        {
            List<string> result = new List<string>();
            foreach (var taxa in _listaTaxas)
            {
                result.Add($"Id:{taxa.IdTaxa}   /   Descricao: {taxa.Descricao}   /   Valor: {taxa.Valor}");
            }
            return result;
        }
    }
}
