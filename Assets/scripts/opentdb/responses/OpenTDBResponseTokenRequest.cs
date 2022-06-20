using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace OpenTDB
{
    [System.Serializable]
    public class ResponseTokenRequest
    {
        public int response_code;
        public string response_message;
        public string token;
    }
}