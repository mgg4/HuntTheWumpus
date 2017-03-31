using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    class Trivia
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

        // Member variables
        Question[] questions;

        Triva()
        {
            // Load the trivia from the file
            this.loadTriva();
        }

        loadTriva()
        {
            // Read the JSON file and parse the questions, creating the question object to be used for the Triva game

            // TODO: Implement this
        }
    }
}
