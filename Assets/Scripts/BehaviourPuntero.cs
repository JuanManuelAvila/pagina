using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BehaviourPuntero : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Need Audio?")] public bool _audio;
    private AudioSource _audioSource;
    private AudioSource[] allAudioSources;

    public AudioClip _Audio;

    private void Awake()
    {
        #region OpcionesAudio

        if (gameObject.GetComponent<AudioSource>() == null && _audio)
        {
            gameObject.AddComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().playOnAwake = false;
            gameObject.GetComponent<AudioSource>().clip = _Audio;
        }
        else if (gameObject.GetComponent<AudioSource>() != null && !_audio)
        {
            DestroyImmediate(gameObject.GetComponent<AudioSource>());
        }

        #endregion
        
    }

    private void Start()
    {
        _audioSource = _audio ? GetComponent<AudioSource>() : null;
    }
    
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(Resources.Load<Texture2D>("Punteros/Puntero1"), new Vector2(0f, 0f), CursorMode.ForceSoftware);

        if (_audio)
            if (GetComponent<Button>())
            {
                if (GetComponent<Button>().interactable)
                {
                    StopAllAudio();
                    if(!_audioSource.isPlaying)
                        _audioSource.Play();
                }

            }
            else
            {
                StopAllAudio();
                if(!_audioSource.isPlaying)
                    _audioSource.Play();
            }
           

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);

        if(_audio)
            _audioSource.Stop();
    }

    private void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);      
    }

    #region StopAllAudios

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    

    #endregion
    
    
     
}
