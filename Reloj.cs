using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public AudioClip RelojTicking;
    public AudioClip RelojCampana;
    public bool EventoReloj;
    public AudioSource AudioReloj;
    //
    public ControladorVision controladorVision;

    void Update()
    {
        if (!AudioReloj.isPlaying)
        {
            AudioReloj.Play();
        }
        if (EventoReloj)
        {
            
            AudioReloj.clip = RelojCampana;
            AudioReloj.maxDistance = 20;
            //
            controladorVision.ActivarVision = true;

        } else
        {

            AudioReloj.clip = RelojTicking;
            AudioReloj.maxDistance = 9;
            //
            controladorVision.ActivarVision = false;
        }
    }


}
