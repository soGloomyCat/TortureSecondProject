using UnityEngine;

public class FireHoseMover : MonoBehaviour
{
    private const float SpeedRotate = 1.5f;
    private const float MinHorizontalRotateAngle = -0.18f;
    private const float MaxHorizontalRotateAngle = 0.05f;
    private const float MinVerticalRotateAngle = -0.2f;
    private const float MaxVerticalRotateAngle = 0.2f;
    private const float SideRotateAngle = 0;

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

        transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, MinHorizontalRotateAngle, MaxHorizontalRotateAngle),
                                            Mathf.Clamp(transform.rotation.y, MinVerticalRotateAngle, MaxVerticalRotateAngle), SideRotateAngle, 1);
    }
}
