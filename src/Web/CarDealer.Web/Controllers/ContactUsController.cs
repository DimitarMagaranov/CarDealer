namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Common;
    using CarDealer.Services.Messaging;
    using CarDealer.Web.ViewModels.ContactUs;
    using CarDealer.Web.ViewModels.InputModels.ContactUs;

    using Microsoft.AspNetCore.Mvc;

    public class ContactUsController : BaseController
    {
        private readonly IEmailSender emailSender;

        public ContactUsController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var viewModel = new ContactUsViewModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactUsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.emailSender.SendEmailAsync(input.Email, input.FullName, GlobalConstants.AdministratorEmailAddress, input.Subject, input.Message, null);

            return this.Redirect("/");
        }
    }
}
