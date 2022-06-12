using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Model
{
    public class Crypto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _assetId = String.Empty;
        private string _name = String.Empty;
        private decimal _price = -1;
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
        public string Name
        {
            get => _name;

            set
            {
                if (!value.Equals(_name))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public decimal Price
        {
            get => _price;

            set
            {
                if (!value.Equals(_price))
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
