using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Prototype.Models;

namespace Prototype.Ctrls
{
    class PageController
    {
        private readonly StackLayout MyLayout;
        private List<Content.RootObject> Contents;
        private List<ClozeTest> ClozeTests;
        private List<QuizQuestion> Questions;
        private int QIndex = 0;
        private int CIndex = 0;
        private int Index = 0;
        private QuizQuestion Question;
        private ClozeTest ClozeTest;
        private Label QuestionLbl;
        private Label SentenceLbl;
        private Content.RootObject Content;

        public PageController(StackLayout layout, List<Content.RootObject> contents)
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
            if (Index == 0 || Index % 2 == 0)
            {
                ShowQuestion();
            }
            else
            {
                ShowClozeTest();
            }
        }

        private void ShowQuestion()
        {
            if (Questions.Count == 0)
            {
                Index++;
                DoTransition();
                return;
            }
            Question = Questions[QIndex];
            QuestionLbl = new Label { Text = Question.Question, Padding = 35,  TextColor = Color.Black };
            MyLayout.Children.Add(QuestionLbl);

        }

        private void ShowClozeTest()
        {
            ClozeTest = ClozeTests[CIndex];
            SentenceLbl = new Label {Text = ClozeTest.Sentence, Padding = 35, TextColor = Color.Black};
            MyLayout.Children.Add(SentenceLbl);
        }

        private void DistributeData()
        {
            Questions = new List<QuizQuestion>();
            ClozeTests = new List<ClozeTest>();
            foreach(var i in Contents)
            {
                if (i.type.ToString().Equals("mcq"))
                {
                    QuizQuestion q = new QuizQuestion
                    {
                        Question = i.content.Question, Answers = i.content.Answers,
                        CorrectAnswer = i.content.CorrectAnswer
                    };
                    Questions.Add(q);
                }

                if (i.type.ToString().Equals("cloze"))
                {
                    ClozeTest c = new ClozeTest {Sentence = i.content.sentence, MissingWords = i.content.MissingWords};
                    ClozeTests.Add(c);
                }
            }           
        }
    }
}
