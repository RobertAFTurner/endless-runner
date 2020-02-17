using UnityEngine;

public class EndOfPlatformTriggerController : MonoBehaviour
{
    [SerializeField]
    GameObject platformManager;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(other.gameObject);
            SpawnNewPlatform();
        }
    }

    private void SpawnNewPlatform()
    {
        var platformManagerController = platformManager.GetComponent<PlatformManagerController>();
        platformManagerController.SpawnPlatform();
    }
}
