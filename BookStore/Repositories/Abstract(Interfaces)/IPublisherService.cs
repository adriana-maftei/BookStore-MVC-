using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract_Interfaces_
{
    public interface IPublisherService
    {
        bool Add(Publisher model);

        bool Update(Publisher model);

        bool Delete(int id);

        Publisher FindByID(int id);

        IEnumerable<Publisher> GetAll();
    }
}
