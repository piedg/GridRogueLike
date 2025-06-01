using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
   [SerializeField] private GameObject TileMap;
   [SerializeField] private List<GameObject> tileMaps;
   private List<GridTile> tiles = new List<GridTile>();

   private static Grid instance;

   public static Grid Instance => instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }

      foreach (var tileMap in tileMaps)
      {
         foreach (var tileObj in tileMap.GetComponentsInChildren<GridTile>())
         {
            tiles.Add(tileObj);
         }
      }
   }

   public void SetObjectToTile(GridObject gridObject, GridTile gridTile)
   {
      gridTile.SetGridObject(gridObject);
      gridObject.SetGridTile(gridTile);
   }

   public void RemoveGridObjectFromTile(GridTile gridTile)
   {
      gridTile.RemoveGridObject();
   }

   public GridTile GetTileAt(int x, int y)
   {
      foreach (var tile in tiles)
      {
         if (tile.Position.y == y && tile.Position.x == x)
         {
            return tile;
         }
      }
      Debug.Log($"Tile {x + ", " + y} not found");
      return null;
   }
   
   public GridTile GetTileAt(Vector2Int position)  
   {
      foreach (var tile in tiles)
      {
         if (tile.Position.y == position.y && tile.Position.x == position.x)
         {
            return tile;
         }
      }
      Debug.Log($"Tile {position.x + ", " + position.y} not found");
      return null;
   }
}
