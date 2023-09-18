using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using RPG.Control;

namespace MoreMountains.TopDownEngine
{
        
        /// <summary>
        /// TODO_DESCRIPTION
        /// </summary>
        [AddComponentMenu("TopDown Engine/Character/Abilities/BlockShield")]
        public class BlockState : CharacterAbility
        {
        /// a list of objects to offset when crouching
		[Tooltip("a list of objects to offset when crouching")]
        public List<GameObject> ObjectsToOffset;
        /// the offset to apply to objects when crouching
        [Tooltip("the offset to apply to objects when crouching")]
        public Vector3 OffsetBlock;
        /// the speed at which to offset objects
        [Tooltip("the speed at which to offset objects")]
        public float OffsetSpeed = 0f;

        public bool BlockAuthorized = true;
        public float BlockSpeed = 0f;
       // [SerializeField] GameObject disableup;
        public bool ForcedBlock = false;
        protected List<Vector3> _objectsToOffsetOriginalPositions;
        protected const string _yourAbilityAnimationParameterName = "block1";
        protected int _BlockAbilityAnimationParameter;
        protected bool _blocking = false;
        protected CharacterRun _characterRun;



        protected virtual void OffsetObjects()
        {
            // we move all the objects we want to move
            if (ObjectsToOffset.Count > 0)
            {
                for (int i = 0; i < ObjectsToOffset.Count; i++)
                {
                    Vector3 newOffset = Vector3.zero;
                    if (_movement.CurrentState == CharacterStates.MovementStates.Block)
                    {
                        newOffset = OffsetBlock;
                    }
                    
                    if (ObjectsToOffset[i] != null)
                    {
                        ObjectsToOffset[i].transform.localPosition = Vector3.Lerp(ObjectsToOffset[i].transform.localPosition, _objectsToOffsetOriginalPositions[i] + newOffset, Time.deltaTime * OffsetSpeed);
                    }
                }
            }
        }
        /// <summary>
        /// Here you should initialize our parameters
        /// </summary>
        protected override void Initialization()
            {
                base.Initialization();
            _characterRun = _character.FindAbility<CharacterRun>();

            // we store our objects to offset's initial positions
            if (ObjectsToOffset.Count > 0)
            {
                _objectsToOffsetOriginalPositions = new List<Vector3>();
                foreach (GameObject go in ObjectsToOffset)
                {
                    if (go != null)
                    {
                        _objectsToOffsetOriginalPositions.Add(go.transform.localPosition);
                    }
                }
            }
        }

            /// <summary>
            /// Every frame, we check if we're crouched and if we still should be
            /// </summary>
            public override void ProcessAbility()
            {
                base.ProcessAbility();
            HandleForcedBlock();
            DetermineState();
            CheckExitBlock();
            OffsetObjects();
        }

        protected virtual void Block()
        {
            if (!AbilityAuthorized// if the ability is not permitted
                || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal)// or if we're not in our normal stance
                || (!_controller.Grounded))// or if we're grounded
                                           // we do nothing and exit
            {
                return;
            }

            
                _health.DamageDisabled();
            

            // if this is the first time we're here, we trigger our sounds
            if ((_movement.CurrentState != CharacterStates.MovementStates.Block))
            {
                if (ForcedBlock)
            {
                _health.DamageDisabled();
            }
                // we play the crouch start sound 
                PlayAbilityStartFeedbacks();
                PlayAbilityStartSfx();
                PlayAbilityUsedSfx();
            }

            if (_movement.CurrentState == CharacterStates.MovementStates.Running)
            {
                _characterRun.RunStop();
            }

            _blocking = true;

            // we set the character's state to Crouching and if it's also moving we set it to Crawling
            _movement.ChangeState(CharacterStates.MovementStates.Block);
            //if ((Mathf.Abs(_horizontalInput) > 0) && (BlockAuthorized))
            //{
                //_movement.ChangeState(CharacterStates.MovementStates.Crawling);
           // }

            // we resize our collider to match the new shape of our character (it's usually smaller when crouched)
           // tu zmienic na wy³¹cz ¿ycie itp
           // if (ResizeColliderWhenCrouched)
            //{
               // _controller.ResizeColliderHeight(CrouchedColliderHeight, TranslateColliderOnCrouch);
            //}

            // we change our character's speed
            if (_characterMovement != null)
            {
                _characterMovement.MovementSpeed = 0f;
            }

            // we prevent movement if we can't crawl
            if (!BlockAuthorized)
            {
                _characterMovement.MovementSpeed = 0f;
            }
        }

        protected virtual void CheckExitBlock()
        {
            // if we're currently grounded
            if ((_movement.CurrentState == CharacterStates.MovementStates.Block)
                 
                 || _blocking)
            {
                if (_inputManager == null)
                {
                    if (!ForcedBlock)
                    {
                        ExitBlock();
                    }
                    return;
                }

                // but we're not pressing down anymore, or we're not grounded anymore
                if ((!_controller.Grounded)
                     || ((_movement.CurrentState != CharacterStates.MovementStates.Block)

                     && (_inputManager.TimeControlButton.State.CurrentState == MMInput.ButtonStates.Off) && (!ForcedBlock)))
                     {

                
                  
                }
            }
        }

        /// <summary>
        /// Returns the character to normal stance
        /// </summary>
        protected virtual void ExitBlock()
        {
            _blocking = false;

            // we return to normal walking speed
            if (_characterMovement == true)
            {
                _movement.ChangeState(CharacterStates.MovementStates.Running);
                //_characterMovement.ResetSpeed();
                _characterMovement.MovementSpeed = 5f;
            }

            
                _health.DamageEnabled();
               
            
            // we play our exit sound
            StopAbilityUsedSfx();
            PlayAbilityStopSfx();
            StopStartFeedbacks();
            PlayAbilityStopFeedbacks();

            // W³acz zycia moze obliczenia zadawania obra¿eñ
            if ((_movement.CurrentState == CharacterStates.MovementStates.Block))
            {
                _movement.ChangeState(CharacterStates.MovementStates.Idle);
            }

            //_controller.ResetColliderSize();
        }


        protected virtual void HandleForcedBlock()
        {
            if (ForcedBlock && (_movement.CurrentState != CharacterStates.MovementStates.Block))
            {
                Block();
            }
        }
        /// <summary>
        /// Called at the start of the ability's cycle, this is where you'll check for input
        /// </summary>
        protected override void HandleInput()
            {
            base.HandleInput();
            
            if (_inputManager.TimeControlButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                Block();
            }
            if (_inputManager.TimeControlButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
            { 
             ExitBlock();
            }
            
        }
        /*protected virtual void GoBlock(bool state)
        {
            
            // if we're still here, we display a text log in the console
            MMDebug.DebugLogTime("We're doing something yay!");
            if (state == true)
            {
                MMDebug.DebugLogTime("We're doing something yay!");
                
                    _animator.SetBool(_yourAbilityAnimationParameterName, state);
                
            }
            else
            {
                MMDebug.DebugLogTime("Stop");
                
            }
        }*/

        /// <summary>
        /// If we're pressing down, we check for a few conditions to see if we can perform our action
        /// </summary>
        protected virtual void DetermineState()
        {
            if ((_movement.CurrentState == CharacterStates.MovementStates.Block))
            {
                if ((_controller.CurrentMovement.magnitude > 0) && (BlockAuthorized))
                {
                    _movement.ChangeState(CharacterStates.MovementStates.Idle);
                }
                
            }
        }

        /// <summary>
        /// Adds required animator parameters to the animator parameters list if they exist
        /// </summary>
        protected override void InitializeAnimatorParameters()
            {
                RegisterAnimatorParameter(_yourAbilityAnimationParameterName, AnimatorControllerParameterType.Bool, out _BlockAbilityAnimationParameter);
            }

            /// <summary>
            /// At the end of the ability's cycle,
            /// we send our current crouching and crawling states to the animator
            /// </summary>
            public override void UpdateAnimator()
            {
                MMAnimatorExtensions.UpdateAnimatorBool(_animator, _BlockAbilityAnimationParameter, (_movement.CurrentState == CharacterStates.MovementStates.Block), _character._animatorParameters, _character.RunAnimatorSanityChecks);
            //MMAnimatorExtensions.UpdateAnimatorBool(_animator,_crawlingAnimationParameter,(_movement.CurrentState == CharacterStates.MovementStates.Crawling), _character._animatorParameters, _character.RunAnimatorSanityChecks);
        }
    }
}


