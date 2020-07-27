using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.7f);
    }
}
