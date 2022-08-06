using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;
    
    public Image[] hearts;
    private int lives;

    void Start()
    {
        totalHealth.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        //bc there are 10 total hearts
        currentHealth.fillAmount = playerHealth.currentHealth / 10; 
    }
}
