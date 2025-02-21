using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ButtonMuteHandler : MonoBehaviour
    {
        public Sprite mutedSprite; // Sprite to show when muted
        public Sprite unmutedSprite; // Sprite to show when unmuted

        private Image buttonImage;
        private bool isMuted = false;

        private void Start()
        {
            isMuted = NarrationSystemSingleton.GetInstance().IsMuted();
            // Get the Image component of the button
            buttonImage = GetComponent<Image>();

            // Set the initial sprite based on the current mute state
            UpdateButtonImage();
        }

        public void Mute()
        {
            // Toggle the mute state in the NarrationSystemSingleton
            NarrationSystemSingleton.GetInstance().ToggleMute();

            // Toggle the local mute state
            isMuted = !isMuted;

            // Update the button image
            UpdateButtonImage();
        }

        private void UpdateButtonImage()
        {
            // Change the button's sprite based on the mute state
            buttonImage.sprite = isMuted ? mutedSprite : unmutedSprite;
        }
    }
}
