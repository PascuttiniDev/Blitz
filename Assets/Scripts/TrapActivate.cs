using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivate : MonoBehaviour
{
    public GameObject Trap;
    GameManager gameManager;
    public KeyCode interact = KeyCode.E;
    public float TrapTimer;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Trap.SetActive(false);
    }

    IEnumerator TrapTime()
    {
        yield return new WaitForSeconds(TrapTimer);
        Trap.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            if(Input.GetKeyDown(interact) && gameManager.points >= 1500)
            {
                Trap.SetActive(true);
                gameManager.points = gameManager.points - 1500;
                StartCoroutine(TrapTime());
            }
        }
    }
}