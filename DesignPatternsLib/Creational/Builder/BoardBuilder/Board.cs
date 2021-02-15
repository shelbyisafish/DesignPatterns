using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    public class Board
    {
        public List<LandMass> landMasses { get; }

        public Board(List<LandMass> landMasses)
        {
            this.landMasses = landMasses;
        }
    }

    public class LandMass
    {
        public List<BoardPiece> pieces { get; }

        public LandMass(List<BoardPiece> pieces)
        {
            this.pieces = pieces;
        }
    }
}
