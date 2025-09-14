using System;

public class Robot
{
    public int? x;
    public int? y;
    public Direction face;

    public char Icon
    {
        get
        {
            return face switch
            {
                Direction.NORTH => '↑',
                Direction.EAST => '→',
                Direction.SOUTH => '↓',
                Direction.WEST => '←',
                _ => 'R',
            };
        }
    }

    public Robot(int? x = null, int? y = null, Direction face = Direction.NORTH)
    {
        this.x = x;
        this.y = y;
        this.face = face;
    }

    public bool Move(Surface surface)
    {
        if (!x.HasValue || !y.HasValue) return false;

        int newX = x.Value;
        int newY = y.Value;

        switch (face)
        {
            case Direction.NORTH:
                newY++;
                break;
            case Direction.EAST:
                newX++;
                break;
            case Direction.SOUTH:
                newY--;
                break;
            case Direction.WEST:
                newX--;
                break;
        }

        if (newX >= 0 && newX < surface.width && newY >= 0 && newY < surface.height)
        {
            x = newX;
            y = newY;
            return true;
        }

        return false; // else, the move is ignored
    }

    public void TurnLeft()
    {
        face = face switch
        {
            Direction.NORTH => Direction.WEST,
            Direction.WEST => Direction.SOUTH,
            Direction.SOUTH => Direction.EAST,
            Direction.EAST => Direction.NORTH,
            _ => face
        };
    }

    public void TurnRight()
    {
        face = face switch
        {
            Direction.NORTH => Direction.EAST,
            Direction.EAST => Direction.SOUTH,
            Direction.SOUTH => Direction.WEST,
            Direction.WEST => Direction.NORTH,
            _ => face
        };
    }

    public string Report()
    {
        if (x.HasValue && y.HasValue)
        {
            return $"Output: {x},{y},{face.ToString().ToUpper()}";
        }
        return "Robot not placed.";
    }
}
