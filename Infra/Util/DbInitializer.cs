using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars.Infra.Util
{
    public static class DbInitializer
    {
        public static void CreateFilm(AppDbContext context)
        {
            //var adminCount = context.Admin.Count();
            ////if (adminCount == 0)
            ////{
            //byte[] passwordHash, passwordSalt;
            //PasswordHasher.Create("Fwbg2Zwj", out passwordHash, out passwordSalt);
            //var admin1 = new Admin
            //{
            //    Nome = "admin",
            //    Email = "admin@admin.com",
            //    Celular = "62 99161-6262",
            //    AdminTypeId = "7411b766-45cf-409b-9007-e3c368677525",
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt
            //};
            //context.Admin.Add(admin1);
            //context.SaveChanges();
            ////}
        }

        public async static Task SeedProductCategoryAttribute(AppDbContext context)
        {
            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE ProductAttributeValue");
            //await context.SaveChangesAsync();

            //var products = context.Product.OrderBy(order => order.Sequence).ToList();
            //foreach (var product in products)
            //{
            //    switch (product.Name)
            //    {
            //        case "1.49 S/ AR":
            //            {
            //                var productCategoryAttribute = context.ProductCategoryAttribute.Where(single => single.ProductCategoryId == product.ProductCategoryId).ToList();

            //                foreach (var attr in productCategoryAttribute)
            //                {
            //                    switch (attr.Name)
            //                    {
            //                        case "Diâmetro":
            //                            {
            //                                var productCategoryAttributeValue = await context.ProductCategoryAttributeValue.SingleOrDefaultAsync(single => single.ProductCategoryAttributeId == attr.Id &&
            //                                    single.Value == "-70MM/+65MM");
            //                                Serilog.Log.Error((productCategoryAttributeValue == null).ToString());
            //                                var productAttributeValue = new ProductAttributeValue
            //                                {
            //                                    ProductId = product.Id,
            //                                    ProductCategoryAttributeId = attr.Id,
            //                                    ProductCategoryAttributeValueId = productCategoryAttributeValue.Id
            //                                };
            //                                context.ProductAttributeValue.Add(productAttributeValue);
            //                                break;
            //                            }
            //                        case "Esférico Mínimo":
            //                            {
            //                                var productCategoryAttributeValue = await context.ProductCategoryAttributeValue.SingleOrDefaultAsync(single => single.ProductCategoryAttributeId == attr.Id &&
            //                                    single.Value == "-6");
            //                                var productAttributeValue = new ProductAttributeValue
            //                                {
            //                                    ProductId = product.Id,
            //                                    ProductCategoryAttributeId = attr.Id,
            //                                    ProductCategoryAttributeValueId = productCategoryAttributeValue.Id
            //                                };
            //                                context.ProductAttributeValue.Add(productAttributeValue);
            //                                break;
            //                            }
            //                        case "Esférico Máximo":
            //                            {
            //                                var productCategoryAttributeValue = await context.ProductCategoryAttributeValue.SingleOrDefaultAsync(single => single.ProductCategoryAttributeId == attr.Id &&
            //                                    single.Value == "6");
            //                                var productAttributeValue = new ProductAttributeValue
            //                                {
            //                                    ProductId = product.Id,
            //                                    ProductCategoryAttributeId = attr.Id,
            //                                    ProductCategoryAttributeValueId = productCategoryAttributeValue.Id
            //                                };
            //                                context.ProductAttributeValue.Add(productAttributeValue);
            //                                break;
            //                            }
            //                        case "Cilíndrico Mínimo":
            //                            {
            //                                var productCategoryAttributeValue = await context.ProductCategoryAttributeValue.SingleOrDefaultAsync(single => single.ProductCategoryAttributeId == attr.Id &&
            //                                    single.Value == "-2");
            //                                var productAttributeValue = new ProductAttributeValue
            //                                {
            //                                    ProductId = product.Id,
            //                                    ProductCategoryAttributeId = attr.Id,
            //                                    ProductCategoryAttributeValueId = productCategoryAttributeValue.Id
            //                                };
            //                                context.ProductAttributeValue.Add(productAttributeValue);
            //                                break;
            //                            }
            //                        case "Cilíndrico Máximo":
            //                            {
            //                                var productCategoryAttributeValue = await context.ProductCategoryAttributeValue.SingleOrDefaultAsync(single => single.ProductCategoryAttributeId == attr.Id &&
            //                                    single.Value == "0");
            //                                var productAttributeValue = new ProductAttributeValue
            //                                {
            //                                    ProductId = product.Id,
            //                                    ProductCategoryAttributeId = attr.Id,
            //                                    ProductCategoryAttributeValueId = productCategoryAttributeValue.Id
            //                                };
            //                                context.ProductAttributeValue.Add(productAttributeValue);
            //                                break;
            //                            }
            //                    }
            //                }
            //                await context.SaveChangesAsync();
            //                break;
            //            }
            //    }
            //}
        }

        public static void Seed(AppDbContext context)
        {
            if (context != null)
            {
                context.Database.ExecuteSqlRaw("CREATE DATABASE starwarsdb");

                CreateFilm(context);
            }
        }
    }
}
