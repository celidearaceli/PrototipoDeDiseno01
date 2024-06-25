using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Patrol : MonoBehaviour
{
    public NavMeshAgent myNavMeshAgent;
    public GameObject personajePrincipal;
    public Transform[] puntosPatrol;
    public float maxDistance = 10.0f;
    private int currentPosition;
    private bool isPatrolling = true;

    void Start()
    {
        currentPosition = Random.Range(0, puntosPatrol.Length);
        myNavMeshAgent.SetDestination(puntosPatrol[currentPosition].position);
    }

    void Update()
    {
        if (isPatrolling)
        {
            if (myNavMeshAgent.remainingDistance < 0.1)
            {
                currentPosition = (currentPosition + 1) % puntosPatrol.Length;
                myNavMeshAgent.SetDestination(puntosPatrol[currentPosition].position);
            }

            float distance = Vector3.Distance(personajePrincipal.transform.position, transform.position);

            if (distance < maxDistance)
            {
                isPatrolling = false; // Deja de patrullar
                myNavMeshAgent.SetDestination(personajePrincipal.transform.position);
            }
        }
        else // Está persiguiendo al jugador
        {
            float distance = Vector3.Distance(personajePrincipal.transform.position, transform.position);

            if (distance > maxDistance)
            {
                isPatrolling = true; // Vuelve a patrullar
                currentPosition = Random.Range(0, puntosPatrol.Length);
                myNavMeshAgent.SetDestination(puntosPatrol[currentPosition].position);
            }
            else
            {
                myNavMeshAgent.SetDestination(personajePrincipal.transform.position);
            }
        }
    }

    // Método para detectar colisiones
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == personajePrincipal)
        {
            CambiarEscena();
        }
    }

    // Método para cambiar de escena
    void CambiarEscena()
    {
        // Puedes cambiar de escena por nombre o por índice de build
        SceneManager.LoadScene("NombreDeTuEscena");
        // O puedes usar el índice de build de la escena:
        // SceneManager.LoadScene(1); // Cambia al índice de build correcto de tu escena
    }
}