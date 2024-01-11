using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Pages.NewFolder;

namespace MyStore.Pages.Clients
{
    public class CreateModel : PageModel
    { 
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
    public void OnPost()
    {
        clientInfo.name = Request.Form["name"];
        clientInfo.name = Request.Form["email"];
        clientInfo.name = Request.Form["phone_number"];
        clientInfo.name = Request.Form["address"];

            if(clientInfo.name.Length ==0 || clientInfo.email.Length==0|| clientInfo.phone_number.Length==0 || clientInfo.address.Length==0)
            { errorMessage = "All fields are required";
                return;
            }

            clientInfo.name = ""; clientInfo.email = ""; clientInfo.phone_number = ""; clientInfo.address = "";
            successMessage = "New Client added successfully";
    } //saving the new Client into the database
    }
}
