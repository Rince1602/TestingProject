using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour
{
    [SerializeField] private GameObject collectButton;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private Image progress;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text progressText;    
    [SerializeField] private bool isActive;
    [SerializeField] private GameObject sphere;
    private float cooldownTime = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            collectButton.SetActive(true);
            progress.fillAmount = 0;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectButton.SetActive(false);
            progressBar.SetActive(false);
            if (progress.fillAmount == 1)
            {
                isActive = false;
                sphere.SetActive(true);
                StartCoroutine(PointerCooldown());
            }
        }
    }

    private void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        if (progressBar.activeInHierarchy && progress.fillAmount != 1)
        {
            progress.fillAmount += 0.15f * Time.deltaTime;
            progressText.text = (progress.fillAmount * 100f).ToString("0") + "%";
        }
        else if (progressBar.activeInHierarchy && progress.fillAmount == 1)
        {
            GameManager.Instance.score += 1;
            scoreText.text = "Score: " + GameManager.Instance.score;
            progressBar.SetActive(false);
            collectButton.SetActive(false);
        }
    }

    public void CollectButton()
    {
        progressBar.SetActive(true);
    }

    private IEnumerator PointerCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isActive = true;
        sphere.SetActive(false);
        yield break;
    }
}
