using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudaPrefeito.Dominio
{
    public class Rua
    {
        public Rua(int id, string cep, string nome)
        {
            Id = id;
            Cep = cep;
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Cep { get; private set; }
        public string Nome { get; private set; }

        public List<Casa> Casas { get; private set; }
    }
}
