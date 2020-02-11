using System.Collections.Generic;
using Xamarin.Forms;

namespace Prototype.Controllers
{
    //Ignore this class for now, is used latet for MVVM or MVC
    public class ChoiceView : StackLayout
    {
        //Class properties
        public List<string> Choices 
        {
            get { return (List<string>)GetValue(ChoicesProperty); }
            set { SetValue(ChoicesProperty, value); }
        }

        //Bind the property of the strings to the choiceView i.e, view type 
        public static readonly BindableProperty ChoicesProperty =
            BindableProperty.Create(nameof(Choices), typeof(List<string>), typeof(ChoiceView), null,
                                     BindingMode.Default, null, OnItemsSourceChanged);

        static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue) =>
            ((ChoiceView)bindable).ChoiceViewPopulation();

        public string SelectedChoice
        {
            get { return (string)GetValue(SelectedChoiceProperty); }
            set { SetValue(SelectedChoiceProperty, value); }
        }

        public static readonly BindableProperty SelectedChoiceProperty =
            BindableProperty.Create(nameof(SelectedChoice), typeof(string), typeof(ChoiceView), defaultBindingMode: BindingMode.TwoWay);

        void ChoiceViewPopulation()
        {
            this.Children.Clear();
            foreach(var c in Choices)
            {
                var btn = new Button { Text = c };
                btn.Clicked += (sender, e) => SelectedChoice = c;
                this.Children.Add(btn);
            }
            
        }
    }

}
