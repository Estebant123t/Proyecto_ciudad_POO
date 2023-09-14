using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net.NetworkInformation;

public class BaseenWeb : MonoBehaviour
{
    public void CrearUsuario(string usuario, string contrase�a, Action<Respuesta> response)
    {
        StartCoroutine(CO_CrearUsuario(usuario, contrase�a, response));

    }
    private IEnumerator CO_CrearUsuario(string usuario, string contrase�a, Action<Respuesta> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario);
        form.AddField("contrase�a", contrase�a);
        WWW w = new WWW("https://localhost/Base_de_datos_POO/CrearUsuario.php", form);
        yield return w;

        response(JsonUtility.FromJson<Respuesta>(w.text));

    }
}
[Serializable]
public class Respuesta
{
    public bool done = false;
    public string mensaje = "";
}
