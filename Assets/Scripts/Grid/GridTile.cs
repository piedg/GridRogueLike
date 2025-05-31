using System;
using UnityEngine;

public enum eGridType
{
    Ground,
    Wall,
    Door
}

public class GridTile : MonoBehaviour
{
    private Vector2Int _position;
    public Vector2Int Position => _position;

    [SerializeField] private eGridType _type;

    public eGridType Type => _type;

    public GridObject _gridObject = null;
    public GridObject GridObject => _gridObject;

    private void Awake()
    {
        _position.x = (int)transform.position.x;
        _position.y = (int)transform.position.y;
    }

    public void RemoveGridObject()
    {
        _gridObject = null;
    }
    
    public void SetGridObject(GridObject newGridObject)
    {
        _gridObject = newGridObject;
    }

    public bool HasObject()
    {
        return _gridObject != null;
    }
}
