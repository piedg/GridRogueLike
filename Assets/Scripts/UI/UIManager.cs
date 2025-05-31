using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] Text hungryText;
    [SerializeField]  Text healthText;

    private void Update()
    {
        hungryText.text = $"Hungry: {GameManager.Instance.GetPlayerHungry()}";
        healthText.text = $"Health: {GameManager.Instance.GetPlayerHealth()}";
    }
}
