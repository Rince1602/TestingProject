using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion

    public bool isControllerSwitch;
    public Text switcherText;
    public int score;
    public GameObject endScreen;
    public Text victoryText;
    public GameObject UI;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (score == 10)
        {
            Time.timeScale = 0;
            UI.SetActive(false);
            endScreen.SetActive(true);
            victoryText.text = "Victory";
        }
    }

    public void ControllerSwitcher()
    {
        if (isControllerSwitch)
        {
            isControllerSwitch = false;
            switcherText.text = "TopDown";
        }
        else
        {
            isControllerSwitch = true;
            switcherText.text = "TPS";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
