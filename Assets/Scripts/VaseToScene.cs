using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VaseToScene : MonoBehaviour
{
    public GameObject interactText; // текст "Press E"
    public string sceneName = "Main"; // имя сцены для перехода
    public bool opensChest = true; // если true, будет открывать сундук
    public bool changeScene = false; // если true, будет переходить на сцену

    private bool playerInRange = false;
    private bool chestOpened = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (opensChest && !chestOpened)
            {
                OpenChest();
            }

            if (changeScene)
            {
                LoadScene();
            }
        }
    }

    void OpenChest()
    {
        chestOpened = true;
        interactText.SetActive(false);
        Debug.Log("Chest opened");
        LoadScene();
        // Тут можно добавить анимацию, лут, звук и т.д.
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactText != null)
                interactText.SetActive(false);
        }
    }
}