using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraLook : MonoBehaviour
{
    // Sensibilidad para el movimiento del mouse.
    [SerializeField] private float mouseSensitivity = 80f;

    // Referencia al cuerpo del jugador para la rotación horizontal.
    [SerializeField] private Transform playerBody;

    // Ángulo de rotación en el eje X.
    float xRotation = 0;

    void Start()
    {
    }

    void Update()
    {
        // Obtener el movimiento del mouse en los ejes X e Y.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Actualizar la rotación vertical en función del movimiento vertical del mouse.
        xRotation -= mouseY;

        //se utiliza Mathf.Clamp  para limitar el valor de xRotation entre -90 y 90 grados. 
        //Esto asegura que la rotación vertical de la cámara (mirada hacia arriba y abajo) se mantenga dentro de 
        //un rango que evita giros excesivos, como mirar directamente hacia arriba o hacia abajo.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplicar la rotación vertical a la cámara.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //  se utiliza para rotar el cuerpo del jugador 
        //horizontalmente basado en el movimiento horizontal del ratón
        playerBody.Rotate(Vector2.up * mouseX);
    }
}
