using System;
using System.Runtime.InteropServices;
using UnityEngine;


//NOTE : Permet d'avoir une fenêtre de n'importe quelle forme MAIS c'est pas super stable
public class WindowShape : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    [DllImport("gdi32.dll")]
    static extern IntPtr CreatePolygonRgn(POINT[] lppt, int cPoints, int fnPolyFillMode);

    [DllImport("user32.dll")]
    static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    IntPtr hWnd;

    void Start()
    {
        hWnd = GetActiveWindow();

        POINT[] points = new POINT[]
        {
            new POINT { X = 50, Y = 0 },
            new POINT { X = 450, Y = 0 },
            new POINT { X = 400, Y = 300 },
            new POINT { X = 0, Y = 300 }
        };

        IntPtr region = CreatePolygonRgn(points, points.Length, 1);
        SetWindowRgn(hWnd, region, true);
    }
}