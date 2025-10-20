using UnityEngine;

public class ChangeColorOnCollisionWithHumanoid : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Type_1"))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
