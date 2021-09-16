using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumnsPositioner : MonoBehaviour
{
    public float distanceBetweenColumns;
    public Transform[] enemyColumns;

    [ContextMenu("ResetColumnPositions")]
    void ResetColumnPositions() {
        float enemyColumnCount = enemyColumns.Length;
        for (int i = 0; i < enemyColumnCount; i++) {
            Transform enemyColumn = enemyColumns[i];
            float positionX = -distanceBetweenColumns * enemyColumnCount / 2f + distanceBetweenColumns * (i + 0.5f);
            Vector3 columnPosition = enemyColumn.position;
            enemyColumn.position = new Vector3(positionX, columnPosition.y, columnPosition.z);
        }
    }
}
