using UnityEngine;
using UnityEngine.UI;

public class LeaderboardLargePanel : MonoBehaviour
{
    [SerializeField] private GameObject userScore;
    [SerializeField] private GameObject stats;

    public void LoadPlayerData()
    {
        PlayerData data = PlayerData.Data;

        userScore.transform.Find("Place").GetComponent<Text>().text = "#1"; // Assuming the user is always #1
        userScore.transform.Find("Name").GetComponent<Text>().text = data.playerName;
        userScore.transform.Find("Points").GetComponent<Text>().text = data.drivingPoint.ToString() + " Points";

        stats.transform.Find("DrivingStats").GetComponent<Text>().text = "Miles: " + data.drivingMiles.ToString();
        stats.transform.Find("MinigameStats").GetComponent<Text>().text = "Minigame Stats: " + GetMinigameStats(data);
    }

    private string GetMinigameStats(PlayerData data)
    {
        return $"Bath: {data.statBath.playCount}/{data.statBath.winCount}, " +
               $"Feed: {data.statFeed.playCount}/{data.statFeed.winCount}, " +
               $"Fetch: {data.statFetch.playCount}/{data.statFetch.winCount}, " +
               $"HideNSeek: {data.statHideNSeek.playCount}/{data.statHideNSeek.winCount}, " +
               $"TugOWar: {data.statTugOWar.playCount}/{data.statTugOWar.winCount}, " +
               $"WalkScene: {data.statWalkScene.playCount}/{data.statWalkScene.winCount}";
    }
}
