
using Aarvani.ChannelAdvisor.Contracts;
using Aarvani.ChannelAdvisor.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarvani.ChannelAdvisor.Services
{
    public sealed class ProductService: IProductService
    {
        public ProductService(  )
        {
           
        }

        public async Task<Product> GetProduct(int id) {

            ApiCall.ApiCallGet<Product> call = 
                new ApiCall.ApiCallGet<Product>(ValuesType.ApiUrls.Products);
            return await call.Get(id);

        }

        public async Task<IEnumerable<Product>> GetProducts(int? Skip = null, string Filter = "") {
            

            ApiCall.ApiCallGet<Product> call =
                new ApiCall.ApiCallGet<Product>(ValuesType.ApiUrls.Products);
            string query = string.Empty;
            bool hasparam = false;
            
            //Filter
            if (!string.IsNullOrEmpty(Filter))
            {
                query = "$filter=" + Filter;
                hasparam = true;
            }

            //Paging
            if (Skip != null)
            {
                if (hasparam)
                    query += "&";

                query += "$skip=" + Skip;
                hasparam = true;
            }

            if (hasparam)
                query = "?"+ query;

            return await call.Get(query);
        }
        
        public async Task UpdateProduct(Product product) {

            var dclass = new  ExpandoObject();
            
            ApiCall.ApiCallPatch<ExpandoObject> call =
                new ApiCall.ApiCallPatch<ExpandoObject>(ValuesType.ApiUrls.Products);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            
            foreach (var item in product.GetType().GetProperties())
            {
                if (item.GetValue(product, null) != null)
                {

                    string type = item.GetValue(product, null).GetType().ToString().ToLower();
                    object value = item.GetValue(product, null);

                    if (value != null)
                    {
                        if (type.Contains("int"))
                        {
                            if ((int)value > 0)
                            {
                                properties.Add(item.Name, value);
                            }
                        }

                        if (type.Contains("string"))
                        {
                            if (!string.IsNullOrEmpty((string)value))
                            {
                                properties.Add(item.Name, value);
                            }
                        }
                    }
                }
                
            }
            
            dclass = GetDynamicObject(properties);

            await call.Update(dclass, 367849);

        }
        

        public static dynamic GetDynamicObject(Dictionary<string, object> properties)
        {
            var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var property in properties)
            {
                dynamicObject.Add(property.Key, property.Value);
            }
            return dynamicObject;
        }

    }
    

 }




