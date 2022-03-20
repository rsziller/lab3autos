using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinearStructures
{
    public class ABB<T> : ADT.BaseTree<T> where T : IComparable
    {
        Node<T> Raiz = new Node<T>();
        Node<T> Eliminar = new Node<T>();
        public void Add(T value, Delegate delegado)
        {
            Insertar(value, delegado, Raiz);
        }
        public void Delete(T value, Delegate Delegado)
        {
            
        }
        public void Edit(T value, Delegate Delegado)
        {
            

        }
        

        public T Get(T value, Delegate Delegado)
        {
            return Obtener(value, Delegado);
        }
        public List<T> Mostrar()
        {
            List<T> ListaArbol = new List<T>();
            MostrarRaiz(Raiz, ListaArbol);
            return ListaArbol;
        }

        private void MostrarRaiz(Node<T> NodoRaiz, List<T> Lista)
        {
            if (NodoRaiz.value != null)
            {
                MostrarRaiz(NodoRaiz.left, Lista);
                Lista.Add(NodoRaiz.value);
                MostrarRaiz(NodoRaiz.right, Lista);
            }
        }
        

        protected override T Obtener(T value, Delegate Delegado)
        {
            Node<T> NodoPivote = Raiz;
            Node<T> NoEncontrado = new Node<T>();
            while (NodoPivote.value != null)
            {
                if (Convert.ToInt32(Delegado.DynamicInvoke(value, NodoPivote.value)) == 1)
                {
                    if (NodoPivote.right.value != null)
                    {
                        NodoPivote = NodoPivote.right;
                    }
                    else
                    {
                        return NoEncontrado.value;
                    }
                }
                else if (Convert.ToInt32(Delegado.DynamicInvoke(value, NodoPivote.value)) == -1)
                {
                    if (NodoPivote.left.value != null)
                    {
                        NodoPivote = NodoPivote.left;
                    }
                    else
                    {
                        return NoEncontrado.value;
                    }
                }
                else if (Convert.ToInt32(Delegado.DynamicInvoke(value, NodoPivote.value)) == 0)
                {
                    return NodoPivote.value;
                }
                else
                {
                    return NoEncontrado.value;
                }
            }
            return NodoPivote.value;

        }

        protected override void Insertar(T value, Delegate Delegado, Node<T> NodoRaiz)
        {
            if (NodoRaiz.value == null)
            {
                NodoRaiz.value = value;
                NodoRaiz.left = new Node<T>();
                NodoRaiz.right = new Node<T>();
            }
            else if (Convert.ToInt32(Delegado.DynamicInvoke(value, NodoRaiz.value)) == 1)
            {
                Insertar(value, Delegado, NodoRaiz.right);
            }
            else if (Convert.ToInt32(Delegado.DynamicInvoke(value, NodoRaiz.value)) == -1)
            {
                Insertar(value, Delegado, NodoRaiz.left);
            }
        }
        public List<T> Where(Func<T, bool> Predicate)
        {
            var Lista = Mostrar();
            List<T> ListaResultado = new List<T>();
            foreach (T item in Lista)
            {
                if (Predicate(item))
                {
                    ListaResultado.Add(item);
                }
            }
            return ListaResultado;
        }

        

    }
}
