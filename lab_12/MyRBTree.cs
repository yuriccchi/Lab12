using MyLib;
using System.Xml;

namespace lab_12
{
    public class MyRBTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public Node<TKey, TValue> nullNode = new Node<TKey, TValue>();
        public Node<TKey, TValue> root { get; set; }

        public MyRBTree()
        {
            root = nullNode;
        }

        public void Insert(TKey key, TValue value)
        {
            Node<TKey, TValue> current = root;
            Node<TKey, TValue> parent = nullNode;

            // Поиск места
            while (current != nullNode)
            {
                parent = current;

                int comparison = key.CompareTo(current.Key);

                if (comparison == 0) // Если ключи равны, обновляется значение
                {
                    current.Value = value;
                    return;
                }
                else if (comparison < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            // Создаем новый узел
            Node<TKey, TValue> newNode = new Node<TKey, TValue>(key, value);
            newNode.Parent = parent;

            // Определение, будет ли новый узел левым или правым ребенком для родителя
            if (parent == nullNode)
            {
                // Если дерево пустое, новый узел становится корнем
                root = newNode;
            }
            else if (key.CompareTo(parent.Key) < 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            newNode.Left = nullNode;
            newNode.Right = nullNode;

            BalanceTree(newNode);
        }

        // Возможно 4 ситуации, когда нужна балансировка из-за того, что добавляется новый элемент, который по умолчанию красный, после красного отца:
        // 1: дед нового элемента не корень, дядя красный ==> родителя и дядю в чёрный, деда в красный ==> высота сохранилась
        // 2: дед корень дерева, дядя красный ==> родителя и дядю в чёрный, при этом деда в красный нельзя, но высота и так сохранилась
        // 3: новый элемент образует зигзаг, дядя чёрный ==> левый поворот относительно родителя, после попадаем на 4 ситуацию
        // 4: новый элемент образовал прямую линию-ветку, дядя чёрный ==> родителя в чёрный, деда в красный, поворот относительно деда

        // в обычной ситуации перекрашиваем новый узел в чёрный

        private void BalanceTree(Node<TKey, TValue> node)
        {
            while (node != root && node.Parent.NodeColor == Color.Red)
            {
                Node<TKey, TValue> father = node.Parent;
                Node<TKey, TValue> grandfather = father.Parent;

                if (father == grandfather.Left)
                {
                    Node<TKey, TValue> uncle = grandfather.Right;

                    if (uncle.NodeColor == Color.Red)
                    {
                        father.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        grandfather.NodeColor = Color.Red;
                        node = grandfather;
                    }
                    else
                    {
                        if (node == father.Right)
                        {
                            node = father;
                            leftRotate(node);
                            father = node.Parent;
                        }

                        father.NodeColor = Color.Black;
                        grandfather.NodeColor = Color.Red;
                        rightRotate(grandfather);
                    }
                }
                else
                {
                    Node<TKey, TValue> uncle = grandfather.Left;

                    if (uncle.NodeColor == Color.Red)
                    {
                        father.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        grandfather.NodeColor = Color.Red;
                        node = grandfather;
                    }
                    else
                    {
                        if (node == father.Left)
                        {
                            node = father;
                            rightRotate(node);
                            father = node.Parent;
                        }

                        father.NodeColor = Color.Black;
                        grandfather.NodeColor = Color.Red;
                        leftRotate(grandfather);
                    }
                }
            }

            root.NodeColor = Color.Black;
        }

        private void leftRotate(Node<TKey, TValue> x)
        {
            if (x == null || x == nullNode || x.Right == nullNode)
            {
                return; // Проверка, что x не равен nullNode и у него есть правый потомок
            }

            Node<TKey, TValue> y = x.Right;

            if (y == null || y == nullNode)
            {
                return; // Проверка, что y не равен nullNode
            }

            x.Right = y.Left;

            if (y.Left != nullNode)
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;

            if (x.Parent == nullNode)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Left = x;
            x.Parent = y;
        }

        private void rightRotate(Node<TKey, TValue> x)
        {
            if (x == null || x == nullNode || x.Left == nullNode)
            {
                return; // Проверка, что x не равен nullNode и у него есть левый потомок
            }

            Node<TKey, TValue> y = x.Left;
            if (y == null || y == nullNode)
            {
                return; // Проверка, что y не равен nullNode
            }

            x.Left = y.Right;

            if (y.Right != nullNode)
            {
                y.Right.Parent = x;
            }

            y.Parent = x.Parent;

            if (x.Parent == nullNode)
            {
                root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Right = x;
            x.Parent = y;
        }

        public void Remove(TKey key)
        {
            Node<TKey, TValue> node = FindNode(key);

            if (node != nullNode)
            {
                DeleteNode(node);
            }
            else
            {
                Console.WriteLine("Фигура с таким ключём не записана в дерево");
            }
        }

        public Node<TKey, TValue> FindNode(TKey key)
        {
            Node<TKey, TValue> current = root;

            while (current != nullNode)
            {
                int comparison = key.CompareTo(current.Key);

                if (comparison == 0) // Узел с ключём найден сразу
                {
                    return current;
                }
                else if (comparison < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return nullNode; // Узел не найден
        }

        private void DeleteNode(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> replaceNode; // Узел, который заменит удаляемый узел
            Node<TKey, TValue> removeNode; // Узел, который будет удален

            if (node.Left == nullNode || node.Right == nullNode) // У узла меньше двух детей
            {
                removeNode = node;
            }
            else // У узла два ребенка, находим следующий узел по значению и удаляем его
            {
                removeNode = SetChildOrNull(node);
            }

            if (removeNode.Left != nullNode) // Определяем узел для замены
            {
                replaceNode = removeNode.Left;
            }
            else
            {
                replaceNode = removeNode.Right;
            }

            replaceNode.Parent = removeNode.Parent; // Устанавливаем нового родителя для заменяющего узла

            if (removeNode.Parent == nullNode) // Если удаляемый узел - корень
            {
                root = replaceNode;
            }
            else if (removeNode == removeNode.Parent.Left) // Если удаляемый узел - левый ребенок
            {
                removeNode.Parent.Left = replaceNode;
            }
            else // Если удаляемый узел - правый ребенок
            {
                removeNode.Parent.Right = replaceNode;
            }

            if (removeNode != node) // Если удаляемый узел имеет дочерние узлы
            {
                node.Key = removeNode.Key;
                node.Value = removeNode.Value;
            }

            if (removeNode.NodeColor == Color.Black) // Балансировка после удаления
            {
                FixAfter(replaceNode);
            }
        }

        private Node<TKey, TValue> SetChildOrNull(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> current = node.Right;

            while (current.Left != nullNode)
            {
                current = current.Left;
            }

            return current;
        }

        private void FixAfter(Node<TKey, TValue> node)
        {
            while (node != root && node.NodeColor == Color.Black)
            {
                Node<TKey, TValue> brother;

                if (node == node.Parent.Left)
                {
                    brother = node.Parent.Right;

                    if (brother.NodeColor == Color.Red)
                    {
                        brother.NodeColor = Color.Black;
                        node.Parent.NodeColor = Color.Red;
                        leftRotate(node.Parent);
                        brother = node.Parent.Right;
                    }

                    if (brother.Left.NodeColor == Color.Black && brother.Right.NodeColor == Color.Black)
                    {
                        brother.NodeColor = Color.Red;
                        node = node.Parent;
                    }

                    else
                    {
                        if (brother.Right.NodeColor == Color.Black)
                        {
                            brother.Left.NodeColor = Color.Black;
                            brother.NodeColor = Color.Red;
                            rightRotate(brother);
                            brother = node.Parent.Right;
                        }

                        brother.NodeColor = node.Parent.NodeColor;
                        node.Parent.NodeColor = Color.Black;
                        brother.Right.NodeColor = Color.Black;
                        leftRotate(node.Parent);
                        node = root;
                    }
                }

                else
                {
                    brother = node.Parent.Right;

                    if(brother.NodeColor == Color.Red)
                    {
                        brother.NodeColor = Color.Black;
                        node.Parent.NodeColor = Color.Red;
                        rightRotate(node.Parent);
                        brother = node.Parent.Left;
                    }

                    if(brother.Left.NodeColor == Color.Black && brother.Right.NodeColor == Color.Black)
                    {
                        rightRotate(node.Parent);
                        brother = node.Parent.Left;
                    }

                    else
                    {
                        if(brother.Left.NodeColor == Color.Black)
                        {
                            brother.Right.NodeColor = Color.Black;
                            brother.NodeColor = Color.Red;
                            leftRotate(brother);
                            brother = node.Parent.Left;
                        }

                        brother.NodeColor = node.Parent.NodeColor;
                        node.Parent.NodeColor = Color.Black;
                        brother.Left.NodeColor = Color.Black;
                        rightRotate(node.Parent);
                        node = root;
                    }
                }
            }

            node.NodeColor = Color.Black;
        }

        public void PrintTree()
        {
            if (root == nullNode)
            {
                Console.WriteLine("\nДерево пустое");
            }
            else
            {
                Console.WriteLine("\nДерево:");
                PrintTree(root, 0);
            }
        }

        private void PrintTree(Node<TKey, TValue> node, int indent)
        {
            if (node == nullNode) return;

            if (node.Right != null)
            {
                PrintTree(node.Right, indent + 10);
            }

            Console.ForegroundColor = node.NodeColor == Color.Red ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(new string(' ', indent) + $"{node.Key} : {node.Value}");
            Console.ForegroundColor = ConsoleColor.White;

            if (node.Left != null)
            {
                PrintTree(node.Left, indent + 10);
            }
        }

        public void PrintBlackHeight()
        {
            int blackHeight = CalculateBlackHeight(root);

            Console.WriteLine($"\nЧерная высота дерева: {blackHeight}");
        }

        private int CalculateBlackHeight(Node<TKey, TValue> node)
        {
            if (node == null || node == nullNode)
            {
                return 0;
            }
            else
            {
                int leftBlackHeight = CalculateBlackHeight(node.Left) + (node.NodeColor == Color.Black ? 1 : 0);
                int rightBlackHeight = CalculateBlackHeight(node.Right) + (node.NodeColor == Color.Black ? 1 : 0);

                if (leftBlackHeight != rightBlackHeight && (node.Left != nullNode || node.Right != nullNode))
                {
                    throw new Exception("Нарушено правило черной высоты");
                }

                return leftBlackHeight;
            }
        }

        public void ClearTree()
        {
            ClearTree(root);
            root = nullNode;
        }

        private void ClearTree(Node<TKey, TValue> node)
        {
            if (node == null || node == nullNode)
            {
                return;
            }

            ClearTree(node.Left);
            ClearTree(node.Right);

            node = null;
        }
    }
}
