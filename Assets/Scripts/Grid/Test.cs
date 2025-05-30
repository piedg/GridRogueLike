using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Grid grid;
    
    [SerializeField] private GridObjectVisual playerPrefab;
    private GridObjectVisual player;
    [SerializeField] private Vector2 playerStartPos;
    
    private void Start()
    {
        player = Instantiate(playerPrefab, grid.GetTileAt((int)playerStartPos.x,(int)playerStartPos.y).Position, Quaternion.identity);
        player.SetGridTile(grid.GetTileAt((int)playerStartPos.x,(int)playerStartPos.y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.SetGridTile(grid.GetTileAt((int)player.GetGridTile().Position.x, (int)player.GetGridTile().Position.y + 1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player.SetGridTile(grid.GetTileAt( (int)player.GetGridTile().Position.x + 1, (int)player.GetGridTile().Position.y));

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            player.SetGridTile(grid.GetTileAt((int)player.GetGridTile().Position.x - 1, (int)player.GetGridTile().Position.y));

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            player.SetGridTile(grid.GetTileAt((int)player.GetGridTile().Position.x, (int)player.GetGridTile().Position.y - 1));
        }
    }
}
