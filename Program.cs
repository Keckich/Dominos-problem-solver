namespace Dominos
{
    class Program
    {
        public static void Main(string[] args)
        {
            var path = @"dominos.txt";
            var dominos = FileReader.ReadDominoSetsFromFile(path);

            DominoChainSolver.Solve(dominos);
        }
    }
}