using UnityEngine;

public class FireHoseShooter : MonoBehaviour
{
    [SerializeField] private WaterStreamHandler _waterPrefab;
    [SerializeField] private Transform _pool;
    [SerializeField] private ParticleSystem _waterStream;

    private bool _isStreamCreated = false;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _isStreamCreated == false)
            Shoot();

        if (Input.GetMouseButtonUp(0))
            DestroyWaterStream();
    }

    private void Shoot()
    {
        _isStreamCreated = true;
        WaterStreamHandler tempWater;

        _waterStream.Play();
        tempWater = Instantiate(_waterPrefab, _pool);
    }

    private void DestroyWaterStream()
    {
        _isStreamCreated = false;
        _waterStream.Stop();
        _waterStream.Clear();
        Destroy(_pool.GetChild(0).gameObject);
    }
}
