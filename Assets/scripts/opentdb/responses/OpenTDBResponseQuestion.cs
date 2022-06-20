using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace OpenTDB
{
    [System.Serializable]
    public class ResponseQuestion
    {
        public int response_code;
        public Question[] results;
    }
}