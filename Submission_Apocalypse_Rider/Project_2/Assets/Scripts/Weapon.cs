using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    private Animator animate;
    private PlayerMovement playerMovement;
    public PlayerSFXManager playerSFXManager;

    [SerializeField] public float delayBetweenShots;
    float lastShotDate;
    // Start is called before the first frame update
    void Start()
    {
        lastShotDate = Time.time;
        animate = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && ((Time.time - lastShotDate) >  delayBetweenShots))
        {
            playerSFXManager.PlayShootingSFX();
            Shoot();
        }
 
    }
    private void Shoot()
    {
        animate.SetTrigger("attack");
        lastShotDate = Time.time;
        //shooting logic
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
    }
}


// Update is called once per frame
