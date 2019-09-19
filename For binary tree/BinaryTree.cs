using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_binary_tree
{
    public class BinaryTree
    {
        public Class_Identificator Data { get; private set; } //объект идентификатора
        public BinaryTree Left { get; set; } // левое поддерево
        public BinaryTree Right { get; set; }// правое поддерево
        public BinaryTree Parent { get; set; } // родитель у вершины поддерева
        /// <summary>
        /// Вставляет целочисленное значение в дерево
        /// </summary>
        /// <param name="data">Значение, которое добавится в дерево</param>
        /// 
        public void Insert(Class_Identificator data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data.HashCode > data.HashCode)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }

        /// <summary>
        /// Вставляет значение в определённый узел дерева
        /// </summary>
        /// <param name="data">Значение</param>
        /// <param name="node">Целевой узел для вставки</param>
        /// <param name="parent">Родительский узел</param>
        private void Insert(Class_Identificator data, BinaryTree node, BinaryTree parent)
        {
            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data.HashCode > data.HashCode)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }


    }
}
