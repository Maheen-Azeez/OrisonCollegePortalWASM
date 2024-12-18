using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrisonCollegePortal.Client.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace OrisonCollegePortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public UploadController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        [HttpPost("[action]")]
        public async void Save(IList<IFormFile> UploadFiles)
        {  
            long size = 0;
            string path = "";
           // path = _generalServices.getBranchSettings("CollegeDocumentPath").Result;
            path= @"D:\Orison\OrisonPortal\HiraComputerSolutions\OrisonStudentModule\Documents";
           // path=@" D:\Orison\OrisonPortal\Hira Computer Solutions\OrisonCollegePortal\CollegeDocuments";


            // path = "http://185.140.248.101/"D:\Orison\OrisonPortal\OrisonCollegePortal\ColDocuments/";
            // path = $@"C:\Users\hp\source\repos\OrisonCollegePortal\OrisonCollegePortal\wwwroot\UploadedDocument";
            try
            {
                foreach (var file in UploadFiles)
                {
                    var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                    filename = Path.Combine(path, filename);
                    filename = $@"{filename}";
                    size += (int)file.Length; 
                    string t = file.ContentType;
                    if (filename.Contains(".PDF"))
                    { }
                    else if (filename.Contains(".pdf"))
                    { }
                    else if (filename.Contains(".docx"))
                    { }
                    else if (filename.Contains(".doc"))
                    { }

                    else if (filename.Contains(".txt"))
                    { }
                    else if (filename.Contains(".xml"))
                    { }
                    else if (filename.Contains(".jpg"))
                    { }
                    else if (filename.Contains(".xlsm"))
                    { }
                    else if (filename.Contains(".png"))
                    { }
                    else if (filename.Contains(".PNG"))
                    {
                        //filename = Path.ChangeExtension(filename, ".png");
                    }
                    else if (filename.Contains(".jpeg"))
                    { }
                    else if (filename.Contains(".xlsx"))
                    { }
                    else if (filename.Contains(".xls"))
                    { }
                    else
                    {
                        int pos = t.IndexOf("/");
                        if (pos >= 0)
                        {

                            // Remove everything before founder but include founder  
                            t = t.Remove(0, pos + 1);
                            t = "." + t;

                        }

                        //string t = file.ContentType;
                        bool d = filename.Contains(t);
                        if (d == false)
                        {
                            filename = filename + t;
                        }
                    }
                    try
                    {
                        if (!System.IO.File.Exists(filename))
                        {
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }



                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
        [HttpPost("[action]")]
        public async void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                string path = "";
                //   path =_generalServices.getBranchSettings("CollegeDocumentPath").Result;
                path = @"D:\Saranya\Upload\";


                //path = $@"C:\Users\hp\source\repos\OrisonCollegePortal\OrisonCollegePortal\wwwroot\UploadedDocument";

                var filename = Path.Combine(path, UploadFiles[0].FileName);
                filename = $@"{filename}";
                //var filename = $@"C:\Orison\OrisonResources\HRDocuments\{UploadFiles[0].FileName}";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}
