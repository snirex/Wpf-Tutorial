using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfJson.View;

namespace WpfJson.ViewModel
{
    public class PersonModel : NotifyPropertyChangedHandler
    {
        

        List<PersonModel> Items { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("firstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("lastName");
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; NotifyPropertyChanged("gender"); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged("age"); }
        }

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; NotifyPropertyChanged("number"); }
        }

    }
}
