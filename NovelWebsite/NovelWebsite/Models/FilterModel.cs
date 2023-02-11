namespace NovelWebsite.Models
{
    public class FilterModel
    {
        public string BookStatusId { get; set; }
        public int CategoryId { get; set; }
        public string RankType { get; set; }
        public Tuple<int, int> ChapterRange { get; set; }
        public string OrderBy { get; set; }
        public List<string> ListTags { get; set; }
    }
}
