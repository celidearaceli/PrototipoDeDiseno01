using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptAscensor : MonoBehaviour
{
    /* Variable privada que representa la velocidad en el eje X*/
    //[SerializeField] private float velocidadY = 1f;
    /*Es una variable privada que indica la posición inicial en el eje X.*/
   //[SerializeField] private float finalPosicionY = -30f;





    void Start()
    {

    }

    // Update is called once per frame
    /*En el metodo Update() mueve el GameObject  a lo largo del eje X utilizando Translate.
     * Luego, verifica si la posición actual en el eje X es mayor o igual a finalPosicionX o menor o igual a inicialPosicionX. 
     * Si es así, invierte la dirección de movimiento multiplicando velocidadZ por -1.*/
    void Update()
    {
      /*  transform.Translate(0, velocidadY * Time.deltaTime, 0);

        if (transform.position.y >= finalPosicionY)
        {

            velocidadY = velocidadY * -1f;

        }*/


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            SceneManager.LoadScene("YouWin");

        }


    }
}
