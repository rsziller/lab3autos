using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinearStructures
{
    public class AVL<T> : ADT.BaseTree<T> where T : IComparable
    {
        Node<T> root = null;

        public void Add(Delegate delegado, T dato)
        {
            Node<T> newNode = new Node<T>();
            newNode.left = null;
            newNode.right = null;
            newNode.value = dato;

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                root = InsertElement(delegado, dato, root);
            }
        }

        public void Remove(Delegate delegado, T dato)
        {
            if (root != null)
            {
                root = DeleteElement(delegado, dato, root);
            }
        }

        public List<T> Get()
        {
            List<T> binaryAVL = new List<T>();
            Get(binaryAVL, root);
            return binaryAVL;
        }

        private void Get(List<T> list, Node<T> root)
        {
            if (root != null)
            {
                Get(list, root.left);
                list.Add(root.value);
                Get(list, root.right);
            }
        }

        protected T FindElement(Delegate function, T element, Node<T> root)
        {
            T busqueda = element;
            if (root != null)
            {
                if ((int)function.DynamicInvoke(element, root.value) == 0)
                {
                    return root.value;
                }
                else
                {
                    if ((int)function.DynamicInvoke(element, root.value) < 0)
                    {
                        busqueda = FindElement(function, element, root.left);
                    }
                    else
                    {
                        busqueda = FindElement(function, element, root.right);
                    }
                }
            }
            return busqueda;
        }

        public int BalanceFactor(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return node.FE;
            }
        }
        public Node<T> simpleLeftRotation(Node<T> tempRoot)
        {
            Node<T> aux = tempRoot.left;
            tempRoot.left = aux.right;
            aux.right = tempRoot;
            tempRoot.FE = Math.Max(BalanceFactor(tempRoot.left), BalanceFactor(tempRoot.right)) + 1;
            aux.FE = Math.Max(BalanceFactor(aux.left), BalanceFactor(aux.right)) + 1;
            return aux;
        }

        public Node<T> simpleRightRotation(Node<T> tempRoot)
        {
            Node<T> aux = tempRoot.right;
            tempRoot.right = aux.left;
            aux.left = tempRoot;
            tempRoot.FE = Math.Max(BalanceFactor(tempRoot.left), BalanceFactor(tempRoot.right)) + 1;
            aux.FE = Math.Max(BalanceFactor(aux.left), BalanceFactor(aux.right)) + 1;
            return aux;
        }

        public Node<T> DoubleLeftRotation(Node<T> tempRoot)
        {
            Node<T> aux;
            tempRoot.left = simpleRightRotation(tempRoot.left);
            aux = simpleLeftRotation(tempRoot);
            return aux;
        }

        public Node<T> DoubleRightRotation(Node<T> tempRoot)
        {
            Node<T> aux;
            tempRoot.right = simpleLeftRotation(tempRoot.right);
            aux = simpleRightRotation(tempRoot);
            return aux;
        }


        protected  Node<T> InsertElement(Delegate function, T data, Node<T> root)
        {
            Node<T> newNode = new Node<T>();
            newNode.left = null;
            newNode.right = null;
            newNode.value = data;
            Node<T> tempRoot = root;

            if ((int)function.DynamicInvoke(data, root.value) < 0)
            {
                if (root.left == null)
                {
                    root.left = newNode;
                }
                else
                {
                    root.left = InsertElement(function, data, root.left);

                    if ((BalanceFactor(root.right) - BalanceFactor(root.left) == -2))
                    {
                        if ((int)function.DynamicInvoke(data, root.left.value) < 0)
                        {
                            tempRoot = simpleLeftRotation(root);
                        }
                        else
                        {
                            tempRoot = DoubleLeftRotation(root);
                        }
                    }
                }
            }
            else if ((int)function.DynamicInvoke(data, root.value) > 0)
            {
                if (root.right == null)
                {
                    root.right = newNode;
                }
                else
                {
                    root.right = InsertElement(function, data, root.right);

                    if ((BalanceFactor(root.right) - BalanceFactor(root.left) == 2))
                    {
                        if ((int)function.DynamicInvoke(data, root.right.value) > 0)
                        {
                            tempRoot = simpleRightRotation(root);
                        }
                        else
                        {
                            tempRoot = DoubleRightRotation(root);
                        }
                    }
                }
            }

            if ((root.left == null) && (root.right != null))
            {
                root.FE = root.right.FE + 1;
            }
            else if ((root.left != null) && (root.right == null))
            {
                root.FE = root.left.FE + 1;
            }
            else
            {
                root.FE = Math.Max(BalanceFactor(root.left), BalanceFactor(root.right)) + 1;
            }
            return tempRoot;
        }

        public Node<T> SearchMinRight(Node<T> tempRoot)
        {
            Node<T> aux = tempRoot;
            while (aux.left != null)
            {
                aux = aux.left;
            }
            tempRoot = null;
            return aux;
        }

        public Node<T> SearchMaxLeft(Node<T> tempRoot)
        {
            Node<T> aux = tempRoot;
            while (aux.right != null)
            {
                aux = aux.right;
            }
            tempRoot = null;
            return aux;
        }

        private int getBalance(Node<T> tempRoot)
        {
            if (tempRoot == null)
            {
                return 0;
            }
            return BalanceFactor(tempRoot.left) - BalanceFactor(tempRoot.right);
        }

        protected  Node<T> DeleteElement(Delegate function, T data, Node<T> root)
        {
            if ((int)function.DynamicInvoke(data, root.value) < 0)
            {
                root.left = DeleteElement(function, data, root.left);
            }
            else if ((int)function.DynamicInvoke(data, root.value) > 0)
            {
                root.right = DeleteElement(function, data, root.right);
            }
            else if ((int)function.DynamicInvoke(data, root.value) == 0)
            {
                if (root.left == null || root.right == null)
                {
                    Node<T> tempRoot;

                    if (root.left != null)
                    {
                        tempRoot = root.left;
                    }
                    else
                    {
                        tempRoot = root.right;
                    }

                    if (tempRoot == null)
                    {
                        root = null;
                    }
                    else
                    {
                        root = tempRoot;
                    }
                }
                else
                {
                    Node<T> tempRoot = SearchMinRight(root.right);

                    root.value = tempRoot.value;

                    root.right = DeleteElement(function, tempRoot.value, root.right);
                }
            }

            if (root == null)
            {
                return root;
            }
            else
            {
                root.FE = Math.Max(BalanceFactor(root.left), BalanceFactor(root.right)) + 1;

                if (getBalance(root) > 1 && getBalance(root.left) >= 0)
                {
                    return simpleRightRotation(root);
                }

                if (getBalance(root) > 1 && getBalance(root.left) < 0)
                {
                    root.left = simpleLeftRotation(root.left);
                    return simpleRightRotation(root);
                }

                if (getBalance(root) < -1 && getBalance(root.right) <= 0)
                {
                    return simpleLeftRotation(root);
                }

                if (getBalance(root) < -1 && getBalance(root.right) > 0)
                {
                    root.right = simpleRightRotation(root.right);
                    return simpleLeftRotation(root);
                }
                return root;
            }
        }

        protected  void EditElement(Delegate function, T data)
        {
            throw new NotImplementedException();
        }

        protected override void Insertar(T Valor, Delegate Delegado, Node<T> NodoRaiz)
        {
            throw new NotImplementedException();
        }

        protected override T Obtener(T Valor, Delegate Delegado)
        {
            throw new NotImplementedException();
        }
    }
}

