using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenTDB
{
    public static class Utils
    {
        public static HttpClient httpClient = new HttpClient();

        public static T SendAndGetJson<T>(string requestUrl)
        {
            var task = Task.Run(() => Utils.httpClient.GetStringAsync(requestUrl));
            task.Wait();

            var jsonStr = task.Result;
            return JsonUtility.FromJson<T>(jsonStr);
        }

        public static void CheckResponseCode(int responseCode)
        {
            if(responseCode == Config.RESPONSE_INVALID_PARAMETER)
                throw new UnityException("Response from request: Invalid parameters given");

            if (responseCode == Config.RESPONSE_NO_RESULTS)
                throw new UnityException("Response from request: No results for query");

            if (responseCode == Config.RESPONSE_TOKEN_EMPTY)
                throw new UnityException("Response from request: Token given is empty");

            if (responseCode == Config.RESPONSE_TOKEN_NOT_FOUND)
                throw new UnityException("Response from request: Token not found in request");
        }

        public static string GetParamString(params string[] input)
        {
            if(input.Length == 1)
                return $"{input[0]}";

            var paramStr = string.Join("&", input.Skip(1));
            return $"{input[0]}?{paramStr}";
        }

        public static string Keypair (string k, object v) => $"{k}={v}";
    }
}