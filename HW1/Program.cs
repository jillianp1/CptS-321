//Name: Jillian Plahn
//CptS 321 Assignment: HW1

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get input from user 
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], seperated by spaces:\n");
            int[] input = ReadInput();

            //Initialize binary search tree
            BinaryTree bst = new BinaryTree();

            //Begin to insert numbers into tree
            foreach (int j in input)
            {
                bst.Insert(j);
            }

            //Print tree statistics:
            //Print tree contents smallest to largest:
            Console.WriteLine("Tree contents: ");
            bst.DisplaySorted(bst.root);
            Console.WriteLine("\nTree statistics:");
            //Print number of items in tree:
            int totalCount = bst.Count();
            Console.WriteLine(" Number of nodes: " + totalCount);
            //Print number of levels
            int levels = bst.CountLevels(bst.root);
            Console.WriteLine(" Number of levels: " + levels);
            //Print minimum number of levels
            int minLevels = bst.MinLevels(totalCount);
            Console.WriteLine(" Minimum number of levels that a tree with " + totalCount + " nodes could have = " + minLevels);
            Console.WriteLine("\nDone");
            Console.ReadLine();
        }
        /// <summary>
        ///Takes in input line from user and parses input on spaces
        ///Then converts the parsed string array into an integer array
        ///Then removes duplicate values from integer array and returns final array
        /// </summary>
        /// <returns>
        ///int [] dist
        /// </returns>
        static int[] ReadInput()
        {
            string userInput = Console.ReadLine();
            string[] parses = userInput.Split(' ');
            int[] ints = Array.ConvertAll(parses, s => int.Parse(s));
            int[] dist = ints.Distinct().ToArray();
            return dist;      
        }
    }
    /// <summary>
    /// Node class containing integer for data and Nodes left and right
    /// </summary>
    class Node
    {
        public int data;
        public Node right;
        public Node left;
        public Node(int value)
        {
            data = value;
            right = null;
            left = null;
        }
    }
    /// <summary>
    /// Binary tree class containing the root and count for number of items in tree
    /// Contains insert function for inserting nodes into tree
    /// </summary>
    class BinaryTree
    {
        public Node root;
        int count;
        //Initialize root of tree
        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        /// <summary>
        /// Insert node into tree
        /// </summary>
        /// <param name="value"></param>
        public void Insert(int value)
        {
            //Create new node with data given
            Node newNode = new Node(value);
            newNode.data = value;

            if (root == null)
            {
                root = newNode;
                count++;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (value > current.data)
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            count++;
                            return;
                        }
                    }
                    else
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            count++;
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Returns number of nodes in tree
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }
        /// <summary>
        /// Prints the data of the node in order 
        /// </summary>
        /// <param name="node"></param>
        public void DisplaySorted(Node node)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                DisplaySorted(node.left);
                Console.Write(node.data + " ");
                DisplaySorted(node.right);
            }
        }
        /// <summary>
        /// Counts number of levels in tree by finding right and left levels
        /// Then returns the greater of the two 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int CountLevels(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftLevel = CountLevels(node.left) + 1;
            int rightLevel = CountLevels(node.right) + 1;

            if (leftLevel > rightLevel)
            {
                return leftLevel;
            }
            else
            {
                return rightLevel;
            }
        }
        /// <summary>
        /// Calculates minimum number of levels in tree given number of nodes in tree
        /// Using the formula 1+floor(log_2(n))
        /// Convert number of nodes to a double then finds log and rounds that down
        /// Then converts result to an int for return value
        /// </summary>
        /// <param name="numNodes"></param>
        /// <returns></returns>
        public int MinLevels(int numNodes)
        {
            //Formula: given n number of nodes a tree will have at least 1+floor(log_2(n))
            double nodes = Convert.ToDouble(numNodes);
            double log = Math.Log(nodes, 2);
            double round = Math.Floor(log) + 1;
            return Convert.ToInt32(round);
        }
    }
}


