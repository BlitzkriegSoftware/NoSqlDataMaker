using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamaker.console.Models
{
    public class Person
    {
        public Guid MemberId { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string EMail { get; set; }
        public string Company { get; set; }
        public DateTime MemberSince { get; set; }
        public DateTime Birthday { get; set; }

        private List<Address> _addresses = null;

        public List<Address> Addresses
        {
            get
            {
                if (_addresses == null) _addresses = new List<Address>();
                return _addresses;
            }
        }

        private Dictionary<string, string> _preference = null;
        public Dictionary<string,string> Preference
        {
            get
            {
                if (_preference == null) _preference = new Dictionary<string, string>();
                return _preference;
            }
        }
    }
}

