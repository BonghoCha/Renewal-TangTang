using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region ## Class ##

    public class AudioClipEx
    {
        private ClipType clipType;
        private string clipName;
        private AudioClip clip;

        public AudioClipEx(ClipType clipType, string clipName, AudioClip clip)
        {
            this.clipType = clipType;
            this.clipName = clipName;
            this.clip = clip;
        }

        #region ## Getter ##

        public ClipType GetType()
        {
            return this.clipType;
        }

        public string GetName()
        {
            return this.clipName;
        }
        
        public AudioClip GetClip()
        {
            return this.clip;
        }

        #endregion
    }

    #endregion

    #region ## Enum ##

    public enum ClipType
    {
        BGM,
        Effect
    }
    

    #endregion

    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject();
                go.name = "SoundManager";
                _instance = go.AddComponent<SoundManager>();
                DontDestroyOnLoad(_instance);
            }
            
            return _instance;
        }
    }
    
    [SerializeField] private AudioSource _BGM;
    [SerializeField] private List<AudioSource> _Effects;

    private Dictionary<string, AudioClipEx> _clipDic = new Dictionary<string, AudioClipEx>();

    public void Play(string clipName)
    {
        if (_clipDic.TryGetValue(clipName, out var clip))
        {
            var clipType = clip.GetType();
            switch (clipType)
            {
                case ClipType.BGM:
                {
                    Play(_BGM, clip.GetClip());
                    break;
                }
                case ClipType.Effect:
                {
                    var isPlayed = false;
                    foreach (var effect in _Effects)
                    {
                        if (effect.isPlaying)
                        {
                            Play(effect, clip.GetClip());

                            isPlayed = true;
                            break;
                        }
                    }

                    if (!isPlayed)
                    {
                        Play(_Effects[0], clip.GetClip());
                    }

                    break;
                }
            }
        }
        else
        {
            Debug.Log("[SoundManager] not found the clip !!");
        }
    }

    public void Play(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
