using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromDetails.AllDetails, fromForm.AllDetails);
        }
    }
}
