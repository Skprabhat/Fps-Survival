using UnityEngine;
using System.Collections;

public class DayRotation : MonoBehaviour
{

    [HideInInspector]
    public GameObject sun;
    [HideInInspector]
    public Light sunLight;

    [Range(0, 24)]
    public float timeOfDay = 12;

    public float secondsPerMinute = 60;
    [HideInInspector]
    public float secondsPerHour;
    [HideInInspector]
    public float secondsPerDay;

    public float timeMultiplier = 1;

    void Start()
    {
        sun = gameObject;
        sunLight = gameObject.GetComponent<Light>();

        secondsPerHour = secondsPerMinute * 60;
        secondsPerDay = secondsPerHour * 24;
    }

    // Update is called once per frame
    void Update()
    {
        SunUpdate();
    }

    public void SunUpdate()
    {
        sun.transform.localEulerAngles = new Vector3(Time.time * timeMultiplier, -30, 0);
    }
}