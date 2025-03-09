using Microsoft.AspNetCore.Mvc;
using ResumeSample.Core.Services.Interfaces;
using ResumeSample.Domain.Models.Auth;

namespace ResumeSample.Controllers
{
    public class UserController : Controller
    {

        private IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("ShowUser")]
        public IActionResult ShowUser()
        {
            List<User> users = userService.GetAllUsers();
            return View(users);
        }

        [HttpGet("CreateUser")]
        //be darkhast haye get karbar pasokh midahad
        public IActionResult CreateUser()
        {
            
            return View(new User());
        }

        [HttpPost("CreateUser")]
        //be darkhast haye post karbar pasokh midahad
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);
                return RedirectToAction("ShowUser");
            }
            else
            {

                return View(user);
            }

        }

    }
}
