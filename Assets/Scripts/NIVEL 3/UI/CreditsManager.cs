using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreditsManager : MonoBehaviour
{
    public GameObject creditPanel; // Panel que contiene las imágenes de créditos
    public List<GameObject> creditImages; // Lista de imágenes de créditos
    public float displayTime = 10f; // Tiempo para mostrar cada imagen
    public AudioSource backgroundAudio; // Audio de fondo
    public string mainMenuSceneName = "MainMenu"; // Nombre de la escena del menú principal
    public Image blackScreen; // Imagen negra para transición

    private int currentImageIndex = 0;

    void Start()
    {
        // Iniciar el audio de fondo
        if (backgroundAudio != null && backgroundAudio.clip != null)
        {
            backgroundAudio.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned.");
        }

        // Mostrar el primer panel de crédito
        StartCoroutine(ShowCreditSequence());
    }

    private IEnumerator ShowCreditSequence()
    {
        // Asegurarse de que el panel esté activo
        creditPanel.SetActive(true);

        while (currentImageIndex < creditImages.Count)
        {
            // Mostrar la imagen actual
            ShowCreditImage(currentImageIndex);
            yield return new WaitForSeconds(displayTime);
            // Ocultar la imagen actual
            HideCreditImage(currentImageIndex);
            currentImageIndex++;
        }

        // Ocultar el panel de crédito
        creditPanel.SetActive(false);

        // Mostrar la pantalla en negro
        if (blackScreen != null)
        {
            blackScreen.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f); // Pausa para mostrar la pantalla en negro
        }

        // Regresar al menú principal después de mostrar todas las imágenes
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void ShowCreditImage(int index)
    {
        if (index < creditImages.Count)
        {
            creditImages[index].SetActive(true);
        }
    }

    private void HideCreditImage(int index)
    {
        if (index < creditImages.Count)
        {
            creditImages[index].SetActive(false);
        }
    }
}
