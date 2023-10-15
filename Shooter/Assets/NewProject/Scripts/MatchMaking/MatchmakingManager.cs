using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchmakingManager : NetworkManager
{
    public List<MatchEntity> AllMatches;
    public List<Scene> AllScenes;
    private int LastSceneIndex = 1;
    private bool subscenesLoaded = false;
    public PlayerEntity Player;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        StartCoroutine(ECreateServerAddPlayer(conn));
    }

    private IEnumerator ECreateServerAddPlayer(NetworkConnectionToClient conn)
    {
        while (!subscenesLoaded)
            yield return null;
        conn.Send(new SceneMessage { sceneName = AllScenes[0].name, sceneOperation = SceneOperation.LoadAdditive });
        AllMatches[0].Players.Add(Player);
        yield return new WaitForEndOfFrame();
        base.OnServerAddPlayer(conn);
        SceneManager.MoveGameObjectToScene(conn.identity.gameObject, AllScenes[0]);
       // conn.identity.GetComponent<Collider>().enabled = true;
    }

    public override void OnStartServer()
    {
        CreateMatch();
        CreateMatch();
        CreateMatch();

    }

    [Server]
    public void CreateMatch()
    {
        StartCoroutine(ECreateMatch());
    }

    private IEnumerator ECreateMatch() 
    {
        LoadSceneParameters MatchParameters = new LoadSceneParameters(LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(1, MatchParameters);
        AllScenes.Add(SceneManager.GetSceneAt(LastSceneIndex));
 
        MatchEntity newMatch = new MatchEntity(LastSceneIndex);
        AllMatches.Add(newMatch);

        LastSceneIndex++;
        subscenesLoaded = true;
    }
}
