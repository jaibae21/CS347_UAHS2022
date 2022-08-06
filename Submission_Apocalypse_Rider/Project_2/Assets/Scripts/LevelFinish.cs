using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    public PlayerMovement player;
    public GameManager gameManager;

    public bool levelFinish { get; private set; }
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelFinish = true;
            gameManager.levelFinish();  //call the finish function
        }
    }
}
