using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    // The director class knows how to use the functions in Builder
    // to create the desired object.
    public class Director
    {
        private IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// Construct a regular Settlers of Catan board with the standard
        /// number of pieces and 1 landmass.
        /// </summary>
        public void ConstructStandardBoard()
        {
            if (builder is BoardBuilder == false)
            {
                Console.WriteLine($"Cannot create a board. Builder is not set to BoardBuilder. Builder is {builder.GetType()}.");
                return;
            }

            builder.ResetBuilder();
            builder.SetConfiguration(); // use default config
            builder.BuildPieces();
            builder.CreateLandmass(builder.RemainingPiecesCount());
            // Note: Cannot call GetBoard() here. That is the responsibility of the builder, not Director.
        }

        /// <summary>
        /// Construct a non-standard Settlers of Catan board with
        /// 25 pieces and 2 landmasses.
        /// </summary>
        public void ConstructAdvancedBoard()
        {
            if (builder is BoardBuilder == false)
            {
                Console.WriteLine($"Cannot create a board. Builder is not set to BoardBuilder. Builder is {builder.GetType()}.");
                return;
            }

            builder.ResetBuilder();
            builder.SetConfiguration(25);
            builder.BuildPieces();

            int remaining1 = builder.RemainingPiecesCount();
            builder.CreateLandmass(remaining1);
            builder.CreateLandmass(builder.RemainingPiecesCount());
        }

        /// <summary>
        /// Construct an explanation for a standard Settlers of Catan board.
        /// </summary>
        public void ConstructStandardExplanation()
        {
            if (builder is ExplanationBuilder == false)
            {
                Console.WriteLine($"Cannot create an Explanation. Builder is not set to ExplanationBuilder. Builder is {builder.GetType()}.");
                return;
            }

            builder.ResetBuilder();
            builder.SetConfiguration();
            builder.BuildPieces();
            builder.CreateLandmass(25);
        }
    }
}
