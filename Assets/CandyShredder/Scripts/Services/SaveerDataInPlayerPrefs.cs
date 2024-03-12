using System;
using UnityEngine;

public class SaveerDataInPlayerPrefs : SaveerData
{
    public override T Load<T>(string nameParameter, T defaultValue)
    {
        if (PlayerPrefs.HasKey(nameParameter) == false)
            return defaultValue;

        Type inType = typeof(T);

        if (inType == typeof(int))
            return (T)(object)PlayerPrefs.GetInt(nameParameter);
        else if (inType == typeof(float))
            return (T)(object)PlayerPrefs.GetFloat(nameParameter);
        else
            return (T)(object)PlayerPrefs.GetString(nameParameter);
    }

    public override void Save<T>(string nameParameter, T value)
    {
        Type inType = typeof(T);

        if (inType == typeof(int))
            PlayerPrefs.SetInt(nameParameter, int.Parse(value.ToString()));
        else if (inType == typeof(float))
            PlayerPrefs.SetFloat(nameParameter, float.Parse(value.ToString()));
        else if (inType == typeof(string))
            PlayerPrefs.SetString(nameParameter, value.ToString());
    }
}
