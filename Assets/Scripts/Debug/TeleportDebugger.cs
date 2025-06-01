using UnityEngine;

public class TeleportDebugger : MonoBehaviour
{
    [SerializeField] Teleport tp;
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (tp.SpawnTile != null)
        {
            Debug.DrawLine(gameObject.transform.position, (Vector2)tp.SpawnTile.Position, Color.cyan);
        }
    }
#endif
}