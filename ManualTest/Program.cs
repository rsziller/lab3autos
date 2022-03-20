using System;
using DataStructures.LinearStructures;
namespace ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*CustomLinkedList<string> miLista = new CustomLinkedList<string>();
            miLista.Insert("prueba");
            miLista.Insert("prueba2");
            miLista.Insert("prueba3");

            foreach (var item in miLista)
            {
                Console.WriteLine("elemento: " + item);
            }
            Console.WriteLine("cantidad de elementos: " + miLista.Count());*/

            CustomDoublyLinkedList<string> miLista2 = new CustomDoublyLinkedList<string>();
            miLista2.Insert("prueba");
            miLista2.Insert("prueba2");
            miLista2.Insert("prueba3");



            foreach (var item in miLista2)
            {
                Console.WriteLine("elemento: " + item);
            }



            Console.WriteLine("primero: " + miLista2.end.previous.value);
            Console.WriteLine("anterior al primero: " + miLista2.Count());
        }
    }
}
