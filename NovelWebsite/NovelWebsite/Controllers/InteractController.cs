using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/interact")]
    public class InteractController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public InteractController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/getuserid")]
        public int GetUserId()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return Int32.Parse(claims.FindFirst("UserId").Value);
        }

        [Route("/updatefav")]

        public bool UpdateFav(int bookId, bool fav)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            if (fav)
            {
                book.Likes ++;
            }
            else
            {
                book.Likes --;
            }
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return true;
        }

        [Route("/updaterec")]

        public bool UpdateRec(int bookId, bool rec)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            if (rec)
            {
                book.Recommends++;
            }
            else
            {
                book.Recommends--;
            }
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return true;
        }

        [Route("/updatefollow")]
        public bool UpdateFollow(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUsers.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUsers.Add(new BookUserEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUsers.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
