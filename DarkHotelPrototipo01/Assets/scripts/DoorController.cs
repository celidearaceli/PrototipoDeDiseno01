using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    public Transform doorHinge; // El punto alrededor del cual la puerta gira
    public float openAngle = 90f; // El ángulo al que se abrirá la puerta
    public float openSpeed = 2f; // La velocidad a la que se abrirá la puerta
    private bool isOpen = false; // Estado de la puerta (abierta o cerrada)
    private Quaternion closedRotation; // Rotación original de la puerta
    private Quaternion openRotation; // Rotación de la puerta cuando está abierta

    void Start()
    {
        closedRotation = doorHinge.localRotation;
        openRotation = Quaternion.Euler(doorHinge.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isOpen)
        {
            doorHinge.localRotation = Quaternion.Slerp(doorHinge.localRotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            doorHinge.localRotation = Quaternion.Slerp(doorHinge.localRotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
