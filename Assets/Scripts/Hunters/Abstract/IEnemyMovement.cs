using System.Collections;
using UnityEngine;

public interface IEnemyMovement
{
    void Move();

    void Chase();

    void Patrol();

    IEnumerator UpdatingTargetPosition();
}
