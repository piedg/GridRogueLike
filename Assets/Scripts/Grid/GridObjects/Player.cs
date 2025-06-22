using UnityEngine;

public class Player : GridObject, IMoveable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] float actionDelay = 0.25f;

    [Header("Stats")] [SerializeField] private int startingHealth;
    [SerializeField] private int startingHungry;

    private Stat _health;
    private Stat _hungry;

    private float _moveTimer;

    private void Awake()
    {
        _health = new Stat(startingHealth, eStatType.Health);
        _hungry = new Stat(startingHungry, eStatType.Hungry);
    }

    private void Start()
    {
        _moveTimer = actionDelay;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

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

        MoveToTile(newX, newY);
    }

    private void MoveToTile(int newX, int newY)
    {
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
                Grid.Instance.UpdateObjectInGrid(this, _gridTile, newGridTile);
            }

            _moveTimer = 0f;
        }
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

    private void PerformAction(GridTile newGridTile)
    {
        if (!newGridTile.HasObject()) return;

        switch (newGridTile.GridObject.Type)
        {
            case eGridObjectType.Food:
                Food foodObj = newGridTile.GridObject.GetComponent<IConsumable>() as Food;
                if (foodObj != null)
                {
                    foodObj.Use(this);
                }

                break;
            case eGridObjectType.Heal:
                Heal healObj = newGridTile.GridObject.GetComponent<IConsumable>() as Heal;
                if (healObj != null)
                {
                    healObj.Use(this);
                }

                break;
            case eGridObjectType.Key:
            {
                DoorKey doorKey = newGridTile.GridObject.GetComponent<IConsumable>() as DoorKey;
                if (doorKey != null)
                {
                    doorKey.Use(this);
                }

                break;
            }
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

    private void Die()
    {
        Debug.Log("Player died");
    }
}