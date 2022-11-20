using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.Data.Maker.Models
{
    /// <summary>
    /// Address Kind
    /// </summary>
    public enum AddressKind
    {
        /// <summary>
        /// Mailing (Postal)
        /// </summary>
        Mailing = 0,
        /// <summary>
        /// Billing (Accts. Receivable)
        /// </summary>
        Billing = 1,
        /// <summary>
        /// Other
        /// </summary>
        Other = 2
    }
}
