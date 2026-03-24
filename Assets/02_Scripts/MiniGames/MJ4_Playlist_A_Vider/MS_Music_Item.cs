using System;
using UnityEngine;

public class MS_Music_Item : MonoBehaviour
{
    [SerializeField] private SO_MusicDatas _currentMusicDatas;


    private void Start()
    {
        
    }

    public void RemoveMusicFromQueue()
    {
        Destroy(gameObject);
    }
    
}
