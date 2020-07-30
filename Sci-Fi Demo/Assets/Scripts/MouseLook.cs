using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity;
    [SerializeField]
    private bool _isCamera;

    private float _rotationX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rotationX = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCamera)
        {
            MoveVertically();
        }
        else
        {
            MoveHorizontally();
        }
    }

    void MoveHorizontally()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _sensitivity, 0));
    }

    void MoveVertically()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        var newRotation = new Vector3(CalculateRotationX(mouseY), 0, 0);
        transform.localEulerAngles = newRotation;
    }

    float CalculateRotationX(float mouseY)
    {
        _rotationX -= mouseY * _sensitivity;
        
        return Mathf.Clamp(_rotationX, -45, 45);
    }
}
