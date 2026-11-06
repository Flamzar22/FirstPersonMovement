using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;
    public static PlayerScore instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateText();
    }
    void Update()
    {
        
    }
    public void UpdateText()
    {
        scoreText.text = $"Score: {score}";
    }
}
