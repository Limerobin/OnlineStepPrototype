using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Models;
using Prototype.Ctrls;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterPage : ContentPage
    {
        public ChapterPage(String id)
        {
            InitializeComponent();
            Controller controller = new Controller(ChapterPageLayout);
            controller.ShowChapters(id);
        }
      
    }
}