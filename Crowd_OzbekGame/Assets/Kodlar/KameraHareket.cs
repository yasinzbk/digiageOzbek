using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    public Transform takipEdilecekObje;

    public float degisimHizi;

    public float kameraTakipMesafesi;

    private void LateUpdate()
    {
        Vector3 yeni = new Vector3(takipEdilecekObje.position.x, transform.position.y, takipEdilecekObje.position.z-kameraTakipMesafesi);

        transform.position = Vector3.Lerp(transform.position, yeni, Time.deltaTime * degisimHizi);
    }

}
