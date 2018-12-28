using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene_Game()
    {
        Application.LoadLevel("Game");
    }

    public void Scene_Quit()
    {
        //if (Input.GetKey("escape"))
        //{
        //    Application.Quit();
        //}

 // 유니티 에디터
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

// 유니티 웹플레이어
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");

#else
        Application.Quit();

#endif
    }
}
