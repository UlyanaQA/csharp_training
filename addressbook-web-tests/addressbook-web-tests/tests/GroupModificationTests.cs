using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CreateIfNoGroups();

            GroupData newData = new GroupData("eidt_name100");
            newData.Header = null;
            newData.Footer = "eidt_footer3";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(app.Groups.GetGroupCount(), oldGroups.Count);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
