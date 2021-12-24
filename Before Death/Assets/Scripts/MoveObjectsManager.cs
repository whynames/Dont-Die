using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveObjectsManager : MonoSingleton<MoveObjectsManager>
{
    private ObjectToMove[] objectsToMove;

    private HashSet<ObjectToMove>  OutOfBoundsObjects = new HashSet<ObjectToMove>();


    public bool canMove;
    private float timeForSummon = 0; 
    [SerializeField]
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        objectsToMove = FindComponents.Find<ObjectToMove>().ToArray();
        OutOfBoundsObjects = new HashSet<ObjectToMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            foreach (ObjectToMove @object in objectsToMove)
            {
                @object.Move();
                if(@object.CheckOutofBounds())
                {
                    OutOfBoundsObjects.Add(@object);
                }
            }
        }

        if(Time.time > timeForSummon + waitTime)
        {
            timeForSummon = Time.time;
            int random =(int) Random.Range(0, OutOfBoundsObjects.Count);
            if(OutOfBoundsObjects.Count >1)
            {
                ObjectToMove selected = OutOfBoundsObjects.ElementAt(random);
                selected.Reuse();
                OutOfBoundsObjects.Remove(selected);
            }

        }
    }
}
