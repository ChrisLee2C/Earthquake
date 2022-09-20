using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class HTTPPost : MonoBehaviour
{
    List<string> paramenters;
    string email;
    string token;
    string data;

    void Start()
    {
        paramenters = FindObjectOfType<HTTPGet>().parameters;
        email = paramenters[0];
        token = paramenters[1];

        data = string.Format("[{{\"email\":\"{0}\",\"token\":\"{1}\",\"apps_id\":\"app10\",\"score\":1}}]", email, token);
    }

    IEnumerator postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", data);


        using (UnityWebRequest uwr = UnityWebRequest.Post(url, form))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)

            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }
            uwr.Dispose();
        }
    }

    public void Post()
    {
        print(data);
        StartCoroutine(postRequest("https://cuhk.iontec.com.hk/api.php"));
    }
}
