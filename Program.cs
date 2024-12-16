namespace Dominos
{
    class Program
    {
        public static void Main(string[] args)
        {
            RandomSolve();
            FileSolve();
        }

        private static void RandomSolve()
        {
            Console.Write("Random solve:\nPlease, provide number of dominos: ");
            var dominosCount = Convert.ToInt32(Console.ReadLine());
            var dominos = DominoSetGenerator.Generate(dominosCount);

            DominoChainSolver.Solve(dominos);
        }

        private static void FileSolve()
        {
            Console.WriteLine("\nFile solve:");
            var path = @"dominos.txt";
            var dominos = FileReader.ReadDominoSetsFromFile(path);

            DominoChainSolver.Solve(dominos);
        }
    }
}