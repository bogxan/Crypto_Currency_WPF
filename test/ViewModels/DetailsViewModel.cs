using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.Commands;
using test.Models;

namespace test.ViewModels
{
    public class DetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _assetId = String.Empty;
        public ObservableCollection<ListQuotes> ListQuotes { get; set; } = new ObservableCollection<ListQuotes>();
        private DetailsCrypto _crypto;
        public DetailsCrypto SelectedCrypto
        {
            get => _crypto;
            set
            {
                if (value != _crypto)
                {
                    _crypto = value;
                    OnPropertyChanged(nameof(SelectedCrypto));
                }
            }
        }
        public string Asset_Id
        {
            get => _assetId;

            set
            {
                if (!value.Equals(_assetId))
                {
                    _assetId = value;
                    OnPropertyChanged(nameof(Asset_Id));
                }
            }
        }
        public DetailsViewModel(string choosedId)
        {
            Asset_Id = choosedId;
            SelectedCrypto = GetData(Asset_Id);
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.USD, Name = "USD" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.EUR, Name = "EUR" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.NZD, Name = "NZD" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.AUD, Name = "AUD" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.JPY, Name = "JPY" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.GBP, Name = "GBP" });
            ListQuotes.Add(new ListQuotes { Quote = SelectedCrypto.Quote.CAD, Name = "CAD" });
        }
        private ProcessCommand _exitCommand;
        public ProcessCommand ExitCommand => _exitCommand ?? (_exitCommand = new ProcessCommand(obj => {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) 
                    item.Close();
            }
        }));
        public DetailsCrypto GetData(string id)
        {
            string url = $"https://www.cryptingup.com/api/assets/{id}";
            string json = new WebClient().DownloadString(url);
            var res = JsonConvert.DeserializeObject<ListDetailsCrypto>(json);
            return res.Asset;
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
