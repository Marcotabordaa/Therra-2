using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CharacterImageManager : MonoBehaviour
{
    public List<Sprite> characterSprites; // Lista de sprites de personajes
    public Image characterImage; // Referencia a la imagen del UI para mostrar personajes
    public string mainMenuSceneName; // Nombre de la escena del menú principal

    private float timeBetweenSpawns = 10f; // Intervalo entre apariciones
    private float timer = 0f; // Temporizador para controlar el tiempo entre apariciones
    private int currentCharacterIndex = 0; // Índice del personaje actual

    void Start()
    {
        if (characterSprites == null || characterSprites.Count == 0)
        {
            Debug.LogError("No character sprites assigned!");
            return;
        }

        // Mostrar el primer personaje
        characterImage.sprite = characterSprites[currentCharacterIndex];
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Verificar si ha pasado el tiempo suficiente para mostrar un nuevo personaje
        if (timer >= timeBetweenSpawns)
        {
            ShowNextCharacter();
            timer = 0f;
        }

        // Verificar si se ha hecho clic
        if (Input.GetMouseButtonDown(0))
        {
            ReturnToMainMenu();
        }
    }

    void ShowNextCharacter()
    {
        if (characterSprites == null || characterSprites.Count == 0) return;

        // Mostrar el siguiente personaje
        currentCharacterIndex = (currentCharacterIndex + 1) % characterSprites.Count;
        characterImage.sprite = characterSprites[currentCharacterIndex];
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
