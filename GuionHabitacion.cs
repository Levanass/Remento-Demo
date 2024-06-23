using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuionHabitacion : MonoBehaviour
{
    public SwitchLuces SwitchHabitacion;
    public Image OjitoSw;
    public Image OjitoVela;
    public Image OjitoEnc;
    public Image OjitoEscondite;
    //public Image OjitoLiber;
    public Puerta PuertaHabit;
    public Inspeccionable VelaInsp;
    public GameObject VelaTutorial;
    public GameObject VelaNormal;
    public int Marcador = 0;
    public GameObject DetonadorEscondite;
    public Avisar AvisarVela;
    public GameObject DetonadorEncendedor;
    public Avisar AvisarEnc;
    public Inspeccionable EncInsp;
    public GameObject EncendedorProp;
    public Encendedor EncendedorJugador;
    //
    public GameObject CorteDeLuz;
    //public GameObject LiberLiminos;
    //
    public GameObject Enemigo;
    //
    public GameObject Velaerror;
    //
    public GameObject Reloj;

    // FASE 4 CORTE DE LUZ HABITACION HABILITAR
    void Start()
    {
        //velaerror
        Velaerror.GetComponent<BoxCollider>().enabled = false;
        //velaerror
        DetonadorEscondite.SetActive(false); //Desactiva Escondite

        OjitoVela.enabled=false;
        VelaInsp.enabled=false;
        OjitoEnc.enabled = false;
        OjitoEscondite.enabled = false;
        //OjitoLiber.enabled = true;
        VelaNormal.SetActive(false);

        PuertaHabit.NecesitoLlave = true; //La puerta de la habitación comienza cerrada

        VelaTutorial.GetComponent<BoxCollider>().enabled = false;
        DetonadorEncendedor.GetComponent<BoxCollider>().enabled = false;
    }

    
    void Update()
    {
        

        EncendedorJugador.UnidadesGasRestante = 20; // El gas no se gasta hasta que no termina el tutorial
        //---- FASE 0

        if (SwitchHabitacion.Encendido && Marcador==0) // Apenas el jugador aprenda a prender las luces
        {
            Destroy(OjitoSw); //Destruye el ojito
            VelaInsp.enabled = true; //Activa el script de la vela tutorial
            ActivarColliderVela();

            // Escondite
            OjitoEscondite.enabled = true;
            DetonadorEscondite.SetActive(true);

        }

        if (DetonadorEscondite.GetComponent<Avisar>().YaRevisado) // Si revise escondite, desactivar su ojo
        {
            OjitoEscondite.enabled = false;


        }

        //if (LiberLiminos.GetComponent<Avisar>().YaRevisado) // Si revise Liber, desactivar su ojo
        //{
        //    OjitoLiber.enabled = false;
        //}

        if (VelaInsp.enabled && !VelaInsp.ObjetoHablando && Marcador==1) // Si el script de la vela tutorial está activada y  está hablando
        {

            StartCoroutine(Esperar1segVela()); //
             //Activa el ojito para ir ahi
        }

        if (VelaInsp.enabled && VelaInsp.ObjetoHablando) // 
        {


            OjitoVela.enabled = false; //
        }

        if (Marcador==1)
        {

            // si la vela hablo entonces
            if (AvisarVela.YaRevisado)
            {
                ///escondite
                ///
                if (DetonadorEscondite.GetComponent<Avisar>().YaRevisado) // Si revise escondite, desactivar su ojo
                {
                    OjitoEscondite.enabled = false;

                    OjitoEnc.enabled = true; //Activa ojito encendedor
                    DetonadorEncendedor.GetComponent<BoxCollider>().enabled = true;//Activa Collider
                }
                //OjitoEnc.enabled = true; //Activa ojito encendedor
                //DetonadorEncendedor.GetComponent<BoxCollider>().enabled = true;//Activa Collider

            }
              
            
        }

        //----- FASE 2
        if (AvisarEnc.YaRevisado) // Si ya revise encendedor, 
        {
            
            StartCoroutine(DestruirOjitoEnc()); //<----
            Marcador = 2;

        }

        ///---- FASE 3
        if (Marcador==2 && !EncInsp.ObjetoHablando)
        {
            
            Marcador = 3;
        }

        if (Marcador==3)
        {
            ///Activa el encededor del jugador
            EncendedorJugador.TengoEncendedor = true;
            VelaTutorial.SetActive(false);
            //Destroy(OjitoVela);
            OjitoVela.enabled = false;
            VelaNormal.SetActive(true);
            /// Desactivar detonador escondite
            DetonadorEscondite.SetActive(false); ///// 

            if (!EncInsp.ObjetoHablando && AvisarEnc.YaRevisado)
            {
                DetonadorEncendedor.tag = "Untagged";
                EncendedorProp.SetActive(false);
                Marcador = 4;
            }
            
        }
        /// ----- FASE 4
        if (Marcador==4)
        {
            
            CorteDeLuz.SetActive(true);
            //
            if (CorteDeLuz.activeInHierarchy && VelaNormal.GetComponent<Vela>().VelaEncendida)
            {
                Marcador = 5;

            }
        }



        if (Marcador == 5)
        {
            StartCoroutine(EsperarElectricidad());
            Marcador = 6;
            //Reloj.GetComponent<Reloj>().EventoReloj = true;
        }

        if (Marcador == 6 && CorteDeLuz.GetComponent<CorteDeLuzHabitacion>().revertir)
        {
            Enemigo.SetActive(true);
            //velaerror
            Velaerror.GetComponent<BoxCollider>().enabled = true;
            //velaerror
            Reloj.GetComponent<Reloj>().EventoReloj = true; // <---
        }



    }

    // ----- FASE 1
    void ActivarColliderVela()
    {
        if (Marcador==0)
        {
            VelaTutorial.GetComponent<BoxCollider>().enabled = true;
            VelaTutorial.tag = "Interactuable";
            Marcador = 1; // Siguiente step
        }
        
    }


    /// ---- RUTINAS  <summary>
    /// 
    
    IEnumerator Esperar1segVela()
    {
        yield return new WaitForSeconds(1);
        OjitoVela.enabled = true;
    }

    IEnumerator DestruirOjitoEnc()
    {
        yield return new WaitForSeconds(1);
        Destroy(OjitoEnc);
       
    }

    IEnumerator EsperarElectricidad()
    {
        yield return new WaitForSeconds(10f);

        CorteDeLuz.GetComponent<CorteDeLuzHabitacion>().revertir = true;
        


    }

}
