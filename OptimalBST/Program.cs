namespace OptimalBST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Define the sequence of keys and their corresponding frequencies
            int[] keys = { 10, 20, 30, 40 };
            int[] freq = { 4, 2, 6, 3 };
            double[] pFreq = { 0, 3, 3, 1, 1 };
            double[] fFreq = { 2, 3, 1, 1, 1 };

            // Compute the minimum cost of the optimal binary search tree
            int cost = OBST.OptimalBST(keys, freq);
            // Print the minimum cost
            Console.WriteLine("\nThe minimum cost of optimal binary search tree is: " + cost + "\n");

            double cost1 = OBST.OptimalBST(keys, pFreq, fFreq);
            Console.WriteLine("\nThe minimum cost of optimal binary search tree is: " + cost1);
            _ = Console.ReadLine();
        }
    }
}