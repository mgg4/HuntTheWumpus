using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{


    /// <summary>
    /// The Question Object contains the information about a Trivia Question.
    /// </summary>
    class Question
    {
        // Enums
        enum QuestionType { NULL, MULTI, TF};

        // Class members/values
        QuestionType questionType;
        String questionText;
        String[] questionHints;
        Answer[] questionAnswers;
        int correctAnswerIndex;


        /// <summary>
        /// Blank constructor.  Creates a null question; not valid for processing by trivia object.
        /// </summary>
        Question()
        {
            this.questionType = QuestionType.NULL;
            this.questionText = null;
            this.questionAnswers = [];
        }

        /// <summary>
        /// Construct a valid question using information provided
        /// </summary>
        /// <param name="type">Either QuestionType.TF, or QuestionType.MULTI</param>
        /// <param name="question">The text of the question</param>
        /// <param name="hints">The string array containing the hints for this question</param>
        /// <param name="correctAnswer">The index of the correct answer, or 1 for True and 0 for False.</param>
        /// <param name="answers">The string array containing the possible answers for this question</param>
        Question(QuestionType type, String question, String[] hints, int correctAnswer, String[] answers)
        {
            int i;

            this.questionType = type;
            this.questionText = question;
            this.correctAnswerIndex = correctAnswer;
            for (i=0;i<hints.Length;i++)
            {
                this.questionHints[i] = hints[i];
            }
            for (i=0;i<answers.Length;i++)
            {
                this.questionAnswers[i] = Answer(i, answers[i]);
            }
        }
    }
}
