using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    public class Session
    {
        public SessionToken sessionToken;
        public Config config = Config.DefaultConfig;

        public Session()
        {
            this.sessionToken = new SessionToken(ref config);
        }
    }
}