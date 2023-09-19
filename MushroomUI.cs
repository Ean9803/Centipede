using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomUI : MonoBehaviour
{
    private Centipede.Mushroom Mush;
    public float Radius = 1;
    public float Height = 2;

    public Centipede.Mushroom SetMush(Centipede.Mushroom Mush)
    {
        this.Mush = Mush;
        return Mush;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mush != null)
        {
            Mush.SetPos(new Centipede.Vector3(transform.position.x, transform.position.y, transform.position.z)).SetRadius(Radius).SetHeight(Height);
        }
    }
}
