using MailKitExampleV6.MailLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MailKitExampleV6.Pages
{
    public class SendMailModel : PageModel
    {
        private readonly IMailSendLogic _mailSendLogic;

        public SendMailModel(IMailSendLogic mailSendLogic)
        {
            _mailSendLogic = mailSendLogic;
        }

        [BindProperty]
        public Models.SendMailModel? SendMail { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
            }

            if (SendMail==null)
            {
                return Page();
            }

            await _mailSendLogic.SendMailAsync(SendMail?.SendTo, SendMail.SendFrom, SendMail.Subject, SendMail.Text);
            return Page();
        }
    }
}
