using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Csh_Kutsenko_01.Annotations;
using Csh_Kutsenko_01.Tools;
using Csh_Kutsenko_01.Tools.Managers;
using Test.Misc;

namespace Csh_Kutsenko_01.ViewModels
{
    class BirthDateViewModel : INotifyPropertyChanged
    {

        private DateTime _date = System.DateTime.Today;
        private string _age;
        private string _zodiacWest;
        private string _zodiakChineese;

        private ICommand _update;

        public ICommand Update => _update ?? (_update = new RelayCommand<object>(o => UpdateFields()));
        

        public DateTime Date
        {
            get { return _date; }
            set
            {
                int tmp = (System.DateTime.Today - value).Days / 365;
                if (tmp > 135 | value > System.DateTime.Today)
                {
                    MessageBox.Show("Некоректна дата!");
                    _date = System.DateTime.Today;
                    return;
                }

                _date = value;
                Age = tmp.ToString();


                switch (value.Date.Month)
                {
                    case 1:
                        ZodiakWest = value.Date.Day < 20 ? "Стрілець" : "Козоріг";
                        break;
                    case 2:
                        ZodiakWest = value.Date.Day < 16 ? "Козоріг" : "Водолій";
                        break;
                    case 3:
                        ZodiakWest = value.Date.Day < 11 ? "Водолій" : "Риби";
                        break;
                    case 4:
                        ZodiakWest = value.Date.Day < 18 ? "Риби" : "Овен";
                        break;
                    case 5:
                        ZodiakWest = value.Date.Day < 13 ? "Овен" : "Телець";
                        break;
                    case 6:
                        ZodiakWest = value.Date.Day < 21 ? "Телець" : "Близнюки";
                        break;
                    case 7:
                        ZodiakWest = value.Date.Day < 20 ? "Близнюки" : "Рак";
                        break;
                    case 8:
                        ZodiakWest = value.Date.Day < 10 ? "Рак" : "Лев";
                        break;
                    case 9:
                        ZodiakWest = value.Date.Day < 16 ? "Лев" : "Діва";
                        break;
                    case 10:
                        ZodiakWest = value.Date.Day < 30 ? "Діва" : "Терези";
                        break;
                    case 11:
                        ZodiakWest = value.Date.Day < 23 ? "Терези" : Date.Date.Day < 29 ? "Скорпіон" : "Змієносець";
                        break;
                    case 12:
                        ZodiakWest = value.Date.Day < 17 ? "Змієносець" : "Стрілець";
                        break;
                }

                switch (value.Date.Year % 12)
                {
                    case 0:
                        ZodiakChineese = "Мавпа";
                        break;
                    case 1:
                        ZodiakChineese = "Півень";
                        break;
                    case 2:
                        ZodiakChineese = "Собака";
                        break;
                    case 3:
                        ZodiakChineese = "Свиня";
                        break;
                    case 4:
                        ZodiakChineese = "Пацюк";
                        break;
                    case 5:
                        ZodiakChineese = "Бик";
                        break;
                    case 6:
                        ZodiakChineese = "Тигр";
                        break;
                    case 7:
                        ZodiakChineese = "Кролик";
                        break;
                    case 8:
                        ZodiakChineese = "Дракон";
                        break;
                    case 9:
                        ZodiakChineese = "Змія";
                        break;
                    case 10:
                        ZodiakChineese = "Кінь";
                        break;
                    case 11:
                        ZodiakChineese = "Коза";
                        break;
                }


                if (value.Date.Month == System.DateTime.Today.Month && value.Date.Day == System.DateTime.Today.Day)
                {
                    MessageBox.Show("Схоже, що сьогодні в вас день народження! Вітаємо!");
                }
                
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return "Ваш вік: " + System.Environment.NewLine + _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string ZodiakWest
        {
            get { return "Ваш знак задіаку за західною системою: " + System.Environment.NewLine + _zodiacWest; }
            set
            {
                _zodiacWest = value;
                OnPropertyChanged();
            }
        }

        public string ZodiakChineese
        {
            get { return "Ваш знак задіаку за китайською системою: " + System.Environment.NewLine + _zodiakChineese; }
            set
            {
                _zodiakChineese = value;
                OnPropertyChanged();
            }
        }



        private void UpdateFields()
        {
            _age = ((System.DateTime.Today.Subtract(Date)).Days / 365).ToString(); //(System.DateTime.Now.Year - Date.Year).ToString();

            _zodiacWest = "Temporary field";

            _zodiakChineese = "Temporary field";

        }

        public BirthDateViewModel()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
