using UnityEngine;

public class EndOfPlatformTriggerController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(other.gameObject);
        }
    }
}
