using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public GameObject spawnPoint;
    int[] otherPlayers;
    int index;
    private const string txtFileName = "playerNames";
    public GridSpawnScript gridSpawnScript;

    public float moveDistance = 1.0f;
    public RolledNumberScript rolledNumberScript;
    Text diceNum;

    void Start()
    {
        if(gridSpawnScript == null)
        {
            gridSpawnScript = FindAnyObjectByType<GridSpawnScript>();
        }

        if(gridSpawnScript != null)
        {
            gridSpawnScript.GetGridArray();
        } else
        {
            Debug.LogError("GridSpawnScript not found");
        }

            characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject mainCharacter = Instantiate(playerPrefabs[characterIndex], spawnPoint.transform.position, Quaternion.identity);
        mainCharacter.GetComponent<NameScript>().SetPlayerName(PlayerPrefs.GetString("PlayerName"));

        otherPlayers = new int[PlayerPrefs.GetInt("PlayerCount")];
        string[] nameArray = ReadLineFromFile(txtFileName);

        for(int i = 0; i <otherPlayers.Length-1; i++)
        {
            spawnPoint.transform.position += new Vector3(0.2f, 0, 0.08f);
            index = Random.Range(0, playerPrefabs.Length);
            GameObject character = Instantiate(playerPrefabs[index], spawnPoint.transform.position, Quaternion.identity);
            character.GetComponent<NameScript>().SetPlayerName(nameArray[Random.Range(0, nameArray.Length)]);
        }
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

    public void DiceRoll()
    {
        if (rolledNumberScript == null)
        {
            rolledNumberScript = FindAnyObjectByType<RolledNumberScript>();
        }

        if (rolledNumberScript != null)
        {
            diceNum = rolledNumberScript.GetDiceNum();
            
        }
        else
        {
            Debug.LogError("RolledNumberScript not found");
        }
    }
}
