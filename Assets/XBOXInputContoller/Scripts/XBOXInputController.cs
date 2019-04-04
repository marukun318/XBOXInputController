// These codes are licensed under CC0.
// http://creativecommons.org/publicdomain/zero/1.0/deed.ja

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class XBOXInputController : SingletonMonoBehaviour<XBOXInputController>
{
#if WINDOWS_UWP
    private Gamepad controller;
#endif
    private const int PAD_LEFT = 0x0001;

//    private const float PAD_DEAD = 0.2f;

    // Common
    private const string INPUT_HORIZONTAL = "Horizontal";
    private const string INPUT_VERTICAL = "Vertical";

    private const string INPUT_ACTION0 = "Action0";
    private const string INPUT_ACTION1 = "Action1";
    private const string INPUT_ACTION2 = "Action2";
    private const string INPUT_ACTION3 = "Action3";

#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
    // OSX
    private const string INPUT_HORIZONTAL_R = "Horizontal2";
    private const string INPUT_VERTICAL_R = "Vertical2";

    private const string INPUT_TRIGGER_L = "LeftTrigger";
    private const string INPUT_TRIGGER_R = "RightTrigger";
    
    private const string INPUT_DPAD_H = "DPADH";
    private const string INPUT_DPAD_V = "DPADV";

    private const string INPUT_LB = "LB_Mac";
    private const string INPUT_RB = "RB_Mac";
    private const string INPUT_VIEW = "View_Mac";
    private const string INPUT_MENU = "Menu_Mac";
   private const string INPUT_LSTICK_CLICK = "LStickClick";
    private const string INPUT_RSTICK_CLICK = "RStickClick";
#elif UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX
    // Linux
    private const string INPUT_HORIZONTAL_R = "Horizontal2";
    private const string INPUT_VERTICAL_R = "Vertical2";

    private const string INPUT_TRIGGER_L = "LeftTrigger";
    private const string INPUT_TRIGGER_R = "RightTrigger";

    private const string INPUT_DPAD_H = "DPADH";
    private const string INPUT_DPAD_V = "DPADV";

    private const string INPUT_LB = "LB_Linux";
    private const string INPUT_RB = "RB_Linux";
    private const string INPUT_VIEW = "View_Linux";
    private const string INPUT_MENU = "Menu_Linux";
    private const string INPUT_LSTICK_CLICK = "LStickClick";
    private const string INPUT_RSTICK_CLICK = "RStickClick";
#else
    // Win
    private const string INPUT_HORIZONTAL_R = "Horizontal2";
    private const string INPUT_VERTICAL_R = "Vertical2";

    private const string INPUT_TRIGGER_L = "LeftTrigger";
    private const string INPUT_TRIGGER_R = "RightTrigger";

    private const string INPUT_DPAD_H = "DPADH";
    private const string INPUT_DPAD_V = "DPADV";

    private const string INPUT_LB = "LB";
    private const string INPUT_RB = "RB";
    private const string INPUT_VIEW = "View";
    private const string INPUT_MENU = "Menu";
    private const string INPUT_LSTICK_CLICK = "LStickClick";
    private const string INPUT_RSTICK_CLICK = "RStickClick";
#endif

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        // シーン遷移されても消えないように
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(InitializeManager());
    }

    /// <summary>
    /// Destroyされたとき
    /// </summary>
    private void OnDestroy()
    {
//        Debug.Log("OnDestroy()");
    }

    /// <summary>
    /// Startから呼ぶ初期化
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitializeManager()
    {
        Debug.Log("InitializeManager()");

#if WINDOWS_UWP
        // Gamepadを探す
        if(Gamepad.Gamepads.Count > 0) {
            Debug.Log("Gamepad found.");
          //  controller = Gamepad.Gamepads.First();
        } else
        {
            Debug.Log("Gamepad not found.");
        }
        // ゲームパッド追加時イベント処理を追加
        Gamepad.GamepadAdded += Gamepad_GamepadAdded;
#endif
        yield break;
    }

    /// <summary>
    /// 画面更新
    /// </summary>
    private void Update()
    {
        // 接続されているコントローラの名前を調べる
        var controllerNames = Input.GetJoystickNames();

        if (controllerNames.Length == 0)
        {
            // Steamコントローラの場合も０になる？
            Debug.Log("***Steam Controller?***");
        }
        else
        {
            // 一台もコントローラが接続されていなければエラー
            if (controllerNames[0] == "")
            {
                // ゲームコントローラは接続されていない
                Debug.Log(controllerNames[0]);
            }
            Debug.Log(controllerNames[0]);

            if (controllerNames[0].Equals("Controller (XBOX 360 For Windows)"))
            {
                Debug.Log("***XBOX360***");

            }
            else
            if (controllerNames[0].Equals("Controller (Xbox One For Windows)"))
            {
                Debug.Log("***XBOXONE***");

            }
            else
            if (controllerNames[0].Equals("JC-PS101U"))
            {
                Debug.Log("***PlayStation1***");

            }
        }

        // Analog Stick
        float vx = Input.GetAxis(INPUT_HORIZONTAL);
        float vy = Input.GetAxis(INPUT_VERTICAL);

        // Right Analog Stick
        float rvx = Input.GetAxis(INPUT_HORIZONTAL_R);
        float rvy = Input.GetAxis(INPUT_VERTICAL_R);

        // DPad
        float dvx = Input.GetAxis(INPUT_DPAD_H);
        float dvy = Input.GetAxis(INPUT_DPAD_V);

        // Left Trigger
        float tl = Input.GetAxis(INPUT_TRIGGER_L);
        float tr = Input.GetAxis(INPUT_TRIGGER_R);

        // Analog Left チェック
        if (vx < 0f)
        {
            Debug.Log("ANALOG_LEFT");
        }
        else if (vx > 0f)
        {
            Debug.Log("ANALOG_RIGHT");
        }
        // 上下逆
        if (vy > 0f)
        {
            Debug.Log("ANALOG_UP");
        }
        else if (vy < 0f)
        {
            Debug.Log("ANALOG_DOWN");
        }

        // Analog Right チェック
        if (rvx < 0f)
        {
            Debug.Log("RIGHT_ANALOG_LEFT");
        }
        else if (rvx > 0f)
        {
            Debug.Log("RIGHT_ANALOG_RIGHT");
        }
        if (rvy < 0f)
        {
            Debug.Log("RIGHT_ANALOG_UP");
        }
        else if (rvy > 0f)
        {
            Debug.Log("RIGHT_ANALOG_DOWN");
        }


        // トリガー
        Debug.Log("tl=" + tl + " tr=" + tr);


        // DPADチェック
        if (dvx < 0f)
        {
            Debug.Log("DPAD_LEFT");

        }
        else if (dvx > 0f)
        {
            Debug.Log("DPAD_RIGHT");
        }
        // 上下逆
        if (dvy > 0f)
        {
            Debug.Log("DPAD_UP");
        }
        else if (dvy < 0f)
        {
            Debug.Log("DPAD_DOWN");
        }

        // ボタンをチェック
        if (Input.GetButton(INPUT_ACTION0))
        {
            Debug.Log("A");
        }
        if (Input.GetButton(INPUT_ACTION1))
        {
            Debug.Log("B");
        }
        if (Input.GetButton(INPUT_ACTION2))
        {
            Debug.Log("X");
        }
        if (Input.GetButton(INPUT_ACTION3))
        {
            Debug.Log("Y");
        }
        if (Input.GetButton(INPUT_LB))
        {
            Debug.Log("LB");
        }
        if (Input.GetButton(INPUT_RB))
        {
            Debug.Log("RB");
        }
        if (Input.GetButton(INPUT_LSTICK_CLICK))
        {
            Debug.Log("LSTICK_CLICK");
        }
        if (Input.GetButton(INPUT_RSTICK_CLICK))
        {
            Debug.Log("RSTICK_CLICK");
        }
        // Start
        if (Input.GetButton(INPUT_MENU))
        {
            Debug.Log("MENU");
        }
        // Back
        if (Input.GetButton(INPUT_VIEW))
        {
            Debug.Log("VIEW");
        }

    }

#if WINDOWS_UWP
    /// <summary>
    // ゲームパッド追加時のイベント処理
    /// </summary>
    private void Gamepad_GamepadAdded(object sender, Gamepad e)
    {
        controller = e;
        Debug.Log("Gamepad added");
    }
#endif

}
