using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorteDeLuzHabitacion : MonoBehaviour
{
    public GameObject LamparaPiePrendido;
    public GameObject LamparaPieApagado;
    public GameObject LuzPie;
    public GameObject LamparaParedPrendido;
    public GameObject LamparaParedApagado;
    public GameObject LuzPared;
    /// Luz de techo
    public SwitchLuces TechoScript;
    public GameObject TechoEncendido;
    public GameObject TechoApagado;
    public GameObject LuzTecho;
    public GameObject SwitchVerde;
    // Cositas Sueltas
    public GameObject Boton;
    /// 
    public bool revertir;
    //
    public AudioSource audiocorteluz;
    private void Update()
    {
        if (revertir)
        {
            LamparaParedPrendido.SetActive(true);
            LamparaParedApagado.SetActive(false);

            LamparaPiePrendido.SetActive(true);
            LamparaPieApagado.SetActive(false);

            //techo
            TechoScript.Encendido = true; //<----
            TechoScript.enabled = true;
            TechoEncendido.SetActive(true);
            TechoApagado.SetActive(false);
            LuzTecho.SetActive(true);
            SwitchVerde.SetActive(true);
            //
            Boton.SetActive(true);

            // Si ya revirtio, destruirse para evitar problemas.
            gameObject.GetComponent<CorteDeLuzHabitacion>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {
            LamparaParedPrendido.SetActive(false);
            LamparaParedApagado.SetActive(true);

            LamparaPiePrendido.SetActive(false);
            LamparaPieApagado.SetActive(true);

            //techo
            TechoScript.Encendido = false; //<----
            TechoScript.enabled = false;
            TechoEncendido.SetActive(false);
            TechoApagado.SetActive(true);
            LuzTecho.SetActive(false);
            SwitchVerde.SetActive(false);
            //
            Boton.SetActive(false);
            //
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            //
            audiocorteluz.Play();
        }
    }
}
