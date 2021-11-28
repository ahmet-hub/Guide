namespace ReportCreatorWorker.Options
{
    public class KafkaOptions
    {
        public string Endpoint { get; set; }
        public string ReportTopic { get; set; }
        public string GroupId { get; set; }
    }
}
