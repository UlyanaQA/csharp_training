using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemovingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactToGroup()
        {
            app.Contacts.CreateIfNoContact();
            app.Groups.CreateIfNoGroups();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> listContactsInGroup = group.GetContacts();

            if (listContactsInGroup.Count == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                listContactsInGroup = group.GetContacts();
            }

            ContactData contactInGroup = listContactsInGroup[0];

            app.Contacts.RemoveContactFromGroup(contactInGroup, group);

            List<ContactData> newListContactsInGroup = group.GetContacts();
            listContactsInGroup.Add(contactInGroup);
            newListContactsInGroup.Sort();
            listContactsInGroup.Sort();

            Assert.That(newListContactsInGroup, Has.No.Member(contactInGroup));
        }
    }
}
