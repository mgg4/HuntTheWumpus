using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    /// <summary>
    /// The Answer Object encapsulates all of the necessary data and methods for managing an answer to a trivia question.
    /// The Question Object will contain multiple Answer Objects, representing the possible answers to the question.
    /// </summary>
    class Answer
    {
        String value;
        int    index;

        public Answer(int nbr, String answerString)
        {
            this.value = answerString;
            this.index = nbr;
        }
    }
}
