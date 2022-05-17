using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Salons
{
    public class DetailsModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public DetailsModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

      public Salon Salon { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Salon == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon.FirstOrDefaultAsync(m => m.Id == id);
            if (salon == null)
            {
                return NotFound();
            }
            else 
            {
                Salon = salon;
            }
            return Page();
        }
    }
}
