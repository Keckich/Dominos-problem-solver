class DominoChainSolver
{
    public static void Main(string[] args)
    {
        var dominos = new List<(int, int)>
        {
            //(2, 1), (2, 3), (1, 3)

            (3, 5), (1, 4), (4, 3), (1, 5), (5, 5), (4, 4)

            //(3, 1), (1, 3), (4, 3), (4, 5), (5, 3)
            //(2, 1), (1, 2), (4, 3), (4, 5), (5, 3)

            //(3, 1), (1, 3), (4, 3), (3, 4), (4, 4) //true
            //(2, 1), (1, 2), (4, 3), (4, 3), (4, 4) //false
        };

        var chain = FindCircularChain(dominos);
        if (chain.Count == dominos.Count)
        {
            foreach (var item in chain)
            {
                Console.Write($"[{item.Item1}|{item.Item2}] ");
            }
        }
        else
        {
            Console.WriteLine("Circular chain is not possible");
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
}