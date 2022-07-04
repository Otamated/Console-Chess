using ChessBoard;
using System;


namespace Chess
{
    class Program
    {

        static Board ChessBoard = new Board(8);
        static bool BlacksTurn = false;
        static bool WhiteCheck = false;
        static bool BlackCheck = false;
        static Cell PickedC;
        static Cell CurrentC;
        static string ChessPiece;
        static bool CurrentCIsBlack;


        static void Main(string[] args)
        {
            BlacksTurn = false;
            FillBoard(ChessBoard);
            while (true)
            {
            restart:
                PrintBoard(ChessBoard, BlacksTurn);
                if (PickedC != null)
                {
                    Console.Clear();
                    PrintBoard(ChessBoard, BlacksTurn);
                }
                if (BlacksTurn)
                {
                    Console.WriteLine("It's black turn");
                    if (BlackCheck)
                    {
                        Console.WriteLine("black king is in danger");
                    }
                }
                else
                {
                    Console.WriteLine("It's whites turn");
                    if (WhiteCheck)
                    {
                        Console.WriteLine("White king is in danger");
                    }
                }
                Cell pickedCell = null;
                try
                {
                    //pick piece
                    pickedCell = PickPiece(BlacksTurn);
                    ChessBoard.MarkNextLegalMoves(pickedCell, false);
                    Console.Clear();
                    PrintBoard(ChessBoard, false);
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    goto restart;
                }
                

                //move piece
                char restart = MovePiece(pickedCell);
                PawnZeroToHero();
                MarkAllPossibleMoves();

                //restart
                if (restart == 'r')
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            ChessBoard.TheGrid[i, j].IsPicked = false;
                        }
                    }
                    goto restart;
                }

                //checkmate
                CheckmateCheck();

                if (BlackCheck && BlacksTurn || WhiteCheck && !BlacksTurn)
                {
                    Console.WriteLine("invalid move. your king is in danger...");
                    bool occupied = false;

                    if (ChessPiece != null) { occupied = true; }


                    PickedC.Occupied = true;
                    PickedC.ChessPiece = CurrentC.ChessPiece;

                    CurrentC.Occupied = occupied;
                    CurrentC.ChessPiece = ChessPiece;


                    if (CurrentC.IsBlack)
                    {
                        PickedC.IsBlack = true;

                    }
                    else
                    {
                        PickedC.IsBlack = false;

                    }
                    CurrentC.IsBlack = CurrentCIsBlack;



                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            ChessBoard.TheGrid[i, j].LegalNextMove = false;
                            ChessBoard.TheGrid[i, j].PossibleNextMoveW = false;
                            ChessBoard.TheGrid[i, j].PossibleNextMoveB = false;
                            ChessBoard.TheGrid[i, j].IsPicked = false;
                        }
                    }

                    MarkAllPossibleMoves();

                    goto restart;

                }

                //remove all legal moves
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        ChessBoard.TheGrid[i, j].LegalNextMove = false;
                    }
                }

                

                Console.Clear();

                if (BlacksTurn)
                {
                    BlacksTurn = false;
                }
                else if (!BlacksTurn)
                {
                    BlacksTurn = true;
                }

            }
        }
        private static Board FillBoard(Board board)
        {
            //king
            board.TheGrid[8 - 1, 5 - 1].Occupied = true;
            board.TheGrid[8 - 1, 5 - 1].ChessPiece = "king";
            board.TheGrid[8 - 1, 5 - 1].IsBlack = false;

            //queen
            board.TheGrid[8 - 1, 4 - 1].Occupied = true;
            board.TheGrid[8 - 1, 4 - 1].ChessPiece = "queen";
            board.TheGrid[8 - 1, 4 - 1].IsBlack = false;


            //rook
            board.TheGrid[8 - 1, 1 - 1].Occupied = true;
            board.TheGrid[8 - 1, 1 - 1].ChessPiece = "rook";
            board.TheGrid[8 - 1, 1 - 1].IsBlack = false;

            board.TheGrid[8 - 1, 8 - 1].Occupied = true;
            board.TheGrid[8 - 1, 8 - 1].ChessPiece = "rook";
            board.TheGrid[8 - 1, 8 - 1].IsBlack = false;

            //knight
            board.TheGrid[8 - 1, 2 - 1].Occupied = true;
            board.TheGrid[8 - 1, 2 - 1].ChessPiece = "knight";
            board.TheGrid[8 - 1, 2 - 1].IsBlack = false;

            board.TheGrid[8 - 1, 7 - 1].Occupied = true;
            board.TheGrid[8 - 1, 7 - 1].ChessPiece = "knight";
            board.TheGrid[8 - 1, 7 - 1].IsBlack = false;

            //bishop
            board.TheGrid[8 - 1, 3 - 1].Occupied = true;
            board.TheGrid[8 - 1, 3 - 1].ChessPiece = "bishop";
            board.TheGrid[8 - 1, 3 - 1].IsBlack = false;

            board.TheGrid[8 - 1, 6 - 1].Occupied = true;
            board.TheGrid[8 - 1, 6 - 1].ChessPiece = "bishop";
            board.TheGrid[8 - 1, 6 - 1].IsBlack = false;


            //pawn
            for (int i = 0; i < 8; i++)
            {
                board.TheGrid[7 - 1, i].Occupied = true;
                board.TheGrid[7 - 1, i].ChessPiece = "pawn";
                board.TheGrid[7 - 1, i].IsBlack = false;
            }

            //black
            //king
            board.TheGrid[1 - 1, 5 - 1].Occupied = true;
            board.TheGrid[1 - 1, 5 - 1].ChessPiece = "king";
            board.TheGrid[1 - 1, 5 - 1].IsBlack = true;

            //queen
            board.TheGrid[1 - 1, 4 - 1].Occupied = true;
            board.TheGrid[1 - 1, 4 - 1].ChessPiece = "queen";
            board.TheGrid[1 - 1, 4 - 1].IsBlack = true;


            //rook
            board.TheGrid[1 - 1, 1 - 1].Occupied = true;
            board.TheGrid[1 - 1, 1 - 1].ChessPiece = "rook";
            board.TheGrid[1 - 1, 1 - 1].IsBlack = true;

            board.TheGrid[1 - 1, 8 - 1].Occupied = true;
            board.TheGrid[1 - 1, 8 - 1].ChessPiece = "rook";
            board.TheGrid[1 - 1, 8 - 1].IsBlack = true;

            //knight
            board.TheGrid[1 - 1, 2 - 1].Occupied = true;
            board.TheGrid[1 - 1, 2 - 1].ChessPiece = "knight";
            board.TheGrid[1 - 1, 2 - 1].IsBlack = true;

            board.TheGrid[1 - 1, 7 - 1].Occupied = true;
            board.TheGrid[1 - 1, 7 - 1].ChessPiece = "knight";
            board.TheGrid[1 - 1, 7 - 1].IsBlack = true;

            //bishop
            board.TheGrid[1 - 1, 3 - 1].Occupied = true;
            board.TheGrid[1 - 1, 3 - 1].ChessPiece = "bishop";
            board.TheGrid[1 - 1, 3 - 1].IsBlack = true;

            board.TheGrid[1 - 1, 6 - 1].Occupied = true;
            board.TheGrid[1 - 1, 6 - 1].ChessPiece = "bishop";
            board.TheGrid[1 - 1, 6 - 1].IsBlack = true;


            //pawn
            for (int i = 0; i < 8; i++)
            {
                board.TheGrid[2 - 1, i].Occupied = true;
                board.TheGrid[2 - 1, i].ChessPiece = "pawn";
                board.TheGrid[2 - 1, i].IsBlack = true;
            }

            return board;
        }
        private static void PrintBoard(Board board, bool BlacksTurn)
        {
            Console.WriteLine("     a   b   c   d   e   f   g   h");
            for (int i = 0; i < ChessBoard.Size; i++)
            {
                Console.WriteLine("   +---+---+---+---+---+---+---+---+");
                int space = i + 1;
                Console.Write(" " + (9 - space) + " ");
                

                for (int j = 0; j < ChessBoard.Size; j++)
                {
                    Cell c = ChessBoard.TheGrid[i, j];
                    if (c.Occupied && BlacksTurn && c.LegalNextMove)
                    {
                        Console.Write("|");
                        ChangeBackground(i, j);
                        switch (c.ChessPiece)
                        {
                            case "king":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" K ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "queen":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" Q ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "rook":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" R ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "bishop":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" B ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "knight":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" N ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "pawn":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" p ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                        }
                    }
                    else if (c.Occupied && !BlacksTurn && c.LegalNextMove)
                    {
                        Console.Write("|");
                        ChangeBackground(i, j);
                        switch (c.ChessPiece)
                        {
                            case "king":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" K ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "queen":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" Q ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "rook":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" R ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "bishop":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" B ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "knight":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" N ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case "pawn":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(" p ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                        }
                    }
                    else if (c.CheckedKing && c.IsBlack && c.Occupied && c.ChessPiece == "king")
                    {
                        Console.Write("|");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" K ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (c.CheckedKing && !c.IsBlack && c.Occupied && c.ChessPiece == "king")
                    {
                        Console.Write("|");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" K ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (c.Occupied)
                    {

                        Console.Write("|");
                        ChangeBackground(i, j);
                        if (c.IsPicked && c.Occupied)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                        }


                        if (c.IsBlack)
                        {
                            switch (c.ChessPiece)
                            {
                                case "king":
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" K ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "queen":

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" Q ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "rook":
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" R ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "bishop":

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" B ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "knight":

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" N ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "pawn":

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" p ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;

                            }

                        }
                        else
                        {
                            switch (c.ChessPiece)
                            {
                                case "king":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" K ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "queen":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" Q ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "rook":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" R ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "bishop":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" B ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "knight":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" N ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "pawn":

                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write(" p ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;

                            }
                        }
                    }
                    else if (c.LegalNextMove)
                    {
                        Console.Write("|");
                        ChangeBackground(i, j);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" + ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    //dev state 
                    //else if (c.PossibleNextMoveB && c.PossibleNextMoveW)
                    //{
                    //    Console.Write("|");
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.Write(" x ");
                    //    Cons ole.ForegroundColor = ConsoleColor.White;
                    //}
                    //else if (c.PossibleNextMoveB && !c.PossibleNextMoveW)
                    //{
                    //    Console.Write("|");
                    //    Console.ForegroundColor = ConsoleColor.Cyan;
                    //    Console.Write(" + ");
                    //    Console.ForegroundColor = ConsoleColor.White;


                    //}
                    //else if (c.PossibleNextMoveW && !c.PossibleNextMoveB)
                    //{
                    //    Console.Write("|");
                    //    Console.ForegroundColor = ConsoleColor.Yellow;
                    //    Console.Write(" + ");
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //}

                    else
                    {
                        Console.Write("|");
                        ChangeBackground(i, j);
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                }
                Console.Write("|");
                Console.Write(" " + (9 - space) + " ");
                if (9 - space == 8)
                {
                    Console.Write("        Type [R] To Repick Piece");
                }
                else if(9 - space == 7)
                {
                    Console.Write("        Type 'SwapR' To Do Castling Right Or Type 'SwapL' To Do Castling Left");
                }
                Console.WriteLine();

            }
            Console.WriteLine("   +---+---+---+---+---+---+---+---+");
            Console.WriteLine("     a   b   c   d   e   f   g   h");
            Console.WriteLine(" ");
            Console.WriteLine("====================================");
        }
        private static Cell PickPiece(bool BlacksTurn)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessBoard.TheGrid[i, j].IsPicked = false;
                }
            }

        invalidPick:

            Console.WriteLine("Enter coordinates of the piece you want to move");
            string input = Console.ReadLine().ToLower();

            int column;
            switch (input[0])
            {
                case 'a':
                    column = 0;
                    break;

                case 'b':
                    column = 1;
                    break;

                case 'c':
                    column = 2;
                    break;

                case 'd':
                    column = 3;
                    break;

                case 'e':
                    column = 4;
                    break;

                case 'f':
                    column = 5;
                    break;

                case 'g':
                    column = 6;
                    break;

                case 'h':
                    column = 7;
                    break;
                default:
                    column = 8;
                    break;

            }
            string rowS = Convert.ToString(input[1]);
            int row = 8 - Convert.ToInt32(rowS);


            Cell c = ChessBoard.TheGrid[row, column];
            PickedC = c;
            if (BlacksTurn)
            {
                if (c.Occupied && c.IsBlack)
                {
                    c.IsPicked = true;
                }
                else
                {
                    Console.WriteLine("theres not your piece on that cell");
                    goto invalidPick;
                }
            }
            else if (!BlacksTurn)
            {
                if (c.Occupied && !c.IsBlack)
                {
                    c.IsPicked = true;
                }
                else
                {
                    Console.WriteLine("theres not your piece on that cell");
                    goto invalidPick;
                }
            }



            return c;
        }
        private static char MovePiece(Cell PickedCell)
        {
        invalidMove:

            int row = 0;
            int column = 0;
            string input;
            Console.WriteLine("Enter coordinates where u want to move picked piece ");
            input = Console.ReadLine().ToLower();
            if (RookKingSwap())
            {
                
                if (input == "swapr" && PickedC.IsBlack)
                {
                    ChessBoard.TheGrid[0, 4].ChessPiece = null;
                    ChessBoard.TheGrid[0, 4].Occupied = false;

                    ChessBoard.TheGrid[0, 6].ChessPiece = "king";
                    ChessBoard.TheGrid[0, 6].Occupied = true;
                    ChessBoard.TheGrid[0, 6].IsBlack = true;

                    ChessBoard.TheGrid[0, 7].Occupied = false;
                    ChessBoard.TheGrid[0, 7].ChessPiece = null;

                    ChessBoard.TheGrid[0, 5].Occupied = true;
                    ChessBoard.TheGrid[0, 5].ChessPiece = "rook";
                    ChessBoard.TheGrid[0, 5].IsBlack = true;
                }
                else if (input == "swapl" && PickedC.IsBlack)
                {
                    ChessBoard.TheGrid[0, 4].ChessPiece = null;
                    ChessBoard.TheGrid[0, 4].Occupied = false;

                    ChessBoard.TheGrid[0, 1].ChessPiece = "king";
                    ChessBoard.TheGrid[0, 1].Occupied = true;
                    ChessBoard.TheGrid[0, 1].IsBlack = true;

                    ChessBoard.TheGrid[0, 0].Occupied = false;
                    ChessBoard.TheGrid[0, 0].ChessPiece = null;

                    ChessBoard.TheGrid[0, 2].Occupied = true;
                    ChessBoard.TheGrid[0, 2].ChessPiece = "rook";
                    ChessBoard.TheGrid[0, 2].IsBlack = true;
                }
                else if (input == "swapr" && !PickedC.IsBlack)
                {
                    ChessBoard.TheGrid[7, 4].ChessPiece = null;
                    ChessBoard.TheGrid[7, 4].Occupied = false;

                    ChessBoard.TheGrid[7, 6].ChessPiece = "king";
                    ChessBoard.TheGrid[7, 6].Occupied = true;
                    ChessBoard.TheGrid[7, 6].IsBlack = false;

                    ChessBoard.TheGrid[7, 7].Occupied = false;
                    ChessBoard.TheGrid[7, 7].ChessPiece = null;

                    ChessBoard.TheGrid[7, 5].Occupied = true;
                    ChessBoard.TheGrid[7, 5].ChessPiece = "rook";
                    ChessBoard.TheGrid[7, 5].IsBlack = false;
                }
                else if (input == "swapl" && !PickedC.IsBlack)
                {
                    ChessBoard.TheGrid[7, 4].ChessPiece = null;
                    ChessBoard.TheGrid[7, 4].Occupied = false;

                    ChessBoard.TheGrid[7, 1].ChessPiece = "king";
                    ChessBoard.TheGrid[7, 1].Occupied = true;
                    ChessBoard.TheGrid[7, 1].IsBlack = false;

                    ChessBoard.TheGrid[7, 0].Occupied = false;
                    ChessBoard.TheGrid[7, 0].ChessPiece = null;

                    ChessBoard.TheGrid[7, 2].Occupied = true;
                    ChessBoard.TheGrid[7, 2].ChessPiece = "rook";
                    ChessBoard.TheGrid[7, 2].IsBlack = false;
                }
                switch (input[0])
                {
                    case 'a':
                        column = 0;
                        break;

                    case 'b':
                        column = 1;
                        break;

                    case 'c':
                        column = 2;
                        break;

                    case 'd':
                        column = 3;
                        break;

                    case 'e':
                        column = 4;
                        break;

                    case 'f':
                        column = 5;
                        break;

                    case 'g':
                        column = 6;
                        break;

                    case 'h':
                        column = 7;
                        break;
                    case 'r':
                        return 'r';
                    default:
                        return 'l';
                }
            }
            else
            {
                switch (input[0])
                {
                    case 'a':
                        column = 0;
                        break;

                    case 'b':
                        column = 1;
                        break;

                    case 'c':
                        column = 2;
                        break;

                    case 'd':
                        column = 3;
                        break;

                    case 'e':
                        column = 4;
                        break;

                    case 'f':
                        column = 5;
                        break;

                    case 'g':
                        column = 6;
                        break;

                    case 'h':
                        column = 7;
                        break;
                    case 'r':
                        return 'r';
                }
            }

            try
            {
                string rowS = Convert.ToString(input[1]);
                row = 8 - Convert.ToInt32(rowS);
            }
            catch (Exception)
            {
                goto invalidMove;
            }




            Cell c = ChessBoard.TheGrid[row, column];


            CurrentC = c;
            ChessPiece = c.ChessPiece;
            CurrentCIsBlack = CurrentC.IsBlack;



            if (c.LegalNextMove == true)
            {
                //c = PickedCell;
                //PickedCell.Occupied = false;
                //PickedCell.ChessPiece = null;

                c.Occupied = true;
                c.ChessPiece = PickedCell.ChessPiece;
                PickedCell.Occupied = false;
                PickedCell.ChessPiece = null;
                if (PickedCell.IsBlack)
                {
                    c.IsBlack = true;

                }
                else
                {
                    c.IsBlack = false;

                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        ChessBoard.TheGrid[i, j].LegalNextMove = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Move");
                goto invalidMove;
            }
            return 's';


        }
        private static void MarkAllPossibleMoves()
        {
            bool BackMarking = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell currentCell = ChessBoard.TheGrid[i, j];
                    currentCell.PossibleNextMoveB = false;
                    currentCell.PossibleNextMoveW = false;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell currentCell = ChessBoard.TheGrid[i, j];
                    ChessBoard.MarkNextLegalMoves(currentCell, BackMarking);
                }
            }
        }
        private static void CheckmateCheck()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ChessBoard.TheGrid[i, j].PossibleNextMoveB
                        && ChessBoard.TheGrid[i, j].ChessPiece == "king"
                        && !ChessBoard.TheGrid[i, j].IsBlack)
                    {
                        ChessBoard.TheGrid[i, j].CheckedKing = true;
                        WhiteCheck = true;
                        return;
                    }
                    if ((ChessBoard.TheGrid[i, j].PossibleNextMoveW)
                       && (ChessBoard.TheGrid[i, j].ChessPiece == "king")
                       && (ChessBoard.TheGrid[i, j].IsBlack))
                    {
                        BlackCheck = true;
                        ChessBoard.TheGrid[i, j].CheckedKing = true;
                        return;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessBoard.TheGrid[i, j].CheckedKing = false;
                }
            }
            WhiteCheck = false;
            BlackCheck = false;
        }
        private static void PawnZeroToHero()
        {

            if ((CurrentC != null
                && CurrentC.ChessPiece == "pawn"
                && CurrentC.IsBlack
                && CurrentC.RowNumber == 7) ||
                (CurrentC != null
                && CurrentC.ChessPiece == "pawn"
                && !CurrentC.IsBlack
                && CurrentC.RowNumber == 0))
            {
                bool validPiece;
                Console.WriteLine("enter chesspiece you want your pawn to turn into");
                do
                {
                    string chessPiece = Console.ReadLine().ToLower();

                    if (chessPiece == "queen" || chessPiece == "knight" || chessPiece == "bishop" || chessPiece == "rook")
                    {
                        CurrentC.ChessPiece = chessPiece;
                        validPiece = true;
                    }
                    else
                    {
                        Console.WriteLine("the piece you entered is not valid");
                        validPiece = false;
                    }

                } while (!validPiece);



            }
        }
        private static bool RookKingSwap()
        {
            if (PickedC.ChessPiece == "king"
                && !PickedC.IsBlack
                && ChessBoard.TheGrid[7, 0].ChessPiece == "rook"
                && !ChessBoard.TheGrid[7, 0].IsBlack
                && ChessBoard.TheGrid[7, 4].ChessPiece == "king"
                && ChessBoard.TheGrid[7, 1].Occupied == false
                && ChessBoard.TheGrid[7, 2].Occupied == false
                && ChessBoard.TheGrid[7, 3].Occupied == false)
            {
                return true;
            }
            else if (PickedC.ChessPiece == "king"
                     && !PickedC.IsBlack
                     && ChessBoard.TheGrid[7, 7].ChessPiece == "rook"
                     && !ChessBoard.TheGrid[7, 7].IsBlack
                     && ChessBoard.TheGrid[7, 4].ChessPiece == "king"
                     && ChessBoard.TheGrid[7, 5].Occupied == false
                     && ChessBoard.TheGrid[7, 6].Occupied == false)
            {
                return true;
            }
            else if (PickedC.ChessPiece == "king"
                     && PickedC.IsBlack
                     && ChessBoard.TheGrid[0, 7].ChessPiece == "rook"
                     && ChessBoard.TheGrid[0, 7].IsBlack
                     && ChessBoard.TheGrid[0, 4].ChessPiece == "king"
                     && ChessBoard.TheGrid[0, 5].Occupied == false
                     && ChessBoard.TheGrid[0, 6].Occupied == false)
            {
                return true;
            }
            else if (PickedC.ChessPiece == "king"
                     && PickedC.IsBlack
                     && ChessBoard.TheGrid[0, 0].ChessPiece == "rook"
                     && ChessBoard.TheGrid[0, 0].IsBlack
                     && ChessBoard.TheGrid[0, 4].ChessPiece == "king"
                     && ChessBoard.TheGrid[0, 1].Occupied == false
                     && ChessBoard.TheGrid[0, 2].Occupied == false
                     && ChessBoard.TheGrid[0, 3].Occupied == false)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        private static void ChangeBackground(int i, int j)
        {
            if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
            {
                //Console.BackgroundColor = ConsoleColor.White;
            }
        }

    }
}
