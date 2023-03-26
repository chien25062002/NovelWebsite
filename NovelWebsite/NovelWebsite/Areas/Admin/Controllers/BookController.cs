using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
                                        .Where(b => b.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Include(b => b.User)
                                        .Include(b => b.BookStatus)
                                        .ToList();
            return View(query);
        }
        
        public IActionResult AddOrUpdateBook(int bookId = 0)
        {
            if (bookId == 0)
            {
                return View();
            }
            var query = _dbContext.Books.Where(b => b.BookId == bookId && b.IsDeleted == false)
                                         .Include(b => b.Author)
                                         .Include(b => b.Category)
                                         .Include(b => b.User)
                                         .Include(b => b.BookStatus)
                                         .First();
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }

        [HttpPost]
        public IActionResult AddOrUpdateBook(BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Admin/Book/AddOrUpdateBook?id=" + bookModel.BookId);
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
                var book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookModel.BookId && b.IsDeleted == false);
                if (book.BookId == null)
                {
                    book = new BookEntity()
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
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    };
                    _dbContext.Books.Add(book);
                }
                else
                {
                    book.BookName = bookModel.BookName;
                    book.AuthorId = bookModel.AuthorId;
                    book.CategoryId = bookModel.CategoryId;
                    book.Avatar = bookModel.Avatar;
                    book.Introduce = bookModel.Introduce;
                    book.BookStatusId = bookModel.BookStatusId;
                    book.UpdatedDate = DateTime.Now;
                    _dbContext.Books.Update(book);
                }
            }
            _dbContext.SaveChanges();
            return AddOrUpdateBook(bookModel.BookId);
        }

        public IActionResult DeleteBook(int bookId)
        {
            var book = _dbContext.Books.First(x => x.BookId == bookId);
            book.IsDeleted = true;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Book/ListOfBooks");
        }
    }
}
