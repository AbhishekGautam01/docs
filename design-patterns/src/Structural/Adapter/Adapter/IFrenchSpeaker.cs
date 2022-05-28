using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    internal interface IFrenchSpeaker
    {
        string AskQuestion(string words);
        string AnswerForTheQuestion(string words);  
    }
}
