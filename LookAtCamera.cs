using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform targetCamera; // La c�mara a la que la imagen debe mirar

    void Update()
    {
        // Hacer que la imagen mire hacia la c�mara
        if (targetCamera != null)
        {
            transform.LookAt(targetCamera);
        }
    }
}
