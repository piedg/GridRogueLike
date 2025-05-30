using UnityEngine;

public class GridTileVisual : MonoBehaviour
{
    private GridTile tile;
    [SerializeField] private eGridType _gridType;
    public GridTile Tile
    {
        get => tile;
        set => tile = value;
    }

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();

        tile = new GridTile((int)transform.position.x, (int)transform.position.y, _gridType);
    }

    private void Start()
    {
    
    }
}
