using Prototype.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Prototype.Controllers
{
    class PageController
    {
        private List<object> PageList;
        private readonly StackLayout MyLayout;
        private List<Content.RootObject> Contents;
        private int Index = 0;
        private Models.Mcq Question;
        private Cloze ClozeTest;
        private Label QuestionLbl;
        private Label SentenceLbl;
        private Content.RootObject Content;
        private List<Button> Btns;
        private string[] choices;
        private Button SubmitBtn;
        private string SelectedAnswer;
        private Entry Input;

        public PageController()
        {

        }

        public void DisplayEachPage()
        {
            //Help method
            DistributeData();
            DoTransition();
        }

        private void DoTransition()
        {
            MyLayout.Children.Clear();

            if (Index == PageList.Count)
            {
                MyLayout.Navigation.PopModalAsync();
                return;
            }

            switch (PageList[Index].GetType().Name)
            {
                case "ClozeTest":
                    ShowClozeTest(PageList[Index]);
                    break;
                case "Mcq":
                    ShowQuestion(PageList[Index]);
                    break;
            }
        }

        private void ShowQuestion(Object page)
        {
            Question = (Models.Mcq)page;
            QuestionLbl = new Label { Text = Question.Question, Padding = 35, TextColor = Color.Black };

            MyLayout.Children.Add(QuestionLbl);
            choices = CallBackChoices(Question);
            CreateMcqAnswerBtn();
            MyLayout.Children.Add(SubmitBtn);
        }

        private void SubmitBtnAction(object sender, EventArgs e)
        {
            if (PageList[Index].GetType() == typeof(Models.Mcq))
            {
                Index++;
                //TODO: Show correct or wrong here
                DoTransition();

            }
            else if (PageList[Index].GetType() == typeof(Models.Cloze))
            {
                Index++;
                DoTransition();
            }
        }

        private string[] CallBackChoices(Models.Mcq question)
        {
            string[] Choices = new string[question.Answers.Count];
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Choices[i] = question.Answers[i];
            }
            return Choices;
        }
        private void CreateMcqAnswerBtn()
        {
            Btns = new List<Button>();
            foreach (var c in choices)
            {
                Button btn = new Button { Text = c };
                Btns.Add(btn);
            }

            foreach (var i in Btns)
            {
                i.Clicked += McqAnswerBtnAction;
                MyLayout.Children.Add(i);
            }
        }
        private void McqAnswerBtnAction(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            foreach (var i in Btns)
            {
                if (!i.Text.Equals(b.Text))
                {
                    i.BackgroundColor = Color.Gray;
                }
                else
                {
                    b.BackgroundColor = Color.Aqua;
                    SelectedAnswer = b.Text;
                }
            }

        }
        private void ShowClozeTest(Object o)
        {
            ClozeTest = (Cloze) o;
            Input = new Entry { HorizontalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 100 };
            SentenceLbl = new Label { Text = ModifiedSentence(), Padding = 35, TextColor = Color.Black };      
            MyLayout.Children.Add(SentenceLbl);
            MyLayout.Children.Add(Input);
            MyLayout.Children.Add(SubmitBtn);
        }

        private string ModifiedSentence()
        {
            string Value = null;
            ClozeTest.MissingWords.RemoveAll(item => item == null);
            foreach (var i in ClozeTest.MissingWords)
            {
                if (ClozeTest.Sentence.Contains(i))
                {
                    Value = ClozeTest.Sentence.Replace(i, "______");
                    Console.WriteLine(i);
                }
            }
            return Value;
        }

        private void DistributeData()
        {

            PageList = new List<object>();
            foreach (var i in Contents)
            {
                if (i.type.ToString().Equals("mcq"))
                {
                    Models.Mcq q = new Models.Mcq
                    {
                        Question = i.content.Question,
                        Answers = i.content.Answers,
                        CorrectAnswer = i.content.CorrectAnswer
                    };
                    PageList.Add(q);
                }

                if (i.type.ToString().Equals("cloze"))
                {
                    Cloze c = new Cloze { Sentence = i.content.sentence, MissingWords = i.content.MissingWords };
                    PageList.Add(c);
                }
            }
        }

    }
}
