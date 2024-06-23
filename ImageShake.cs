using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageShake : MonoBehaviour
{
    public float shakeAmount = 0.1f; // La cantidad m�xima de temblor
    public float shakeSpeed = 50f; // La velocidad de temblor

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Generar un desplazamiento aleatorio en las coordenadas X e Y
        float offsetX = Random.Range(-shakeAmount, shakeAmount);
        float offsetY = Random.Range(-shakeAmount, shakeAmount);

        // Calcular la nueva posici�n con el temblor
        Vector3 shakePosition = originalPosition + new Vector3(offsetX, offsetY, 0);

        // Asignar la nueva posici�n a la imagen
        transform.position = Vector3.Lerp(transform.position, shakePosition, Time.deltaTime * shakeSpeed);
    }
}
