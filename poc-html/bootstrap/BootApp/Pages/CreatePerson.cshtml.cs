using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BootApp.Code;

namespace BootApp.Pages
{
    public class CreatePersonPageModel : PageModel
    {
        private readonly BootApp.Code.BootAppDbContext _context;

        public CreatePersonPageModel(BootApp.Code.BootAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonVM Person { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persons.Add(new Person(Person.Name, Person.Age));
            await _context.SaveChangesAsync();

            // var emptyStudent = new PersonVM();
            //
            // if (await TryUpdateModelAsync<PersonVM>(
            //         emptyStudent,
            //         "student",   // Prefix for form value.
            //         s => s.Name, s => s.Age))
            // {
            //     _context.Persons.Add(Person);
            //     await _context.SaveChangesAsync();
            //     return RedirectToPage("./Index");
            // }

            return RedirectToPage("./Index");
        }
    }
}
