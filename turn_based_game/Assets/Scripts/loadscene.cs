using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadscene : MonoBehaviour
{
    public void loadLevel(string nama)
    {
        SceneManager.LoadScene(nama);
    }

    public void keluarapp()
    {
        Application.Quit();
    }
}
