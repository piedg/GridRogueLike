using UnityEngine;

public class Teleport : GridTile
{
    [SerializeField] private GridTile spawnTile;
    [SerializeField] private Transform roomCenter;
    public GridTile SpawnTile => spawnTile;

    public virtual void Use(Player player)
    {
        Camera.main.GetComponent<CameraController>().MoveToRoom(roomCenter);
        player.SetGridTile(spawnTile);
        player.transform.position = (Vector2)spawnTile.Position;
    }
}
