using Nico.Utils.Core;
using UnityEngine;

namespace Nico.Template
{
    public class TemplateInput<T> : IComponent<T>
    {
        public T owner { get; set; }
        public readonly NormalControls controls;
        public TemplateInput(T owner)
        {
            this.owner = owner;
            controls = new NormalControls();
        }

        #region IComponent

        public void OnEnable()
        {
            controls.Player.Enable();
        }


        public void OnDisable()
        {
            controls.Player.Disable();
        }

        #endregion
    }
}