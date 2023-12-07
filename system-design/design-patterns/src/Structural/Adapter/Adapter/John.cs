using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// John is able to speak english
    /// </summary>
    internal class John : IEnglishSpeaker
    {
        public string AnswerForTheQuestion(string words)
        {
            Console.WriteLine("Question Asked by John [English Speaker and Can understand only English] : " + words);
            ITarget target = new Pam();
            string replyFromDavid = target.TranslateAndTellToOtherPerson(words, "French");
            return replyFromDavid;
        }

        public string AskQuestion(string words)
        {
            string reply = null;
            if (words.Equals("where are you?", StringComparison.InvariantCultureIgnoreCase))
            {
                reply = "I am in USA";
            }
            return reply;
        }
    }
}
