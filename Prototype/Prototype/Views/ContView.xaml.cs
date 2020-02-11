using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Ctrls;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContView : ContentPage
    {
        public ContView(string id)
        {
            InitializeComponent();
            Controller controller = new Controller(ContentPageLayout);
            controller.ShowContent(id);
        }
    }
}