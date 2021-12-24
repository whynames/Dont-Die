using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public static class UniversalFunctions 
{
    
    public static void MoveSmooth(this Transform transform, float speed = 1, float? x = null, float? y = null)
    {
        Vector3 target = new Vector3(x ?? transform.position.x,  y ?? transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public static void MoveInstant(this Transform transform, float? x = null, float? y = null)
    {
        transform.position = new Vector3(x ?? transform.position.x, y ?? transform.position.y, transform.position.z);
    }

    public static IEnumerator LerpForGameEnd(this float value, float end, float speed)
    {
        float t=0;

        while(t<1)
        {
            t+= Time.deltaTime * speed;
            value = Mathf.Lerp(value, end, t);
            yield return null;
        }
        
        yield break;
    }


}

public static class FindComponents
{
    public static List<T> Find<T>()
    {
        List<T> interfaces = new List<T>();
        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
            foreach (var childInterface in childrenInterfaces)
            {
                interfaces.Add(childInterface);
            }
        }
        return interfaces;
    }
}

