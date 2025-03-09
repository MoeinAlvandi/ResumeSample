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
        public IActionResult ShowUser(string SuccessMessage,string DangerMessage)
        {
            if(!string.IsNullOrEmpty(SuccessMessage))
                ViewBag.SuccessMessage = SuccessMessage;

            if (!string.IsNullOrEmpty(DangerMessage))
                ViewBag.DangerMessage = DangerMessage;

            List<User> users = userService.GetAllUsers();
            return View(users);
        }

        #region CreateUser
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
        #endregion


        #region EditUser

        [HttpGet("EditUser/{Id}")]
        public IActionResult EditUser(int Id)
        {
            if (Id > 0)
            {
                if (userService.IsExist(Id))
                {
                    User user = userService.GetUserByID(Id);
                    return View(user);
                }
                else
                {
                    //peyda nashod
                    return RedirectToAction("ShowUser");
                }
            }
            else
            {
                //peyda nashod
                return RedirectToAction("ShowUser");
            }
        }


        [Route("EditUser")]
        [Route("EditUser/{Id}")]
        [HttpPost]
        public IActionResult EditUser(User model)//carbar frestade
        {
            if (ModelState.IsValid)
            {

                User user=userService.GetUserByID(model.Id);//data base oomade

                if (user != null)
                {
                    bool isChnage= false;
                    if(!user.Fullname.Equals(model.Fullname))
                    {
                        user.Fullname = model.Fullname;
                        isChnage=true;
                    }
                    if (!user.Password.Equals(model.Password))
                    {
                        user.Password = model.Password;
                        isChnage=true;
                    }


                    if(isChnage)
                    {
                        userService.UpdateUser(user);
                        return RedirectToAction("ShowUser", "User", new { SuccessMessage = "Your User Changed SuccessFully" });

                    }
                    else
                    {
                        return RedirectToAction("ShowUser", "User", new { DangerMessage = "Your User Not Changed" });

                    }


                }
                else
                {
                    //user not found
                    return RedirectToAction("ShowUser");

                }
                
            }
            else
            {

                return View(model);
            }
            
        }

        #endregion


        #region Delete User
        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    User user = userService.GetUserByID(id);
                    if (user != null)
                    {

                        userService.DeleteUser(user);

                        return Ok("Deleted SuccessFully");//200

                    }
                    else
                    {
                        return BadRequest("User Not Found");

                    }

                }
                else
                {
                    return BadRequest("User Not Found");
                }


            }
            catch (Exception ex)
            {

                return BadRequest("error : "+ex.ToString());//400
            }

        }

        #endregion
    }
}
