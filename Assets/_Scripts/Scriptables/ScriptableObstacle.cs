using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Example")]
public class ScriptableObstacle : ScriptableObject
{
    public ObstacleType ObstacleType;
}

[Serializable]
public enum ObstacleType{
    notMoving = 0,
    moving = 1
}
