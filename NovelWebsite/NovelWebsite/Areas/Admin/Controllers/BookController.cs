using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ListOfBooks(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            int pageTotal = _dbContext.Books.Count();
            int pageCount = (int)Math.Ceiling(1.0 * pageTotal / pageSize);
            int skip = pageNumber * pageSize - pageSize;
            var query = _dbContext.Books.Where(b => string.IsNullOrEmpty(name) || b.BookName.ToLower().Contains(name.ToLower()))
                                        .Skip(skip)
                                        .Take(pageSize)
                                        .ToList();
            return View(query);
        }
        
        public IActionResult AddOrUpdateBook(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdateBook(BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {

            }
            else
            {
                AuthorEntity author = _dbContext.Authors.FirstOrDefault(a => a.AuthorName == bookModel.AuthorName);
                if (author == null)
                {
                    author = new AuthorEntity()
                    {
                        AuthorName = bookModel.AuthorName,
                    };
                    _dbContext.Authors.Add(author);
                }
                if (bookModel.BookId == 0)
                {
                    _dbContext.Books.Add(new BookEntity()
                    {
                        BookName = bookModel.BookName,
                        BookId = bookModel.BookId,
                        Category = _dbContext.Categories.Find(bookModel.CategoryId),
                        Author = author,
                        User = _dbContext.Users.Find(bookModel.UserId),
                        NumberOfChapters = 0,
                        Views = 0,
                        Likes = 0,
                        Recommends = 0,
                        Avatar = bookModel.Avatar,
                        Introduce = bookModel.Introduce,
                        BookStatusId = bookModel.BookStatusId,
                    });
                }
            }
            return AddOrUpdateBook(bookModel.BookId);
        }
    }
}
