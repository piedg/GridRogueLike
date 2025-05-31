using UnityEngine;

public class GridObject : MonoBehaviour
{
    protected GridTile _gridTile;
    public GridTile GridTile => _gridTile;

    public void SetGridTile(GridTile newGridTile)
    {
        _gridTile = newGridTile;
    }

    protected bool CanMove(GridTile newGridTile)
    {
        if (newGridTile == null) return false;
        if (newGridTile == _gridTile) return false;
        if (newGridTile.Type == eGridType.Wall) { Debug.Log("Wall"); return false; }

        return true;
    }
    
  
}
