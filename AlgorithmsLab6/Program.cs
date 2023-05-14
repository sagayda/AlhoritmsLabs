namespace AlgorithmsLab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTableLinear hashTable = new HashTableLinear(6);

            hashTable.Insert("danilo", "one");
            hashTable.Insert("mydilo", "two");
            hashTable.Insert("gigilo", "three");
            hashTable.Insert("rodilo", "four");
            hashTable.Insert("ubilo", "five");
            hashTable.Insert("sortir", "six");

            Console.WriteLine(hashTable.Search("ubilo"));

            Console.WriteLine(hashTable.Extract("rodilo"));
            hashTable.Search("rodilo");

            hashTable.Delete("mydilo");
            hashTable.Search("mydilo");


        }
    }
}