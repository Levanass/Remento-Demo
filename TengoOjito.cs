using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TengoOjito : MonoBehaviour
{
    public Image Ojito;
    public GameObject EsteObjeto;

    void Start()
    {
        Ojito.enabled = true;
    }
    
    void Update()
    {
        if (EsteObjeto.GetComponent<Avisar>().YaRevisado) // Si revise Liber, desactivar su ojo
        {
            Ojito.enabled = false;
        }
    }
}
