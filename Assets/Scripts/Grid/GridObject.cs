using UnityEngine;

[System.Serializable]
public class GridObject
{
    private GridTile _gridTile;
    public GridTile GridTile => _gridTile;

    public GridObject(GridTile gridTile)
    {
        _gridTile = gridTile;
    }
    
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
}
