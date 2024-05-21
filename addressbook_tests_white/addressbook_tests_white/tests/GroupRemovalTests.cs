using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            app.Groups.CreateIfNoGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
