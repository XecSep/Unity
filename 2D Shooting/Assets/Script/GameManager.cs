using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject enemy;

    public GameObject readyText;
    public Text scoreText;
    

    static public int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 비활성화
        readyText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    // Update is called once per frame
    void Update()
    {
        UIManager();
    }

    void UIManager()
    {
        TextManager();
    }

    void TextManager()
    {
        Score();
    }

    void Score()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator ShowReady()
    {
        int count = 0;

        while(count<3)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            count++;
        }
    }
}
