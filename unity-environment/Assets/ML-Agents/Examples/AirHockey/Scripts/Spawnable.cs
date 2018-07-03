using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    private Vector3 _spawnPosition;
    private Rigidbody rigidbody;

    public void Start()
    {
        _spawnPosition = this.transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    public float Region;

    public Vector3 GetRandomSpawnPosition()
    {
        return _spawnPosition;
    }

    public void Respawn()
    {
        transform.position = GetRandomSpawnPosition();
        rigidbody.velocity = Vector3.zero;
    }
}