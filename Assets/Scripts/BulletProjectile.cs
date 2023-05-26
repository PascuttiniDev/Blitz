using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidBody;
    ThirdPersonShooterController thirdPersonShooterController;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        thirdPersonShooterController = GameObject.Find("Player").GetComponent<ThirdPersonShooterController>();
        thirdPersonShooterController.currentbullets--;
        float speed = 40f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<BulletTarget>() != null)
        {
            // Hit target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        } else
        {
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}