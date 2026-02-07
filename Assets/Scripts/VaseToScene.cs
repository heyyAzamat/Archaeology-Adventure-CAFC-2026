using UnityEngine;
using UnityEngine.SceneManagement;

public class VaseToScene : MonoBehaviour
{
    public string sceneName = "Main";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
