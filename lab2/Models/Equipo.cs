using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Coach { get; set; }
        public string Liga { get; set; }
        public string Fecha { get; set; }

        public Equipo(int Id, string Nombre, string Coach, string Liga, string Fecha)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Coach = Coach;
            this.Liga = Liga;
            this.Fecha = Fecha;
        }

        public Equipo()
        {
            
        }

        public Comparison<Equipo> BuscarId = delegate (Equipo Equipo1, Equipo Equipo2)
        {
            return Equipo1.Id.CompareTo(Equipo2.Id);
        };
    }
}
