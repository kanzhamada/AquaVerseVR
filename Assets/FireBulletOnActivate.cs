using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    public GameObject muzzlePrefab;
    public GameObject muzzlePosition;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg){
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;

        // Destroy the bullet after a certain period of time
        Destroy(spawnedBullet, 5);

        // Make the muzzle flash
        var flash = Instantiate(muzzlePrefab, muzzlePosition.transform.position, Quaternion.identity);
        // Destroy the flash after a certain period of time
        Destroy(flash, 0.1f);
    }

}
