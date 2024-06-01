using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseUrl;
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public LoginHelper Auth { get; set; }
        public ManagementMenuHelper Navigation { get; set; }
        public ProjectManagementHelper Project { get; set; }
        public AdminHelper Admin { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseUrl = "http://localhost/mantisbt-1.3.20";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Auth = new LoginHelper(this);
            Navigation = new ManagementMenuHelper(this, baseUrl);
            Project = new ProjectManagementHelper(this);
            Admin = new AdminHelper(this, baseUrl);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            API = new APIHelper(this);
        }

        /*
         * Деструктор: пока не работает из-за бага selenium
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        */

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseUrl + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value; 
        }

        public IWebDriver Driver
        {
            get { return driver; } 
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }  
    }
}
