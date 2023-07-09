using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject desactivar;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject quit;
    public GameObject pauseMenu;
    public static bool isPaused;
    StarterAssetsInputs starterAssets;
    //MouseLook mouseLook;
    
    void Start()
    {
        Cursor.visible = false;
        starterAssets = GameObject.Find("Player").GetComponent<StarterAssetsInputs>();
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                //starterAssets.cursorLocked = true;
                starterAssets.enabled = true;
                ResumeGame();
            }
            else
            {
                //starterAssets.cursorLocked = false;
                starterAssets.enabled = false;
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(resume);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
