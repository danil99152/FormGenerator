using System.Collections.Generic;

namespace FormGenerator.Model.Models
{
    internal class RadioControl : DataControlAbstract
    {
        internal List<(string Value, string Label, bool Checked)> Items { get; set; }

        public override string GenerateHtml()
        {
            return this.GenerateControl(this.GenerateGroup());
        }

        private string GenerateGroup()
        {
            var props = this.GenerateProperties();
            var result = string.Empty;
            var selectedFound = false;
            foreach (var item in this.Items)
            {
                var check = string.Empty;
                if (!selectedFound && item.Checked)
                {
                    selectedFound = true;
                    check = "checked";
                }

                result += $"<p><input type=\'radio\' name=\'{this.Name}\' value=\'{item.Value}\' {check} />{item.Label}</p>";
            }

            return $"<div {props.Properties}>{result}</div>";
        }
    }
}
