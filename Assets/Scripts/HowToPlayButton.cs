using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButton : MonoBehaviour
{
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
