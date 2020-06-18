using Markdig;

namespace SelfService.Shared
{
    public class ProgramResource
    {
        public string CurrentInformation { get; set; }

        public string CurrentInformationAsMarkdown
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.CurrentInformation))
                {
                    return string.Empty;
                }
                return Markdown.ToHtml(this.CurrentInformation);
            }
        }
    }
}