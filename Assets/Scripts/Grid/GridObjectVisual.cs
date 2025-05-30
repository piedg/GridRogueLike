using UnityEngine;

public class GridObjectVisual : MonoBehaviour
{
    private GridObject _gridObject = new GridObject();
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetGridTile(_gridObject.GridTile);
    }

    public void SetGridTile(GridTile newGridTile)
    {
        if (newGridTile == null) return;
        if (newGridTile.Type == eGridType.Wall) { Debug.Log("Muro"); return;}
        
        _gridObject.GridTile = newGridTile;
        transform.position = _gridObject.GridTile.Position;
    }

    public GridTile GetGridTile()
    {
        return _gridObject.GridTile;
    }
}