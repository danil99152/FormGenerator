namespace FormGenerator.Model.Models
{
    internal abstract class DataControlAbstract : IControl
    {
        internal DataControlAbstract()
        {
        }

        internal string Name { get; set; }
        internal string Placeholder { get; set; }
        internal bool Required { get; set; }
        internal Validator Validator { get; set; }
        internal string Value { get; set; }
        internal string Label { get; set; }
        public string Class { get; set; }
        internal bool Disabled { get; set; }

        protected (string Label, string Properties) GenerateProperties()
        {
            var disabled = this.Disabled ? "disabled" : string.Empty;
            var props = $"id=\'{this.Name}\' name=\'{this.Name}\' class=\'{this.Class}\' {disabled} placeholder=\'{this.Placeholder}\' formElement=\'true\' ";
            var label = $"<label for='{this.Name}'>{this.Label}</label>";
            return (Label: label, Properties: props);
        }

        protected string GenerateControl(string innerHtml)
        {
            return $"<div>{innerHtml}{this.Validator.GenerateValidator()}</div>";
        }

        public abstract string GenerateHtml();
    }
}
