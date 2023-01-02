using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public UnityEvent GamePause;

    public UnityEvent GameResumed;

    public static Health instance;

    public Text healthText;
    public int health = 3;
    public bool isPaused = false;
    public GameObject gameoverPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthText.text = "x" + health.ToString();
    }
    private void Update()
    {
        if (health > 0)
        {
            healthText.text = "x" + health.ToString();
        }
        else
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
                GamePause.Invoke();
                ActivePanel();
            }
            else
            {
                Time.timeScale = 1;
                GameResumed.Invoke();
            }
        }
    }
    public void DecreaseHealth()
    {
        if (health > 0)
        {
            health -= 1;
            healthText.text = "x" + health.ToString();
        }
        else
        {
            health = 0;
        }

    }
    void ActivePanel()
    {
        gameoverPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SpaceInvaders");
    }
}
