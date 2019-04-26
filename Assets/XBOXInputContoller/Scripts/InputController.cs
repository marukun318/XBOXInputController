// These codes are licensed under CC0.
// http://creativecommons.org/publicdomain/zero/1.0/deed.ja

using UnityEngine;
//
internal class InputController : SingletonMonoBehaviour<InputController>
{
    public static readonly uint PAD_LEFT = 0x00000001;
    public static readonly uint PAD_RIGHT = 0x00000002;
    public static readonly uint PAD_UP = 0x00000004;
    public static readonly uint PAD_DOWN = 0x00000008;
    public static readonly uint PAD_BUTTON_A = 0x00000010;
    public static readonly uint PAD_BUTTON_B = 0x00000020;
    public static readonly uint PAD_BUTTON_X = 0x00000040;
    public static readonly uint PAD_BUTTON_Y = 0x00000080;

    public static readonly uint PAD_BUTTON_LB = 0x01000000;
    public static readonly uint PAD_BUTTON_RB = 0x02000000;

    public static readonly uint PAD_BUTTON_MENU = 0x10000000;
    public static readonly uint PAD_BUTTON_VIEW = 0x20000000;

    public static readonly float PAD_DEAD = 0.2f;

    private bool isReady;                     // Preparation for initialization complete

    protected uint pad_bak = 0;               // 以前のPad入力
    protected uint pad_trg = 0;               // トリガー


    // 読み取り専用プロパティ
    public bool IsReady { get { return this.isReady; } set { this.isReady = value; } }

    /// <summary>
    /// ボタンが押された一瞬の状態を得る
    /// </summary>
    /// <returns>ボタンが押された一瞬の状態Bit</returns>
    public uint Trigger { get { return this.pad_trg; } }

    /// <summary>
    /// ポーリング
    /// </summary>
    /// <returns></returns>
    public virtual uint Poll() { return 0; }

    /// <summary>
    /// Destroyされたとき
    /// </summary>
    private void OnDestroy()
    {
        IsReady = false;
    }

}
