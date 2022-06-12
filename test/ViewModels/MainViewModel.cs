using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using test.Commands;
using test.Model;
using test.Models;

namespace test.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Crypto> myList { get; set; }
        public ObservableCollection<Crypto> dataGrid { get; set; }
        Crypto _selectedCrypto;
        public Crypto SelectedCrypto
        {
            get => _selectedCrypto;
            set
            {
                if (value != _selectedCrypto)
                {
                    _selectedCrypto = value;
                    OnPropertyChanged(nameof(SelectedCrypto));
                }
            }
        }
        public MainViewModel()
        {
            myList = GetData();
            dataGrid = new ObservableCollection<Crypto>(myList.OrderByDescending(x => x.Price).Take(10));
        }
        public ObservableCollection<Crypto> GetData()
        {
            string url = "https://www.cryptingup.com/api/assets";
            string json = new WebClient().DownloadString(url);
            var res = JsonConvert.DeserializeObject<ListCryptos>(json);
            return res.Assets;
        }

        private ProcessCommand _searchCommand;
        public ProcessCommand SearchCommand => _searchCommand ?? (_searchCommand = new ProcessCommand(obj => {
            
        }));
        private ProcessCommand _detailsCommand;
        public ProcessCommand DetailsCommand => _detailsCommand ?? (_detailsCommand = new ProcessCommand(obj => {
            Crypto choosenCrypto = SelectedCrypto;
            
        }));
        private ProcessCommand _convertCommand;
        public ProcessCommand ConvertCommand => _convertCommand ?? (_convertCommand = new ProcessCommand(obj => {

        }));

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
