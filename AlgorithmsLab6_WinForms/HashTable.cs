namespace AlgorithmsLab6
{
    public abstract class HashTable
    {
        public class HashNode
        {
            public static HashNode Deleted => new HashNode { Key = "<DELETED>", Value = "<DELETED>" };
            public string Key { get; private set; }
            public string Value { get; private set; }

            public HashNode()
            {
                Key = string.Empty;
                Value = string.Empty;
            }

            public HashNode(string key, string value)
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(key));

                Key = key;
                Value = value;
            }

            public override string ToString()
            {
                return Key.ToString();
            }

            public static bool IsDeleted(HashNode hashNode)
            {
                if(hashNode.Value == HashNode.Deleted.Value && hashNode.Key == HashNode.Deleted.Key)
                    return true;
                return false;
            }
        }

        private readonly int _size;
        private const int c1 = 1;
        private const int c2 = 3;

        #region [h() functions]
        private int h(int k) => k % _size;

        private int h2(int k) => 1 + (k % (_size - 1));

        protected int hLinear(int k, int i) => (h(k) + i) % _size;

        protected int hQuad(int k, int i) => (h(k) + c1 * i + c2 * i*i) % _size;

        protected int hDouble (int k, int i) => (h(k) + i * h2(k)) % _size;
        #endregion

        public HashNode[] HashNodes { get; private set; }

        public HashTable(int size)
        {
            _size = size;

            HashNodes = new HashNode[_size];

            for (int i = 0; i < _size; i++)
            {
                HashNodes[i] = null;
            }
        }

        protected abstract int GetHash(string key, int i);

        public int Insert(string key, string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key,i);

                if (HashNodes[hash] == null || HashNode.IsDeleted(HashNodes[hash]))
                {
                    HashNode hashNode = new HashNode(key, value);

                    HashNodes[hash] = hashNode;

                    return hash;
                }

                i++;
            } while (i < _size);

            throw new OverflowException();
        }

        public string? Search(string key) 
        {
            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key, i);

                if (HashNodes[hash]?.Key == key)
                {
                    return HashNodes[hash].Value;
                }
                i++;
            } while (i < _size && HashNodes[hash] != null);

            return null;
        }

        public int Delete(string key)
        {
            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key, i);

                if (HashNodes[hash]?.Key == key)
                {
                    HashNodes[hash] = HashNode.Deleted;
                    return hash;
                }
                i++;
            } while (i < _size && HashNodes[hash] != null);

            throw new ArgumentException(null, nameof(key));
        }

        public string Extract(string key)
        {
            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key, i);

                if (HashNodes[hash]?.Key == key)
                {
                    string temp = HashNodes[hash].Value;
                    HashNodes[hash] = HashNode.Deleted;
                    return temp;
                }
                i++;
            } while (i < _size && HashNodes[hash] != null);

            throw new ArgumentException(null, nameof(key));
        }
    }

    public class HashTableLinear : HashTable
    {
        public HashTableLinear(int size) : base(size)
        {

        }

        protected override int GetHash(string key, int i)
        {
            int k = 0;
            foreach (var ch in key)
            {
                k += ch;
            }

            return hLinear(k, i);
        }
    }

    public class HashTableQuad : HashTable
    {
        public HashTableQuad(int size) : base(size)
        {
        }

        protected override int GetHash(string key, int i)
        {
            int k = 0;
            foreach (var ch in key)
            {
                k += ch;
            }

            return hQuad(k, i);
        }
    }

    public class HashTableDouble : HashTable
    {
        public HashTableDouble(int size) : base(size)
        {

        }

        protected override int GetHash(string key, int i)
        {
            int k = 0;
            foreach (var ch in key)
            {
                k += ch;
            }

            return hDouble(k, i);
        }
    }
}
