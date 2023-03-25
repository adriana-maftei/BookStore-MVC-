using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract_Interfaces_
{
    public interface IAuthorService
    {
        bool Add(Author model);

        bool Update(Author model);

        bool Delete(int id);

        Author FindByID(int id);

        IEnumerable<Author> GetAll();
    }
}
