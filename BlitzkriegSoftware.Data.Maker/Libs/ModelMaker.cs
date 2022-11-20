using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.Data.Maker.Libs
{
    /// <summary>
    /// Model Maker
    /// </summary>
    public static class ModelMaker
    {
        private static Random Dice = new Random();

        /// <summary>
        /// Make Onen Person
        /// </summary>
        /// <returns></returns>
        public static Models.Person PersonMake()
        {
            var person = new Models.Person()
            {
                _id = Guid.NewGuid(),
                Birthday = Faker.Date.Birthday(),
                EMail = Faker.User.Email(),
                NameLast = Faker.Name.LastName()
            };

            var gender = Faker.Name.Gender();
            if (gender.ToLowerInvariant().StartsWith("f"))
            {
                person.NameFirst = Faker.Name.FemaleFirstName();
            }
            else
            {
                person.NameFirst = Faker.Name.MaleFirstName();
            }

            person.Company = person.EMail.Substring(person.EMail.IndexOf('@') + 1);

            person.EMail = string.Format("{0}.{1}@{2}", person.NameFirst, person.NameLast, person.Company);

            person.MemberSince = person.Birthday.AddDays(365 * 18 + Dice.Next(1, 365));

            for (int p = 0; p < Dice.Next(2, 6); p++)
            {
                person.Preference.Add(string.Format("{0}-{1}", Faker.Lorem.Word(), p), Faker.Lorem.Sentence());
            }

            person.Addresses.Add(new Models.Address()
            {
                Address1 = string.Format("{0} {1} {2}", Faker.Number.RandomNumber(101, 8888), Faker.Address.StreetName(), Faker.Address.StreetSuffix()),
                City = Faker.Address.USCity(),
                State = Faker.Address.StateAbbreviation(),
                Zip = Faker.Address.USZipCode(),
                Kind = Models.AddressKind.Mailing
            });

            if (Dice.Next(1, 10) > 7)
            {
                person.Addresses.Add(new Models.Address()
                {
                    Address1 = string.Format("{0} {1} {2}", Faker.Number.RandomNumber(101, 8888), Faker.Address.StreetName(), Faker.Address.StreetSuffix()),
                    City = Faker.Address.USCity(),
                    State = Faker.Address.StateAbbreviation(),
                    Zip = Faker.Address.USZipCode(),
                    Kind = Models.AddressKind.Billing
                });
            }

            return person;
        }
    }
}
