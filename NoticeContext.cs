using Microsoft.EntityFrameworkCore;
using NoticeBoardAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardAPI.Data
{
    public class NoticeContext : DbContext
    {
        public NoticeContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Notice> Notices { get; set; }
        //public DbSet<Relation> Relations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
