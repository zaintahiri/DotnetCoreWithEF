using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotnetCoreWithEF.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IConfiguration _configuration;
        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;          
        //}

        // how to read values from configuration using IOption class, this will map the values to NewBookAlertConfig object
        private readonly NewBookAlertConfig _newBookAlertConfiguration;
        private readonly IMessageRepository _messageRepository;
        public HomeController(IOptions<NewBookAlertConfig> newBookAlertConfiguration,IMessageRepository messageRepository)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
            _messageRepository = messageRepository;
        }


        //[Route("Home")]
        //[Route("/")]
        public ActionResult Index()
        {
            // Content comes from the Controller class
            //return Content("<h1>Welcome to ASP .NET CORE</h1", "text/html");

            //return new ContentResult() { 
            //    Content="<h1>Welcome to Asp.net core MVC</h1>",
            //    ContentType="text/html"
            //};

            //var newBookAler = new NewBookAlertConfig();
            //_configuration.Bind("NewBookAlert", newBookAler);

            //bool isDisplay = newBookAler.DisplayNewBookAlert;

            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;
            var bookName = _messageRepository.GetName();
            return View();

        }

        public string Error()
        {
            return "this is error here";
        }


        [Route("About")]
        public ActionResult About()
        {
            return View();
        }


        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }



        [Route("Product/{id:int:min(100):max(9999)}")]
        public string Product()
        {
            return "Hi, You are in Product page";
        }

        [Route("Employee")]
        public ContentResult Employee()
        {
            return Content("{\"name\":\"Zain ul abdin\"}", "text/html");

        }

        //return proper json we have return type JsonResult
        [Route("EmployeeData")]
        public JsonResult EmployeeTwo()
        {
            return Json(
               new EmployeeModel()
               {
                   EmpId = 101,
                   EmpName = "zain ul abdin",
                   Age = 36,
                   Salary = 360000

               });
            //dynamic model
            //return new JsonResult(
            //    new Employee()
            //    {
            //        EmpId = 101,
            //        EmpName = "zain ul abdin",
            //        Age = 36,
            //        Salary = 360000

            //    });
            //return new JsonResult(new { Id="101",Name="zain ul abdin",age="36",salary="350000"});        
        }

    }
}
