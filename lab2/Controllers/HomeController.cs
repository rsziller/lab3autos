using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


using System.IO;
using System.Web;

using DataStructures.LinearStructures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {

        //auto
        


        public static ABB<NodoAuto> ArbolBusqueda = new ABB<NodoAuto>();
        public static ABB<NodoAuto> ArbolBusquedaEmail = new ABB<NodoAuto>();
        public static ABB<NodoAuto> ArbolBusquedaSerie = new ABB<NodoAuto>();
        public static List<NodoAuto> Autos = new List<NodoAuto>();
        
        public static string RutaBase;
        public static string RutaArchivoAux;
        private IWebHostEnvironment Environment;

        public static string textoGuardado;
        //auto


        private readonly ILogger<HomeController> _logger;
        public static List<Cliente> clientes = new List<Cliente>();
        public static LinkedList<Cliente> clientesN = new LinkedList<Cliente>();

        public static CustomDoublyLinkedList<Cliente> miLista2 = new CustomDoublyLinkedList<Cliente>();
        public static CustomDoublyLinkedList<Equipo> miListaEquipo = new CustomDoublyLinkedList<Equipo>();
        public static CustomDoublyLinkedList<Jugador> miListaJugador = new CustomDoublyLinkedList<Jugador>();

        public static int IdJugadores = 1;
        public static int IdEquipos = 1;
        public static bool bandera;


        public static Stopwatch Cronometro = new Stopwatch();
        public static long TiempoEjecucion;
        public void EscribirLog(string Texto)
        {
            Texto = Texto + ". Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n";
            string RutaTXT = @"Instrucciones.txt";
            System.IO.File.AppendAllText(RutaTXT, Texto);
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public String HelloWorld(String firstname, String lastname)
        {
            return "Hello " + firstname + " " + lastname;
        }
        public IActionResult FormClient()
        {
            return View();
        }

        public IActionResult FormTeam()
        {
            return View();
        }

        public IActionResult FormPlayer()
        {
            return View();
        }

        public IActionResult test()
        {
            return View();
        }


        public IActionResult SaveClient(string Nombre, string Apellido, int Telefono, string Descripcion)
        {
            Cliente nuevoCliente = new Cliente(Nombre, Apellido, Telefono, Descripcion);
            clientes.Add(nuevoCliente);

            miLista2.Insert(nuevoCliente);

            ViewBag.saveclientsuccess = "Cliente con nombre: " + Nombre + " y apellido: " + Apellido + " guardado exitosamente.";

            return View();
        }

        public IActionResult SaveTeam(string Nombre, string Coach, string Liga, string Fecha)
        {
            Cronometro.Restart();
            Equipo nuevoEquipo = new Equipo(IdEquipos, Nombre, Coach, Liga, Fecha);
            IdEquipos++;

            miListaEquipo.Insert(nuevoEquipo);

            ViewBag.saveteamsuccess = "Equipo con nombre: " + Nombre + " y liga: " + Liga + " guardado exitosamente.";
            Cronometro.Stop();
            EscribirLog("Se Creo Un Equipo");
            Debug.WriteLine("Se Creo Un Equipo. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            return View();
        }

        public IActionResult SavePlayer(string Nombre, string Apellido, string Rol, double KDA, int CreepScore, string Equipo)
        {
            Cronometro.Restart();
            Jugador nuevoJugador = new Jugador(IdJugadores, Nombre, Apellido,  Rol,  KDA,  CreepScore,  Equipo);
            IdJugadores++;

            miListaJugador.Insert(nuevoJugador);

            ViewBag.saveplayersuccess = "Jugador con nombre: " + Nombre + " y apellido: " + Apellido + " guardado exitosamente.";
            
            Cronometro.Stop();
            EscribirLog("Se Creo Un Jugador");
            Debug.WriteLine("Se Creo Un Jugador. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            return View();
        }

        public IActionResult ShowClient()
        {

            //ViewData["clientes"] = clientes;
            ViewData["clientes"] = miLista2;
            return View();
        }

        public IActionResult ShowTeam()
        {
            Cronometro.Restart();
            //ViewData["clientes"] = clientes;
            ViewData["equipos"] = miListaEquipo;
            Cronometro.Stop();
            EscribirLog("Se mostro los equipos");
            Debug.WriteLine("Se mostro los equipos. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            return View();


        }

        public IActionResult ShowPlayer()
        {
            Cronometro.Restart();
            //ViewData["clientes"] = clientes;
            ViewData["jugadores"] = miListaJugador;
            Cronometro.Stop();
            EscribirLog("Se mostro los jugadores");
            Debug.WriteLine("Se mostro los jugadores. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            return View();
        }

        public IActionResult ShowClientName()
        {
            Node();
            ViewData["clientes"] = clientes;
            return View("ShowClient");
        }

        public IActionResult ShowClientLast()
        {
            NodeLast();
            ViewData["clientes"] = clientes;
            return View("ShowClient");
        }

        public void Node()
        {
            Cliente clienteaux;


            for (int i = 0; i < (clientes.Count - 1); i++)
            {
                for (int j = 0; j < (clientes.Count - i - 1); j++)
                {
                    if (string.Compare(clientes[j].Nombre, clientes[j + 1].Nombre) > 0)
                    {
                        clienteaux = clientes[j];
                        clientes[j] = clientes[j + 1];
                        clientes[j + 1] = clienteaux;
                    }
                }
            }
        }

        public void NodeLast()
        {
            Cliente clienteaux;

            for (int i = 0; i < (clientes.Count - 1); i++)
            {
                for (int j = 0; j < (clientes.Count - i - 1); j++)
                {
                    if (string.Compare(clientes[j].Apellido, clientes[j + 1].Apellido) > 0)
                    {
                        clienteaux = clientes[j];
                        clientes[j] = clientes[j + 1];
                        clientes[j + 1] = clienteaux;
                    }
                }
            }

        }

        [HttpPost]
        public IActionResult ImportarCSVT(IFormFile ArchivoCargado)
        {
            Cronometro.Restart();
            int cantidad = 0;
            if (ArchivoCargado.FileName.Contains(".csv"))
            {


                using (var stream = new StreamReader(ArchivoCargado.OpenReadStream()))
                {
                    stream.ReadLine();
                    string Texto = stream.ReadToEnd();
                    foreach (string Fila in Texto.Split("\n"))
                    {
                        Equipo equipo = new Equipo();
                        if (!string.IsNullOrEmpty(Fila))
                        {
                            equipo.Id = IdEquipos;
                            IdEquipos++;
                            equipo.Nombre = Fila.Split(",")[0];
                            equipo.Coach = Fila.Split(",")[1];
                            equipo.Liga = Fila.Split(",")[2];
                            equipo.Fecha = Fila.Split(",")[3];
                            

                            miListaEquipo.Insert(equipo);
                            cantidad++;

                            ViewBag.saveteamsuccess = "Equipo con nombre: " + equipo.Nombre + " y liga: " + equipo.Liga + " guardado exitosamente.";
                        }



                        
                    }
                }
            }
            Cronometro.Stop();
            Debug.WriteLine("Se crearon " + cantidad + " equipos en carga masiva. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");
            EscribirLog("Se crearon " + cantidad + " equipos en carga masiva");
            cantidad = 0;
            return View("SaveTeam");
        }

        [HttpPost]
        public IActionResult ImportarCSVP(IFormFile ArchivoCargado)
        {
            Cronometro.Restart();
            int cantidad = 0;
            if (ArchivoCargado.FileName.Contains(".csv"))
            {


                using (var stream = new StreamReader(ArchivoCargado.OpenReadStream()))
                {
                    stream.ReadLine();
                    string Texto = stream.ReadToEnd();
                    Debug.WriteLine(Texto);
                    foreach (string Fila in Texto.Split("\n"))
                    {
                        Jugador jugador = new Jugador();
                        if (!string.IsNullOrEmpty(Fila))
                        {
                            jugador.Id = IdJugadores;
                            IdJugadores++;
                            jugador.Nombre = Fila.Split(",")[0];
                            jugador.Apellido = Fila.Split(",")[1];
                            jugador.Rol = Fila.Split(",")[2];
                            //Debug.WriteLine(Fila.Split(",")[3]);
                            jugador.KDA = double.Parse(Fila.Split(",")[3]);
                            jugador.CreepScore = Convert.ToInt32(Fila.Split(",")[4]);
                            jugador.Equipo = Fila.Split(",")[5];
                            Debug.WriteLine(Fila.Split(",")[5]);
                            miListaJugador.Insert(jugador);
                            cantidad++;
                            ViewBag.saveteamsuccess = "Jugador con nombre: " + jugador.Nombre + " y apellido: " + jugador.Apellido + " guardado exitosamente.";
                        }




                    }
                }
            }
            
            Cronometro.Stop();
            Debug.WriteLine("Se crearon " + cantidad + " jugadores en carga masiva. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            EscribirLog("Se crearon "+ cantidad + " jugadores en carga masiva");
            cantidad = 0;
            return View("SavePlayer");
        }

        public ActionResult DeletePlayer(int id)
        {
          
            Jugador jugador = new Jugador();
            jugador.Id = id;

            jugador = miListaJugador.Where(x => x.Id == id).FirstOrDefault();
            return View("DeletePlayer", jugador);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id, IFormCollection collection)
        {
            Cronometro.Restart();
            Jugador jugador = new Jugador();
            jugador.Id = Convert.ToInt32(collection["Id"]);
           
            
                miListaJugador.Delete(jugador.BuscarId, jugador);

                ViewBag.Jugadores = miListaJugador;

            Cronometro.Stop();
            EscribirLog("Se elimino un jugador");
            Debug.WriteLine("Se elimino un jugador. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");



            return View("ShowPlayer");
        }


        public ActionResult EditPlayer(int id)
        {
           
            Jugador jugador = new Jugador();
            jugador.Id = id;

            //jugador = miListaJugador.Where(x => x.Id == id).FirstOrDefault();
            jugador = miListaJugador.FindID(jugador.BuscarId, jugador);
            
            return View("EditPlayer", jugador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlayerPost(int id, IFormCollection collection)
        {
            Cronometro.Restart();
            Jugador EditarJugador = new Jugador();
            EditarJugador.Id = id;
            EditarJugador.Nombre = collection["Nombre"];
            EditarJugador.Apellido = collection["Apellido"];
            EditarJugador.Rol = collection["Rol"];
            EditarJugador.KDA = double.Parse(collection["KDA"]);
            EditarJugador.CreepScore = int.Parse(collection["CreepScore"]);
            EditarJugador.Equipo = collection["Equipo"];

            miListaJugador.Edit(EditarJugador.BuscarId, EditarJugador);
            ViewBag.Jugadores = miListaJugador;
            
            Cronometro.Stop();
            EscribirLog("Se edito un jugador");
            Debug.WriteLine("Se edito un jugador. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");


            return View("ShowPlayer");
        }

        public ActionResult DeleteTeam(int id)
        {
           
            Equipo equipo = new Equipo();
            equipo.Id = id;

            equipo = miListaEquipo.Where(x => x.Id == id).FirstOrDefault();

            return View("DeleteTeam", equipo);
        }

        [HttpPost]
        public ActionResult ConfirmDeleteTeam(int id, IFormCollection collection)
        {
            Cronometro.Restart();
            Equipo equipo = new Equipo();
            equipo.Id = Convert.ToInt32(collection["Id"]);
            equipo.Nombre = collection["Nombre"];

            miListaEquipo.Delete(equipo.BuscarId, equipo);

            foreach (Jugador item in miListaJugador)
            {
                if (equipo.Nombre == item.Equipo.Replace("\r", ""))
                {

                    item.Id = Convert.ToInt32(collection["Id"]);


                    miListaJugador.Delete(item.BuscarId, item);
                    ViewBag.Jugadores = miListaJugador;
                }
            }
            ViewBag.Equipos = miListaEquipo;

            Cronometro.Stop();
            EscribirLog("Se elimino un equipo");
            Debug.WriteLine("Se elimino un equipo. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");


            return View("ShowTeam");
        }

        public ActionResult EditTeam(int id)
        {
      
            Equipo equipo = new Equipo();
            equipo.Id = id;

            //jugador = miListaJugador.Where(x => x.Id == id).FirstOrDefault();
            equipo = miListaEquipo.FindID(equipo.BuscarId, equipo);

            return View("EditTeam", equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeamPost(int id, IFormCollection collection)
        {
            Cronometro.Restart();
            Equipo EditarEquipo = new Equipo();
            EditarEquipo.Id = id;
            EditarEquipo.Nombre = collection["Nombre"];
            EditarEquipo.Coach = collection["Coach"];
            EditarEquipo.Liga = collection["Liga"];
            EditarEquipo.Fecha = collection["Fecha"];
        
            miListaEquipo.Edit(EditarEquipo.BuscarId, EditarEquipo);
            ViewBag.equipos = miListaEquipo;

            Cronometro.Stop();
            EscribirLog("Se edito un equipo");
            Debug.WriteLine("Se edito un equipo. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");


            return View("ShowTeam");
        }

        public ActionResult BuscarJugador(string Buscar, string Texto)
        {
            Cronometro.Restart();
            Jugador JugadorBuscar = new Jugador();
           
            CustomDoublyLinkedList<Jugador> ListaBuscar = new CustomDoublyLinkedList<Jugador>();
            if (Buscar == "N")
            {
                JugadorBuscar.Nombre = Texto;
                JugadorBuscar.Apellido = Texto;
                
                 ListaBuscar = miListaJugador.FindAll(JugadorBuscar.BuscarNombreApellido, JugadorBuscar, miListaJugador);
            }
            else if (Buscar == "R")
            {
                JugadorBuscar.Rol = Texto;
               
                    ListaBuscar = miListaJugador.FindAll(JugadorBuscar.BuscarRol, JugadorBuscar, miListaJugador);

            }
            else if (Buscar == "K")
            {
                JugadorBuscar.KDA = Convert.ToDouble(Texto);
                
                    ListaBuscar = miListaJugador.FindAll(JugadorBuscar.BuscarKDA, JugadorBuscar, miListaJugador);
            }
            else if (Buscar == "C")
            {
                JugadorBuscar.CreepScore = Convert.ToInt32(Texto);

                ListaBuscar = miListaJugador.FindAll(JugadorBuscar.BuscarCreepScore, JugadorBuscar, miListaJugador);
            }
            else if (Buscar == "E")
            {
                try
                {
                    JugadorBuscar.Equipo = Texto;

                ListaBuscar = miListaJugador.FindAll(JugadorBuscar.BuscarEquipo, JugadorBuscar, miListaJugador);

                foreach (var item in ListaBuscar)
                {
                    Debug.Write("Equipos: "+item.Equipo);
                }

                }
                catch (Exception) { }
            }

            ViewBag.Jugadores = ListaBuscar;
            
            Cronometro.Stop();
            EscribirLog("Busqueda de Jugadores");
            return View("BuscarJugador");
        }
        //auto

        [HttpPost]
        public IActionResult ImportarAutos(IFormFile ArchivoCargado)
        {
          
            
            if (ArchivoCargado.FileName.Contains(".csv"))
            {


                using (var stream = new StreamReader(ArchivoCargado.OpenReadStream()))
                {
                    Cronometro.Restart();
                    stream.ReadLine();
                    string Texto = stream.ReadToEnd();
                    Debug.WriteLine(Texto);
                    foreach (string Fila in Texto.Split("\r\n"))
                    {
                        NodoAuto nodoauto = new NodoAuto();
                        if (!string.IsNullOrEmpty(Fila))
                        {
                            nodoauto.ID = Fila.Split(",")[0];
                            nodoauto.Email = Fila.Split(",")[1];
                            nodoauto.Propietario = Fila.Split(",")[2];
                            nodoauto.Color = Fila.Split(",")[3];
                            nodoauto.Marca = Fila.Split(",")[4];
                            nodoauto.Serie = Fila.Split(",")[5];
                            ArbolBusqueda.Add(nodoauto, nodoauto.BuscarID);
                            ArbolBusquedaSerie.Add(nodoauto, nodoauto.BuscarSerie);
                            ArbolBusquedaEmail.Add(nodoauto, nodoauto.BuscarEmail);

                        }


                    }
                    Cronometro.Stop();
                    EscribirLog("Se cargo un archivo masivamente");
                    Debug.WriteLine(ArbolBusqueda.Mostrar());
                    Debug.WriteLine("Se cargo un archivo masivamente. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");
                    textoGuardado = Texto;
                    //Console.WriteLine(Texto);
                    
                }
            }
            
            ViewBag.Autos = ArbolBusqueda.Mostrar();
            return View("Index");

        }

        

        public ActionResult CargarAutos()
        {

            return View("ImportarAutos");
        }

        public ActionResult MostrarAutos()
        {

            List<NodoAuto> ListaAutos = ArbolBusqueda.Mostrar();
            return View("MostrarAutos", ListaAutos);
        }


        public ActionResult MostrarAutosEmail()
        {

            /*foreach (string Fila in textoGuardado.Split("\r\n"))
            {
                NodoAuto nodoauto = new NodoAuto();
                if (!string.IsNullOrEmpty(Fila))
                {
                    nodoauto.ID = Fila.Split(",")[0];
                    nodoauto.Email = Fila.Split(",")[1];
                    nodoauto.Propietario = Fila.Split(",")[2];
                    nodoauto.Color = Fila.Split(",")[3];
                    nodoauto.Marca = Fila.Split(",")[4];
                    nodoauto.Serie = Fila.Split(",")[5];
                    ArbolBusquedaEmail.Add(nodoauto, nodoauto.BuscarEmail);


                }


            } */
            Cronometro.Restart();

            List<NodoAuto> ListaAutos = ArbolBusquedaEmail.Mostrar();
            Cronometro.Stop();
            EscribirLog("Se ordeno el arbol por email");
            Debug.WriteLine("Se ordeno el arbol por email. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");
            return View("MostrarAutos", ListaAutos);
        }

        public ActionResult MostrarAutosSerie()
        {

            /*foreach (string Fila in textoGuardado.Split("\r\n"))
            {
                NodoAuto nodoauto = new NodoAuto();
                if (!string.IsNullOrEmpty(Fila))
                {
                    nodoauto.ID = Fila.Split(",")[0];
                    nodoauto.Email = Fila.Split(",")[1];
                    nodoauto.Propietario = Fila.Split(",")[2];
                    nodoauto.Color = Fila.Split(",")[3];
                    nodoauto.Marca = Fila.Split(",")[4];
                    nodoauto.Serie = Fila.Split(",")[5];
                    ArbolBusquedaSerie.Add(nodoauto, nodoauto.BuscarSerie);


                }


            }*/
            Cronometro.Restart();
            
            List<NodoAuto> ListaAutos = ArbolBusquedaSerie.Mostrar();

            Cronometro.Stop();
            EscribirLog("Se ordeno el arbol por serie");
            Debug.WriteLine("Se ordeno el arbol por serie. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");
            return View("MostrarAutos", ListaAutos);
        }

        public IActionResult CargarAutosManual()
        {
            return View();
        }

        public IActionResult GuardarAutosManual(string ID, string Email, string Propietario, string Color, string Marca, string Serie)
        {
            Cronometro.Restart();
            NodoAuto nodoauto = new NodoAuto();

            nodoauto.ID = ID;
            nodoauto.Email = Email;
            nodoauto.Propietario = Propietario;
            nodoauto.Color = Color;
            nodoauto.Marca = Marca;
            nodoauto.Serie = Serie;
            ArbolBusqueda.Add(nodoauto, nodoauto.BuscarID);
            ArbolBusquedaEmail.Add(nodoauto, nodoauto.BuscarEmail);
            ArbolBusquedaSerie.Add(nodoauto, nodoauto.BuscarSerie);

            Cronometro.Stop();
            EscribirLog("Se creo un automovil");
            Debug.WriteLine("Se creo un automovil. Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n");

            return View();
        }

        public ActionResult BuscarAuto(string Buscar, string Texto)
        {
            
            NodoAuto AutoBuscar = new NodoAuto();
            ABB<NodoAuto> ArbolBusquedaEs = new ABB<NodoAuto>();
            Debug.WriteLine(Texto);



            if (Buscar == "I")
            {
                AutoBuscar.ID = Texto;
                Debug.WriteLine(AutoBuscar.ID);
                AutoBuscar = ArbolBusqueda.Get(AutoBuscar, AutoBuscar.BuscarID);
                ArbolBusquedaEs.Add(AutoBuscar, AutoBuscar.BuscarID);



            }
            else if (Buscar == "S")
            {
                AutoBuscar.Serie = Texto;
                Debug.WriteLine(AutoBuscar.Serie.ToString());
                AutoBuscar = ArbolBusquedaSerie.Get(AutoBuscar, AutoBuscar.BuscarSerie);
                ArbolBusquedaEs.Add(AutoBuscar, AutoBuscar.BuscarSerie);
            }
            else if (Buscar == "E")
            {
                AutoBuscar.Email = Texto;

                AutoBuscar = ArbolBusquedaEmail.Get(AutoBuscar, AutoBuscar.BuscarEmail);
                ArbolBusquedaEs.Add(AutoBuscar, AutoBuscar.BuscarEmail);
            }


            List<NodoAuto> ListaAutosBuscar = ArbolBusquedaEs.Mostrar();
            return View("BuscarAuto", ListaAutosBuscar);






        }


    }
}
