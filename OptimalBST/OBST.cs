namespace OptimalBST
{
    internal static class OBST
    {
        /// <summary>
        /// This method computes the minimum cost of the optimal binary search tree
        /// given an array of keys and their frequencies
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public static int OptimalBST(int[] keys, int[] freq)
        {
            int n = keys.Length;

            // Initialize the cost matrix
            // Create a 2D matrix to store the cost of each subtree
            int[,] cost = new int[n + 1, n + 1];

            // Fill in the matrix for subtrees of length 1
            for (int i = 0; i < n; i++)
            {
                // the cost of a subtree with one node is the frequency of that node
                cost[i, i + 1] = freq[i];
                Console.WriteLine($"cost[{i},{i + 1}] = {cost[i, i + 1]}");
            }

            // Fill in the matrix for subtrees of length 2 to n
            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i < n - len + 1; i++)
                {
                    int j = i + len;
                    // set the cost of the subtree to a very large number at first
                    cost[i, j] = int.MaxValue;

                    // Find the best root node for the subtree
                    for (int k = i + 1; k <= j; k++)
                    {
                        int freqSum = FrequencySum(freq, i, j);

                        // Calculate the value of cost[i][k-1] +cost[k + 1][j] + sum(frequencies[i..j])
                        int value = cost[i, k - 1] + cost[k, j] + freqSum;


                        // If this is the best root node we've found so far, update the cost
                        if (value < cost[i, j])
                        {
                            cost[i, j] = value;
                        }
                    }
                    Console.WriteLine($"cost[{i},{j}] = {cost[i, j]}");
                }
            }
            Print2DArray(cost);
            // Return the total cost of the optimal binary search tree
            return cost[0, n - 1];
        }
        /// <summary>
        /// This method computes the minimum cost of the optimal binary search tree
        /// given an array of keys and their success and failure probabilities
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="pSuccess"></param>
        /// <param name="pFailure"></param>
        /// <returns></returns>
        public static double OptimalBST(int[] keys, double[] pSuccess, double[] pFailure)
        {
            int n = keys.Length;

            double[,] cost = new double[n + 1, n + 1];
            double[,] weight = WeightSum(pSuccess, pFailure);

            for (int i = 0; i <= n; i++)
            {
                if (i != n)
                {
                    cost[i, i + 1] = cost[i, i] + cost[i + 1, i + 1] + weight[i, i] + pSuccess[i + 1] + pFailure[i + 1];
                    Console.WriteLine($"cost[{i},{i + 1}] = {cost[i, i + 1]}");
                }
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i < n - len + 1; i++)
                {
                    int j = i + len;
                    cost[i, j] = int.MaxValue;

                    for (int k = i + 1; k <= j; k++)
                    {
                        double value = 0;
                        value = cost[i, k - 1] + cost[k, j] + weight[i, j];
                        if (value < cost[i, j])
                        {
                            cost[i, j] = value;
                        }
                    }
                    Console.WriteLine($"cost[{i},{j}] = {cost[i, j]}");
                }
            }
            Print2DArray(cost);
            return cost[0, n - 1];
        }
        public static double[,] WeightSum(double[] pSuccess, double[] pFailure)
        {
            var n = pFailure.Length - 1;
            double[,] weight = new double[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                weight[i, i] = pFailure[i];
                for (int j = i + 1; j <= n; j++)
                {
                    weight[i, j] = weight[i, j - 1] + pSuccess[j] + pFailure[j];
                    Console.WriteLine($"weight[{i},{j}] = {weight[i, j]}");
                }
            }
            return weight;
        }
        public static int FrequencySum(int[] freq, int i = 0, int j = 0)
        {
            // Calculate the sum of frequencies of nodes in the subtree
            int freqSum = 0;
            for (int f = i; f <= j - 1; f++)
            {
                freqSum += freq[f];
            }
            return freqSum;
        }
        public static void Print2DArray<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            // print the matrix to the console
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}
