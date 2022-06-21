using UnityEngine;

public class WaterStreamHandler : MonoBehaviour
{
    private void FixedUpdate()
    {
        LetStream();
    }

    private void LetStream()
    {
        Ray ray;
        RaycastHit hit;

        ray = new Ray(transform.position, transform.up);

        if (Physics.Raycast(ray, out hit, 100f))
            if (hit.collider.TryGetComponent(out IgniteObject igniteObject))
                igniteObject.Extinguish();
    }
}
