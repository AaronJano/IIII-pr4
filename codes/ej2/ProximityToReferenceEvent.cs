using UnityEngine;

public class ProximityToReferenceEvent : MonoBehaviour
{
    public delegate void ProximityEventHandler();
    public event ProximityEventHandler OnProximityEvent;

    [SerializeField] private GameObject referenceObject; // Object to check proximity to
    [SerializeField] private float proximityThreshold = 5f; // Distance threshold

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (referenceObject.transform != null)
        {
            float distance = Vector3.Distance(transform.position, referenceObject.transform.position);
            if (distance < proximityThreshold)
            {
                OnProximityEvent?.Invoke();
            }
        }
    }
}
