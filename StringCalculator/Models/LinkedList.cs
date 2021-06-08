using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorAssignment
{
    public class LinkedList
    {
        public LinkedListNode nodeHead;
        public LinkedListNode present;
        private int capacity;
        public int Count => capacity;
        public LinkedList()
        {
            capacity = 0;
            nodeHead = null;
        }
        public void Add(object item)
        {
            capacity++;

            LinkedListNode node = new LinkedListNode(item);

            if (nodeHead == null)
            {
                nodeHead = node;
            }
            else
            {
                present.MoveNext = node;
            }
            present = node;
        }
        public void ListNodes()
        {
            LinkedListNode tempNode = nodeHead;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.NodeContent);
                tempNode = tempNode.MoveNext;
            }
        }
        public bool Delete(int intPosition)
        {
            if (intPosition == 1)
            {

                Console.WriteLine("Index position one cant be deleted");

                return true;
            }
            if (intPosition > 1 && intPosition <= capacity)
            {
                LinkedListNode tempNode = nodeHead;

                LinkedListNode lastNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == intPosition - 1)
                    {
                        lastNode.MoveNext = tempNode.MoveNext;
                        return true;
                    }
                    count++;

                    lastNode = tempNode;
                    tempNode = tempNode.MoveNext;
                }
            }
            return false;
        }
        public void PrintList(int intPosition)
        {
            if (nodeHead == null)
            {
                Console.WriteLine("Linklist Empty");
            }
            else
            {
                LinkedListNode tempNode = nodeHead;
                LinkedListNode retNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == intPosition - 1)
                    {
                        retNode = tempNode;
                        break;
                    }
                    count++;
                    tempNode = tempNode.MoveNext;
                }
                Console.WriteLine("The Element at Node " + intPosition + " is " + retNode.NodeContent);

            }
        }
    }
    public class LinkedListNode
    {
        public object NodeContent;
        public LinkedListNode MoveNext;
        public LinkedListNode(object itemContent) => this.NodeContent = itemContent;
    }

}
