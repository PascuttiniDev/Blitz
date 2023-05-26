using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets : MonoBehaviour
{
    ThirdPersonShooterController thirdPersonShooterController;
    DestroyAmmo destroyAmmo;
    private void Start()
    {
        destroyAmmo = GetComponentInParent<DestroyAmmo>();
        thirdPersonShooterController = GameObject.Find("Player").GetComponent<ThirdPersonShooterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thirdPersonShooterController.currentbullets = thirdPersonShooterController.currentbullets + 20;
            destroyAmmo.MuerteALasBalas();
        }
    }
}
