using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        var transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x - GlobalGameStats.platformSpeed, transform.position.y);
    }
}
