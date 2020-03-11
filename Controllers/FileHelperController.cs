using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileHelperController : ControllerBase
    {
        private List<string> myfiles = new List<string>();

        [HttpGet]
        [Route("getshitdone")]
        public ActionResult<List<string>> Get()
        {
            myfiles = GetFiles();
            return Ok(myfiles);
        }

        private List<string> GetFiles()
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var myDir = Directory.GetDirectories(docPath);
            try
            {

                // cboNames.Items.Add(docPath);

                foreach (var item in myDir)
                {
                    if (item != null)
                    {
                        myfiles.Add(item);
                    }

                }
            }
            catch (Exception)
            {
                throw;

            }

            return myfiles;
        }
    }
}