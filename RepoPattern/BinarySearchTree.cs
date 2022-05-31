using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern
{
    public class BinarySearchTree
    {
        private Node root;
        public Node getRoot()
        {
            return root;
        }

        public void setRoot(Node root)
        {
            this.root = root;
        }

        public Node recursive_insert(Node currentNode, int value)
        {
            return currentNode;
        }

        //Function to call recursive insert
        public bool insert(int value)
        {

            root = recursive_insert(this.root, value);
            return true;
        }

        //Function to check if Tree is empty or not  
        public bool isEmpty()
        {
            return root == null; //if root is null then it means Tree is empty
        }
    }
}
