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
        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private ObservableCollection<Crypto> _cryptos;
        public ObservableCollection<Crypto> Cryptos
        {
            get { return _cryptos; }
            set
            {
                _cryptos = value;
                OnPropertyChanged("CryptosList");
            }
        }
        private ListCollectionView _view;
        public ICollectionView View
        {
            get { return _view; }
        }
        private string _TextSearch;
        public string TextSearch
        {
            get { return _TextSearch; }
            set
            {
                _TextSearch = value;
                OnPropertyChanged("TextSearch");
                View.Refresh();
            }
        }
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
        public MainViewModel()
        {
            Cryptos = new ObservableCollection<Crypto>(GetData());
            _view = new ListCollectionView(_cryptos);
            Console.WriteLine(_view.Count);
            _view.Filter = Filter;
        }
        public List<Crypto> GetData()
        {
            string url = "https://www.cryptingup.com/api/assets";
            string json = new WebClient().DownloadString(url);
            var res = JsonConvert.DeserializeObject<ListCryptos>(json);
            return res.Assets.ToList();
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(TextSearch))
                return true;
            else
                return ((item as Crypto).Name.IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Crypto).Asset_Id.IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private ProcessCommand _detailsCommand;
        public ProcessCommand DetailsCommand => _detailsCommand ?? (_detailsCommand = new ProcessCommand(obj => {
            DetailsWindow detWind = new DetailsWindow(SelectedCrypto.Asset_Id);
            detWind.ShowDialog();
        }));
    }
}