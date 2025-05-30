using UnityEngine;

public enum eGridType
{
    Ground,
    Wall,
    Door
}

public class GridTile
{
    private Vector2Int _position;
    public Vector2Int Position => _position;

    public eGridType Type => _type;

    private eGridType _type;

    public GridTile(int x, int y, eGridType type)
    {
        _position.x = x;
        _position.y = y;
        _type = type;
    }
}
