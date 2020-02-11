using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Prototype.Models;

namespace Prototype.Ctrls
{
    class ContentController
    {
        private readonly StackLayout MyLayout;
        private List<Content.RootObject> Contents;
        private readonly List<ClozeTest> ClozeTests;
        private readonly List<QuizQuestion> Questions;
        private int QIndex = 0;
        private int CIndex = 0;
        private int Index = 0;
        private QuizQuestion Question;
        private ClozeTest ClozeTest;
        private Label QuestionLbl;
        private Label SentenceLbl;
        private Content.RootObject Content;

        public ContentController(StackLayout layout, List<Content.RootObject> contents)
        {
            this.MyLayout = layout;
            this.Contents = contents;
            this.Content = this.Contents[Index];
        }

        public void DisplayEachPage()
        {
            DistributeData();
        }

        private void DoTransition()
        {             
            Console.WriteLine(Contents.Count);        
        }

        private void ShowQuestion()
        {
            //QuestionLbl.Text = Content.Question;
            QuestionLbl.TextColor = Color.Black;
            QuestionLbl.Padding = 35;

        }

        private void ShowClozeTest()
        {
            //SentenceLbl.Text = Content.sentence;
            SentenceLbl.TextColor = Color.Black;
            SentenceLbl.Padding = 35;
        }

        private void DistributeData()
        {
            foreach(var i in Contents)
            {
                
            }           
        }
    }
}
