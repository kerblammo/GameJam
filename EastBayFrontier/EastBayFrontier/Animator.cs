using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EastBayFrontier
{
    public class Animator
    {
        #region Attributes
        public PictureBox PicBox { get; set; }          //Where to draw image
        public List<Image> Sprite { get; set; }         //Images to be used for animation 
        public int SpriteIndex { get; set; }            //Current frame in animation
        public int AnimationSpeed { get; set; }         //How quickly to cycle through frames
        public int AnimationThreshold { get; set; }     //When to cycle frames
        public int AnimationProgress { get; set; }      //How long until animation needs to change frames
        #endregion

        /// <summary>
        /// Animate the picturebox 
        /// </summary>
        public void Play()
        {
            //increase progress and see if frame must change
            AnimationProgress += AnimationSpeed;
            if (AnimationProgress >= AnimationThreshold)
            {
                AnimationProgress = 0;
                if (SpriteIndex + 1 >= Sprite.Count)    //return to beginning
                {
                    SpriteIndex = 0;
                }
                else    //next frame
                {
                    SpriteIndex++;
                }
                //update image
                PicBox.Image = Sprite[SpriteIndex];
            }
        }

        /// <summary>
        /// Stop the animation
        /// </summary>
        public void Stop()
        {
            AnimationProgress = 0;
            SpriteIndex = 0;
            PicBox.Image = Sprite[SpriteIndex];
        }

        /// <summary>
        /// Default Constructor with initial values. Note that PicBox and Sprite are not set
        /// </summary>
        public Animator()
        {
            SpriteIndex = 0;
            AnimationSpeed = 20;
            AnimationProgress = 0;
            AnimationThreshold = 100;
        }
        /// <summary>
        /// Construct Animator with supplied attributes
        /// </summary>
        /// <param name="sprite">The images to animate through</param>
        /// <param name="picbox">The picturebox to draw images at</param>
       public Animator(List<Image> sprite, PictureBox picbox)
        {
            Sprite = sprite;
            PicBox = picbox;
            SpriteIndex = 0;
            AnimationSpeed = 20;
            AnimationProgress = 0;
            AnimationThreshold = 100;
        }
    }
}
