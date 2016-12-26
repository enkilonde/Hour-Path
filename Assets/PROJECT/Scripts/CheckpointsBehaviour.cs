using UnityEngine;
using System.Collections;

public class CheckpointsBehaviour : BaseObject
{
    public Vector3 checkPoint;

    void Awake()
    {
        checkPoint = transform.position;
    }

    void Update()
    {
        if(transform.position.y < -100)
        {
            Respawn();
        }
    }

    void OnCollisionEnter(Collision coll)
    {

        if(coll.transform.GetComponent<TimeManager>() && coll.transform.GetComponent<TimeManager>().type == Type.Block_Rouge)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = checkPoint;
        
    }

}
