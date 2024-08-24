using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }
}
