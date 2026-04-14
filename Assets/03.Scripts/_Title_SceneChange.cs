using UnityEngine;
using UnityEngine.SceneManagement;

public class _Title_SceneChange : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Simulator");
    }
}
