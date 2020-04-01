using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

using Sleuth.Models;

namespace Sleuth
{
    class Program
    {
        static IWebDriver Driver;
        static string Username;
        static string Password;
        static string Browser;

        static Random rng = new Random();

        static string BasePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string SettingsPath = Path.Combine(BasePath, "Settings.json");
        static string SiteUrl = "https://gremlins-api.reddit.com/room?nightmode=1&platform=desktop";
        static string LoginSelector = ".AnimatedForm";
        static string AppXPath = "/html/body/gremlin-app";
        static string AnswerXPath = "/html/body/gremlin-app/gremlin-form/gremlin-room/gremlin-prompt/gremlin-note";
        static string ContinueXPath = "/html/body/gremlin-app/gremlin-prompt/gremlin-action[1]/a";

        static void Main(string[] args)
        {
            LoadSettings();
            LoadDriver();

            Driver.Url = SiteUrl;

            TryLogin:

            if (Driver.FindElement(By.CssSelector(LoginSelector)).Displayed)
            {
                var usernameInput = Driver.FindElement(By.CssSelector("input#loginUsername"));
                var passwordInput = Driver.FindElement(By.CssSelector("input#loginPassword"));
                var submitButton  = Driver.FindElement(By.CssSelector(".AnimatedForm__submitButton"));

                usernameInput.SendKeys(Username);
                passwordInput.SendKeys(Password);
                submitButton.Click();
            }
            else
            {
                goto TryLogin;
            }

            TryVote:

            try
            {
                var imposterApp = Driver.FindElement(By.XPath(AppXPath));
                var answers = Driver.FindElements(By.XPath(AnswerXPath));

                answers.First().Click();
                goto TryContinue;
            }
            catch
            {
                goto TryVote;
            }

            TryContinue:

            try
            {
                var continueLink = Driver.FindElement(By.XPath(ContinueXPath));
                continueLink.Click();
                goto TryVote;
            }
            catch
            {
                goto TryContinue;
            }
        }

        /// <summary>
        /// Attempts to load user settings file
        /// </summary>
        static void LoadSettings()
        {
            string settingsFile = @".\Settings.json";
            if (File.Exists(settingsFile))
            {
                string json = File.ReadAllText(settingsFile);
                var settings = new JavaScriptSerializer().Deserialize<Settings>(json);

                Username = settings.Username;
                Password = settings.Password;
                Browser = settings.Browser.ToLower();
            }
            else
            {
                Console.WriteLine("Settings file could not be found.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Initializes the web driver based on the user's settings, must be called after <see cref="LoadSettings">LoadSettings</see>.
        /// </summary>
        static void LoadDriver()
        {
            switch (Browser)
            {
                default:
                case "chrome":
                    Driver = new ChromeDriver(BasePath);
                    break;
                case "firefox":
                case "ff":
                    Driver = new FirefoxDriver(BasePath);
                    break;
                case "opera":
                    Driver = new OperaDriver(BasePath);
                    break;
            }
        }
    }
}
