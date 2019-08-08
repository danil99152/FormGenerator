using System.Collections.Generic;

namespace FormGenerator.Model.Models
{
    internal class SelectControl : DataControlAbstract
    {
        internal List<(string Value, string Text, bool Selected)> Options { get; set; }

        public override string GenerateHtml()
        {
            var props = this.GenerateProperties();
            string html = $"{props.Label}<p/><select {props.Properties}/>{this.GenerateOptions()}</select>";
            return this.GenerateControl(html);
        }

        private string GenerateOptions()
        {
            var result = string.Empty;
            var selectedFound = false;
            foreach(var option in this.Options)
            {
                var selected = string.Empty;
                if (!selectedFound && option.Selected)
                {
                    selectedFound = true;
                    selected = "selected";
                }

                result += $"<option value=\'{option.Value}\' {selected}>{option.Text}</option>";
            }

            return result;
        }
    }
}
