using UnityEngine;
using UnityEngine.UI;

public class ShieldCollector : MonoBehaviour
{
    public int shieldCuantity = 0;
    private int resetEvery100 = 0;
    private int level = 0;

    private Text canvasText;

    void Start()
    {
        // Cachea el componente Text para no buscarlo cada vez
        canvasText = GameObject.Find("Canvas").GetComponent<Text>();
        if (canvasText != null)
        {
            UpdateCanvasText();
        }
        else
        {
            Debug.LogWarning("Canvas Text component not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Actualiza shieldCuantity y resetEvery100 según el tipo de escudo
        if (collision.gameObject.CompareTag("Shield_1"))
        {
            shieldCuantity += 5;
            resetEvery100 += 5;
            Debug.Log("Shields collected of type 1: " + shieldCuantity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield_2"))
        {
            shieldCuantity += 10;
            resetEvery100 += 10;
            Debug.Log("Shields collected of type 2: " + shieldCuantity);
            Destroy(collision.gameObject);
        }

        // Subir de nivel cada 100 shields
        if (resetEvery100 >= 100)
        {
            level++;
            resetEvery100 = 0; // reinicia el contador
            Debug.Log("Level up! New level: " + level);
        }

        // Actualiza el texto del Canvas
        UpdateCanvasText();
    }

    private void UpdateCanvasText()
    {
        // Mantiene exactamente los espacios entre "Shield:" y "Level:"
        if (canvasText != null)
        {
            canvasText.text = "Shield: " + shieldCuantity + "  Level: " + level;
        }
    }
}
