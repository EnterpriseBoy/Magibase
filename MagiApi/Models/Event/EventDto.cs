namespace MagiApi.Models.Event
{ 
    /// <summary>
    /// Event with an Name and Descrptoin
    /// </summary>
    public class EventDto
    {
        /// <summary>
        /// Id of the event
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the event
        /// </summary>
        public string Description { get; set; }
    }
}
