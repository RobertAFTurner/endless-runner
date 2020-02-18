using UnityEngine;

public class PlatformManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefab;

    [SerializeField]
    private float speedIncrimentTime = 10f;

    private float speedIncrimentTimer;

    private void Start()
    {
        speedIncrimentTimer = speedIncrimentTime;
    }
    private void Update()
    {
        IncreasePlatformSpeedOverTime();
    }

    private void IncreasePlatformSpeedOverTime()
    {
        speedIncrimentTimer -= Time.deltaTime;
        if (speedIncrimentTimer < 0)
        {
            GlobalGameStats.platformSpeed += 0.02f;
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
