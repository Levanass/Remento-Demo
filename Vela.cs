using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vela : MonoBehaviour
{
    Encendedor encjugador;
    Raycast_Jugador jugador;
    public bool VelaEncendida;
    public Light LuzVela;
    public GameObject Llama;
    
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Raycast_Jugador>();
        encjugador = GameObject.Find("Encendedor").GetComponent<Encendedor>();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.tag = "Untagged";

       
    }

    void Update()
    {
        if (VelaEncendida)
        {
            LuzVela.enabled = true;
            Llama.SetActive(true);
            gameObject.tag = "Untagged";
        }
        else
        {
            LuzVela.enabled = false;
            Llama.SetActive(false);
            gameObject.tag = "Interactuable";
        }

        if (encjugador.TengoEncendedor) //hasta que el jugador no tenga encendedor, no puede interactuar con este objeto
        {

            gameObject.GetComponent<BoxCollider>().enabled = true;
            

            if (!VelaEncendida) // Si vela apagada
            {

                if (jugador.ObjetoObservado == this.gameObject) // y me mira
                {
                    if (encjugador.Prendido) // y el encendedor ta on
                    {
                        if (Input.GetMouseButtonDown(0)) //y hace click
                        {

                            VelaEncendida = !VelaEncendida;
                            
                        }
                    }
                    
                    


                }

            }


        }
        else
        {

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.tag = "Untagged";
        }
    }
}
