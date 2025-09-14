# Toy Robot Simulator

This is a simple console-based simulation of a toy robot moving on a tabletop.

## How to Run the Project

1.  **Clone the repository** to your local machine:
    ```sh
    git clone <repository-url>
    ```
2.  **Open a terminal** (Command Prompt, PowerShell, or any other terminal).
3.  **Navigate to the project directory**:
    ```sh
    cd <directory-where-you-cloned-the-repo>
    ```
4.  **Run the application** using the .NET CLI:
    ```sh
    dotnet run
    ```
5.  The application will first ask you to define the width and height of the tabletop.

## Commands

The following commands are available to control the robot:

- `PLACE X,Y,F`

  - Places the robot on the table at coordinates (X,Y) and facing a direction (F).
  - `(X,Y)` must be within the bounds of the table.
  - `F` must be one of the following: `NORTH`, `EAST`, `SOUTH`, `WEST` (case-insensitive).
  - This must be the first command issued to the robot. It can also be used at any time to re-place the robot.
  - Example: `PLACE 0,0,NORTH`

- `MOVE`

  - Moves the robot one unit forward in the direction it is currently facing.
  - The robot will not move if it would fall off the table.

- `LEFT`

  - Rotates the robot 90 degrees to the left without changing its position.

- `RIGHT`

  - Rotates the robot 90 degrees to the right without changing its position.

- `REPORT`

  - Announces the current X, Y, and direction of the robot.
  - Example output: `Output: 0,1,NORTH`

- `ENABLE MAP 1`

  - Enables the visual map display in the console. The map will be shown after every command.

- `ENABLE MAP 0`

  - Disables the visual map display.

- `exit`
  - Quits the simulation.
