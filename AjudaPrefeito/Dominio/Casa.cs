using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudaPrefeito.Dominio
{
    public class Casa
    {

        public Casa(int id, int numero, int totalEleitores, Rua rua)
        {
            Id = id;
            Numero = numero;
            TotalEleitores = totalEleitores;
            Rua = rua;
        }

        public int Id { get; private set; }
        public int Numero { get; private set; }
        public int TotalEleitores { get; private set; }

        public Rua Rua { get; private set; }
    }
}
