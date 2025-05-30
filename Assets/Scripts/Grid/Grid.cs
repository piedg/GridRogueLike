using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
   [SerializeField] private GameObject TileMap;
   private List<GridTileVisual> tiles = new List<GridTileVisual>();

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
      
      foreach (var tileObj in TileMap.GetComponentsInChildren<GridTileVisual>())
      {
         tiles.Add(tileObj);
      }
   }

   public GridTile GetTileAt(int x, int y)
   {
      foreach (var tileVisual in tiles)
      {
         if ((int)tileVisual.Tile.Position.y == y && (int)tileVisual.Tile.Position.x == x)
         {
            return tileVisual.Tile;
         }
      }
      Debug.Log($"Tile {x + ", " + y} not found");
      return null;
   }
}
