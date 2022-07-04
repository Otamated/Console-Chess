namespace ChessBoard
{
    public class Board
    {
        //  the size of the board
        public int Size { get; set; }

        // 2d array of type cell
        public Cell[,] TheGrid { get; set; }

        public Board(int size)
        {
            Size = size;

            TheGrid = new Cell[Size, Size];

            //fill 2d array with new cells with unique x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, bool backMarking)
        {
            //remove all legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].LegalNextMove = false;
                }
            }

            //find all legal moves and mark them as legal
            switch (currentCell.ChessPiece)
            {
                case "knight":
                    if (IsSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        }
                    }
                    break;
                case "king":
                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                    }
                    if (IsSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1, TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsBlack))
                    {
                        if (backMarking)
                        {
                            if (currentCell.IsBlack)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].PossibleNextMoveW = true;
                            }
                        }
                        else
                        {
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                    }


                    break;
                case "rook":
                    int rowR = currentCell.RowNumber;
                    int columnR = currentCell.ColumnNumber;
                    bool KilledBlack;
                    if (currentCell.IsBlack)
                    {
                        KilledBlack = false;
                        Rook(rowR, columnR, KilledBlack, backMarking);
                    }
                    else
                    {
                        KilledBlack = true;
                        Rook(rowR, columnR, KilledBlack, backMarking);
                    }
                    break;
                case "bishop":

                    int rowB = currentCell.RowNumber;
                    int columnB = currentCell.ColumnNumber;
                    if (currentCell.IsBlack)
                    {
                        KilledBlack = false;
                        Bishop(rowB, columnB, KilledBlack, backMarking);
                    }
                    else
                    {
                        KilledBlack = true;
                        Bishop(rowB, columnB, KilledBlack, backMarking);
                    }
                    break;

                case "queen":
                    int rowQ = currentCell.RowNumber;
                    int columnQ = currentCell.ColumnNumber;
                    if (currentCell.IsBlack)
                    {
                        KilledBlack = false;
                        Bishop(rowQ, columnQ, KilledBlack, backMarking);
                        Rook(rowQ, columnQ, KilledBlack, backMarking);
                    }
                    else
                    {
                        KilledBlack = true;
                        Bishop(rowQ, columnQ, KilledBlack, backMarking);
                        Rook(rowQ, columnQ, KilledBlack, backMarking);
                    }
                    break;
                case "pawn":
                    if (currentCell.IsBlack)
                    {
                        if (currentCell.RowNumber == 2 - 1)
                        {
                            if (!TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].Occupied)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                                if (!TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber].Occupied)
                                {
                                    TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber].LegalNextMove = true;

                                }
                            }


                        }
                        else
                        {
                            if ((currentCell.RowNumber + 1 < 8 && currentCell.RowNumber + 1 >= 0) &&
                                (currentCell.ColumnNumber < 8 && currentCell.ColumnNumber >= 0) &&
                                !TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].Occupied)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                            }

                        }


                        if (((currentCell.RowNumber + 1 < 8 && currentCell.RowNumber + 1 >= 0) &&
                            (currentCell.ColumnNumber - 1 < 8 && currentCell.ColumnNumber - 1 >= 0)) &&
                            (TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].Occupied) &&
                            (!TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].IsBlack))
                        {
                            //tu rame airi egreve aq
                            if (backMarking)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                            }
                        }
                        if (currentCell.RowNumber + 1 < 8 && currentCell.RowNumber + 1 >= 0 &&
                            currentCell.ColumnNumber + 1 < 8 && currentCell.ColumnNumber + 1 >= 0 &&
                            TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].Occupied &&
                            !TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].IsBlack)
                        {
                            //tu rame airia egreve aq
                            if (backMarking)
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                            }
                        }
                    }
                    else
                    {

                        if (currentCell.RowNumber == 7 - 1)
                        {
                            if (!TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].Occupied)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                                if (!TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber].Occupied)
                                {
                                    TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber].LegalNextMove = true;
                                }
                            }
                        }
                        else
                        {
                            if ((currentCell.RowNumber - 1 < 8 && currentCell.RowNumber - 1 >= 0) &&
                                (currentCell.ColumnNumber < 8 && currentCell.ColumnNumber >= 0) &&
                                !TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].Occupied)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                            }

                        }

                        if (((currentCell.RowNumber - 1 < 8 && currentCell.RowNumber - 1 >= 0) &&
                            (currentCell.ColumnNumber + 1 < 8 && currentCell.ColumnNumber + 1 >= 0)) &&
                            (TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].Occupied) &&
                            (TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].IsBlack)
                           )
                        {

                            if (backMarking)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                            }
                        }
                        if (currentCell.RowNumber - 1 < 8 && currentCell.RowNumber - 1 >= 0 &&
                            currentCell.ColumnNumber - 1 < 8 && currentCell.ColumnNumber - 1 >= 0 &&
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].Occupied &&
                            TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].IsBlack)
                        {

                            if (backMarking)
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].PossibleNextMoveB = true;
                            }
                            else
                            {
                                TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                            }
                        }
                    }
                    break;
            }
        }

        public void Bishop(int Row, int Column, bool KilledBlack, bool backmarking)
        {

            int row = Row;
            int column = Column;
            Cell currentCell = TheGrid[Row, Column];
            while ((row < 7 && column < 7) &&
                (TheGrid[row + 1, column + 1].Occupied == false
                || (TheGrid[row + 1, column + 1].Occupied && TheGrid[row + 1, column + 1].IsBlack == KilledBlack)))
            {
                if (TheGrid[row + 1, column + 1].Occupied && TheGrid[row + 1, column + 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (currentCell.IsBlack)
                        {
                            TheGrid[row + 1, column + 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!currentCell.IsBlack)
                        {
                            TheGrid[row + 1, column + 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[row + 1, column + 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (currentCell.IsBlack)
                    {
                        TheGrid[row + 1, column + 1].PossibleNextMoveB = true;

                    }
                    else if (!currentCell.IsBlack)
                    {
                        TheGrid[row + 1, column + 1].PossibleNextMoveW = true;

                    }
                }
                else
                {
                    TheGrid[row + 1, column + 1].LegalNextMove = true;
                }
                row++;
                column++;
            }
            row = Row;
            column = Column;

            while ((row > 0 && column > 0)
                && (TheGrid[row - 1, column - 1].Occupied == false
                || (TheGrid[row - 1, column - 1].Occupied && TheGrid[row - 1, column - 1].IsBlack == KilledBlack)))
            {
                if (TheGrid[row - 1, column - 1].Occupied && TheGrid[row - 1, column - 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (currentCell.IsBlack)
                        {
                            TheGrid[row - 1, column - 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!currentCell.IsBlack)
                        {
                            TheGrid[row - 1, column - 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[row - 1, column - 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (currentCell.IsBlack)
                    {
                        TheGrid[row - 1, column - 1].PossibleNextMoveB = true;

                    }
                    else if (!currentCell.IsBlack)
                    {
                        TheGrid[row - 1, column - 1].PossibleNextMoveW = true;

                    }
                }
                else
                {
                    TheGrid[row - 1, column - 1].LegalNextMove = true;
                }
                row--;
                column--;
            }
            row = Row;
            column = Column;

            while ((row < 7 && column > 0)
                && (TheGrid[row + 1, column - 1].Occupied == false
                || (TheGrid[row + 1, column - 1].Occupied && TheGrid[row + 1, column - 1].IsBlack == KilledBlack)))
            {
                if (TheGrid[row + 1, column - 1].Occupied && TheGrid[row + 1, column - 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (currentCell.IsBlack)
                        {
                            TheGrid[row + 1, column - 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!currentCell.IsBlack)
                        {
                            TheGrid[row + 1, column - 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[row + 1, column - 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (currentCell.IsBlack)
                    {
                        TheGrid[row + 1, column - 1].PossibleNextMoveB = true;

                    }
                    else if (!currentCell.IsBlack)
                    {
                        TheGrid[row + 1, column - 1].PossibleNextMoveW = true;

                    }
                }
                else
                {
                    TheGrid[row + 1, column - 1].LegalNextMove = true;
                }

                row++;
                column--;
            }
            row = Row;
            column = Column;

            while ((row > 0 && column < 7)
                && (TheGrid[row - 1, column + 1].Occupied == false
                || (TheGrid[row - 1, column + 1].Occupied && TheGrid[row - 1, column + 1].IsBlack == KilledBlack)))
            {
                if (TheGrid[row - 1, column + 1].Occupied && TheGrid[row - 1, column + 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (currentCell.IsBlack)
                        {
                            TheGrid[row - 1, column + 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!currentCell.IsBlack)
                        {
                            TheGrid[row - 1, column + 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[row - 1, column + 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (currentCell.IsBlack)
                    {
                        TheGrid[row - 1, column + 1].PossibleNextMoveB = true;

                    }
                    else if (!currentCell.IsBlack)
                    {
                        TheGrid[row - 1, column + 1].PossibleNextMoveW = true;

                    }
                }
                else
                {
                    TheGrid[row - 1, column + 1].LegalNextMove = true;
                }
                row--;
                column++;
            }
        }

        public void Rook(int Row, int Column, bool KilledBlack, bool backmarking)
        {

            for (int i = Row; i > 0 && (TheGrid[i - 1, Column].Occupied == false
                || (TheGrid[i - 1, Column].Occupied && TheGrid[i - 1, Column].IsBlack == KilledBlack)); i--)
            {
                if (TheGrid[i - 1, Column].Occupied && TheGrid[i - 1, Column].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[i - 1, Column].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[i - 1, Column].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[i - 1, Column].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[i - 1, Column].PossibleNextMoveB = true;

                    }
                    else if (!TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[i - 1, Column].PossibleNextMoveW = true;
                    }
                }
                else
                {
                    TheGrid[i - 1, Column].LegalNextMove = true;
                }
            }


            for (int i = Row; i < 7 && (TheGrid[i + 1, Column].Occupied == false
              || (TheGrid[i + 1, Column].Occupied && TheGrid[i + 1, Column].IsBlack == KilledBlack)); i++)
            {
                if (TheGrid[i + 1, Column].Occupied && TheGrid[i + 1, Column].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[i + 1, Column].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[i + 1, Column].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[i + 1, Column].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[i + 1, Column].PossibleNextMoveB = true;

                    }
                    else if (!TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[i + 1, Column].PossibleNextMoveW = true;
                    }
                }
                else
                {
                    TheGrid[i + 1, Column].LegalNextMove = true;
                }
            }

            for (int i = Column; i > 0 && (TheGrid[Row, i - 1].Occupied == false
              || (TheGrid[Row, i - 1].Occupied && TheGrid[Row, i - 1].IsBlack == KilledBlack)); i--)
            {
                if (TheGrid[Row, i - 1].Occupied && TheGrid[Row, i - 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[Row, i - 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[Row, i - 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[Row, i - 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[Row, i - 1].PossibleNextMoveB = true;

                    }
                    else if (!TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[Row, i - 1].PossibleNextMoveW = true;
                    }
                }
                else
                {
                    TheGrid[Row, i - 1].LegalNextMove = true;
                }
            }

            for (int i = Column; i < 7 && (TheGrid[Row, i + 1].Occupied == false
              || (TheGrid[Row, i + 1].Occupied && TheGrid[Row, i + 1].IsBlack == KilledBlack)); i++)
            {
                if (TheGrid[Row, i + 1].Occupied && TheGrid[Row, i + 1].IsBlack == KilledBlack)
                {
                    if (backmarking)
                    {
                        if (TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[Row, i + 1].PossibleNextMoveB = true;
                            break;
                        }
                        else if (!TheGrid[Row, Column].IsBlack)
                        {
                            TheGrid[Row, i + 1].PossibleNextMoveW = true;
                            break;
                        }
                    }
                    else
                    {
                        TheGrid[Row, i + 1].LegalNextMove = true;
                        break;
                    }
                }

                if (backmarking)
                {
                    if (TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[Row, i + 1].PossibleNextMoveB = true;

                    }
                    else if (!TheGrid[Row, Column].IsBlack)
                    {
                        TheGrid[Row, i + 1].PossibleNextMoveW = true;
                    }
                }
                else
                {
                    TheGrid[Row, i + 1].LegalNextMove = true;
                }
            }
        }

        public bool IsSafe(int RowNumeber, int ColumnNumber, bool isBlack)
        {

            if (isBlack)
            {
                if (((RowNumeber < 8 && RowNumeber >= 0) && (ColumnNumber < 8 && ColumnNumber >= 0)) && (TheGrid[RowNumeber, ColumnNumber].Occupied == false || TheGrid[RowNumeber, ColumnNumber].IsBlack == false))
                {
                    return true;

                }
                else
                {

                    return false;
                }
            }
            else
            {
                if (((RowNumeber < 8 && RowNumeber >= 0) && (ColumnNumber < 8 && ColumnNumber >= 0)) && (TheGrid[RowNumeber, ColumnNumber].Occupied == false || TheGrid[RowNumeber, ColumnNumber].IsBlack == true))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }





    }
}





