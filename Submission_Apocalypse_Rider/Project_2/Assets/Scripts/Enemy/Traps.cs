using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private float damage;
    private AudioSource collisionSound;

    private void Start()
    {
        damage = 0.5f;
        collisionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            collisionSound.Play();
        }
    }
}
