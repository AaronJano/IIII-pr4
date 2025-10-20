using UnityEngine;

public class GoToSelectedShield : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private CollisionWithHumanoidEvent collisionEvent;
    private bool move = false;
    void Start()
    {
        collisionEvent.OnType2CollisionEnterEvent += HandleCollision;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            GameObject shield = GameObject.Find("SelectedShield");
            if (shield != null)
            {
                Vector3 shieldPosition = shield.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, shieldPosition, Time.deltaTime * 3f);
            }
        }
    }

    private void HandleCollision()
    {
        move = true;
    }
}
