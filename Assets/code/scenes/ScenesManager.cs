using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public void cargarJuego() 
    {
        Cursor.visible=false;
        SceneManager.LoadScene("JuegoPlay");
    }

    public void cargarMenu() 
    {
        Cursor.visible=true;
        SceneManager.LoadScene("Menu");
    }

    public void cargarGameOver() 
    {
        Cursor.visible=true;
        SceneManager.LoadScene("GameOver");
    }

    public void salir() 
    {
        Application.Quit();
    }
}