using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Components.Misc_Scripts
{
    public class LightCookieGrabber : MonoBehaviour
    {
        public Light2D glowLight;
        private SpriteRenderer glowRenderer;
        
        private void Awake()
        {
            glowRenderer = GetComponent<SpriteRenderer>();
            glowLight = GetComponent<Light2D>();
        }
        
        private void Update()
        {
            glowLight.lightCookieSprite = glowRenderer.sprite; //dynamically assign the lightCookie to sprite current position
        }
        
    }

}