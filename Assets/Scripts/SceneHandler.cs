using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private SceneAsset gameScene;
    [SerializeField] private SceneAsset emptyScene;

    private string gameSceneName;
    private string emptySceneName;

    private void Awake()
    {
        // Convert SceneAsset → scene name (only works in Editor)
#if UNITY_EDITOR
        gameSceneName = gameScene != null ? gameScene.name : "";
        emptySceneName = emptyScene != null ? emptyScene.name : "";
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleScene();
        }
    }

    private void ToggleScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == gameSceneName)
        {
            SceneManager.LoadScene(emptySceneName);
        }
        else
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}