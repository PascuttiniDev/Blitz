using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;



public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform spawnBulletPositionBurst;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject pistolBurst;


    public AudioClip sonido;
    public Text ammoText;
    private AudioSource audioSource;
    public Vector3 mouseWorldPosition;
    bool shootingTime = true;
    public int currentbullets;
    public bool rafagas = true;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;


    void Start()
    {
        currentbullets = 50;
        audioSource = GetComponentInParent<AudioSource>();
    }
    private void Awake()
    {
        thirdPersonController = GetComponentInParent<ThirdPersonController>();
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInParent<Animator>();

    }

    

    private void Update()
    {
        ammoText.text = currentbullets.ToString();
        mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && pistol.activeSelf == true && pistolBurst.activeSelf == false) // forward
        {
            pistol.SetActive(false);
            pistolBurst.SetActive(true);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && pistol.activeSelf == false && pistolBurst.activeSelf == true) // backwards
        {
            pistol.SetActive(true);
            pistolBurst.SetActive(false);
        }

        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }

        else
        {
            //Debug.Log("estas en un lio");
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (Input.GetMouseButtonDown(0) && starterAssetsInputs.aim && currentbullets > 0 && pistol.activeSelf == true && pistolBurst.activeSelf == false)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
        if (Input.GetMouseButtonDown(0) && starterAssetsInputs.aim && currentbullets > 0 && pistol.activeSelf == false && pistolBurst.activeSelf == true)
        {
  
                StartCoroutine(Disparar());
                Debug.Log("pene");
                rafagas = false;
            
        }

        if (currentbullets > 90)
        {
            currentbullets = 90;
        }

    }
    IEnumerator Disparar()
    {
        Debug.Log("Peneson");
        Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
        Instantiate(pfBulletProjectile, spawnBulletPositionBurst.position, Quaternion.LookRotation(aimDir, Vector3.up));
        yield return new WaitForSeconds(0.1f);
        Instantiate(pfBulletProjectile, spawnBulletPositionBurst.position, Quaternion.LookRotation(aimDir, Vector3.up));
        yield return new WaitForSeconds(0.1f);
        Instantiate(pfBulletProjectile, spawnBulletPositionBurst.position, Quaternion.LookRotation(aimDir, Vector3.up));
        yield return new WaitForSeconds(0.1f);
        rafagas = true;

    }
}