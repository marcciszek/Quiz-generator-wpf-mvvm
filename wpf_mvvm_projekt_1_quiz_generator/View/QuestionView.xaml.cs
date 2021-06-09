using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_mvvm_projekt_1_quiz_generator.View
{
    /// <summary>
    /// Logika interakcji dla klasy QuestionView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {
        public QuestionView()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty QuestionProperty =
                DependencyProperty.Register(
                    nameof(Question),
                    typeof(string),
                    typeof(QuestionView));
        public string Question
        {
            get { return (string)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty AnswerProperty_1 =
            DependencyProperty.Register(
                nameof(Answer_1),
                typeof(string),
                typeof(QuestionView));
        public string Answer_1
        {
            get { return (string)GetValue(AnswerProperty_1); }
            set { SetValue(AnswerProperty_1, value); }
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty AnswerProperty_2 =
            DependencyProperty.Register(
                nameof(Answer_2),
                typeof(string),
                typeof(QuestionView));
        public string Answer_2
        {
            get { return (string)GetValue(AnswerProperty_2); }
            set { SetValue(AnswerProperty_2, value); }
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty AnswerProperty_3 =
            DependencyProperty.Register(
                nameof(Answer_3),
                typeof(string),
                typeof(QuestionView));

        public string Answer_3
        {
            get { return (string)GetValue(AnswerProperty_3); }
            set { SetValue(AnswerProperty_3, value); }
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty AnswerProperty_4 =
            DependencyProperty.Register(
                nameof(Answer_4),
                typeof(string),
                typeof(QuestionView));

        public string Answer_4
        {
            get { return (string)GetValue(AnswerProperty_4); }
            set { SetValue(AnswerProperty_4, value); }
        }
        //-------------------------------------------------------------------------------
        public static readonly DependencyProperty CorrectAnswerProperty =
            DependencyProperty.Register(
                nameof(Correct),
                typeof(int?),
                typeof(QuestionView),
                new PropertyMetadata(new PropertyChangedCallback(ChangeChecked)));
        public int? Correct
        {
            get { return (int?)GetValue(CorrectAnswerProperty); }
            set { SetValue(CorrectAnswerProperty, value); }
        }
        //-------------------------------------------------------------------------------
        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            Correct = int.Parse((sender as RadioButton).Tag.ToString());
        }

        private static void ChangeChecked(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int? newValue = (int?)e.NewValue;
            if (newValue == null)
            {
                (d as QuestionView).RBAns_1.IsChecked = false;
                (d as QuestionView).RBAns_2.IsChecked = false;
                (d as QuestionView).RBAns_3.IsChecked = false;
                (d as QuestionView).RBAns_4.IsChecked = false;
            }
            if (newValue == 0)
                (d as QuestionView).RBAns_1.IsChecked = true;

            if (newValue == 1)
                (d as QuestionView).RBAns_2.IsChecked = true;

            if (newValue == 2)
                (d as QuestionView).RBAns_3.IsChecked = true;

            if (newValue == 3)
                (d as QuestionView).RBAns_4.IsChecked = true;
        }
    }
}
