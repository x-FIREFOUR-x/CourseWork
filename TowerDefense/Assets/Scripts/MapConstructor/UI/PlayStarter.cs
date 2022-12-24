using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayStarter : MonoBehaviour
{
    [SerializeField]
    private string mainScene = "MainScene";


    public void Play()
    {
        if(MapSaver.instance.�onstructedMapIsCorrect())
        {
            SceneManager.LoadScene(mainScene);
        }
        
    }
}
