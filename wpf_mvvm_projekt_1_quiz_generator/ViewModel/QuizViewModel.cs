using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace wpf_mvvm_projekt_1_quiz_generator.ViewModel
{
    using BaseClass;
    using Model;
    using System.Windows.Input;
    using System.IO;
    using Microsoft.Win32;
    using System.Windows;

    class QuizViewModel : ViewModel
    {
        private Quiz questionsList;
        private Question currentQuestion;
        private int idxOfCurrentQuestion;


        public QuizViewModel()
        {
            questionsList = new Quiz();
            currentQuestion = new Question();
            idxOfCurrentQuestion = 0;
        }

        public string CurrentQuestion
        {
            get { return currentQuestion.QuestionText; }
            set { currentQuestion.QuestionText = value; onPropertyChange(nameof(CurrentQuestion)); }
        }
        public string CurrentAnswer_1
        {
            get { return currentQuestion.Ans1; }
            set { currentQuestion.Ans1 = value; onPropertyChange(nameof(CurrentAnswer_1)); }
        }

        public string CurrentAnswer_2
        {
            get { return currentQuestion.Ans2; }
            set { currentQuestion.Ans2 = value; onPropertyChange(nameof(CurrentAnswer_2)); }
        }

        public string CurrentAnswer_3
        {
            get { return currentQuestion.Ans3; }
            set { currentQuestion.Ans3 = value; onPropertyChange(nameof(CurrentAnswer_3)); }
        }

        public string CurrentAnswer_4
        {
            get { return currentQuestion.Ans4; }
            set { currentQuestion.Ans4 = value; onPropertyChange(nameof(CurrentAnswer_4)); }
        }

        public int? CorrectAnswer
        {
            get { return currentQuestion.CorrectAnswer; }
            set { currentQuestion.CorrectAnswer = value; onPropertyChange(nameof(CorrectAnswer)); }
        }

        private ObservableCollection<Question> currentQuestionsObservable = new ObservableCollection<Question>();
        public ObservableCollection<Question> CurrentQuestionsObservable
        {
            get { return currentQuestionsObservable; }
            set { currentQuestionsObservable = value; onPropertyChange(nameof(CurrentQuestionsObservable)); }
        }

        public Int32 CurrentSelectedQuestionIdx
        {
            get {
                if (idxOfCurrentQuestion == questionsList.QuestionCounter)
                    return -1;
                return idxOfCurrentQuestion; }
            set { 
                if (value != -1)
                {
                    idxOfCurrentQuestion = value;
                    currentQuestion = questionsList.ListOfQuestions[idxOfCurrentQuestion];
                }

                CurrentQuestion = currentQuestion.QuestionText;
                CurrentAnswer_1 = currentQuestion.Ans1;
                CurrentAnswer_2 = currentQuestion.Ans2;
                CurrentAnswer_3 = currentQuestion.Ans3;
                CurrentAnswer_4 = currentQuestion.Ans4;
                CorrectAnswer = currentQuestion.CorrectAnswer;

                onPropertyChange(nameof(CurrentQuestion));
                onPropertyChange(nameof(CurrentAnswer_1));
                onPropertyChange(nameof(CurrentAnswer_2));
                onPropertyChange(nameof(CurrentAnswer_3));
                onPropertyChange(nameof(CurrentAnswer_4));
                onPropertyChange(nameof(CorrectAnswer));

                onPropertyChange(nameof(CurrentSelectedQuestionIdx)); }
        }

        private string title = "Title";
        public string Title
        {
            get { return title; }
            set { title = value; onPropertyChange(nameof(Title));
            }
        }

        private string fileName = "File_Name";
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; onPropertyChange(nameof(FileName)); }
        }


        private ICommand previousQuestion;
        public ICommand PreviousQuestion
        {
            get
            {
                if (previousQuestion == null)
                {
                    previousQuestion = new RelayCommand(
                        arg =>
                        {
                            idxOfCurrentQuestion--;
                            currentQuestion = questionsList[idxOfCurrentQuestion];

                            CurrentQuestion = currentQuestion.QuestionText;
                            CurrentAnswer_1 = currentQuestion.Ans1;
                            CurrentAnswer_2 = currentQuestion.Ans2;
                            CurrentAnswer_3 = currentQuestion.Ans3;
                            CurrentAnswer_4 = currentQuestion.Ans4;
                            CorrectAnswer = currentQuestion.CorrectAnswer;
                            onPropertyChange(nameof(CurrentQuestion));
                            onPropertyChange(nameof(CurrentAnswer_1));
                            onPropertyChange(nameof(CurrentAnswer_2));
                            onPropertyChange(nameof(CurrentAnswer_3));
                            onPropertyChange(nameof(CurrentAnswer_4));
                            onPropertyChange(nameof(CorrectAnswer));

                            onPropertyChange(nameof(CurrentSelectedQuestionIdx));
                        },
                        arg => idxOfCurrentQuestion > 0);
                }
                return previousQuestion;
            }
        }


        private ICommand nextQuestion;
        public ICommand NextQuestion
        {
            get
            {
                if (nextQuestion == null)
                {
                    nextQuestion = new RelayCommand(
                        arg =>
                        {
                            idxOfCurrentQuestion++;
                            currentQuestion = questionsList[idxOfCurrentQuestion];

                            CurrentQuestion = currentQuestion.QuestionText;
                            CurrentAnswer_1 = currentQuestion.Ans1;
                            CurrentAnswer_2 = currentQuestion.Ans2;
                            CurrentAnswer_3 = currentQuestion.Ans3;
                            CurrentAnswer_4 = currentQuestion.Ans4;
                            CorrectAnswer = currentQuestion.CorrectAnswer;
                            onPropertyChange(nameof(CurrentQuestion));
                            onPropertyChange(nameof(CurrentAnswer_1));
                            onPropertyChange(nameof(CurrentAnswer_2));
                            onPropertyChange(nameof(CurrentAnswer_3));
                            onPropertyChange(nameof(CurrentAnswer_4));
                            onPropertyChange(nameof(CorrectAnswer));

                            onPropertyChange(nameof(CurrentSelectedQuestionIdx));
                        },
                        arg => idxOfCurrentQuestion < questionsList.QuestionCounter);
                }
                return nextQuestion;
            }
        }

        private ICommand _addQuestion = null;
        public ICommand AddQuestion
        {
            get
            {
                if(_addQuestion == null)
                {
                    _addQuestion = new RelayCommand(
                        arg =>
                        {
                            currentQuestion.QuestionText = CurrentQuestion;
                            currentQuestion.Ans1 = CurrentAnswer_1;
                            currentQuestion.Ans2 = CurrentAnswer_2;
                            currentQuestion.Ans3 = CurrentAnswer_3;
                            currentQuestion.Ans4 = CurrentAnswer_4;
                            currentQuestion.CorrectAnswer = CorrectAnswer;

                            questionsList.Add(new Question(currentQuestion));
                            currentQuestionsObservable.Add(new Question(currentQuestion));

                            idxOfCurrentQuestion++;

                            currentQuestion = new Question();
                            onPropertyChange(nameof(CurrentQuestion));
                            onPropertyChange(nameof(CurrentAnswer_1));
                            onPropertyChange(nameof(CurrentAnswer_2));
                            onPropertyChange(nameof(CurrentAnswer_3));
                            onPropertyChange(nameof(CurrentAnswer_4));
                            onPropertyChange(nameof(CorrectAnswer));

                        },
                        arg => (!string.IsNullOrEmpty(CurrentQuestion) &&
                                !string.IsNullOrEmpty(CurrentAnswer_1) &&
                                !string.IsNullOrEmpty(CurrentAnswer_2) &&
                                !string.IsNullOrEmpty(CurrentAnswer_3) &&
                                !string.IsNullOrEmpty(CurrentAnswer_4) &&
                                CorrectAnswer != null)
                        );
                }
                return _addQuestion;
            }
        }


        private ICommand _editQuestion = null;
        public ICommand EditQuestion
        {
            get
            {
                if (_editQuestion == null)
                {
                    _editQuestion = new RelayCommand(
                        arg =>
                        {
                            currentQuestion.QuestionText = CurrentQuestion;
                            currentQuestion.Ans1 = CurrentAnswer_1;
                            currentQuestion.Ans2 = CurrentAnswer_2;
                            currentQuestion.Ans3 = CurrentAnswer_3;
                            currentQuestion.Ans4 = CurrentAnswer_4;
                            currentQuestion.CorrectAnswer = CorrectAnswer;

                            questionsList[idxOfCurrentQuestion].QuestionText = CurrentQuestion;
                            questionsList[idxOfCurrentQuestion].Ans1 = CurrentAnswer_1;
                            questionsList[idxOfCurrentQuestion].Ans2 = CurrentAnswer_2;
                            questionsList[idxOfCurrentQuestion].Ans3 = CurrentAnswer_3;
                            questionsList[idxOfCurrentQuestion].Ans4 = CurrentAnswer_4;
                            questionsList[idxOfCurrentQuestion].CorrectAnswer = CorrectAnswer;

                            currentQuestionsObservable[idxOfCurrentQuestion] = new Question(CurrentQuestion, CurrentAnswer_1, CurrentAnswer_2, CurrentAnswer_3, CurrentAnswer_4, CorrectAnswer);

                            onPropertyChange(nameof(CurrentQuestion));
                            onPropertyChange(nameof(CurrentAnswer_1));
                            onPropertyChange(nameof(CurrentAnswer_2));
                            onPropertyChange(nameof(CurrentAnswer_3));
                            onPropertyChange(nameof(CurrentAnswer_4));
                            onPropertyChange(nameof(CorrectAnswer));


                        },
                        arg => (!string.IsNullOrEmpty(CurrentQuestion) &&
                                !string.IsNullOrEmpty(CurrentAnswer_1) &&
                                !string.IsNullOrEmpty(CurrentAnswer_2) &&
                                !string.IsNullOrEmpty(CurrentAnswer_3) &&
                                !string.IsNullOrEmpty(CurrentAnswer_4) &&
                                CorrectAnswer != null &&
                                CurrentSelectedQuestionIdx != -1)
                        );
                }
                return _editQuestion;
            }
        }

        private ICommand saveQuiz;
        public ICommand SaveQuiz
        {
            get
            {
                if (saveQuiz == null)
                {
                    saveQuiz = new RelayCommand(
                        arg =>
                        {
                            if (questionsList.SaveQuiz(Title, FileName))
                                MessageBox.Show("Zapisano");
                            else
                                MessageBox.Show("Nie udało się zapisać");
                        },
                        arg => (!string.IsNullOrEmpty(Title) &&
                                !string.IsNullOrEmpty(FileName))
                        );
                }
                return saveQuiz;
            }
        }


        private ICommand loadQuiz;
        public ICommand LoadQuiz
        {
            get
            {
                if (loadQuiz == null)
                {
                    loadQuiz = new RelayCommand(
                        arg =>
                        {
                            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                            dlg.InitialDirectory = Directory.GetCurrentDirectory();
                            dlg.DefaultExt = ".txt";
                            dlg.Filter = "Text documents (.txt)|*.txt";

                            Nullable<bool> result = dlg.ShowDialog();

                            if (result == true)
                            {
                                string filename = dlg.FileName;

                                Title = questionsList.LoadQuiz(filename);
                                FileName = dlg.SafeFileName.Replace(".txt","");

                                currentQuestionsObservable = new ObservableCollection<Question>();
                                foreach (Question item in questionsList.ListOfQuestions)
                                {
                                    currentQuestionsObservable.Add(new Question(item));
                                }

                                currentQuestion = questionsList.ListOfQuestions[0];

                                onPropertyChange(nameof(CurrentQuestionsObservable));
                                onPropertyChange(nameof(CurrentQuestion));
                                onPropertyChange(nameof(CurrentAnswer_1));
                                onPropertyChange(nameof(CurrentAnswer_2));
                                onPropertyChange(nameof(CurrentAnswer_3));
                                onPropertyChange(nameof(CurrentAnswer_4));
                                onPropertyChange(nameof(CorrectAnswer));

                                MessageBox.Show("Wczytano pomyślnie");
                            }
                        },
                        arg => true
                        );
                }
                return loadQuiz;
            }
        }
    }
}
