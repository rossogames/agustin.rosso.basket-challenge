using Rossoforge.Popups.PopupTemplate;
using UnityEngine;

namespace Rossoforge.Popups.PopupDemo
{
    public class Demo : MonoBehaviour
    {
        public PopupTemplateView popupDemo;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (popupDemo.CanBeOpened())
                {
                    popupDemo.Open();
                }
                else if (popupDemo.CanBeClosed())
                {
                    popupDemo.Close();
                }
            }
        }
    }
}