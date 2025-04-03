using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class PlayerScript : MonoBehaviour
{
    //general player stuff
    public GameObject[] playerPrefabs;
    int characterIndex;
    public GameObject spawnPoint;
    int[] otherPlayers;
    int index;
    private const string txtFileName = "playerNames";

    public List<GameObject> players = new List<GameObject>();
    public int currentPlayerIndex = 0;

    //turn UI stuff
    public Text turnText;
    public Text[] scoreTexts;
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();

    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        GameObject mainCharacter = Instantiate(playerPrefabs[characterIndex], spawnPoint.transform.position, Quaternion.identity);
        mainCharacter.GetComponent<NameScript>().SetPlayerName(PlayerPrefs.GetString("PlayerName"));
        players.Add(mainCharacter);
        playerScores[mainCharacter] = 0;

        otherPlayers = new int[PlayerPrefs.GetInt("PlayerCount")];
        string[] nameArray = ReadLineFromFile(txtFileName);

        for(int i = 0; i <otherPlayers.Length-1; i++)
        {
            spawnPoint.transform.position += new Vector3(0.2f, 0, 0.08f);
            index = Random.Range(0, playerPrefabs.Length);
            GameObject character = Instantiate(playerPrefabs[index], spawnPoint.transform.position, Quaternion.identity);
            character.GetComponent<NameScript>().SetPlayerName(nameArray[Random.Range(0, nameArray.Length)]);
            players.Add(character);
            playerScores[character] = 0;
        }
        StartTurn();
    }

    void StartTurn()
    {
        //do not change, displays player names
        string playerName = players[currentPlayerIndex].GetComponent<NameScript>().GetPlayerName();
        turnText.text = playerName + "'s Turn";
        players[currentPlayerIndex].GetComponent<PlayerMoveS>().enabled = true;
        //

        UpdateScoreDisplay();
    }

    public void EndTurn()
    {
        players[currentPlayerIndex].GetComponent<PlayerMoveS>().enabled = false;
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        StartTurn();
    }


    string[] ReadLineFromFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if(textAsset != null)
        {
            return textAsset.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            Debug.LogError("File not found: " + fileName);
            return new string[0];
        }
    }

    public void AddScore(GameObject player, int points)
    {
        if (!playerScores.ContainsKey(player))
        {
            Debug.LogError("Player not found in score list: " + player.name);
            return;
        }

        int oldScore = playerScores[player];
        playerScores[player] += points;
        int newScore = playerScores[player];

        Debug.Log(player.name + " Score updated: " + oldScore + " -> " + newScore + " (+" + points + ")");

        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i == currentPlayerIndex)
            {
                scoreTexts[i].gameObject.SetActive(true);
                scoreTexts[i].text = "Score: " + playerScores[players[i]];
            }
            else
            {
                scoreTexts[i].gameObject.SetActive(false);
            }
        }
    }

}
