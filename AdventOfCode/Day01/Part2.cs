//namespace AdventOfCode.Day01;

//public static class Part2
//{
//    public static void Solve()
//    {
//        var count = 0;
//        int pointer = 50;

//        var lines = File.ReadLines("Day01/input.txt");

//        foreach (var line in lines)
//        {
//            char side = line[0];
//            var number = int.Parse(line.Substring(1));

//            var start = pointer;
//            int end;

//            if (side == 'L')
//            {
//                var rawL = pointer - number;
//                end = ((rawL % 100) + 100) % 100;

//                // count zero crossings between (start) down to (rawL)
//                int high = start - 1;
//                int low = rawL;

//                count += CountMultiplesOf100(low, high);

//                pointer = end;
//            }
//            else
//            {
//                var rawR = pointer + number;
//                end = ((rawR % 100) + 100) % 100;

//                // count zero crossings between (start) up to (rawR)
//                int low = start + 1;
//                int high = rawR;

//                count += CountMultiplesOf100(low, high);

//                pointer = end;
//            }
//        }

//        Console.WriteLine("Answerr of Day 1 part 2 " + count);
//    }

//    private static int CountMultiplesOf100(int low, int high)
//    {
//        if (low > high)
//        {
//            var temp = low;
//            low = high;
//            high = temp;
//        }

//        int a = FloorDiv(low, 100);
//        int b = FloorDiv(high, 100);

//        return b - a;
//    }

//    private static int FloorDiv(int a, int b)
//    {
//        if (a >= 0) return a / b;
//        return -(((-a) + b - 1) / b);
//    }
//}
//namespace AdventOfCode.Day01;

//public static class Part2
//{
//    public static void Solve()
//    {
//        int startPoint = 50;
//        int zeroCount = 0;

//        var lines = File.ReadAllLines("Day01/input2.txt");

//        foreach (var element in lines)
//        {
//            if (element[0] == 'L')
//            {
//                int value = int.Parse(element.Substring(1));
//                int preStartValue = startPoint;

//                startPoint -= value;

//                if (startPoint < 0)
//                {
//                    var obj = NegativeValidator(startPoint, preStartValue);
//                    startPoint = obj.startPoint;
//                    zeroCount += obj.zeroCount;
//                }
//            }
//            else if (element[0] == 'R')
//            {
//                int value = int.Parse(element.Substring(1));
//                startPoint += value;

//                if (startPoint > 100)
//                {
//                    var obj = PositiveValidator(startPoint);
//                    startPoint = obj.startPoint;
//                    zeroCount += obj.zeroCount;
//                }
//            }

//            if (startPoint == 100)
//                startPoint = 0;

//            if (startPoint == 0)
//                zeroCount++;
//        }

//        Console.WriteLine("zeroCount2 " + zeroCount);
//    }

//    private static (int startPoint, int zeroCount) NegativeValidator(int startPoint, int preValue)
//    {
//        int value = -100;
//        int zeroCount = 1;

//        while (startPoint < value)
//        {
//            value -= 100;
//            zeroCount++;
//        }

//        if (preValue == 0)
//            zeroCount--;

//        return (-(value - startPoint), zeroCount);
//    }

//    private static (int startPoint, int zeroCount) PositiveValidator(int startPoint)
//    {
//        int counter = 100;
//        int value = 0;
//        int zeroCount = 0;

//        while (startPoint > counter)
//        {
//            counter += 100;
//            value += 100;
//            zeroCount++;
//        }

//        return (startPoint - value, zeroCount);
//    }
//}
namespace AdventOfCode.Day01;

public static class Part2
{
    public static void Solve()
    {
        int pointer = 50;
        int zeroCount = 0;

        foreach (var line in File.ReadLines("Day01/input.txt"))
        {
            char side = line[0];
            int value = int.Parse(line[1..]);

            if (side == 'L')
            {
                int fullTurns = value / 100;
                int leftover = value % 100;

                // full turns always cross 0
                zeroCount += fullTurns;

                int end = pointer - leftover;

                if (end < 0)
                {
                    // leftover crosses 0
                    zeroCount++;
                    end += 100;
                }

                pointer = end;
            }
            else // R block
            {
                int fullTurns = value / 100;
                int leftover = value % 100;

                // full turns always cross 0
                zeroCount += fullTurns;

                int end = pointer + leftover;

                if (end >= 100)
                {
                    // leftover crosses 0
                    zeroCount++;
                    end -= 100;
                }

                pointer = end;
            }
        }

        Console.WriteLine("Answer: " + zeroCount);
    }
}
