using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private GridTile _gridTile;
    public GridTile GridTile => _gridTile;

    public void SetGridTile(GridTile newGridTile)
    {
        _gridTile = newGridTile;
    }

    public bool CanMove(GridTile newGridTile)
    {
        if (newGridTile == null) return false;
        if (newGridTile == _gridTile) return false;
        if (newGridTile.Type == eGridType.Wall) { Debug.Log("Wall"); return false; }

        return true;
    }
    
    public void UpdatePosition()
    {
        transform.position = Vector2.Lerp(transform.position, _gridTile.Position, Time.deltaTime * moveSpeed);
        _gridTile.SetGridObject(this);
    }
}
