using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_mvc_sample.Controllers {
  public class SimpleController : Controller {

    // Hello, Worldを表示
    public IActionResult HelloWorld() {
      return Content("Hello, World");
    }

    // HelloWorldにリダイレクト
    public IActionResult RedirectToHello() {
      return RedirectToAction(nameof(HelloWorld));
    }

    // NotFoundを返す
    public IActionResult ReturnNotFound() {
      return NotFound();
    }
  }
}