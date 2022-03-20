﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    interface ICustomLinkedList<T>
    {
        /// <summary>
        /// Insert an element into the list
        /// </summary>
        /// <param name="value">The data</param>
        void Insert(T value);
        /// <summary>
        /// Insert an element into the list in a specific position
        /// </summary>
        /// <param name="value">The data</param>
        /// <param name="index">Position in the list</param>
        void Insert(T value, int index);
        /// <summary>
        /// Removes a element from the list
        /// </summary>
        /// <param name="index">Position of the element</param>
        void Delete(int index);
        /// <summary>
        /// Returns an element from the list without remove
        /// </summary>
        /// <param name="index">Position of the element</param>
        /// <returns>The element value</returns>
        T Get(int index);
        /// <summary>
        /// Verifies if the list is empty
        /// </summary>
        /// <returns>true if its empty and false otherwise</returns>
        bool IsEmpty();

        /// <summary>
        /// Returns the number of element in the list
        /// </summary>
        /// <returns>number of elements</returns>
        int Count();
    }
}
