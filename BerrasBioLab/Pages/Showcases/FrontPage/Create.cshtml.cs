using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.FrontPage
{
    public class CreateModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public CreateModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
        ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Showcase Showcase { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Showcase == null || Showcase == null)
            {
                return Page();
            }

            _context.Showcase.Add(Showcase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
