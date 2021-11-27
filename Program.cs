using System;

Console.Title = "Tic tac toe";

GameBoard gameBoard = new GameBoard();
gameBoard.PlayerMark();


public class GameBoard
{
    //Top row
    private SquareState _box1 = SquareState.Null;
    private SquareState _box2 = SquareState.Null;
    private SquareState _box3 = SquareState.Null;
    //Middle row
    private SquareState _box4 = SquareState.Null;
    private SquareState _box5 = SquareState.Null;
    private SquareState _box6 = SquareState.Null;
    //Bottom row
    private SquareState _box7 = SquareState.Null;
    private SquareState _box8 = SquareState.Null;
    private SquareState _box9 = SquareState.Null;

    //Round counter
    private int _round = 1;

    private GameState _gameState = GameState.InProgress;

    //Constructor
    public GameBoard() { }

    //Accessors
    public SquareState Box1 { get => _box1; set => _box1 = value; }
    public SquareState Box2 { get => _box2; set => _box2 = value; }
    public SquareState Box3 { get => _box3; set => _box3 = value; }
    public SquareState Box4 { get => _box4; set => _box4 = value; }
    public SquareState Box5 { get => _box5; set => _box5 = value; }
    public SquareState Box6 { get => _box6; set => _box6 = value; }
    public SquareState Box7 { get => _box7; set => _box7 = value; }
    public SquareState Box8 { get => _box8; set => _box8 = value; }
    public SquareState Box9 { get => _box9; set => _box9 = value; }
    public int Round { get => _round; }
    public GameState GameState { get => _gameState; set => _gameState = value; }

    //Change state of box based on whose turn it is
    public void PlayerMark()
    {
        
        while (GameState == GameState.InProgress)
        {
            //On odd-numbered turns, player 1 (X) is making the move.
            SquareState playerTurn;
            string player;
            if (_round % 2 != 0)
            {
                playerTurn = SquareState.X;
                player = "Player 1";
            }
            else { playerTurn = SquareState.O; player = "Player 2"; }

            string boxChoice = null;
            while (boxChoice == null)
            {
                DisplayBoard();
                DisplayBoardKey();
                Console.Write($"{player}, where would you like to move? ");
                boxChoice = Console.ReadLine();

                //Current player chooses box. If the box is not taken, it is given to the
                //player. If it is taken, then the player is prompted to input another box.
                switch (boxChoice)
                {
                    case "1":
                        if (Box1 == SquareState.Null)
                        {
                            Box1 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "2":
                        if (Box2 == SquareState.Null)
                        {
                            Box2 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "3":
                        if (Box3 == SquareState.Null)
                        {
                            Box3 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "4":
                        if (Box4 == SquareState.Null)
                        {
                            Box4 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "5":
                        if (Box5 == SquareState.Null)
                        {
                            Box5 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "6":
                        if (Box6 == SquareState.Null)
                        {
                            Box6 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "7":
                        if (Box7 == SquareState.Null)
                        {
                            Box7 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "8":
                        if (Box8 == SquareState.Null)
                        {
                            Box8 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    case "9":
                        if (Box9 == SquareState.Null)
                        {
                            Box9 = playerTurn;
                            Console.Clear();
                            break;
                        }
                        else { Console.Clear(); Console.WriteLine("This box is already taken."); continue; }
                    default:
                        boxChoice = null;
                        Console.Clear();
                        Console.WriteLine("Invalid entry.");
                        continue;
                }
                //Advance the round only once a valid move has been made.
                _round++;
                WinCheck();
                Console.Clear();
            }
        }

        if (GameState == GameState.Finished)
        {
            string player;

            //The round advances before the wincheck, so we have to subtract 1 to see who the real winner was.
            _round--;
            if (_round % 2 != 0)
            {
                player = "Player 1";
            }
            else { player = "Player 2"; }

            Console.WriteLine($"{player} is the winner!");
            DisplayBoard();
        }

        if (GameState == GameState.Draw)
        {
            Console.WriteLine("Draw!");
            DisplayBoard();
        }

    }

    public void DisplayBoard()
    {
        Console.WriteLine("   |   |   ");

        if (Box1 == SquareState.Null && Box2 == SquareState.Null && Box3 == SquareState.Null)
        {
            Console.WriteLine("   |   |   ");
        }
        else if (Box1 == SquareState.Null && Box2 == SquareState.Null)
        {
            Console.WriteLine($"   |   | {Box3} ");
        }
        else if (Box1 == SquareState.Null && Box3 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box2} |   ");
        }
        else if (Box2 == SquareState.Null && Box3 == SquareState.Null)
        {
            Console.WriteLine($" {Box1} |   |   ");
        }
        else if (Box3 == SquareState.Null)
        {
            Console.WriteLine($" {Box1} | {Box2} |   ");
        }
        else if (Box2 == SquareState.Null)
        {
            Console.WriteLine($" {Box1} |   | {Box3} ");
        }
        else if (Box1 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box2} | {Box3} ");
        }
        else
        {
            Console.WriteLine($" {Box1} | {Box2} | {Box3} ");
        }

        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");

        if (Box4 == SquareState.Null && Box5 == SquareState.Null && Box6 == SquareState.Null)
        {
            Console.WriteLine("   |   |   ");
        }
        else if (Box4 == SquareState.Null && Box5 == SquareState.Null)
        {
            Console.WriteLine($"   |   | {Box6} ");
        }
        else if (Box4 == SquareState.Null && Box6 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box5} |   ");
        }
        else if (Box5 == SquareState.Null && Box6 == SquareState.Null)
        {
            Console.WriteLine($" {Box4} |   |   ");
        }
        else if (Box6 == SquareState.Null)
        {
            Console.WriteLine($" {Box4} | {Box5} |   ");
        }
        else if (Box5 == SquareState.Null)
        {
            Console.WriteLine($" {Box4} |   | {Box6} ");
        }
        else if (Box4 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box5} | {Box6} ");
        }
        else
        {
            Console.WriteLine($" {Box4} | {Box5} | {Box6} ");
        }

        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");

        if (Box7 == SquareState.Null && Box8 == SquareState.Null && Box9 == SquareState.Null)
        {
            Console.WriteLine("   |   |   ");
        }
        else if (Box7 == SquareState.Null && Box8 == SquareState.Null)
        {
            Console.WriteLine($"   |   | {Box9} ");
        }
        else if (Box7 == SquareState.Null && Box9 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box8} |   ");
        }
        else if (Box8 == SquareState.Null && Box9 == SquareState.Null)
        {
            Console.WriteLine($" {Box7} |   |   ");
        }
        else if (Box9 == SquareState.Null)
        {
            Console.WriteLine($" {Box7} | {Box8} |   ");
        }
        else if (Box8 == SquareState.Null)
        {
            Console.WriteLine($" {Box7} |   | {Box9} ");
        }
        else if (Box7 == SquareState.Null)
        {
            Console.WriteLine($"   | {Box8} | {Box9} ");
        }
        else
        {
            Console.WriteLine($" {Box7} | {Box8} | {Box9} ");
        }

        Console.WriteLine("   |   |   ");
    }

    public void DisplayBoardKey()
    {
        Console.WriteLine("\nKey:");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" 1 | 2 | 3 ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" 7 | 8 | 9 ");
        Console.WriteLine("   |   |   \n");

    }

    public void WinCheck()
    {
        //Horizontal matches
        if (Box1 == SquareState.X && Box2 == SquareState.X && Box3 == SquareState.X) GameState = GameState.Finished;
        if (Box1 == SquareState.O && Box2 == SquareState.O && Box3 == SquareState.O) GameState = GameState.Finished;
        if (Box4 == SquareState.X && Box5 == SquareState.X && Box6 == SquareState.X) GameState = GameState.Finished;
        if (Box4 == SquareState.O && Box5 == SquareState.O && Box6 == SquareState.O) GameState = GameState.Finished;
        if (Box7 == SquareState.X && Box8 == SquareState.X && Box9 == SquareState.X) GameState = GameState.Finished;
        if (Box7 == SquareState.O && Box8 == SquareState.O && Box9 == SquareState.O) GameState = GameState.Finished;

        //Vertical matches
        if (Box1 == SquareState.X && Box4 == SquareState.X && Box7 == SquareState.X) GameState = GameState.Finished;
        if (Box1 == SquareState.O && Box4 == SquareState.O && Box7 == SquareState.O) GameState = GameState.Finished;
        if (Box2 == SquareState.X && Box5 == SquareState.X && Box8 == SquareState.X) GameState = GameState.Finished;
        if (Box2 == SquareState.O && Box5 == SquareState.O && Box8 == SquareState.O) GameState = GameState.Finished;
        if (Box3 == SquareState.X && Box6 == SquareState.X && Box9 == SquareState.X) GameState = GameState.Finished;
        if (Box3 == SquareState.O && Box6 == SquareState.O && Box9 == SquareState.O) GameState = GameState.Finished;

        //Diagonal matches
        if (Box1 == SquareState.X && Box5 == SquareState.X && Box9 == SquareState.X) GameState = GameState.Finished;
        if (Box1 == SquareState.O && Box5 == SquareState.O && Box9 == SquareState.O) GameState = GameState.Finished;
        if (Box7 == SquareState.X && Box5 == SquareState.X && Box3 == SquareState.X) GameState = GameState.Finished;
        if (Box7 == SquareState.O && Box5 == SquareState.O && Box3 == SquareState.O) GameState = GameState.Finished;

        //Draw
        if (GameState != GameState.Finished && Box1 != SquareState.Null && Box2 != SquareState.Null &&
            Box3 != SquareState.Null && Box4 != SquareState.Null && Box5 != SquareState.Null &&
            Box6 != SquareState.Null && Box7 != SquareState.Null && Box8 != SquareState.Null &&
            Box9 != SquareState.Null) GameState = GameState.Draw;
    }

}


public enum SquareState { Null, X, O }
public enum GameState { InProgress, Finished, Draw }

/*
    public void DisplayBoard()
    {
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {Box1} | {Box2} | {Box3} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {Box4} | {Box5} | {Box6} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {Box7} | {Box8} | {Box9} ");
        Console.WriteLine("   |   |   ");
    }
*/