using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.AdminPages
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
        ViewData["SalonId"] = new SelectList(_context.Set<Salon>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Showcase Showcasezz { get; set; } = default!;
        public Salon Salons { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Showcase == null || Showcasezz == null)
            {
                return Page();
            }
            
            var seats = _context.Salon.Where(x => x.Id == Showcasezz.SalonId).FirstOrDefault();

            _context.Showcase.Add(Showcasezz);
            await _context.SaveChangesAsync();

            Showcasezz.AvailableSeats = seats.NrOfSeats;

            _context.Showcase.Update(Showcasezz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
