using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.FrontPage
{
    public class EditModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public EditModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Showcase Showcase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Showcase == null)
            {
                return NotFound();
            }

            var showcase =  await _context.Showcase.FirstOrDefaultAsync(m => m.Id == id);
            if (showcase == null)
            {
                return NotFound();
            }
            Showcase = showcase;
           ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
           ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Showcase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowcaseExists(Showcase.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShowcaseExists(int id)
        {
          return (_context.Showcase?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
