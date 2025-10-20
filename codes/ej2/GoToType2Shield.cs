using UnityEngine;

public class GoToType2Shield : MonoBehaviour
{
    [SerializeField] private CollisionWithHumanoidEvent collisionEvent;
    private bool move = false;

    void Start()
    {
        collisionEvent.OnType1CollisionEnterEvent += HandleCollision;
    }

    void Update()
    {
        if (move)
        {
            GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield_2");
            if (shields.Length > 0)
            {
                GameObject nearestShield = FindNearestShield(shields);
                if (nearestShield != null)
                {
                    Vector3 shieldPosition = nearestShield.transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, shieldPosition, Time.deltaTime * 3f);
                }
            }
        }
    }

    private void HandleCollision()
    {
        move = true;
    }

    private GameObject FindNearestShield(GameObject[] shields)
    {
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject shield in shields)
        {
            float distance = Vector3.Distance(transform.position, shield.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = shield;
            }
        }

        return nearest;
    }
}
