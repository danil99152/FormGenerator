namespace FormGenerator.Model.Models
{
    internal interface IControl
    {
        string Class { get; set; }
        string GenerateHtml();
    }
}
