using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : GridObject, IConsumable
{
    [SerializeField] private int valueAmount;
    public int ValueAmount => valueAmount;

    public void Use(Player player)
    {
        player.GetHungryStat().AddValue(valueAmount);
        Destroy(gameObject);
    }
}
