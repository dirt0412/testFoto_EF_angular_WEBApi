using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class FotoFilesRepo : IRepository<Table_foto_files, string>
    {
        protected DbContext AppContext { get; private set; }
        private fotoEntities entitiesDB = new fotoEntities();

        public FotoFilesRepo()
        {
            //this.entitiesDB = entitiesDB;
        }

        public async Task<Table_foto_files> GetAsync(string id)
        {
            return await Task.Run(delegate ()
            {
                return entitiesDB.Table_foto_files.FindAsync(id);
            });
        }

        public async Task<IList<Table_foto_files>> GetAsync()
        {
            return await Task.Run<IList<Table_foto_files>>(delegate ()
            {
                return entitiesDB.Table_foto_files.ToList();
            });
        }        

        public async Task<Table_foto_files> PostAsync(Table_foto_files folder)
        {
            return await Task.Run<Table_foto_files>(delegate ()
            {


                Table_foto_files obj = entitiesDB.Table_foto_files.Add(folder);
                entitiesDB.SaveChanges();
                //Table_foto_files obj = dbSet.Add(folder);
                //this._unitOfWork.Db.SaveChanges();
                return obj;
            });
        }

        public async Task<Table_foto_files> PutAsync(Table_foto_files folder)
        {
            return await Task.Run<Table_foto_files>(delegate ()
            {
                Table_foto_files obj = entitiesDB.Table_foto_files.Attach(folder);
                entitiesDB.Entry(folder).State = EntityState.Modified;
                entitiesDB.SaveChanges();
                //Table_foto_files obj = dbSet.Attach(folder);
                //_unitOfWork.Db.Entry(folder).State = EntityState.Modified;
                //this._unitOfWork.Db.SaveChanges();
                return obj;
            });
        }

        public async Task DeleteAsync(string id)
        {
            decimal temp = 0;
            decimal.TryParse(id, out temp);
            Table_foto_files folder = await entitiesDB.Table_foto_files.FindAsync(temp);
            if (folder != null)
            {
                entitiesDB.Table_foto_files.Remove(folder);
                entitiesDB.SaveChanges();

                //var importDir = HostingEnvironment.MapPath("~/Foto/" + folder.name + "/");
                //if (Directory.Exists(importDir))
                //{
                //    Directory.Delete(importDir);
                //}
            }
            //var entity = await FindByIdAsync(id);
            //if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entity);
            //}
            //dynamic obj = dbSet.Remove(entity);
            //this._unitOfWork.Db.SaveChanges();
        }
        public async Task<Table_foto_files> FindByIdAsync(string id)
        {
            return await GetAsync(id);
        }

        Table_foto_files FindById(string id)
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
                    //this.UserManager.Dispose();
                }

                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        Table_foto_files IRepository<Table_foto_files, string>.FindById(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
       
    }
}