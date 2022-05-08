using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ImageUpload> ImageUploads { get; set; }

        internal void UploadFile(string image, string fullpath)
        {
            throw new NotImplementedException();
        }
    }
}
