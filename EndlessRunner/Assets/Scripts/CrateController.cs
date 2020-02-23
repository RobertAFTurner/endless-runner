using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField]
    private int scoreReward;

    [SerializeField]
    private GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();

            if(playerController.IsBoosting)
                DestroySelf();
            else
                Destroy(other.gameObject);
        }
    }

    private void DestroySelf()
    {
        AudioManagerController.Instance.PlaySound("Explosion");

        GlobalGameStats.score += scoreReward;
        var explosion = Instantiate(explosionEffect, transform.position, new Quaternion());

        explosion.transform.SetParent(transform.parent);
        Destroy(gameObject);
    }
}
