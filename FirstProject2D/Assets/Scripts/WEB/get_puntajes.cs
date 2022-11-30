using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_puntajes : MonoBehaviour
{
    public Servidor servidor;
    

    public void get()
    {
        
        string[] datos = new string[0];
        StartCoroutine(servidor.ConsumirServicio("puntajes", datos));
        
    }
}
