namespace Iverzer.Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class IverzerOA : DbContext
    {
        public IverzerOA()
            : base("name=IverzerOA")
        {

        }
        //模型映射成表的时候删除表名的复数版本（加s es这种命名）
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
    }
}