using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/FotoFilesMgt")] 
    public class FotoFilesController : ApiController
    {
        FotoFilesRepo fotoFilesRepo = new FotoFilesRepo();

        // GET api/values
        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get([FromUri] FolderRequest request)
        {
            List<FotoFiles> folders = new List<FotoFiles>();
            IEnumerable<Table_foto_files> folderList = null;
            try
            {
                folderList = await fotoFilesRepo.GetAsync();
                foreach (var item in folderList)
                {
                    FotoFiles f = new FotoFiles();
                    f.id = item.id;
                    f.name = item.name;
                    f.description = item.description;
                    f.id_folder = item.id_folder;
                    folders.Add(f);
                }
            }
            catch (Exception ex)
            {
                //NLogger.Error(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { items = folders, totalItems = folderList.Count() });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("post")]
        public async Task<HttpResponseMessage> Post([FromBody]Table_foto_files folder)
        //public async Task<HttpResponseMessage> Post([FromBody]decimal id_folder, string description, string name)
        {
            Table_foto_files val = new Table_foto_files();
            try
            {
                var request = HttpContext.Current.Request;
                //if (request.Files.Count == 0) return Ok("selectFile");
                FoldersRepo foldersRepo = new FoldersRepo();
                Table_folders folder1 = await foldersRepo.FindByIdAsync(folder.id_folder);               

                string filename = Path.GetFileName(request.Files[0].FileName);
                
                var importDir = HostingEnvironment.MapPath("~/Foto/" + folder1.name + "/");
                var importPathFile = importDir + filename;

                if (!CheckExtensionLogoType(filename))
                {
                    //NLogger.Error("CheckExtensionLogoType", GetTraceInfo(new StackTrace().GetFrame(0).GetMethod().ToString()));
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, val);
                }

                if (!Directory.Exists(importDir))
                {
                    Directory.CreateDirectory(importDir);
                }
                else
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(importDir);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
                request.Files[0].SaveAs(importPathFile);

                val = await fotoFilesRepo.PostAsync(folder);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, val);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("put")]
        public async Task<HttpResponseMessage> Put([FromBody]Table_foto_files folder)
        {
            Table_foto_files val = new Table_foto_files();
            try
            {
                val = await fotoFilesRepo.PutAsync(folder);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, val);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete(Table_foto_files folder)
        {
            try
            {
                await fotoFilesRepo.DeleteAsync(folder.id.ToString());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public static bool CheckExtensionLogoType(string filename)
        {
            string[] extensionArray = new string[4] { ".gif", ".png", ".jpg", ".bmp" };
            string extension = Path.GetExtension(filename).ToLower();
            return extensionArray.Contains(extension);
        }
    }
}