using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    public class Node
    {
        public char c;
        public Node next;
        public Node copyN;

        public Node()
        {//default constructor.
            next = null;
        }
        public Node(char o)
        {//builds a list consisting of a single Node containing data character c.
            Node anotherNode;
            c = o;
            anotherNode = null;
        }
        public Node(string s)
        {//builds a list consisting of a collection of Nodes, one character of s per Node.
            int j = 0;
            char[] ch = new char[s.Length];
            int num = ch.Length;
            Node current;
            using (StringReader myReader = new StringReader(s))
            {
                myReader.Read(ch, 0, s.Length);
                //Console.Out.WriteLine(c);
            }
            
            for (j = 0; j < num; j++)
            {
                c = ch[j];
                Node myNode = new Node(c);
                if (next == null)
                    next = myNode;
                else
                {
                    current = next;
                    while (current.next != null)
                        current = current.next;
                    current.next = myNode;
                }
            }
        }//end public Node(string s)
        public Node copy(Node no)
        {//creates a copy of a list: a character-by-character, node-by-node identical copy of the 
            //original list structure; returns a handle to the head of the constructed list structure.

            Node copyN = no;

            while (copyN != null)
            {
                copyN.c = no.c;
                no = no.next;
            }
            return copyN;
        }//end public Node copy()
        public Node reverse()
        {//reverses the linkage within the current list so that the resulting list is the reverse 
            //of the original; returns a handle to the head of the reversed list structure. 
            //You must reverse the links – you may NOT create a reversed copy of the original 
            //list: you must use all the original nodes.
            return next;
        }//end public Node reverse()
        public bool equals(Node n)
        {//a predicate: yields true if the current list structure is equal (in terms of data)
            //to the argument list, n; yields false otherwise. (Do NOT just convert the two 
            //list structures to Strings and then use string compare!)
            return true;
        }
        public override string ToString()
        {//yields a string composed of the data characters from the original list.
            string result = "";

            Node current = next;
            while (current != null)
            {
                result += current.c;
                current = current.next;
            }

            return result;
        }

    }
    class DriverClass
    {
        public void PrintIntro()
        {
            Console.Out.WriteLine("Palindromic Lists");
            Console.Out.WriteLine(" ");
            Console.Out.WriteLine("Author: Jeremy D Swartley");
            Console.Out.WriteLine("Date:   March 26, 2014");
            Console.Out.WriteLine("Course: GSD311 - C# Programming");
            Console.Out.WriteLine("Assignment: Seminar 5 Individual Program");
            Console.Out.WriteLine(" ");
            Console.Out.WriteLine("Place all input strings in a file named 'data.txt' one string per line.");
            Console.Out.WriteLine("The program converts each string into an equivalent list structure, ");
            Console.Out.WriteLine("then it copies the list, reverses it in place, and determines if it ");
            Console.Out.WriteLine("is a 'palindrome' (equal it its reverse).");
        }
        static void Main(string[] args)
        {
            int j;
            string str;
            Node copyNode = null;
            string[] all = System.IO.File.ReadAllLines(@"C:\Users\Jeremy\Documents\1C# Programming\Palindromes.txt");
            int num = all.Length;
            DriverClass newDriver = new DriverClass();
            newDriver.PrintIntro();
            for (j = 0; j < num; j++)
            {
                str = all[j];
                Node newNode = new Node(str);
                Console.Out.Write("Initial string:    ");
                Console.Out.WriteLine(str);
                Console.Out.Write("String as a list:  ");
                Console.Out.WriteLine(newNode);
                Console.Out.Write("Copy as a list:    ");
                copyNode = newNode.copy(newNode);
                Console.Out.WriteLine(copyNode);
                Console.Out.Write("Copy reversed:     ");
                Console.Out.WriteLine();
                Console.Out.WriteLine("");
            }
            Console.In.ReadLine();
        }
    }
}
