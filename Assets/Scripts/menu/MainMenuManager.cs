using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("IntroductionScene"); // Cambia "IntroductionScene" por el nombre real de tu escena de introducción
    }

    public void ShowCredits()
    {
        // Implementa la lógica para mostrar los créditos
        SceneManager.LoadScene("CreditScene");
    }

    public void ShowCharacters()
    {
        // Implementa la lógica para mostrar los personajes
        SceneManager.LoadScene("Personajes");
    }

    public void QuitGame()
    {
        // Salir del juego
        Application.Quit();
        Debug.Log("QuitGame clicked");
    }
}
