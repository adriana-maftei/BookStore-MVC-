using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;

namespace BookStore.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext databaseContext;

        public BookService(DatabaseContext _databaseContext)
        {
            this.databaseContext = _databaseContext;
        }

        public bool Add(Book model)
        {
            try
            {
                databaseContext.Book.Add(model);
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

                databaseContext.Book.Remove(data);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindByID(int id)
        {
            return databaseContext.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in databaseContext.Book
                        join author in databaseContext.Author
                        on book.AuthorID equals author.ID
                        join publisher in databaseContext.Publisher on book.PublisherID equals publisher.ID
                        join genre in databaseContext.Genre on book.GenreID equals genre.ID
                        select new Book
                        {
                            ID = book.ID,
                            AuthorID = book.AuthorID,
                            GenreID = book.GenreID,
                            PublisherID = book.PublisherID,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName,
                            ISBN = book.ISBN,
                            Title = book.Title,
                            Pages = book.Pages
                        }).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                databaseContext.Book.Update(model);
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
