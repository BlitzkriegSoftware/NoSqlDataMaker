using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.Data.Maker.Models
{
    /// <summary>
    /// Model: Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Mongo DB is super fussy about this name
        /// </summary>
        public Guid _id { get; set; }
        /// <summary>
        /// Last
        /// </summary>
        public string? NameLast { get; set; }
        /// <summary>
        /// First
        /// </summary>
        public string? NameFirst { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? EMail { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string? Company { get; set; }
        /// <summary>
        /// Member Since
        /// </summary>
        public DateTime MemberSince { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.MinValue;

        private List<Address>? _addresses;

        /// <summary>
        /// Addresses
        /// </summary>
        public List<Address> Addresses
        {
            get
            {
                if (_addresses == null) _addresses = new List<Address>();
                return _addresses;
            }
        }

        private Dictionary<string, string>? _preference;
        /// <summary>
        /// Preferences
        /// </summary>
        public Dictionary<string, string> Preference
        {
            get
            {
                if (_preference == null) _preference = new Dictionary<string, string>();
                return _preference;
            }
        }
    }
}
