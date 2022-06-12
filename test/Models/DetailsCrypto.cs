using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class DetailsCrypto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _assetId = String.Empty;
        private string _name = String.Empty;
        private decimal _price = -1;
        private string _description = String.Empty;
        private decimal _volume_24h = -1;
        private decimal _change_1h = -1;
        private decimal _change_24h = -1;
        private decimal _change_7d = -1;
        private decimal _total_supply = -1;
        private decimal _circulating_supply = -1;
        private decimal _max_supply = -1;
        private DateTime _created_at = new DateTime();
        private DateTime _updated_at = new DateTime();
        public DateTime Created_At
        {
            get => _created_at;

            set
            {
                if (!value.Equals(_created_at))
                {
                    _created_at = value;
                    OnPropertyChanged(nameof(Created_At));
                }
            }
        }
        public DateTime Updated_At
        {
            get => _updated_at;

            set
            {
                if (!value.Equals(_updated_at))
                {
                    _updated_at = value;
                    OnPropertyChanged(nameof(Updated_At));
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
        public string Description
        {
            get => _description;

            set
            {
                if (!value.Equals(_description))
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public decimal Volume_24h
        {
            get => _volume_24h;

            set
            {
                if (!value.Equals(_volume_24h))
                {
                    _volume_24h = value;
                    OnPropertyChanged(nameof(Volume_24h));
                }
            }
        }
        public decimal Change_1h
        {
            get => _change_1h;

            set
            {
                if (!value.Equals(_change_1h))
                {
                    _change_1h = value;
                    OnPropertyChanged(nameof(Change_1h));
                }
            }
        }
        public decimal Change_24h
        {
            get => _change_24h;

            set
            {
                if (!value.Equals(_change_24h))
                {
                    _change_24h = value;
                    OnPropertyChanged(nameof(Change_24h));
                }
            }
        }
        public decimal Change_7d
        {
            get => _change_7d;

            set
            {
                if (!value.Equals(_change_7d))
                {
                    _change_7d = value;
                    OnPropertyChanged(nameof(Change_7d));
                }
            }
        }
        public decimal Total_supply
        {
            get => _total_supply;

            set
            {
                if (!value.Equals(_total_supply))
                {
                    _total_supply = value;
                    OnPropertyChanged(nameof(Total_supply));
                }
            }
        }
        public decimal Circulating_supply
        {
            get => _circulating_supply;

            set
            {
                if (!value.Equals(_circulating_supply))
                {
                    _circulating_supply = value;
                    OnPropertyChanged(nameof(Circulating_supply));
                }
            }
        }
        public decimal Max_supply
        {
            get => _max_supply;

            set
            {
                if (!value.Equals(_max_supply))
                {
                    _max_supply = value;
                    OnPropertyChanged(nameof(Max_supply));
                }
            }
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}