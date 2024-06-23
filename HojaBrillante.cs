using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaBrillante : MonoBehaviour
{
    public SwitchLuces Switch;
    public GameObject ObjetoHoja;
    void Update()
    {
        if (Switch.Encendido)
        {
            ObjetoHoja.SetActive(false);

        } else {
        
            ObjetoHoja.SetActive(true);

        }
    }
}
