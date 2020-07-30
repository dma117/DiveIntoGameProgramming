using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position);
            other.GetComponent<Player>().UpdateCoins();
            Destroy(gameObject);
        }
    }
}
