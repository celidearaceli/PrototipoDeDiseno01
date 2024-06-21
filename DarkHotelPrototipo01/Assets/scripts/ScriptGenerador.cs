using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGenerador : MonoBehaviour
{

    public GameObject objetivo;
    // Variable para representar el objeto generador
    public GameObject ascensor;
    public TextMeshProUGUI textAdvertencia;
    void Start()
    {
        // Asegurarse de que el generador esté desactivado al inicio
        if (ascensor != null)
        {
            ascensor.SetActive(false);
        }

        objetivo.SetActive(true);
    }

   
    void Update()
    {

    }

    /*Este metodo se llama cuando el objeto colisiona con otro objeto en el juego. Si el objeto colisiona con un objeto que tenga la etiqueta "Jugador", 
     * se llama a la funcion SumarPuntos del script ScriptGameManager.instance, y luego se destruye el objeto.*/
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            ascensor.SetActive(true);
            objetivo.SetActive(false);
            textAdvertencia.text = "Escapa o Muere";
        }

    }
}
