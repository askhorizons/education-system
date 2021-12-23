using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public abstract class StepViewModel
    {
        /// <summary>
        /// Allows to control the order of a list of steps.
        /// </summary>
        public int Position { get; protected set; }
    }
}
