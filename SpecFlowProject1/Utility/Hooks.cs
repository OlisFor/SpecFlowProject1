using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Gherkin.Ast;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1.Utility
{
    [Binding]
    public sealed class Hooks
    {
        public static IWebDriver driver;

        //Implementing Extent Report
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, test;

        static string reportpath = Directory.GetParent(@"../../../").FullName

            + Path.DirectorySeparatorChar + "Results"
            + Path.DirectorySeparatorChar + "ExtentReport" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        private ExtentTest step;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Driver initialization
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            CreateExtentReport();
           
        }

        [BeforeFeature]

        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public  void BeforeTest()
        {
            step = scenario;
        }

        [AfterStep]
        public  void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                string screenshot = GetScreenShot();
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build);
            }
        }


        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
            driver.Dispose();
        }
        public static void CreateExtentReport()
        {
            //Extent report Generation
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);
            extent.AddSystemInfo("Environment", "UAT");
            extent.AddSystemInfo("os", Environment.OSVersion.VersionString);

            htmlreport.Config.DocumentTitle = "Automation Training";
            htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlreport.Config.ReportName = "Regression Testing";
        }

        public void GetScreenShot()
        {
            return ((ITakesScreenshot)driver).GetScreenShot().AsBase64EncodedString;
        }

    }
}