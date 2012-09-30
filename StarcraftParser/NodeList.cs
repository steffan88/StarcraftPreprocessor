﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace StarcraftParser
{
    public class NodeList<T> : Collection<Node<T>>
    {

        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }

        public void Traverse(Action<Node<T>> v)
        {
            foreach (Node<T> i in Items)
            {
                i.Visit(v);
            }
        }

        //public Node<ScEvent> FindByUnit(string p)
        //{
        //    // search the list for the value
        //    foreach (Node<ScEvent> node in Items)
        //    {
        //        node
        //        if (node.Value. equals(p))
        //            return node;
        //    }
        //    // if we reached here, we didn't find a matching node
        //    return null;
        //}
    }
}
