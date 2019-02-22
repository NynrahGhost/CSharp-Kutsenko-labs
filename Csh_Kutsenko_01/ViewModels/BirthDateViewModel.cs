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

        private DateTime _date;
        private string _age;
        private string _zodiacWest;
        private string _zodiakChineese;

        private ICommand _update;

        public ICommand Update => _update ?? (_update = new RelayCommand<object>(o => UpdateFields()));
        

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = (System.DateTime.Now .Year - Date.Year).ToString();
                OnPropertyChanged();
            }
        }

        public string ZodiakWest
        {
            get { return _zodiacWest; }
            set
            {
                _zodiacWest = "Temporary field";
            }
        }

        public string ZodiakChineese
        {
            get { return _zodiakChineese; }
            set
            {
                _zodiakChineese = "Temporary field";
            }
        }



        private async void UpdateFields()
        {

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
