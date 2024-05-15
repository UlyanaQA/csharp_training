using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Contacts.CreateIfNoContact();
            app.Groups.CreateIfNoGroups();

            GroupData group = GroupData.GetAll()[0];
            ContactData contact = ContactData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> contacts = ContactData.GetAll();

            if (oldList.Count == contacts.Count)
            {
                app.Contacts.Create(new ContactData("FirstName", "Lastname"));
                contact = ContactData.GetAll().FirstOrDefault(i => i.Id == ContactData.MaxContactId());
            }
            else
            {
                contact = ContactData.GetAll().Except(oldList).First();
            }

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
