using AjudaPrefeito.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AjudaPrefeito
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Casa> listaDeCasas = new List<Casa>();
            Casa casa;

            var casas = new Dictionary<int, Casa>()
            {
                {1, new Casa(1,10,3,new Rua(1,"76810-164","Tambaqui")) },
                {2, new Casa(2,11,5,new Rua(1,"76810-164","Tambaqui")) },
                {3, new Casa(3,20,6,new Rua(2,"76500-100","Jatuarana")) },
                {4, new Casa(4,21,4,new Rua(2,"76500-100","Jatuarana")) },
                {5, new Casa(5,30,3,new Rua(3,"76412-200","Pirarara")) },
                {6, new Casa(6,31,2,new Rua(3,"76412-200","Pirarara")) }
            };

            foreach (var item in casas)
            {
                casa = new Casa(item.Value.Id, item.Value.Numero, item.Value.TotalEleitores, item.Value.Rua);
                listaDeCasas.Add(casa);
            }

            var totalEleitoresPorRua = ListarRuas(listaDeCasas);

            var query = totalEleitoresPorRua.GroupBy(x => x.Id)
                .Select(g => new { 
                    Key = g.Key,
                    Rua = g.First().Nome,
                    Cep = g.First().Cep,
                    Total = g.Sum(s => s.Casas.First().TotalEleitores)
                });

            foreach (var item in query)
            {
                Console.WriteLine($"IdRua: {item.Key} - CEP: {item.Cep} - Rua: {item.Rua} - Total Eleitor: {item.Total}");
            }

            Console.ReadKey();
        }

        static List<Rua> ListarRuas(List<Casa> casas)
        {
            List<Rua> listaDeRuas = new List<Rua>();
            
            foreach (var item in casas.OrderByDescending(x => x.TotalEleitores))
            {
                item.Rua.Casas.Add(item);

                listaDeRuas.Add(item.Rua);
            }

            return listaDeRuas;
        }
    }
}
