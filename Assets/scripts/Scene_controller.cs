using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_controller : MonoBehaviour
{
    public void scene_change()
    {
        SceneManager.LoadScene("dance_scene_demo");
    }
    public void exit_scene()
    {
        Application.Quit();
    }
    public void load_main_game()
    {
        SceneManager.LoadScene("Main_Game_Scene");
    }
    public void change_ui_scene()
    {
        SceneManager.LoadScene("mainui");
    }
}
