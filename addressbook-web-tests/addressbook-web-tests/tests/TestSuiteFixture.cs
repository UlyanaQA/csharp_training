using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {

        [SetUp]
        public void IniApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        /*
        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }
        */
    }
}
