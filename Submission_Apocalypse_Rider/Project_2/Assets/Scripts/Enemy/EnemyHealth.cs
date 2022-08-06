using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    private float startingHealth;
    
    [Header("Scene Variables")]
    private string sceneName;
    [Header("Animation_Object")]
    private Animator anim;
    public float currentHealth { get; private set; }
    private Collider2D enemyCollider;
    [Header("iFrame")]
    private float iFrameDuration = 1f;
    private int numberofFlashes = 1; //how many times the player flashes for hurt
    private SpriteRenderer spriteRend;  //change color of player to show invulnerability 

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        if (sceneName == "Scene1")
        {
            startingHealth = 5;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene2")
        {
            startingHealth = 10;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene3")
        {
            startingHealth = 15;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene4")
        {
            startingHealth = 20;
            currentHealth = startingHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        if (currentHealth <= 0)
        {
            //when dead want game to pause and GUIs to popup
            anim.SetTrigger("death");
            enemyCollider.isTrigger = true;

            //Destroy(gameObject);
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if (GetComponent<EnemyAttack>() != null)    //attack disable works
            {
                GetComponent<EnemyAttack>().enabled = false;
            }
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //invulnerabiilty duration
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
