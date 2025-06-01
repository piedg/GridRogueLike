using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Vector2Int playerStartPos;
    private Player _player;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GridTile spawnTile = Grid.Instance.GetTileAt(playerStartPos.x, playerStartPos.y);
        if (spawnTile.IsWall() || spawnTile.IsTeleport())
        {
            Debug.LogWarning($"Can't spawn Player at tile {spawnTile.Position}");
            return;
        }
        _player = Instantiate(playerPrefab, (Vector2)spawnTile.Position, Quaternion.identity);
        _player.SetGridTile(spawnTile);
        Camera.main.GetComponent<CameraController>().MoveToRoom(spawnTile.GetComponentInParent<Transform>());
    }

    public int GetPlayerHealth()
    {
        if (_player == null) return 0;
        return _player.GetHealthStat().CurrentValue;
    }
    
    public int GetPlayerHungry()
    {
        if (_player == null) return 0;
        return _player.GetHungryStat().CurrentValue;
    }
}
