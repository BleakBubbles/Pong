using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class NetworkManager : Mirror.NetworkManager
{
    private GameObject ball;

    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // destroy ball
        if (ball != null)
            NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}
