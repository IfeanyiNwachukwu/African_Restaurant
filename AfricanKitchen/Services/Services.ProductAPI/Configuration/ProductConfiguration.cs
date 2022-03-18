using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.ProductAPI.Models;

namespace Services.ProductAPI.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Samosa",
                    Price = 15,
                    Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                    ImageUrl = "https://dbblobifeanyi.blob.core.windows.net/ifeanyi/14.jpg",
                    CategoryName = "Appetizer"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Paneer Tikka",
                    Price = 13.99,
                    Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                    ImageUrl = "https://dbblobifeanyi.blob.core.windows.net/ifeanyi/12.jpg",
                    CategoryName = "Appetizer"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Sweet Pie",
                    Price = 10.99,
                    Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                    ImageUrl = "https://dbblobifeanyi.blob.core.windows.net/ifeanyi/11.jpg",
                    CategoryName = "Dessert"
                },

                  new Product
                  {
                      ProductId = 4,
                      Name = "Pav Bhaji",
                      Price = 15,
                      Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                      ImageUrl = "https://dbblobifeanyi.blob.core.windows.net/ifeanyi/13.jpg",
                      CategoryName = "Entree"
                  }


            );
        }
    }
}
