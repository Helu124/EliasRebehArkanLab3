using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.AdminPages
{
    public class DetailsModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public DetailsModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

      public Showcase Showcase { get; set; } = default!; 

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
            else 
            {
                Showcase = showcase;
            }
            return Page();
        }
    }
}
