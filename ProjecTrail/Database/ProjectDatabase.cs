using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjecTrail.Models;
using ProjecTrail;
using SQLite;

namespace ProjecTrail.Database
{
    public class ProjectDatabase : DbContext
    {
        private SQLiteAsyncConnection Database;

        public ProjectDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(PathDb.GetPath(Constants.DatabaseFilename), Constants.Flags);
            var result = await Database.CreateTableAsync<Project>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Filename={PathDb.GetPath(Constants.DatabaseFilename)}");
            }
        }


        public async Task<List<Project>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Project>().ToListAsync();
        }

        public async Task<Project> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Project>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Project item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Project item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
