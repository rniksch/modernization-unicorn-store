using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnicornStore.Models
{
    public static class SampleData
    {
        const string imgUrl = "~/Images/placeholder.png";
        const string defaultAdminUserName = "DefaultAdminUserName";
        const string defaultAdminPassword = "DefaultAdminPassword";

        public static async Task InitializeUnicornStoreDatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<UnicornStoreContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestData(scopeServiceProvider);
                    if (createUsers)
                    {
                        await CreateAdminUser(scopeServiceProvider);
                    }
                }
            }
        }

        private static async Task InsertTestData(IServiceProvider serviceProvider)
        {
            var albums = GetAlbums(imgUrl, Genres, Artists);

            await AddOrUpdateAsync(serviceProvider, g => g.GenreId, Genres.Select(genre => genre.Value));
            await AddOrUpdateAsync(serviceProvider, a => a.ArtistId, Artists.Select(artist => artist.Value));
            await AddOrUpdateAsync(serviceProvider, a => a.AlbumId, albums);
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<UnicornStoreContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<UnicornStoreContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Creates a store manager user who can manage the inventory.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            var env = serviceProvider.GetService<IHostingEnvironment>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            //const string adminRole = "Administrator";

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            // TODO: Identity SQL does not support roles yet
            //var roleManager = serviceProvider.GetService<ApplicationRoleManager>();
            //if (!await roleManager.RoleExistsAsync(adminRole))
            //{
            //    await roleManager.CreateAsync(new IdentityRole(adminRole));
            //}

            var user = await userManager.FindByNameAsync(configuration[defaultAdminUserName]);
            if (user == null)
            {
                user = new ApplicationUser { UserName = configuration[defaultAdminUserName] };
                await userManager.CreateAsync(user, configuration[defaultAdminPassword]);
                //await userManager.AddToRoleAsync(user, adminRole);
                await userManager.AddClaimAsync(user, new Claim("ManageStore", "Allowed"));
            }

            // NOTE: For end to end testing only
            var envPerfLab = configuration["PERF_LAB"];
            if (envPerfLab == "true")
            {
                for (int i = 0; i < 100; ++i)
                {
                    var email = string.Format("User{0:D3}@example.com", i);
                    var normalUser = await userManager.FindByEmailAsync(email);
                    if (normalUser == null)
                    {
                        await userManager.CreateAsync(new ApplicationUser { UserName = email, Email = email }, "Password~!1");
                    }
                }
            }
        }

        private static Album[] GetAlbums(string imgUrl, Dictionary<string, Genre> genres, Dictionary<string, Artist> artists)
        {
            var albums = new Album[]
            {
                new Album { Title = "The fiery one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Adiana"], AlbumArtUrl = imgUrl },
                new Album { Title = "The cheerful one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Alairia"], AlbumArtUrl = imgUrl },
                new Album { Title = "Fair and Beautiful", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Alanala"], AlbumArtUrl = imgUrl },
                new Album { Title = "Fair of face", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Albany"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Truthful one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Aletha"], AlbumArtUrl = imgUrl },
                new Album { Title = "One who charms", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Alize"], AlbumArtUrl = imgUrl },
                new Album { Title = "Peaceful and Attractive", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Allena"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Powerful one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Amandaria"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Eternal one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Amara"], AlbumArtUrl = imgUrl },
                new Album { Title = "Strong and Courageous", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Andra"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Angelic one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Angelina"], AlbumArtUrl = imgUrl },
                new Album { Title = "Full of Grace", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Annamika"], AlbumArtUrl = imgUrl },
                new Album { Title = "Bright as a Star", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Astra"], AlbumArtUrl = imgUrl },
                new Album { Title = "Little blessed one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Bennettia"], AlbumArtUrl = imgUrl },
                new Album { Title = "Simply beautiful", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Bellini"], AlbumArtUrl = imgUrl },
                new Album { Title = "One who is blessed", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Benicia"], AlbumArtUrl = imgUrl },
                new Album { Title = "White power", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Biancha"], AlbumArtUrl = imgUrl },
                new Album { Title = "Perfect joy", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Blissia"], AlbumArtUrl = imgUrl },
                new Album { Title = "Swift and strong", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Boaz"], AlbumArtUrl = imgUrl },
                new Album { Title = "The pretty one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Bonita"], AlbumArtUrl = imgUrl },
                new Album { Title = "Pure and Virtuous", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Breanna"], AlbumArtUrl = imgUrl },
                new Album { Title = "The strong one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Bryanne"], AlbumArtUrl = imgUrl },
                new Album { Title = "From the moon", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Celina"], AlbumArtUrl = imgUrl },
                new Album { Title = "From the stars", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Celestia"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Gentle one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Clementine"], AlbumArtUrl = imgUrl },
                new Album { Title = "The bold one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Cortesia"], AlbumArtUrl = imgUrl },
                new Album { Title = "Morning Star", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Danika"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Noble one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Della"], AlbumArtUrl = imgUrl },
                new Album { Title = "Lover of the Earth", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Demetrius"], AlbumArtUrl = imgUrl },
                new Album { Title = "The great one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Denali"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Roamer", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Dessa"], AlbumArtUrl = imgUrl },
                new Album { Title = "Celestial Spirit", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Deva"], AlbumArtUrl = imgUrl },
                new Album { Title = "Child of the sun", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Drisana"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Sweet one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Dulcea"], AlbumArtUrl = imgUrl },
                new Album { Title = "Divine Spirit", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Duscha"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Shining one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Electra"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Chosen One", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Elita"], AlbumArtUrl = imgUrl },
                new Album { Title = "Full of determination", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Etana"], AlbumArtUrl = imgUrl },
                new Album { Title = "Eternal friend", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Eternia"], AlbumArtUrl = imgUrl },
                new Album { Title = "Always tranquil", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Evania"], AlbumArtUrl = imgUrl },
                new Album { Title = "To be trusted", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Faith"], AlbumArtUrl = imgUrl },
                new Album { Title = "Happiness always", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Felicia"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Fair One", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Fenella"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Daring One", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Fernaco"], AlbumArtUrl = imgUrl },
                new Album { Title = "Little Star", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Estrellita"], AlbumArtUrl = imgUrl },
                new Album { Title = "The Swift one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Fleta"], AlbumArtUrl = imgUrl },
                new Album { Title = "Prosperous", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Floriana"], AlbumArtUrl = imgUrl },
                new Album { Title = "The protective one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Gerda"], AlbumArtUrl = imgUrl },
                new Album { Title = "Forever young", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Giulio"], AlbumArtUrl = imgUrl },
                new Album { Title = "The graceful one", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Gratiana"], AlbumArtUrl = imgUrl },
                new Album { Title = "Brown Eyed Buttons", Genre = genres["Bright Pegasi"], Price = 8.99M, Artist = artists["Yana"], AlbumArtUrl = imgUrl }
            };

            foreach (var album in albums)
            {
                album.ArtistId = album.Artist.ArtistId;
                album.GenreId = album.Genre.GenreId;
            }

            return albums;
        }

        private static Dictionary<string, Artist> artists;
        public static Dictionary<string, Artist> Artists
        {
            get
            {
                if (artists == null)
                {
                    var artistsList = new Artist[]
                    {
                        new Artist { Name = "Adiana" },
                        new Artist { Name = "Alairia" },
                        new Artist { Name = "Alanala" },
                        new Artist { Name = "Albany" },
                        new Artist { Name = "Aletha" },
                        new Artist { Name = "Alize" },
                        new Artist { Name = "Allena" },
                        new Artist { Name = "Amandaria" },
                        new Artist { Name = "Amara" },
                        new Artist { Name = "Andra" },
                        new Artist { Name = "Angelina" },
                        new Artist { Name = "Annamika" },
                        new Artist { Name = "Astra" },
                        new Artist { Name = "Bennettia" },
                        new Artist { Name = "Bellini" },
                        new Artist { Name = "Benicia" },
                        new Artist { Name = "Biancha" },
                        new Artist { Name = "Blissia" },
                        new Artist { Name = "Boaz" },
                        new Artist { Name = "Bonita" },
                        new Artist { Name = "Breanna" },
                        new Artist { Name = "Bryanne" },
                        new Artist { Name = "Celina" },
                        new Artist { Name = "Celestia" },
                        new Artist { Name = "Clementine" },
                        new Artist { Name = "Cortesia" },
                        new Artist { Name = "Danika" },
                        new Artist { Name = "Della" },
                        new Artist { Name = "Demetrius" },
                        new Artist { Name = "Denali" },
                        new Artist { Name = "Dessa" },
                        new Artist { Name = "Deva" },
                        new Artist { Name = "Drisana" },
                        new Artist { Name = "Dulcea" },
                        new Artist { Name = "Duscha" },
                        new Artist { Name = "Electra" },
                        new Artist { Name = "Elita" },
                        new Artist { Name = "Etana" },
                        new Artist { Name = "Eternia" },
                        new Artist { Name = "Evania" },
                        new Artist { Name = "Faith" },
                        new Artist { Name = "Felicia" },
                        new Artist { Name = "Fenella" },
                        new Artist { Name = "Fernaco" },
                        new Artist { Name = "Estrellita" },
                        new Artist { Name = "Fleta" },
                        new Artist { Name = "Floriana" },
                        new Artist { Name = "Gerda" },
                        new Artist { Name = "Giulio" },
                        new Artist { Name = "Gratiana"},
                        new Artist { Name = "Yana" }
                    };

                    artists = new Dictionary<string, Artist>();
                    foreach (Artist artist in artistsList)
                    {
                        artists.Add(artist.Name, artist);
                    }
                }

                return artists;
            }
        }

        private static Dictionary<string, Genre> genres;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    var genresList = new Genre[]
                    {
                        new Genre { Name = "Bright Pegasi" },
                        new Genre { Name = "Ruvas" },
                        new Genre { Name = "MagiCorns" },
                        new Genre { Name = "Rainbow Unicorns" },
                        new Genre { Name = "Dark Wings" }
                    };

                    genres = new Dictionary<string, Genre>();

                    foreach (Genre genre in genresList)
                    {
                        genres.Add(genre.Name, genre);
                    }
                }

                return genres;
            }
        }
    }
}
