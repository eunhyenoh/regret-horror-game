using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingGhostManager : MonoBehaviour
{
    static public FollowingGhostManager S;

    [Header("Player")]
    [SerializeField]
    GameObject Player;

    public List<Vector3> PlayerPos;
   

    [Header("Saving Time")]
    public float savingTime = 3f;
    float timer = 0;

    void Start()
    {
        PlayerPos = new List<Vector3>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > savingTime)
        {
            if (PlayerPos.Count > 5)
            {
                PlayerPos.Remove(PlayerPos[0]);
            }
            PlayerPos.Add(Player.transform.position);
        }
    }
}
