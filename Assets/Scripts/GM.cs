using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{
    public static GM gm;
    public static AudioSource sfx;
    public static bool APP_QUIT_NOW = false;


    public enum GameState {
        PrepareForStart,    // menu
        StartExe,
        Starting,                 // during
        Ending,                  // start return to menu
        End                        // return to menu
    };

    public static GameState state = GameState.PrepareForStart;

    public static bool is_StartButton = false;
    public static bool is_ID_Button = false;

    public static int score = 0;
    public static TextMeshProUGUI t_score;
    public static bool av_t_score = false;


    [SerializeField] private AudioClip expSound;
    public static void playSound_exp()
    {
        sfx.PlayOneShot(gm.expSound);
    }

    void Awake()
    {
        gm = this;
        sfx = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (APP_QUIT_NOW)
        {
            Debug.Log("GameQuit");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        switch (state)
        {
            case GameState.PrepareForStart: {       //  PREPARE 準備
                    if (is_StartButton)     // 按下開始
                    {
                        is_StartButton = false;
                         print("starting...");
                        state = GameState.StartExe;
                    }
            } break;
            case GameState.StartExe: {                  // 開始begin
                    score = 0;
                    av_t_score = false;
                    //StartCoroutine(awaitThenChangeScene("Stage1", 0));
                    SceneManager.LoadScene("Stage1");
                    if (SceneManager.GetActiveScene().name == "Stage1")
                        state = GameState.Starting;
                        //StartCoroutine(awaitThenChangeState(GameState.Starting, 0.5f));
            } break;
            case GameState.Starting: {                   // 遊戲運行中
                    if (av_t_score) t_score.text = "SCORE:" + score;
                    if (!av_t_score) print("報到器異常");
                    if (score >= 4)
                    {
                        print("gameover");
                        state = GameState.Ending;
                    }
             } break;
            case GameState.Ending:
                {
                    StartCoroutine(awaitThenChangeScene("Menu", 1f));
                    // SceneManager.LoadScene("Menu");
                    state = GameState.End;
                } break;
            case GameState.End: {                         // 遊戲結束
                    if (SceneManager.GetActiveScene().name == "Menu")
                        state = GameState.PrepareForStart;
                } break;
        }
    }

    // change scene
    IEnumerator awaitThenChangeScene(string sceneName, float awaitDuration)
    {
        yield return new WaitForSeconds(awaitDuration);
        SceneManager.LoadScene(sceneName);
    }
    // change State
    IEnumerator awaitThenChangeState(GameState st, float awaitDuration)
    {
        yield return new WaitForSeconds(awaitDuration);
        state = st;
    }
}
