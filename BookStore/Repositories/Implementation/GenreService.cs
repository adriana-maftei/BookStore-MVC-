using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;

namespace BookStore.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext databaseContext;

        public GenreService(DatabaseContext _databaseContext)
        {
            this.databaseContext = _databaseContext;
        }

        public bool Add(Genre model)
        {
            try
            {
                databaseContext.Genre.Add(model);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindByID(id);
                if (data == null) return false;

                databaseContext.Genre.Remove(data);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindByID(int id)
        {
            return databaseContext.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return databaseContext.Genre.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                databaseContext.Genre.Update(model);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}