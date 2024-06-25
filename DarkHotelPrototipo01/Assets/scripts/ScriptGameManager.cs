using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameManager : MonoBehaviour
{
    /*Variable tipo Hud para representar el objeto Hud de nuestro juego*/
    public HUD hud;
    /*Esto declara una propiedad estatica llamada instance que permite acceder a una instancia ?nica de la clase ScriptGameManager. 
     * El acceso a la instancia es a traves de ScriptGameManager.instance.*/
    public static ScriptGameManager instance { get; private set; }
    /*Esto declara una propiedad publica llamada PuntosTotales que proporciona acceso a la variable privada puntosTotales. 
     * Esto permite a otras clases obtener el valor de puntos totales sin modificarlo directamente.*/
    public int PuntosTotales { get { return puntosTotales; } }
    /*Esta variable privada almacena la cantidad total de puntos en el juego.*/
    private int puntosTotales;

    // Variable para representar el objeto generador
    public GameObject generador;

    public GameObject ascensor;

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el generador esté desactivado al inicio
        if (generador != null)
        {
            Time.timeScale = 1.0f;
            generador.SetActive(false);
            ascensor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*Este metodo se llama al comienzo de la ejecucion del juego, antes del metodo Start. 
     * Se comprueba si ya existe una instancia de ScriptGameManager y, en caso contrario, se establece esta instancia como la actual. 
     * Esto garantiza que solo haya una instancia de ScriptGameManager en la escena.*/
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }
    /*Este metodo se utiliza para agregar puntos al puntaje total del jugador. Se suma la cantidad puntosASumar a puntosTotales,
     se actualiza la interfaz de usuario a traves de hud, y se verifica si el jugador ha alcanzado ciertos puntos en escenas especificas
     para cargar escena YouWIn*/
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
        hud.ActualizarPuntos(puntosTotales);

        if (puntosTotales == 7 && generador != null)
        {
            generador.SetActive(true);
        }
        /* if (SceneManager.GetActiveScene().name == "Level1" && puntosTotales >= 1)
         {
             SceneManager.LoadScene("YouWin");
         }*/


    }

    /*Este m?todo se utiliza para restar puntos al puntaje total del jugador. Se suma la cantidad puntosASumar a puntosTotales,
    se actualiza la interfaz de usuario a traves de hud, y se verifica si el jugador ha alcanzado ciertos puntos en escenas especificas
    para cargar pantalla gameover.*/
    public void RestarPuntos()
    {
        puntosTotales--;

        Debug.Log(puntosTotales);
        hud.ActualizarPuntos(puntosTotales);
        if (puntosTotales <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
