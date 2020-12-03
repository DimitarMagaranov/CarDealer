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
            var fullName = input.FullName;
            var subject = input.Subject;
            var message = input.Message;

            await this.emailSender.SendEmailAsync(email, fullName, "dimitar.magaranov1@gmail.com", subject, message, null);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
