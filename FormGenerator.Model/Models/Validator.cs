using System;
using System.Linq;

namespace FormGenerator.Model.Models
{
    internal enum ValidatorType
    {
        None,
        Text,
        Tel,
        Email,
        Select,
        Radio,
        Checkbox
    }

    internal class Validator
    {
        private ValidatorType _type;
        private string _parentName;

        internal Validator(string t, string parentName)
        {
            if (!string.IsNullOrEmpty(t))
            {
                t = t.First().ToString().ToUpper() + t.Substring(1);
                this._type = (ValidatorType)Enum.Parse(typeof(ValidatorType), t);
            }
            else
            {
                this._type = ValidatorType.None;
            }

            this._parentName = parentName;
        }

        internal string GenerateValidator()
        {
            var customContent = string.Empty;
            switch (this._type)
            {
                case ValidatorType.Text:
                    customContent = "validatorType =\'text\' pattern=\'.+\'";
                    break;
                case ValidatorType.Tel:
                    customContent = "validatorType=\'tel\' pattern=\'^((8|\\+7)-?)?\\(?\\d{3}\\)?-?\\d{1}-?\\d{1}-?\\d{1}-?\\d{1}-?\\d{1}-?\\d{1}-?\\d{1}$\'";
                    break;
                case ValidatorType.Email:
                    customContent = "validatorType='email' pattern='^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'";
                    break;
                case ValidatorType.Select:
                    customContent = "validatorType = 'select'";
                    break;
                case ValidatorType.Radio:
                    customContent = "validatorType = 'radio'";
                    break;
                case ValidatorType.Checkbox:
                    customContent = "validatorType = 'checkbox'";
                    break;
            }

            return $"<div valiatedControlId=\'{this._parentName}\' class=\'validator\' style=\'display: none; color: red;\' {customContent} >* Это поле обязательно для заполнения.</div>";
        }
    }
}
