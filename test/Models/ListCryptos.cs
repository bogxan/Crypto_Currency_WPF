using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Model;

namespace test.Models
{
    public class ListCryptos
    {
        public ObservableCollection<Crypto> Assets { get; set; }
        public int Next { get; set; }
    }
}
