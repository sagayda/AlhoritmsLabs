namespace AlgorithmsLab4
{
    internal class QueueByArray<T>
    {
        private T[] values;
        private int? firstElemIndex;
        private int? lastElemIndex;
        public QueueByArray(int size)
        {
            values = new T[size];
            firstElemIndex = null; 
            lastElemIndex = null;
        }

        public void Enqueue(T elem)
        {
            if(firstElemIndex == null)
            {
                firstElemIndex = 0;
                lastElemIndex = 0;
                values[0] = elem;
                return;
            }

            if (lastElemIndex >= values.Length - 1)
            {
                if (firstElemIndex <= 0)
                    throw new Exception("Queue overflow exception");

                MoveElements();
                values[(int)lastElemIndex + 1] = elem;
                lastElemIndex++;
                return;
            }

            values[(int)lastElemIndex + 1] = elem;
            lastElemIndex++;
        }
        public T Dequeue()
        {
            if(firstElemIndex == null)
                throw new Exception("Blankness exception");

            T temp;
            if (lastElemIndex == firstElemIndex)
            {
                temp = values[(int)firstElemIndex];
                values[(int)firstElemIndex] = default;
                firstElemIndex = null;
                lastElemIndex = null;
                return temp;
            }

            temp = values[(int)firstElemIndex];
            values[(int)firstElemIndex] = default;
            firstElemIndex++;
            return temp;
        }

        private void MoveElements()
        {
            if (firstElemIndex <= 0)
                throw new Exception("Queue overflow exception");

            for (int i = (int)firstElemIndex; i < values.Length; i++)
            {
                values[i - 1] = values[i];
            }

            values[(int)lastElemIndex] = default;
            firstElemIndex--;
            lastElemIndex--;
        }
    }
}
