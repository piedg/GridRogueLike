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
}
