using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroductionManager : MonoBehaviour
{
    public GameObject introductionPanel;  // Panel que muestra la introducción
    public AudioSource introductionAudio; // Audio de la introducción
    public string nextSceneName;          // Nombre de la escena del juego
    public Image blackScreen;             // Imagen negra para la transición

    private bool hasStarted = false;

    void Start()
    {
        blackScreen.gameObject.SetActive(false); // Asegurarse de que la pantalla negra esté oculta al inicio
        StartCoroutine(ShowIntroduction());
    }

    private IEnumerator ShowIntroduction()
    {
        // Mostrar el panel de introducción
        introductionPanel.SetActive(true);

        // Reproducir el audio de introducción
        introductionAudio.Play();

        // Esperar hasta que el audio termine de reproducirse
        while (introductionAudio.isPlaying)
        {
            yield return null;
        }

        // Ocultar el panel de introducción
        introductionPanel.SetActive(false);

        // Iniciar la transición a la siguiente escena
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            StartCoroutine(ShowBlackScreenAndLoadScene(nextSceneName));
        }
    }

    void Update()
    {
        // Opción para omitir la introducción al presionar una tecla
        if (!hasStarted && Input.anyKeyDown)
        {
            hasStarted = true;
            StopAllCoroutines();
            introductionAudio.Stop();
            introductionPanel.SetActive(false);
            StartCoroutine(ShowBlackScreenAndLoadScene(nextSceneName));
        }
    }

    private IEnumerator ShowBlackScreenAndLoadScene(string sceneName)
    {
        blackScreen.gameObject.SetActive(true); // Activar la pantalla negra
        yield return null; // Esperar un frame para asegurarse de que la pantalla negra se muestra
        SceneManager.LoadScene(sceneName); // Cargar la siguiente escena
    }
}
