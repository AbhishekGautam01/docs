using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// French Speaker
    /// </summary>
    internal class David : IFrenchSpeaker
    {
        public string AnswerForTheQuestion(string words)
        {
            string reply = null;
            if (words.Equals("comment allez-vous?", StringComparison.InvariantCultureIgnoreCase))
            {
                reply = "Je suis très bien";
            }
            return reply;
        }

        public string AskQuestion(string words)
        {
            Console.WriteLine("Question Asked by David [French Speaker and Can understand only French] : " + words);
            ITarget target = new Pam();
            string replyFromJohn = target.TranslateAndTellToOtherPerson(words, "English");
            return replyFromJohn;
        }
    }
}
