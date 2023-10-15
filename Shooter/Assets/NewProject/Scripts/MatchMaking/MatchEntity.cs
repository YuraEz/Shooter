using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MatchEntity
{
    public int SceneId;
    public List<PlayerEntity> Players;

    public MatchEntity(int sceneId)
    {
        SceneId = sceneId;
        Players = new List<PlayerEntity>();
    }
}
