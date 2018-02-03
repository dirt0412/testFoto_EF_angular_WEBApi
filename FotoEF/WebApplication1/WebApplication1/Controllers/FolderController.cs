using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/FolderMgt")]
    public class FolderController : ApiController
    {
        FoldersRepo foldersRepo = new FoldersRepo();

        // GET api/values
        [HttpGet]
        [Route("get")]
        public async Task<HttpResponseMessage> Get([FromUri] FolderRequest request)
        {
            List<Folders> folders = new List<Folders>();
            IEnumerable<Table_folders> folderList = null;
            try
            {
                folderList = await foldersRepo.GetAsync();
                foreach (var item in folderList)
                {
                    Folders f = new Folders();
                    f.id = item.id;
                    f.name = item.name;
                    f.description = item.description;
                    f.icon = item.icon;
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
        public async Task<HttpResponseMessage> Post([FromBody]Table_folders folder)
        {
            //Table_folders folder
            Table_folders val = new Table_folders();
            try
            {
                val = await foldersRepo.PostAsync(folder);
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
        public async Task<HttpResponseMessage> Put([FromBody]Table_folders folder)
        {
            Table_folders val = new Table_folders();
            try
            {
                val = await foldersRepo.PutAsync(folder);
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
        public async Task<HttpResponseMessage> Delete(Table_folders folder)
        {
            try
            {
                await foldersRepo.DeleteAsync(folder.id.ToString());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
