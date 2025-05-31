using System;
using UnityEngine;

public enum eGridObjectType
{
    None,
    Player,
    Enemy,
    Food,
    Heal
}

public class GridObject : MonoBehaviour
{
    [SerializeField] private eGridObjectType _type;
    public eGridObjectType Type => _type;

    protected GridTile _gridTile;

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
