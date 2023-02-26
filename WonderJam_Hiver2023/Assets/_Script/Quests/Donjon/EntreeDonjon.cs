using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreeDonjon : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInteract player))
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
