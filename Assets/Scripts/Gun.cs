using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Custom/Gun")]
public class Gun : ScriptableObject
{
    [SerializeField] float damage = 5f;
    [SerializeField] float firerate = 500f;
    [SerializeField] int capacity = 10;
    [SerializeField] float reloadTime = 3f;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float range = 10f;

    public float Damage => damage;
    public float Firerate => firerate;
    public int Capacity => capacity;
    public float ReloadTime => reloadTime;
    public float BulletSpeed => bulletSpeed;
    public float Range => range;
}
