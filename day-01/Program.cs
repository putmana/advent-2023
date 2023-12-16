namespace DayOne
{
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var partOne = PartOne("input.txt");
            Console.WriteLine(partOne);

            var partTwo = PartTwo("input.txt");
            Console.WriteLine(partTwo);
        }

        // ======== PART ONE ======== 
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


        // ======== PART TWO ========
        static int PartTwo(string path)
        {
            // Open and read the file
            var lines = File.ReadAllLines(path);

            // Number lookup table
            var lookup = new Dictionary<string, int> {
                {"zero", 0}, {"0", 0},
                {"one", 1}, {"1", 1},
                {"two", 2}, {"2", 2},
                {"three", 3}, {"3", 3},
                {"four", 4}, {"4", 4},
                {"five", 5}, {"5", 5},
                {"six", 6}, {"6", 6},
                {"seven", 7}, {"7", 7},
                {"eight", 8}, {"8", 8},
                {"nine", 9}, {"9", 9},
            };

            // Create a regular expression to match numbers and instances of number words
            var pattern = @"(?<=(zero|one|two|three|four|five|six|seven|eight|nine|[0-9]))";

            // Add up the values from each line
            return lines.Aggregate(0, (total, line) =>
            {
                // Match line against regular expression
                var nums = Regex.Matches(line, pattern)
                    .Select(match => match.Groups[1].Value) // Get matching string
                    .Select(match => lookup[match]); // Use lookup table to convert string to integer

                // Return a two digit number made up of the first and last integers in the array
                return total + (nums.First() * 10 + nums.Last());

            });
        }
    }
}
