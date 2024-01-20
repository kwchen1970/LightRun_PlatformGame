using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        shootSoundEffect.Play();
        animator.SetTrigger("Shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
