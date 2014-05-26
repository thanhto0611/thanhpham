using System;

namespace FriendTracker
{
    [Serializable()]
    public class Friend
    {
        public string Name { get; set; }
        public string AddDate { get; set; }
        public string DeleteDate { get; set; }
        public bool HasChangedName { get; set; }
        public bool IsNew { get; set; }
        public bool IsManual { get; set; }
        public string ID { get; set; }
    }
}
