using System.Collections;

namespace AlgorithmsLab4
{
    class QueueByIndex<T>
    {
        public QueueByIndexElem<T> FirstElem { get; private set; }
        public QueueByIndexElem<T> LastElem { get; private set; }
        public QueueByIndex()
        {
            FirstElem = null;
            LastElem = null;
        }
        public void Enqueue(T elem)
        {
            if(FirstElem == null) 
            {
                FirstElem = new QueueByIndexElem<T>(elem);
                LastElem = FirstElem;
                return;
            }

            LastElem.nextElement = new QueueByIndexElem<T>(elem);
            LastElem = LastElem.nextElement;
        }
        public T Dequeue()
        {
            if (FirstElem == null)
                throw new Exception("Blankness exception");

            T elem = FirstElem.Element;
            FirstElem = FirstElem.nextElement;
            return elem;

        }
        public class QueueByIndexElem<T>
        {
            public T Element { get; set; }
            public QueueByIndexElem<T> nextElement { get; set; }
            public QueueByIndexElem(T elem)
            {
                Element = elem;
            }
        }
    }
}
