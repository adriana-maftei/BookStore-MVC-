using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;

namespace BookStore.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext databaseContext;

        public AuthorService(DatabaseContext _databaseContext)
        {
            this.databaseContext = _databaseContext;
        }

        public bool Add(Author model)
        {
            try
            {
                databaseContext.Author.Add(model);
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

                databaseContext.Author.Remove(data);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindByID(int id)
        {
            return databaseContext.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return databaseContext.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                databaseContext.Author.Update(model);
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
