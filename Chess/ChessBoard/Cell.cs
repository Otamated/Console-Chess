using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string ChessPiece { get; set; }
        public bool Occupied { get; set; }
        public bool IsPicked { get; set; }
        public bool LegalNextMove { get; set; }
        public bool PossibleNextMoveW { get; set; }
        public bool PossibleNextMoveB { get; set; }
        public bool IsBlack { get; set; }
        public bool CheckedKing { get; set; }


        public Cell(int x ,int y)
        {
            RowNumber = x;
            ColumnNumber = y;

            if(Occupied == false)
            {
                ChessPiece = null;
            }
        }




    }
}
