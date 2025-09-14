using System;

public class Surface
{
    public int width;
    public int height;

    public Surface(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void PrintField()
    {
        // Print from top (height-1) to bottom (0), so (0,0) is south-west
        for (int y = height - 1; y >= 0; --y)
        {
            for (int x = 0; x < width; ++x)
            {
                Console.Write(". ");
            }
            Console.WriteLine();
        }
    }

    public void PrintField(Robot robot)
    {
        // Print from top (height-1) to bottom (0), so (0,0) is south-west
        for (int y = height - 1; y >= 0; --y)
        {
            for (int x = 0; x < width; ++x)
            {
                if (robot.x == x && robot.y == y)
                {
                    Console.Write(robot.Icon + " ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }
    }

    public void Clear()
    {
        Console.Clear();
    }
}
