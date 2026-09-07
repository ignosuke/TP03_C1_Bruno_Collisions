using System;
using UnityEngine;

// Esto serviría de pseudo base de datos de momento

public static class PlayerData
{
    public enum ID
    {
        One,
        Two
    }

    public static float playerOneSpeed = 5f; // Entre 0.5 y 20
    public static float playerOneWidth = 2f; // Entre 1 y 3
    public static Color playerOneColor = Color.white; // R/G/B, C/Y/M o White

    public static float playerTwoSpeed = 5f;
    public static float playerTwoWidth = 2f;
    public static Color playerTwoColor = Color.white;

    public static event Action<ID, float> OnSpeedChanged;
    public static event Action<ID, float> OnWidthChanged;
    public static event Action<ID, Color> OnColorChanged;

    public static float GetSpeed(ID id) => id == ID.One ? playerOneSpeed : playerTwoSpeed;
    public static float GetWidth(ID id) => id == ID.One ? playerOneWidth : playerTwoWidth;
    public static Color GetColor(ID id) => id == ID.One ? playerOneColor : playerTwoColor;

    public static void SetSpeed(ID id, float value)
    {
        if (id == ID.One) playerOneSpeed = value;
        else playerTwoSpeed = value;

        OnSpeedChanged?.Invoke(id, value);
    }

    public static void SetWidth(ID id, float value)
    {
        if (id == ID.One) playerOneWidth = value;
        else playerTwoWidth = value;

        OnWidthChanged?.Invoke(id, value);
    }

    public static void SetColor(ID id, Color value)
    {
        if (id == ID.One) playerOneColor = value;
        else playerTwoColor = value;

        OnColorChanged?.Invoke(id, value);
    }
}
