namespace FormGenerator.Model.Models
{
    internal class TextControl : DataControlAbstract
    {
        public override string GenerateHtml()
        {
            var props = this.GenerateProperties();
            string html = $"{props.Label}<p/><input type=\'text\' {props.Properties}/>";
            return this.GenerateControl(html);
        }
    }
}
