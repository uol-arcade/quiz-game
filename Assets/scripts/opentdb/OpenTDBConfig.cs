using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    public class Config
    {
        public string apiBaseURL = default;
        public string apiEndpointQuestions = default;
        public string apiEndpointToken = default;

        public const int RESPONSE_SUCCESS = 0;
        public const int RESPONSE_NO_RESULTS = 1;
        public const int RESPONSE_INVALID_PARAMETER = 2;
        public const int RESPONSE_TOKEN_NOT_FOUND = 3;
        public const int RESPONSE_TOKEN_EMPTY = 4;

        public static readonly Config DefaultConfig = new Config()
        {
            apiBaseURL = @"https://opentdb.com/",
            apiEndpointQuestions = "api.php",
            apiEndpointToken = "api_token.php"
        };
    }
}