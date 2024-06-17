using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController doorController; // Referencia al script DoorController en la puerta
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar con la puerta

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(interactKey))
        {
            doorController.ToggleDoor();
        }
    }
}
