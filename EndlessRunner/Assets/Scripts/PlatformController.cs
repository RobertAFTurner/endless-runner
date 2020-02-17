using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float platformMoveSpeed;

    private bool checkForDeath = false;
    private float deathTimer;
    private float deathTime = 3f;

    void Start()
    {
        deathTimer = deathTime;
    }

    void Update()
    {
        MoveLeft();
        //CheckForDeath();
    }

    private void MoveLeft()
    {
        var transform = GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x - platformMoveSpeed, transform.position.y);
    }

    private void CheckForDeath()
    {
        if (checkForDeath)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnBecameInvisible()
    {
        checkForDeath = true;
    }

    private void OnBecameVisible()
    {
        checkForDeath = false;
        deathTimer = deathTime;
    }
}
