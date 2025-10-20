using UnityEngine;

public class ResponseToCollision : MonoBehaviour
{
    [SerializeField] private OnCollisionEvent collisionEvent;
    private bool move = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (collisionEvent == null)
        {
            Debug.LogError($"{name}: Falta asignar 'collisionEvent' en el inspector.");
            return;
        }

        collisionEvent.OnCollisionEnterEvent += HandleCollision;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (this.gameObject.CompareTag("Type_1"))
            {
                GameObject greenSphere = GameObject.Find("objectiveSphere");
                if (greenSphere != null)
                {
                    Vector3 greenPosition = greenSphere.transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, greenPosition, Time.deltaTime * 3f);
                }
            }
            else if (this.gameObject.CompareTag("Type_2"))
            {
                GameObject cylinder = GameObject.Find("Cylinder");
                if (cylinder != null)
                {
                    Vector3 cylinderPosition = cylinder.transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, cylinderPosition, Time.deltaTime * 3f);
                }
            }
        }
    }
    public void HandleCollision()
    {
        move = true;
    }
}

