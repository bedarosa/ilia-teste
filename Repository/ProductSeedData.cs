using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ProductSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Rodou!!!");
            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Celular", Price = 10.0, Description = "Celular Samsung" },
                new { Id = 2, Name = "Notebook", Price = 25.0, Description = "Notebook Dell Inspiron" },
                new { Id = 3, Name = "Tablet", Price = 15.0, Description = "Tablet Apple iPad" },
                new { Id = 4, Name = "Fone de Ouvido", Price = 5.0, Description = "Fone de Ouvido Bluetooth JBL" },
                new { Id = 5, Name = "Monitor", Price = 20.0, Description = "Monitor LG 24 Polegadas" },
                new { Id = 6, Name = "Mouse", Price = 7.0, Description = "Mouse Sem Fio Logitech" },
                new { Id = 7, Name = "Teclado", Price = 8.0, Description = "Teclado Mecânico Redragon" },
                new { Id = 8, Name = "Smartwatch", Price = 12.0, Description = "Smartwatch Xiaomi Mi Band" },
                new { Id = 9, Name = "Câmera", Price = 30.0, Description = "Câmera DSLR Canon" },
                new { Id = 10, Name = "Impressora", Price = 18.0, Description = "Impressora HP LaserJet" }
        );
            Console.WriteLine("Chegou ao fim!!!");
        }
    }
}
