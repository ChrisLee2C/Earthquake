using System.Collections.Generic;

public class ParamParse
{
    [System.Runtime.InteropServices.DllImport("__Internal")]
    public static extern string BrowserGetLinkHREF();

    public static Dictionary<string, string> GetBrowserParameters()
    {

        Dictionary<string, string> ret =
            new Dictionary<string, string>();

        //#if UNITY_WEBGL && !UNITY_EDITOR

        // Use the .NET class Uri to parse the link and get the query portion for us
        System.Uri uri = new System.Uri(BrowserGetLinkHREF());
        string linkParams = uri.Query;

        if (linkParams.Length == 0)
            return ret;

        // If it contains the starting questionmark, strip it out
        if (linkParams[0] == '?')
            linkParams = linkParams.Substring(1);

        // Get the different parameters separated by '&''
        string[] sections = linkParams.Split(new char[] { '&' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string sec in sections)
        {
            // Check to see if it's a variable assignment
            string[] split = sec.Split(new char[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 0)
                continue;

            // If it contains an '=' sign, assign its key-value in the dictionary
            if (split.Length == 2)
            {
                if (ret.ContainsKey(split[0]) == true)
                    ret[split[0]] = split[1];
                else
                    ret.Add(split[0], split[1]);
            }
            else
            {
                // If it doesn't contain a '=', just log it as a key, and an empty value
                if (ret.ContainsKey(sec) == true)
                    ret[sec] = "";
                else
                    ret.Add(sec, "");
            }

        }
        //#endif
        return ret;
    }
}