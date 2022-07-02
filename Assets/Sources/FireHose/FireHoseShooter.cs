using System.Collections.Generic;
using UnityEngine;

public class FireHoseShooter : MonoBehaviour
{
    private const int HoseIndex = 0;

    [SerializeField] private WaterStreamHandler _waterPrefab;
    [SerializeField] private Transform _pool;
    [SerializeField] private List<ParticleSystem> _particleSystems;

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
        ActivateParticleSystems(_particleSystems);
        Instantiate(_waterPrefab, _pool);
    }

    private void DestroyWaterStream()
    {
        _isStreamCreated = false;
        DisableParticleSystems(_particleSystems);
        Destroy(_pool.GetChild(HoseIndex).gameObject);
    }

    private void ActivateParticleSystems(List<ParticleSystem> particleSystems)
    {
        foreach (var particleSystem in particleSystems)
            particleSystem.Play();
    }

    private void DisableParticleSystems(List<ParticleSystem> particleSystems)
    {
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.Clear();
            particleSystem.Stop();
        }
    }
}
