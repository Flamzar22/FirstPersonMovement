using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorPrice;
    public TextMeshProUGUI buyText;
    public bool buyDoor = false;
    public static Door instance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instance = this;
            buyText.gameObject.SetActive(true);
            buyText.text = $"Press E to unlock door (Cost:{doorPrice})";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && buyDoor)
        {
            if (PlayerScore.instance.score > doorPrice)
            {
                Destroy(gameObject);
                PlayerScore.instance.score -= doorPrice;
                PlayerScore.instance.UpdateText();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buyText.gameObject.SetActive(false);
        }
    }
}
