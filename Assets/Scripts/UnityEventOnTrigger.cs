using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnTrigger : MonoBehaviour
{
    [Tooltip("The colliding object that we want to trigger these events with needs to use a tag of the same name as typed in this variable")]
    public string tagToActivate = "Player";
    
    public UnityEvent onTriggerEnter, onTriggerExit;
    
    private HashSet<GameObject> triggeredObjects = new HashSet<GameObject>();

    private void Awake()
    {
        if ((GetComponent<Collider>() == null) && (GetComponent<Collider2D>() == null))
        {
            Debug.Log($"{gameObject} is missing a collider");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate) && !triggeredObjects.Contains(other.gameObject))
        {
            onTriggerEnter.Invoke();
            triggeredObjects.Add(other.gameObject);
            Debug.Log("Unity Event Trigger (enter) activated on " + gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate) && triggeredObjects.Contains(other.gameObject))
        {
            onTriggerExit.Invoke();
            triggeredObjects.Remove(other.gameObject);
            Debug.Log("Unity Event Trigger (exit) activated on " + gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToActivate) && !triggeredObjects.Contains(other.gameObject))
        {
            onTriggerEnter.Invoke();
            triggeredObjects.Add(other.gameObject);
            Debug.Log("Unity Event Trigger (enter) activated on " + gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToActivate) && !triggeredObjects.Contains(other.gameObject))
        {
            onTriggerExit.Invoke();
            triggeredObjects.Remove(other.gameObject);
            Debug.Log("Unity Event Trigger (exit) activated on " + gameObject);
        }
    }
}
