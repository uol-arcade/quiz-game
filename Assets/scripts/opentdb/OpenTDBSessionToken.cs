using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace OpenTDB
{
    public class SessionToken
    {
        public string token;

        private static string buildParam (string x) => $"command={x}";

        public readonly string commandRequest = buildParam("request");
        public readonly string commandReset = buildParam("reset"); 

        public Config config;

        public SessionToken(ref Config sessionConfig)
        {
            this.config = sessionConfig;

            this.Retrieve();
        }

        public void Reset()
        {
            var parameters = Utils.GetParamString(config.apiEndpointToken, commandReset);
            var requestUrl = $"{config.apiBaseURL}{parameters}";
            Debug.Log($"SessionToken.Reset() => {requestUrl}");
        }

        public void Retrieve()
        {
            var parameters = Utils.GetParamString(config.apiEndpointToken, commandRequest);
            var requestUrl = $"{config.apiBaseURL}{parameters}";
            
            var response = Utils.SendAndGetJson<ResponseTokenRequest>(requestUrl);
            Utils.CheckResponseCode(response.response_code);
            
            Debug.Log($"SessionToken.Retrieve() => {requestUrl}");

            this.token = response.token;
        }
    }
}