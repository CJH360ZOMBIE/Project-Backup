using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameassets : MonoBehaviour
{
    private static Gameassets _i;

    public static Gameassets i {
        get {
            if (_i == null) _i = (Instantiate(Resources.Load("Gameassets")) as GameObject).GetComponent<Gameassets>(); 
            return _i;              
        }
    }
    public Transform TheDamagePopUp; 
}

