using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    /// <summary>
    /// Explanation Builder defines what each step should do to build an explanation.
    /// 
    /// Notice, builders do not necessarily build a Board.
    /// Builders can create whatever object you need, as long as it can follow
    /// the steps outlined in IBuilder.
    /// </summary>
    public class ExplanationBuilder : IBuilder
    {
        private Explanation head;
        private Explanation current;

        public void SetConfiguration(int numPieces = 19)
        {
            Explanation explanation = new Explanation(
                "Setting the config value.\n" +
                $"\t\tnumPieces: {numPieces}."
                );
            Append(explanation);
        }

        public void BuildPieces()
        {
            Explanation explanation = new Explanation(
                "Building all pieces.\n" +
                "\t\tThe number of pieces built depends on the config value numPieces."
                );
            Append(explanation);
        }

        /// <summary>
        /// No pieces to count here.
        /// </summary>
        /// <returns></returns>
        public int RemainingPiecesCount()
        {
            throw new NotImplementedException();
        }

        public void CreateLandmass(int numPieces)
        {
            Explanation explanation = new Explanation(
                $"Creating a landmass with the given number of pieces, {numPieces}."
                );
            Append(explanation);
        }

        public Explanation GetExplanations()
        {
            Explanation explanation = new Explanation(
                "Returning all explanations."
                );
            Append(explanation);
            return head;
        }

        public void ResetBuilder()
        {
            Console.WriteLine("Explanation Builder is reset.");
            head = null;
        }

        /// <summary>
        /// Helper method to append a new explanation to the end of the list.
        /// </summary>
        /// <param name="newExplanation"></param>
        private void Append(Explanation newExplanation)
        {
            if (head == null || string.IsNullOrWhiteSpace(head.explanation))
            {
                head = newExplanation;
                current = head;
            }
            else
            {
                current.next = newExplanation;
                current = current.next;
            }
        }
    }
}
