using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
            Ctrls.QuizController controller = new Ctrls.QuizController(QuestionLbl,myLayout);
            controller.ShowQuestions();
        }    
    }
}