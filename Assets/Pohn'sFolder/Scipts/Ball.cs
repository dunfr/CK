using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Grandfater ;
    public GameObject Grandmother ;
    public float ballSpeed;
    private float GrandfaterX;
    private float GrandmotherX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        Grandfater = GameObject.Find("Granfater");
        Grandmother = GameObject.Find("Grandmother");
    }

    // Update is called once per frame
    void Update()
    {
        GrandfaterX = Grandfater.transform.position.x;
        GrandmotherX = Grandmother.transform.position.x;
        dist = GrandmotherX - GrandfaterX;
        nextX = Mathf.MoveTowards(transform.position.x, GrandmotherX, ballSpeed * Time.deltaTime);
        baseY = Mathf.Lerp(Grandfater.transform.position.y, Grandmother.transform.position.y, (nextX - GrandfaterX) / dist);
        height = 2 * (nextX - GrandfaterX) * (nextX - GrandmotherX) / (-0.25f * dist * dist);
        Vector3 movePostion = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = quaternion(movePostion - transform.position);
        transform.position = movePostion;
        if(transform.position == Grandmother.transform.position)
        {
        }
    }
    public static Quaternion quaternion(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
