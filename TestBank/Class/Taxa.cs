using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace TestBank.Class
{
    public class Taxa
    {
        List<TaxaObj> listaTaxas = new List<TaxaObj>();
        public void AdicionarTaxa()
        {
            Console.Write("Informe a descrição da taxa: ");
            string descricao = Console.ReadLine();
            Console.Write("Informe o valor da taxa: ");
            double valor = double.Parse(Console.ReadLine());

            int maxTaxas = listaTaxas.Count();
            TaxaObj taxaObj = new TaxaObj()
            {
                Descricao = descricao,
                IdTaxa = maxTaxas + 1,
                Valor = valor
            };

            listaTaxas.Add(taxaObj);
            Console.WriteLine("Taxa adicionada com sucesso!");
        }

        public void RemoverTaxa()
        {
            Console.Write("Informe o Id da taxa que deseja remover: ");
            int idTaxa = int.Parse(Console.ReadLine());

            TaxaObj taxaSelecionada = BuscarTaxaPorId(idTaxa);

            if (taxaSelecionada != null)
            {
                listaTaxas.Remove(taxaSelecionada);
                Console.WriteLine("Taxa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Taxa não encontrada.");
            }
        }

        public TaxaObj BuscarTaxaPorId(int IdTaxa)
        {
            return listaTaxas.Where(x => x.IdTaxa == IdTaxa).FirstOrDefault();
        }

        public void ConsultarTodasTaxas()
        {
            Console.WriteLine("Taxas cadastradas:");
            foreach (var taxa in listaTaxas)
            {
                Console.WriteLine($"Id:{taxa.IdTaxa}   /   Descricao: {taxa.Descricao}   /   Valor: {taxa.Valor}");
            }
        }
    }
}
