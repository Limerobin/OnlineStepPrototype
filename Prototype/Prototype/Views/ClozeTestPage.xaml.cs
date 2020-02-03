using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClozeTestPage : ContentPage
    {
        public ClozeTestPage()
        {
            InitializeComponent();
            Ctrls.ClozeTestController controller = new Ctrls.ClozeTestController(MyLayout, SentenceLbl, SendBtn, EntryAnswer);
            controller.ShowSentence();
        }
    }
}