using UnityEngine;

public class DoorKey : GridObject, IConsumable
{
    [SerializeField] Door _door;

    public void Use(Player player)
    {
        _door.Open();
        Destroy(gameObject);
    }
}