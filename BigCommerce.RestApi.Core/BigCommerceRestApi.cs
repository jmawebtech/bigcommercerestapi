using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BigCommerce.RestApi.Core
{
    public class BigCommerceRestApi
    {
        string api_key;
        string username;
        string baseUrl;

        public BigCommerceRestApi(string api_key, string username, string baseUrl)
        {
            this.api_key = api_key;
            this.username = username;
            this.baseUrl = baseUrl;
        }

        public List<orderstatus> GetOrderStatuses()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, api_key);

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
            };

            string url = "orderstatuses.json";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                List<orderstatus> result = response.Content.ReadAsAsync<List<orderstatus>>().Result;
                return result;
            }

            return null;

        }


        public List<order> GetOrdersByDateRange(DateTime beginTime, DateTime endTime)
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

        public List<order> GetOrdersByIdRange(int lowestOrder, int highestOrder)
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

        public order GetOrderById(string orderId)
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

        public List<Product> GetProducts(int orderId)
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

        public List<Address> GetAddresses(int orderId)
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
