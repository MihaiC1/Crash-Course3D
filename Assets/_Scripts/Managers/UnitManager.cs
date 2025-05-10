using UnityEngine;

/// <summary>
/// An example of a scene-specific manager grabbing resources from the resource system
/// Scene-specific managers are things like grid managers, unit managers, environment managers etc
/// </summary>
public class UnitManager : StaticInstance<UnitManager> {

    public void SpawnObstacles() {
        SpawnUnit(ObstacleType.notMoving, new Vector3(1, 0, 0));
    }

    void SpawnUnit(ObstacleType t, Vector3 pos) {
        
    }
}