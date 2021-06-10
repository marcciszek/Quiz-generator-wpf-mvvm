using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace wpf_mvvm_projekt_1_quiz_generator.Model
{
    public class Quiz
    {
        private List<Question> listOfQuestions;
        private int questionCounter;

        public List<Question> ListOfQuestions { 
            get { return listOfQuestions; }
            set { listOfQuestions = value; }
        }
        public int QuestionCounter { 
            get { return questionCounter; }
            set { questionCounter = value; } }

        public Quiz()
        {
            questionCounter = 0;
            listOfQuestions = new List<Question>();
        }

        public Quiz(List<Question> listOfQuestions)
        {
            this.listOfQuestions = listOfQuestions;
            questionCounter = listOfQuestions.Count;
        }

        public void Add(Question q)
        {
            listOfQuestions.Add(q);
            questionCounter++;
        }
        
        public Question this[int idx]
        {
            get { 
                if (idx<listOfQuestions.Count)
                    return listOfQuestions[idx];
                return new Question();
            }
        }

        public bool SaveQuiz(string title, string quizName)
        {
            System.IO.Directory.CreateDirectory("Quizes");

            string path = "Quizes\\\\" + quizName.ToString() + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(title);

                    foreach(Question item in listOfQuestions)
                    {
                        sw.WriteLine(item.QuestionText);

                        string tmp_string = "";
                        if (item.CorrectAnswer == 0)
                            tmp_string += "1";
                        else
                            tmp_string += "0";
                        tmp_string += "|" + item.Ans1;
                        sw.WriteLine(tmp_string);

                        tmp_string = "";
                        if (item.CorrectAnswer == 1)
                            tmp_string += "1";
                        else
                            tmp_string += "0";
                        tmp_string += "|" + item.Ans2;
                        sw.WriteLine(tmp_string);

                        tmp_string = "";
                        if (item.CorrectAnswer == 2)
                            tmp_string += "1";
                        else
                            tmp_string += "0";
                        tmp_string += "|" + item.Ans3;
                        sw.WriteLine(tmp_string);

                        tmp_string = "";
                        if (item.CorrectAnswer == 3)
                            tmp_string += "1";
                        else
                            tmp_string += "0";
                        tmp_string += "|" + item.Ans4;
                        sw.WriteLine(tmp_string);

                        sw.WriteLine("**********");
                    }
                    return true;
                }
            }
            return false;
        }

        public string LoadQuiz(string path)
        {
            string quizTitle = "";
            if(File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    this.listOfQuestions = new List<Question>();
                    this.questionCounter = 0;

                    string s;

                    if ((s = sr.ReadLine()) != null) { quizTitle = s; };

                    int iterator = 0;
                    Question question = new Question();
                    while ((s = sr.ReadLine()) != null)
                    {
                    if (iterator % 6 == 0)
                        {
                            question.QuestionText = s;
                        }
                    if (iterator % 6 == 1)
                        {
                            string[] tmp = s.Split('|');
                            question.Ans1 = tmp[1];
                            if (tmp[0].Equals("1"))
                            {
                                question.CorrectAnswer = 0;
                            }
                        }
                    if (iterator % 6 == 2)
                        {
                            string[] tmp = s.Split('|');
                            question.Ans2 = tmp[1];
                            if (tmp[0].Equals("1"))
                            {
                                question.CorrectAnswer = 0;
                            }
                        }
                    if (iterator % 6 == 3)
                        {
                            string[] tmp = s.Split('|');
                            question.Ans3 = tmp[1];
                            if (tmp[0].Equals("1"))
                            {
                                question.CorrectAnswer = 0;
                            }
                        }
                    if (iterator % 6 == 4)
                        {
                            string[] tmp = s.Split('|');
                            question.Ans4 = tmp[1];
                            if (tmp[0].Equals("1"))
                            {
                                question.CorrectAnswer = 0;
                            }
                        }
                    if (iterator % 6 == 5)
                        {
                            listOfQuestions.Add(question);
                            question = new Question();
                            this.questionCounter++;
                        }
                        iterator++;
                    }      
                }
            }
            return quizTitle;
        }
    }
}
