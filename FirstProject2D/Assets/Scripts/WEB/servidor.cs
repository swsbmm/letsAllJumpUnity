using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[CreateAssetMenu(fileName = "Servidor", menuName = "HegetServidor", order=1)]
public class Servidor : ScriptableObject
{
    public string servidor;
    public Servicio[] servicios;
    public Respuesta respuesta;

    public bool ocupado = false;
    public 


    public IEnumerator ConsumirServicio(string nombre, string[] datos)
    {
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s;
        for(int = 0; int<servicios.Length; int++)
        {
            if (servicios[i].Equals(nombre))
            {
                s = servicios[i];
            }
        }

        for(int=0; int< s.parametros; int++)
        {
            formulario.AddField(s.parametros[i], datos[i]);
        }

        UnityWebRequest WWW = UnityWebRequest.Post(servidor.url)

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
}