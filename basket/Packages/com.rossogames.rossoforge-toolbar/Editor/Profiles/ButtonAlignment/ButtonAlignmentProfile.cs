﻿using Rossoforge.Toolbar.Editor.Profiles.Buttons;
using UnityEngine;

namespace Rossoforge.Toolbar.Editor.Profiles.Alignments
{
    public abstract class ButtonAlignmentProfile : ScriptableObject
    {
        [field: SerializeField]
        public ButtonProfile[] Buttons { get; private set; }
    }
}
