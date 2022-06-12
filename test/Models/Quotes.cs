using System.ComponentModel;

namespace test.Models
{
    public class Quotes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private decimal _price = -1;
        private decimal _volume_24h = -1;
        private decimal _market_cap = -1;
        private decimal _fully_diluted_market_cap = -1;
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
        public decimal Market_Cap
        {
            get => _market_cap;

            set
            {
                if (!value.Equals(_market_cap))
                {
                    _market_cap = value;
                    OnPropertyChanged(nameof(Market_Cap));
                }
            }
        }
        public decimal Fully_Diluted_Market_Cap
        {
            get => _fully_diluted_market_cap;

            set
            {
                if (!value.Equals(_fully_diluted_market_cap))
                {
                    _fully_diluted_market_cap = value;
                    OnPropertyChanged(nameof(Fully_Diluted_Market_Cap));
                }
            }
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}