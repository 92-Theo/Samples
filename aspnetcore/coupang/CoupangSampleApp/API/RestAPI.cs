using CoupangSampleApp.API.Request;
using CoupangSampleApp.API.Response;
using CoupangSampleApp.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace CoupangSampleApp.API
{
    public class RestAPI
    {
        private static string url = "https://api-gateway.coupang.com";
        private static string schema = "https";
        private static int port = 443;




        /// <summary>
        /// 발주서 목록 조회 (일단위 페이징)
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="vendorId"></param>
        /// <param name="createdAtFrom">검색 시작일시 yyyy-mm-dd 형태로 조회하기 원하는 시작 날짜 기입 ex) 2018-07-01</param>
        /// <param name="createdAtTo">검색 종료일시 yyyy-mm-dd 형태로 조회하기 원하는 종료 날짜 기입 ex) 2018-07-31 최대 31일까지 조회 가능합니다.</param>
        /// <param name="status">발주서 상태</param>
        /// <returns></returns>
        public OrderSheetsResponse GetOrderSheets(string accessKey, string secretKey, string vendorId, DateTime createdAtFrom, DateTime createdAtTo, string status)
        {
            var ret = default(OrderSheetsResponse);
            string method = "GET";
            string path = $"/v2/providers/openapi/apis/api/v4/vendors/{vendorId}/ordersheets";

            var uriBuilder = new UriBuilder(url + path);
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["createdAtFrom"] = Helper.DateToString(createdAtFrom);
            parameters["createdAtTo"] = Helper.DateToString(createdAtTo);
            parameters["status"] = status;
            uriBuilder.Query = parameters.ToString();

            string query = uriBuilder.Query.ToString().Remove(0, 1);

            uriBuilder.Scheme = schema;
            uriBuilder.Port = port;
            Uri finalUrl = uriBuilder.Uri;

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(finalUrl.ToString());

                request.Timeout = 10000;
                request.Method = method;

                request.ContentType = "application/json;charset=UTF-8";
                request.Headers["Authorization"] = GetHmac(accessKey, secretKey,  method, path, query);

                var response = (HttpWebResponse)request.GetResponse();
                // Display the status ...
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Response Status Code is OK and StatusDescription is: {0}", response.StatusDescription);

                    var responseStream = response.GetResponseStream();

                    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    // Pipes the stream to a higher level stream reader with the required encoding format. 
                    StreamReader reader = new StreamReader(responseStream, encode);

                    string responseString = reader.ReadToEnd();

                    reader.Close();
                    responseStream.Close();
                    response.Close();

                    Console.WriteLine(responseString);
                    //Console.WriteLine(String.Format("Response: {0}", responseString));

                    ret = JsonConvert.DeserializeObject<OrderSheetsResponse>(responseString);
                }
                else
                {
                    string msg = $"Response Status Code is Not OK and StatusDescription is: {response.StatusDescription}";
                    Console.WriteLine(msg);
                    ret = new OrderSheetsResponse() { Messasge = msg };
                }
            }
            catch (WebException e)
            {
                string msg = $"WebException Raised. The following error occured : {e.Status}\n";
                msg += e.Message;
                Console.WriteLine(msg);
                ret = new OrderSheetsResponse() { Messasge = msg };
            }
            catch (Exception e)
            {
                string msg = $"The following Exception was raised : {e.Message}";
                Console.WriteLine(msg);
                ret = new OrderSheetsResponse() { Messasge = msg };
            }


            return ret;
        }

        public OrderInvoicesResponse UploadOrderInvoices(string accessKey, string secretKey, string vendorId, OrderInvoicesRequest requestData)
        {
            var ret = default(OrderInvoicesResponse);

            string method = "POST";

            string path = $"/v2/providers/openapi/apis/api/v4/vendors/{vendorId}/orders/invoices";
            //replace with your own product registration json data
            //String strjson = "{}";
            String strjson = JsonConvert.SerializeObject(requestData);

            var uriBuilder = new UriBuilder(url + path);

            uriBuilder.Scheme = schema;
            uriBuilder.Port = port;
            Uri finalUrl = uriBuilder.Uri;

            try
            {

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(finalUrl.ToString());

                request.Timeout = 10000;
                request.Method = method;

                request.ContentType = "application/json;charset=UTF-8";
                request.Headers["Authorization"] = GetHmac(accessKey, secretKey, method, path, "");

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    byte[] data = Encoding.UTF8.GetBytes(strjson);

                    streamWriter.Write(strjson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var response = (HttpWebResponse)request.GetResponse();

                // Display the status ...
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Response Status Code is OK and StatusDescription is: {0}", response.StatusDescription);

                    var responseStream = response.GetResponseStream();

                    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    // Pipes the stream to a higher level stream reader with the required encoding format. 
                    StreamReader reader = new StreamReader(responseStream, encode);

                    string responseString = reader.ReadToEnd();

                    reader.Close();
                    responseStream.Close();
                    response.Close();

                    Console.WriteLine(String.Format("Response: {0}", responseString));

                    ret = JsonConvert.DeserializeObject<OrderInvoicesResponse>(responseString);
                }
                else
                {
                    string msg = $"Response Status Code is Not OK and StatusDescription is : {response.StatusDescription}";
                    Console.WriteLine(msg);
                    ret = new OrderInvoicesResponse() { Messasge = msg };
                }
            }
            catch (WebException e)
            {
                string msg = $"WebException Raised. The following error occured : {e.Status}\n{e.Message}";
                Console.WriteLine(msg);
                ret = new OrderInvoicesResponse() { Messasge = msg };
            }
            catch (Exception e)
            {
                string msg = $"The following Exception was raised : {e.Message}";
                Console.WriteLine(msg);
                ret = new OrderInvoicesResponse() { Messasge = msg };
            }

            return ret;
        }



        private string GenerateFormattedMessage(string datetime, string method, string path, string query)
        {
            return String.Format("{0}{1}{2}{3}", datetime, method, path, query);
        }

        private String GenerateFormattedHeader(string accessKey, string algorithm, string datetime, string signature)
        {
            return String.Format("CEA algorithm={0}, access-key={1}, signed-date={2}, signature={3}", algorithm, accessKey, datetime, signature);
        }

        private string GetHmac(string accessKey, string secretKey, string method, string path,  string query)
        {
            string algorithm = "HmacSHA256";
            string datetime = DateTime.Now.ToUniversalTime().ToString("yyMMddTHHmmssZ");
            string message = GenerateFormattedMessage(datetime, method, path, query);
            string signature = CreateTokenByHMACSHA256(secretKey, message);

            return GenerateFormattedHeader(accessKey, algorithm, datetime, signature);
        }

        private String CreateTokenByHMACSHA256(string secretKey, string message)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            var hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            return ByteToString(hmacsha256.ComputeHash(messageBytes));
        }

        public string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("x2"); // hex format
            }
            return sbinary;
        }
    }
}
