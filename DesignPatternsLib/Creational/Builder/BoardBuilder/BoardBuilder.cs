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
        private int[] numResources;
        private List<BoardPiece> pieces;
        private static Random random = new Random();

        /// <summary>
        /// Sets the board configuration.
        /// </summary>
        /// <param name="numPieces"></param>
        /// <param name="numLandmasses"></param>
        public void SetConfiguration(int numPieces = 19)
        {
            if (numPieces < 6)
                throw new Exception("Cannot create a board with less than 6 pieces.");

            int distribution = (numPieces-1) / 5;
            int leftover = (numPieces - 1) % 5;

            numResources = new int[Enum.GetNames(typeof(ResourceEnum)).Length];
            numResources[0] = 1;    // Desert
            numResources[1] = distribution;    // Grain
            numResources[2] = distribution;    // Lumber
            numResources[3] = distribution;    // Wool
            numResources[4] = distribution;    // Ore
            numResources[5] = distribution;    // Brick
            for (int i=1; i<=leftover; i++)
            {
                numResources[i]++;
            }

            if (pieces == null)
                pieces = new List<BoardPiece>();
        }

        /// <summary>
        /// Create all board pieces according to the configuration.
        /// </summary>
        public void BuildPieces()
        {
            for (int resourceType=0; resourceType<numResources.Length; resourceType++)
            {
                for (int amount=0; amount<numResources[resourceType]; amount++)
                {
                    pieces.Add(new BoardPiece((ResourceEnum)resourceType));
                }
            }
        }

        public int RemainingPiecesCount()
        {
            return pieces.Count();
        }

        /// <summary>
        /// Must BuildPieces() before calling CreateLandmass().
        /// Adds landmass to board.
        /// </summary>
        /// <param name="numPieces"></param>
        public void CreateLandmass(int numPieces)
        {
            if (numPieces > pieces.Count)
            {
                Console.WriteLine($"Cannot create a landmass with {numPieces}. Not enough pieces left: {pieces.Count()}. Returning...");
                return;
            }

            if (board == null)
                board = new Board();

            List<BoardPiece> chosenPieces = new List<BoardPiece>();
            for (int i=0; i<numPieces; i++)
            {
                int pieceRNG = random.Next(0, pieces.Count());

                if (chosenPieces.Any())
                    ConnectAdjacent(chosenPieces, pieces[pieceRNG]);
                chosenPieces.Add(pieces[pieceRNG]);
                pieces.RemoveAt(pieceRNG);
            }

            LandMass landMass = new LandMass(chosenPieces);
            board.AddLandmass(landMass);
        }

        public Board GetBoard()
        {
            return board;
        }

        public void ResetBuilder()
        {
            board = null;
            numResources = null;
            if (pieces != null)
                pieces.Clear();
        }

        // This is not a good calculation.
        // Could come back and fix this later, but not necessary for the example.
        private void ConnectAdjacent(List<BoardPiece> existingPieces, BoardPiece newPiece)
        {
            int locationRNG = random.Next(0, 6);
            existingPieces.Last().adjacentPieces[locationRNG] = newPiece;
        }
    }
}
