using UnityEngine;

public class Player : GridObject, IMoveable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] float actionDelay = 0.25f;
    
    private Stat _health;
    private Stat _hungry;

    private float _moveTimer;

    private void Awake()
    {
        _health = new Stat(5, eStatType.Health);
        _hungry = new Stat(5, eStatType.Hungry);
    }

    private void Start()
    {
        _moveTimer = actionDelay;
    }

    private void Update()
    {
        _moveTimer += Time.deltaTime;
        if (_health.IsDead())
        {
            Die();
            return;
        }
        
        UpdatePosition();

        if (_moveTimer >= actionDelay)
        {
            MoveAction();
        }
    }

    private void MoveAction()
    {
        Vector2Int currentPosition = _gridTile.Position;
        int newX = currentPosition.x;
        int newY = currentPosition.y;

        if (Input.GetKeyDown(KeyCode.W))
        {
            newY += 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            newX -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            newY -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            newX += 1;
        }

        GridTile newGridTile = Grid.Instance.GetTileAt(newX, newY);
        if (CanMove(newGridTile))
        {
            PerformMove();
            if (newGridTile.IsTeleport())
            {
                Teleport teleportTile = newGridTile as Teleport;
                if (teleportTile)
                {
                    teleportTile.Use(this);
                }
            }
            else
            {
                PerformAction(newGridTile);
                MoveToNewTile(_gridTile, newGridTile);
            }
            
            _moveTimer = 0f;
        }
    }

    private void MoveToNewTile(GridTile currentTile, GridTile newGridTile)
    {
        Grid.Instance.RemoveGridObjectFromTile(currentTile);
        Grid.Instance.SetObjectToTile(this, newGridTile);
    }

    private void PerformMove()
    {
        if (_hungry.IsStarving())
        {
            _health.RemoveValue(1);
        }
        else
        {
            _hungry.RemoveValue(1);
        }
    }

    public Stat GetHungryStat()
    {
        return _hungry;
    }
    
    public Stat GetHealthStat()
    {
        return _health;
    }

    public void UpdatePosition()
    {
        transform.position = Vector2.Lerp(transform.position, _gridTile.Position, Time.deltaTime * moveSpeed);
    }

    private void PerformAction(GridTile gridTile)
    {
        if (!gridTile.HasObject()) return;
        
        switch (gridTile.GridObject.Type)
        {
            case eGridObjectType.Food:
                Food foodObj = gridTile.GridObject.GetComponent<IConsumable>() as Food;
                if (foodObj != null)
                {
                    foodObj.Use(this);
                }
                break;
            case eGridObjectType.Heal:
                Heal healObj = gridTile.GridObject.GetComponent<IConsumable>() as Heal;
                if (healObj != null)
                {
                    healObj.Use(this);
                }
                break;
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
    }
}