namespace AdventOfCode.Day01;

public static class Part1
{
    public static void Solve()
    {
        var count = 0;
        int pointer = 50;
        
        var lines = File.ReadLines("Day01/input.txt");

        foreach (var line in lines)
        {
            char side = line[0];
            var number = int.Parse(line.Substring(1));
            if (side == 'L')
            {
                var remainder = ((pointer - number) % 100 + 100) % 100;

                if (remainder == 0)
                    pointer = 0;
                else
                    pointer = remainder + 100;

            }
            else
            {
                var remainder = (pointer + number) % 100;

                if (remainder == 0)
                    pointer = 0;
                else
                    pointer = remainder;

            }
            if (pointer == 0)
                count++;
            
        }
        Console.WriteLine("Answerr of Day 1 part 1 "+count);
    }
}
