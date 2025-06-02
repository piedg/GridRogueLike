using UnityEngine;

public class Food : GridObject, IConsumable
{
    [SerializeField] private int valueAmount;
    
    public void Use(Player player)
    {
        player.GetHungryStat().AddValue(valueAmount);
        Destroy(gameObject);
    }
}
