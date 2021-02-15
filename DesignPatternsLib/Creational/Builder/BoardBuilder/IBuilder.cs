using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    /// <summary>
    /// The IBuilder interface has everything a Builder would know how to do.
    /// A Builder doesn't need to do something for every step, but every step
    /// the Director needs to call should be here.
    /// </summary>
    public interface IBuilder
    {
        void ResetBuilder();
        void SetConfiguration(int numPieces, int numLandmasses);
        void BuildPieces();
        void CreateLandmass(int numPieces);
    }
}
