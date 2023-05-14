using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab6
{
    abstract class HashTable
    {
        protected class HashNode
        {
            public string Key { get; private set; }
            public string Value { get; private set; }

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
        }

        private readonly int _size;
        private const decimal A = 0.6180339887m;
        private const int c1 = 1;
        private const int c2 = 2;

        #region [h() functions]
        private int h(int k) => k % _size;

        private int h2(int k) => 1 + (k % (_size - 1));

        protected int hLinear(int k, int i) => (h(k) + i) % _size;

        protected int hQuad(int k, int i) => (h(k) + c1 * i + c2 * i * i) % _size;

        protected int hDouble (int k, int i) => (h(k) + i * h2(k)) % _size;
        #endregion

        private HashNode[] HashNodes { get; set; }

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

        public void Insert(string key, string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key,i);

                if (HashNodes[hash] == null)
                {
                    HashNode hashNode = new HashNode(key, value);

                    HashNodes[hash] = hashNode;

                    Console.WriteLine($"Inserted {key}, {value} in {hash}");

                    return;
                }

                i++;
            } while (i < _size);

            Console.WriteLine("Can`t insert");
        }

        public string Search(string key) 
        {
            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key, i);

                if (HashNodes[hash]?.Key == key)
                {
                    Console.WriteLine($"Hash node with key {key} found at {hash}");
                    return HashNodes[hash].Value;
                }

                Console.WriteLine($"Hash node {hash} is not suitable");
                i++;
            } while (HashNodes[hash] != null && i < _size);

            return null;
        }

        public void Delete(string key)
        {
            int i = 0;
            int hash;

            do
            {
                hash = GetHash(key, i);

                if (HashNodes[hash]?.Key == key)
                {
                    Console.WriteLine($"Hash node with key {key} deleted at {hash}");
                    HashNodes[hash] = null;
                    return;
                }

                Console.WriteLine($"Hash node {hash} is not suitable");
                i++;
            } while (HashNodes[hash] != null && i < _size);
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
                    Console.WriteLine($"Hash node with key {key} extracted from {hash}");
                    string temp = HashNodes[hash].Value;
                    HashNodes[hash] = null;
                    return temp;
                }

                Console.WriteLine($"Hash node {hash} is not suitable");
                i++;
            } while (HashNodes[hash] != null && i < _size);

            return null;
        }
    }

    class HashTableLinear : HashTable
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

    class HashTableQuad : HashTable
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

    class HashTableDouble : HashTable
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
