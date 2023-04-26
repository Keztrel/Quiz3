class program {
    private static int numStalls;

    static void Main(string[] args)
     {
               int[] stalls = new int[numStalls];

        for (int i = 0; i < numStalls; i++)
        {
            stalls[i] = i + 1;
        }

        while (true)
        {
            Console.WriteLine("Enter the stall number(s) you want to reserve (enter 0 or a negative integer to reserve only one panel): ");
            int stallStart = int.Parse(Console.ReadLine());
            int stallEnd = int.Parse(Console.ReadLine());

            if (stallStart <= 0 || stallEnd <= 0)
            {
                int stallToReserve = Math.Abs(stallStart + stallEnd - 1);
                if (stallToReserve > numStalls || stalls[stallToReserve - 1] == -1)
                {
                    Console.WriteLine("Invalid stall number. Please try again.");
                    continue;
                }
                else
                {
                    stalls[stallToReserve - 1] = -1;
                    Console.WriteLine("Stall panel {0} is reserved.", stallToReserve);
                }
            }
            else if (stallStart > 0 && stallEnd > 0)
            {
                if (stallStart > stallEnd)
                {
                    int temp = stallStart;
                    stallStart = stallEnd;
                    stallEnd = temp;
                }

                for (int i = stallStart; i <= stallEnd; i++)
                {
                    if (i > numStalls || stalls[i - 1] == -1)
                    {
                        Console.WriteLine("Invalid stall number(s). Please try again.");
                        break;
                    }
                    stalls[i - 1] = -1;
                }
                Console.WriteLine("Stall panels {0} to {1} are reserved.", stallStart, stallEnd);
            }

            Console.WriteLine("=============================");
            Console.WriteLine("Current Stall Reservation Status: ");
            for (int i = 0; i < numStalls; i++)
            {
                Console.Write(" {0} ", stalls[i] == -1 ? "X" : stalls[i].ToString());
            }
            Console.WriteLine("\n");
        }
    }
}
