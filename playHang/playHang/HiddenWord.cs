using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playHang
{
    class HiddenWord
    {
        public string changeTosymbol(string wordToChange)
        {
            string changeWordToSymbol = null;

            foreach (int p in wordToChange)
            {
                if ((p == 97) || (p == 101) || (p == 105) || (p == 111) || (p == 117))
                {
                    changeWordToSymbol += ".";
                }
                else
                {
                    if (p == 32)
                    {
                        changeWordToSymbol += " ";
                    }
                    else
                    {
                        changeWordToSymbol += "_";
                    }
                }
            }
            return changeWordToSymbol;
        }

    }
}
