using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int nextSceneIndex = -1; // Initialize to an invalid value

    private void Start()
    {
        // Calculate the next scene index based on the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

        // If the next scene index is out of bounds, set it to a valid scene or handle as needed
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Change to the first scene or handle as needed
        }
    }

    private void Update()
    {
        // Check for numeric key presses (1, 2, 3, 4)
        for (int i = 1; i <= 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                LoadSceneByNumber(i);
                break; // Exit the loop after loading the scene
            }
        }

        // Check for the Escape key to quit the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }

    private void LoadSceneByNumber(int sceneNumber)
    {
       
