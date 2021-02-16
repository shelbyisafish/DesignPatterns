using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    public class BoardPiece
    {
        public ResourceEnum resourceType { get; set; }
        public BoardPiece[] adjacentPieces { get; set; }

        public BoardPiece(ResourceEnum resourceType)
        {
            this.resourceType = resourceType;
            adjacentPieces = new BoardPiece[6];
        }
    }
}
