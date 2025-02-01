using System;
using System.IO;
using UnityEngine;

[Serializable]
class PlayerData
{
    // declare persistent data fields
    // initialize with <b>default value</b>, i.e. factory reset value
    public string playerName = "Pet Owner";

    public static PlayerData playerData;

    /// <summary>
    /// Loads player data from a file. I.e. load into PlayerData.instance
    /// </summary>
    public static PlayerData LoadFromFile()
    {
        string saveFilePath = GetSaveFilePath();

        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            playerData = JsonUtility.FromJson<PlayerData>(jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tLoad from File: {saveFilePath}");
            }

            return playerData;
        }
        catch (Exception ex)
        {
            if (ex is FileNotFoundException || ex is ArgumentException)
            {
                // create an default PlayerData instance
                playerData = new PlayerData();

                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning(
                        $"PlayerData\tFail to Load from file: {saveFilePath}. An empty player data is used."
                    );
                }

                return playerData;
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// save player data to a file. I.e. save PlayerData.instance
    /// </summary>
    public static void SaveToFile()
    {
        string saveFilePath = GetSaveFilePath();
        string jsonText = JsonUtility.ToJson(playerData);

        try
        {
            File.WriteAllText(saveFilePath, jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tsave to file: {saveFilePath}");
            }
        }
        catch (Exception ex)
        {
            if (
                ex is UnauthorizedAccessException
                || ex is ArgumentNullException
                || ex is DirectoryNotFoundException
            )
                if (Debug.isDebugBuild)
                {
                    Debug.LogError($"PlayerData\tfail to save to file: {saveFilePath}");
                }
        }
    }

    /// <summary>
    /// resets the player data and saving it to the file.
    /// </summary>
    public static void ResetPlayerData()
    {
        playerData = new PlayerData();
        SaveToFile();
        Debug.Log("PlayerData\tReset");
    }

    private static string GetSaveFilePath()
    {
        string fileName = "playerData";
        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        return filePath;
    }
}
