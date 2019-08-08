using System.Web.Mvc;
using FormGenerator.Models;

namespace FormGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new RawFormModel { Json = "{\"form\":{\"name\":\"two\",\"items\":[{\"type\":\"filler\",\"message\":\"<h2>Резюме.</h2>\"},{\"type\":\"text\",\"name\":\"name\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"text\"},\"value\":\"\",\"label\":\"ФИО:\",\"class\":\"\",\"disabled\":false},{\"type\":\"text\",\"name\":\"tel\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"tel\"},\"value\":\"\",\"label\":\"Телефон:\",\"class\":\"\",\"disabled\":false},{\"type\":\"filler\",\"message\":\"<p>Ваш пол:</p>\",\"class\":\"\"},{\"type\":\"radio\",\"name\":\"radio\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"radio\"},\"disabled\":false,\"class\":\"\",\"items\":[{\"value\":\"1\",\"label\":\"Мужской\",\"checked\":false},{\"value\":\"2\",\"label\":\"Женский\",\"checked\":false}]},{\"type\":\"text\",\"name\":\"skills\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"text\"},\"value\":\"\",\"label\":\"Ваши навыки:\",\"class\":\"\",\"disabled\":false},{\"type\":\"text\",\"name\":\"past\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"text\"},\"value\":\"\",\"label\":\"Прошлые места работы:\",\"class\":\"\",\"disabled\":false},{\"type\":\"select\",\"name\":\"select\",\"placeholder\":\"\",\"required\":true,\"validationRules\":{\"type\":\"select\"},\"label\":\"На какую должность вы претендуете:\",\"class\":\"\",\"disabled\":false,\"options\":[{\"value\":\"\",\"text\":\"\",\"selected\":true},{\"value\":\"1\",\"text\":\"Директор\",\"selected\":false},{\"value\":\"2\",\"text\":\"Бухгалтер\",\"selected\":false},{\"value\":\"3\",\"text\":\"Программист\",\"selected\":false}]},{\"type\":\"button\",\"text\":\"Отправить\",\"class\":\"\"}],\"postmessage\":\"<p>Мы вам перезвоним))</p>\"}}" };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}