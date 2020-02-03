using Newtonsoft.Json;
using Prototype.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Prototype.Ctrls
{
    class QuizController
    {
        private const string url = "http://users.du.se/~h17najse/Android/assignment/test.php";
        private RestClient.RestClient_Alpha RestClient;
        private readonly Label QuestionLbl;
        private readonly StackLayout MyLayout;
        private QuizQuestion question;
        private string[] choices;
        private int index = 0;
        private List<QuizQuestion> Questions;
        private List<Button> Btns;


        public QuizController(Label lbl, StackLayout layout)
        {
            this.QuestionLbl = lbl;
            this.MyLayout = layout;
        }

        public void ShowQuestions()
        {
            //Instantiation of our RestClient object
            RestClient = new RestClient.RestClient_Alpha { EndPoint = url };
            string Response = RestClient.DoRequest();
            Console.WriteLine(Response.ToString());
            //JsonCovert does exactly what is says...
            Questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(Response);
            DoTransition();
        }

        private void DoTransition()
        {
            question = Questions[index];
            QuestionLbl.Text = question.Question;
            choices = CallBackChoices(question);
            CreateButtons();
        }

        private void CreateButtons()
        {
            Btns = new List<Button>();
            foreach(var c in choices)
            {
                Button btn = new Button { Text = c };
                Btns.Add(btn);
            }

            foreach(var i in Btns)
            {
                i.Clicked += BtnAction;
                MyLayout.Children.Add(i);
            }
        
            //for (int i = 0; i < Btns.Count; i++)
            //{
            //    Btns[i].Clicked += BtnAction;
            //    MyLayout.Children.Add(Btns[i]);
            //}

        }

        private void BtnAction(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text.Equals(question.CorrectAnswer))
            {
                Console.WriteLine("Correct");
                index++;
                question = Questions[index];
                QuestionLbl.Text = question.Question;
                RefreshButtons(question);
            }
        }

        private void RefreshButtons(QuizQuestion question)
        {
            choices = CallBackChoices(question);

            for (int i = 0; i < choices.Length; i++)
            {
                Btns[i].Text = choices[i];
            }

        }

        private string[] CallBackChoices(QuizQuestion question)
        {
            string[] Choices = new string[3] { question.Alt1, question.Alt2, question.Alt3 };
            return Choices;
        }

    }
}
