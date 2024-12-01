using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDataBinding
{
    internal class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string prpertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prpertyName));
        }

        private string _name;
        private DateTime _birthDate;

        public string Name
        {
            get => _name;
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get
            {
                // 생일로부터 현재까지의 나이 계산
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged();

                    // Example of dependent property update
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(IsAdult));
                }
            }
        }

        public bool IsAdult => Age >= 18;
    }
}
