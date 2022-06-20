using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace OpenTDB
{
    [System.Serializable]
    public class ResponseTokenReset
    {
        public int response_code;
        public string token;
    }
}