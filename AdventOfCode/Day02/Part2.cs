namespace AdventOfCode.Day02;

public static class Part2
{
    public static void Solve()
    {
        // Input consists of comma-separated ranges: start-end
        // Example: "11-22,95-115,..."
        var input = "1-14,46452718-46482242,16-35,92506028-92574540,1515128146-1515174322,56453-79759,74-94,798-971,49-66,601-752,3428-4981,511505-565011,421819-510058,877942-901121,39978-50500,9494916094-9494978970,7432846301-7432888696,204-252,908772-990423,21425-25165,1030-1285,7685-9644,419-568,474396757-474518094,5252506279-5252546898,4399342-4505058,311262290-311393585,1895-2772,110695-150992,567521-773338,277531-375437,284-364,217936-270837,3365257-3426031,29828-36350";

        // Split input into individual ranges
        var inputrange = input.Split(',');

        // Store all invalid IDs found
        var invalidNumbers = new List<long>();

        foreach (var range in inputrange)
        {
            // Each range is in the form start-end
            var parts = range.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);

            // Check every number in the range
            for (long i = start; i <= end; i++)
            {
                // Convert number to string for pattern checking
                var s = i.ToString();

                // Invalid if the number is made by repeating a digit sequence
                // at least twice (e.g., 55, 6464, 123123, 111, 121212)
                if (HasConcurrentNumber(s))
                {
                    invalidNumbers.Add(i);
                }
            }
        }

        // Final result: sum of all invalid IDs
        Console.WriteLine("Day 02 part 2 Sum of invalid range ");
        Console.WriteLine(invalidNumbers?.Sum());
    }

    /// <summary>
    /// Returns true if the string is composed of a smaller substring
    /// repeated at least twice.
    ///
    /// Examples:
    ///  - "55"       -> true  ("5" repeated)
    ///  - "6464"     -> true  ("64" repeated)
    ///  - "123123"   -> true  ("123" repeated)
    ///  - "111"      -> true  ("1" repeated)
    ///  - "1212"     -> true  ("12" repeated)
    ///  - "123"      -> false
    /// </summary>
    private static bool HasConcurrentNumber(string val)
    {
        int len = val.Length;

        // Try all possible chunk sizes up to half the length
        for (int i = 1; i <= len / 2; i++)
        {
            // Length must be divisible by the chunk size
            if (len % i != 0)
                continue;

            // First chunk to compare against
            string chunk = val.Substring(0, i);
            bool ok = true;

            // Compare all subsequent chunks
            for (int j = i; j < len; j += i)
            {
                var chunk2 = val.Substring(j, i);
                if (chunk2 != chunk)
                {
                    ok = false;
                    break;
                }
            }

            // If all chunks matched, it's a repeated pattern
            if (ok)
                return true;
        }

        // No repeating pattern found
        return false;
    }
}
