using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allDetails;
        private string allEmails;
        private string allPhonesFromDetails;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname=" + Lastname + "\nfirstname=" + Firstname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; } = "";

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string HomePhoneDefinition(string homePhone)
        {
            if (string.IsNullOrEmpty(homePhone))
            {
                return "";
            }
            return "H: " + homePhone + "\r\n";
        }

        public string MobilePhoneDefinition(string mobilePhone)
        {
            if (string.IsNullOrEmpty(mobilePhone))
            {
                return "";
            }
            return "M: " + mobilePhone + "\r\n";
        }

        public string WorkPhoneDefinition(string workPhone)
        {
            if (string.IsNullOrEmpty(workPhone))
            {
                return "";
            }
            return "W: " + workPhone + "\r\n";
        }

        public string AllPhonesFromDetails
        {
            get
            {
                if (allPhonesFromDetails != null)
                {
                    return allPhonesFromDetails;
                }
                else
                {
                    if (string.IsNullOrEmpty(HomePhone) && string.IsNullOrEmpty(MobilePhone) && string.IsNullOrEmpty(WorkPhone))
                    {
                        return "";
                    }
                    return (HomePhoneDefinition(HomePhone) + MobilePhoneDefinition(MobilePhone) + WorkPhoneDefinition(WorkPhone)) + "\r\n";
                }
            }
            set
            {
                allPhonesFromDetails = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" + Address + "\r\n"
                            + AllPhonesFromDetails + AllEmails + "\r\n\r\n").Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}
