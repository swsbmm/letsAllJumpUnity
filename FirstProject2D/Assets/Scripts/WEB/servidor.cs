using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[CreateAssetMenu(fileName = "Servidor", menuName = "HegetServidor", order = 1)]
public class Servidor : ScriptableObject
{
    public string servidor;
    public Servicio[] servicios;
    public Respuesta respuesta;

    public bool ocupado = false;

    public IEnumerator ConsumirServicio(string nombre, string[] datos)
    {
        Debug.Log("HOLAa");
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s = new Servicio();
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
            }
        }

        for (int i = 0; i < s.parametros.Length; i++)
        {
            formulario.AddField(s.parametros[i], datos[i]);
        }

        UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.url, formulario);
        Debug.Log(servidor + "/" + s.url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            respuesta = new Respuesta();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
        }
        ocupado = false;
    }

}

[System.Serializable]
public class Servicio
{
    public string nombre;
    public string url;
    public string[] parametros;
}

[System.Serializable]
public class Respuesta
{
    public int codigo;
    public string mensaje;

    public Respuesta()
    {
        codigo = 404;
        mensaje = "error";
    }
}