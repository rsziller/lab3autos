using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.LinearStructures;

namespace DataStructures.ADT
{
    public abstract class BaseTree<T>
    {
        protected abstract void Insertar(T Valor, Delegate Delegado, Node<T> NodoRaiz);
 
        protected abstract T Obtener(T Valor, Delegate Delegado);

    }
}
