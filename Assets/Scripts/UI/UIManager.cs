using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] Text hungryText;
    [SerializeField] Text healthText;
    [SerializeField] Text statusText;
    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        hungryText.text = $"Hungry: {GameManager.Instance.GetPlayerHungry()}";
        healthText.text = $"Health: {GameManager.Instance.GetPlayerHealth()}";

        if (GameManager.Instance.GetPlayerHungry() == 0)
        {
            statusText.text = "You are starving!";
        }
        else
        {
            statusText.text = "";
        }

        if (GameManager.Instance.GetPlayerHealth() == 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
