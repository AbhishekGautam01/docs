using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// Adaptee
    /// </summary>
    internal interface IEnglishSpeaker
    {
        string AskQuestion(string words);
        string AnswerForTheQuestion(string words);
    }
}
