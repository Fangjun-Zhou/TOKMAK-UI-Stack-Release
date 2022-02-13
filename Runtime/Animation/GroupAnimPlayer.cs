using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public enum PlayDirection
    {
        Forward,
        Backward
    }
    
    /// <summary>
    /// The player to play a group of animation.
    /// </summary>
    public class GroupAnimPlayer : MonoBehaviour
    {
        #region Public Field

        /// <summary>
        /// All the AnimPlayers controlled by this group.
        /// </summary>
        public List<AnimPlayer> players;

        /// <summary>
        /// The interval to play the anim.
        /// </summary>
        public float playInterval;

        #endregion

        #region Public Methods

        /// <summary>
        /// The default play method to play the group animation.
        /// </summary>
        /// <param name="id">the id of the animation.</param>
        /// <param name="interval">the interval between each play.</param>
        /// <param name="direction">the direction to play.</param>
        public async void Play(string id, float interval, PlayDirection direction)
        {
            if (direction == PlayDirection.Forward)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].Play(id);
                    await Task.Delay((int) (interval * 1000));
                }
            }
            else
            {
                for (int i = players.Count-1; i >= 0; i--)
                {
                    players[i].Play(id);
                    await Task.Delay((int) (interval * 1000));
                }
            }
        }

        /// <summary>
        /// The preset method to play forward.
        /// </summary>
        /// <param name="id">the id of anim to play.</param>
        public void PlayForward(string id)
        {
            Play(id, playInterval, PlayDirection.Forward);
        }
        
        /// <summary>
        /// The preset method to play backward.
        /// </summary>
        /// <param name="id">the id of anim to play.</param>
        public void PlayBackward(string id)
        {
            Play(id, playInterval, PlayDirection.Backward);
        }

        #endregion
    }
}