using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public void ToMainMenu(){
        SceneManager.LoadScene("MainMenu");   
        Debug.Log("te fuiste pal mein meniu");
    }
}
