using UnityEngine;

public class FireHoseMover : MonoBehaviour
{
    private const float SpeedRotate = 1.5f; 

    private void Update()
    {
        RotateHose();
    }

    private void RotateHose()
    {
        Vector3 mousePosition = Input.mousePosition;
        float verticalAngle = (mousePosition.x - (Screen.width / 2)) / Screen.width;
        float horizontalAngle = (mousePosition.y - (Screen.height / 3)) / Screen.height;

        transform.Rotate(Vector3.up, verticalAngle * SpeedRotate);
        transform.Rotate(Vector3.right, -horizontalAngle * SpeedRotate);

        transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -0.18f, 0.05f), Mathf.Clamp(transform.rotation.y, -0.2f, 0.2f), 0, 1);
    }
}
