using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class FoldersRepo : IRepository<Table_folders, string>
    {
       
        protected DbContext AppContext { get; private set; }
        private fotoEntities entitiesDB = new fotoEntities();

        public FoldersRepo()
        {

        }

        public async Task<Table_folders> GetAsync(decimal id)
        {
            return await Task.Run(delegate ()
            {
                return entitiesDB.Table_folders.FindAsync(id);
            });            
        }

        public async Task<IList<Table_folders>> GetAsync()
        {
            return await Task.Run<IList<Table_folders>>(delegate ()
            {
                return entitiesDB.Table_folders.ToList();
            });            
        }

        public async Task<Table_folders> PostAsync(Table_folders folder)
        {
            return await Task.Run(delegate ()
            {
                Table_folders obj = entitiesDB.Table_folders.Add(folder);
                entitiesDB.SaveChanges();

                var importDir = HostingEnvironment.MapPath("~/Foto/" + folder.name + "/");
                if (!Directory.Exists(importDir))
                {
                    Directory.CreateDirectory(importDir);
                }

                return obj;
            });
        }

        public async Task<Table_folders> PutAsync(Table_folders folder)
        {
            //Table_folders folderOld = await entitiesDB.Table_folders.FindAsync(folder);
            return await Task.Run(delegate ()
            {
                Table_folders obj = entitiesDB.Table_folders.Attach(folder);
                entitiesDB.Entry(folder).State = EntityState.Modified;
                entitiesDB.SaveChanges();

                //var importDir = HostingEnvironment.MapPath("~/Foto/" + folder.name + "/");
                //if (Directory.Exists(importDir))
                //{
                //    Directory.Move(importDir, importDir);
                //}
                
                return obj;
            });
        }

        public async Task DeleteAsync(string id)
        {
            decimal temp = 0;
            decimal.TryParse(id,out temp);
            Table_folders folder = await entitiesDB.Table_folders.FindAsync(temp);
            if (folder != null)
            {
                entitiesDB.Table_folders.Remove(folder);
                entitiesDB.SaveChanges();

                var importDir = HostingEnvironment.MapPath("~/Foto/" + folder.name + "/");
                if (Directory.Exists(importDir))
                {
                    Directory.Delete(importDir);
                }
            }

        }
        public async Task<Table_folders> FindByIdAsync(decimal id)
        {
            return await GetAsync(id);
        }

        Table_folders FindById(string id)
        {
            throw new NotImplementedException();
        }
       

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.AppContext.Dispose();
                }

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        Table_folders IRepository<Table_folders, string>.FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Table_folders> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Table_folders> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}