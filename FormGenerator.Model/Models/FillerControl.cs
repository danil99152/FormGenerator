namespace FormGenerator.Model.Models
{
    internal class FillerControl : IControl
    {
        public string Class { get; set; }
        internal string Message { get; set; }

        public string GenerateHtml()
        {
            string html = $"<div>{this.Message}</div>";
            return html;
        }
    }
}
