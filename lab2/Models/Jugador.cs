using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public double KDA { get; set; }
        public int CreepScore { get; set; }
        public string Equipo { get; set; }

        public Jugador(int Id, string Nombre, string Apellido, string Rol, double KDA, int CreepScore, string Equipo)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Rol = Rol;
            this.KDA = KDA;
            this.CreepScore = CreepScore;
            this.Equipo = Equipo;
        }

        public Jugador()
        {
            
        }

        public Comparison<Jugador> BuscarId = delegate (Jugador Jugador1, Jugador Jugador2)
        {
            return Jugador1.Id.CompareTo(Jugador2.Id);
        };

        public Comparison<Jugador> BuscarNombreApellido = delegate (Jugador Jugador1, Jugador Jugador2)
        {

            if (Jugador1.Apellido.CompareTo(Jugador2.Apellido) != 0)
                return Jugador1.Nombre.CompareTo(Jugador2.Nombre);
            else
                return Jugador1.Apellido.CompareTo(Jugador2.Apellido);

        };

        public Comparison<Jugador> BuscarRol = delegate (Jugador Jugador1, Jugador Jugador2)
        {
            return Jugador1.Rol.CompareTo(Jugador2.Rol);
        };

        public Comparison<Jugador> BuscarKDA = delegate (Jugador Jugador1, Jugador Jugador2)
        {
            return Jugador1.KDA.CompareTo(Jugador2.KDA);
        };

        public Comparison<Jugador> BuscarCreepScore = delegate (Jugador Jugador1, Jugador Jugador2)
        {
            return Jugador1.CreepScore.CompareTo(Jugador2.CreepScore);
        };

        public Comparison<Jugador> BuscarEquipo = delegate (Jugador Jugador1, Jugador Jugador2)
        {
            return Jugador1.Equipo.Replace("\r", "").CompareTo(Jugador2.Equipo);
        };
    }
}
