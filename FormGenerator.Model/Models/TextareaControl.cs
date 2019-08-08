namespace FormGenerator.Model.Models
{
    internal class TextareaControl : DataControlAbstract
    {
        public override string GenerateHtml()
        {
            var props = this.GenerateProperties();
            string html = $"{props.Label}<p/><textarea type=\'text\' {props.Properties} style=\'min-width: 400px; min-height: 200px;\'></textarea>";
            return this.GenerateControl(html);
        }
    }
}
