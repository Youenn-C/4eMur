using System;
using System.Runtime.InteropServices;

public class PopupSpawner
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern IntPtr CreateWindowEx(
        int dwExStyle,
        string lpClassName,
        string lpWindowName,
        int dwStyle,
        int x, int y, int width, int height,
        IntPtr parent,
        IntPtr menu,
        IntPtr instance,
        IntPtr param
    );

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public static void CreatePopup()
    {
        IntPtr hWnd = CreateWindowEx(
            0,
            "STATIC",
            "Tu ne t’enfuiras pas.",
            0x10CF0000, // style standard
            100, 100, 300, 200,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero
        );

        ShowWindow(hWnd, 1);
    }
    
    public static void LosingMinigame()
    {
        IntPtr hWnd = CreateWindowEx(
            0,
            "STATIC",
            "Va falloir devenir meilleur que ça...",
            0x10CF0000, // style standard
            100, 100, 300, 200,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero
        );

        ShowWindow(hWnd, 1);
    }
    
    public static void ShowThreeLives()
    {
        IntPtr hWnd = CreateWindowEx(
            0,
            "STATIC",
            "Il te reste 3 vies",
            0x10CF0000, // style standard
            100, 100, 300, 200,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero
        );

        ShowWindow(hWnd, 1);
    }
    
    public static void ShowTwoLives()
    {
        IntPtr hWnd = CreateWindowEx(
            0,
            "STATIC",
            "Il te reste encore 2 vies",
            0x10CF0000, // style standard
            100, 100, 300, 200,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero
        );

        ShowWindow(hWnd, 1);
    }
    
    public static void ShowOneLife()
    {
        IntPtr hWnd = CreateWindowEx(
            0,
            "STATIC",
            "C'est ta dernière vie !",
            0x10CF0000, // style standard
            100, 100, 300, 200,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero
        );

        ShowWindow(hWnd, 1);
    }
}