using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
     public int playerScore;
     public Text scoreText;
     public GameObject gameOverScreen;
     private bool isGameOver = false;

     public Text highScoreText;
     private int highScore;

     public GameObject titleScreen;
     private bool gameStarted = false;

     
     public Camera mainCamera;
     private Color startColor = new Color(0.5f, 0.8f, 1f);  // Light Blue (Sky Blue)
     private Color endColor = new Color(0.1f, 0.1f, 0.3f);  // Dark Blue (Night Sky)


     [ContextMenu("Increase Score")]

     private void Start()
    {
        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

        titleScreen.SetActive(true);
        Time.timeScale = 0; //Pause game until player clicks "Start"

        // Find the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    //Function for the "Start" button
    public void StartGame()
    {
        gameStarted = true;
        titleScreen.SetActive(false);
        Time.timeScale = 1; 
    }

    // Interpolate between startColor and endColor based on score
    private void UpdateBackgroundColor()
    {
        float t = Mathf.Clamp01(playerScore / 20f);
        mainCamera.backgroundColor = Color.Lerp(startColor, endColor, t);
    }

     public void addScore(){
        if(!isGameOver && gameStarted){
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
            FindFirstObjectByType<AudioManagerScript>().PlayScoreSound();

            if (playerScore > highScore)
            {
                highScore = playerScore;
                highScoreText.text = "High Score: " + highScore.ToString();
            }
            UpdateBackgroundColor();
        }
    }
    
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        isGameOver = true;
        gameOverScreen.SetActive(true);

        // Trigger screen shake
        ScreenShakeScript screenShake = FindFirstObjectByType<ScreenShakeScript>();
        if (screenShake != null)
        {
            screenShake.TriggerShake();  // Ensure shake happens on every game over
            }

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
        }
    }

}
