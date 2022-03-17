namespace Utilities.MarksPriorityQueue
{
    public class MarksPriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> _pq = new List<T>();
        public int Count => _pq.Count;
        private readonly Comparer<T> InnerComparer;

        public MarksPriorityQueue()
        {
            InnerComparer = Comparer<T>.Default;
        }

        public MarksPriorityQueue(Comparer<T> comparer)
        {
            InnerComparer = comparer;
        }

        public T Peek()
        {
            if (_pq.Count() == 0) throw new ArgumentException("Priority queue is empty. Cannot peek. Check count first.");
            return _pq[0];
        }

        public void Enqueue(T item)
        {
            _pq.Add(item);
            BubbleUp();
        }

        private void BubbleUp()
        {
            var childIndex = _pq.Count - 1;
            while (childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;
                if (InnerComparer.Compare(_pq[childIndex], _pq[parentIndex]) >= 0)
                {
                    break;
                }
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            var highestPrioritizedItem = _pq[0];

            MoveLastItemToTheTop();
            SinkDown();

            return highestPrioritizedItem;
        }

        private void MoveLastItemToTheTop()
        {
            var lastIndex = _pq.Count - 1;
            _pq[0] = _pq[lastIndex];
            _pq.RemoveAt(lastIndex);
        }

        private void SinkDown()
        {
            var lastIndex = _pq.Count - 1;
            var parentIndex = 0;

            while (true)
            {
                var firstChildIndex = parentIndex * 2 + 1;
                if (firstChildIndex > lastIndex)
                {
                    break;
                }
                var secondChildIndex = firstChildIndex + 1;
                if (secondChildIndex <= lastIndex && InnerComparer.Compare(_pq[secondChildIndex], _pq[firstChildIndex]) < 0)
                {
                    firstChildIndex = secondChildIndex;
                }
                if (InnerComparer.Compare(_pq[parentIndex], _pq[firstChildIndex]) < 0)
                {
                    break;
                }
                Swap(parentIndex, firstChildIndex);
                parentIndex = firstChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            var tmp = _pq[index1];
            _pq[index1] = _pq[index2];
            _pq[index2] = tmp;
        }
    }
}