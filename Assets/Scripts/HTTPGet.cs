using System.Collections.Generic;
using UnityEngine;

public class HTTPGet : MonoBehaviour
{
    public List<string> parameters;

    private void Awake()
    {
        this.ListHREFParameters();
    }

    void ListHREFParameters()
    {
        Dictionary<string, string> prms = ParamParse.GetBrowserParameters();
        if (prms.Count == 0)
            return;

        foreach (KeyValuePair<string, string> kvp in prms)
        {
            parameters.Add(kvp.Value);
        }
    }
}