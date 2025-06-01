using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void MoveToRoom(Transform roomCenter)
    {
        transform.position = new Vector3(roomCenter.position.x, roomCenter.position.y, transform.position.z);
    }
}