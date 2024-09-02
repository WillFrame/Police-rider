using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);

    }
    void Update()
    {
        // Проверяем, нажата ли клавиша пробел
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

}
