using System;
using System.Collections.Generic;
using System.Linq;

namespace FormGenerator.Model.Models
{
    internal enum ControlTypes
    {
        Filler,
        Text,
        Textarea,
        Checkbox,
        Select,
        Radio,
        Button
    }

    internal static class ControlFactory
    {
        private static readonly Dictionary<ControlTypes, Type> typesMap = new Dictionary<ControlTypes, Type>
        {
            { ControlTypes.Filler, typeof(FillerControl) },
            { ControlTypes.Text, typeof(TextControl) },
            { ControlTypes.Textarea, typeof(TextareaControl) },
            { ControlTypes.Checkbox, typeof(CheckboxControl) },
            { ControlTypes.Select, typeof(SelectControl) },
            { ControlTypes.Radio, typeof(RadioControl) },
            { ControlTypes.Button, null },
        };

        internal static IControl Create(dynamic control)
        {
            string t = control.type;
            t = t.First().ToString().ToUpper() + t.Substring(1);
            var type = (ControlTypes)Enum.Parse(typeof(ControlTypes), t);


            if (type == ControlTypes.Filler)
            {
                return new FillerControl { Message = control.message, Class = control["class"] };
            }

            if (type == ControlTypes.Button)
            {
                return new ButtonControl { Class = control["class"], Text = control.text };
            }

            return ControlFactory.CreateDataControl(control, type);
        }

        private static DataControlAbstract CreateDataControl(dynamic control, ControlTypes type)
        {
            var t = typesMap[type];
            if (t != null)
            {
                var result = (DataControlAbstract)Activator.CreateInstance(typesMap[type]);
                result.Name = control.name;
                result.Placeholder = control.placeholder;
                result.Required = Convert.ToBoolean(control.required);
                result.Value = control.value;
                result.Label = control.label;
                result.Class = control["class"];
                result.Disabled = Convert.ToBoolean(control.disabled);
                string validatorType = control.validationRules.type;
                result.Validator = new Validator(validatorType, result.Name);

                if (result is CheckboxControl)
                {
                    (result as CheckboxControl).Checked = Convert.ToBoolean(control["checked"]);
                }

                if (result is SelectControl)
                {
                    var select = result as SelectControl;
                    select.Options = new List<(string Value, string Text, bool Selected)>();
                    foreach (var option in control.options)
                    {
                        select.Options.Add((Value: option.value, Text: option.text, Selected: Convert.ToBoolean(option.selected)));
                    }
                }

                if (result is RadioControl)
                {
                    var radio = result as RadioControl;
                    radio.Items = new List<(string Value, string Label, bool Checked)>();
                    foreach (var option in control.items)
                    {
                        radio.Items.Add((Value: option.value, Label: option.label, Checked: Convert.ToBoolean(option["checked"])));
                    }
                }

                return result;
            }

            return null;
        }
    }
}
