using Dongnipp_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using top.nuozhen.Dongnipp;

namespace Dongnipp_ASP.Controllers
{
    public class DongniController : Controller
    {
        // 这是登录页面的GET方法
        public IActionResult Login()
        {
            return View();
        }

        // 这是登录页面的POST方法，它将在用户提交表单时被调用
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            // 在这里调用你的dongniSDK.login方法
            var (Token, userId, studentId, userNickName, accountName, errorInfo) = await dongniSDK.login(model.UserName, model.Password);

            // 检查登录是否成功
            if (errorInfo != null)
            {
                // 如果登录失败，将错误信息添加到ModelState中，并返回同一个View
                ModelState.AddModelError("Failed to login.", errorInfo);
                return View(model);
            }
            else
            {
                // 如果登录成功，将用户重定向到欢迎页面
                return RedirectToAction("Welcome");
            }
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
