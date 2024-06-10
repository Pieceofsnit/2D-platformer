using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private EnemyMover _patrol;
    [SerializeField] private float _speed;
    [SerializeField] private Player _target;
}
