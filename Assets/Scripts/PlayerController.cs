using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GridObjectVisual _gridObjectVisual;

    private void Awake()
    {
        _gridObjectVisual = GetComponent<GridObjectVisual>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _gridObjectVisual.SetGridTile(Grid.Instance.GetTileAt((int)_gridObjectVisual.GetGridTile().Position.x, (int)_gridObjectVisual.GetGridTile().Position.y + 1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _gridObjectVisual.SetGridTile(Grid.Instance.GetTileAt( (int)_gridObjectVisual.GetGridTile().Position.x + 1, (int)_gridObjectVisual.GetGridTile().Position.y));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _gridObjectVisual.SetGridTile(Grid.Instance.GetTileAt((int)_gridObjectVisual.GetGridTile().Position.x - 1, (int)_gridObjectVisual.GetGridTile().Position.y));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _gridObjectVisual.SetGridTile(Grid.Instance.GetTileAt((int)_gridObjectVisual.GetGridTile().Position.x, (int)_gridObjectVisual.GetGridTile().Position.y - 1));
        }
    }
}
