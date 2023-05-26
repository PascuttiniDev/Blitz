using UnityEngine;
using System.Collections;

public class SendDamage : MonoBehaviour
{
    bool IsInside = false;
    bool OnTime = true;
    public int damage = 25;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsInside = true;
        }
        
        if ((IsInside && OnTime) == true && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerDamage>().ApplyDamage(damage);
            OnTime = false;
            StartCoroutine(Damage());
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsInside = false;
        }
    }
    IEnumerator Damage()
    {
        yield return new WaitForSeconds(1f);
        OnTime = true;
    }
}

