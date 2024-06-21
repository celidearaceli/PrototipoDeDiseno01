using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    /*Esto declara una variable publica de tipo TextMeshProUGUI llamada puntos. 
      * Se utiliza para mostrar informaci?n textual en la interfaz de usuario del juego.*/
    public TextMeshProUGUI puntos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*En el metodo update Verifica la escena activa y actualizar el texto de puntos en consecuencia.
     */
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            puntos.text = " Fusibles: " + ScriptGameManager.instance.PuntosTotales.ToString() + "/7";

            if (ScriptGameManager.instance.PuntosTotales == 7)
            {
                puntos.text = "Enciende el Generador";
            }

        }



    }
    /*Este es un metodo publico que permite actualizar el texto del objeto puntos. 
     * Toma un argumento puntosTotales y establece el texto del objeto puntos en el valor de puntosTotales.*/
    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }
}
