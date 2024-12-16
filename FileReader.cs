namespace Dominos
{
    internal class FileReader
    {
        public static List<List<(int, int)>> ReadDominoSetsFromFile(string filePath)
        {
            var allDominoSets = new List<List<(int, int)>>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var dominoSet = new List<(int, int)>();
                    var dominosString = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var domino in dominosString)
                    {
                        var parts = domino.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length == 2 &&
                            int.TryParse(parts[0], out int num1) &&
                            int.TryParse(parts[1], out int num2))
                        {
                            dominoSet.Add((num1, num2));
                        }
                        else
                        {
                            Console.WriteLine($"Некорректное домино: {domino}");
                        }
                    }

                    if (dominoSet.Count > 0)
                    {
                        allDominoSets.Add(dominoSet);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                throw;
            }

            return allDominoSets;
        }
    }
}
