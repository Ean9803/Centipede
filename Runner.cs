using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    private Centipede Centi;
    public Transform StartPos;
    public Transform EndPos;
    public int SubDivide = 5;
    public bool Reset;

    public List<MushroomUI> Mushes = new List<MushroomUI>();
    
    private Vector3 V(Centipede.Vector3 Vector)
    {
        return new Vector3(Vector.x, Vector.y, Vector.z);
    }

    private Centipede.Vector3 C(Vector3 Vector)
    {
        return new Centipede.Vector3(Vector.x, Vector.y, Vector.z);
    }

    private void OnDrawGizmos()
    {
        if (Centi == null || Reset)
        {
            Reset = false;
            Centi = new Centipede();
            foreach (var item in Mushes)
            {
                if (item != null)
                {
                    Vector3 Pos = item.gameObject.transform.position;
                    Centi.AddMushroom(item.SetMush(new Centipede.Mushroom(new Centipede.Vector3(Pos.x, Pos.y, Pos.z), item.Radius, item.Height)));
                }
            }
        }
        else
        {
            Centipede.WaterFlowNode[] Test = Centi.GenerateClearPath(SubDivide, C(StartPos.position), C(EndPos.position));

            for (int l = 0; l < Test.Length; l++)
            {
                if (Test[l].Obstructed)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(V(Test[l].Position), 0.1f);

                    if (Test[l].Ring != null)
                    {
                        for (int i = 0; i < Test[l].Ring.Count; i++)
                        {
                            Gizmos.color = Color.yellow;
                            Gizmos.DrawWireSphere(V(Test[l].Ring[i]), 0.1f);

                            Gizmos.color = Color.cyan;
                            Gizmos.DrawWireSphere(V(Test[l].SurfaceRing[i]), 0.1f);

                            Gizmos.color = Color.green;
                            Gizmos.DrawLine(V(Test[l].SurfaceRing[i]), V(Test[l].Ring[i]));
                        }
                    }
                }
                else
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(V(Test[l].Position), 0.1f);
                }
                if (l > 0)
                {
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(V(Test[l].Position), V(Test[l - 1].Position));
                }
            }
        }
    }
}
