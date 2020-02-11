using System;
using System.Collections.Generic;
using Prototype.Models;
using Xamarin.Forms;

namespace Prototype.Controllers
{
    class Page
    {
        private List<object> PageList;
        private readonly StackLayout MyLayout;
        private List<Content.RootObject> Contents;
        private List<ClozeTest> ClozeTests;
        private List<Models.Mcq> Questions;
        private int QIndex = 0;
        private int CIndex = 0;
        private int Index = 0;
        private Models.Mcq Question;
        private ClozeTest ClozeTest;
        private Label QuestionLbl;
        private Label SentenceLbl;
        private Content.RootObject Content;
        private List<Button> Btns;
        private string[] choices;

        public Page(StackLayout layout, List<Content.RootObject> contents)
        {
            this.MyLayout = layout;
            this.Contents = contents;

        }

        public void DisplayEachPage()
        {
            DistributeData();
            DoTransition();
        }

        private void DoTransition()
        {

            foreach (var page in PageList)
            {
                if (page.GetType() == typeof(Models.ClozeTest))
                {
                    ShowClozeTest(page);
                }
                if (page.GetType() == typeof(Models.Mcq))
                {
                    ShowQuestion(page);
                }

                break;
            }
        }

        private void ShowQuestion(Object page)
        {
            Question = (Models.Mcq) page;
            QuestionLbl = new Label { Text = Question.Question, Padding = 35,  TextColor = Color.Black };
            MyLayout.Children.Add(QuestionLbl);
            choices = CallBackChoices(Question);
            CreateMcqAnswerBtn();
        }
        private string[] CallBackChoices(Models.Mcq question)
        {
            string[] Choices = new string[5];
            for (int i = 0; i < Questions.Count; i++)
            {
                Choices[i] = Questions[i].Answers[i];
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
            //Button b = (Button)sender;
            //if (b.Text.Equals(question.CorrectAnswer))
            //{
            //    Console.WriteLine("Correct");
            //    index++;
            //    question = Questions[index];
            //    QuestionLbl.Text = question.Question;
            //    RefreshButtons(question);
            //}
        }
        private void ShowClozeTest(Object o)
        {
            ClozeTest = (ClozeTest) o;
            SentenceLbl = new Label {Text = ClozeTest.Sentence, Padding = 35, TextColor = Color.Black};
            MyLayout.Children.Add(SentenceLbl);
        }

        private void DistributeData()
        {

            PageList = new List<object>();
            Questions = new List<Models.Mcq>();
            ClozeTests = new List<ClozeTest>();
            foreach(var i in Contents)
            {
                if (i.type.ToString().Equals("mcq"))
                {
                    Models.Mcq q = new Models.Mcq
                    {
                        Question = i.content.Question, Answers = i.content.Answers,
                        CorrectAnswer = i.content.CorrectAnswer
                    };
                    Questions.Add(q);
                    PageList.Add(q);
                }

                if (i.type.ToString().Equals("cloze"))
                {
                    ClozeTest c = new ClozeTest {Sentence = i.content.sentence, MissingWords = i.content.MissingWords};
                    ClozeTests.Add(c);
                    PageList.Add(c);
                }
            }       
            Console.WriteLine(PageList[1]);
        }

    }
}
