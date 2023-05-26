using UnityEngine;
public class EnemyDamage : MonoBehaviour
{
    public GameManager gameManager;
    public int hitNumber;
    public GameObject bullets;
    float randomFloat;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnEnable()
    {
        hitNumber = 0;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.
        CompareTag("bullet"))
        {
            //If the comparison is true, we increase the hit number.
            hitNumber++;
        }
        if (hitNumber == 3)
        {
            Death();
        }
    }

    public void Death()
    {
        gameManager.AddPoints(10);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        randomFloat = Random.value;
    }

    private void OnDisable()
    {
        if (randomFloat >= 0.5f)
            Instantiate(bullets, transform.position, bullets.transform.rotation); //your dropped sword
    }

}