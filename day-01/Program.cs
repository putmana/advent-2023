namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var partOne = PartOne("input.txt");
            Console.WriteLine(partOne);
        }

        // PART ONE
        static int PartOne(string path)
        {
            // Open and read the file
            var lines = File.ReadAllLines(path);

            // Add up the value from each line
            return lines.Aggregate(0, (total, line) =>
            {
                // Convert string into array of valid integers
                var nums = line
                    .Where(chr => int.TryParse(chr.ToString(), out _)) // Filter out non-integer characters
                    .Select(chr => int.Parse(chr.ToString())); // Parse character as an integer

                // Return a two-digit number made of the first and last integers in the array
                return total + (nums.First() * 10 + nums.Last());

            });
        }
    }
}
