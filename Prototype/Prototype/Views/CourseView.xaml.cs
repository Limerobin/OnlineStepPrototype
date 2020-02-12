using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
            Controllers.NavigationController navigation = new Controllers.NavigationController(CourseViewLayout);
            navigation.ShowCourses();
        }
    }
}