using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinaryTree
{
    public class Node<T> where  T: struct
    {
        public T data;
        public Node<T> leftNode;
        public Node<T> rightNode;


        public Node()
        {
            
        }
        
        public Node(T data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }


    public class BinaryTree<T> where T : struct
    {
        public Node<T> rootNode;
        public int itemOfNumber = 0;
        
        Vector3 leftDirection = new Vector3(-2, -1);
        Vector3 rightDirection = new Vector3(+2f, -1);
        

        public Node<T> CreateNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            return newNode;
        }
        
        public void Add(T data)
        {
            if (rootNode == null)
            {
                rootNode = CreateNode(data);
                itemOfNumber++;
                return;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(rootNode);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.leftNode != null)
                {
                    queue.Enqueue(node.leftNode);
                }
                else
                {
                    node.leftNode = CreateNode(data);
                    itemOfNumber++;
                    return;
                }

                if (node.rightNode != null)
                {
                    queue.Enqueue(node.rightNode);
                }
                else
                {
                    node.rightNode = CreateNode(data);
                    itemOfNumber++;
                    return;
                }
            }
        }


        public void DebugTree()
        {
            if (rootNode == null)
            {
                return;
            }
            
            ShowNode(rootNode,Vector3.zero,0);
            
        }

        void ShowNode(Node<T> node,Vector3 position,float depth)
        {
            DalDebug.DrawText(node.ToString(),position,Color.red);

            if (node.leftNode != null)
            {
                var pos = position + leftDirection;
                pos.x += .5f;

                Debug.DrawLine(position,pos,Color.blue);
                ShowNode(node.leftNode,pos,depth+1);
            }

            if (node.rightNode != null)
            {
                var pos = position +  rightDirection;
                pos.x -= .5f;
                
                Debug.DrawLine(position,pos,Color.blue);
                ShowNode(node.rightNode,pos,depth+1);
            }
        }
    }

}

