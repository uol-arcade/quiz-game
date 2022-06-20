using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace OpenTDB
{
    public static class Utils
    {
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