using BookStore.Models.Domain;

namespace BookStore.Repositories.Abstract_Interfaces_
{
    public interface IGenreService
    {
        bool Add(Genre model);

        bool Update(Genre model);

        bool Delete(int id);

        Genre FindByID(int id);

        IEnumerable<Genre> GetAll();
    }
}