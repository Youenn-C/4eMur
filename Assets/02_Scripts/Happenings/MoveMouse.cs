// using UnityEngine;
// using System.Runtime.InteropServices;
// public static class User32
// {
//     [DllImport("user32.dll")]
//     public static extern long GetCursorPos(ref POINT point);
//
//     [DllImport("user32.dll")]
//     public static extern long SetCursorPos(int x, int y);
//
//     [StructLayout(LayoutKind.Sequential)]
//     public struct POINT
//     {
//         public int x;
//         public int y;
//     }
// }
//
// public static bool TryWarpCursorPosition(Vector2 unityScreenPosition)
// {
// #if UNITY_STANDALONE_WIN
//     try
//     {
//         // Convert Unity position to use top-of-screen Y coordinate like Windows
//         var newUnityCursorPositionFromTopOfScreen = new Vector2Int((int)unityScreenPosition.x, Screen.height - (int)unityScreenPosition.y);
//
//         // Get Windows cursor position
//         User32.POINT _windowsCursorPosition = default;
//         User32.GetCursorPos(ref _windowsCursorPosition);
//         var currentWindowsCursorPosition = new Vector2Int(_windowsCursorPosition.x, _windowsCursorPosition.y);
//
//         // Get Unity cursor position
//         var currentUnityCursorPositionFromTopOfScreen = new Vector2Int
//         (
//             (int)UnityEngine.Input.mousePosition.x,
//             Screen.height - (int)UnityEngine.Input.mousePosition.y
//         );
//
//         // Calculate the offset between the absolute Windows position and the local Unity position
//         var unityToWindowsOffset = currentWindowsCursorPosition - currentUnityCursorPositionFromTopOfScreen;
//
//         // Calculate the new absolute Windows cursor position based on a local position argument
//         var newWindowsCursorPositionX = newUnityCursorPositionFromTopOfScreen.x + unityToWindowsOffset.x;
//         var newWindowsCursorPositionY = newUnityCursorPositionFromTopOfScreen.y + unityToWindowsOffset.y;
//         User32.SetCursorPos(newWindowsCursorPositionX, newWindowsCursorPositionY);
//
//         return true;
//     }
//     catch (Exception ex)
//     {
//         Debug.LogException(ex);
//         return false;
//     }
// #else
//     return false;
// #endif
// }