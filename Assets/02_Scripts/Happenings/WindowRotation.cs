using System;
using System.Runtime.InteropServices;
using UnityEngine;

//NOTE : Ne permet pas la rotation pour le moment, juste un déplacement sur les 2 axes
public class WindowRotation : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow(); //Ref à la fenêtre active du jeu

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);
    
    

    IntPtr hWnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hWnd = GetActiveWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SetWindowPos(hWnd, IntPtr.Zero, 45, 45, 500, 300, 0);
        }
    }
}
