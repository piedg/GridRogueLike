using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Grid grid;
    
    [SerializeField] private GridObjectVisual playerPrefab;
    private GridObjectVisual player;
    [SerializeField] private Vector2Int playerStartPos;
    
    private void Start()
    {
        player = Instantiate(playerPrefab, (Vector2)grid.GetTileAt(playerStartPos.x,playerStartPos.y).Position, Quaternion.identity);
        player.GridObject.SetGridTile(grid.GetTileAt(playerStartPos.x,playerStartPos.y));
    }
}
