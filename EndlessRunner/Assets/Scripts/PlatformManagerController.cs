using UnityEngine;

public class PlatformManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefab;

    [SerializeField]
    private float timeBetweenSpawns = 3f;
    private float timeLeft;

    void Start()
    {
        timeLeft = timeBetweenSpawns;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            Instantiate(platformPrefab[Random.Range(0, 3)],
                        new Vector3(35, Random.Range(-4, 2), 0),
                        new Quaternion());

            timeLeft = timeBetweenSpawns;
        }
    }
}
