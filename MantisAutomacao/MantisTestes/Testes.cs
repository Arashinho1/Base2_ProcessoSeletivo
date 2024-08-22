using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MantisAutomacao
{
    public class MantisTestes
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br/");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Página Inicial Carregada");
        }

        [TearDown]
        public void Teardown()
        {  
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); 
            }
        }

        [Test, Order(1)]
        public void LoginTest()
        {
            Login();
        }

        [Test, Order(2)]
        public void CreateBugTest()
        {
            Login();
            
            var reportIssueLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='navbar-container']/div[2]/ul/li[1]/div/a")));
            reportIssueLink.Click();
            Thread.Sleep(1000);

            var categoryDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("category_id")));
            var categorySelect = new SelectElement(categoryDropdown);
            categorySelect.SelectByIndex(2);  
            Thread.Sleep(1000);

            var summaryField = driver.FindElement(By.Name("summary"));
            summaryField.SendKeys("Bug de teste criado automaticamente");
            Thread.Sleep(1000);

            var descriptionField = driver.FindElement(By.Name("description"));
            descriptionField.SendKeys("Esta é uma descrição do bug criado durante um teste automatizado.");
            Thread.Sleep(2000);

            var submitButton = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/form/div/div[2]/div[2]/input"));
            submitButton.Click();
            Thread.Sleep(1000);
        }

        [Test, Order(3)]
        public void ViewBugTest()
        {
            Login();
            
            // Navegar para "View Issues"
            var icons = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("menu-icon")));
            if (icons.Count > 2)
            {
                var iconToClick = icons[1];
                iconToClick.Click();
                Console.WriteLine("Ícone clicado com sucesso.");
            }
            else
            {
                Console.WriteLine("Ícone não encontrado.");
            }
            Thread.Sleep(1000);

            // Esperar a tabela de bugs carregar
            var bugsTable = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("column-id")));
            Thread.Sleep(1000);

            // Interagir com cada item da coluna "NUM"
            var bugLinks = bugsTable.FindElements(By.XPath("//table[@id='buglist']/tbody/tr/td[4]/a"));

            foreach (var bugLink in bugLinks)
            {
                try
                {
                string bugId = bugLink.Text;
                Console.WriteLine($"Verificando o bug com ID: {bugId}");

                // Clicar no link do bug
                bugLink.Click();

                // Verificar se a página de detalhes do bug foi carregada corretamente
                var bugSummary = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(@class,'bug-summary')]")));
                Assert.IsTrue(bugSummary.Displayed, $"Detalhes do bug {bugId} exibidos com sucesso.");
                Thread.Sleep(1000);

                // Voltar para a página de lista de bugs
                driver.Navigate().Back();
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("column-id")));
                Console.WriteLine($"Bug {bugId} verificado e retornado à lista de bugs.");
                Thread.Sleep(1000);
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine("Elemento obsoleto encontrado. Re-localizando elementos...");
                bugLinks = wait.Until(driver => driver.FindElements(By.XPath(".//tbody/tr/td[4]/a")));
            }
        }
     }   
        private void Login()
        {
            var usernameField = driver.FindElement(By.Name("username"));
            usernameField.SendKeys("Vitor_Santos");
            Thread.Sleep(1000);

            var loginButton = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[4]/div/div/div[1]/form/fieldset/input[2]"));
            loginButton.Click();
            Thread.Sleep(1000);

            var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            passwordField.SendKeys("@Vermelho123");
            Thread.Sleep(1000);

            loginButton = driver.FindElement(By.XPath("//*[@id='login-form']/fieldset/input[3]"));
            loginButton.Click();
            Thread.Sleep(1000);
        }
    }
}
