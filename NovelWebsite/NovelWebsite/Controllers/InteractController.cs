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

        [Route("getfav/{bookId}")]
        public bool GetFav(int bookId)
        {
            var book = _dbContext.BookUserLikes.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (book == null)
            {
                return false;
            }
            return true;
        }

        [Route("getrec/{bookId}")]
        public bool GetRec(int bookId)
        {
            var book = _dbContext.BookUserRecommends.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (book == null)
            {
                return false;
            }
            return true;
        }

        [Route("getfollow/{bookId}")]
        public bool GetFollow(int bookId)
        {
            int id = GetUserId();
            var book = _dbContext.BookUserFollows.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (book == null)
            {
                return false;
            }
            return true;
        }

        [Route("updatefav/{bookId}")]

        public bool UpdateFav(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserLikes.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserLikes.Add(new BookUserLikeEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("updaterec/{bookId}")]

        public bool UpdateRec(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserRecommends.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserRecommends.Add(new BookUserRecommendEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserRecommends.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("updatefollow/{bookId}")]
        public bool UpdateFollow(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserFollows.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserFollows.Add(new BookUserFollowEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserFollows.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
