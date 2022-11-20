using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.Data.Maker.Models
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address Line
        /// </summary>
        public string? Address1 { get; set; }
        /// <summary>
        /// Appt, Department, Floor, etc.
        /// </summary>
        public string? Address2 { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// State or Postal Code
        /// </summary>
        public string? State { get; set; }
        /// <summary>
        /// Zip Code
        /// </summary>
        public string? Zip { get; set; }

        /// <summary>
        /// Kind: Address
        /// </summary>
        public AddressKind Kind { get; set; } = AddressKind.Other;

        /// <summary>
        /// Address is Empty
        /// </summary>
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
