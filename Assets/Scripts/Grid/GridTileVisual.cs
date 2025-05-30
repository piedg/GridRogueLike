using UnityEngine;

public class GridTileVisual : MonoBehaviour
{
    private GridTile _tile;
    
    [SerializeField] private eGridType _gridType;
    public GridTile Tile => _tile;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _tile = new GridTile((int)transform.position.x, (int)transform.position.y, _gridType);
    }
}
