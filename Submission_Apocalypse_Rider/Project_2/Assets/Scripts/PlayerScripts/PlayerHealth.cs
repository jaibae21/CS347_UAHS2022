using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    private float startingHealth;
    [Header("Scene Variables")]
    private string sceneName;
    public float currentHealth { get; private set; }
    [Header("iFrame")]
    private float iFrameDuration = 2f;
    private int numberofFlashes = 1; //how many times the player flashes for hurt
    private SpriteRenderer spriteRend;  //change color of player to show invulnerability 
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        spriteRend = GetComponent<SpriteRenderer>();
        if (sceneName == "Scene1")
        {
            startingHealth = 3;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene2") //probably add additional condition for if player chooses to buff their health
        {
            //for now just gonna put default of 5 for the rest of the levels
            startingHealth = 5;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene3")
        {
            startingHealth = 5;
            currentHealth = startingHealth;
        }
        else if (sceneName == "Scene4")
        {
            startingHealth = 5;
            currentHealth = startingHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //testing the system
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    TakeDamage(1);
        //}
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            StartCoroutine(Invunerability());
        }
        if(currentHealth <= 0)
        {
            //when dead want game to pause and GUIs to popup
            Time.timeScale = 0.1f;
            new WaitForSeconds(10);
            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
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
