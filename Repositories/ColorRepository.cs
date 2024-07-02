using DessertsApp.Data;
using DessertsApp.Models;

namespace DessertsApp.Repositories
{
    public class ColorRepository : BaseRepository<Color>
    {
        public ColorRepository(ApplicationDbContext db):base(db) 
        { 
        
        }
    }
}
