using DG.Tweening;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TokenMoving
{
    public class MovingMethodCol
    {
        private delegate Tween MovingMethod(ITokenContainer start, ITokenContainer target);

        private readonly 
            Dictionary<Type, Dictionary<Type, MovingMethod>> _movingMethods =
            new Dictionary<Type, Dictionary<Type, MovingMethod>>()
            {
                { 
                    typeof(BattlefieldCell),
                    new Dictionary<Type, MovingMethod>()
                    {
                        { typeof(PreCameraPlane), MoveFromCellToPreCameraPlane },
                        { typeof(BattlefieldCell), MoveFromCellToCell },
                    }
                },
                {
                    typeof(PreCameraPlane),
                    new Dictionary<Type, MovingMethod>()
                    {
                        { typeof(BattlefieldCell), MoveFromPreCameraPlaneToCell },
                    }
                }
            };

        public Tween MoveTokenFromContainerToContainer(ITokenContainer start, ITokenContainer target)
        {
            Type startType = start.GetType();
            Type targetType = target.GetType();
            var movingMethod = _movingMethods[startType][targetType];
            return movingMethod.Invoke(start, target);
        }

        private static Tween MoveFromCellToCell(ITokenContainer start, ITokenContainer target)
        {
            return null;
        }

        private static Tween MoveFromCellToPreCameraPlane(ITokenContainer start, ITokenContainer target)
        {
            return null;
        }

        private static Tween MoveFromPreCameraPlaneToCell(ITokenContainer start, ITokenContainer target)
        {
            return null;
        }
    }
}
