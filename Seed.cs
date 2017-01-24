using System;
using System.Linq;
using DotNetGroupTalk.Models;
using Microsoft.Extensions.DependencyInjection;

public static class Seed{
    public static void Seedit(IServiceProvider serviceProvider){
        using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()){
            var context = serviceScope.ServiceProvider.GetService<ProductContext>();
            bool exist= context.Database.EnsureCreated();
            if(!context.Products.Any()){
                var pro = new Product();
                pro.Name = "Hello Seeding";
                context.Products.Add(pro);
                context.SaveChanges();
            }
        }
    }
}