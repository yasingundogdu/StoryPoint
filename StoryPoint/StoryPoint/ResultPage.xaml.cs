using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoryPoint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        public ResultPage(ObservableCollection<QuestionModel> SelectedQuestions)
        {
            InitializeComponent();

            BindingContext = new ResultViewModel(SelectedQuestions);
        }


       
    }
}