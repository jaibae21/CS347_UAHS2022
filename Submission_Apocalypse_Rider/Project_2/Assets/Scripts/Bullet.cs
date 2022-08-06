using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    private int damage = 5; //defaulted for now
    private bool hit;
    private float lifetime;

    [Header("Scene Variables")]
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //tell bullet to fly
        rb.velocity = transform.right * speed;
        if (sceneName == "Scene1")
        {
            damage = 2;
        }
        else if (sceneName == "Scene2") //probably add additional condition for if player chooses to buff their attack
        {

        }
        else if (sceneName == "Scene3")
        {

        }
        else if (sceneName == "Scene4")
        {

        }
    }
    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 1.5)
        {
            //gets rid of bullet if it misses an enemy and flies off screen
            Destroy(gameObject);
            lifetime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        lifetime = 0;   //reset lifetime
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
