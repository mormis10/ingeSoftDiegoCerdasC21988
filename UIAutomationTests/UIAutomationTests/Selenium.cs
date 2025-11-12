using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
//Voy a implementar el T
using System.Threading;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            //Arrange
            var url = "http://localhost:8080";

            this._driver.Manage().Window.Maximize();

            //Act 
            //Vamos a navegar a la página que queramos probar
            this._driver.Navigate().GoToUrl(url);


            //Assert
            Assert.IsNotNull(this._driver);
        }

        // Apartir de aquí inicia el desarrollo de nuevos métodos para realizar una prueba más robusta cómo lo solicitó la profesora
        [Test]
        public void Create_New_Country_Succesfuly()
        {
            //Arrange
            //La dirección URL de donde está alojado nuestro lab
            var url = "http://localhost:8080";
            //Navegamos hacia la dirección
            this._driver.Navigate ().GoToUrl(url);

            //Vamos a añadir sleeps para que se vea más claro en el video
            Thread.Sleep(2000);

            //Esperamos que aparezca la página, y bucamos el botón de Agregar país
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var countryButton = wait.Until(d => d.FindElement(By.Id("add-country")));
            Thread.Sleep(2000);

            //Hacmeos un assert para garantizar que hayamos encontrado el botón y no sea nulo
            Assert.IsNotNull(countryButton, "El botón para añadir el nuevo país no se encontró");

            //ACT

            //Hacemos click para ir al formulario
            countryButton.Click();

            //Esperamos a que cargue y busacmos la etiqueta del form
            //la etiqueta del form tiene como id name
            wait.Until(d => d.FindElement(By.Id("name")));

            Thread.Sleep(2000);

            //Obtenemos los campos de formulario

            // El nombre del nuevo país
            var inputName = this._driver.FindElement(By.Id("name"));
            //Verificamos que hayamos encotrado la etiquta
            Assert.IsNotNull(inputName, "No se encontró el input para añadir el nombre del país");
            Thread.Sleep(2000);

            var continentSelect = this._driver.FindElement(By.Id("continente"));
            Assert.IsNotNull(continentSelect, "No se encontró el input para añadir el continente del país");
            Thread.Sleep(2000);

            var languageInput = _driver.FindElement(By.Id("idioma"));
            Assert.IsNotNull(continentSelect, "No se encontró el input para añadir el ideoma del país");
            Thread.Sleep(2000);
            //Rellenamos los inputs
            inputName.SendKeys("Konoha");
            Thread.Sleep(2000);

            new SelectElement(continentSelect).SelectByText("Asia");
            Thread.Sleep(2000);

            languageInput.SendKeys("Japonés");
            Thread.Sleep(2000);

            //Confirmamos que los valores ingresados sean los esperados
            Assert.AreEqual("Konoha", inputName.GetAttribute("value"));
            Assert.AreEqual("Asia", new SelectElement(continentSelect).SelectedOption.Text);
            Assert.AreEqual("Japonés", languageInput.GetAttribute("value"));


            // Enviamos el formulario
            // buscamos el botón de submit

            var saveButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            Thread.Sleep(2000);
            //Nos aseguramos de haberlo encontrado
            Assert.IsNotNull(saveButton, "No se encontró el botón de guardado");

            saveButton.Click();
            Thread.Sleep(2000);

            //Finalmente validamos que se haya rederigido correctamente
            // Esperamos a que nos lleve al root
            wait.Until(d => d.Url.Contains("/"));
           Thread.Sleep(2000);

            Assert.IsTrue(_driver.Url.Contains("/"), "No se redirigió correctamente tras guardar el país.");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
