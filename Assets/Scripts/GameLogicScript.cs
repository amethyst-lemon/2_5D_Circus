using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject[] players; // Array of player objects
    public Transform[] boardSpaces; // The spots on the board
    private int currentPlayerIndex = 0;
    private bool isMoving = false;
    public RolledNumberScript rolledNumberScript;

    void Start()
    {
        foreach (var player in players)
        {
            player.transform.position = boardSpaces[0].position;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine(HandleDiceRoll());
        }
    }

    IEnumerator HandleDiceRoll()
    {
        isMoving = true;

        yield return new WaitUntil(() => rolledNumberScript.diceRollScript.isLanded);

        int diceRoll = int.Parse(rolledNumberScript.diceRollScript.diceFaceNum);
        Debug.Log($"Player {currentPlayerIndex + 1} rolled: {diceRoll}");

        StartCoroutine(MovePlayer(diceRoll));
    }

    IEnumerator MovePlayer(int diceRoll)
    {
        GameObject player = players[currentPlayerIndex];
        int currentPosition = GetPlayerPosition(player);
        int targetPosition = Mathf.Min(currentPosition + diceRoll, boardSpaces.Length - 1);

        // Move the player step by step
        for (int i = currentPosition + 1; i <= targetPosition; i++)
        {
            player.transform.position = boardSpaces[i].position;
            yield return new WaitForSeconds(0.5f); // Small delay to simulate movement
        }

        CheckSpecialTile(player, targetPosition);

        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        isMoving = false;
    }

    int GetPlayerPosition(GameObject player)
    {
        for (int i = 0; i < boardSpaces.Length; i++)
        {
            if (player.transform.position == boardSpaces[i].position)
                return i;
        }
        return 0;
    }

    void CheckSpecialTile(GameObject player, int position)
    {
        // Example: If player lands on tile 5, move back to start
        if (position == 5)
        {
            Debug.Log("Landed on a trap! Go back to start.");
            player.transform.position = boardSpaces[0].position;
        }
    }
}
