using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
public class S_GameManager : MonoBehaviour
{
    // Component References
    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI clickTP;
    public TextMeshProUGUI settingsMenu;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;
    public TextMeshProUGUI mvText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public Button exitGame;
    public Button settings;
    public Button controls;
    public Button credits;
    public Button settingsBack;
    public Button controlBack;
    public Button creditBack;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider mvSlider;
    public RawImage controlIMG;
    public RawImage creditIMG;

    // Variables
    public bool gameOver = false;
    public bool gameStart = false;

    private int _score;
    public float gameSpeed = 50;
    private float gameSpeedMulti = 5;
    private float gameSpeedMax = 250;

    public float _addScore;
    private void Start()
    {
        _score = 0;

        settings.onClick.AddListener(SettingsMenu);
       
        StartCoroutine(Clock());
    }

    private void Update()
    {
        StartGame();

        if (gameStart == true) /////////////////////
        {
            UpdateScore(0);
            controlSpeed();
            GameOverScreen();
        }
    }

    //////////////////////////// UI ////////////////////////////
    public void UpdateScore(int addToScore)
    {
        _score += addToScore;
        scoreText.text = "Score: " + _score;
    }

    public void StartGame()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameStart = true;
        }

        if (gameStart == true)
        {
            scoreText.gameObject.SetActive(true);

            gameTitle.gameObject.SetActive(false);
            clickTP.gameObject.SetActive(false);
            settings.gameObject.SetActive(false);
            exitGame.gameObject.SetActive(false);
        }
    }

    public void GameOverScreen()
    {
        if (gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }

    public void SettingsMenu()
    {
        gameTitle.gameObject.SetActive(false);
        clickTP.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);

        controls.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(true);
        //musicText.gameObject.SetActive(true);
       // sfxText.gameObject.SetActive(true);
        mvText.gameObject.SetActive(true);
        settingsBack.gameObject.SetActive(true);
        mvSlider.gameObject.SetActive(true);
        //sfxSlider.gameObject.SetActive(true);
       // musicSlider.gameObject.SetActive(true);

        controlIMG.gameObject.SetActive(false);
        controlBack.gameObject.SetActive(false);

        creditBack.gameObject.SetActive(false);
        creditIMG.gameObject.SetActive(false);

        settingsBack.onClick.AddListener(MainMenu);
        controls.onClick.AddListener(ControlMenu);
        credits.onClick.AddListener(CreditsMenu);
    }

    public void MainMenu()
    {
        gameTitle.gameObject.SetActive(true);
        clickTP.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);

        controls.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        musicText.gameObject.SetActive(false);
        sfxText.gameObject.SetActive(false);
        mvText.gameObject.SetActive(false);
        settingsBack.gameObject.SetActive(false);
        mvSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(false);
    }

    public void ControlMenu()
    {
        controls.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        musicText.gameObject.SetActive(false);
        sfxText.gameObject.SetActive(false);
        mvText.gameObject.SetActive(false);
        settingsBack.gameObject.SetActive(false);
        mvSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        
        controlIMG.gameObject.SetActive(true);
        controlBack.gameObject.SetActive(true);

        controlBack.onClick.AddListener(SettingsMenu);
    }

    public void CreditsMenu()
    {
        controls.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        musicText.gameObject.SetActive(false);
        sfxText.gameObject.SetActive(false);
        mvText.gameObject.SetActive(false);
        settingsBack.gameObject.SetActive(false);
        mvSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(false);

        controlIMG.gameObject.SetActive(false);
        controlBack.gameObject.SetActive(false);

        creditBack.gameObject.SetActive(true);
        creditIMG.gameObject.SetActive(true);

        creditBack.onClick.AddListener(SettingsMenu);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    ////////////////////////////////////////////////////////////
   
    //////////////////// Distance Mechanics ////////////////////
    private IEnumerator Clock()
    {

        yield return new WaitUntil(() => gameStart);

        if (gameStart == true) 
        {
            while (gameOver == false)
            {
                yield return new WaitForSeconds(0.1f);

                UpdateScore(1);
                gameSpeed += 0.5f;

                if (gameSpeed > gameSpeedMax)
                {
                    gameSpeed = gameSpeedMax;
                }
            }
        } 
    }

    private void controlSpeed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (gameOver == false)
            {
                if (gameSpeed >= gameSpeedMax)
                {
                    gameSpeed = gameSpeedMax;
                }
                else
                {
                    gameSpeed += gameSpeedMulti * Time.deltaTime;
                }

                UpdateScore(1);
            } 
        }
    }
    ////////////////////////////////////////////////////////////
}


