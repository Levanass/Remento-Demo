using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recogible : MonoBehaviour
{
    public GameObject EsteObjeto;
    public AudioSource AudioSourceEsteObj;
    public bool sono =false;
    
    void Update()
    {
        if (!sono)
        {
            if (EsteObjeto.GetComponent<Avisar>().YaRevisado && !EsteObjeto.GetComponent<Inspeccionable>().ObjetoHablando)
            {
                AudioSourceEsteObj.Play();
                sono = true;
            }
        }
        
    }
}
