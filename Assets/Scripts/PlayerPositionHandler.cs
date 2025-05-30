using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPositionHandler : MonoBehaviour
{


    #region Condition
    Vector2 playerCurrentPosition;
    Vector2 currentCheckpointPosition;

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }

    public void OnEnemy()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }

    public void OnFinish()
    {
        GameManager.Instance.ChangeLevel(1);
        GameManager.Instance.ChangeScene(0);
    }
    #endregion

    #region SaveLoad
    public TransformData playerPositionData;

    private void LoadPosition()
    {
        transform.position = playerPositionData.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    #endregion


    #region Instruction
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    #endregion
}
