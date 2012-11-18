using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playHang
{
    class HangSession
    {
        public int errState { get; set; }
        public bool makeMistake { get; set; }
        public string controlStateWord { get; set; }
        public bool controlStringSymbol { get; set; }
        public int indexWordToFind { get; set; }
        public int indexSubWordToComplete { get; set; }
        public int attempt { get; set; }
        public bool toEliminateConflict { get; set; }
    }
}
