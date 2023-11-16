using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string username, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(username, pass, response));
    }
    private IEnumerator CO_CreateUser(string username, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("pass", pass);
        WWW w = new WWW("https://localhost/usuarios/createUser.php", form);
        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));


    }
}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}