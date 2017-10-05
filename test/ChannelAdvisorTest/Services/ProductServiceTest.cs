
using Aarvani.ChannelAdvisor.Contracts;
using Aarvani.ChannelAdvisor.Entities;
using Aarvani.ChannelAdvisor.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using System.Threading;
using System;
using System.Diagnostics;

namespace ChannelAdvisorTest.Services
{
    [TestClass]
    public class ProductServiceTest
    {


        [TestMethod]
        public async Task Should_Get_OneProduct() {

            //Arrange
            ProductService productService = new ProductService();
            Product product;

            //Act
            product = await productService.GetProduct(367849);
            
            //Arrange
            Assert.IsNotNull(product);

        }

        [TestMethod]
        public async Task Should_Get_100Products() {

            //Arrange
            ProductService productService = new ProductService();
            IEnumerable<Product> products;

            //Act
            products = await productService.GetProducts();

            //Arrange
            Assert.IsNotNull(products);

        }
        
        [TestMethod]
        public async Task Should_Update_OneProduct() {
            //Arrange
            ProductService productService = new ProductService();
            Product product = new Product()
            {
                Description = "Update Americo 3"
            };

            //Act

            try
            {
                await productService.UpdateProduct(product);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(false);
                throw;
            }

            
            //Assert
        }
  
        

    }
}
