using UnityEngine;
using TMPro;

public class CapsuleInteraction : MonoBehaviour
{
    public TextMeshProUGUI hpText; // Referencia al texto en el Canvas

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto tiene la etiqueta "paciente"
        if (collision.gameObject.CompareTag("paciente"))
        {
            // Actualiza el texto del HP
            if (hpText != null)
            {
                int currentHP;
                if (int.TryParse(hpText.text.Replace("HP: ", ""), out currentHP))
                {
                    currentHP += 10;
                    hpText.text = "HP: " + currentHP;
                }
                else
                {
                    Debug.LogError("El texto de HP no es un número válido.");
                }
            }

            // Destruye la cápsula
            Destroy(gameObject);
        }
    }
}
