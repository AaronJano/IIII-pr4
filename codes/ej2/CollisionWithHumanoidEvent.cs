using UnityEngine;

public class CollisionWithHumanoidEvent : MonoBehaviour
{
    public delegate void HumanoidCollisionEventHandler();
    public event HumanoidCollisionEventHandler OnType1CollisionEnterEvent;
    public event HumanoidCollisionEventHandler OnType2CollisionEnterEvent;

    private bool hasCollidedWithType1 = false;
    private bool hasCollidedWithType2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Type_1" && !hasCollidedWithType1)
        {
            hasCollidedWithType1 = true;
            OnType1CollisionEnterEvent?.Invoke();
        }
        else if (collision.gameObject.tag == "Type_2" && !hasCollidedWithType2)
        {
            hasCollidedWithType2 = true;
            OnType2CollisionEnterEvent?.Invoke();
        }
    }
}
