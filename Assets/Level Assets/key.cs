using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class key : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnKeyPickup;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnKeyPickup.Invoke();
            Destroy(gameObject);
        }
    }
}
