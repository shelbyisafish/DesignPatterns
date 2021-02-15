using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    /// <summary>
    /// Board Builder defines what each step should do to build a board.
    /// </summary>
    public class BoardBuilder : IBuilder
    {
        private Board board;
        private int totalNumPieces, totalNumLandmasses;
        private int[] numResources;
        private List<BoardPiece> pieces;

        public void SetConfiguration(int numPieces = 19, int numLandmasses = 1)
        {
            if (numPieces < 6)
                throw new Exception("Cannot create a board with less than 6 pieces.");
            if (numLandmasses < 1)
                throw new Exception("Cannot create a board with less than 1 landmass.");

            totalNumPieces = numPieces;
            totalNumLandmasses = numLandmasses;

            int distribution = (numPieces-1) / 5;
            int leftover = (numPieces - 1) % 5;

            numResources = new int[Enum.GetNames(typeof(ResourceEnum)).Length];
            numResources[0] = 1;    // Desert
            numResources[1] = distribution;    // Grain
            numResources[2] = distribution;    // Lumber
            numResources[3] = distribution;    // Wool
            numResources[4] = distribution;    // Ore
            numResources[5] = distribution;    // Brick

        }

        public void BuildPieces()
        {
            for(int i=0; i<totalNumPieces; i++)
            {
                pieces.Add(new BoardPiece());
            }
        }

        public void CreateLandmass(int numPieces)
        {
            throw new NotImplementedException();
        }

        public Board GetBoard()
        {
            return board;
        }

        public void ResetBuilder()
        {
            board = null;
            totalNumPieces = 0;
            totalNumLandmasses = 0;
        }
    }
}
