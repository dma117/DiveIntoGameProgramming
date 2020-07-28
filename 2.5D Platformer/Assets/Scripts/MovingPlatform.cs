using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _startPos;
    [SerializeField]
    private Transform _endPos;
    [SerializeField]
    private float _speed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPos.transform.position, _speed * Time.deltaTime);

        if (transform.position == _startPos.position || transform.position == _endPos.position)
        {
            (_startPos, _endPos) = (_endPos, _startPos);
        }
    }
}
