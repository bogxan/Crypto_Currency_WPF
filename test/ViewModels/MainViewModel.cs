using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using test.Commands;
using test.Model;
using test.Models;
using test.Views;

namespace test.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Crypto> myList { get; set; }
        public ObservableCollection<Crypto> dataGrid { get; set; }
        private string _srchwrd;
        private Crypto _selectedCrypto;
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
        public string SrchWrd
        {
            get=> _srchwrd;
            set
            {
                if (value != _srchwrd)
                {
                    _srchwrd = value;
                    OnPropertyChanged(nameof(SrchWrd));
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
            if (!string.IsNullOrEmpty(SrchWrd))
            {
                dataGrid.Clear();
                dataGrid = new ObservableCollection<Crypto>(myList.Where(x => x.Name.ToLower().Contains(SrchWrd.ToLower())|| x.Asset_Id.ToLower().Contains(SrchWrd.ToLower())).OrderByDescending(x => x.Price).ToList());
                CollectionViewSource.GetDefaultView(dataGrid).Refresh();
            }
            else
            {
                dataGrid.Clear();
                dataGrid = new ObservableCollection<Crypto>(myList.OrderByDescending(x => x.Price).Take(10));
                CollectionViewSource.GetDefaultView(dataGrid).Refresh();
            }
        }));
        private ProcessCommand _detailsCommand;
        public ProcessCommand DetailsCommand => _detailsCommand ?? (_detailsCommand = new ProcessCommand(obj => {
            Crypto choosenCrypto = SelectedCrypto;
            DetailsWindow detWind = new DetailsWindow(choosenCrypto.Asset_Id);
            detWind.ShowDialog();
        }));
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}