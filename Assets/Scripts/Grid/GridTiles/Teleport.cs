using UnityEngine;

public class Teleport : GridTile
{
    [SerializeField] private GridTile spawnTile;
    public GridTile SpawnTile => spawnTile;

    public void Use(Player player)
    {
        Camera.main.GetComponent<CameraController>().MoveToRoom(spawnTile.GetComponentInParent<Transform>());
        player.SetGridTile(spawnTile);
        player.transform.position = (Vector2)spawnTile.Position;
    }
}
