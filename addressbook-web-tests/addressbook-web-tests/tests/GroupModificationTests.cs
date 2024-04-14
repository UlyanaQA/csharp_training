using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CreateIfNoGroups();

            GroupData newData = new GroupData("eidt_name100");
            newData.Header = null;
            newData.Footer = "eidt_footer3";

            app.Groups.Modify(1, newData);
        }
    }
}
