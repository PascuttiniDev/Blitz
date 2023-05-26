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
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = false;
        EventSystem.current.SetSelectedGameObject(resume);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
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
