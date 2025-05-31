using UnityEngine;

public class Heal : GridObject, IConsumable
{
    [SerializeField] private int valueAmount;

    public void Use(Player player)
    {
        player.GetHealthStat().AddValue(valueAmount);
        Destroy(gameObject);
    }
}