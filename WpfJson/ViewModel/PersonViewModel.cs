using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfJson.ICommandUpdater;
using WpfJson.View;

//video 1: https://www.youtube.com/watch?v=5P0BNH6DByU
//video 2: https://www.youtube.com/watch?v=4f36kVve5YA
namespace WpfJson.ViewModel
{
    public class PersonViewModel : NotifyPropertyChangedHandler
    {
        string path = @"C:\Users\user1\source\repos\Wpf Tutorial\WpfJson\SourceDataFile\PeopleData.json";
        private ICommand _ShowDataCommand;
        private ICommand _AddCommand;

        //private PersonModel _SelectedPersonModel;
        private PersonModel _SelectedPersonModel;
        public PersonModel SelectedPersonModel
        {
            get { return _SelectedPersonModel; }
            set { _SelectedPersonModel = value; NotifyPropertyChanged("SelectedPersonModel"); }
        }

        private List<PersonModel> _Items;
        public List<PersonModel> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                NotifyPropertyChanged("Items");
            }
        }



        public PersonViewModel()
        {
            this.SelectedPersonModel = new PersonModel();
            ShowDataCommand.Execute(null);
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(param => this.AddJsonData(), null);
                }
                return _AddCommand;
            }
        }


        public ICommand ShowDataCommand
        {
            get
            {
                if (_ShowDataCommand == null)
                {
                    _ShowDataCommand = new RelayCommand(param => this.GetJsonData(), null);
                }
                return _ShowDataCommand;
            }
        }

        private void AddJsonData()
        {
            Items.Add(SelectedPersonModel);
            var NewJsonData = JsonConvert.SerializeObject(Items, Formatting.Indented);
            File.WriteAllText(path, NewJsonData);
        }

        private void GetJsonData()
        {
            string json = File.ReadAllText(path);
            Items = JsonConvert.DeserializeObject<List<PersonModel>>(json);
        }
    }
}
