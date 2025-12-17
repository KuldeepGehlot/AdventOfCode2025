namespace AdventOfCode.Day02;

public static class Part1
{
    public static void Solve()
    {
        // Input consists of comma-separated ranges: start-end
        // These are the product ID ranges we need to inspect
        var input = "1-14,46452718-46482242,16-35,92506028-92574540,1515128146-1515174322,56453-79759,74-94,798-971,49-66,601-752,3428-4981,511505-565011,421819-510058,877942-901121,39978-50500,9494916094-9494978970,7432846301-7432888696,204-252,908772-990423,21425-25165,1030-1285,7685-9644,419-568,474396757-474518094,5252506279-5252546898,4399342-4505058,311262290-311393585,1895-2772,110695-150992,567521-773338,277531-375437,284-364,217936-270837,3365257-3426031,29828-36350";

        // Split input into individual ranges
        var inputrange = input.Split(',');

        // Store all invalid IDs found
        var invalidNumbers = new List<long>();

        foreach (var range in inputrange)
        {
            // Each range is of the form "start-end"
            var parts = range.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);

            // Check every ID in the range
            for (long i = start; i <= end; i++)
            {
                // Convert number to string for digit comparison
                var s = i.ToString();

                // Part 1 rule:
                // An ID is invalid if it is made by repeating
                // a sequence of digits exactly twice
                // (e.g. 55, 6464, 123123)
                if (IsInvalidId(s))
                {
                    invalidNumbers.Add(i);
                }
            }
        }

        // Output the sum of all invalid IDs
        Console.WriteLine("Sum of invalid range ");
        Console.WriteLine(invalidNumbers?.Sum());
    }

    /// <summary>
    /// Returns true if the string consists of two identical halves.
    ///
    /// Examples:
    ///  - "55"       -> true  ("5" + "5")
    ///  - "6464"     -> true  ("64" + "64")
    ///  - "123123"   -> true  ("123" + "123")
    ///  - "111"      -> false (odd length)
    ///  - "1212"     -> true  ("12" + "12")
    ///  - "123"      -> false
    /// </summary>
    private static bool IsInvalidId(string s)
    {
        int n = s.Length;

        // Length must be even to split into two equal parts
        if (n % 2 != 0)
            return false;

        int half = n / 2;

        // Compare first half with second half
        return s.Substring(0, half) == s.Substring(half, half);
    }
}
