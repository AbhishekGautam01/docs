using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    internal interface ITarget
    {
        string TranslateAndTellToOtherPerson(string words, string convertToWhichLanguage);
    }
}
