using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    private Player _player;
    [SerializeField] private Vector2Int playerStartPos;

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
        _player = Instantiate(playerPrefab, (Vector2)Grid.Instance.GetTileAt(playerStartPos.x,playerStartPos.y).Position, Quaternion.identity);
        _player.SetGridTile(Grid.Instance.GetTileAt(playerStartPos.x,playerStartPos.y));
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
