using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryPoint
{
    public class ResultViewModel : INotifyPropertyChanged
    {

        public ResultViewModel(ObservableCollection<QuestionModel> SelectedQuestions)
        {
            ResultList = SelectedQuestions;


            refreshCommand = new Command(Refresh);
        }



        ICommand refreshCommand;
        public ICommand RefreshCommand
        {
            get { return refreshCommand; }
            set
            {
                if (refreshCommand == null)
                    return;
                refreshCommand = value;
            }
        }

        private QuestionModel _item;
        public QuestionModel Item
        {
            get => _item;
            set { 
                _item = null;
                RaisePropertyChanged("Item");
            }
        }
        private ObservableCollection<QuestionModel> _resultList;
        public ObservableCollection<QuestionModel> ResultList
        {
            get => _resultList;
            set { _resultList = value; RaisePropertyChanged("ResultList"); }
        }


        public void Refresh()
        {
            Application.Current.MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#9575CD")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
