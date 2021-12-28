using System.Collections.Generic;
using System.Threading.Tasks;
using BootApp.Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BootApp.Pages
{
    public class ListPersonsModel : PageModel
    {
        public IList<Person> Persons { get; private set; }

        private readonly BootAppDbContext dbContext;

        public ListPersonsModel(BootAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Persons = await dbContext.Persons.ToListAsync();
        }
    }
}
