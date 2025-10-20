using UnityEngine;

public class OnProximityEventResponse : MonoBehaviour
{
    [SerializeField] private ProximityToReferenceEvent proximityEvent; // Asigna el emisor del evento
    [SerializeField] private string objectiveShieldName = "ObjectiveShield"; // Nombre del escudo objetivo
    [SerializeField] private bool triggerOnce = true;

    private bool hasTriggered = false;

    void OnEnable()
    {
        if (proximityEvent != null)
        {
            proximityEvent.OnProximityEvent += HandleProximityEvent;
        }
        else
        {
            Debug.LogError($"{name}: proximityEvent no asignado en el Inspector.");
        }
    }

    void OnDisable()
    {
        if (proximityEvent != null)
        {
            proximityEvent.OnProximityEvent -= HandleProximityEvent;
        }
    }

    private void HandleProximityEvent()
    {
        if (triggerOnce && hasTriggered) return;

        GameObject shield = GameObject.Find(objectiveShieldName);
        if (shield == null) return;

        // Este componente se añade a cada objeto que debe reaccionar.
        if (CompareTag("Type_1"))
        {
            Vector3 target = shield.transform.position;
            Rigidbody rb = GetComponent<Rigidbody>();

            // Si tiene Rigidbody dinámico, reposiciona por rb.position y limpia velocidades
            if (rb != null && !rb.isKinematic)
            {
                rb.position = target;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            else
            {
                // Kinematic o sin Rigidbody: mover por transform es correcto
                transform.position = target;
            }
        }
        else if (CompareTag("Type_2"))
        {
            transform.LookAt(shield.transform);
        }

        hasTriggered = true;
    }
}
