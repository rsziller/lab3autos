using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class NodoAuto : IComparable
    {
        public string ID { get; set; }
        public string Email { get; set; }

        public string Propietario { get; set; }

        public string Color { get; set; }

        public string Marca { get; set; }

        public string Serie { get; set; }

        public Comparison<NodoAuto> BuscarID = delegate (NodoAuto Auto1, NodoAuto Auto2)
        {
            return Auto1.ID.CompareTo(Auto2.ID);
        };
        public Comparison<NodoAuto> BuscarEmail = delegate (NodoAuto Auto1, NodoAuto Auto2)
        {
            return Auto1.Email.CompareTo(Auto2.Email);
        };
        public Comparison<NodoAuto> BuscarSerie = delegate (NodoAuto Auto1, NodoAuto Auto2)
        {
            return Auto1.Serie.CompareTo(Auto2.Serie);
        };
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
