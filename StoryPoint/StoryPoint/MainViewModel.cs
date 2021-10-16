using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryPoint
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {

            swipeCommand = new Command<SwipedCardEventArgs>(Swipe);
            
            Questions = new ObservableCollection<QuestionModel>();
            SelectedQuestions = new ObservableCollection<QuestionModel>();
            QuestionsBinding();
        }

        ICommand swipeCommand;
        public ICommand SwipeCommand
        {
            get { return swipeCommand; }
            set
            {
                if (swipeCommand == null)
                    return;
                swipeCommand = value;
            }
        }


        private QuestionModel _question;
        public QuestionModel Question
        {
            get => _question;
            set 
            { 
                _question = value;

                if (_question == null)
                    Application.Current.MainPage.Navigation.PushAsync(new ResultPage(SelectedQuestions));

                RaisePropertyChanged("Question"); 
            }
        }


        private ObservableCollection<QuestionModel> _questions;
        public ObservableCollection<QuestionModel> Questions
        {
            get => _questions;
            set { _questions = value; RaisePropertyChanged("Questions"); }
        }


        private ObservableCollection<QuestionModel> _selectedquestions;
        public ObservableCollection<QuestionModel> SelectedQuestions
        {
            get => _selectedquestions;
            set { _selectedquestions = value; RaisePropertyChanged("SelectedQuestions"); }
        }

        private int _totalPoint = 0;
        public int TotalPoint 
        { 
            get => _totalPoint; 
            set { _totalPoint = value; RaisePropertyChanged("TotalPoint"); } 
        }

        public void QuestionsBinding()
        {

            //analiz soruları
            _questions.Add(new QuestionModel() { ID = 1, Point = 1, Desc = "CR süreci işleyecek mi?" });
            _questions.Add(new QuestionModel() { ID = 2, Point = 1, Desc = "Development öncesi developer analizi gerekiyor mu?" });
            _questions.Add(new QuestionModel() { ID = 3, Point = 1, Desc = "Sistemsel ihtiyaçlar ve setuplar var mı? (yetki, talep vb.)" });
            _questions.Add(new QuestionModel() { ID = 4, Point = 1, Desc = "Kapsamlı kullanım dökümanı hazırlanacak mı?" });
            _questions.Add(new QuestionModel() { ID = 5, Point = 1, Desc = "Toplantı yapmaya/organize olmaya ihtiyaç var mı?" });
            _questions.Add(new QuestionModel() { ID = 6, Point = 1, Desc = "Analiz süreci olacak mı?" });

            //development soruları
            _questions.Add(new QuestionModel() { ID = 7, Point = 1,  Desc = "Riskli bir yerde mi kod değişikliği yapılıyor?" });
            _questions.Add(new QuestionModel() { ID = 8, Point = 1,  Desc = "Developerların test yükü fazla mı?" });
            _questions.Add(new QuestionModel() { ID = 9, Point = 1,  Desc = "Daha önce benzeri yapılmamış mı?" });
            _questions.Add(new QuestionModel() { ID = 10, Point = 1, Desc = "DB tarafında değişiklik yapılacak mı?" });
            _questions.Add(new QuestionModel() { ID = 11, Point = 1, Desc = "Back-End tarafında geliştirme var mı?" });
            _questions.Add(new QuestionModel() { ID = 12, Point = 1, Desc = "Rapor geliştirmesi mi?" });
            _questions.Add(new QuestionModel() { ID = 13, Point = 1, Desc = "Front-End iş yükü ne kadar?" });
            _questions.Add(new QuestionModel() { ID = 14, Point = 1, Desc = "Cross development olacak mı?" });

            //test soruları
            _questions.Add(new QuestionModel() { ID = 15, Point = 1, Desc = "Diğer ekiplerle ortak çalışma olacak mı?" });
            _questions.Add(new QuestionModel() { ID = 16, Point = 1, Desc = "UAT süreci olacak mı?" });
            _questions.Add(new QuestionModel() { ID = 17, Point = 1, Desc = "Farklı ortamlarda test senaryoları işletilecek mi?" });
            _questions.Add(new QuestionModel() { ID = 18, Point = 1, Desc = "Test için data hazırlığı gerekiyor mu?" });
            _questions.Add(new QuestionModel() { ID = 19, Point = 1, Desc = "Yük testi yapılacak mı?" });
            _questions.Add(new QuestionModel() { ID = 20, Point = 1, Desc = "Test yapılacak mı?" });
        }

      
        public void Swipe(SwipedCardEventArgs eventArgs)
        {
            if (eventArgs.Direction == SwipeCardDirection.Right)
                SelectedQuestions.Add((QuestionModel)(eventArgs.Item));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
