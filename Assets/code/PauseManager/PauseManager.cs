using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool activo;
    private float velocidadJuego;

    void Awake() 
    {
        pauseMenuUI.SetActive(false);
        activo = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!activo) {
                Debug.Log("Le entro");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Mostramos el menu de pause
        pauseMenuUI.SetActive(true);

        // Guardamos la velocidad del juego por si esta actibo el powerup tempus
        velocidadJuego = Time.timeScale;
        Time.timeScale = 0f;
        activo = true;
    }

    public void ResumeGame()
    {
        // Quitamos el menu de pause
        pauseMenuUI.SetActive(false);

        // Restablecemos el tiempo de juego a como estaba
        Time.timeScale = velocidadJuego;
        activo = false;
    }

    public void QuitGame()
    {
        // Cerramos la aplicacion
        Application.Quit();
    }
}
