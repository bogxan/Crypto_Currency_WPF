using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using test.Models;

namespace test.ViewModels
{
    public class DetailsViewModel
    {
        public ObservableCollection<DetailsCrypto> GetData(string id)
        {
            string url = "https://www.cryptingup.com/api/assets/"+id;
            string json = new WebClient().DownloadString(url);
            var res = JsonConvert.DeserializeObject<ObservableCollection<DetailsCrypto>>(json);
            return res;
        }
    }
}
