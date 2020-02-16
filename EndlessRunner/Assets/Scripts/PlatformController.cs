using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float platformMoveSpeed;

    void Start()
    {
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        var transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x - platformMoveSpeed, transform.position.y);   
    }    
}
