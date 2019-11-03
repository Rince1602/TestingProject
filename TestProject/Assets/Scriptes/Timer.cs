using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startingTime = 10f;
    private float currentTime;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text loseText;
    [SerializeField] private GameObject UI;
    void Start()
    {
        currentTime = startingTime; 
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;
            UI.SetActive(false);
            endScreen.SetActive(true);
            loseText.text = "Defeat";
        }
    }
}
