using api_banco_geek.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_banco_geek.Infraestructure
{
    public class ApiBancoGeekDbContext : DbContext
    {
        public virtual DbSet<ApiCallLog> ApiCallLog { get; set; }
        public virtual DbSet<FibonacciValue> FibonacciValue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiCallLog>(entity => {
                entity.ToTable("ApiCallLog");

                entity.Property(e => e.Request).IsRequired();
                entity.Property(e => e.ValueA).IsRequired();
                entity.Property(e => e.ValueB).IsRequired();
                entity.Property(e => e.ResultValue).IsRequired();
                entity.Property(e => e.IsResultValueInFibonnaci).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<FibonacciValue>(entity => {
                entity.ToTable("FibonacciValue");

                entity.Property(e => e.Value).IsRequired();

                entity.HasData(
                    new FibonacciValue() { IdValue = 1, Value = 0 },
                    new FibonacciValue() { IdValue = 2, Value = 1 }
                );

                decimal a = 0;
                decimal b = 1;
                decimal fibonacciValue;

                for (int i = 3; i < 101; i++)
                {
                    fibonacciValue = a + b;
                    entity.HasData(new FibonacciValue { IdValue= i, Value = fibonacciValue });
                    a = b;
                    b = fibonacciValue;
                }
            });
        }
    }
}
