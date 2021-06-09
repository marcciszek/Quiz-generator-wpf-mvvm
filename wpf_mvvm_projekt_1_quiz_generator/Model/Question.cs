using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_mvvm_projekt_1_quiz_generator.Model
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Ans1 { get; set; }
        public string Ans2 { get; set; }
        public string Ans3 { get; set; }
        public string Ans4 { get; set; }
        public int? CorrectAnswer { get; set; }

        public Question()
        {
            QuestionText = "";
            Ans1 = "";
            Ans2 = "";
            Ans3 = "";
            Ans4 = "";
            CorrectAnswer = null;
        }

        public Question(string questionText, string ans1, string ans2, string ans3, string ans4, int? correctAnswer)
        {
            QuestionText = questionText;
            Ans1 = ans1;
            Ans2 = ans2;
            Ans3 = ans3;
            Ans4 = ans4;
            CorrectAnswer = correctAnswer;
        }

        public Question(Question question)
        {
            QuestionText = question.QuestionText;
            Ans1 = question.Ans1;
            Ans2 = question.Ans2;
            Ans3 = question.Ans3;
            Ans4 = question.Ans4;
            CorrectAnswer = question.CorrectAnswer;
        }

        public override string ToString()
        {
            return QuestionText;
        }
    }
}
