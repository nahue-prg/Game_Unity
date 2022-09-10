using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIJuego : MonoBehaviour
{
    public Text vidasPerdidas;
    public Text avisoInteraccion;
    public Text terminoElJuego;

    public static bool mostrar;
    public static bool JuegoTerminado = false;

    private bool pauseActive;
    public GameObject pauseMenu;
    public GameObject gameOverM;


    // Start is called before the first frame update
    void Start()
    {
        avisoInteraccion.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        vidasPerdidas.text = "Vidas perdidas: " + GameManager.scoreLostLifes.ToString();
        mostrarAviso();
        togglePause();
        gameOver();
    }

    public void mostrarAviso() {
        if (mostrar)
        {
            avisoInteraccion.enabled = true;
        }
        else avisoInteraccion.enabled = false;

    }


    public void gameOver()
    {
        if (JuegoTerminado)
        {
            gameOverM.SetActive(true);
            terminoElJuego.text = "Game Over \n Vidas Perdidas: " + GameManager.scoreLostLifes.ToString();
            Time.timeScale = 0;
        }
        else
        {

        }

    }

    public void togglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }

    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }

    public void pauseGame ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;           //Congela el tiempo del juego (no transcurren frames)
        pauseActive = true;
    }

    public void IrMenuPrincipal()
    {
        GameManager.scoreLostLifes = 0;
        JuegoTerminado = false;
        gameOverM.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
