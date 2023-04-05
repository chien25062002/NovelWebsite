using Microsoft.AspNetCore.Authorization;
using NovelWebsite.Entities;

namespace NovelWebsite.Authorization
{
    public class CheckBookOwnerAuthorizationHandler : AuthorizationHandler<BookOwnerRequirement>
    {
        private readonly AppDbContext _dbContext;

        public CheckBookOwnerAuthorizationHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BookOwnerRequirement requirement)
        {
            string bookId = "";
            try
            {
                bookId = new HttpContextAccessor().HttpContext.Request.RouteValues["bookId"].ToString();
            }
            catch (Exception ex)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            var bookUserId = _dbContext.Books.Where(b => b.BookId == Int32.Parse(bookId)).First().UserId.ToString();
            var currentUserId = new HttpContextAccessor().HttpContext.Request.RouteValues["userId"].ToString();
            if (bookUserId == currentUserId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

    }
}
