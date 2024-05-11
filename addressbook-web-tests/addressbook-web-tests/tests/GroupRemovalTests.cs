using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CreateIfNoGroups();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(app.Groups.GetGroupCount(), oldGroups.Count - 1);

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            
        }   
    }
}
