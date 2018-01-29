using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwaWalletWeb_AspNetCore.Controllers
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller
    /// Every public method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string. Note the comments preceding each method.8
    /// An HTTP endpoint is a targetable URL in the web application, such as http://localhost:1234/HelloWorld, and combines the protocol used: HTTP, the network location of the web server (including the TCP port): localhost:1234 and the target URI HelloWorld.
    /// The first comment states this is an HTTP GET method that's invoked by appending "/HelloWorld/" to the base URL. The second comment specifies an HTTP GET method that's invoked by appending "/HelloWorld/Welcome/" to the URL.Later on in the tutorial you'll use the scaffolding engine to generate HTTP POST methods.
    /// </summary>
    public class HelloWorldController : Controller
    {
        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        /// <summary>
        /// http://localhost:xxxx/HelloWorld/Welcome?name=Rick&numtimes=4
        /// In the image above, the URL segment (Parameters) isn't used, the name and numTimes parameters are passed 
        /// as query strings. The ? (question mark) in the above URL is a separator, and the query strings follow. 
        /// The & character separates query strings.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numTimes"></param>
        /// <returns></returns>
        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        public string Welcome2(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        /// <summary>
        /// http://localhost:xxx/HelloWorld/Welcome/3?name=Rick
        /// This time the third URL segment matched the route parameter id. 
        /// The Welcome method contains a parameter id that matched the URL template in the MapRoute method. 
        /// The trailing ? (in id?) indicates the id parameter is optional.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// GET: /HelloWorld/Welcome/ 
        public string Welcome3(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
