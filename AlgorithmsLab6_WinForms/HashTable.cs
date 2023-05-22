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

            public static bool IsDeleted(HashNode? hashNode)
            {
                if(hashNode == null) 
                    return false;

                if(hashNode.Value == HashNode.Deleted.Value && hashNode.Key == HashNode.Deleted.Key)
                    return true;

                return false;
            }
        }

        protected readonly int _size;

        public HashNode?[] HashNodes { get; private set; }

        public HashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            _size = size;

            HashNodes = new HashNode[_size];

            for (int i = 0; i < _size; i++)
            {
                HashNodes[i] = null;
            }
        }

        protected abstract int GetHash(int key, int i);

        public int Insert(string key, string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            int i = 0;
            int hash = StringKeyToInt(key);

            do
            {
                if (HashNodes[hash] == null || HashNode.IsDeleted(HashNodes[hash]))
                {
                    HashNode hashNode = new HashNode(key, value);

                    HashNodes[hash] = hashNode;

                    return hash;
                }

                i++;
                hash = GetHash(hash, i);
            } while (i < _size);

            throw new OverflowException();
        }

        public string? Search(string key) 
        {
            int i = 0;
            int hash = StringKeyToInt(key);
            do
            {

                if (HashNodes[hash]?.Key == key)
                {
                    return HashNodes[hash]?.Value;
                }

                i++;
                hash = GetHash(hash, i);
            } while (i < _size && HashNodes[hash] != null);

            return null;
        }

        public int Delete(string key)
        {
            int i = 0;
            int hash = StringKeyToInt(key);

            do
            {
                if (HashNodes[hash]?.Key == key)
                {
                    HashNodes[hash] = HashNode.Deleted;
                    return hash;
                }

                i++;
                hash = GetHash(hash, i);
            } while (i < _size && HashNodes[hash] != null);

            throw new ArgumentException(null, nameof(key));
        }

        public string Extract(string key)
        {
            int i = 0;
            int hash = StringKeyToInt(key);

            do
            {
                if (HashNodes[hash] != null && HashNodes[hash].Key == key)
                {
                    string temp = HashNodes[hash].Value;
                    HashNodes[hash] = HashNode.Deleted;
                    return temp;
                }
                
                i++;
                hash = GetHash(hash, i);
            } while (i < _size && HashNodes[hash] != null);

            throw new ArgumentException(null, nameof(key));
        }

        public int StringKeyToInt(string key)
        {
            int k = 0;
            
            foreach (var ch in key)
            {
                k += ch;
            }

            return k % _size;
        }
    }

    public class HashTableLinear : HashTable
    {
        public HashTableLinear(int size) : base(size)
        {

        }

        protected override int GetHash(int key, int i)
        {
            return (key + 1) % _size;
        }
    }

    public class HashTableDouble : HashTable
    {
        public HashTableDouble(int size) : base(size)
        {

        }

        protected override int GetHash(int key, int i)
        {
            int hash2 = 1 + key % (_size - 1);

            return (key + i * hash2) % _size;
        }
    }

    public class HashTableQuad : HashTable
    {
        public HashTableQuad(int size) : base(size)
        {

        }

        protected override int GetHash(int key, int i)
        {
            return (key + i * i) % _size;
        }
    }
}
