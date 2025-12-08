namespace AdventOfCode.Day01;

public static class Part2
{
    public static void Solve()
    {
        int count = 0;
        int pointer = 50;
        var lines = File.ReadLines("Day01/input.txt");

        foreach (var line in lines)
        {
            var increaedPointer = false;
            var quotient = 0;
            char side = line[0];
            var number = int.Parse(line.Substring(1));
            if (side == 'L')
            {
                var remainder = ((pointer - number) % 100 + 100) % 100;
                quotient = (pointer - number) / 100;
                count += Math.Abs(quotient);

                if ((pointer - number) < 0 && (pointer - number) >= -99)
                {
                    count++;
                }

                if (quotient > 0 || remainder == 0)
                {
                    increaedPointer = true;
                }

                if (remainder == 0)
                {
                    count++;
                    pointer = 0;
                }
                else
                    pointer = remainder;
            }
            else
            {
                var remainder = (pointer + number) % 100;

                quotient = (pointer + number) / 100;
                count += Math.Abs(quotient);

                if (quotient > 0 || remainder == 0)
                {
                    increaedPointer = true;
                }

                if (remainder == 0)
                    pointer = 0;
                else
                    pointer = remainder;
            }
            if (pointer == 0 && !increaedPointer)
            {
                count++;
            }
        }
        Console.WriteLine("Answerr of Day 1 part 1 " + count);

    }
}
