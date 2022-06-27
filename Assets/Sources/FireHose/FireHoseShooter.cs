using UnityEngine;

public class FireHoseShooter : MonoBehaviour
{
    [SerializeField] private WaterStreamHandler _waterPrefab;
    [SerializeField] private Transform _pool;
    [SerializeField] private ParticleSystem _waterStream;
    [SerializeField] private ParticleSystem _waterShadow;
    [SerializeField] private ParticleSystem _waterLight;

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

        _waterLight.Play();
        _waterStream.Play();
        _waterShadow.Play();
        Instantiate(_waterPrefab, _pool);
    }

    private void DestroyWaterStream()
    {
        _isStreamCreated = false;
        DisableParticleSystem(_waterStream);
        DisableParticleSystem(_waterShadow);
        DisableParticleSystem(_waterLight);
        Destroy(_pool.GetChild(0).gameObject);
    }

    private void DisableParticleSystem(ParticleSystem particleSystem)
    {
        particleSystem.Clear();
        particleSystem.Stop();
    }
}
