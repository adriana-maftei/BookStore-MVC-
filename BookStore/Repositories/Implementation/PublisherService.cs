using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;

namespace BookStore.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext databaseContext;

        public PublisherService(DatabaseContext _databaseContext)
        {
            this.databaseContext = _databaseContext;
        }

        public bool Add(Publisher model)
        {
            try
            {
                databaseContext.Publisher.Add(model);
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

                databaseContext.Publisher.Remove(data);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindByID(int id)
        {
            return databaseContext.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return databaseContext.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                databaseContext.Publisher.Update(model);
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