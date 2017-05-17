using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace HuntTheWumpus
{
    // On creation of the trivia object, load the questions from the trivia file into the question object array.
    // The Trivia Object will reference the Question Object, which in turn will reference the Answer Object.

    // The trivaQuestions file is a JSON file named triviaQuestions.json in the Resources directory.
    // The file contains an JSON array of JSON question objects.  There are two types of question objects:
    //   "TF" -- A True/False question.  No answers are included in the file.  
    //           The correct answer is either false, represented by a 0 (zero) value; or true, represented by a 1.
    //   "Multi" -- A multiple choice question.  Multiple answers are included in an answers array.  Any number of answers may be included.
    //           The correct answer is indicated as a zero-based value indicating the correct answer in the array.
    // The members for each JSON object are:
    //   "type" -- Either "TF" or "Multi"
    //   "question" -- The string value of the question.
    //   "hints" -- A JSON array of string hints to be provided to players for this question.  One will be selected at random.
    //   "correct" -- Integer value indicating the correct answer.  
    //            Either a true/false (1=true/0=false) value for "TF" type questions, 
    //            or a zero-based index indicating which answer is correct for "Multi" type questions.
    //   "answers" -- A JSON array of string values.  Each string represents one of the answers.
    //            This is not required for "TF" type questions, and if included on these, the answers array will
    //            be used to replace the "False" and "True" string values on the display.
    //            If included on "TF" type questions, the sequence is "False", "True".

    // An example file format is:
    //[
    //  {
    //    "type":"TF",
    //    "question":"The Space Needle is in Seattle",
    //    "hints":[
    //      "The Space Needle is not in Tacoma"
    //    ]
    //    "correct":1 
    //  },
    //  {
    //    "type":"Multi",
    //    "question":"The tallest mountain in Washington State is...",
    //    "hints":[
    //      "Mount Rainier is tall",
    //      "Mt Hood is not in Washington State"
    //    ],
    //    "correct":2
    //    "answers":[
    //      "Mount Hood",
    //      "Mount Baker",
    //      "Mount Rainier",
    //      "Mount Shasta"
    //    ],
    //  }
    //]

    /// <summary>
    /// Class for parsing the JSON file of questions.
    /// </summary>
    public class QuestionJSON
    {
        public string type { get; set; }
        public string question { get; set; }
        public string[] hints { get; set; }
        public int correct { get; set; }
        public string[] answers { get; set; }
    }


    public class Trivia
    {
        // Member variables
        int questionsAsked;
        List<Question> questions = new List<Question>();    // The list of Questions
        List<String> hints = new List<String>();            // The global list of Hints.  This makes providing hints easier.
        GameControl gc;

        public Trivia(GameControl gc)
        {
            // Load the trivia from the file
            this.gc = gc;
            this.loadTrivia();
        }

        void loadTrivia()
        {
            List<QuestionJSON> jsonList = this.loader();
            foreach (QuestionJSON Q in jsonList)
            {
                Question.QuestionType Qtype;
                switch (Q.type)
                {
                    case "TF":
                        Qtype = Question.QuestionType.TF;
                        break;
                    case "Multi":
                        Qtype = Question.QuestionType.MULTI;
                        break;
                    default:
                        Qtype = Question.QuestionType.NULL;
                        break;
                }
                questions.Add(new Question(Qtype, Q.question, Q.hints, Q.correct, Q.answers));
                hints.AddRange(Q.hints);
            }
            questionsAsked = 0;
        }

        // This is a sample of how to deserialize the json file
        List<QuestionJSON> loader()
        {
            List<QuestionJSON> ro;
            string pwd = Directory.GetCurrentDirectory();
            string path = Properties.Resources.triviaPath;

            using (StreamReader r = new StreamReader(pwd + path))
            {
                string json = r.ReadToEnd();
                ro = JsonConvert.DeserializeObject<List<QuestionJSON>>(json);
            }
            return ro;
        }

        public bool askRandomQuestion()
        {
            // Ask a random question and return a boolean true if answered correctly.
            // Return false if the answer was not correct.
            Question question = selectRandomQuestion();
            question.asked = true;
            // Now Ask the question 
            // Dialog box popup time.
            return false;
        }

        private Question selectRandomQuestion()
        {
            int i;

            // Check to see if all questions have been asked.
            if (questionsAsked >= questions.Count())
            {
                // Since the question list is exhausted, reset it back to original state.
                // This will cause questions to be asked again.
                foreach (Question q in questions) {
                    q.asked = false;
                }
                questionsAsked = 0;
            }
            // Use the RNG to get a random question from the list.  The condition on the loop
            // will ensure we return a question that has not been asked yet this go around.
            do
            {
                i = gc.rng.Next(0, questions.Count());
            } while (questions[i].asked == true);
            // Increment the count of questions asked and return the question.
            questionsAsked++;
            return questions[i];
        }
    }
}
