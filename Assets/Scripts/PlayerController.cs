using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private GridObjectVisual _gridObjectVisual;

    private Stat _health;
    private Stat _hungry;

    [SerializeField] float actionDelay = 0.25f;
    private float _moveTimer;

    private void Awake()
    {
        _gridObjectVisual = GetComponent<GridObjectVisual>();

        _health = new Stat(10, eStatType.Health);
        _hungry = new Stat(10, eStatType.Hungry);
    }

    private void Start()
    {
        _moveTimer = actionDelay;
    }

    private void Update()
    {
        _moveTimer += Time.deltaTime;
        _gridObjectVisual.UpdatePosition();

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
        Vector2Int currentPosition = _gridObjectVisual.GetGridTile().Position;
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
        if (_gridObjectVisual.GridObject.CanMove(newGridTile))
        {
            _gridObjectVisual.GridObject.SetGridTile(newGridTile);
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

    private void Die()
    {
        Debug.Log("Player died");
    }
}