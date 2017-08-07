using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamaker.console.Models
{
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public AddressKind Kind { get; set; }

        [JsonIgnore]
        public bool IsEmpty
        {
            get
            {
                return 
                    string.IsNullOrWhiteSpace(this.Address1) &&
                    string.IsNullOrWhiteSpace(this.City) &&
                    string.IsNullOrWhiteSpace(this.State) &&
                    string.IsNullOrWhiteSpace(this.Zip);
            }
        }
    }
}
