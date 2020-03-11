using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Controllers;
using Prototype.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class McqView : ContentPage
    {
        public McqView()
        {
            InitializeComponent();
            PageController controller = new PageController();
            //    TitleLbl.Text = 
            //    Question = (Models.Mcq)page;
            //    QuestionLbl = new Label { Text = Question.Question, Padding = 35, TextColor = Color.Black };
            //    McqView.ch
            //    MyLayout.Children.Add(QuestionLbl);
            //    choices = CallBackChoices(Question);
            //    CreateMcqAnswerBtn();
            //    MyLayout.Children.Add(SubmitBtn);
            //}
            //private void CreateMcqAnswerBtn()
            //{
            //    Btns = new List<Button>();
            //    foreach (var c in choices)
            //    {
            //        Button btn = new Button { Text = c };
            //        Btns.Add(btn);
            //    }

            //    foreach (var i in Btns)
            //    {
            //        i.Clicked += McqAnswerBtnAction;
            //        MyLayout.Children.Add(i);
            //    }
        }

    }
}