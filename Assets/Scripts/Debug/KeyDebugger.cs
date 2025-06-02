using UnityEngine;

public class KeyDebugger : MonoBehaviour
{
    [SerializeField] Door door;
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (door.SpawnTile != null)
        {
            Debug.DrawLine(transform.position, door.transform.position, Color.red);
        }
    }
#endif
}