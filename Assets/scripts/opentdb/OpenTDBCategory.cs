using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    [System.Serializable]
    public class Category
    {
        public int id;
        public string name;

        public override string ToString()
        {
            return this.name;
        }

        public static Category[] GetCategories(ref Config config)
        {
            var parameters = Utils.GetParamString(config.apiEndpointCategory);
            var requestUrl = $"{config.apiBaseURL}{parameters}";
            Debug.Log($"Category.GetCategories() => {requestUrl}");
            return new Category[] { null };
        }
    }
}