using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    [AddComponentMenu("OpenTDB/Tester")]
    public class OpenTDBTester : MonoBehaviour
    {
        public void Start()
        {
            var session = new Session();
        }
    }
}