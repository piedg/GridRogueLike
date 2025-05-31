using UnityEngine;

public enum eGridType
{
    Ground,
    Wall,
    Door
}

[System.Serializable]
public class GridTile
{
    private Vector2Int _position;
    public Vector2Int Position => _position;

    public eGridType Type => _type;

    private eGridType _type;

    private GridObject _gridObject;

    public GridTile(int x, int y, eGridType type, GridObject gridObject = null)
    {
        _position.x = x;
        _position.y = y;
        _type = type;
        _gridObject = gridObject;
    }

    public void SetGridObject(GridObject gridObject)
    {
        _gridObject = gridObject;
    }

    public void RemoveGridObject()
    {
        _gridObject = null;
    }
}
