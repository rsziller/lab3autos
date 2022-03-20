using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinearStructures
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }

        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

        /*public Node()
        {

        }

        public Node(T value)
        {
            this.value = value;
        }*/
    }
}
