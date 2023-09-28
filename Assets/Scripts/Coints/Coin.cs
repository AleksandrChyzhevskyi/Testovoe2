using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private MeshRenderer _meshRenderer;

    private void Awake() =>
        _meshRenderer = transform.GetComponent<MeshRenderer>();

    private void FixedUpdate() =>
        RotateCoin();


    private void OnDisable() =>
        StopCoroutine(WaitTimeParticleSystem());

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats Player))
        {
            Player.ChangeCountCoints();
            _meshRenderer.enabled = false;
            _particleSystem.Play();
            StartCoroutine(WaitTimeParticleSystem());
        }
    }

    private IEnumerator WaitTimeParticleSystem()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    private void RotateCoin() =>
        transform.Rotate(0, 0, 1);
}