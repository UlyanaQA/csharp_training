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
    public class ContactModificationTests : ContactTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateIfNoContact();

            ContactData newData = new ContactData("Edit_Name8", "Edit_Lastname7");

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0] = newData;

            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
