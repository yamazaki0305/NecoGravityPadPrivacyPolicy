using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// 
/// Unity 2018.2.11f1
/// 
/// </summary>

public class OpenURL : MonoBehaviour
{
    // Plugins
    [DllImport("__Internal")] private static extern void OpenNewTab(string URL);

    // URL
    private readonly string url = "https://yamazaki1.webnode.jp/catgravityprivacypolicy/";

    // 開くボタンを押したときの処理
    public void ClickOpenButton()
    {
        OpenWindow();
    }

    // 外部ブラウザでURLを開く
    private void OpenWindow()
    {
#if UNITY_EDITOR
        Application.OpenURL(url);
#elif UNITY_WEBGL
          OpenNewTab(url);
#else
          Application.OpenURL(url);
#endif
    }
}