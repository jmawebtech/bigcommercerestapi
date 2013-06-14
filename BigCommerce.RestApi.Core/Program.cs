using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using BigCommerce.RestApi.Core;
using System.Xml;

namespace BigCommerceConsole
{
    class Program
    {
        static string api_key = "27f6ba83fc77d9cd4f13eb76bf0c53fb73009a44";
        static string username = "admin";
        static string baseUrl = "https://store-4evfk.mybigcommerce.com/api/v2/";

        static void Main(string[] args)
        {
            // do to product options

            //https://store-4evfk.mybigcommerce.com/api/v2/orders/100/products.xml

            //List<order> orders = GetOrdersByDateRange(DateTime.Now.AddDays(-1), DateTime.Now);
            //List<Product> p = GetProducts(100);
            List<Address> add = GetAddresses(100);
            Console.ReadLine();
        }

        static List<order> GetOrdersByDateRange(DateTime beginTime, DateTime endTime)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string bt = Rfc822DateTime.ToString(beginTime.ToUniversalTime()).Replace("Z", "-0700").Trim();
            string et = Rfc822DateTime.ToString(endTime.ToUniversalTime()).Replace("Z", "-0700").Trim();

            string url = String.Format("orders.json?min_date_created={0}&max_date_created={1}", bt, et);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                List<order> result = response.Content.ReadAsAsync<List<order>>().Result;
                return result;
            }

            return null;

        }

        static List<order> GetOrdersByIdRange(int lowestOrder, int highestOrder)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string url = String.Format("orders.json?min_id={0}&max_id={1}", lowestOrder, highestOrder);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                List<order> result = response.Content.ReadAsAsync<List<order>>().Result;
                return result;
            }

            return null;
        }

        static order GetOrderById(string orderId)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string url = String.Format("orders/{0}.json?", orderId);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                order result = response.Content.ReadAsAsync<order>().Result;
                return result;
            }

            return null;
        }

        static List<Product> GetProducts(int orderId)
        {
            //https://store-4evfk.mybigcommerce.com/

            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string url = String.Format("orders/{0}/products.json", orderId);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Product> result = response.Content.ReadAsAsync<List<Product>>().Result;
                return result;
            }

            return null;

        }

        static List<Address> GetAddresses(int orderId)
        {
            //https://store-4evfk.mybigcommerce.com/

            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string url = String.Format("orders/{0}/shippingaddresses.json", orderId);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Address> result = response.Content.ReadAsAsync<List<Address>>().Result;
                return result;
            }

            return null;

        }
    }
}
