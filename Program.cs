using System;

class Program
{
    static void Main()
    {
        int width = 0, height = 0;
        while (true)
        {
            Console.Write("Enter table width (positive integer): ");
            if (!int.TryParse(Console.ReadLine(), out width) || width <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                continue;
            }

            Console.Write("Enter table height (positive integer): ");
            if (!int.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                continue;
            }
            break;
        }

        Surface table = new Surface(width, height);
        // table.PrintField();

        Robot robot = new Robot(); // Robot with null coordinates
        bool robotPlaced = false;
        bool mapEnabled = false;
        Console.WriteLine("\nType 'PLACE X,Y,F' to place the robot. Type 'ENABLE MAP' to see the map. Type 'exit' to quit.");

        while (true)
        {
            Console.Write("> ");
            string? inputLine = Console.ReadLine();
            if (inputLine == null) continue;

            if (inputLine.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (inputLine.StartsWith("PLACE ", StringComparison.OrdinalIgnoreCase))
            {
                string paramsStr = inputLine.Substring(6);
                string[] parts = paramsStr.Split(',');

                if (parts.Length == 3 &&
                    int.TryParse(parts[0].Trim(), out int px) &&
                    int.TryParse(parts[1].Trim(), out int py))
                {
                    if (Enum.TryParse<Direction>(parts[2].Trim(), true, out Direction face) &&
                        px >= 0 && px < width && py >= 0 && py < height)
                    {
                        robot = new Robot(px, py, face);
                        robotPlaced = true; // Robot is now placed
                        Console.WriteLine($"Robot placed at ({px},{py}) facing {face}.");
                        if (mapEnabled)
                        {
                            table.PrintField(robot);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid PLACE parameters. Make sure coordinates are within bounds and direction is valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PLACE command format. Usage: PLACE X,Y,FACE");
                }
                continue; // Continue to next command
            }

            if (!robotPlaced)
            {
                Console.WriteLine("Please issue a valid PLACE command first.");
                continue;
            }

            // Robot has been placed, handle other commands
            if (inputLine.Equals("MOVE", StringComparison.OrdinalIgnoreCase))
            {
                if (robot.Move(table))
                {
                    Console.WriteLine("Robot moved successfully.");
                }
                else
                {
                    Console.WriteLine("Move ignored. Robot would fall off the table.");
                }
            }
            else if (inputLine.Equals("LEFT", StringComparison.OrdinalIgnoreCase))
            {
                robot.TurnLeft();
                Console.WriteLine($"Robot turned left, now facing {robot.face}.");
            }
            else if (inputLine.Equals("RIGHT", StringComparison.OrdinalIgnoreCase))
            {
                robot.TurnRight();
                Console.WriteLine($"Robot turned right, now facing {robot.face}.");
            }
            else if (inputLine.Equals("REPORT", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(robot.Report());
            }
            else if (inputLine.StartsWith("ENABLE MAP", StringComparison.OrdinalIgnoreCase))
            {
                string[] parts = inputLine.Split(' ');
                if (parts.Length == 3 && int.TryParse(parts[2], out int mode))
                {
                    if (mode == 1)
                    {
                        mapEnabled = true;
                        Console.WriteLine("Map enabled.");
                        table.PrintField(robot);
                    }
                    else if (mode == 0)
                    {
                        mapEnabled = false;
                        Console.WriteLine("Map disabled.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid mode for ENABLE MAP. Use 1 to enable, 0 to disable.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format for ENABLE MAP. Use 'ENABLE MAP 1' or 'ENABLE MAP 0'.");
                }
                continue;
            }
            else
            {
                Console.WriteLine($"Unknown command: {inputLine}");
            }

            if (mapEnabled)
            {
                table.PrintField(robot);
            }
        }
    }
}

