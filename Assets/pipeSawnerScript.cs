using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3;
    private float currentD = 0;
    public float heightOffset = 8;
    public float spawnRate1;
    public static float Speed ;
    public static float deltaY,pdeltaY;
    public float Yp1, Yp2;
    public float Speed1,Speed2;
    public float speedIncrease = 0.001f;
    public float distance;
    public kunkunscript kunkun;
    public float gravityscale;
    public float t;
    public float c1=0.05f, c2=1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake speed = " + Speed);
    }
    void Start()
    {
        Debug.Log("Start speed = "+Speed);
        Speed1 = 5;
        Speed2 = Speed;
        
        pdeltaY = transform.position.y;
        spawnPipe();
        spawnRate1 = spawnRate;
        
        gravityscale = kunkun.myRigidbody.gravityScale;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Speed1);
        distance = spawnRate1 * Speed1;
        Speed += speedIncrease * Time.deltaTime;
        if ( currentD < distance)
        {
            currentD += Speed* Time.deltaTime;
        }
        else
        {
            Speed2 = Speed;
            spawnPipe();
            currentD = 0;
            spawnRate1 = Random.Range(spawnRate - 1.5f, spawnRate + 0.5f);
        }


    }
    void spawnPipe()
    {
        t= (-Speed2+Mathf.Sqrt(Mathf.Pow(Speed2, 2) + 2 * speedIncrease * spawnRate1))/speedIncrease;
        Yp1 = (c1* Mathf.Pow(kunkun.flapStrength, 2) / gravityscale) * t;
        Yp2 = c2*4.905f * gravityscale * Mathf.Pow(t, 2);
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        deltaY = Random.Range(lowestPoint, highestPoint);
        float maxY1 = Yp1 ;
        float maxY2 = Yp2 ;

        if(deltaY - pdeltaY >= 0)
        {
            if(deltaY - pdeltaY >maxY1)
                deltaY = pdeltaY + maxY1;
        }
        else
        {
            if (pdeltaY - deltaY > maxY2)
                deltaY = pdeltaY - maxY2;
        }

            Instantiate(pipe, new Vector3(transform.position.x, deltaY, 0), transform.rotation);
        pdeltaY = deltaY;
        Debug.Log(Speed);
        
    }
}
