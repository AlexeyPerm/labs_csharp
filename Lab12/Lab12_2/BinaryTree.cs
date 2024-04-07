using ClassLibraryLab10;

namespace Lab12_2;

public class BinaryTree
{
    #region Node
    public class Node
    {
        private Organisation _data;
        private Node _left;
        private Node _right;

        public Node()
        {
            _data = new Organisation();
            _left = null;
            _right = null;
        }

        /// <summary>
        /// Рандомное заполнение элемента
        /// </summary>
        /// <param name="random">Рандом или не рандом?</param>
        public Node(bool random)
        {
            if (!random) return;
            _data = new Organisation();
            _data.RandomInit();
            _left = null;
            _right = null;
        }

        public Node(Organisation data)
        {
            _data = data;
            _left = null;
            _right = null;
        }

        public override string ToString()
        {
            return _data.ToString();
        }
    }

    #endregion

    public Node root = null;
}