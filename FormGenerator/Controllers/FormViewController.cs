using FormGenerator.Model;
using FormGenerator.Models;
using System.Web;
using System.Web.Mvc;

namespace FormGenerator.Controllers
{
    public class FormViewController : Controller
    {
        [HttpPost]
        public ActionResult GenerateForm(RawFormModel rawForm)
        {
            if (rawForm == null)
            {
                return Content("Json is Null or Empty");
            }

            var decoded = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(rawForm.Json));
            var generated = Generator.CreateForm(decoded);
            return this.View("FormView", new FormModel { Html = generated });
        }
    }
}