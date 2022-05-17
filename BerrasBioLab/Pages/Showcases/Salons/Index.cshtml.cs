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
    public class IndexModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public IndexModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        public IList<Salon> Salon { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Salon != null)
            {
                Salon = await _context.Salon.ToListAsync();
            }
        }
    }
}
