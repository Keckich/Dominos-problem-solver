namespace Dominos
{
    internal class DominoChainSolver
    {
        public static void Solve(List<List<(int, int)>> dominos)
        {
            foreach (var dominoSet in dominos)
            {
                var orderedSet = dominoSet.OrderBy(d => d.Item1 != d.Item2).ToList();
                var chain = FindCircularChain(orderedSet);
                LogResult(dominoSet, chain);
            }
        }

        private static List<(int, int)> FindCircularChain(List<(int, int)> dominos)
        {
            var used = new bool[dominos.Count()];
            used[0] = true;
            var chain = new List<(int, int)>() { dominos[0] };

            GetChain(dominos, chain, used);

            return chain;
        }

        private static bool GetChain(List<(int, int)> dominos, List<(int, int)> chain, bool[] used)
        {
            if (dominos.Count == chain.Count)
            {
                return true;
            }

            for (int i = 0; i < dominos.Count(); i++)
            {
                if (used[i])
                {
                    continue;
                }

                var current = chain.Last();
                var next = dominos[i];

                if (current.Item2 == next.Item1)
                {
                    chain.Add(next);
                    used[i] = true;
                    if (GetChain(dominos, chain, used))
                    {
                        return true;
                    }

                    RemoveLastPair(i, chain, used);

                }
                else if (current.Item2 == next.Item2)
                {
                    chain.Add((next.Item2, next.Item1));
                    used[i] = true;
                    if (GetChain(dominos, chain, used))
                    {
                        return true;
                    }

                    RemoveLastPair(i, chain, used);
                }
            }

            return false;
        }

        private static void RemoveLastPair(int index, List<(int, int)> chain, bool[] used)
        {
            used[index] = false;
            chain.RemoveAt(chain.Count - 1);
        }

        private static void LogResult(List<(int, int)> dominoSet, List<(int, int)> chain)
        {
            Console.Write("Set: ");
            foreach (var item in dominoSet)
            {
                Console.Write($"[{item.Item1}|{item.Item2}] ");
            }
            if (chain.Count == dominoSet.Count)
            {
                Console.Write("Result chain: ");
                foreach (var item in chain)
                {
                    Console.Write($"[{item.Item1}|{item.Item2}] ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Circular chain is not possible");
            }
        }
    }
}
