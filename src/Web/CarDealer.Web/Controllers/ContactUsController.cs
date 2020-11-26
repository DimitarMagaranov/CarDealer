namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Services.Messaging;
    using CarDealer.Web.ViewModels.InputModels.ContactUs;
    using Microsoft.AspNetCore.Mvc;

    public class ContactUsController : BaseController
    {
        private readonly IEmailSender emailSender;

        public ContactUsController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ContactUsInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactUsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var email = input.Email;
            var name = input.Name;
            var subject = input.Subject;
            var content = input.Message;

            await this.emailSender.SendEmailAsync(email, name, "dimitar.magaranov1@gmail.com", subject, content, null);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
