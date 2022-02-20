using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPITestConsole.Controllers
{
    public class TestController : ApiController
    {
        // GET: Test
        public void Get(string id)
        {
            RunExecutable(id);
        }

        private void RunExecutable(string arguments) 
        {
            var fileName = HttpContext.Current.Server.MapPath("/content/WebAPIConsole.exe");

            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WorkingDirectory = HttpContext.Current.Server.MapPath("/content/");

            process.Start();
            process.WaitForExit();
        }


    }
}