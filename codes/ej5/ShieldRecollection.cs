using UnityEngine;

public class ShieldRecollection : MonoBehaviour
{

    public int shieldCuantity = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shield_1"))
        {
            shieldCuantity += 5;
            Debug.Log("Shields collected of type 1: " + shieldCuantity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield_2"))
        {
            shieldCuantity += 10;
            Debug.Log("Shields collected of type 2: " + shieldCuantity);
            Destroy(collision.gameObject);
        }
    }

}
