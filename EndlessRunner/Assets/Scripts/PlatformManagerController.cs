using UnityEngine;

public class PlatformManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefab;

    [SerializeField]
    private float speedIncrimentTime = 5f;

    private float speedIncrimentTimer;

    private void Start()
    {
        speedIncrimentTimer = speedIncrimentTime;
    }
    private void Update()
    {
        speedIncrimentTimer -= Time.deltaTime;
        if (speedIncrimentTimer < 0)
        {
            GlobalGameStats.platformSpeed += 0.2f;
            speedIncrimentTimer = speedIncrimentTime;
        }
    }

    public void SpawnPlatform()
    {
        Instantiate(platformPrefab[Random.Range(0, 3)],
                new Vector3(35, Random.Range(-6, -2), 0),
                new Quaternion());
    }
}
