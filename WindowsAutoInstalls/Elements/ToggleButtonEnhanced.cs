using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace WindowsAutoInstalls.Elements
{
    public class ToggleButtonEnhanced
    {
        public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.RegisterAttached("IsChecked",
                                      typeof(bool),
                                      typeof(ToggleButtonEnhanced),
                                      new PropertyMetadata(OnChanged));

        public static bool GetIsChecked(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCheckedProperty);
        }
        public static void SetIsChecked(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCheckedProperty, value);
        }

        private static void OnChanged(DependencyObject o,
                                      DependencyPropertyChangedEventArgs args)
        {
            ToggleButton tb = o as ToggleButton;
            if (null != tb)
                tb.IsChecked = (bool)args.NewValue;
        }
    }
}
