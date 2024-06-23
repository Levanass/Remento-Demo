using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inspeccionable : MonoBehaviour
{
    
    Camera CamJugador;
    Camera CamObjeto;
    public float Trans_speed = 1f;
    Image Transition;
    [SerializeField] private bool Negro;
    [SerializeField] private bool Blanco;
    //texto
    Raycast_Jugador jugador;
    //[SerializeField] private string TextoDeEsteObjeto = "";
    public string TextoDeEsteObjeto = "";
    TMP_Text Mostrador;
    //[SerializeField] private bool ObjetoHablando;
    public bool ObjetoHablando;
    FirstPersonMovement MovimientoJugador;
    

    void Start()
    {
        // cam
        CamJugador = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CamObjeto = this.gameObject.transform.GetChild(0).GetComponent<Camera>();
        CamObjeto.enabled = false;
        //trans
        
        // text
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Raycast_Jugador>();
        Mostrador = GameObject.Find("MostradorTextos").GetComponent<TMP_Text>();
        Mostrador.text = "";
        Mostrador.GetComponent<CanvasGroup>().alpha = 0f;
        //
        Transition = GameObject.Find("Transition").GetComponent<Image>();
        Transition.GetComponent<CanvasGroup>().alpha = 0f;
        //
        //rigijuga = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        MovimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonMovement>();

    }

    void Update()
    {
        if (Blanco && Negro) //errores --> Apagar todo
        {
            CamJugador.enabled = true;
            CamObjeto.enabled = false;
            Transition.GetComponent<CanvasGroup>().alpha = 0f;
            Mostrador.GetComponent<CanvasGroup>().alpha = 0f;
            Mostrador.text = "";
            gameObject.GetComponent<Inspeccionable>().ObjetoHablando = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            Blanco = false;
            Negro = false;
        }


        if (jugador.ObjetoObservado == this.gameObject) // me mira
        {
            if (Input.GetMouseButtonDown(0)) // click
            {
                //Mostrador.GetComponent<CanvasGroup>().alpha = 0;

                gameObject.GetComponent<Inspeccionable>().ObjetoHablando = !gameObject.GetComponent<Inspeccionable>().ObjetoHablando; // Switch Obj Hablando

                this.gameObject.GetComponent<BoxCollider>().enabled = false; // desactiva collider para evitar errores

                this.gameObject.tag = "Vacio"; // cambia tag temporalmente para esconder punteros

                
            }


        }


        if (this.gameObject.GetComponent<Inspeccionable>().ObjetoHablando)
        {
            ONOFF();
            

            if (CamJugador.enabled)
            {
                CamJugador.GetComponent<FirstPersonLook>().enabled = false;
                //
                MovimientoJugador.GetComponent<FirstPersonMovement>().enabled = false;//<---------------------

                Blanco = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;

                
            }
            else
            {
                
                //Mostrador.GetComponent<CanvasGroup>().alpha += Time.deltaTime * Trans_speed;
            }
            //Textos
            if (Mostrador.text == "")
            {
                Mostrador.text = gameObject.GetComponent<Inspeccionable>().TextoDeEsteObjeto;
                Mostrador.GetComponent<CanvasGroup>().alpha = 0;
            }



        } else
        {
            ONOFF();


            if (CamObjeto.enabled)
            {
                CamJugador.GetComponent<FirstPersonLook>().enabled = true;
                Blanco = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                //Mostrador.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * Trans_speed;
                MovimientoJugador.GetComponent<FirstPersonMovement>().enabled = true; //<---------------------
            }
            else
            {
                //Mostrador.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * Trans_speed * 2;
            }
            //Textos
            if (Mostrador.text == gameObject.GetComponent<Inspeccionable>().TextoDeEsteObjeto && CamJugador.enabled) // Y el mostrador es el texto de este objeto
            {
                Mostrador.text = "";
                Mostrador.GetComponent<CanvasGroup>().alpha = 0;
                this.gameObject.tag = "Interactuable";
            }
        }
    }

    void ONOFF()
    {
        if (Blanco)
        {
            Transition.GetComponent<CanvasGroup>().alpha += Time.deltaTime * Trans_speed;
            Mostrador.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * Trans_speed;

            if (Transition.GetComponent<CanvasGroup>().alpha == 1f)
            {

                CamJugador.enabled = !CamJugador.enabled;
                CamObjeto.enabled = !CamObjeto.enabled;
                Blanco = false;
                Negro = true;
                

            }

        }

        if (Negro)
        {
            Transition.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * Trans_speed;
            Mostrador.GetComponent<CanvasGroup>().alpha += Time.deltaTime * Trans_speed;

            if (Transition.GetComponent<CanvasGroup>().alpha == 0f)
            {
                
                Negro = false;
                //textos
            }
        }
        
    }


}
