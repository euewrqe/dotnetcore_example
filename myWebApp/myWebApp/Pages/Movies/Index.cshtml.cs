using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myWebApp.Data;
using myWebApp.Models;


// add search
namespace myWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly myWebApp.Data.myWebAppContext _context;

        public IndexModel(myWebApp.Data.myWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            // create a LINQ query to select the movies
            var movies = from m in _context.Movie
                         select m;
            movies.Count();

            if (!string.IsNullOrEmpty(SearchString))
            {
                // search out contained the "searchString" from all of the title of movies
                movies = movies.Where(s => s.Title.Contains(SearchString));
                movies.Count();
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
