using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Journals
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; } = default!;


        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string? SearchType { get; set; }

        public string? SortByBook { get; set; }
        public string? SortByDate { get; set; }

        public async Task OnGetAsync(string SortOrder)
        {
            var journals = from j in _context.Journal
                         select j;
            SortByBook = String.IsNullOrEmpty(SortOrder) ? "Name" : "";
            SortByDate = SortOrder == "Date" ? "Name" : "Date";

            if (SortOrder == "Name")
            {
               journals = journals.OrderByDescending(s => s.BookName);
            }
            else if (SortOrder== "Date")
            {
                journals = journals.OrderBy(s => s.EntryDate);
  
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                if (SearchType == "Book")
                {
                    journals = journals.Where(s => s.BookName.Contains(SearchString));
                }
                else
                {
                    journals = journals.Where(s => s.Notes  .Contains(SearchString));
                }
                
            }
                
            Journal = await journals.ToListAsync();
        }

    }
}
