using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawners
{
    public GameObject go;
    public bool active;
    public Spawners(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}


public class GameManager : MonoBehaviour
{

    public GameObject panel;
    public delegate void RestartRounds();
    public static event RestartRounds RoundComplete;
    private int health;
    private int roundsSurived;
    private int currentRound;
    public int points;
    [SerializeField] private Text pointsText;
    private PlayerDamage playerDamage;
    private Text panelText;
    public List<Spawners> spawner = new List<Spawners>();

    void Start()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        playerDamage = GameObject.Find("Player").GetComponent<PlayerDamage>();
        panelText = panel.GetComponentInChildren<Text>();

        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name.Contains("Spawner"))
            {
                spawner.Add(new Spawners(go, true));
            }
        }
    }

    void Update()
    {
        int total = 0;
        pointsText.text = points.ToString();
        health = playerDamage.health;
        if (health > 0)
        {
            for (int i = spawner.Count - 1; i >= 0; i--)
            {
                if (spawner[i].go.GetComponent<Spawner>().spawnsDead)
                {
                    total++;
                }
            }

            if (total == spawner.Count && roundsSurived == currentRound)
            {
                roundsSurived++;
                panelText.text = string.Format("Round {0} Completed!", roundsSurived);
                panel.SetActive(true);
            }


            if (roundsSurived != currentRound && Input.GetKey(KeyCode.Return))
            {
                currentRound = roundsSurived;
                RoundComplete();
                panel.SetActive(false);
            }
        }
        else
        {
            Death();
        }
    }
    public void Death()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.name);
        }
        else
        {
            panel.SetActive(true);
            panelText.text = string.Format("Survived {0} Rounds", roundsSurived);
            Time.timeScale = 0;
        }
    }

    public void AddPoints(int number)
    {
        points = points + number;
    }
    public void QuitPoints()
    {
        points = 0;
    }
}
