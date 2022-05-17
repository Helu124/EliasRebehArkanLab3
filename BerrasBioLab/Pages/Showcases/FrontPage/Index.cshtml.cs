using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Data;
using BerrasBioLab.Models;

namespace BerrasBioLab.Pages.Showcases.FrontPage
{
    public class IndexModel : PageModel
    {
        private readonly BerrasBioLab.Data.BerrasBioLabContext _context;

        public IndexModel(BerrasBioLab.Data.BerrasBioLabContext context)
        {
            _context = context;
        }

        public IList<Showcase> Showcase { get;set; } = default!;

        public Showcase Showcasezz { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Showcase != null)
            {
                Showcase = await _context.Showcase
                .Include(s => s.Movie)
                .Include(s => s.Salon).ToListAsync();
            }
        }
    }
}
