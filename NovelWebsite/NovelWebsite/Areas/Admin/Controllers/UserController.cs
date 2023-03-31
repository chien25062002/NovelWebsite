﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // isDeleted = true: xoá tk, Status = 0: đang hoạt động, Status = 1: bị ban

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var listUser = _dbContext.Accounts.Where(x => x.Status == 0 && x.IsDeleted == false)
                                              .Include(x => x.User).ThenInclude(x => x.Role)
                                              .OrderByDescending(a => a.CreatedDate);

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(listUser.Count() * 1.0 / pageSize);

            ViewBag.Role = new SelectList(_dbContext.Roles.ToList(), "RoleId", "RoleName");
            return View(listUser.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        public IActionResult AddOrUpdateUser(string account)
        {
            var user = _dbContext.Accounts.Where(x => x.AccountName == account).Include(p => p.User).ThenInclude(p => p.Role).FirstOrDefault();
            if (user != null)
            {
                return Json(new UserModel()
                {
                    AccountName = account,
                    UserId = user.UserId,
                    Username = user.User.UserName,
                    Avatar = user.User.Avatar,
                    CoverPhoto = user.User.CoverPhoto,
                    Email = user.User.Email,
                    Role = user.User.Role.RoleName
                });
            }
            return Json("");
        }

        public IActionResult BanUser(string account)
        {
            var user = _dbContext.Accounts.Where(x => x.AccountName == account).Include(p => p.User).ThenInclude(p => p.Role).FirstOrDefault();
            if (user != null)
            {
                user.Status = 1;
                user.User.Status = 1;
                _dbContext.Accounts.Update(user);
                _dbContext.SaveChanges();
            }
            return Json("");
        }

        public IActionResult UpdateRole(int userId, int roleId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if (user != null)
            {
                user.RoleId = roleId;
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            }
            return Json("");
        }
    }
}
