using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WindowRunAway : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    struct POINT { public int X; public int Y; }
    struct RECT { public int Left, Top, Right, Bottom; }

    IntPtr hWnd;

    const uint SWP_NOSIZE = 0x0001;

    void Start()
    {
        hWnd = GetActiveWindow();
    }

    void Update()
    {
        // Position souris
        GetCursorPos(out POINT mouse);

        // Position fenêtre
        GetWindowRect(hWnd, out RECT rect);

        int windowCenterX = (rect.Left + rect.Right) / 2;
        int windowCenterY = (rect.Top + rect.Bottom) / 2;

        // Direction souris -> fenêtre
        int dirX = windowCenterX - mouse.X;
        int dirY = windowCenterY - mouse.Y;

        float distance = Mathf.Sqrt(dirX * dirX + dirY * dirY);

        // Si la souris est proche → fuite
        if (distance < 300f)
        {
            float speed = 10f;

            int newX = rect.Left + (int)(dirX / distance * speed);
            int newY = rect.Top + (int)(dirY / distance * speed);

            SetWindowPos(hWnd, IntPtr.Zero, newX, newY, 0, 0, SWP_NOSIZE);
        }
    }
}