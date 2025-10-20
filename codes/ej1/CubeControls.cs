using UnityEngine;
using UnityEngine.EventSystems;

public class CubeControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * Time.fixedDeltaTime * 5f);
    }
}
