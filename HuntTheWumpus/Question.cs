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
    public class Question
    {
        // Enums
        public enum QuestionType { NULL, MULTI, TF };

        // Class members/values
        public QuestionType questionType;
        public String questionText;
        public List<Answer> questionAnswers = new List<Answer>();
        public List<String> questionHints = new List<String>();            // The global list of Hints.  This makes providing hints easier.
         int correctAnswerIndex;
        public bool asked;


        /// <summary>
        /// Blank constructor.  Creates a null question; not valid for processing by trivia object.
        /// </summary>
        Question()
        {
            this.questionType = QuestionType.NULL;
            this.questionText = null;
            this.questionAnswers = null;
            this.questionHints = null;
        }

        /// <summary>
        /// Construct a valid question using information provided
        /// </summary>
        /// <param name="type">Either QuestionType.TF, or QuestionType.MULTI</param>
        /// <param name="question">The text of the question</param>
        /// <param name="hints">The string array containing the hints for this question</param>
        /// <param name="correctAnswer">The index of the correct answer, or 1 for True and 0 for False.</param>
        /// <param name="answers">The string array containing the possible answers for this question</param>
        public Question(QuestionType type, String question, String[] hints, int correctAnswer, String[] answers)
        {
            int i;

            questionType = type;                   // Set the single value members...
            questionText = question;               // ...from the parameters provided...
            correctAnswerIndex = correctAnswer;    // ...
            asked = false;                         // Mark this question as yet to be asked.  
                                                   // This prevents the same question from being asked multiple times.
            
            // Now spin through the multi-value parameters and set them into the Question object.
            //for (i = 0; i < hints.Length; i++)
            //{
            //    questionHints.Add(hints[i]);
            //}
            questionHints.AddRange(hints);
            if (answers != null)
            {
                for (i = 0; i < answers.Length; i++)
                {
                    questionAnswers.Add(new Answer(i, answers[i].ToString()));
                }
            }
        }
    }
}
