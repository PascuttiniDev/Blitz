using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderSimple : MonoBehaviour
{
    [SerializeField] private string staticScene = "StaticScene";
    [SerializeField] private string mainMenuScene = "MainMenuScene";
    [SerializeField] private string gameScene1 = "GameScene1";
    [SerializeField] private string gameScene2 = "GameScene2";
    [SerializeField] private string gameScene3 = "GameScene3";
    [SerializeField] private string gameScene4 = "GameScene4";
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject PauseMenu;


    private static SceneLoaderSimple instance;
    public static SceneLoaderSimple Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(mainMenuScene, LoadSceneMode.Additive);
        UI.SetActive(false);
        PauseMenu.SetActive(false);
        Cursor.visible = true;

    }

    public void RemoveMainMenu()
    {
        SceneManager.UnloadSceneAsync(mainMenuScene);
        UI.SetActive(true);
        PauseMenu.SetActive(true);
        Cursor.visible = false;
    }

    public void LoadGameScene1()
    {
        SceneManager.LoadSceneAsync(gameScene1, LoadSceneMode.Additive);

    }
    public void RemoveGameScene1()
    {
        SceneManager.UnloadSceneAsync(gameScene1);
    }

    public void LoadGameScene2()
    {
        SceneManager.LoadSceneAsync(gameScene2, LoadSceneMode.Additive);

    }
    public void RemoveGameScene2()
    {
        SceneManager.UnloadSceneAsync(gameScene2);
    }

    public void LoadGameScene3()
    {
        SceneManager.LoadSceneAsync(gameScene3, LoadSceneMode.Additive);

    }
    public void RemoveGameScene3()
    {
        SceneManager.UnloadSceneAsync(gameScene3);
    }
}
