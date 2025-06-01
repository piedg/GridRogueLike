using UnityEngine;

public class TeleportDebugger : MonoBehaviour
{
    [SerializeField] Teleport tp;
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (tp.SpawnTile != null)
        {
            Debug.DrawLine(transform.position, tp.SpawnTile.transform.position, Color.cyan);
        }
    }
#endif
}