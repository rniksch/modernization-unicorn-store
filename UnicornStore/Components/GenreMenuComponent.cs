using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnicornStore.Models;

namespace UnicornStore.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        public GenreMenuComponent(UnicornStoreContext dbContext)
        {
            DbContext = dbContext;
        }

        private UnicornStoreContext DbContext { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO use nested sum https://github.com/aspnet/EntityFramework/issues/3792
            //.OrderByDescending(
            //    g => g.Albums.Sum(a => a.OrderDetails.Sum(od => od.Quantity)))
            
            var genres = await DbContext.Genres.Select(g => g.Name).Take(9).ToListAsync();

            return View(genres);
        }
    }
}