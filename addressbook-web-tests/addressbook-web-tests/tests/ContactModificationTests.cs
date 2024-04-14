using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateIfNoContact();

            ContactData newData = new ContactData("Edit_Name8", "Edit_Lastname7");
            app.Contacts.Modify(1, newData);
        }
    }
}
