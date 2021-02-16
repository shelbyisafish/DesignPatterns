using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    public class Board
    {
        public List<LandMass> landMasses { get; private set; }

        public Board() { }

        public void AddLandmass(LandMass landMass)
        {
            if (landMasses == null)
                landMasses = new List<LandMass>();

            landMasses.Add(landMass);
        }
    }

    public class LandMass
    {
        /// <summary>
        /// Providing the full list of pieces for a landmass,
        /// even though the first piece should be the head.
        /// </summary>
        public List<BoardPiece> pieces { get; }

        public LandMass(List<BoardPiece> pieces)
        {
            this.pieces = pieces;
        }
    }
}
