using Mirror;
using UnityEngine;

namespace Games.MulPlayer
{
    public class MulTestNetWorkManager: NetworkManager
    {
        public Transform spawnPoint1;
        public Transform spawnPoint2;
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            var player = Instantiate(playerPrefab);
            if (numPlayers == 0)
            {
                player.transform.position = spawnPoint1.position;
            }
            else
            {
                player.transform.position = spawnPoint2.position;
            }
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}