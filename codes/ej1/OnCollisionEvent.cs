using UnityEngine;

public class OnCollisionEvent : MonoBehaviour
{
    public delegate void CollisionEventHandler();
    public event CollisionEventHandler OnCollisionEnterEvent;

    private bool hasCollided = false;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
                OnCollisionEnterEvent?.Invoke();
            }
        }
    }
}
