using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinearStructures
{
    public class CustomDoublyLinkedList<T> : ICustomLinkedList<T>, IEnumerable<T>
    {

        public int count;
        public Node<T> start { get; set; }
        public Node<T> end { get; set; }



        public int Count()
        {
            return count;
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }



        public void Insert(T value, int index)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.value = value;
            if (start == null)
            {
                start = newNode;
                end = newNode;

                newNode.previous = null;
                newNode.next = null;
            }
            else
            {
                end.next = newNode;
                newNode.previous = end;
                end = newNode;
            }

            count++;
        }

        public bool IsEmpty()
        {
            return (count == 0);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = start;
            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        public void Delete(Delegate delegado, T Valor)
        {
            Borrar(delegado, Valor);
        }

        protected  void Borrar(Delegate delegado, T Valor)
        {
            Node<T> NodoPivote = new Node<T>();
            NodoPivote = start.next;
            if (Convert.ToInt32(delegado.DynamicInvoke(start.value, Valor)) == 0)
            {
                start = start.next;
                if (start != null)
                {
                    start.previous = null;
                }
                else
                {
                    // When linked list empty after delete 
                    end = null;
                }


            }
            else if (Convert.ToInt32(delegado.DynamicInvoke(end.value, Valor)) == 0)
            {
                end = end.previous;
                if (end != null)
                {
                    end.next = null;
                }
                else
                {
                    // Remove all nodes
                    start = null;
                }



            }
            else
            {
                while (NodoPivote != end)
                {

                    if (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.value, Valor)) == 0)
                    {
                        Node<T> NodoAnterior = NodoPivote.previous;
                        Node<T> NodoSiguiente = NodoPivote.next;
                        NodoSiguiente.previous = NodoAnterior;
                        NodoAnterior.next = NodoSiguiente;
                        NodoPivote = end;
                    }
                    else
                    {
                        NodoPivote = NodoPivote.next;
                    }
                }
            }

        }

        public T FindID(Delegate delegado, T Valor)
        {
            return Obtener(delegado, Valor);
        }

        protected  T Obtener(Delegate delegado, T Valor)
        {
            Node<T> NodoPivote = start;
            while (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.value, Valor)) != 0)
            {

                NodoPivote = NodoPivote.next;

            }
            return NodoPivote.value;
        }

        public void Edit(Delegate delegado, T Valor)
        {
            Node<T> NodoSustituto = new Node<T>();
            NodoSustituto.value = Valor;
            Node<T> NodoPivote = start;



            while (NodoPivote != end.next)
            {

                if (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.value, Valor)) == 0)
                {

                    if (NodoPivote.previous == null)
                    {
                        Node<T> NodoAnterior = NodoPivote.previous;
                        Node<T> NodoSiguiente = NodoPivote.next;
                        start = NodoSustituto;
                        NodoSustituto.next = NodoSiguiente;
                        //NodoSiguiente.previous = NodoSustituto;
                        NodoSustituto.previous = NodoAnterior;
                        NodoPivote.value = NodoSustituto.value;
                        NodoPivote = end.next;
                    }
                    else if (NodoPivote.next == null)
                    {
                        Node<T> NodoAnterior = NodoPivote.previous;
                        Node<T> NodoSiguiente = NodoPivote.next;
                        end = NodoSustituto;
                        NodoSustituto.next = NodoSiguiente;
                        //NodoSiguiente.previous = NodoSustituto;
                        NodoSustituto.previous = NodoAnterior;
                        NodoPivote.value = NodoSustituto.value;
                        NodoPivote = end.next;
                    }
                    else
                    {
                        Node<T> NodoAnterior = NodoPivote.previous;
                        Node<T> NodoSiguiente = NodoPivote.next;
                        NodoAnterior.next = NodoSustituto;
                        NodoSustituto.next = NodoSiguiente;
                        NodoSiguiente.previous = NodoSustituto;
                        NodoSustituto.previous = NodoAnterior;
                        NodoPivote.value = NodoSustituto.value;
                        NodoPivote = end;
                    }
                    

                    /*Node<T> NodoAnterior = NodoPivote.previous;
                        Node<T> NodoSiguiente = NodoPivote.next;
                        NodoAnterior.next = NodoSustituto;
                        NodoSustituto.next = NodoSiguiente;
                        NodoSiguiente.previous = NodoSustituto;
                        NodoSustituto.previous = NodoAnterior;
                        NodoPivote.value = NodoSustituto.value;
                        NodoPivote = end;*/
                }
                else
                {
                    NodoPivote = NodoPivote.next;
                }
            }

        }

        public CustomDoublyLinkedList<T> FindAll(Delegate delegado, T Valor, CustomDoublyLinkedList<T> ListaOriginal)
        {
            CustomDoublyLinkedList<T> ListasFiltrada = new CustomDoublyLinkedList<T>();
            Node<T> NodoPivote = ListaOriginal.start;
            while (NodoPivote != ListaOriginal.end.next)
            {
                if (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.value, Valor)) == 0)
                {
                    ListasFiltrada.Insert(NodoPivote.value);
                    NodoPivote = NodoPivote.next;
                }
                else
                {
                    NodoPivote = NodoPivote.next;
                }
            }
            return ListasFiltrada;
        }


    }
}
