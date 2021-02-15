using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.Creational.Builder.BoardBuilder
{
    /// <summary>
    /// An Explanation is a string that describes what's going on.
    /// It also holds a link to the next explanation.
    /// </summary>
    public class Explanation
    {
        public string explanation = "";
        public Explanation next { get; set; }

        public Explanation(string explanation)
        {
            this.explanation = explanation;
        }
    }
}
