using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] Text hungryText;
    [SerializeField] Text healthText;
    [SerializeField] Text statusText;
    
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] private Text winPanelText;
    [SerializeField] private Text winPanelSecondaryText;
    
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        UpdateStatsUI();
        OpenGameOverPanel();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloseWinPanel();
        }
    }

    private void CloseWinPanel()
    {
        winPanel.SetActive(false);
    }

    private void OpenGameOverPanel()
    {
        if (GameManager.Instance.GetPlayerHealth() == 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
    
    private void UpdateStatsUI()
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
    }

    public void UpdateWinPanel(bool isDoorOpen)
    {
        if (isDoorOpen)
        {
            winPanelText.text = "YOU ESCAPED!";
            winPanelSecondaryText.text = "PRESS <R> TO RESTART";
        }
        else
        {
            winPanelText.text = "YOU NEED A KEY";
            winPanelSecondaryText.text = "PRESS <SPACE> TO CONTINUE";
        }
        winPanel.SetActive(true);
    }
}
