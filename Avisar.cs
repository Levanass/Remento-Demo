using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avisar : MonoBehaviour
{
    public bool YaRevisado;
    public Inspeccionable InspeccionableObj;
    void Update()
    {
        if (InspeccionableObj.ObjetoHablando)
        {
            YaRevisado = true;
        }
    }
}
