using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GridObject, IMoveable
{
    [SerializeField] private float moveSpeed;
    private Stat _health;
    private Stat _hungry;

    [SerializeField] float actionDelay = 0.25f;
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
        UpdatePosition();

        if (_health.IsDead())
        {
            Die();
            return;
        }

        if (_moveTimer >= actionDelay)
        {
            MoveAction();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _hungry.AddValue(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _health.AddValue(1);
        }
    }

    private void MoveAction()
    {
        Vector2Int currentPosition = GridTile.Position;
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
            if (newGridTile.HasObject())
            {
                UseItem(newGridTile);
            }
            
            Grid.Instance.RemoveGridObjectFromTile(Grid.Instance.GetTileAt(currentPosition));
            Grid.Instance.SetGridObjectToTile(this, newGridTile);
            _moveTimer = 0f;
            PerformMove();
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

    private void UseItem(GridTile gridTile)
    {
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