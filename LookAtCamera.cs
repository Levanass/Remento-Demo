using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform targetCamera; // La cámara a la que la imagen debe mirar

    void Update()
    {
        // Hacer que la imagen mire hacia la cámara
        if (targetCamera != null)
        {
            transform.LookAt(targetCamera);
        }
    }
}
