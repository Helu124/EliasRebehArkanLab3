using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBioLab.Data;
using BerrasBioLab.Models;
using Microsoft.EntityFrameworkCore;

namespace BerrasBioLab.Pages.Customers.Orders
{
    public class CreateModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public CreateModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Showcase == null)
            {
                return NotFound();
            }

            var showcase = await _context.Showcase.FirstOrDefaultAsync(m => m.Id == id);
            if (showcase == null)
            {
                return NotFound();
            }
            Showcasezz = showcase;
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        [BindProperty]
        public Showcase Showcasezz { get; set; }
        public int Tickets { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customer == null || Customer == null)
            {
                return Page();
            }
            Tickets = Customer.NrOfTickets;

            var available = _context.Showcase.Where(x => x.Id == Showcasezz.Id).FirstOrDefault();

            if (Tickets <= available.AvailableSeats)
            {
                available.AvailableSeats -= Tickets;
            }
            else
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            _context.Showcase.Update(available);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Customer.Id });
        }
    }
}
