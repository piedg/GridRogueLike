using UnityEngine;

public class GridObjectVisual : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    
    private GridObject _gridObject;

    public GridObject GridObject => _gridObject;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _gridObject = new GridObject(Grid.Instance.GetTileAt((int)transform.position.x, (int)transform.position.y));
    }

    public void UpdatePosition()
    {
        transform.position = Vector2.Lerp(transform.position, _gridObject.GridTile.Position, Time.deltaTime * moveSpeed);
    }

    public GridTile GetGridTile()
    {
        return _gridObject.GridTile;
    }
}